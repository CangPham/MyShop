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
        public string Name { get; set; }
        public int CategoryId { get; set; }        
        public bool CascadeAddForChildren { get; set; }
    }
}
