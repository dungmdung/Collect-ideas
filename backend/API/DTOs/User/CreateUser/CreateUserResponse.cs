using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.User.CreateUser
{
    public class CreateUserResponse
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public UserRoleEnum Role { get; set; }
        
        public string Faculty { get; set; }
    }
}
