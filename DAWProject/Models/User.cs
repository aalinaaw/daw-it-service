using System;
using System.Collections.Generic;
using DAWProject.Models.Base;
using Newtonsoft.Json;

namespace DAWProject.Models
{
    public class User: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        
        public Guid UserTypeId { get; set; }
        public UserType UserType { get; set; }
        
        [JsonIgnore]
        public List<Ticket> Tickets { get; set; }
    }
}
