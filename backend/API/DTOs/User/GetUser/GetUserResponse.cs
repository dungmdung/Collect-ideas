using Common.Enums;

namespace API.DTOs.User.GetUser
{
    public class GetUserResponse
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int PhoneNumber { get; set; } 

        public UserRoleEnum Role { get; set; }

        public string Faculty { get; set; }
    }
}
