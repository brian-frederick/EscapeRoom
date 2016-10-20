using EscapeRoom.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            
            CheckOut model = new CheckOut();
            int availableSpots = 0;
            using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
            {
                
            }

            model.Players = new Player[availableSpots];
            for (int i = 0; i < availableSpots; i++)
            {
                model.Players[i] = new Player();
            }
            return View(model);
        }

        //POST: CheckOut
        [HttpPost]
        public ActionResult Index(SessionModel model)
        {
            //TO DO: Add Product to cart in Database!
            /*if (ModelState.IsValid)
            {
                using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
                {
                    var basket = entities.Baskets.Single(x => x.ID == 1); //TODO: this is not correct!
                    foreach (var player in model.Players.Where(x => !string.IsNullOrEmpty(x.Email)))
                    {
                        basket.Players.Add(player);
                    }
                    entities.SaveChanges();
                    //basket.Players.Add(new Player {  })
                }
                    return RedirectToAction("Index", "Reciept");
                string clientID = ConfigurationManager.AppSettings["Braintree.ClientID"];
                string privateKey = ConfigurationManager.AppSettings["Braintree.PrivateKey"];
                string publicKey = ConfigurationManager.AppSettings["Braintree.PublicKey"];
                Braintree.IBraintreeGateway gateway = new Braintree.BraintreeGateway(Braintree.Environment.SANDBOX, clientID, privateKey, publicKey);
                Braintree.CustomerRequest request = new Braintree.CustomerRequest
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    CreditCard = new Braintree.CreditCardRequest
                    {
                        BillingAddress = new Braintree.CreditCardAddressRequest
                        {
                            StreetAddress = model.Address,
                            ExtendedAddress = model.Unit,
                            PostalCode = model.Zip.ToString(),
                            Locality = model.City,
                            FirstName = model.FirstName,
                            LastName = model.LastName,

                        },
                        CardholderName = model.FirstName + " " + model.LastName,
                        //TODO: ExpirationMonth = (model.Expiration )
                        CVV = model.SecCode.ToString(),
                        Number = model.CreditCard
                    }
                };

                var result = gateway.Customer.Create(request);
                //Braintree.TransactionRequest request2 = new Braintree.TransactionRequest()
                //{
                //    Amount = model.subtotal,
                //    CustomerID = "", //TODO: Get the Ids form the first request
                //    BillingAddressID = "",
                //    PaymentMethodToken = ""
                //};
                gateway.Customer.Create(request);
                return RedirectToAction("Index", "Reciept");
            }

            else
            {
                
                return View(model);
            } */
            return View(model);
        }

        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Selection(int id)
        {
            using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
            {

                Session session = entities.Sessions.Single(x => x.Id == id);
                SessionModel model = new SessionModel
                {
                    Id = session.Id,
                    Color = session.Color,
                    InventoryList = new List<int>(),
                    Price = session.Price,
                    Start = session.Start,
                    Title = session.Title
                };

                model.Inventory = session.Game.Capacity - session.Baskets.Sum(x => x.Players.Count());

                for (int i = 1; i <= model.Inventory; i++)
                    {
                    model.InventoryList.Add(i);
                    }

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Selection(SessionModel model)
        {
            return RedirectToAction("Index", "CheckOut", model);
        }

    }
}