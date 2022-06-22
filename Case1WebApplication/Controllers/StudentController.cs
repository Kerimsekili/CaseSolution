using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Web;
using Case1WebApplication.Models;
using Case1WebApplication.Models.EntityFramework;
using System.Linq;

namespace Case1WebApplication.Controllers

{
    public class StudentController : Controller
    {
        CaseDatabaseContext db = new CaseDatabaseContext();
        //CRUD OPERATİONS
        public IActionResult Index()
        {
            var ogrenciler = db.Students.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student t)
        {
            db.Students.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult StudentDelete(int id)
        {
            var student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetStudent(int id)
        {
          var student = db.Students.Find(id);
            return View("GetStudent", student);
        }
        public ActionResult UpdateStudent(Student t)
        {
            var student=db.Students.Find(t.Id);
            student.Name=t.Name;
            student.Surname=t.Surname;
            student.Midterm=t.Midterm;
            student.Final=t.Final;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
