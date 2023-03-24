using API.DTOs.User.GetUser;
using Data.Entities;

namespace API.DTOs.Event.GetEvent
{
    public class GetEventResponse
    {
        public GetEventResponse(Data.Entities.Event request)
        {
            Id = request.Id;
            EventName = request.EventName;
            EventDescription = request.EventDescription;
            FirstClosingDate = request.FirstClosingDate.ToString("dd/MM/yyyy");
            LastClosingDate = request.LastClosingDate.ToString("dd/MM/yyyy");
            UserName = request.User.UserName;
            Faculty = request.User.Faculty;
        }

        public int Id { get; set; }

        public string EventName { get; set; }

        public string EventDescription { get; set; }

        public string FirstClosingDate { get; set; }

        public string LastClosingDate { get; set; }

        public string UserName { get; set; }

        public string Faculty { get; set; }
    }
}
