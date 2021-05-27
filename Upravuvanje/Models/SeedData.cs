using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upravuvanje.Areas.Identity.Data;
using Upravuvanje.Data;
using Upravuvanje.Models;

namespace MVCMovie.Models
{
    public class SeedData
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<UpravuvanjeUser>>();
            IdentityResult roleResult;

            //Add Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin")); }

            //Add Admin User
            UpravuvanjeUser user = await UserManager.FindByEmailAsync("admin@upravuvanje.com");
            if (user == null)
            {
                var User = new UpravuvanjeUser();
                User.Email = "admin@upravuvanje.com";
                User.UserName = "admin@upravuvanje.com";
                string userPWD = "Admin123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Admin"); }
            }

            //Add Teacher Role
            roleCheck = await RoleManager.RoleExistsAsync("Teacher");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Teacher"));
            }

            user = await UserManager.FindByEmailAsync("profesor@upravuvanje.com");
            if (user == null)
            {
                var User = new UpravuvanjeUser();
                User.Email = "profesor@upravuvanje.com";
                User.UserName = "profesor@upravuvanje.com";
                User.TeacherId = 1;
                string userPWD = "Profesor123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Teacher"); }
            }

            //Add Student Role
            roleCheck = await RoleManager.RoleExistsAsync("Student");
            if (!roleCheck)
            {
                roleResult = await RoleManager.CreateAsync(new IdentityRole("Student"));
            }

            user = await UserManager.FindByEmailAsync("student@upravuvanje.com");
            if (user == null)
            {
                var User = new UpravuvanjeUser();
                User.Email = "student@upravuvanje.com";
                User.UserName = "student@upravuvanje.com";
                User.StudentId = 2;
                string userPWD = "Student123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Student"); }
            }
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            
            using (var context = new UpravuvanjeContext(
            serviceProvider.GetRequiredService<
            DbContextOptions<UpravuvanjeContext>>()))
            {
                CreateUserRoles(serviceProvider).Wait();
                //CreateUserRoles(serviceProvider).Wait();
                // Look for any movies.
                if (context.Course.Any() || context.Teacher.Any() || context.Student.Any())
                {
                    return; // DB has been seeded
                }

                context.Teacher.AddRange(
                    new Teacher { FirstName = "Даниел", LastName = "Денковски", Degree = "Професор", AcademicRank = "Доцент", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3"), Course1 = new List<Course>(), Course2 = new List<Course>() },
                    new Teacher { FirstName = "Перо", LastName = "Латковски", Degree = "Професор", AcademicRank = "Доктор", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3"), Course1 = new List<Course>(), Course2 = new List<Course>() },
                    new Teacher { FirstName = "Марија", LastName = "Календар", Degree = "Професор", AcademicRank = "Доктор", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3"), Course1 = new List<Course>(), Course2 = new List<Course>() },
                    new Teacher { FirstName = "Ана", LastName = "Чолаковска", Degree = "Магистар", AcademicRank = "Магистар", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3"), Course1 = new List<Course>(), Course2 = new List<Course>() },
                    new Teacher { FirstName = "Горан", LastName = "Јакимовски", Degree = "Професор", AcademicRank = "Доцент", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3"), Course1 = new List<Course>(), Course2 = new List<Course>() },
                    new Teacher { FirstName = "Марко", LastName = "Порјазовски", Degree = "Професор", AcademicRank = "Доцент", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3"), Course1 = new List<Course>(), Course2 = new List<Course>() },
                    new Teacher { FirstName = "Владимир", LastName = "Атанасовски", Degree = "Професор", AcademicRank = "Доцент", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3"), Course1 = new List<Course>(), Course2 = new List<Course>() },
                    new Teacher { FirstName = "Валентин", LastName = "Раковиќ", Degree = "Професор", AcademicRank = "Доцент", OfficeNumber = "01234", HireDate = DateTime.Parse("2020-2-3"), Course1 = new List<Course>(), Course2 = new List<Course>() }
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
                    new Enrollment { StudentId = 1, CourseId = 1, Year = 2021 },
                    new Enrollment { StudentId = 2, CourseId = 1, Year = 2020 },
                    new Enrollment { StudentId = 3, CourseId = 1, Year = 2021 },
                    new Enrollment { StudentId = 4, CourseId = 2, Year = 2019 },
                    new Enrollment { StudentId = 5, CourseId = 2, Year = 2020 },
                    new Enrollment { StudentId = 6, CourseId = 2, Year = 2021 },
                    new Enrollment { StudentId = 7, CourseId = 3, Year = 2021 },
                    new Enrollment { StudentId = 3, CourseId = 3, Year = 2019 },
                    new Enrollment { StudentId = 5, CourseId = 4, Year = 2020 },
                    new Enrollment { StudentId = 1, CourseId = 4, Year = 2021 }
                    );
                context.SaveChanges();
            }
        }
    }
}
