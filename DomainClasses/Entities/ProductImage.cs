using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Entities
{
    public class ProductImage : IEntityBase
    {
        public int Id { get; set; }

        public virtual Product Product { get; set; }
        public virtual string Path { get; set; }
        [ForeignKey("Product")]
        public virtual int ProductId  { get; set; }
    }
}
