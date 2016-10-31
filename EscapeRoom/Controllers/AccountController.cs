using EscapeRoom.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EscapeRoom.Controllers
{
    public class AccountController : Controller
    {
        public int AppSettings { get; private set; }

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
        [AllowAnonymous]
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
                    string token = WebMatrix.WebData.WebSecurity.CreateUserAndAccount(model.Email, model.Password,
                        new
                        {
                            DateCreated = DateTime.UtcNow,
                            FirstName = model.FirstName,
                            LastName = model.LastName,
                            Phone = model.Phone,
                            Email = model.Email
                        },
                        true);

                    string apiKey = ConfigurationManager.AppSettings["SendGrid.Key"];
                    SendGrid.SendGridAPIClient client = new SendGrid.SendGridAPIClient(apiKey);

                    SendGrid.Helpers.Mail.Email from = new SendGrid.Helpers.Mail.Email("admin@ChicagoUnlocked.com");
                    string subject = "Complete your EscapeRoom Registration";
                    SendGrid.Helpers.Mail.Email to = new SendGrid.Helpers.Mail.Email(model.Email);
                    string emailContent = string.Format("<html><body><a href=\"{0}\">Complete your registration</a></body></html>", Request.Url.GetLeftPart(UriPartial.Authority) +
                         "/Account/REgisterConfirm/" + HttpUtility.UrlEncode(token) + "?email=" + HttpUtility.UrlEncode(model.Email));
                    SendGrid.Helpers.Mail.Content content = new SendGrid.Helpers.Mail.Content("Text/html", emailContent);
                    SendGrid.Helpers.Mail.Mail mail = new SendGrid.Helpers.Mail.Mail(from, subject, to, content);

                    client.client.mail.send.post(requestBody: mail.Get());
                    return RedirectToAction("RegisterComplete");
                }
                return View(model);

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

        [AllowAnonymous]
        public ActionResult RegisterComplete()
        {
            return View();
        }
        public ActionResult RegisterConfirm(string id, string email)
        {
            if (WebMatrix.WebData.WebSecurity.ConfirmAccount(email, id))
            {
                ViewBag.Confirmed = true;
                return View();
            };
            return View();
        }
    }
}