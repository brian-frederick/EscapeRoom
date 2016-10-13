using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EscapeRoom.Models
{
    public class AccountDetailsModel
    {
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(7)]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string Phone { get; set; }
    }
}