using API.DTOs.Category;

namespace API.DTOs.Idea.CreateIdea
{
    public class CreateIdeaResponse
    {
        public CreateIdeaResponse(Data.Entities.Idea idea)
        {
            IdeaTitle = idea.IdeaTitle;
            IdeaDescription = idea.IdeaDescription;
            DateSubmitted = DateTime.UtcNow;
            File = idea.File;
            UserId = idea.UserId;
            EventId = idea.EventId;
            Categories = idea.Categories
                .Select(category => new CategoryModel
                {
                    Id = category.Id,
                    CategoryName = category.CategoryName,
                    CategoryDescription = category.CategoryDescription,
                }).ToList();
        }

        public string IdeaTitle { get; set; }

        public string IdeaDescription { get; set; }

        public DateTime DateSubmitted { get; set; }

        public string File { get; set; }

        public int UserId { get; set; }

        public int EventId { get; set; }

        public List<CategoryModel> Categories { get; set; }
    }
}
