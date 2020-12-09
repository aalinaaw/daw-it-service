using DAWProject.Models.Base;
using System.Collections.Generic;

namespace DAWProject.Models.Relations.One_to_Many
{
    public class Model1 : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Model2> Models2 { get; set; }
    }
}
