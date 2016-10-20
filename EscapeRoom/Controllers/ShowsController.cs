using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EscapeRoom.Models;

namespace EscapeRoom.Controllers
{
    public class ShowsController : Controller
    {
        // GET: Shows
        public ActionResult Index(string showName)
        {
            //TODO: Get Parameter from url
            

            using (EscapeRoomDBEntities entity = new Models.EscapeRoomDBEntities())
            {
                
                Game model = entity.Games.Single(x => x.Title == showName);

                return View(model);

            }

          
        }
    }
}
//TODO: Add Session Controller Scaffolding

//List<ProductModel> list = new List<ProductModel>();
//list.Add(new ProductModel() { title = "The Last Defender", start = new DateTime(2016, 10, 15, 7, 30, 0), Price = 40, id = 007 });
//            list.Add(new ProductModel() { title = "Nova to Lodestar", start = new DateTime(2016, 10, 15, 7, 30, 0), Price = 50, id = 007 });
//            list.Add(new ProductModel() { title = "The Last Defender", start = new DateTime(2016, 10, 16, 7, 30, 0), Price = 40, id = 007 });
//            list.Add(new ProductModel() { title = "Nova to Lodestar", start = new DateTime(2016, 10, 16, 7, 30, 0), Price = 50, id = 007 });
//            return View(list);