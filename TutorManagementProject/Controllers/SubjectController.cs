using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorManagementProject.Models;
using System.Data.Entity;

namespace TutorManagementProject.Controllers
{
    
    public class SubjectController : Controller
    {
        TutorManagmentEntities1 tm = new TutorManagmentEntities1();
        // GET: Subject
        [Authorize(Roles = "Admin, Student")]
        public ActionResult SubjectDetails()
        {
            return View(tm.Subjects.Where(S => S.Active == true));
        }

        // GET: Subject/Details/5
        [Authorize(Roles = "Admin, Student")]
        public ActionResult SubjectDetail(int SubjectId) // int id
        {
            return View(tm.Subjects.Find(SubjectId));
        }

        // GET: Subject/Create
        [Authorize(Roles = "Admin")]
        public ActionResult AddSubject()
        {
            return View();
        }

        // POST: Subject/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddSubject(Subject subject)
        {
            // TODO: Add insert logic here
            tm.Subjects.Add(subject);
            tm.SaveChanges();
                return RedirectToAction("SubjectDetails");
            
        }

        // GET: Subject/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditSubject(int SubjectId) // int id
        {
            return View(tm.Subjects.Find(SubjectId));
        }

        // POST: Subject/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult EditSubject(Subject subject)
        {
           
                // TODO: Add update logic here
                tm.Entry(subject).State = EntityState.Modified;
            tm.SaveChanges();
                return RedirectToAction("SubjectDetails");
        }

        // GET: Subject/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteSubject(int SubjectId) // int id
        {
            return View(tm.Subjects.Find(SubjectId));
        }

        // POST: Subject/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteSubject(Subject subject)
        {

            // TODO: Add delete logic here
            tm.Entry(subject).State = EntityState.Modified;
            tm.SaveChanges();
                return RedirectToAction("SubjectDetails");
           
        }
    }
}
