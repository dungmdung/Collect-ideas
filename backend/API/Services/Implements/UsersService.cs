﻿using API.DTOs.User.Authentication;
using API.DTOs.User.ChangePassword;
using API.DTOs.User.CreateUser;
using API.DTOs.User.GetUser;
using API.DTOs.User.UpdateUser;
using API.Helpers;
using API.Queries;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Application.Common;
using Common.Constant;
using Common.DataType;
using Common.Enums;
using Common.Jwt;
using Data.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services.Implements
{
    public class UsersService : IUsersService
    {
        private readonly IUserRepository _userRepository;

        public UsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Response> ChangePasswordAsync(ChangePasswordRequest request)
        {
            using (var transaction = _userRepository.DatabaseTransaction())
            {
                try
                {
                    var user = await _userRepository.GetAsync(user => user.Id == request.Id);

                    if (user != null && user.Password == request.OldPassword)
                    {
                        user.Password = request.NewPassword;
                    }
                    else
                    {
                        return new Response(false, ErrorMessages.PasswordError);
                    }

                    _userRepository.Update(user);

                    _userRepository.SaveChanges();

                    transaction.Commit();

                    return new Response(true, Messages.ActionSuccess);

                }
                catch
                {
                    transaction.Rollback();

                    return new Response(false, ErrorMessages.BadRequest);
                }
            }
        }

        public async Task<Response<CreateUserResponse>> CreateUserAsync(CreateUserRequest request)
        {
            using (var transaction = _userRepository.DatabaseTransaction())
            {
                try
                {
                    var newEntity = new User
                    {
                        UserName = request.UserName,
                        Password = request.Password,
                        FullName = request.FullName,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        Role = request.Role,
                        Faculty = request.Faculty,
                    };

                    var newUser = _userRepository.Create(newEntity);

                    var responseData = new CreateUserResponse(newUser);

                    _userRepository.SaveChanges();

                    transaction.Commit();

                    return new Response<CreateUserResponse>(true, Messages.ActionSuccess, responseData);
                }
                catch
                {
                    transaction.Rollback();

                    return new Response<CreateUserResponse>(false, ErrorMessages.BadRequest);
                }
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            using (var transaction = _userRepository.DatabaseTransaction())
            {
                try
                {
                    var user = await _userRepository.GetAsync(user => user.Id == id);

                    if (user != null)
                    {
                        _userRepository.Delete(user);

                        _userRepository.SaveChanges();

                        transaction.Commit();
                    }

                    return true;
                }
                catch
                {
                    transaction.Rollback();

                    return false;
                }
            }
        }

        public async Task<IEnumerable<GetUserResponse>> GetAllAsync()
        {
            return (await _userRepository.GetAllAsync())
                .Select(user => new GetUserResponse(user));
        }

        public async Task<Response<GetUserResponse>> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetAsync(user => user.Id == id);

            if (user == null)
            {
                return new Response<GetUserResponse>(false, ErrorMessages.NotFound);
            }

            var reponseDate = new GetUserResponse(user);

            return new Response<GetUserResponse>(true, Messages.ActionSuccess, reponseDate);
        }

        public async Task<IPagedList<GetUserResponse>> GetPagedListAsync(PagingQuery pagingQuery, 
            SortQuery sortQuery, SearchQuery searchQuery, FilterQuery filterQuery)
        {
            var users = (await _userRepository.GetAllAsync()).AsQueryable();

            var vaildSortFields = new[]
            {
                ModelField.UserName,
                ModelField.FullName
            };

            var validSearchFields = new[]
            {
                ModelField.UserName,
                ModelField.FullName
            };

            var validFilterFields = new[]
            {
                ModelField.Role,
                ModelField.Faculty
            };

            var processedList = users.SortByField(vaildSortFields, sortQuery.SortField, sortQuery.SortDirection)
                                        .SearchByField(validSearchFields, searchQuery.SearchValue)
                                        .Select(user => new GetUserResponse(user))
                                        .AsQueryable()
                                        .FilterByField(validFilterFields, filterQuery.FilterField, filterQuery.FilterValue);

            return new PagedList<GetUserResponse>(processedList, pagingQuery.PageIndex, pagingQuery.PageSize);
        }

        public async Task<LoginResponse?> LoginUserAsync(LoginRequest request)
        {
            var user = await _userRepository.GetAsync(user => user.UserName == request.UserName && user.Password == request.Password);
            if (user == null)
            {
                return null;
            }
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.Role,user.Role.ToString()),
                new Claim("Id",user.Id.ToString()),
                new Claim("UserName", user.UserName.ToString()),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConstant.Key));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expired = DateTime.UtcNow.AddMinutes(JwtConstant.ExpiredTime);

            var token = new JwtSecurityToken(JwtConstant.Issuer,
                JwtConstant.Audience, claims,
                expires: expired, signingCredentials: signIn);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new LoginResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                Role = user.Role.ToString(),
                Token = tokenString
            };
        }

        public async Task<Response<UpdateUserResponse>> UpdateUserAsync(UpdateUserRequest request)
        {
            using (var transaction = _userRepository.DatabaseTransaction())
            {
                try
                {
                    var user = await _userRepository.GetAsync(user => user.Id == request.Id);

                    if (user != null)
                    {
                        user.UserName = request.UserName;
                        user.FullName = request.FullName;
                        user.PhoneNumber = request.PhoneNumber;
                        user.Faculty = request.Faculty;

                        var updateUser = _userRepository.Update(user);

                        var responseData = new UpdateUserResponse(updateUser);

                        _userRepository.SaveChanges();

                        transaction.Commit();

                        return new Response<UpdateUserResponse>(true, Messages.ActionSuccess, responseData);
                    }

                    return new Response<UpdateUserResponse>(false, ErrorMessages.NotFound);
                }
                catch
                { 
                    transaction.Rollback();

                    return new Response<UpdateUserResponse>(false, ErrorMessages.BadRequest);
                }
            }
        }
    }
}
