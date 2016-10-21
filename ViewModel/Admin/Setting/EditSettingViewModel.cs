using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Admin
{
    public class EditSettingViewModel
    {       
        public string StorName { get; set; }
        public string StoreKeyWords { get; set; }
        public string StoreDescription { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Address { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public bool CommentModeratorStatus { get; set; }

    }
}
