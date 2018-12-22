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

        }

        public readonly int Number;
        public readonly int Suit;
        public readonly int Name;
    }
}
