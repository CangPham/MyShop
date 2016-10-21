using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAnnotationsExtensions;
using DomainClasses.Enums;

namespace ViewModel.Admin.Product
{
    public class EditProductViewModel
    {
        public int Id { get; set; }
        public int OldCategoryId { get; set; }
        public string Name { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public string MetaKeyWords { get; set; }
        public string PrincipleImagePath { get; set; }
        public bool IsFreeShipping { get; set; }
        public decimal Stock { get; set; }
        public decimal NotificationStockMinimum { get; set; }
        public long Price { get; set; }
        public decimal Ratio { get; set; }
        public bool ApplyCategoryDiscount { get; set; }
        public int CategoryId { get; set; }
        public int DiscountPercent { get; set; }
        public ProductType Type { get; set; }
        public bool Deleted { get; set; }
    }
}
