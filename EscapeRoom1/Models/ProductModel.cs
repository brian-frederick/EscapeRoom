using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EscapeRoom.Models
{
    public class ProductModel
    {
        public string title { get; set; }
        public int id { get; set; }
        public bool allDay { get; set; }
        public DateTime? start { get; set; }
        public string url { get; set; }
        public int inventory { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
    }
}