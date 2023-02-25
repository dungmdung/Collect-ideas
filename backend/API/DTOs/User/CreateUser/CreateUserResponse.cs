using Common.Enums;

namespace API.DTOs.User.CreateUser
{
    public class CreateUserResponse
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public UserRoleEnum Role { get; set; }
    }
}
