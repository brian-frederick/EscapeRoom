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

            //TODO: Refactor this

            //get all current sessions and convert to string list for model
            List<Session> sessionList = new List<Session>();
            model.stringSessions = new List<String>();

            using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
            {
                sessionList = entities.Sessions.Where(x => x.Start >= DateTime.UtcNow).ToList();

                foreach (var item in sessionList)
                {
                    string str = item.Id + " " + item.Game.Title + " " + item.Start;
                    model.stringSessions.Add(str);
                }

            }

                return View(model);
        }

        [HttpPost]
        public ActionResult Index(WillCallModel model)
        {
            //parse selection to get usable id
            int selectedId = Convert.ToInt32(model.selection.Substring(0, model.selection.IndexOf(" ") + 1));

            using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
            {
                model.session = entities.Sessions.Single(x => x.Id == selectedId);
                
                model.players = new List<string>();

                model.stringSessions = new List<string>();
                //get players

                var playerIdList = entities.sp_willCallPlayers(selectedId);
                foreach (var item in playerIdList)
                {
                    Player p = entities.Players.Single(x => x.Id == item);
                    string stringP = p.FirstName + " " + p.LastName + " " + p.Email + " " + p.Phone + " " + p.Measurements;
                    model.players.Add(stringP);
                }

                List<Session> sessionList = new List<Session>();
                //create dropdown list
                sessionList = entities.Sessions.Where(x => x.Start >= DateTime.UtcNow).ToList();

                foreach (var item in sessionList)
                {
                    string str = item.Id + " " + item.Game.Title + " " + item.Start;
                    model.stringSessions.Add(str);
                }

            }
            return View(model);
        }
    }
}