using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using DAWProject.Models.Base;

namespace DAWProject.Models
{
    public class Ticket: BaseEntity
    {
        public string Description { get; set; }

        [JsonIgnore]
        public Guid TicketTypeId { get; set; }
        
        public ServiceType TicketType { get; set; }
        
        [JsonIgnore]
        public List<EmployeeTicket> Employees { get; set; }
        
        public Guid UserId { get; set; }
        
        [JsonIgnore]
        public User User { get; set; }
    }
}