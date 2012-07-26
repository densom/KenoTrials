using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KenoTrials.Keno;

namespace KenoTrials.WinForm
{
    public partial class Form1 : Form
    {
        private readonly GameManager _gameManager = new GameManager();
        private static readonly GameManager GameManager = new GameManager();
        private static readonly Player Player = new Player("Dennis");
        private static GameTicket _ticket;
        private int[] _numbersToPlay;
        private decimal _moneySpent;
        private GameResult _gameResult;

        public Form1()
        {
            InitializeComponent();
        }

        public void ClearBoard()
        {
            kenoBoard1.ResetBoard();
        }

        public void ShowPayout(decimal payout)
        {
            payoutLabel.Text = payout.ToString();
        }

        private GameReceipt RegisterTicket(IEnumerable<int> numbersToPlay)
        {
            return _gameManager.RegisterTickets(
                new GameTicket(1, 1, numbersToPlay.Count(), numbersToPlay.ToArray(), false), new Player("Dennis"));

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            ResetBoard();

            var numbersToPlay = numberToPlayTextBox.Text.Split(',').Select(x => int.Parse(x.Trim()));
            var receipt = RegisterTicket(numbersToPlay);

            MarkNumbersPlayed(receipt);

            foreach (var gameResult in _gameManager.Run())
            {
                foreach (var number in gameResult.NumbersDrawn)
                {
                    kenoBoard1.SelectNumber(number);
                }

                foreach (var matchingNumber in gameResult.NumbersMatched)
                {
                    kenoBoard1.MarkMatched(matchingNumber);
                }

                payoutLabel.Text = string.Format(gameResult.Payout.ToString());
            }

        }

        private void ResetBoard()
        {
            kenoBoard1.ResetBoard();
        }

        private void MarkNumbersPlayed(GameReceipt receipt)
        {
            foreach (var numPlayed in receipt.NumbersPlayed)
            {
                kenoBoard1.MarkPlayed(numPlayed);
            }
        }

        private void SetNumbersPlayed()
        {
            
        }


//        private void PostGameAction2(params GameResult[] gameResult)
//        {
//            
//        }

        private void PostGameAction()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(PostGameAction));
            }
            else
            {
                kenoBoard1.ResetBoard();
                _numbersToPlay.ToList().ForEach(kenoBoard1.MarkPlayed);
                _moneySpent -= _gameResult.Payout;
                payoutLabel.Text = _moneySpent.ToString();    
            }
            
        }

        private void PlayGames()
        {
            int iterations = 0;
            decimal moneySpent = 0;
            int numbersMatched = 0;
            GameResult gameResult = null;

            //            SetGameTicket(new[] { 17, 23, 36, 49, 3, 76, 54, 10, 8, 65 });
            
            SetGameTicket(_numbersToPlay);

            // play until all numbers are matched
            while (numbersMatched < _ticket.NumbersPlayed.Length)
            {
                iterations++;
                moneySpent += 1;
                _gameResult = Play();
                PostGameAction();

                //                numbersMatched = gameResult.NumbersMatched.Count();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _numbersToPlay = new[] { 17, 23, 36, 49, 3, };
//            Parallel.Invoke(PlayGames);


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
