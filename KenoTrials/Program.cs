using System;
using System.Collections.Generic;
using System.Linq;
using KenoTrials.Keno;

namespace KenoTrials
{
    internal class Program
    {
        private static readonly GameManager GameManager = new GameManager();
        private static readonly Player Player = new Player("Dennis");
        private static GameTicket _ticket;

        private static void Main(string[] args)
        {
            int iterations = 0;
            decimal moneySpent = 0;
            int numbersMatched = 0;
            GameResult gameResult = null;

//            SetGameTicket(new[] { 17, 23, 36, 49, 3, 76, 54, 10, 8, 65 });
            SetGameTicket(new[] { 17, 23, 36, 49, 3, });

            // play until all numbers are matched
            while (numbersMatched < _ticket.NumbersPlayed.Length)
            {
                iterations++;
                moneySpent += 1;
                gameResult = Play();
                moneySpent -= gameResult.Payout;
                Console.WriteLine("Game {0}; Matched {1}; Payout {2}; Money Spent {3}", iterations, gameResult.NumbersMatched.Count(), gameResult.Payout, moneySpent);
                numbersMatched = gameResult.NumbersMatched.Count();
            }

            Console.WriteLine("Achieved {0} payout in {1} iterations.", gameResult.Payout, iterations);
            Console.WriteLine("Money Spent: {0}", moneySpent);
            Console.ReadLine();
        }

        private static void SetGameTicket(int[] ints)
        {
            _ticket = new GameTicket(1, 1, ints.Length, ints, false);
        }

        private static GameResult Play()
        {
            
            GameManager.RegisterTickets(_ticket, Player);
            var result = GameManager.Run();
            return result.First();
        }
    }
}