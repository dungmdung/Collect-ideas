using System.ComponentModel.DataAnnotations;

namespace API.DTOs.Faculty.UpdateFaculty
{
    public class UpdateFacultyRequest
    {
        [Required]
        public int Id { get; set; }

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
