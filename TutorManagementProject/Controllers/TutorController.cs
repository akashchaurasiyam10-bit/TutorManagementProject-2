using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TutorManagementProject.Models;
namespace TutorManagementProject.Controllers
{
    [Authorize]
    public class TutorController : Controller
    {
        TutorManagmentEntities1 tm = new TutorManagmentEntities1();
        // GET: Tutor
        [Authorize(Roles = "Admin, Student, Tutor")]
        public ActionResult TutorDetails()
        {
            //var tud = tm.Tutors.Where(B => B.Status == true).ToList();
            return View(tm.Tutors);
        }

        // GET: Tutor/Details/5
        [Authorize(Roles = "Admin, Student")]
        public ActionResult TutorDetail(int TutorId) //int id
        {
            return View(tm.Tutors.Find(TutorId));
        }

        // GET: Tutor/Create
        [Authorize(Roles = "Admin, Tutor")]
        public ActionResult AddTutor()
        {
            return View();
        }

        // POST: Tutor/Create
        [HttpPost]
        [Authorize(Roles = "Admin, Tutor")]
        public ActionResult AddTutor(Tutor tutor)
        {
            // TODO: Add insert logic here

            tm.Tutors.Add(tutor);
            tm.SaveChanges();
             return RedirectToAction("TutorDetails");
        }

        // GET: Tutor/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditTutor(int TutorId) //int id
        {

            return View(tm.Tutors.Find(TutorId));
        }

        // POST: Tutor/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateTutor(Tutor tutor)
        {
            // TODO: Add update logic here
            tm.Entry(tutor).State = EntityState.Modified;
            tm.SaveChanges();
                return RedirectToAction("TutorDetails");
        }

        // GET: Tutor/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteTutor(int TutorId) // int id
        {

            return View(tm.Tutors.Find(TutorId));
        }

        // POST: Tutor/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteTutor(Tutor tutor)
        {
            // TODO: Add delete logic here
            //Tutor tutor1 = tm.Tutors.Find(tutor.TutorId);
            //tm.Students.Remove(tutor1);

            tm.Entry(tutor).State = EntityState.Modified;
            tm.SaveChanges();
                return RedirectToAction("TutorDetails");
        }
    }
}
