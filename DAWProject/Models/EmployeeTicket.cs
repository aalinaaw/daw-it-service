using System;
using Newtonsoft.Json;

namespace DAWProject.Models
{
    public class EmployeeTicket
    {
        public Guid EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Employee { get; set; }
        public Guid TicketId { get; set; }
        [JsonIgnore]
        public Ticket Ticket { get; set; }
    }
}