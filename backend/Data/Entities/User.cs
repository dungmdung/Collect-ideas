using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class User : BaseEntity
    {
        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required, MaxLength(50)]
        public string Password { get; set; }

        [Required, MaxLength(225)]
        public string FullName { get; set; }

        [Required, MaxLength(225)]
        public string Email { get; set; }

        [Required, MaxLength(10)]
        public string PhoneNumber { get; set; }

        [Required]
        public UserRoleEnum Role { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Idea> Ideas { get; set; }

        public ICollection<Thumb> Thumbs { get; set; }
    }
}
