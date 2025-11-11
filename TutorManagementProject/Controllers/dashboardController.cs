using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TutorManagementProject.Models;

namespace TutorManagementProject.Controllers
{
    public class dashboardController : Controller
    {


        //private Tu db = new AppDbContext();

        //TutorManagmentEntities1 db = new TutorManagmentEntities1();
        //[Authorize(Roles = "Admin, Student")]
        //public ActionResult Index()
        //{
        //    var totalTutors = db.Tutors.Count();
        //    var totalStudents = db.Students.Count();
        //    var totalBatchs = db.Batches.Count();
        //    var upcomingBatches = db.Batches
        //                            .Where(b => b.StartDate > DateTime.Now)
        //                            .OrderBy(b => b.StartDate)
        //                            .Take(5)
        //                            .ToList();

        //    ViewBag.TotalTutors = totalTutors;
        //    ViewBag.TotalStudents = totalStudents;
        //    ViewBag.UpcomingBatches = upcomingBatches;
        //    ViewBag.TotalBatchs = totalBatchs;

        //    return View();

        //}


        //--------------------------------------------------------------



        public ActionResult Index()
        {
            // Dummy data (you can replace it with database calls)
            ViewBag.TotalStudents = 45;
            ViewBag.TotalTutors = 10;
            ViewBag.TotalCourses = 12;
            ViewBag.TotalFees = 35000;

            // Example notices
            ViewBag.Notices = new List<(DateTime Date, string Notice)>
            {
                (DateTime.Parse("2025-02-14"), "All students must maintain 75% attendance."),
                (DateTime.Parse("2025-02-19"), "Semester exams will begin from March 2025.")
            };

            // Example transactions
            ViewBag.Transactions = new List<(DateTime Date, string Receipt, decimal Amount)>
            {
                (DateTime.Parse("2025-10-01"), "2022001123", 2500),
                (DateTime.Parse("2025-09-20"), "2022001198", 12000),
                (DateTime.Parse("2025-09-10"), "2022001155", 1500)
            };

            return View();
        }



    }
}
