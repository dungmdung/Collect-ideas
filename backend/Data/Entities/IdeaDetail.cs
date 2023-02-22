using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class IdeaDetail : BaseEntity
    {
        [Required]
        public int IdeaId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Idea Ideas { get; set; }

        public virtual Category Categories { get; set; }
    }
}
