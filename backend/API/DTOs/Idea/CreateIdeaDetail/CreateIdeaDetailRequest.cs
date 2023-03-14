namespace API.DTOs.Idea.CreateIdeaDetail
{
    public class CreateIdeaDetailRequest
    {
        public int IdeaId { get; set; }

        public List<int> CategoryIds { get; set; }
    }
}
