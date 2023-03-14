namespace API.DTOs.Category.CreateCategory
{
    public class CreateCategoryResponse
    {
        public int Id { get; set; }

        public string? CategoryName { get; set; }

        public string? CategoryDescription { get; set; }
    }
}
