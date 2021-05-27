using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Upravuvanje.Models;

namespace Upravuvanje.ViewModels
{
    public class EnrollmentViewModels
    {
        [Display(Name = "Семестар")]
        public string? Semestar { get; set; }

        [Display(Name = "Година")]
        public int? Year { get; set; }

        [Display(Name = "Оцена")]
        public int? Grade { get; set; }

        

        [Display(Name = "Проект")]
        public string? ProjectUrl { get; set; }

        [Display(Name = "Бодови")]
        public int? ExamPoint { get; set; }

        [Display(Name = "Бодови Семинарска")]
        public int? SeminalPoints { get; set; }

        [Display(Name = "Бодови Проект")]
        public int? ProjectPoints { get; set; }

        [Display(Name = "Додатни поени")]
        public int? AdditionalPoints { get; set; }

        [Display(Name = "Завршен датум")]
        [DataType(DataType.Date)]
        public DateTime? FinishDate { get; set; }
    }
}
