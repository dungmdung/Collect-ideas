using API.Services.Interfaces;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Implements
{
    public class UsersService : IUsersService
    {
        private readonly DatabaseContext _databaseContext;

        public UsersService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<User?> LoginUser(string username, string password)
        {
            return await _databaseContext.Users.SingleOrDefaultAsync(x => x.UserName == username && x.Password == password);
        }
    }
}
