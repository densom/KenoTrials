using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KenoTrials.WinForm
{
    public partial class KenoBoard : UserControl
    {
        public KenoBoard()
        {
            InitializeComponent();
            InitializeBoard();

        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 80; i++)
            {
                var position = ResolvePosition(i + 1);
                var result = tableLayoutPanel1.GetControlFromPosition(position[1], position[0]) as KenoNumber;
                result.SetNumber(i + 1);
            }

        }

        public void SelectNumber(int number)
        {
            var position = ResolvePosition(number);
            var row = position[0];
            var column = position[1];

            var result = tableLayoutPanel1.GetControlFromPosition(column, row) as KenoNumber;
            result.MarkSelected();
        }

        public void MarkPlayed(int number)
        {
            GetKenoNumber(number).MarkPlayed();
        }

        private KenoNumber GetKenoNumber(int number)
        {
            return (from x in AllKenoNumbers() where x.Number == number select x).First();
        }

        public int[] ResolvePosition(int number)
        {
            // subtract 1 from the number, then first digit is row, second digit is column
            var stringNumber = (number - 1).ToString().PadLeft(2, '0');
            return new[] { int.Parse(stringNumber.ToCharArray()[0].ToString()), int.Parse(stringNumber.ToCharArray()[1].ToString()) };

        }

        public int ResolveNumber(int row, int column)
        {
            return (row) * 10 + (column + 1);
        }

        public void ResetBoard()
        {
            AllKenoNumbers().ToList().ForEach(x => x.Reset());
        }

        public IEnumerable<KenoNumber> AllKenoNumbers()
        {
            for (int i = 1; i <= 80; i++)
            {
                var position = ResolvePosition(i);
                var row = position[0];
                var column = position[1];

                yield return tableLayoutPanel1.GetControlFromPosition(column, row) as KenoNumber;
            }
        }

        public void MarkMatched(int matchingNumber)
        {
            GetKenoNumber(matchingNumber).MarkMatched();
        }
    }
}
