using Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.Entities
{
    public class Thumb : BaseEntity
    {
        public ThumbEnum ThumbType { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int IdeaId { get; set; }

        public User? Users { get; set; }

        public Idea? Ideas { get; set; }
    }
}
