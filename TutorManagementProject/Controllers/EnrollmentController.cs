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
    public class EnrollmentController : Controller
    {
        TutorManagmentEntities1 tm = new TutorManagmentEntities1();

        // GET: Enrollment
        [Authorize(Roles = "Admin, Student")]
        public ActionResult EnrollmentDetails()
        {
            //var count = tm.Enrollments.Where(E => E.Status == true);
            return View(tm.Enrollments);
        }

        // GET: Enrollment/Details/5
        [Authorize(Roles = "Admin, Student")]
        public ActionResult EnrollmentDetail(int EnrollmentId)  // int id
        {
            return View(tm.Enrollments.Find(EnrollmentId));
        }

        // GET: Enrollment/Create
        [Authorize(Roles = "Admin, Student")]
        public ActionResult AddEnrollment()
        {
            ViewBag.StudentId = new SelectList(tm.Students, "StudentId", "StudentName");
            ViewBag.BatchId = new SelectList(tm.Batches, "BatchId", "BatchName");
            return View();
        }

        // POST: Enrollment/Create
        [HttpPost]
        [Authorize(Roles = "Admin, Student")]
        public ActionResult AddEnrollment(Enrollment enrollment)
        {
           
                // TODO: Add insert logic here
                tm.Enrollments.Add(enrollment);
            tm.SaveChanges();
                return RedirectToAction("EnrollmentDetails");
        }

        // GET: Enrollment/Edit/5
        [Authorize(Roles = "Admin, Student")]
        public ActionResult EditEnrollment(int EnrollmentId)  // int id
        {
            ViewBag.StudentId = new SelectList(tm.Students, "StudentId", "StudentName", EnrollmentId);
            ViewBag.BatchId = new SelectList(tm.Batches, "BatchId", "BatchName");
            return View(tm.Enrollments.Find(EnrollmentId));
        }

        // POST: Enrollment/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin, Student")]
        public ActionResult UpdateEnrollment(Enrollment enrollment)
        {

                // TODO: Add update logic here
                tm.Entry(enrollment).State = EntityState.Modified;
                tm.SaveChanges();
                return RedirectToAction("EnrollmentDetails");
        }

        // GET: Enrollment/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteEnrollment(int EnrollmentId)  // int id
        {
            return View(tm.Enrollments.Find(EnrollmentId));
        }

        // POST: Enrollment/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteEnrollment(Enrollment enrollment)
        {
           
                // TODO: Add delete logic here
                Enrollment enrollments = tm.Enrollments.Find(enrollment);
                tm.Enrollments.Remove(enrollments);  // Paramanent Data delete
               
               tm.Entry(enrollment).State= EntityState.Modified;
               tm.SaveChanges();

                return RedirectToAction("EnrollmentDetails");
        }
    }
}
