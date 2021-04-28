using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Upravuvanje.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Презиме")]
        [Required]
        public string LastName { get; set; }

        [Display(Name ="Индекс")]
        [Required]
        public string Indeks { get; set; }

        [Display(Name = "Датум на упис")]
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        [Display(Name = "Кредити")]
        public int? AcquireCredits { get; set; }

        [Display(Name = "Семестар")]
        public int? CurrentSemestar { get; set; }

        [Display(Name = "Степен")]
        public string? EducationLevel { get; set; }
        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }

        [Display(Name = "Курсеви")]
        public ICollection<Enrollment> Courses { get; set; }
    }
}
