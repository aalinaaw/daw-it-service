using System;
using DAWProject.Models.Base;

namespace DAWProject.Models
{
    public class TicketAuditEntry: BaseEntity
    {
        public DateTime CreationDate { get; set; }

        public Guid TicketId { get; set; }
        
        public Ticket Ticket { get; set; }
    }
}