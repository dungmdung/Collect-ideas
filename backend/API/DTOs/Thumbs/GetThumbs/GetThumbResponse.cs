
using Common.Enums;

namespace API.DTOs.Thumbs.GetThumbs
{
    public class GetThumbResponse
    {
        public GetThumbResponse(Data.Entities.Thumb request)
        {
            Id = request.Id;
            ThumbType = ThumbType;
            UserId = request.UserId;
            IdeaId = request.IdeaId;
        }

        public int Id { get; set; }
        
        public ThumbEnum ThumbType { get; set; }
        public int UserId { get; set; }
        public int IdeaId { get;     set; }
    }
}
