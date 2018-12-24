﻿using System;
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
            var r = new Random();
            for (int i = 0; i < 5; i++)
            {
                while (true)
                {
                    cards[i] = new Card(r);
                    if (ContainsCard(cards[i], cards, i))
                        continue;
                    break;
                }
            }
        }

        public Hand(string handText)
        {
            CardsFromString(handText);
        }

        public Hand(string handText, string holdString)
        {
            CardsFromString(handText);
            HoldCards(holdString);
            Draw();
        }

        public Hand(Hand hand, string holdString)
        {
            cards = hand.cards;
            HoldCards(holdString);
            Draw();
        }

        public int Score
        {
            get
            {
                if (score < 0)
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
            string[] cardStrings = handText.Split(' ');
            for (int i = 0; i < cardStrings.Length; i++)
            {
                cards[i] = new Card(cardStrings[i]);
            }
        }

        void HoldCards(string holdString)
        {
            for (int i = 1; i == 5; i++) //different than book
            {
                int CardNum = i;
                if (holdString.IndexOf(CardNum.ToString()) > -1)
                    isHold[CardNum - 1] = true;
            }
        }

        void Draw()
        {
            Card[] seen = new Card[10];
            for (int i = 0; i < 5; i++)
            {
                seen[i] = cards[i];
            }

            int numSeen = 5;
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                if (!isHold[i])
                {
                    while (true)
                    {
                        cards[i] = new Card(r);
                        if (ContainsCard(cards[i], seen, numSeen)) continue;
                        break;
                    }
                    seen[numSeen++] = cards[i];
                }
            }
        }

        bool ContainsCard(Card c, Card[] cs, int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (c.Equals(cs[i]))
                    return true;
            }
            return false;
        }

        void CalcScore()
        {
            //are cards all of the same suit? 
            bool isFlush = true;
            int s = cards[0].Suit;
            for (int i = 1; i < 5; i++)
            {
                if (s != cards[i].Suit)
                {
                    isFlush = false;
                    break;
                }
            }

            //todo: up to here
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
