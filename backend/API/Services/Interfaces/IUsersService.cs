using API.DTOs.GetUser;
using API.DTOs.UpdateUser;
using API.DTOs.User.Authentication;
using API.DTOs.User.CreateUser;
using API.Queries;
using Common.DataType;

namespace API.Services.Interfaces
{
    public interface IUsersService
    {
        Task<LoginResponse?> LoginUserAsync(LoginRequest request);

        Task<GetUserResponse?> GetByIdAsync(int id);

        Task<IEnumerable<GetUserResponse>> GetAllAsync();

        Task<IPagedList<GetUserResponse>> GetPagedListAsync(PagingQuery pagingQuery, SortQuery sortQuery, SearchQuery searchQuery, FilterQuery filterQuery);

        Task<CreateUserResponse?> CreateUserAsync(CreateUserRequest  request);

        Task<UpdateUserResponse?> UpdateUserAsync(UpdateUserRequest requestModel);

        Task<bool> DeleteUserAsync(int id);
    }
}
