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
    public partial class KenoNumber : UserControl
    {
        public bool IsSelected { get; private set; }
        public int Number { get; private set; }

        public KenoNumber()
        {
            InitializeComponent();
        }
        
        public void MarkSelected()
        {
            IsSelected = true;
            numberLabel.BackColor = Color.Yellow;
        }

        public void SetNumber(int number)
        {
            numberLabel.Text = number.ToString();
            Number = number;
        }

        public void MarkMatched()
        {
            numberLabel.BackColor = Color.LightGreen;
        }

        public void MarkPlayed()
        {
            numberLabel.ForeColor = Color.Red;
        }

        public void Reset()
        {
            numberLabel.ResetBackColor();
            numberLabel.ResetForeColor();
        }
    }


}
