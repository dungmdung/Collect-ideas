using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Faculty.CreateFaculty
{
    public class CreateFacultyRequest
    {
        [Required]
        public string FacultyName { get; set; }

        [Required]
        public string FacultyDescription { get; set; }

        [Required]
        public DateTime FirstClosingDate { get; set; }

        [Required]
        public DateTime LastClosingDate { get; set; }
    }
}
