using API.DTOs.Category;
using API.DTOs.Event.GetEvent;
using API.DTOs.User.GetUser;

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
            User = new GetUserResponse(idea.User);
            Event = new GetEventResponse(idea.Event);
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

        public GetUserResponse User { get; set; }

        public GetEventResponse Event { get; set; }

        public List<CategoryModel> Categories { get; set; }
    }
}
