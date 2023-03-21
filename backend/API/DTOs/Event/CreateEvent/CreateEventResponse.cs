using API.DTOs.User.GetUser;

namespace API.DTOs.Event.CreateEvent
{
    public class CreateEventResponse
    {
        public CreateEventResponse(Data.Entities.Event request)
        {
            EventName = request.EventName;
            EventDescription = request.EventDescription;
            FirstClosingDate = request.FirstClosingDate.ToString("dd/MM/yyyy");
            LastClosingDate = request.LastClosingDate.ToString("dd/MM/yyyy");
            User = new GetUserResponse(request.User);
        }

        public string EventName { get; set; }

        public string EventDescription { get; set; }

        public string FirstClosingDate { get; set; }

        public string LastClosingDate { get; set; }

        public GetUserResponse User { get; set; }
    }
}
