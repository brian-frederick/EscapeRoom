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
        public ActionResult Index(string showName)
        {
            using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
            {
                CalendarSearchModel model = new CalendarSearchModel
                {
                    game = HttpUtility.UrlDecode(showName),
                    games = entities.Games.Select(x => x.Title).ToArray()
                };

                return View(model);
            }
        }

        public ActionResult Data(string showName, string minInventory)
        {
            List<SessionModel> list = null;
            int minInventoryNum = Convert.ToInt32(minInventory);

            using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
            {
                
                if (!string.IsNullOrEmpty(showName) && !string.IsNullOrEmpty(minInventory))
                {
                    list = entities.Sessions.Where(x => x.Title == showName && (x.Baskets.Any() ? (x.Game.Capacity) - x.Baskets.Sum(y => y.Players.Count()) : x.Game.Capacity) >= minInventoryNum).Select(x => new SessionModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Color = x.Color,
                        Start = x.Start,
                        Url = "Checkout/Selection/" + x.Id,
                        Inventory = x.Baskets.Any() ? (x.Game.Capacity) - x.Baskets.Sum(y => y.Players.Count()) : x.Game.Capacity
                    }).ToList();

                }
                else if(!string.IsNullOrEmpty(showName) && !string.IsNullOrEmpty(minInventory))
                {
                    list = entities.Sessions.Select(x => new SessionModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Color = x.Color,
                        Start = x.Start,
                        Inventory = x.Baskets.Any() ? (x.Game.Capacity) - x.Baskets.Sum(y => y.Players.Count()) : x.Game.Capacity,
                        Url = "Checkout/Selection/" + x.Id
                    }).ToList();
                }

                //shorten titles by getting first initials
                foreach(var item in list)
                {
                    char[] array = item.Title.ToCharArray();
                    List<char> charList = new List<char>();
                    charList.Add(array[0]);

                    for (var i = 1; i < array.Length; i++)
                    {
                        if (array[i - 1] == ' ')
                            charList.Add(array[i]);
                    }

                    item.Title = new string(charList.ToArray());
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

