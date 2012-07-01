using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KenoTrials.Keno.Tests
{
    [TestClass]
    public class GameTicketTests
    {
        [TestMethod]
        public void ValidTicket_MeetsMinimumRequirements()
        {
            var ticket = new GameTicket(1,1.00m,3,new[]{1,2,3},false);
            Assert.IsTrue(ticket.IsValid());
            Assert.AreEqual(string.Empty, ticket.InvalidTicketReasons);
        }

        [TestMethod]
        public void InValidTicket_NumbersBetMatchesNumbersPlayed()
        {
            try
            {
                var ticket = new GameTicket(1, 1.00m, 3, new[] { 1, 2, 3, 4 }, false);
                Assert.Fail("Exception not thrown");
            }
            catch (ArgumentException argumentException)
            {
                Assert.AreEqual("Numbers bet [3] do not match numbers played [4].",argumentException.Message);
            }
           
        }
    }
}
