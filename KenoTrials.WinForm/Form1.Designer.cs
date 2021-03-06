﻿namespace KenoTrials.WinForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.kenoBoard1 = new KenoTrials.WinForm.KenoBoard();
            this.playButton = new System.Windows.Forms.Button();
            this.numberToPlayTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.payoutLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.iterationsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.moneySpentLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kenoBoard1
            // 
            this.kenoBoard1.Location = new System.Drawing.Point(69, 91);
            this.kenoBoard1.Name = "kenoBoard1";
            this.kenoBoard1.Size = new System.Drawing.Size(455, 318);
            this.kenoBoard1.TabIndex = 0;
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(175, 40);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // numberToPlayTextBox
            // 
            this.numberToPlayTextBox.Location = new System.Drawing.Point(69, 43);
            this.numberToPlayTextBox.Name = "numberToPlayTextBox";
            this.numberToPlayTextBox.Size = new System.Drawing.Size(100, 20);
            this.numberToPlayTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Payout";
            // 
            // payoutLabel
            // 
            this.payoutLabel.AutoSize = true;
            this.payoutLabel.Location = new System.Drawing.Point(334, 40);
            this.payoutLabel.Name = "payoutLabel";
            this.payoutLabel.Size = new System.Drawing.Size(13, 13);
            this.payoutLabel.TabIndex = 4;
            this.payoutLabel.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(419, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // iterationsLabel
            // 
            this.iterationsLabel.AutoSize = true;
            this.iterationsLabel.Location = new System.Drawing.Point(334, 57);
            this.iterationsLabel.Name = "iterationsLabel";
            this.iterationsLabel.Size = new System.Drawing.Size(13, 13);
            this.iterationsLabel.TabIndex = 6;
            this.iterationsLabel.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Iterations";
            // 
            // moneySpentLabel
            // 
            this.moneySpentLabel.AutoSize = true;
            this.moneySpentLabel.Location = new System.Drawing.Point(334, 70);
            this.moneySpentLabel.Name = "moneySpentLabel";
            this.moneySpentLabel.Size = new System.Drawing.Size(13, 13);
            this.moneySpentLabel.TabIndex = 6;
            this.moneySpentLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Money Spent";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 435);
            this.Controls.Add(this.moneySpentLabel);
            this.Controls.Add(this.iterationsLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.payoutLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberToPlayTextBox);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.kenoBoard1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KenoBoard kenoBoard1;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.TextBox numberToPlayTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label payoutLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label iterationsLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label moneySpentLabel;
        private System.Windows.Forms.Label label3;

    }
}

