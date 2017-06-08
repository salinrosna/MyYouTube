using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyUtubeApp.Models;
using System.Web.Security;
   

namespace MyUtubeApp.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel mdl)
        {

            if (mdl.Password == mdl.ConfirmPassword)
            {

                using (var db = new MyUtubeEntities1())
                {
                    var emailuser = db.Users.Where(x => x.Email == mdl.Email).FirstOrDefault();
                    if (emailuser == null)
                    {
                        var user = new User()
                        {
                            Username = mdl.Username,
                            Email = mdl.Email,
                            Password = mdl.Password,
                            Gender = mdl.Gender,
                            IsActive = true,
                            Createdon = DateTime.Now,
                            Modifiedon = DateTime.Now

                        };
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    else
                    {
                        ViewBag.Emailmessage = "Sorry, Email address already taken";
                        return View();
                    }
                }
                    FormsAuthentication.SetAuthCookie(mdl.Username, true);
                    ResetCurrentSession(mdl.Username);
                    return RedirectToAction("index", "home");

                }
            else
            {
                    ViewBag.cmfrmpass = "Sorry, Password does not match";
                }
            
                return View();
            
        }
        


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model)
        {
            using (var db = new MyUtubeEntities1()) 
            {
                var exituser = db.Users.Where(y => y.Username == model.Username && y.Password == model.Password).FirstOrDefault();
                if(exituser== null)
                {
                    ViewBag.IncorrectLogin = "Sorry Incorrect Username or Password";
                    return View();
                }
               else
                {
                    FormsAuthentication.SetAuthCookie(model.Username, true);
                    ResetCurrentSession(model.Username);
                    return RedirectToAction("Index", "Home");

                }
            }
           
        }
        public static void ResetCurrentSession(string username = null)
        {
            if(string.IsNullOrEmpty(username))
                {
                username = System.Web. HttpContext.Current.User.Identity.Name;
               
            }
            using (var db = new MyUtubeEntities1())
            {

                var user = db.Users.FirstOrDefault(n => n.Username == username);
                if(user == null)
                {
                    return;
                }
                CurrentSession.CurrentUser = user;
              }

        }

        
        public ActionResult Logout()
        {
            
            Session.Abandon();
            FormsAuthentication.SignOut();
            CurrentSession.CurrentUser = null;

            return RedirectToAction("Index", "Home");
        }

    }
}