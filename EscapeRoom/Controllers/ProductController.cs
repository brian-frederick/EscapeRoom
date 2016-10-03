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
            if (id == 1)
            {
                return View(new Models.ProductModel { title = "The Last Defender", id = 001, start = new DateTime(2016, 10, 18, 19, 30, 0), Price = 40m });
            }
            else if (id == 2)
            {
                return View(new Models.ProductModel { title = "The Last Defender", id = 002, start = new DateTime(2016, 10, 19, 21, 30, 0), Price = 40m });
            }

            else
            {
                return HttpNotFound("object not found");
            }           
        }
        //POST: Product
        [HttpPost]
        public ActionResult Index(Models.ProductModel model)
        {
            //TO DO: Add Product to cart in Database!
            return RedirectToAction("Home", "Index");
        }
        
    }
}