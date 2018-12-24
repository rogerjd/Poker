using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    internal class Card
    {
        public Card() : this(new Random()) { }

        public Card(Random random)
        {
            Number = random.Next(2, 15);
            Suit = random.Next(1, 5);
            Name = numberArray[Number - 2] + suitArray[Suit - 1];
        }

        public Card(string name)
        {
            string n = name.Substring(0, 1);
            string s = name.Substring(1, 1);
            Number = numberString.IndexOf(n) + 2;
            Suit = suitString.IndexOf(s) + 1;
            Name = name;
        }

        public override string ToString() 
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            if (obj is Card c)
            {
                return (c.Number == Number) && (c.Suit == Suit);  //name?
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return (Suit << 4) + Number;
        }

        public readonly int Number;
        public readonly int Suit;
        public readonly string Name;

        private static string[] numberArray = {"2", "3", "4", "5", "6", "7", "8", "9", "T",
            "J", "Q", "K", "A"};
        private static string[] suitArray = {"C", "D", "H", "S" };
        private static string numberString = "23456789TJQKA";
        private static string suitString = "CDHS";
    }
}
