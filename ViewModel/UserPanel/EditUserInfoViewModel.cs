using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace ViewModel.UserPanel
{
    public class EditUserInfoViewModel
    {
       

        [DisplayName("FirstName")]
        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(50, ErrorMessage = "Maxlength is 50")]
        public string FirstName { get; set; }

        [DisplayName("LastName")]
        [MaxLength(50, ErrorMessage = "")]
        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [DisplayName("PostalCode")]
        [Required(ErrorMessage = "PostalCode is required")]
        [MaxLength(12, ErrorMessage = "Maxlength is 12")]
        public string PostalCode { get; set; }
        [DisplayName("Tel")]
        [MaxLength(8, ErrorMessage = "Tel is 8")]
        public string Tel { get; set; }

        [DisplayName("Address")]
        [Required(ErrorMessage = "Address is required")]
        [DataType(DataType.MultilineText)]
        [MaxLength(2000, ErrorMessage = "2000 character")]
        public string Address { get; set; }
    }
}
