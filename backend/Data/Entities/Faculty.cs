using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Faculty : BaseEntity
    {
        [Required]
        public string FacultyName { get; set; }

        public string FacultyDescription { get; set; }

        public DateTime? FirstClosingDate { get; set; }

        public DateTime? LastClosingDate { get; set; }

        public ICollection<Idea> Ideas { get; set; }
    }
}
