using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace ViewModel.Admin
{
    public class AddUserViewModel
    {        
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }       
        public string Password { get; set; }        
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
    
    }
}
