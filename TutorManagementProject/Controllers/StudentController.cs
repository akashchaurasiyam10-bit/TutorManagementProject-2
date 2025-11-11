using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using TutorManagementProject.Models;

namespace TutorManagementProject.Controllers
{
    
    public class StudentController : Controller
    {
        TutorManagmentEntities1 tm = new TutorManagmentEntities1();

        // GET: Student
        [Authorize(Roles = "Admin, Student, Rahul")]
        public ActionResult DisplayStudents(string searchBy, string search)
        {
            //var Std = tm.Students.Where(S => S.Active == true);
            ////var Std = tm.Students;
            //return View(Std);

            if (searchBy == "Name")
            {

                var data = tm.Students.Where(model => model.FirstName.StartsWith(search)).ToList();
                return View(data);
            }
            else if (searchBy == "StudentId")
            {
                
                int searchId = Convert.ToInt32(search);
                var data = tm.Students.Where(model => model.StudentId == searchId);

                return View(data);

            }
            else
            {
                var data =  tm.Students.ToList();
                return View(data);
            }


        }

        // GET: Student/Details/5
        [Authorize (Roles = "Student")]
        public ActionResult DisplayStudent(int? StudentId)
        {
            var roles = Roles.GetRolesForUser(User.Identity.Name);
            ViewBag.Roles = string.Join(",", roles);
            Student student = tm.Students.Find(StudentId);
            return View(student);
        }
      // GET: Student/Create


        [Authorize (Roles = "Student")]
        [HttpGet]
        public ActionResult AddStudent() // int Id
        {
            var roles = Roles.GetRolesForUser(User.Identity.Name);
            ViewBag.Roles = string.Join(",", roles);

            //ViewBag.StdId = new SelectList(tm.Students, "StudentId", "FirstaName");
            return View();
        }

        // POST: Student/Create
        
        [Authorize(Roles = "Student")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStudent(Student student) // FormCollection collection
        {
            //student.Active = true;
            tm.Students.Add(student);
            tm.SaveChanges();
            // TODO: Add insert logic here
            
            return RedirectToAction("DisplayStudents");
           
        }

        // GET: Student/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditStudent(int StudentId) // int Id
        {
            Student student = tm.Students.Find(StudentId);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateStudent(Student student)
        {
            // TODO: Add update logic here
            //student.Active == true;
            tm.Entry(student).State = EntityState.Modified;
            tm.SaveChanges();
            return RedirectToAction("DisplayStudents");
                        
        }

        // GET: Student/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteStudent(int StudentId)
        {
            Student student = tm.Students.Find(StudentId);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public RedirectToRouteResult DeleteStudent(Student student)
        {

            // TODO: Add delete logic here
            //Student student1 = tm.Students.Find(student.StudentId);
            //tm.Students.Remove(student1);  // Delete Parmanent Delete Records

            tm.Entry(student).State = EntityState.Modified;
            tm.SaveChanges();
            return RedirectToAction("DisplayStudents");
           
        }
    }
}
