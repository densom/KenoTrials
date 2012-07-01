using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KenoTrials.Keno.Tests
{
    [TestClass]
    public class GameManagerTests
    {
        [TestMethod]
        public void CalculatePayout()
        {
            // one spot tests
            Assert.AreEqual(2,GameManager.CalculatePayout(1, 1));
            
            // two spot tests
            Assert.AreEqual(0, GameManager.CalculatePayout(2, 1));

            Assert.AreEqual(11, GameManager.CalculatePayout(2,2));

            //three spot tests
            Assert.AreEqual(0, GameManager.CalculatePayout(3, 0));
            Assert.AreEqual(0, GameManager.CalculatePayout(3, 1));
            Assert.AreEqual(2, GameManager.CalculatePayout(3, 2));
            Assert.AreEqual(27, GameManager.CalculatePayout(3, 3));

            //four spot tests
            Assert.AreEqual(0, GameManager.CalculatePayout(4, 0));
            Assert.AreEqual(0, GameManager.CalculatePayout(4, 1));
            Assert.AreEqual(1, GameManager.CalculatePayout(4, 2));
            Assert.AreEqual(5, GameManager.CalculatePayout(4, 3));
            Assert.AreEqual(72, GameManager.CalculatePayout(4, 4));


            
        }
    }
}
