using Common.Enums;

namespace API.DTOs.User.GetUser
{
    public class GetUserResponse
    {
        public GetUserResponse(Data.Entities.User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            FullName = user.FullName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Role = user.Role;
            Faculty = user.Faculty;
        }

        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int PhoneNumber { get; set; } 

        public UserRoleEnum Role { get; set; }

        public string Faculty { get; set; }
    }
}
