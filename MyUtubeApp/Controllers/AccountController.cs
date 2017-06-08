using MyUtubeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyUtubeApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }


        //public ActionResult Register(RegisterViewModel model)
        //{
        //   save model in the User Table

        // var user = new User() {
           //    Username = model.username,
           //    Password = model.password
          //    }; 

            //db.User.Add(user);
            //db.Save();

        //    return View();
        //}

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            //check in the database compare if the model.Username is same in the database

            using (var db = new MyUtubeEntities())
            {
                var exituser = db.Users.Where(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefault();

                if (exituser == null)
                {
                    ViewBag.IncorrectLogin = "Sorry incorrect Username or Password";
                    return View();
                }
                else
                {  // set cookie
                    FormsAuthentication.SetAuthCookie(model.Username, true);
                    // reset currentusersession
                    ResetCurrentUserSession(model.Username);
                    //redirect home index page
                    return RedirectToAction("Index", "Home");
                }


            }
        }

        public static void ResetCurrentUserSession(string userName =null)
        {
           if (string.IsNullOrEmpty(userName))
            {
                userName = System.Web.HttpContext.Current.User.Identity.Name;
            }

           using (var db = new MyUtubeEntities())
            {
                var user = db.Users.FirstOrDefault(n => n.Username == userName);
                if (user == null) { return;  }
                CurrentSession.CurrentUser = user;
            }
                 
        }

    }
}