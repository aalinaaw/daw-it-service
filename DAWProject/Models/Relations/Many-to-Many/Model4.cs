using DAWProject.Models.Base;
using System.Collections.Generic;

namespace DAWProject.Models.Relations.Many_to_Many
{
    public class Model4: BaseEntity
    {
        public string Title { get; set; }
        public ICollection<ModelsRelation> ModelRelations { get; set; }
    }
}
