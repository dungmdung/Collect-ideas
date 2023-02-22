using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.Entities
{
    public class Thumb : BaseEntity
    {
        public string Type { get; set; }

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
