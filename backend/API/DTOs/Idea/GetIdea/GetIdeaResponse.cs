using API.DTOs.Category;
using API.DTOs.Event.GetEvent;
using API.DTOs.User.GetUser;

namespace API.DTOs.Idea.GetIdea
{
    public class GetIdeaResponse
    {
        public GetIdeaResponse(Data.Entities.Idea idea)
        {
            Id = idea.Id;
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

        public int Id { get; set; }

        public string IdeaTitle { get; set; }

        public string IdeaDescription { get; set; }

        public DateTime DateSubmitted { get; set; }

        public string File { get; set; }

        public GetUserResponse User { get; set; }

        public GetEventResponse Event { get; set; }

        public List<CategoryModel> Categories { get; set; }
    }
}
