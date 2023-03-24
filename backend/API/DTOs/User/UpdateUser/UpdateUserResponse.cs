using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs.User.UpdateUser
{
    public class UpdateUserResponse
    {
        public UpdateUserResponse(Data.Entities.User user)
        {
            Id = user.Id;
            FullName = user.FullName;
            PhoneNumber = user.PhoneNumber;
            Faculty = user.Faculty;
        }

        public int Id { get; set; }

        public string? FullName { get; set; }

        public int PhoneNumber { get; set; }

        public string Faculty { get; set; }
    }
}
