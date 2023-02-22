using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Idea : BaseEntity
    {
        [Required, MaxLength(225)]
        public string IdeaTitle { get; set; }

        [Required]
        public string IdeaDescription { get; set; }

        [Required]
        public DateTime DateSubmitted { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public DateTime DiscussionTime { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User Users { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Thumb> Thumbs { get; set; }

        public ICollection<IdeaDetail> IdeaDetails { get; set; }
    }
}
