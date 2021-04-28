using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upravuvanje.Models;

namespace Upravuvanje.ViewModels
{
    public class TeacherViewModels
    {
        public IList<Teacher> Profesori { get; set; }
        public SelectList StepenObrazovani { get; set; }
        public SelectList AkademskiRank { get; set; }
        public string ProfesorStepen { get; set; }
        public string ProfesorRank { get; set; }
        public string SearchString { get; set; }

    }
}
