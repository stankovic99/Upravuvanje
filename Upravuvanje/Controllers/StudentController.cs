using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Upravuvanje.Data;
using Upravuvanje.Models;
using Upravuvanje.ViewModels;

namespace Upravuvanje.Controllers
{
    public class StudentController : Controller
    {
        private readonly UpravuvanjeContext _context;
        private readonly IHostingEnvironment webHostEnvironment;
        public StudentController(UpravuvanjeContext context, IHostingEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            IEnumerable<Student> studenti = _context.Student.AsEnumerable();

            var studentIndeksVM = new StudentViewModels
            {
                Students = studenti.ToList()
            };
            return View(studentIndeksVM);
            /*var upravuvanjeContext = _context.Enrollment.Include(e => e.Student).Distinct();
            return View(await upravuvanjeContext.ToListAsync());*/
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Predmet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _context.Student.Include(m=>m.Courses).ThenInclude(m=>m.Course).FirstOrDefaultAsync(m => m.Id == id);
            var predmet = await _context.Student.FindAsync(id);
            ViewData["Student"] = predmet.FullName;
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.FindAsync(id);
            var predmet = await _context.Course.FindAsync(enrollment.CourseId);
            var student = await _context.Student.FindAsync(enrollment.StudentId);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = predmet.Title;
            ViewData["StudentId"] = student.FullName;
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormFile proekt)
        {
            var enrollment = await _context.Enrollment.FindAsync(id);
            if (id != enrollment.Id)
            {
                return NotFound();
            }

            StudentController dodadiURL = new StudentController(_context, webHostEnvironment);
            enrollment.SeminalUrl = dodadiURL.UploadedFile(proekt);
            var predmet = await _context.Course.FindAsync(enrollment.CourseId);
            var student = await _context.Student.FindAsync(enrollment.StudentId);
            ViewData["CourseId"] = predmet.Title;
            ViewData["StudentId"] = student.FullName;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            
            return View(enrollment);
        }

        public string UploadedFile(IFormFile file)
        {
            string uniqueFileName = null;
            if (file != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "projects");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
       
        private bool EnrollmentExists(int id)
        {
            return _context.Enrollment.Any(e => e.Id == id);
        }
    }
}
