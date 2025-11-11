using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using TutorManagementProject.Models;

namespace TutorManagementProject.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        TutorManagmentEntities1 tm = new TutorManagmentEntities1();

        //[HttpGet]
        //public ActionResult Login()
        //{

        //    return View();
        //}
        // //
        //[HttpPost]
        //public ActionResult Login(Member loginUser)
        //{
        //   bool IsValid = tm.LoginUsers.Any(U => U.UserName == loginUser.UserName && U.Password == loginUser.Password );
        //    if (IsValid)
        //    {
        //        FormsAuthentication.SetAuthCookie(loginUser.UserName, false);
        //        return RedirectToAction("PaymentDetails", "Payment");
        //    }
        //        ModelState.AddModelError("", "Invalid User Name And Passsword");
        //        return View();
        //}

        //[HttpGet]
        //public ActionResult SignUp()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult SignUp(Member model)
        //{
        //    using (var context = new TutorManagmentEntities1())
        //    {
        //        context.Me.Add(model);
        //        context.SaveChanges();
        //    }

        //    //tm.LoginUsers.Add(loginUser);

        //    //tm.SaveChanges();
        //    return RedirectToAction("Login");
        
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}