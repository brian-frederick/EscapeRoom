using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace EscapeRoom.Models
{
    public class CheckOut
    {
        public string FirstName { get; set; }
        public string LastName { get; set;}
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public int? Zip { get; set; }
        public string State { get; set; }
        public string CreditCard { get; set; }
        public DateTime? Expiration { get; set;}
        public int? SecCode { get; set; }
        public int numPlayers { get; set; }
        public Player[] Players { get; set; }
        public Session session { get; set; }
        public Session sessionID { get; set; }
    }
}