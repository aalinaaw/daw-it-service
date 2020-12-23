using System.Collections.Generic;
using DAWProject.Models.Base;
using Newtonsoft.Json;

namespace DAWProject.Models
{
    public class ServiceType : BaseEntity
    {
        public string ServiceName { get; set; }
        
        [JsonIgnore]
        public List<Ticket> Tickets { get; set; }
    }
}