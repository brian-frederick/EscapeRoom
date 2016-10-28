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
        

        public ActionResult Payment(int? id)
        {
           
            CheckOut model = new CheckOut();

            using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
            {

                Basket b = entities.Baskets.Single(x => x.ID == id);
                
             
                model.numPlayers = b.Players.Count;
                model.session = new Models.Session
                {
                    Id = b.Session.Id,
                    Price = b.Session.Price,
                    Title = b.Session.Title,
                    Start = b.Session.Start
                };
                model.Players = b.Players.ToArray();

                if (User.Identity.IsAuthenticated)
                {
                    User u = entities.Users.Single(X => X.Email == User.Identity.Name);
                    model.FirstName = u.FirstName;
                    model.LastName = u.LastName;
                    model.Email = u.Email;
                }
            }


            return View(model);
        }

        [HttpPost]
        public ActionResult Payment(CheckOut model, int? id)
        {
            Basket b = new Basket();

            using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
            {
                //create basket
                b = entities.Baskets.Single(x => x.ID == id);

                //if logged in, update record and add basket
                if (User.Identity.IsAuthenticated)
                {
                    User user = entities.Users.Single(X => X.Email == User.Identity.Name);
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.Phone = model.Phone;
                    user.DateCreated = DateTime.UtcNow;
                    b.User = user;
                    entities.SaveChanges();
                }

                //if no login, create user and add basket
                else
                {
                    User user = new Models.User();
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.Phone = model.Phone;
                    user.DateCreated = DateTime.UtcNow;
                    b.User = user;
                    entities.SaveChanges();
                }

            }

            using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
            {
                b = entities.Baskets.Single(x => x.ID == id);
                model.numPlayers = b.Players.Count;
                model.session = new Models.Session
                {
                    Id = b.Session.Id,
                    Price = b.Session.Price,
                    Title = b.Session.Title,
                    Start = b.Session.Start
                };
                model.Players = b.Players.ToArray();
            }

            //configure braintree connection and take payment
            string clientID = ConfigurationManager.AppSettings["Braintree.ClientID"];
            string privateKey = ConfigurationManager.AppSettings["Braintree.PrivateKey"];
            string publicKey = ConfigurationManager.AppSettings["Braintree.PublicKey"];
            Braintree.IBraintreeGateway gateway = new Braintree.BraintreeGateway(Braintree.Environment.SANDBOX, clientID, publicKey, privateKey);
        
            Braintree.TransactionRequest request = new Braintree.TransactionRequest
            {
                Amount = model.session.Price * model.numPlayers,
                PaymentMethodNonce = "fake-valid-nonce",
                Customer = new Braintree.CustomerRequest
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email
                },
                BillingAddress = new Braintree.AddressRequest
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    StreetAddress = model.Address,
                    ExtendedAddress = model.Unit,
                    Locality = model.City,
                    Region = model.State,
                    PostalCode = model.Zip.ToString(),
                    CountryCodeAlpha2 = "US"
                },

                Options = new Braintree.TransactionOptionsRequest
                {
                    SubmitForSettlement = true,
                    StoreInVault = true
                },
            };

            

            Braintree.Result<Braintree.Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
                {

                    Basket completedBasket = entities.Baskets.Single(x => x.ID == id);
                    completedBasket.ReservedUntilDate = DateTime.UtcNow;
                    entities.SaveChanges();
                }

                    return RedirectToAction("Success", "Checkout", new { id = b.ID });
            }
            else
            {
                string errorMessages = "";
                foreach (Braintree.ValidationError error in result.Errors.DeepAll())
                {
                    errorMessages += "Error: " + (int)error.Code + " - " + error.Message + "\n";
                }
                TempData["Flash"] = errorMessages;

                return RedirectToAction("Payment", "Checkout", new { id = b.ID });
            }
        }
            

        public ActionResult Success(int id)
        {
            CheckOut model = new CheckOut();

            using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
            {
                Basket b = entities.Baskets.Single(x => x.ID == id);
                model.numPlayers = b.Players.Count;
                model.Players = new Player[model.numPlayers]; 
                model.session = new Models.Session
                {
                    Id = b.Session.Id,
                    Price = b.Session.Price,
                    Title = b.Session.Title,
                    Start = b.Session.Start
                };

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Success(CheckOut checkout, int id)
        {
            using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
            {

               List<int?> list = entities.sp_basketPlayers(id).ToList();

                int i = 0;

                foreach(int? item in list)
                {
                    var player = entities.Players.Single(x => x.Id == item);
                    player.FirstName = checkout.Players[i].FirstName;
                    player.LastName = checkout.Players[i].LastName;
                    player.Email = checkout.Players[i].Email;
                    entities.SaveChanges();
                    i++;
                }
                

            }
            return RedirectToAction("Index", "Home");
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

                model.Inventory = session.Baskets.Any() ? (session.Game.Capacity) - session.Baskets.Where(x => x.PurchaseDate.HasValue || x.ReservedUntilDate > DateTime.UtcNow).Sum(y => y.Players.Count()) : session.Game.Capacity;
                   
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
      
            int basketId = -1;
            try
            {
                using (EscapeRoomDBEntities entities = new EscapeRoomDBEntities())
                {
                    Basket basket = new Basket();

                    basket.SessionID = model.Id;
                    for (int i = 0; i < model.OrderQty; i++)
                    {
                        basket.Players.Add(new Player { });
                    }
                    basket.ReservedUntilDate = DateTime.UtcNow.AddMinutes(15);
                    entities.Baskets.Add(basket);
                    entities.SaveChanges();
                    
                    basketId = basket.ID;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Payment", "CheckOut", new { ID = basketId });
        }

        public ActionResult SoldOut()
        {
            return View();
        }

    }
}
