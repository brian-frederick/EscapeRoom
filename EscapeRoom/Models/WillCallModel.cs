using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EscapeRoom.Models
{
    public class WillCallModel
    {
        public List<Session> sessions { get; set; }
        public Session selection { get; set; }
        public User user { get; set; }
        public List<Player> players { get; set; }
    }
}