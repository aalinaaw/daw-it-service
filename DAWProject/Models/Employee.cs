using System.Collections.Generic;
using DAWProject.Models.Base;
using Newtonsoft.Json;

namespace DAWProject.Models
{
    public class Employee: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        
        [JsonIgnore]
        public List<EmployeeTicket> Tickets { get; set; }
    }
}