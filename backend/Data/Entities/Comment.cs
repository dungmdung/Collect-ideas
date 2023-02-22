using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.Entities
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }

        public DateTime DateSubmitted { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int IdeaId { get; set; }

        [JsonIgnore]
        public virtual User Users { get; set; }

        [JsonIgnore]
        public virtual Idea Ideas { get; set; }
    }
}
