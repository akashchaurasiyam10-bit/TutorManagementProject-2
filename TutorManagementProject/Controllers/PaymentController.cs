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
    public class PaymentController : Controller
    {
        TutorManagmentEntities1 tm = new TutorManagmentEntities1();

        // GET: Payment
        [Authorize(Roles = "Admin, Student")]
        public ActionResult PaymentDetails()
        {

            return View(tm.Payments.ToList());
        }

        // GET: Payment/Details/5
        [Authorize(Roles = "Admin, Student")]
        public ActionResult PaymentDetail(int PaymentId)  // int id
        {
            return View(tm.Payments.Find(PaymentId));
        }

        // GET: Payment/Create
        [Authorize(Roles = "Admin")]
        public ActionResult AddPayment()
        {
            ViewBag.StudentId = new SelectList(tm.Students, "StudentId", "StudentName");
            ViewBag.BatchId = new SelectList(tm.Batches, "BatchId", "BatchName");
            ViewBag.PaymentId = new SelectList(tm.Batches, "BatchId","BatchFee");
            return View();
        }

        // POST: Payment/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddPayment(Payment payment)
        {

            // TODO: Add insert logic here
            tm.Payments.Add(payment);
                tm.SaveChanges();
                return RedirectToAction("PaymentDetails");
           
        }

        // GET: Payment/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult EditPayment(int PaymentId)  // int id -- Single Value Show
        {
            ViewBag.StudentId = new SelectList(tm.Students, "StudentId", "StudentName");
            ViewBag.BatchId = new SelectList(tm.Batches, "BatchId", "BatchName");
            ViewBag.PaymentId = new SelectList(tm.Batches, "BatchId", "BatchFee");
            return View(tm.Payments.Find(PaymentId));
        }

        // POST: Payment/Edit/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult UpdatePayment(Payment payment)
        {
            // TODO: Add update logic here
            tm.Entry(payment).State = EntityState.Modified;
            tm.SaveChanges();
                return RedirectToAction("PaymentDetails");
        }

        // GET: Payment/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult DeletePayment(int PaymentId)  //int id
        {
            return View(tm.Payments.Find(PaymentId));
        }

        // POST: Payment/Delete/5
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeletePayment(Payment payment)
        {
           
                // TODO: Add delete logic here
                Payment payment1 = tm.Payments.Find(payment.PaymentId);
                tm.Payments.Remove(payment1);
                tm.SaveChanges();
                return RedirectToAction("PaymentDetails");
         
        }
    }
}
