using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class ScoreTests
    {
        [TestMethod]
        public void ThreeOfAKind()
        {
            Hand h = new Hand("3C 3S 3H 4D JD");  
            Assert.AreEqual(h.Score, 4);
            Assert.AreEqual(h.Title, "Three Pair");
            Assert.AreEqual(h.Text, "3C 3S 3H 4D JD");
        }
    }
}
