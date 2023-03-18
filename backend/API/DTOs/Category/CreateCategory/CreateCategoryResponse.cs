namespace API.DTOs.Category.CreateCategory
{
    public class CreateCategoryResponse
    {
        public CreateCategoryResponse(Data.Entities.Category category)
        {
            Id= category.Id;
            CategoryName= category.CategoryName;
            CategoryDescription= category.CategoryDescription;
        }

        public int Id { get; set; }

        public string? CategoryName { get; set; }

        public string? CategoryDescription { get; set; }
    }
}
