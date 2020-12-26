using System.Collections.Generic;
using DAWProject.Models.Base;
using Newtonsoft.Json;

namespace DAWProject.Models
{
    public class UserType : BaseEntity
    {
        public string Type { get; set; }
        
        [JsonIgnore]
        public List<User> Users { get; set; }
    }
}