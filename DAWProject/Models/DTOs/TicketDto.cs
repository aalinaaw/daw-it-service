using System;

namespace DAWProject.Models.DTOs
{
    public class TicketDto
    {
        public string Description { get; set; }

        public ServiceType TicketType { get; set; }

        public Guid UserId { get; set; }
    }
}