using API.DTOs.GetUser;
using API.DTOs.UpdateUser;
using API.DTOs.User.Authentication;
using API.DTOs.User.CreateUser;

namespace API.Services.Interfaces
{
    public interface IUsersService
    {
        Task<LoginResponse?> LoginUserAsync(LoginRequest request);

        Task<GetUserResponse?> GetByIdAsync(int id);

        Task<IEnumerable<GetUserResponse>> GetAllAsync();

        Task<CreateUserResponse?> CreateUserAsync(CreateUserRequest  request);

        Task<UpdateUserResponse?> UpdateUserAsync(UpdateUserRequest requestModel);

        Task<bool> DeleteUserAsync(int id);
    }
}
