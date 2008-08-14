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
	public class FormCargoBuy : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnAll;
		private System.Windows.Forms.Button btnNone;
		private System.Windows.Forms.Label lblQuestion;
		private System.Windows.Forms.Label lblStatement;
		private System.Windows.Forms.NumericUpDown numAmount;
		private System.Windows.Forms.Label lblAvailable;
		private System.Windows.Forms.Label lblAfford;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Member Declarations

		private Game	game	= Game.CurrentGame;

		#endregion

		#region Methods

		public FormCargoBuy(int item, int maxAmount, CargoBuyOp op)
		{
			InitializeComponent();

			Commander	cmdr						= game.Commander;
			numAmount.Maximum					= maxAmount;
			numAmount.Value						= numAmount.Minimum;
			this.Text									= Functions.StringVars(Strings.CargoTitle, Strings.CargoBuyOps[(int)op],
																	Consts.TradeItems[item].Name);
			lblQuestion.Text					= Functions.StringVars(Strings.CargoBuyQuestion, Strings.CargoBuyOps[(int)op].ToLower());

			switch (op)
			{
				case CargoBuyOp.BuySystem:
					lblStatement.Text			= Functions.StringVars(Strings.CargoBuyStatement,
																	Functions.FormatMoney(game.PriceCargoBuy[item]),
																	Functions.FormatNumber(maxAmount));

					this.Height						= btnOk.Top + btnOk.Height + 34;
					break;
				case CargoBuyOp.BuyTrader:
					int afford						= Math.Min(game.Commander.Cash / game.PriceCargoBuy[item],
																	game.Commander.Ship.FreeCargoBays);
					if (afford < maxAmount)
						numAmount.Maximum	= afford;

					lblStatement.Text			= Functions.StringVars(Strings.CargoBuyStatementTrader, Consts.TradeItems[item].Name,
																	Functions.FormatMoney(game.PriceCargoBuy[item]));
					lblAvailable.Text			= Functions.StringVars(Strings.CargoBuyAvailable,
																	Functions.Multiples(game.Opponent.Cargo[item], Strings.CargoUnit));
					lblAfford.Text				= Functions.StringVars(Strings.CargoBuyAfford, Functions.Multiples(afford,
																	Strings.CargoUnit));

					lblAvailable.Visible	= true;
					lblAfford.Visible			= true;

					btnOk.Top							+= 26;
					btnAll.Top						+= 26;
					btnNone.Top						+= 26;
					lblQuestion.Top				+= 26;
					numAmount.Top					+= 26;

					break;
				case CargoBuyOp.Plunder:
					lblStatement.Text			= Functions.StringVars(Strings.CargoBuyStatementSteal,
																	Functions.FormatNumber(game.Opponent.Cargo[item]));

					this.Height						= btnOk.Top + btnOk.Height + 34;
					break;
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
			this.lblQuestion = new System.Windows.Forms.Label();
			this.lblStatement = new System.Windows.Forms.Label();
			this.numAmount = new System.Windows.Forms.NumericUpDown();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnAll = new System.Windows.Forms.Button();
			this.btnNone = new System.Windows.Forms.Button();
			this.lblAvailable = new System.Windows.Forms.Label();
			this.lblAfford = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
			this.SuspendLayout();
			// 
			// lblQuestion
			// 
			this.lblQuestion.AutoSize = true;
			this.lblQuestion.Location = new System.Drawing.Point(8, 24);
			this.lblQuestion.Name = "lblQuestion";
			this.lblQuestion.Size = new System.Drawing.Size(161, 16);
			this.lblQuestion.TabIndex = 1;
			this.lblQuestion.Text = "How many do you want to buy?";
			// 
			// lblStatement
			// 
			this.lblStatement.Location = new System.Drawing.Point(8, 8);
			this.lblStatement.Name = "lblStatement";
			this.lblStatement.Size = new System.Drawing.Size(326, 13);
			this.lblStatement.TabIndex = 3;
			this.lblStatement.Text = "The trader wants to sell Machines for the price of 8,888 cr. each.";
			// 
			// numAmount
			// 
			this.numAmount.Location = new System.Drawing.Point(168, 22);
			this.numAmount.Maximum = new System.Decimal(new int[] {
																															999,
																															0,
																															0,
																															0});
			this.numAmount.Minimum = new System.Decimal(new int[] {
																															1,
																															0,
																															0,
																															0});
			this.numAmount.Name = "numAmount";
			this.numAmount.Size = new System.Drawing.Size(44, 20);
			this.numAmount.TabIndex = 1;
			this.numAmount.Value = new System.Decimal(new int[] {
																														1,
																														0,
																														0,
																														0});
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOk.Location = new System.Drawing.Point(95, 48);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(41, 22);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "Ok";
			// 
			// btnAll
			// 
			this.btnAll.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAll.Location = new System.Drawing.Point(143, 48);
			this.btnAll.Name = "btnAll";
			this.btnAll.Size = new System.Drawing.Size(41, 22);
			this.btnAll.TabIndex = 3;
			this.btnAll.Text = "All";
			this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
			// 
			// btnNone
			// 
			this.btnNone.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNone.Location = new System.Drawing.Point(191, 48);
			this.btnNone.Name = "btnNone";
			this.btnNone.Size = new System.Drawing.Size(41, 22);
			this.btnNone.TabIndex = 4;
			this.btnNone.Text = "None";
			// 
			// lblAvailable
			// 
			this.lblAvailable.Location = new System.Drawing.Point(8, 21);
			this.lblAvailable.Name = "lblAvailable";
			this.lblAvailable.Size = new System.Drawing.Size(163, 13);
			this.lblAvailable.TabIndex = 5;
			this.lblAvailable.Text = "The trader has 88 units for sale.";
			this.lblAvailable.Visible = false;
			// 
			// lblAfford
			// 
			this.lblAfford.Location = new System.Drawing.Point(8, 34);
			this.lblAfford.Name = "lblAfford";
			this.lblAfford.Size = new System.Drawing.Size(157, 13);
			this.lblAfford.TabIndex = 6;
			this.lblAfford.Text = "You can afford to buy 88 units.";
			this.lblAfford.Visible = false;
			// 
			// FormCargoBuy
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnNone;
			this.ClientSize = new System.Drawing.Size(326, 105);
			this.ControlBox = false;
			this.Controls.Add(this.btnNone);
			this.Controls.Add(this.btnAll);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.numAmount);
			this.Controls.Add(this.lblQuestion);
			this.Controls.Add(this.lblStatement);
			this.Controls.Add(this.lblAfford);
			this.Controls.Add(this.lblAvailable);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormCargoBuy";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Buy Xxxxxxxxxx";
			((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#endregion

		#region Event Handlers

		private void btnAll_Click(object sender, System.EventArgs e)
		{
			numAmount.Value	= numAmount.Maximum;
		}

		#endregion

		#region Properties

		public int Amount
		{
			get
			{
				return (int)numAmount.Value;
			}
		}

		#endregion
	}
}
