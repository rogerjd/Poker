﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class SimpleMachine
    {
        public Hand Deal()
        {
            return new Hand();
        }

        public Hand Draw(Hand oldHand, string holdCards)
        {
            return new Hand(oldHand, holdCards);
        }

        public Hand Draw(string oldHand, string holdCards)
        {
            return new Hand(oldHand, holdCards);
        }
    }
}
