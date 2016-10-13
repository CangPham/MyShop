using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DomainClasses.Enums;

namespace ViewModel.Admin
{
    public class AddAttributeViewModel
    {
        [DisplayName("Name")]
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(40, ErrorMessage = "Maxlength is 40")]
        [Remote("AddCheckExistAttributeForCategory", "Category", "Admin", ErrorMessage = "", HttpMethod = "POST", AdditionalFields = "CategoryId")]
        public string Name { get; set; }
        [DisplayName("Category Id")]
        [Required(ErrorMessage = "Category Id is required")]
        public long CategoryId { get; set; }
        [DisplayName("Cascade Add For Children")]
        public bool CascadeAddForChildren { get; set; }
    }
}
