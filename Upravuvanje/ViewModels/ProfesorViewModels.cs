﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upravuvanje.Models;

namespace Upravuvanje.ViewModels
{
    public class ProfesorViewModels
    {
        public IList<Course> Profesori { get; set; }
        public string SearchString { get; set; }
    }
}
