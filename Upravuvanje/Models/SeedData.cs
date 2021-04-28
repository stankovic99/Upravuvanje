using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upravuvanje.Data;
using Upravuvanje.Models;

namespace MVCMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UpravuvanjeContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<UpravuvanjeContext>>()))
            {
                // Look for any movies.
                if (context.Course.Any() || context.Teacher.Any() || context.Student.Any())
                {
                    return; // DB has been seeded
                }

                context.Teacher.AddRange(
                    new Teacher { FirstName = "Даниел", LastName = "Денковски", Degree = "Професор", AcademicRank = "Доцент", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3") },
                    new Teacher { FirstName = "Перо", LastName = "Латковски", Degree = "Професор", AcademicRank = "Доктор", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3") },
                    new Teacher { FirstName = "Марија", LastName = "Календар", Degree = "Професор", AcademicRank = "Доктор", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3") },
                    new Teacher { FirstName = "Ана", LastName = "Чолаковска", Degree = "Магистар", AcademicRank = "Магистар", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3") },
                    new Teacher { FirstName = "Горан", LastName = "Јакимовски", Degree = "Професор", AcademicRank = "Доцент", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3") },
                    new Teacher { FirstName = "Марко", LastName = "Порјазовски", Degree = "Професор", AcademicRank = "Доцент", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3") },
                    new Teacher { FirstName = "Владимир", LastName = "Атанасовски", Degree = "Професор", AcademicRank = "Доцент", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3") },
                    new Teacher { FirstName = "Валентин", LastName = "Раковиќ", Degree = "Професор", AcademicRank = "Доцент", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3") }
                    );
                context.SaveChanges();
                
                context.Course.AddRange(
                        new Course
                        {
                            Title = "Развој на серверски веб апликации",
                            Credits = 6,
                            Semestar = 6,
                            Programme = "КТИ",
                            EducationLevel = "Дипломски",
                            FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Даниел" && d.LastName == "Денковски").Id,
                            SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Перо" && d.LastName == "Латковски").Id
                        },
                        new Course
                        {
                            Title = "Микропроцесорски системи",
                            Credits = 6,
                            Semestar = 2,
                            Programme = "КТИ",
                            EducationLevel = "Дипломски",
                            FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Марија" && d.LastName == "Календар").Id,
                            SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Ана" && d.LastName == "Чолаковска").Id
                        },
                        new Course
                        {
                            Title = "Веб апликации",
                            Credits = 6,
                            Semestar = 3,
                            Programme = "КХИЕ",
                            EducationLevel = "Дипломски",
                            FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Горан" && d.LastName == "Јакимовски").Id,
                            SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Марко" && d.LastName == "Порјазовски").Id
                        },
                        new Course
                        {
                            Title = "Основи на веб Програмирање",
                            Credits = 6,
                            Semestar = 4,
                            Programme = "ТКИИ",
                            EducationLevel = "Дипломски",
                            FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Владимир" && d.LastName == "Атанасовски").Id,
                            SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Валентин" && d.LastName == "Раковиќ").Id
                        }
                    );
                context.SaveChanges();

                context.Student.AddRange(
                    new Student { FirstName = "Стефан", LastName = "Станковиќ", Indeks = "179/2018", EnrollmentDate = DateTime.Parse("2018-6-6"), AcquireCredits = 240, CurrentSemestar = 6, EducationLevel = "Дипломски" },
                    new Student { FirstName = "Марко", LastName = "Марковски", Indeks = "200/2018", EnrollmentDate = DateTime.Parse("2018-6-6"), AcquireCredits = 240, CurrentSemestar = 6, EducationLevel = "Дипломски" },
                    new Student { FirstName = "Петко", LastName = "Петковски", Indeks = "231/2018", EnrollmentDate = DateTime.Parse("2018-6-6"), AcquireCredits = 120, CurrentSemestar = 6, EducationLevel = "Дипломски" },
                    new Student { FirstName = "Марија", LastName = "Станковска", Indeks = "100/2018", EnrollmentDate = DateTime.Parse("2018-6-6"), AcquireCredits = 95, CurrentSemestar = 4, EducationLevel = "Дипломски" },
                    new Student { FirstName = "Ивона", LastName = "Станковска", Indeks = "19/2018", EnrollmentDate = DateTime.Parse("2018-6-6"), AcquireCredits = 100, CurrentSemestar = 3, EducationLevel = "Дипломски" },
                    new Student { FirstName = "Немања", LastName = "Станковиќ", Indeks = "9/2018", EnrollmentDate = DateTime.Parse("2018-6-6"), AcquireCredits = 50, CurrentSemestar = 3, EducationLevel = "Дипломски" },
                    new Student { FirstName = "Виктор", LastName = "Викторовски", Indeks = "17/2018", EnrollmentDate = DateTime.Parse("2018-6-6"), AcquireCredits = 240, CurrentSemestar = 6, EducationLevel = "Дипломски" }
                    );
                context.SaveChanges();

                context.Enrollment.AddRange(
                    new Enrollment { StudentId = 1, CourseId = 1 },
                    new Enrollment { StudentId = 2, CourseId = 1 },
                    new Enrollment { StudentId = 3, CourseId = 1 },
                    new Enrollment { StudentId = 4, CourseId = 2 },
                    new Enrollment { StudentId = 5, CourseId = 2 },
                    new Enrollment { StudentId = 6, CourseId = 2 },
                    new Enrollment { StudentId = 7, CourseId = 3 },
                    new Enrollment { StudentId = 3, CourseId = 3 },
                    new Enrollment { StudentId = 5, CourseId = 4 },
                    new Enrollment { StudentId = 1, CourseId = 4 }
                    );
                context.SaveChanges();
            }
        }
    }
}
