/*******************************************************************************
 *
 * Space Trader for Windows 2.01
 *
 * Copyright (C) 2008 Jay French, All Rights Reserved
 *
 * Additional coding by David Pierron
 * Original coding by Pieter Spronck, Sam Anderson, Samuel Goldstein, Matt Lee
 *
 * This program is free software; you can redistribute it and/or modify it
 * under the terms of the GNU General Public License as published by the Free
 * Software Foundation; either version 2 of the License, or (at your option) any
 * later version.
 *
 * This program is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
 *
 * If you'd like a copy of the GNU General Public License, go to
 * http://www.gnu.org/copyleft/gpl.html.
 *
 * You can contact the author at spacetrader@frenchfryz.com
 *
 ******************************************************************************/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Fryz.Apps.SpaceTrader
{
	public class FormViewHighScores : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblRank0;
		private System.Windows.Forms.Label lblRank2;
		private System.Windows.Forms.Label lblRank1;
		private System.Windows.Forms.Label lblScore0;
		private System.Windows.Forms.Label lblScore1;
		private System.Windows.Forms.Label lblScore2;
		private System.Windows.Forms.Label lblName0;
		private System.Windows.Forms.Label lblName1;
		private System.Windows.Forms.Label lblName2;
		private System.Windows.Forms.Label lblStatus0;
		private System.Windows.Forms.Label lblStatus1;
		private System.Windows.Forms.Label lblStatus2;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Methods

		public FormViewHighScores()
		{
			InitializeComponent();

			Label[] lblName		= new Label[] { lblName0,   lblName1,   lblName2   };
			Label[] lblScore	= new Label[] { lblScore0,  lblScore1,  lblScore2  };
			Label[] lblStatus	= new Label[] { lblStatus0, lblStatus1, lblStatus2 };

			HighScoreRecord[]	highScores	= Functions.GetHighScores(this);
			for (int i = highScores.Length - 1; i >= 0 && highScores[i] != null; i--)
			{
				lblName[2 - i].Text				= highScores[i].Name;
				lblScore[2 - i].Text			= Functions.FormatNumber(highScores[i].Score / 10) + "." + highScores[i].Score % 10;
				lblStatus[2 - i].Text			= Functions.StringVars(Strings.HighScoreStatus, new string[]
																	{
																		Strings.GameCompletionTypes[(int)highScores[i].Type],
																		Functions.Multiples(highScores[i].Days, Strings.TimeUnit),
																		Functions.Multiples(highScores[i].Worth, Strings.MoneyUnit),
																		Strings.DifficultyLevels[(int)highScores[i].Difficulty].ToLower()
																	});

				lblScore[2 - i].Visible		= true;
				lblStatus[2 - i].Visible	= true;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnClose = new System.Windows.Forms.Button();
			this.lblRank0 = new System.Windows.Forms.Label();
			this.lblRank2 = new System.Windows.Forms.Label();
			this.lblRank1 = new System.Windows.Forms.Label();
			this.lblScore0 = new System.Windows.Forms.Label();
			this.lblScore1 = new System.Windows.Forms.Label();
			this.lblScore2 = new System.Windows.Forms.Label();
			this.lblName0 = new System.Windows.Forms.Label();
			this.lblName1 = new System.Windows.Forms.Label();
			this.lblName2 = new System.Windows.Forms.Label();
			this.lblStatus0 = new System.Windows.Forms.Label();
			this.lblStatus1 = new System.Windows.Forms.Label();
			this.lblStatus2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			//
			// btnClose
			//
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(-32, -32);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(32, 32);
			this.btnClose.TabIndex = 32;
			this.btnClose.TabStop = false;
			this.btnClose.Text = "X";
			//
			// lblRank0
			//
			this.lblRank0.AutoSize = true;
			this.lblRank0.Location = new System.Drawing.Point(8, 8);
			this.lblRank0.Name = "lblRank0";
			this.lblRank0.Size = new System.Drawing.Size(14, 13);
			this.lblRank0.TabIndex = 33;
			this.lblRank0.Text = "1.";
			this.lblRank0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblRank2
			//
			this.lblRank2.AutoSize = true;
			this.lblRank2.Location = new System.Drawing.Point(8, 136);
			this.lblRank2.Name = "lblRank2";
			this.lblRank2.Size = new System.Drawing.Size(14, 13);
			this.lblRank2.TabIndex = 34;
			this.lblRank2.Text = "3.";
			this.lblRank2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblRank1
			//
			this.lblRank1.AutoSize = true;
			this.lblRank1.Location = new System.Drawing.Point(8, 72);
			this.lblRank1.Name = "lblRank1";
			this.lblRank1.Size = new System.Drawing.Size(14, 13);
			this.lblRank1.TabIndex = 35;
			this.lblRank1.Text = "2.";
			this.lblRank1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblScore0
			//
			this.lblScore0.Location = new System.Drawing.Point(168, 8);
			this.lblScore0.Name = "lblScore0";
			this.lblScore0.Size = new System.Drawing.Size(43, 13);
			this.lblScore0.TabIndex = 36;
			this.lblScore0.Text = "888.8%";
			this.lblScore0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblScore0.Visible = false;
			//
			// lblScore1
			//
			this.lblScore1.Location = new System.Drawing.Point(168, 72);
			this.lblScore1.Name = "lblScore1";
			this.lblScore1.Size = new System.Drawing.Size(43, 13);
			this.lblScore1.TabIndex = 37;
			this.lblScore1.Text = "888.8%";
			this.lblScore1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblScore1.Visible = false;
			//
			// lblScore2
			//
			this.lblScore2.Location = new System.Drawing.Point(168, 136);
			this.lblScore2.Name = "lblScore2";
			this.lblScore2.Size = new System.Drawing.Size(43, 13);
			this.lblScore2.TabIndex = 38;
			this.lblScore2.Text = "888.8%";
			this.lblScore2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblScore2.Visible = false;
			//
			// lblName0
			//
			this.lblName0.Location = new System.Drawing.Point(24, 8);
			this.lblName0.Name = "lblName0";
			this.lblName0.Size = new System.Drawing.Size(144, 13);
			this.lblName0.TabIndex = 39;
			this.lblName0.Text = "Empty";
			//
			// lblName1
			//
			this.lblName1.Location = new System.Drawing.Point(24, 72);
			this.lblName1.Name = "lblName1";
			this.lblName1.Size = new System.Drawing.Size(144, 13);
			this.lblName1.TabIndex = 40;
			this.lblName1.Text = "Empty";
			//
			// lblName2
			//
			this.lblName2.Location = new System.Drawing.Point(24, 136);
			this.lblName2.Name = "lblName2";
			this.lblName2.Size = new System.Drawing.Size(144, 13);
			this.lblName2.TabIndex = 41;
			this.lblName2.Text = "Empty";
			//
			// lblStatus0
			//
			this.lblStatus0.Location = new System.Drawing.Point(24, 24);
			this.lblStatus0.Name = "lblStatus0";
			this.lblStatus0.Size = new System.Drawing.Size(200, 26);
			this.lblStatus0.TabIndex = 42;
			this.lblStatus0.Text = "Claimed moon in 888,888 days, worth 8,888,888 credits on impossible level.";
			this.lblStatus0.Visible = false;
			//
			// lblStatus1
			//
			this.lblStatus1.Location = new System.Drawing.Point(24, 88);
			this.lblStatus1.Name = "lblStatus1";
			this.lblStatus1.Size = new System.Drawing.Size(200, 26);
			this.lblStatus1.TabIndex = 43;
			this.lblStatus1.Text = "Claimed moon in 888,888 days, worth 8,888,888 credits on impossible level.";
			this.lblStatus1.Visible = false;
			//
			// lblStatus2
			//
			this.lblStatus2.Location = new System.Drawing.Point(24, 152);
			this.lblStatus2.Name = "lblStatus2";
			this.lblStatus2.Size = new System.Drawing.Size(200, 26);
			this.lblStatus2.TabIndex = 44;
			this.lblStatus2.Text = "Claimed moon in 888,888 days, worth 8,888,888 credits on impossible level.";
			this.lblStatus2.Visible = false;
			//
			// FormViewHighScores
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(218, 191);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.lblStatus2,
																																	this.lblStatus1,
																																	this.lblStatus0,
																																	this.lblName2,
																																	this.lblName1,
																																	this.lblName0,
																																	this.lblScore2,
																																	this.lblScore1,
																																	this.lblScore0,
																																	this.lblRank1,
																																	this.lblRank2,
																																	this.lblRank0,
																																	this.btnClose});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormViewHighScores";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "High Scores";
			this.ResumeLayout(false);
		}
		#endregion

		#endregion
	}
}
