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

        [TestMethod]
        public void TwoPair()
        {
            Hand h = new Hand("3C 3S 4H 4D JD");
            Assert.AreEqual(h.Score, 3);
            Assert.AreEqual(h.Title, "Two Pair");
            Assert.AreEqual(h.Text, "3C 3S 4H 4D JD");

            h = new Hand("3C 3S 5H 4D 4S");
            Assert.AreEqual(h.Score, 3);
            Assert.AreEqual(h.Title, "Two Pair");
            Assert.AreEqual(h.Text, "3C 3S 5H 4D 4S");

            h = new Hand("2C 3S 3H 4D 4S");
            Assert.AreEqual(h.Score, 3);
            Assert.AreEqual(h.Title, "Two Pair");
            Assert.AreEqual(h.Text, "2C 3S 3H 4D 4S");
        }

        [TestMethod]
        public void JacksOrBetter()
        {
            Hand h = new Hand("JH JD 2H 6C KS");
            Assert.AreEqual(h.Score, 2);
            Assert.AreEqual(h.Title, "Jacks or Better");
            Assert.AreEqual(h.Text, "JH JD 2H 6C KS");
        }

        [TestMethod]
        public void NoScore()
        {
            Hand h = new Hand("JH TD 2H 6C KS");
            Assert.AreEqual(h.Score, 0);
            Assert.AreEqual(h.Title, "No Score");
            Assert.AreEqual(h.Text, "JH TD 2H 6C KS");
        }
    }
}
