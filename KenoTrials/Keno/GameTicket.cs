using System;
using System.Collections.Generic;

namespace KenoTrials.Keno
{
    public class GameTicket
    {
        public GameTicket(int numberOfGamesToPlay, decimal betAmountPerDraw, int numbersToBetPerGame,
                          int[] numbersPlayed, bool betKicker)
        {
            NumberOfGamesToPlay = numberOfGamesToPlay;
            BetAmountPerDraw = betAmountPerDraw;
            NumbersToBetPerGame = numbersToBetPerGame;
            NumbersPlayed = numbersPlayed;
            BetKicker = betKicker;

            ValidateTicket();
        }

        public int NumberOfGamesToPlay { get; private set; }
        public decimal BetAmountPerDraw { get; private set; }
        public int NumbersToBetPerGame { get; private set; }
        public int[] NumbersPlayed { get; private set; }
        public bool BetKicker { get; private set; }
        public string InvalidTicketReasons { get; private set; }

        private void ValidateTicket()
        {
            if (!IsValid())
            {
                throw new ArgumentException(InvalidTicketReasons);
            }
        }

        public bool IsValid()
        {
            var invalidTicketReasons = new List<string>();

            // Validation

            if (NumbersToBetPerGame < 3)
            {
                invalidTicketReasons.Add("Must bet a minimum of 3 games.");
            }


            if (NumbersToBetPerGame != NumbersPlayed.Length)
            {
                invalidTicketReasons.Add(string.Format("Numbers bet [{0}] do not match numbers played [{1}].",
                                                       NumbersToBetPerGame, NumbersPlayed.Length));
            }


            // determine if errors occurred
            if (invalidTicketReasons.Count == 0)
            {
                InvalidTicketReasons = string.Empty;
                return true;
            }

            InvalidTicketReasons = string.Concat(invalidTicketReasons);
            return false;
        }
    }
}