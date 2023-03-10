using API.DTOs.Faculty.CreateFaculty;
using API.DTOs.Faculty.GetFaculty;
using API.DTOs.Faculty.UpdateFaculty;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using Data.Entities;

namespace API.Services.Implements
{
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyService(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public async Task<CreateFacultyResponse?> CreateFacultyAsync(CreateFacultyRequest request)
        {
            using (var transaction = _facultyRepository.DatabaseTransaction())
            {
                try
                {
                    var newEntity = new Faculty
                    {
                        FacultyName = request.FacultyName,
                        FacultyDescription = request.FacultyDescription,
                        FirstClosingDate = request.FirstClosingDate,
                        LastClosingDate = request.LastClosingDate
                    };

                    var newFaculty = _facultyRepository.Create(newEntity);

                    _facultyRepository.SaveChanges();

                    transaction.Commit();

                    return new CreateFacultyResponse()
                    {
                        FacultyName = newFaculty.FacultyName,
                        FacultyDescription = newFaculty.FacultyDescription,
                        FirstClosingDate = newFaculty.FirstClosingDate.ToString("dd/MM/yyyy"),
                        LastClosingDate = newFaculty.LastClosingDate.ToString("dd/MM/yyyy")
                    };
                }
                catch
                {
                    transaction.Rollback();

                    return null;
                }
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            using (var transaction = _facultyRepository.DatabaseTransaction())
            {
                try
                {
                    var faculty = await _facultyRepository.GetAsync(faculty => faculty.Id == id);

                    if (faculty != null)
                    {
                        _facultyRepository.Delete(faculty);

                        _facultyRepository.SaveChanges();

                        transaction.Commit();
                    }
                    return true;
                }
                catch
                {
                    transaction.Rollback();

                    return false;
                }
            }
        }

        public async Task<IEnumerable<GetFacultyResponse>> GetAllAsync()
        {
            return (await _facultyRepository.GetAllAsync())
                .Select(faculty => new GetFacultyResponse
                {
                    Id = faculty.Id,
                    FacultyName = faculty.FacultyName,
                    FacultyDescription = faculty.FacultyDescription,
                    FirstClosingDate = faculty.FirstClosingDate.ToString("dd/MM/yyyy"),
                    LastClosingDate= faculty.LastClosingDate.ToString("dd/MM/yyyy"),
                });
        }

        public async Task<GetFacultyResponse?> GetByIdAsync(int id)
        {
            var faculty = await _facultyRepository.GetAsync(faculty => faculty.Id == id);

            if (faculty == null) { return null; }

            return new GetFacultyResponse
            {
                Id = faculty.Id,
                FacultyName = faculty.FacultyName,
                FacultyDescription = faculty.FacultyDescription,
                FirstClosingDate = faculty.FirstClosingDate.ToString("dd/MM/yyyy"),
                LastClosingDate = faculty.LastClosingDate.ToString("dd/MM/yyyy")
            };
        }

        public async Task<UpdateFacultyResponse?> UpdateFacultyAsync(UpdateFacultyRequest request)
        {
            using ( var transaction = _facultyRepository.DatabaseTransaction())
            {
                try
                {
                    var faculty = await _facultyRepository.GetAsync(faculty => faculty.Id == request.Id);

                    if (faculty == null)
                    {
                        return null;
                    }

                    faculty.Id = request.Id;
                    faculty.FacultyName = request.FacultyName;
                    faculty.FacultyDescription = request.FacultyDescription;
                    faculty.FirstClosingDate = request.FirstClosingDate;
                    faculty.LastClosingDate = request.LastClosingDate;

                    _facultyRepository.Update(faculty);

                    _facultyRepository.SaveChanges();

                    transaction.Commit();

                    return new UpdateFacultyResponse
                    {
                        Id = request.Id,
                        FacultyName = request.FacultyName,
                        FacultyDescription = request.FacultyDescription,
                        FirstClosingDate = request.FirstClosingDate.ToString("dd/MM/yyyy"),
                        LastClosingDate = request.LastClosingDate.ToString("dd/MM/yyyy")
                    };
                }
                catch
                {
                    transaction.Rollback();

                    return null;
                }
            }
        }
    }
}
