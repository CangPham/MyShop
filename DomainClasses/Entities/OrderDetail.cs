﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Entities
{
    public class OrderDetail : IEntityBase
    {
        public int Id { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        public virtual  int OrderId { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual byte[] RowVersion { get; set; }
        public virtual decimal UnitPrice { get; set; }
    }
}
