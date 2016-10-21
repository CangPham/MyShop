using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Admin
{
    public class DetailsUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public int CommentsCount { get; set; }
        public int OrdersCount { get; set; }
        public string IP { get; set; }
        public string RegisterType { get; set; }
    }
}
