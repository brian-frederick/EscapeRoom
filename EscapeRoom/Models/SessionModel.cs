using System;

namespace EscapeRoom.Models
{
    internal class SessionModel
    {
        public string Color { get; set; }
        public int Id { get; set; }
        public int Inventory { get; set; }
        public decimal Price { get; set; }
        public bool SoldOut { get; set; }
        public DateTime Start { get; set; }
        public string Title { get; set; }
    }
}