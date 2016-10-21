using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataAnnotationsExtensions;
using DomainClasses.Enums;

namespace ViewModel.Admin.Page
{
    public class AddPageViewModel
    {       
        public virtual string Content { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string KeyWords { get; set; }
        public virtual int DisplayOrder { get; set; }
        public virtual PageShowPlace PageShowPlace { get; set; }
        public virtual string ImagePath { get; set; }
    }
}
