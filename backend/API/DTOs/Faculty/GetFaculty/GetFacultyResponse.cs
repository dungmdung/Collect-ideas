namespace API.DTOs.Faculty.GetFaculty
{
    public class GetFacultyResponse
    {
        public int Id { get; set; }

        public string FacultyName { get; set; }

        public string FacultyDescription { get; set; }

        public string FirstClosingDate { get; set; }

        public string LastClosingDate { get; set; }
    }
}
