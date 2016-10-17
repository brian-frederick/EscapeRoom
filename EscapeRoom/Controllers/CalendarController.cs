using EscapeRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeRoom.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Data()
        {
           
            using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
            {
                List<SessionModel> list = new List<SessionModel>();
                foreach(Session s in entities.Sessions)
                {
                    SessionModel sMod = new SessionModel();
                    sMod.Id = s.Id;
                    sMod.Title = s.Title;
                    sMod.Color = s.Color;
                    sMod.Start = s.Start;
                    //having an issue here with null inventory
                    //sMod.Inventory = s.Game.Capacity - s.Baskets.SelectMany(y => y.Players).Count();
                    list.Add(sMod);                       
                }

                //change to camelcase from initial caps for the javascript calendar package
                Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver camelSerializer = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
                Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
                settings.ContractResolver = camelSerializer;
                string content = Newtonsoft.Json.JsonConvert.SerializeObject(list, settings);

                //return the list
                return Content(content);
            }
        }
    }
}

