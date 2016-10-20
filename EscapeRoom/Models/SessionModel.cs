using System;
using System.Collections.Generic;

namespace EscapeRoom.Models
{
    public class SessionModel
    {
        public string Color { get; set; }
        public int Id { get; set; }
        public int OrderQty { get; set; }
        public int Inventory { get; set; }
        public List<int> InventoryList { get; set; }
        public decimal Price { get; set; }
        public bool SoldOut { get; set; }
        public string Url { get; set; }
        public DateTime Start { get; set; }
        public string Title { get; set; }
    }
}