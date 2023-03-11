namespace API.DTOs.Category.GetCategory
{
    public class GetCategoryResponse
    {
        public int Id { get; set; }

        public string? CategoryName { get; set; }

        public string? CategoryDescription { get; set; }
    }
}
