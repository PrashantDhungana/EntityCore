using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class StudentController : Controller
    {
        //Dependency Injection
        private readonly MyDbContext _db;

        public StudentController(MyDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> objList = _db.Student;
            return View(objList);
        }

        //Create Form
        public IActionResult Create()
        {
            return View();
        }

        //After Create Form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            _db.Student.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Form
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var obj = _db.Student.Find(id);
            if (obj == null)
                return Ok("HERE");
            return View(obj);
        }

        //After Create Form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Student obj)
        {
            _db.Student.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

       public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var obj = _db.Student.Find(id);
            if (obj == null)
                return NotFound();
            _db.Student.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
