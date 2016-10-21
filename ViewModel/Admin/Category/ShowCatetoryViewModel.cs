using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Entities;
using Microsoft.SqlServer.Server;
using Attribute = System.Attribute;

namespace ViewModel.Admin
{
    public class ShowCatetoryViewModel
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int DiscountPercent { get; set; }
    }
}
