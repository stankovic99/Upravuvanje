using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Upravuvanje.Areas.Identity.Data;
using Upravuvanje.Models;

namespace Upravuvanje.Data
{
    public class UpravuvanjeContext : IdentityDbContext<UpravuvanjeUser>
    {
        public UpravuvanjeContext (DbContextOptions<UpravuvanjeContext> options)
            : base(options)
        {
        }

        public DbSet<Upravuvanje.Models.Course> Course { get; set; }

        public DbSet<Upravuvanje.Models.Student> Student { get; set; }

        public DbSet<Upravuvanje.Models.Teacher> Teacher { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Enrollment>()
            .HasOne<Student>(p => p.Student)
            .WithMany(p => p.Courses)
            .HasForeignKey(p => p.StudentId);

            builder.Entity<Enrollment>()
            .HasOne<Course>(p => p.Course)
            .WithMany(p => p.Students)
            .HasForeignKey(p => p.CourseId);

            builder.Entity<Course>()
            .HasOne<Teacher>(p => p.Teacher1)
            .WithMany(p => p.Course1)
            .HasForeignKey(p => p.FirstTeacherId);

            builder.Entity<Course>()
            .HasOne<Teacher>(p => p.Teacher2)
            .WithMany(p => p.Course2)
            .HasForeignKey(p => p.SecondTeacherId);

            base.OnModelCreating(builder);
            
        }
        
    }
}
