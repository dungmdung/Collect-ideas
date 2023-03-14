namespace API.DTOs.Idea.GetIdea
{
    public class GetIdeaResponse
    {
        public int Id { get; set; }

        public string IdeaTitle { get; set; }

        public string IdeaDescription { get; set; }

        public DateTime DateSubmitted { get; set; }

        public string File { get; set; }

        public int UserId { get; set; }

        public int EventId { get; set; }
    }
}
