using System.Collections;
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

        public string File { get; set; }

        public int UserId { get; set; }

        public int EventId { get; set; }

        public virtual User Users { get; set; }

        public virtual Event Events { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Thumb> Thumbs { get; set; }

        public ICollection<IdeaDetail> IdeaDetails { get; set; }

        public ICollection<Notification> Notifications { get; set; }
    }
}
