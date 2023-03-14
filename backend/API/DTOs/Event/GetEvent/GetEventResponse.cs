namespace API.DTOs.Event.GetEvent
{
    public class GetEventResponse
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public string EventDescription { get; set; }

        public string FirstClosingDate { get; set; }

        public string LastClosingDate { get; set; }
    }
}
