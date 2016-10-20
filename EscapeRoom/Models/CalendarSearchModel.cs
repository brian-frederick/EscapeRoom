using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EscapeRoom.Models
{
    public class CalendarSearchModel
    {
 
        public string game { get; set; }
        public IEnumerable<string> games { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int minInventory { get; set; }
    }
}