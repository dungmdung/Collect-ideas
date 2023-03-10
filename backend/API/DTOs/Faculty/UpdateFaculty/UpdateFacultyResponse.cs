namespace API.DTOs.Faculty.UpdateFaculty
{
    public class UpdateFacultyResponse
    {
        public int Id { get; set; }

        public string FacultyName { get; set; }

        public string FacultyDescription { get; set; }

        public string FirstClosingDate { get; set; }

        public string LastClosingDate { get; set; }
    }
}
