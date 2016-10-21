using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Admin.Product
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string PrincipleImage { get; set; }
        public int CommentsCount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalRaters { get; set; }
        public string[] Images { get; set; }
        public bool IsFreeShipping { get; set; }
        public long CategoryId { get; set; }
        public bool IsInStock { get; set; }
        public decimal SellCount { get; set; }
        public int ViewCount { get; set; }
        public long Price { get; set; }
        public decimal Ratio { get; set; }
        public double? AvrageRate { get; set; }
        public decimal TotalDiscount { get; set; }


    }
}
