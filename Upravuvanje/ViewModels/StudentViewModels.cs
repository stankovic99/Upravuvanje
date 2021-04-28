using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upravuvanje.Models;

namespace Upravuvanje.ViewModels
{
    public class StudentViewModels
    {
        public IList<Student> Students { get; set; }
        public SelectList Indeksi { get; set; }
        public string StudentIndeks { get; set; }
        public string SearchString { get; set; }
    }
}
