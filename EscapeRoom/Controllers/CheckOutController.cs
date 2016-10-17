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
                Braintree.TransactionRequest request2 = new Braintree.TransactionRequest()
                {
                    Amount = model.subtotal,
                    CustomerID = "", //TODO: Get the Ids form the first request
                    BillingAddressID = "",
                    PaymentMethodToken = ""
                };
                gateway.Customer.Create(request);
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