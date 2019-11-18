using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeChallenge_JS;
using CodeChallenge_JS.Controllers;
using System.Threading.Tasks;

namespace CodeChallenge_JS.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public async Task BotCall()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            var result = await controller.BotCall("aapl.us") as string;

            // Assert
            Assert.AreEqual("AAPL.US quote is 265.76 per share", result);
        }
    }
}
