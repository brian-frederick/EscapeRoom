using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EscapeRoom.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        public ActionResult Index()
        {
            ViewBag.Message = "This is what it is about.";
            return View();
        }

        //POST: CheckOut
        [HttpPost]
        public ActionResult Index(Models.CheckOut model)
        {
            //TO DO: Add Product to cart in Database!
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Reciept");
            }

            else
            {
                
                return View(model);
            }            
        }

        public ActionResult About()
        {
            

            return View();
        }
    }
}