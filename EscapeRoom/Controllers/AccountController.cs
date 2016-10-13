using EscapeRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EscapeRoom.Controllers
{
    public class AccountController : Controller
    {
        //GET: Account
        public ActionResult Index()
        {
            RegistrationModel model = new RegistrationModel();

            using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
            {
                var user = entities.Users.Single(x => x.Email == User.Identity.Name);
                model.FirstName = user.FirstName;
                model.LastName = user.LastName;
                model.Phone = user.Phone;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
                {
                    var user = entities.Users.Single(x => x.Email == User.Identity.Name);
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Phone = model.Phone;

                    entities.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
            
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            RegistrationModel model = new RegistrationModel();
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                if (WebMatrix.WebData.WebSecurity.UserExists(model.Email))
                {
                    ModelState.AddModelError("Email", "Email address is already registered");
                }
                else
                {
                    //model.DateCreated = DateTime.UtcNow;
                    WebMatrix.WebData.WebSecurity.CreateUserAndAccount(model.Email, model.Password, new { DateCreated = DateTime.UtcNow, FirstName = model.FirstName, LastName = model.LastName, Phone = model.Phone, Email = model.Email }, false);
                    System.Web.Security.FormsAuthentication.SetAuthCookie(model.Email, true);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
            
        }

        //GET: Account/LogOut
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        //Get:Account/Login
        public ActionResult Login()
        {
            RegistrationModel model = new RegistrationModel();
            return View();
        }



        [HttpPost]
        public ActionResult Login(RegistrationModel model)
        {

            if (ModelState.IsValid)
            {
                
                if (Membership.ValidateUser(model.Email, model.Password))
                {                    
                    System.Web.Security.FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Email", "Email address or password is incorrect");
                }

            }
            return View();
        }
    }
}