using System.Collections.Generic;

namespace DomainClasses.Entities
{
    public class Folder : IEntityBase
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
