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
            UserId = idea.UserId;
            EventId = idea.EventId;
        }

        public int Id { get; set; }

        public string IdeaTitle { get; set; }

        public string IdeaDescription { get; set; }

        public DateTime DateSubmitted { get; set; }

        public string File { get; set; }

        public int UserId { get; set; }

        public int EventId { get; set; }
    }
}
