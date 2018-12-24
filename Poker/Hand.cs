using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    using System;

    public class Hand
    {
        public Hand()
        {

        }

        public Hand(string handText)
        {

        }

        public Hand(string handText, string holdString)
        {

        }

        public Hand(Hand hand, string holdString)
        {

        }

        public int Score
        {
            get
            {
                if (score == 0)
                {
                    CalcScore();
                }
                return score;
            }
        }

        public string Title
        {
            get
            {
                return titles[Score];
            }
        }

        public string CardName(int cardNum)
        {
            return cards[cardNum - 1].Name;
        }

        public string Text
        {
            get
            {
                return CardName(1) + " " +
                       CardName(2) + " " +
                       CardName(3) + " " +
                       CardName(4) + " " +
                       CardName(5);
            }
        }

        public override string ToString()
        {
            return Text;
        }

        void CardsFromString(string handText)
        {

        }

        void HoldCards(string holdString)
        {
             
        }

        void Draw()
        {

        }

        bool ContainsCard(Card c, Card[] cs, int count)
        {
            return false;
        }

        void CalcScore()
        {
            throw new NotImplementedException();
        }

        Card[] cards = new Card[5];
        bool[] isHold = new bool[5];

        static string[] titles =
        {
            "No Score",
            "",
            "Jacks or Better",
            "Two Pair",
            "Three Pair",
            "Straight",
            "Flush",
            "Full House",
            "Four of a Kind",
            "Straigbt Flush",
            "Royal Flush"
        };

        int score = -1;
    }
}
