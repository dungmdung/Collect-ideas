﻿namespace API.DTOs.Event.UpdateEvent
{
    public class UpdateEventResponse
    {
        public int Id { get; set; }

        public string EventName { get; set; }

        public string EventDescription { get; set; }

        public string FirstClosingDate { get; set; }

        public string LastClosingDate { get; set; }
    }
}
