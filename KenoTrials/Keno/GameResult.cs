namespace KenoTrials.Keno
{
    public class GameResult
    {

        public GameResult(int[] numbersDrawn, bool isWinner, decimal payout, long gameId, int numNumbersBet, int[] numbersMatched)
        {
            NumbersDrawn = numbersDrawn;
            IsWinner = isWinner;
            Payout = payout;
            GameId = gameId;
            NumNumbersBet = numNumbersBet;
            NumbersMatched = numbersMatched;
        }

        public bool IsWinner { get; private set; }
        public decimal Payout { get; private set; }
        public long GameId { get; set; }
        public int NumNumbersBet { get; set; }
        public int[] NumbersMatched { get; set; }
        public int[] NumbersDrawn { get; set; }
    }
}