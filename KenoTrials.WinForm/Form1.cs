using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KenoTrials.Keno;

namespace KenoTrials.WinForm
{
    public partial class Form1 : Form
    {
        private readonly GameManager _gameManager = new GameManager();

        public Form1()
        {
            InitializeComponent();
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
    }
}
