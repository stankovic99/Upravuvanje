using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Upravuvanje.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Display(Name = "Име")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Презиме")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Диплома")]
        public string? Degree { get; set; }

        [Display(Name = "Академски ранк")]
        public string? AcademicRank { get; set; }

        [Display(Name = "Број")]
        public string? OfficeNumber { get; set; }

        [Display(Name = "Дата на вработување")]
        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }
        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }

        public ICollection<Course> Course1 { get; set; }
        public ICollection<Course> Course2 { get; set; }
    }
}
