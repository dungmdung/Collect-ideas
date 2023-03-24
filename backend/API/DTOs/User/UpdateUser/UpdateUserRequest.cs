using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.User.UpdateUser
{
    public class UpdateUserRequest
    {
        [Required]
        public int Id { get; set; }

        [Required, MaxLength(225)]
        public string? FullName { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        public string? Faculty { get; set; }
    }
}
