using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EscapeRoom.Models
{
    public class WillCallModel
    {
        public List<String> stringSessions { get; set; }
        public String selection { get; set; }
        public Session session { get; set; }
        public User user { get; set; }
        public List<string> players { get; set; }
    }
}