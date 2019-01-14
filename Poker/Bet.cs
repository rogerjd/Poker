using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class Bet
    {
        public readonly string Message;
        public readonly int Amount;
        public readonly int Credits;

        public Bet(int bet, int credits, int minBet, int maxBet)
        {
            if (credits < minBet)
            {
                Message = "You don't have enough credits to bet... Game Over!";
                Amount = 0;
                return;
            }

            if (bet < minBet)
            {
                Message = $"You must bet the minimum... betting {minBet}";
                Amount = minBet;
                Credits = Credits = Amount;
                return;
            }

            maxBet = credits < maxBet ? credits : maxBet;
            if (bet > maxBet)
            {
                Message = $"You can only bet {maxBet}... betting {maxBet}";
                Amount = maxBet;
                Credits = Credits - Amount;
                return;
            }

            Message = "";
            Amount = bet;
            Credits = Credits - bet;
        }
    }
}
