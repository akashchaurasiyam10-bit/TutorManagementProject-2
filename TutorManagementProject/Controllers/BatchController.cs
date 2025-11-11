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
    public class BatchController : Controller
    {
        TutorManagmentEntities1 tm = new TutorManagmentEntities1();
        // GET: Batch
        [Authorize(Roles ="Admin, Student")]
        public ActionResult BatchDetails()
        {
            return View(tm.Batches.Where(B => B.Active == true));
           
        }

        // GET: Batch/Details/5
        [Authorize(Roles = "Student, Admin")]
        public ActionResult BatchDetail(int BatchId)  // int id
        {
            return View(tm.Batches.Find(BatchId));
        }

        // GET: Batch/Create
        [Authorize(Roles = "Admin")]
        public ActionResult AddBatch()
        {
            ViewBag.StudentId = new SelectList(tm.Students, "StudentId", "StudentName");
            ViewBag.TutorId = new SelectList(tm.Tutors, "TutorId", "TutorName");
            return View();
        }

        // POST: Batch/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddBatch(Batch batch)
        {
            // TODO: Add insert logic here
            tm.Batches.Add(batch);
            tm.SaveChanges();

            return RedirectToAction("BatchDetails");
        }

        // GET: Batch/Edit/5
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult EditBatch(int BatchId)  // int id
        {
            Batch batch = tm.Batches.Find(BatchId);
            ViewBag.StudentId = new SelectList(tm.Students, "StudentId", "StudentName", batch.StudentId);
            ViewBag.TutorId = new SelectList(tm.Tutors, "TutorId", "TutorName", batch.TutorId);
            return View(batch);
        }

        // POST: Batch/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdateBatch(Batch batch)
        {
            // TODO: Add update logic here
            //batch.Active = true;
           tm.Entry(batch).State = EntityState.Modified;
            tm.SaveChanges();
                return RedirectToAction("BatchDetails");
        }

        // GET: Batch/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteBatch(int BatchId)  // int id
        {

            return View(tm.Batches.Find(BatchId));
        }

        // POST: Batch/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteBatch(Batch batch)
        {

            // TODO: Add delete logic here
            Batch batch1 = tm.Batches.Find(batch.BatchId);
            tm.Batches.Remove(batch1);  // If Record Delete Paramanent then Run this Both Line

            //tm.Entry(batch).State = EntityState.Modified;
            tm.SaveChanges();
                return RedirectToAction("BatchDetails");
        }
    }
}
