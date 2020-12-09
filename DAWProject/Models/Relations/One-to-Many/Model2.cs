using DAWProject.Models.Base;
using System;

namespace DAWProject.Models.Relations.One_to_Many
{
    public class Model2 : BaseEntity
    {
        public string Name { get; set; }

        public Model1 Model1 { get; set; }
        public Guid Model1Id { get; set; }
    }
}
