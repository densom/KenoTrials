using System;

namespace KenoTrials.Keno
{
    public class Player
    {
        public Player(string playerName)
        {
            Name = playerName;
            Id = Guid.NewGuid();
        }

        public string Name { get; set; }
        public Guid Id { get; private set; }
    }
}