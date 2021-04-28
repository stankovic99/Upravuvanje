using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Upravuvanje.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Наслов")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Кредити")]
        [Required]
        public int Credits { get; set; }

        [Display(Name = "Семестар")]
        [Required]
        public int Semestar { get; set; }

        [Display(Name = "Програма")]
        public string? Programme { get; set; }

        [Display(Name = "Степен")]
        public string? EducationLevel { get; set; }

        public ICollection<Enrollment> Students { get; set; }

        [Display(Name = "Наставник 1")]
        public int? FirstTeacherId { get; set; }
        public Teacher Teacher1 { get; set; }

        [Display(Name = "Наставник 2")]
        public int? SecondTeacherId { get; set; }
        public Teacher Teacher2 { get; set; }
    }
}
