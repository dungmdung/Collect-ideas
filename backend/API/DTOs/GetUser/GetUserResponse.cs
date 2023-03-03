using Common.Enums;

namespace API.DTOs.GetUser
{
    public class GetUserResponse
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public UserRoleEnum Role { get; set; }
    }
}
