using API.DTOs.User.Authentication;
using API.DTOs.User.ChangePassword;
using API.DTOs.User.CreateUser;
using API.DTOs.User.GetUser;
using API.DTOs.User.UpdateUser;
using API.Queries;
using Application.Common;
using Common.DataType;

namespace API.Services.Interfaces
{
    public interface IUsersService
    {
        Task<LoginResponse?> LoginUserAsync(LoginRequest request);

        Task<Response<GetUserResponse>> GetByIdAsync(int id);

        Task<IEnumerable<GetUserResponse>> GetAllAsync();

        Task<IPagedList<GetUserResponse>> GetPagedListAsync(PagingQuery pagingQuery, SearchQuery searchQuery, FilterQuery filterQuery);

        Task<Response<CreateUserResponse>> CreateUserAsync(CreateUserRequest request);

        Task<Response<UpdateUserResponse>> UpdateUserAsync(UpdateUserRequest request);

        Task<bool> DeleteUserAsync(int id);

        Task<Response> ChangePasswordAsync(ChangePasswordRequest request);
    }
}
