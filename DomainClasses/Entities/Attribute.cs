using System.Collections.Generic;
using DomainClasses.Enums;

namespace DomainClasses.Entities
{
    public class Attribute : IEntityBase
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Category Category{ get; set; }
        public virtual AttributeType Type { get; set; }
        public virtual int CategoryId{ get; set; }
        public virtual byte[] RowVersion { get; set; }
        public virtual ICollection<Value> Values { get; set; }

    }
}
