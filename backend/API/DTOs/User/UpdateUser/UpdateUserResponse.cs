using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.User.UpdateUser
{
    public class UpdateUserResponse
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string? UserName { get; set; }

        [Required, MaxLength(50)]
        public string? Password { get; set; }

        [Required, MaxLength(225)]
        public string? FullName { get; set; }

        [Required, MaxLength(225)]
        public string? Email { get; set; }

        [Required, MaxLength(10)]
        public int PhoneNumber { get; set; }

        [Required]
        public UserRoleEnum Role { get; set; }
    }
}
