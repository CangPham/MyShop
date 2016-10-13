﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Entities
{
    public class SiteOption : IEntityBase
    {
        public int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }
    }
}
