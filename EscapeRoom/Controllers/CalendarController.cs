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
            List<ProductModel> list = new List<ProductModel>();
            list.Add(new ProductModel() { title = "The Last Defender", start = new DateTime(2016, 10, 15, 7, 30, 0), Price = 40, id = 007, url= "http://localhost:51941/CheckOut/Index", inventory = 10 });
            list.Add(new ProductModel() { title = "Nova to Lodestar", start = new DateTime(2016, 10, 15, 7, 30, 0), Price = 50, id = 008, url = "http://localhost:51941/CheckOut/Index", inventory = 7 });
            list.Add(new ProductModel() { title = "The Last Defender", start = new DateTime(2016, 10, 16, 7, 30, 0), Price = 40, id = 009, url = "http://localhost:51941/CheckOut/Index", inventory = 3 });
            list.Add(new ProductModel() { title = "Nova to Lodestar", start = new DateTime(2016, 10, 16, 7, 30, 0), Price = 50, id = 010, url = "http://localhost:51941/CheckOut/Index", inventory = 9 });

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}