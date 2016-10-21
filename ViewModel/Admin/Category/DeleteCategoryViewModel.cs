using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Admin
{
   public class DeleteCategoryViewModel
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public int ReplaceCategoryIdForProducts { get; set; }
    }
}
