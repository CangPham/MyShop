﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ViewModel.Admin.Folder
{
    public class EditFolderViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
