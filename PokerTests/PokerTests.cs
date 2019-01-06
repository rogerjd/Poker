using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace PokerTests
{
    [TestClass]
    public class ScoreTests
    {
        //royal flush
        [TestMethod]
        public void RoyalFlush()
        {

        }

        //straight flush
        [TestMethod]
        public void StraightFlush()
        {

        }

        [TestMethod]
        public void FourOfAKind()
        {
            Hand h = new Hand("3C 3H 3D 3S 5D");
            Assert.AreEqual(h.Score, 8);
            Assert.AreEqual(h.Title, "Four of a Kind");
            Assert.AreEqual(h.Text, "3C 3H 3D 3S 5D");

            h = new Hand("7D 8C 8D 8H 8S");
            Assert.AreEqual(h.Score, 8);
            Assert.AreEqual(h.Title, "Four of a Kind");
            Assert.AreEqual(h.Text, "7D 8C 8D 8H 8S");
        }

        [TestMethod]
        public void FullHouse()
        {
            Hand h = new Hand("3C 3H 3D 5C 5D");
            Assert.AreEqual(h.Score, 7);
            Assert.AreEqual(h.Title, "Full House");
            Assert.AreEqual(h.Text, "3C 3H 3D 5C 5D");

            h = new Hand("7D 7C TC TD TH");
            Assert.AreEqual(h.Score, 7);
            Assert.AreEqual(h.Title, "Full House");
            Assert.AreEqual(h.Text, "7D 7C TC TD TH");
        }

        [TestMethod]
        public void Flush()
        {
            Hand h = new Hand("3C 5C 8C TC KC");
            Assert.AreEqual(h.Score, 6);
            Assert.AreEqual(h.Title, "Flush");
            Assert.AreEqual(h.Text, "3C 5C 8C TC KC");
        }

        [TestMethod]
        public void Straignt()
        {
            Hand h = new Hand("3C 4S 5H 6D 7D");
            Assert.AreEqual(h.Score, 5);
            Assert.AreEqual(h.Title, "Straight");
            Assert.AreEqual(h.Text, "3C 4S 5H 6D 7D");
        }

        [TestMethod]
        public void ThreeOfAKind()
        {
            Hand h = new Hand("3C 3S 3H 4D JD");
            Assert.AreEqual(h.Score, 4);
            Assert.AreEqual(h.Title, "Three Pair");
            Assert.AreEqual(h.Text, "3C 3S 3H 4D JD");

            h = new Hand("4C 3S 3H 3D JD");
            Assert.AreEqual(h.Score, 4);
            Assert.AreEqual(h.Title, "Three Pair");
            Assert.AreEqual(h.Text, "4C 3S 3H 3D JD");

            h = new Hand("2C 5S 3H 3D 3S");
            Assert.AreEqual(h.Score, 4);
            Assert.AreEqual(h.Title, "Three Pair");
            Assert.AreEqual(h.Text, "2C 5S 3H 3D 3S");
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
