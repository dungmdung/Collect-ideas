using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Faculty.CreateFaculty
{
    public class CreateFacultyResponse
    {
        public string FacultyName { get; set; }

        public string FacultyDescription { get; set; }

        public string FirstClosingDate { get; set; }

        public string LastClosingDate { get; set; }
    }
}
