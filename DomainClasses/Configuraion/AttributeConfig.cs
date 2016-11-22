
using DomainClasses.Entities;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Configuraion
{
    public class AttributeConfig : EntityBaseConfiguration<Attribute>
    {
        public AttributeConfig()
        {            
            HasMany(a=>a.Values).WithRequired(a=>a.Attribute).WillCascadeOnDelete(true);
            Property(a => a.Name).HasMaxLength(50).IsRequired();
            Property(a => a.RowVersion).IsRowVersion();
        }
    }
}
