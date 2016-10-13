using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Entities
{
    public class Value : IEntityBase
    {
        public int Id { get; set; }
        public virtual string Content { get; set; }
        public virtual Attribute Attribute { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Product")]
        public virtual int ProductId { get; set; }
        [ForeignKey("Attribute")]
        public virtual int AttributeId { get; set; }
    }
}
