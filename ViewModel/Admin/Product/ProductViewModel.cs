using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainClasses.Enums;

namespace ViewModel.Admin.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public bool CompletedAttributes { get; set; }
        public bool AddedImages { get; set; }
        public string Name { get; set; }
        public string PrincipleImagePath { get; set; }
        public bool IsFreeShipping { get; set; }
        public decimal Stock { get; set; }
        public decimal ReserveCount { get; set; }
        public decimal SellCount { get; set; }
        public int ViewCount { get; set; }
        public bool Deleted { get; set; }
        public decimal NotificationStockMinimum { get; set; }
        public long Price { get; set; }
        public bool Notification { get; set; }
        public decimal Ratio { get; set; }
        public double? Rate { get; set; }
        public bool ApplyCategoryDiscount { get; set; }
        public string CategoryName { get; set; }
        public decimal DiscountPercent { get; set; }
    }
}
