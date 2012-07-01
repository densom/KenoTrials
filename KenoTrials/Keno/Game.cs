using System.Collections.Generic;

namespace KenoTrials.Keno
{
    public class Game
    {
        public Game(long gameId)
        {
            GameId = gameId;
            RegisteredTickets = new List<GameTicket>();
            GameState = GameState.New;
        }

        public GameState GameState { get; set; }

        public long GameId { get; private set; }
        public List<GameTicket> RegisteredTickets { get; set; }

        public int[] NumbersDrawn { get; set; }


        public void RegisterTicket(GameTicket ticket)
        {
            RegisteredTickets.Add(ticket);
        }
    }
}