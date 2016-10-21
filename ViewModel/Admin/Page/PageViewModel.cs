using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DomainClasses.Enums;

namespace ViewModel.Admin.Page
{
    public class PageViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string ShowPlace { get; set; }
        public string Title { get; set; }
        public string LinkImage { get; set; }
    }
}
