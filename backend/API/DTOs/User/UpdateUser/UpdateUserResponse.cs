using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.User.UpdateUser
{
    public class UpdateUserResponse
    {
        public int Id { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public int PhoneNumber { get; set; }

        public UserRoleEnum Role { get; set; }

        public string Faculty { get; set; }
    }
}
