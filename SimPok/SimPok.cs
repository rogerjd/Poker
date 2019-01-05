using Poker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimPok
{
    class SimPok
    {
        SimpleMachine machine;

        public static void Main(string[] args)
        {
            new SimPok();
        }

        SimPok()
        {
            Console.WriteLine("A simple poker game...");
            Console.WriteLine("Hit Ctrl-C at any time to abort.\n");
            machine = new SimpleMachine();
            while (true)
            {
                NextGame();
            }

            void NextGame()
            {
                Hand dealHand = machine.Deal();
                Console.WriteLine($"{dealHand.Text}");

                //invite player to hold cards
                Console.WriteLine("Enter card number (1 to 5) to hold");
                string holdCards = Console.ReadLine();

                //draw replacement cards
                Hand drawHand = machine.Draw(dealHand, holdCards);
                Console.WriteLine(drawHand.Text);
                Console.WriteLine(drawHand.Title);
                Console.WriteLine($"Score = {drawHand.Score}\n");

            }
        }
    }
}
