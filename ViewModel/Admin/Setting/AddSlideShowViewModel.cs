using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAnnotationsExtensions;

namespace ViewModel.Admin.Setting
{
    public class AddSlideShowViewModel
    {       
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string ImageAltText { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public virtual string Position { get; set; }
        public virtual string HideTransition { get; set; }
        public virtual int DataVertical { get; set; }
        public virtual int DataHorizontal { get; set; }

    }
}
