using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.Entities
{
    public class Comment : BaseEntity
    {
        public string? CommentContent { get; set; }

        public DateTime DateSubmitted { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int IdeaId { get; set; }

        public User? User { get; set; }

        public Idea? Idea { get; set; }
    }
}
