using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using DataAnnotationsExtensions;

namespace ViewModel.Admin
{
    public class AddCategoryViewModel
    {
        public int Level { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int DisplayOrder { get; set; }       
        public string Description { get; set; }
        public string KeyWords { get; set; }
        public int DiscountPercent { get; set; }
    }
}
