using Common.Enums;

namespace API.DTOs.User.CreateUser
{
    public class CreateUserResponse
    {
        public CreateUserResponse(Data.Entities.User user)
        {
            UserName = user.UserName;
            FullName = user.FullName;
            Email = user.Email;
            PhoneNumber= user.PhoneNumber;
            Role = user.Role;
            Faculty = user.Faculty;
        }

        public string UserName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public UserRoleEnum Role { get; set; }
        
        public string Faculty { get; set; }
    }
}
