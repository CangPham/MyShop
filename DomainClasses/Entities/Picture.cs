﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses.Entities
{
    public class Picture : IEntityBase
    {
        public int Id  { get; set; }
        public virtual string Path { get; set; }
        public virtual Folder Folder { get; set; }
        [ForeignKey("Folder")]
        public virtual int FolderId { get; set; }
    }
}
