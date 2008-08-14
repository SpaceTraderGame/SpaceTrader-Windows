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
	public class FormCargoSell : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnAll;
		private System.Windows.Forms.Button btnNone;
		private System.Windows.Forms.Label lblStatement;
		private System.Windows.Forms.Label lblQuestion;
		private System.Windows.Forms.NumericUpDown numAmount;
		private System.Windows.Forms.Label lblPaid;
		private System.Windows.Forms.Label lblProfit;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Member Declarations

		private Game	game	= Game.CurrentGame;

		#endregion

		#region Methods

		public FormCargoSell(int item, int maxAmount, CargoSellOp op, int price)
		{
			InitializeComponent();

			Commander	cmdr			= game.Commander;
			int				cost			= cmdr.PriceCargo[item] / cmdr.Ship.Cargo[item];

			numAmount.Maximum		= maxAmount;
			numAmount.Value			= numAmount.Minimum;
			this.Text						= Functions.StringVars(Strings.CargoTitle, Strings.CargoSellOps[(int)op],
														Consts.TradeItems[item].Name);
			lblQuestion.Text		= Functions.StringVars(Strings.CargoSellQuestion, Strings.CargoSellOps[(int)op].ToLower());
			lblPaid.Text				= Functions.StringVars(op == CargoSellOp.SellTrader ? Strings.CargoSellPaidTrader :
														Strings.CargoSellPaid, Functions.FormatMoney(cost),
														Functions.Multiples(maxAmount, Strings.CargoUnit));
			lblProfit.Text			= Functions.StringVars(Strings.CargoSellProfit, price >= cost ? "profit" : "loss",
														Functions.FormatMoney(price >= cost ? price - cost : cost - price));

			// Override defaults for some ops.
			switch (op)
			{
				case CargoSellOp.Dump:
					lblStatement.Text	= Functions.StringVars(Strings.CargoSellStatementDump, Strings.CargoSellOps[(int)op].ToLower(),
															Functions.FormatNumber(maxAmount));
					lblProfit.Text		= Functions.StringVars(Strings.CargoSellDumpCost, Functions.FormatMoney(-price));
					break;
				case CargoSellOp.Jettison:
					lblStatement.Text	= Functions.StringVars(Strings.CargoSellStatementDump, Strings.CargoSellOps[(int)op].ToLower(),
															Functions.FormatNumber(maxAmount));
					break;
				case CargoSellOp.SellSystem:
					lblStatement.Text	= Functions.StringVars(Strings.CargoSellStatement, Functions.FormatNumber(maxAmount),
															Functions.FormatMoney(price));
					break;
				case CargoSellOp.SellTrader:
					lblStatement.Text	= Functions.StringVars(Strings.CargoSellStatementTrader, Consts.TradeItems[item].Name,
															Functions.FormatMoney(price));
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
			this.lblPaid = new System.Windows.Forms.Label();
			this.lblProfit = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
			this.SuspendLayout();
			// 
			// lblQuestion
			// 
			this.lblQuestion.Location = new System.Drawing.Point(8, 50);
			this.lblQuestion.Name = "lblQuestion";
			this.lblQuestion.Size = new System.Drawing.Size(160, 13);
			this.lblQuestion.TabIndex = 1;
			this.lblQuestion.Text = "How many do you want to sell?";
			// 
			// lblStatement
			// 
			this.lblStatement.Location = new System.Drawing.Point(8, 8);
			this.lblStatement.Name = "lblStatement";
			this.lblStatement.Size = new System.Drawing.Size(302, 13);
			this.lblStatement.TabIndex = 3;
			this.lblStatement.Text = "The trader wants to by Machines, and offers 8,888 cr. each.";
			// 
			// numAmount
			// 
			this.numAmount.Location = new System.Drawing.Point(168, 48);
			this.numAmount.Minimum = new System.Decimal(new int[] {
																															1,
																															0,
																															0,
																															0});
			this.numAmount.Name = "numAmount";
			this.numAmount.Size = new System.Drawing.Size(38, 20);
			this.numAmount.TabIndex = 1;
			this.numAmount.Value = new System.Decimal(new int[] {
																														88,
																														0,
																														0,
																														0});
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOk.Location = new System.Drawing.Point(83, 74);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(41, 22);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "Ok";
			// 
			// btnAll
			// 
			this.btnAll.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAll.Location = new System.Drawing.Point(131, 74);
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
			this.btnNone.Location = new System.Drawing.Point(179, 74);
			this.btnNone.Name = "btnNone";
			this.btnNone.Size = new System.Drawing.Size(41, 22);
			this.btnNone.TabIndex = 4;
			this.btnNone.Text = "None";
			// 
			// lblPaid
			// 
			this.lblPaid.Location = new System.Drawing.Point(8, 21);
			this.lblPaid.Name = "lblPaid";
			this.lblPaid.Size = new System.Drawing.Size(280, 13);
			this.lblPaid.TabIndex = 5;
			this.lblPaid.Text = "You paid about 8,888 cr. per unit, and can sell 88 units.";
			// 
			// lblProfit
			// 
			this.lblProfit.Location = new System.Drawing.Point(8, 34);
			this.lblProfit.Name = "lblProfit";
			this.lblProfit.Size = new System.Drawing.Size(200, 13);
			this.lblProfit.TabIndex = 6;
			this.lblProfit.Text = "It costs 8,888 cr. per unit for disposal.";
			// 
			// FormCargoSell
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnNone;
			this.ClientSize = new System.Drawing.Size(302, 105);
			this.ControlBox = false;
			this.Controls.Add(this.lblProfit);
			this.Controls.Add(this.lblPaid);
			this.Controls.Add(this.btnNone);
			this.Controls.Add(this.btnAll);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.numAmount);
			this.Controls.Add(this.lblQuestion);
			this.Controls.Add(this.lblStatement);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormCargoSell";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Sell Xxxxxxxxxx";
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
