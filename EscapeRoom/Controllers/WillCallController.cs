using EscapeRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeRoom.Controllers
{
    public class WillCallController : Controller
    {
        // GET: WillCall
        public ActionResult Index()
        {
            WillCallModel model = new WillCallModel();
            model.sessions = new List<Session>();

            using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
            {
                model.sessions = entities.Sessions.Where(x => x.Start >= DateTime.UtcNow).ToList();
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult Index(WillCallModel model)
        {
            
            model.sessions = new List<Session>();

            using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
            {
                model.sessions = entities.Sessions.Where(x => x.Start >= DateTime.UtcNow).ToList();
            }


            return View(model);
        }
    }
}