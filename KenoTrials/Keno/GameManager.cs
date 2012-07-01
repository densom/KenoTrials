using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace KenoTrials.Keno
{
    public class GameManager
    {
        private const int MaxGames = 20;
        private static long _nextAvailableGameId = 1;
        private readonly Queue<Game> _availableGames = new Queue<Game>(MaxGames);
        private readonly List<Game> _completedGames = new List<Game>();
        private readonly List<Game> _registeredGames = new List<Game>();
        private static readonly Random RandomPicker = new Random();
        private static List<SpotPayout> _payoutTable;

        private Game _currentGame;

        public GameManager()
        {
            Initialize();
        }

        public ReadOnlyCollection<Game> CompletedGames
        {
            get { return _completedGames.AsReadOnly(); }
        }

        /// <summary>
        /// Enqueues new game essions, up to the max defined
        /// </summary>
        public void RefreshAvailableGames()
        {
            for (int i = 0; i < MaxGames; i++)
            {
                _availableGames.Enqueue(new Game(_nextAvailableGameId++));
            }
        }

        private void Initialize()
        {
            RefreshAvailableGames();
            InitializePayoutTable();
        }

        //expensive function...redo
        public GameReceipt RegisterTickets(GameTicket ticket, Player player)
        {
            var receipt = new GameReceipt
                              {
                                  NumbersPlayed = ticket.NumbersPlayed,
                                  BetAmountPerDraw = ticket.BetAmountPerDraw,
                                  BetKicker = ticket.BetKicker
                              };

            for (int i = 0; i < ticket.NumberOfGamesToPlay; i++)
            {
                Game[] availableGamesArray = _availableGames.ToArray();
                Game game = availableGamesArray[i];
                game.RegisterTicket(ticket);
                _registeredGames.Add(game);
                receipt.GameIds.Add(game.GameId);
            }

            return receipt;
        }

        public IEnumerable<GameResult> Run()
        {
            while (_availableGames.Peek().RegisteredTickets.Count > 0)
            {
                _currentGame = _availableGames.Dequeue();
                _currentGame.GameState = GameState.Active;
                _currentGame.NumbersDrawn = DrawNumbers();
                _currentGame.GameState = GameState.Complete;
                IEnumerable<GameResult> gameResults = ProcessResults(_currentGame);
                _currentGame = null;
                RefreshAvailableGames();
                foreach (GameResult gameResult in gameResults)
                {
                    yield return gameResult;
                }
            }
        }

        private IEnumerable<GameResult> ProcessResults(Game currentGame)
        {
            var results = new List<GameResult>();

            foreach (GameTicket registeredTicket in currentGame.RegisteredTickets)
            {
                decimal amount = CalculatePayout(registeredTicket, currentGame);
                results.Add(new GameResult(currentGame.NumbersDrawn, amount > 0, amount, currentGame.GameId, registeredTicket.NumbersToBetPerGame, NumbersMatched(registeredTicket.NumbersPlayed, currentGame.NumbersDrawn).ToArray()));
            }
            _completedGames.Add(currentGame);
            return results.AsReadOnly();
        }

        private static decimal CalculatePayout(GameTicket ticket, Game game)
        {
            var amount = CalculatePayout(ticket.NumbersToBetPerGame, NumberOfMatches(ticket.NumbersPlayed, game.NumbersDrawn));
            if (ticket.BetKicker)
            {
                amount *= 2;
            }

            return amount;
        }

        private static int NumberOfMatches(IEnumerable<int> numbersPlayed, IEnumerable<int> numbersDrawn)
        {
//            return numbersPlayed.Count(numPlayed => numbersDrawn.Contains(numPlayed));
            return NumbersMatched(numbersPlayed, numbersDrawn).Count();
        }

        private static IEnumerable<int> NumbersMatched(IEnumerable<int> numbersPlayed, IEnumerable<int> numbersDrawn)
        {
            return numbersPlayed.Intersect(numbersDrawn).ToArray();
        }

        public struct SpotPayout
        {
            public int Spots;
            public List<Payout> Payouts;


        }

        public struct Payout
        {
            public int Match;
            public decimal PayoutAmount;
        }

        public static decimal CalculatePayout(int numNumbersPlayed, int numberMatches)
        {
            var payoutTable = GetPayoutTable();

            var payoutRecord = (from x in payoutTable where x.Spots == numNumbersPlayed select x.Payouts).FirstOrDefault();
            
            return (from x in payoutRecord where x.Match == numberMatches select x.PayoutAmount).DefaultIfEmpty(0).FirstOrDefault();
        }

        public static void InitializePayoutTable()
        {
            _payoutTable = new List<SpotPayout>
                                  {
                                      new SpotPayout
                                          {
                                              Spots = 1,
                                              Payouts = new List<Payout>() {new Payout
                                                                                {
                                                                                    Match = 1, PayoutAmount = 2
                                                                                },
                                              }
                                          },
                                          new SpotPayout
                                          {
                                              Spots = 2,
                                              Payouts = new List<Payout>() {new Payout
                                                                                {
                                                                                    Match = 2, PayoutAmount = 11
                                                                                },
                                              }
                                          },
                                          new SpotPayout
                                          {
                                              Spots = 3,
                                              Payouts = new List<Payout>() {new Payout
                                                                                {
                                                                                    Match = 2, PayoutAmount = 2
                                                                                },
                                                                            new Payout()
                                                                                {
                                                                                    Match = 3, PayoutAmount = 27
                                                                                },
                                              }
                                          },
                                           new SpotPayout
                                          {
                                              Spots = 4,
                                              Payouts = new List<Payout>() {new Payout
                                                                                {
                                                                                    Match = 2, PayoutAmount = 1
                                                                                },
                                                                            new Payout()
                                                                                {
                                                                                    Match = 3, PayoutAmount = 5
                                                                                },
                                                                            new Payout()
                                                                            {
                                                                                Match = 4, PayoutAmount = 72
                                                                            },
                                              }
                                          },
                                           new SpotPayout
                                          {
                                              Spots = 5,
                                              Payouts = new List<Payout>() {new Payout
                                                                                {
                                                                                    Match = 3, PayoutAmount = 2
                                                                                },
                                                                            new Payout()
                                                                                {
                                                                                    Match = 4, PayoutAmount = 18
                                                                                },
                                                                            new Payout()
                                                                            {
                                                                                Match = 5, PayoutAmount = 410
                                                                            },

                                              }

                                          },
                                          new SpotPayout
                                          {
                                              Spots = 6,
                                              Payouts = new List<Payout>() {new Payout
                                                                                {
                                                                                    Match = 3, PayoutAmount = 1
                                                                                },
                                                                            new Payout()
                                                                                {
                                                                                    Match = 4, PayoutAmount = 7
                                                                                },
                                                                            new Payout()
                                                                            {
                                                                                Match = 5, PayoutAmount = 57
                                                                            },
                                                                            new Payout()
                                                                            {
                                                                                Match = 6, PayoutAmount = 1100
                                                                            },

                                              }

                                          },
                                          new SpotPayout
                                          {
                                              Spots = 7,
                                              Payouts = new List<Payout>() {new Payout
                                                                                {
                                                                                    Match = 3, PayoutAmount = 1
                                                                                },
                                                                            new Payout()
                                                                                {
                                                                                    Match = 4, PayoutAmount = 5
                                                                                },
                                                                            new Payout()
                                                                            {
                                                                                Match = 5, PayoutAmount = 11
                                                                            },
                                                                            new Payout()
                                                                            {
                                                                                Match = 6, PayoutAmount = 100
                                                                            },
                                                                            new Payout()
                                                                            {
                                                                                Match = 7, PayoutAmount = 2000
                                                                            },

                                              }


                                          },
                                          new SpotPayout
                                          {
                                              Spots = 8,
                                              Payouts = new List<Payout>() {new Payout
                                                                                {
                                                                                    Match = 4, PayoutAmount = 2
                                                                                },
                                                                            new Payout()
                                                                                {
                                                                                    Match = 5, PayoutAmount = 15
                                                                                },
                                                                            new Payout()
                                                                            {
                                                                                Match = 6, PayoutAmount = 50
                                                                            },
                                                                            new Payout()
                                                                            {
                                                                                Match = 7, PayoutAmount = 300
                                                                            },
                                                                            new Payout()
                                                                            {
                                                                                Match = 8, PayoutAmount = 10000
                                                                            },

                                              }

                                          },
                                          new SpotPayout
                                          {
                                              Spots = 9,
                                              Payouts = new List<Payout>() {new Payout
                                                                                {
                                                                                    Match = 4, PayoutAmount = 2
                                                                                },
                                                                            new Payout()
                                                                                {
                                                                                    Match = 5, PayoutAmount = 5
                                                                                },
                                                                            new Payout()
                                                                            {
                                                                                Match = 6, PayoutAmount = 20
                                                                            },
                                                                            new Payout()
                                                                            {
                                                                                Match = 7, PayoutAmount = 100
                                                                            },
                                                                            new Payout()
                                                                            {
                                                                                Match = 8, PayoutAmount = 2000
                                                                            },
                                                                            new Payout()
                                                                            {
                                                                                Match = 9, PayoutAmount = 25000
                                                                            },

                                              }


                                          },
                                          new SpotPayout
                                          {
                                              Spots = 10,
                                              Payouts = new List<Payout>() {new Payout
                                                                                {
                                                                                    Match = 0, PayoutAmount = 5
                                                                                },
                                                                            new Payout()
                                                                                {
                                                                                    Match = 5, PayoutAmount = 2
                                                                                },
                                                                            new Payout()
                                                                            {
                                                                                Match = 6, PayoutAmount = 10
                                                                            },
                                                                            new Payout()
                                                                            {
                                                                                Match = 7, PayoutAmount = 50
                                                                            },
                                                                            new Payout()
                                                                            {
                                                                                Match = 8, PayoutAmount = 500
                                                                            },
                                                                            new Payout()
                                                                            {
                                                                                Match = 9, PayoutAmount = 5000
                                                                            },
                                                                            new Payout()
                                                                            {
                                                                                Match = 10, PayoutAmount = 100000
                                                                            },

                                              }


                                          },


                                  };

        }

        // came from  http://www.ohiolottery.com/Games/Keno/KENO-Odds-Payouts.aspx
        public  static List<SpotPayout> GetPayoutTable()
        {
            return _payoutTable;   
        }

        //todo:  Make this a strategy
        private static int[] DrawNumbers()
        {
            const int numberToDraw = 20;

            var numbersDrawn = new List<int>();
            List<int> numberPool = BuildNumberPool();

            for (int i = 0; i < numberToDraw; i++)
            {
                numbersDrawn.Add(RandomPickNumber(numberPool));
            }


            return numbersDrawn.ToArray();
        }

        private static int RandomPickNumber(List<int> numberPool)
        {
            int selectedIndex = RandomPicker.Next(0, numberPool.Count);
            int selectedNumber = numberPool[selectedIndex];
            numberPool.RemoveAt(selectedIndex);
            return selectedNumber;
        }

        private static List<int> BuildNumberPool()
        {
            var numberPool = new List<int>();

            for (int i = 1; i <= 80; i++)
            {
                numberPool.Add(i);
            }

            return numberPool;
        }
    }
}