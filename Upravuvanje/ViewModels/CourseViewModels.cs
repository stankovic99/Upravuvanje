using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upravuvanje.Models;

namespace Upravuvanje.ViewModels
{
    public class CourseViewModels
    {
        public IList<Course> Predmeti { get; set; }
        public SelectList Semestar { get; set; }
        public SelectList Programa { get; set; }
        public string PredmetPrograma { get; set; }
        public string PredmetSemestar { get; set; }
        public string SearchString { get; set; }
    }
}
