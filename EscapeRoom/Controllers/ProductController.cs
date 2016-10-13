using EscapeRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeRoom.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int? id)
        {
            using (EscapeRoom.Models.EscapeRoomDBEntities entities = new Models.EscapeRoomDBEntities())
            {
                var session = entities.Sessions.Single(x => x.Id == id);
                Session model = new Session();
                model.Id = session.Id;
                model.Game = session.Game;
                model.Price = session.Price;
                model.Start = session.Start;

                return View(model);
            }
        }
        //POST: Product
        [HttpPost]
        public ActionResult Index(User model)
        {
            //TO DO: Add Product to cart in Database!
            using (EscapeRoom.Models.EscapeRoomDBEntities entities = new Models.EscapeRoomDBEntities())
            {

                var newEntity = new User { };
                newEntity.DateCreated = DateTime.Now;
                newEntity.Id = entities.Users.Max(x => x.Id) + 1;
                newEntity.FirstName = model.FirstName;
                newEntity.LastName = model.LastName;
                newEntity.Phone = model.Phone;
                newEntity.Email = model.Email;


                entities.Users.Add(newEntity);
                    
                entities.SaveChanges();                    
            }

            return RedirectToAction("Home", "Index");
        }
        
    }
}