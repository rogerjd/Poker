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
        private int score;

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

        private void CalcScore()
        {
            throw new NotImplementedException();
        }

        static string[] titles = { };
    }
}
