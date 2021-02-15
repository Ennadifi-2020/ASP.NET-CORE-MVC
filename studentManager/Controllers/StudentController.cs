using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using studentManager.Models;
using Microsoft.EntityFrameworkCore;


namespace studentManager.Controllers
{
    public class StudentController : Controller
    {
        private readonly ManagementDbContext _db;
        public StudentController(ManagementDbContext db)
        {
            _db = db;      
        }
        public IActionResult Index()
        {
            var displaydata = _db.students.ToList();
            return View(displaydata);
        }
        [HttpGet]
        public async Task<IActionResult> Index(string Sdtsearch)
        {
            ViewData["Getstudent"] = Sdtsearch;
            var etudiant = from x in _db.students select x;
            if (!string.IsNullOrEmpty(Sdtsearch))
            {
                etudiant = etudiant.Where(x => x.firstName.Contains(Sdtsearch) || x.lastName.Contains(Sdtsearch));
            }
            return View(await etudiant.AsNoTracking().ToListAsync());

        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Create(Student nst) {
            if (ModelState.IsValid)
            {
                _db.Add(nst);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nst);
        }
        public async Task<IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getempdetails = await _db.students.FindAsync(id);
            return View(getempdetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student dit) {
            if(ModelState.IsValid)
            {
                _db.Update(dit);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(dit);

        }
        public async Task<IActionResult>Details (int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getempdetails = await _db.students.FindAsync(id);
            return View(getempdetails);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var getempdetails = await _db.students.FindAsync(id);
            return View(getempdetails);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
          
            var getempdetails = await _db.students.FindAsync(id);
            _db.students.Remove(getempdetails);
            await _db.SaveChangesAsync(); 
            return RedirectToAction("Index");
        } 
    }
}
