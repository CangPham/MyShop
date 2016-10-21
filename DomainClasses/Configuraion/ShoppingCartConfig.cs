﻿using DomainClasses.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Configuraion
{
   public class ShoppingCartConfig: EntityBaseConfiguration<ShoppingCart>
   {
       public ShoppingCartConfig()
       {
           Property(a => a.CartNumber).IsRequired().HasMaxLength(50);
       }
    }
}
