﻿using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class Event : BaseEntity
    {
        [Required]
        public string? EventName { get; set; }

        public string? EventDescription { get; set; }

        public DateTime FirstClosingDate { get; set; }

        public DateTime LastClosingDate { get; set; }

        public ICollection<Idea>? Ideas { get; set; }
    }
}
