using System;
using System.Collections.Generic;

namespace DAWProject.Models.DTOs
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public ServiceType TicketType { get; set; }

        public Guid UserId { get; set; }
        
        public string Username { get; set; }
        
        public List<Employee> Employees { get; set; }

        public String Status { get; set; }
        
        public TicketAuditEntry AuditEntry { get; set; }

    }
}