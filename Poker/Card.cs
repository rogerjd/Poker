using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Card
    {
        public Card() : this(new Random()) { }

        public Card(Random random)
        {
            Number = random.Next(2, 15);
            Suit = random.Next(1, 5);
            Name = numberArray[Number - 2] + suitArray[Suit - 1];
        }

        public readonly int Number;
        public readonly int Suit;
        public readonly string Name;

        private static string[] numberArray = { };
        private static string[] suitArray = { };
        private static string numberString = "";
        private static string suitString = "";
    }
}
