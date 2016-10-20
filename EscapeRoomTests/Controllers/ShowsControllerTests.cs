using Microsoft.VisualStudio.TestTools.UnitTesting;
using EscapeRoom.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeRoom.Models;
using EscapeRoom.Controllers.Tests;
using System.Web.Mvc;

namespace EscapeRoom.Controllers.Tests
{
    [TestClass()]
    public class ShowsControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            //TODO: Fix test
            ShowsController c = new ShowsController();
            string showName = "The Last Defender";
            c.Index(showName);
           // Assert.AreEqual(showName, c.title   );
        }
    }
}