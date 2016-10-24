using EscapeRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeRoom.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Game> model = new List<Game>();
            using (EscapeRoomDBEntities entity = new EscapeRoomDBEntities())
            {
                
                model = entity.Games.ToList();

            }

            return View(model);
        
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