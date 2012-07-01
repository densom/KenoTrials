using System.Collections.Generic;

namespace KenoTrials.Keno
{
    public class GameReceipt
    {
        public GameReceipt()
        {
            GameIds = new List<long>();
        }

        public int[] NumbersPlayed { get; set; }

        public decimal BetAmountPerDraw { get; set; }

        public bool BetKicker { get; set; }

        public List<long> GameIds { get; set; }
    }
}