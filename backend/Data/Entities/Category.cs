namespace Data.Entities
{
    public class Category : BaseEntity
    {
        public string? CategoryName { get; set; }

        public string? CategoryDescription { get; set; }

        public ICollection<Idea>? Ideas { get; set; }
    }
}
