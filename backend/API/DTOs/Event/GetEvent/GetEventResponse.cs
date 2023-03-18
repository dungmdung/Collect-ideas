namespace API.DTOs.Event.GetEvent
{
    public class GetEventResponse
    {
        public GetEventResponse(Data.Entities.Event events)
        {
            Id = events.Id;
            EventName = events.EventName;
            EventDescription = events.EventDescription;
            FirstClosingDate = events.FirstClosingDate.ToString("dd/MM/yyyy");
            LastClosingDate = events.LastClosingDate.ToString("dd/MM/yyyy");
        }

        public int Id { get; set; }

        public string EventName { get; set; }

        public string EventDescription { get; set; }

        public string FirstClosingDate { get; set; }

        public string LastClosingDate { get; set; }
    }
}
