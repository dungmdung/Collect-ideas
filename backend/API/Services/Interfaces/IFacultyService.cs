using API.DTOs.Faculty.CreateFaculty;
using API.DTOs.Faculty.GetFaculty;
using API.DTOs.Faculty.UpdateFaculty;
using API.DTOs.User.CreateUser;
using API.DTOs.User.GetUser;
using API.DTOs.User.UpdateUser;

namespace API.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<GetFacultyResponse?> GetByIdAsync(int id);

        Task<IEnumerable<GetFacultyResponse>> GetAllAsync();

        Task<CreateFacultyResponse?> CreateFacultyAsync(CreateFacultyRequest request);

        Task<UpdateFacultyResponse?> UpdateFacultyAsync(UpdateFacultyRequest request);

        Task<bool> DeleteUserAsync(int id);
    }
}
