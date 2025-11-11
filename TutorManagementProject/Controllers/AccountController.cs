using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TutorManagementProject.Models;

namespace TutorManagementProject.Controllers
{
    //[Authorize]
    //[AllowAnonymous]
    public class AccountController : Controller
    {
        TutorManagmentEntities1 db = new TutorManagmentEntities1();

        // GET: DefaulAccount
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            // Check if username and password match
            var isValid = db.Users.Any(u => u.Username == user.Username && u.Password == user.Password);

            if (isValid)
            {
                // Set auth cookie
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("Index", "dashboard");
            }
            ModelState.AddModelError("", "Invalid User Name And Password");
            return View();
        }

        //[HttpGet]
        //public ActionResult ForgetPassword()
        //{
        //    return RedirectToAction("Signup");
        //}

        public ActionResult Signup()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Signup(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(user); // Show errors
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
