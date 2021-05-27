using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Upravuvanje.Data;
using Upravuvanje.Models;
using Upravuvanje.ViewModels;

namespace Upravuvanje.Controllers
{
    public class ProfesorController : Controller
    {
        private readonly UpravuvanjeContext _context;

        public ProfesorController(UpravuvanjeContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index(int id)
        {
            IQueryable<Course> kursevi = _context.Course.AsQueryable();
            kursevi = kursevi.Where(s => s.Id == id);
            kursevi = kursevi.Include(c => c.Teacher1).Include(c => c.Teacher2);

            var PredmetVM = new ProfesorViewModels
            { 
                Profesori = await kursevi.ToListAsync()
            };return View(PredmetVM);
            /*var upravuvanjeContext = _context.Course.Include(c => c.Teacher1).Include(c => c.Teacher2).Include(c => c.Students).ThenInclude(c => c.Student);
            return View(await upravuvanjeContext.ToListAsync());*/

        }

        // GET: Courses/Studenti/5
        public async Task<IActionResult> Studenti(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .Include(c => c.Students).ThenInclude(c => c.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            var predmet = await _context.Course.FindAsync(id);
            
            ViewData["CourseId"] = predmet.Title;
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

       
        
        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.FindAsync(id);
            var student = await _context.Student.FindAsync(enrollment.StudentId);
            var predmet = await _context.Course.FindAsync(enrollment.CourseId);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Semestar,Year,Grade,SeminalUrl,ProjectUrl,ExamPoint,SeminalPoints,ProjectPoints,AdditionalPoints,FinishDate,StudentId,CourseId")] Enrollment enrollment)
        {
            if (id != enrollment.Id)
            {
                return NotFound();
            }

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
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Title", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FullName", enrollment.StudentId);
            return View(enrollment);
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollment.Any(e => e.Id == id);
        }
    }
}

