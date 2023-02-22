using Data.Entities;

namespace API.Services.Interfaces
{
    public interface IUsersService
    {
        Task<User?> LoginUser(string username, string password);
    }
}
