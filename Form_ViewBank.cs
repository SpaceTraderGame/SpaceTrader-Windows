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
	public class FormViewBank : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Label lblLoan;
		private System.Windows.Forms.Label lblCurrentDebtLabel;
		private System.Windows.Forms.Label lblMaxLoanLabel;
		private System.Windows.Forms.Label lblCurrentDebt;
		private System.Windows.Forms.Label lblMaxLoan;
		private System.Windows.Forms.Button btnGetLoan;
		private System.Windows.Forms.Button btnBuyInsurance;
		private System.Windows.Forms.Label lblNoClaim;
		private System.Windows.Forms.Label lblShipValue;
		private System.Windows.Forms.Label lblNoClaimLabel;
		private System.Windows.Forms.Label lblShipValueLabel;
		private System.Windows.Forms.Label lblInsurance;
		private System.Windows.Forms.Label lblInsAmt;
		private System.Windows.Forms.Label lblInsAmtLabel;
		private System.Windows.Forms.Button btnPayBack;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblMaxNoClaim;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Member Declarations

		private Game			game		= Game.CurrentGame;
		private Commander	cmdr		= Game.CurrentGame.Commander;
		private int				MaxLoan	= Game.CurrentGame.Commander.PoliceRecordScore >=
																Consts.PoliceRecordScoreClean ?
																Math.Min(25000, Math.Max(1000, Game.CurrentGame.Commander.Worth / 5000 * 500)) :
																500;

		#endregion

		#region Methods

		public FormViewBank()
		{
			InitializeComponent();

			UpdateAll();
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
			this.lblLoan = new System.Windows.Forms.Label();
			this.lblCurrentDebtLabel = new System.Windows.Forms.Label();
			this.lblMaxLoanLabel = new System.Windows.Forms.Label();
			this.lblCurrentDebt = new System.Windows.Forms.Label();
			this.lblMaxLoan = new System.Windows.Forms.Label();
			this.btnGetLoan = new System.Windows.Forms.Button();
			this.btnBuyInsurance = new System.Windows.Forms.Button();
			this.lblNoClaim = new System.Windows.Forms.Label();
			this.lblShipValue = new System.Windows.Forms.Label();
			this.lblNoClaimLabel = new System.Windows.Forms.Label();
			this.lblShipValueLabel = new System.Windows.Forms.Label();
			this.lblInsurance = new System.Windows.Forms.Label();
			this.lblInsAmt = new System.Windows.Forms.Label();
			this.lblInsAmtLabel = new System.Windows.Forms.Label();
			this.btnPayBack = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblMaxNoClaim = new System.Windows.Forms.Label();
			this.SuspendLayout();
			//
			// lblLoan
			//
			this.lblLoan.AutoSize = true;
			this.lblLoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblLoan.Location = new System.Drawing.Point(8, 8);
			this.lblLoan.Name = "lblLoan";
			this.lblLoan.Size = new System.Drawing.Size(44, 19);
			this.lblLoan.TabIndex = 1;
			this.lblLoan.Text = "Loan";
			//
			// lblCurrentDebtLabel
			//
			this.lblCurrentDebtLabel.AutoSize = true;
			this.lblCurrentDebtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCurrentDebtLabel.Location = new System.Drawing.Point(16, 32);
			this.lblCurrentDebtLabel.Name = "lblCurrentDebtLabel";
			this.lblCurrentDebtLabel.Size = new System.Drawing.Size(75, 13);
			this.lblCurrentDebtLabel.TabIndex = 2;
			this.lblCurrentDebtLabel.Text = "Current Debt:";
			//
			// lblMaxLoanLabel
			//
			this.lblMaxLoanLabel.AutoSize = true;
			this.lblMaxLoanLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMaxLoanLabel.Location = new System.Drawing.Point(16, 52);
			this.lblMaxLoanLabel.Name = "lblMaxLoanLabel";
			this.lblMaxLoanLabel.Size = new System.Drawing.Size(88, 13);
			this.lblMaxLoanLabel.TabIndex = 3;
			this.lblMaxLoanLabel.Text = "Maximum Loan:";
			//
			// lblCurrentDebt
			//
			this.lblCurrentDebt.Location = new System.Drawing.Point(136, 32);
			this.lblCurrentDebt.Name = "lblCurrentDebt";
			this.lblCurrentDebt.Size = new System.Drawing.Size(56, 13);
			this.lblCurrentDebt.TabIndex = 4;
			this.lblCurrentDebt.Text = "88,888 cr.";
			this.lblCurrentDebt.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblMaxLoan
			//
			this.lblMaxLoan.Location = new System.Drawing.Point(136, 52);
			this.lblMaxLoan.Name = "lblMaxLoan";
			this.lblMaxLoan.Size = new System.Drawing.Size(56, 13);
			this.lblMaxLoan.TabIndex = 5;
			this.lblMaxLoan.Text = "88,888 cr.";
			this.lblMaxLoan.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// btnGetLoan
			//
			this.btnGetLoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGetLoan.Location = new System.Drawing.Point(16, 72);
			this.btnGetLoan.Name = "btnGetLoan";
			this.btnGetLoan.Size = new System.Drawing.Size(61, 22);
			this.btnGetLoan.TabIndex = 1;
			this.btnGetLoan.Text = "Get Loan";
			this.btnGetLoan.Click += new System.EventHandler(this.btnGetLoan_Click);
			//
			// btnBuyInsurance
			//
			this.btnBuyInsurance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyInsurance.Location = new System.Drawing.Point(16, 196);
			this.btnBuyInsurance.Name = "btnBuyInsurance";
			this.btnBuyInsurance.Size = new System.Drawing.Size(90, 22);
			this.btnBuyInsurance.TabIndex = 3;
			this.btnBuyInsurance.Text = "Stop Insurance";
			this.btnBuyInsurance.Click += new System.EventHandler(this.btnBuyInsurance_Click);
			//
			// lblNoClaim
			//
			this.lblNoClaim.Location = new System.Drawing.Point(154, 156);
			this.lblNoClaim.Name = "lblNoClaim";
			this.lblNoClaim.Size = new System.Drawing.Size(32, 13);
			this.lblNoClaim.TabIndex = 27;
			this.lblNoClaim.Text = "88%";
			this.lblNoClaim.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblShipValue
			//
			this.lblShipValue.Location = new System.Drawing.Point(136, 136);
			this.lblShipValue.Name = "lblShipValue";
			this.lblShipValue.Size = new System.Drawing.Size(56, 13);
			this.lblShipValue.TabIndex = 26;
			this.lblShipValue.Text = "88,888 cr.";
			this.lblShipValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblNoClaimLabel
			//
			this.lblNoClaimLabel.AutoSize = true;
			this.lblNoClaimLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNoClaimLabel.Location = new System.Drawing.Point(16, 156);
			this.lblNoClaimLabel.Name = "lblNoClaimLabel";
			this.lblNoClaimLabel.Size = new System.Drawing.Size(106, 13);
			this.lblNoClaimLabel.TabIndex = 25;
			this.lblNoClaimLabel.Text = "No-Claim Discount:";
			//
			// lblShipValueLabel
			//
			this.lblShipValueLabel.AutoSize = true;
			this.lblShipValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblShipValueLabel.Location = new System.Drawing.Point(16, 136);
			this.lblShipValueLabel.Name = "lblShipValueLabel";
			this.lblShipValueLabel.Size = new System.Drawing.Size(65, 13);
			this.lblShipValueLabel.TabIndex = 24;
			this.lblShipValueLabel.Text = "Ship Value:";
			//
			// lblInsurance
			//
			this.lblInsurance.AutoSize = true;
			this.lblInsurance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblInsurance.Location = new System.Drawing.Point(8, 112);
			this.lblInsurance.Name = "lblInsurance";
			this.lblInsurance.Size = new System.Drawing.Size(81, 19);
			this.lblInsurance.TabIndex = 23;
			this.lblInsurance.Text = "Insurance";
			//
			// lblInsAmt
			//
			this.lblInsAmt.Location = new System.Drawing.Point(136, 176);
			this.lblInsAmt.Name = "lblInsAmt";
			this.lblInsAmt.Size = new System.Drawing.Size(82, 13);
			this.lblInsAmt.TabIndex = 30;
			this.lblInsAmt.Text = "8,888 cr. daily";
			this.lblInsAmt.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblInsAmtLabel
			//
			this.lblInsAmtLabel.AutoSize = true;
			this.lblInsAmtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblInsAmtLabel.Location = new System.Drawing.Point(16, 176);
			this.lblInsAmtLabel.Name = "lblInsAmtLabel";
			this.lblInsAmtLabel.Size = new System.Drawing.Size(38, 13);
			this.lblInsAmtLabel.TabIndex = 29;
			this.lblInsAmtLabel.Text = "Costs:";
			//
			// btnPayBack
			//
			this.btnPayBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPayBack.Location = new System.Drawing.Point(88, 72);
			this.btnPayBack.Name = "btnPayBack";
			this.btnPayBack.Size = new System.Drawing.Size(90, 22);
			this.btnPayBack.TabIndex = 2;
			this.btnPayBack.Text = "Pay Back Loan";
			this.btnPayBack.Click += new System.EventHandler(this.btnPayBack_Click);
			//
			// btnClose
			//
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(-32, -32);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(26, 27);
			this.btnClose.TabIndex = 32;
			this.btnClose.TabStop = false;
			this.btnClose.Text = "X";
			//
			// lblMaxNoClaim
			//
			this.lblMaxNoClaim.AutoSize = true;
			this.lblMaxNoClaim.Location = new System.Drawing.Point(182, 156);
			this.lblMaxNoClaim.Name = "lblMaxNoClaim";
			this.lblMaxNoClaim.Size = new System.Drawing.Size(33, 13);
			this.lblMaxNoClaim.TabIndex = 33;
			this.lblMaxNoClaim.Text = "(max)";
			this.lblMaxNoClaim.Visible = false;
			//
			// FormViewBank
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(226, 231);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.lblMaxNoClaim,
																																	this.btnClose,
																																	this.btnPayBack,
																																	this.lblInsAmt,
																																	this.lblInsAmtLabel,
																																	this.lblNoClaimLabel,
																																	this.lblShipValueLabel,
																																	this.lblInsurance,
																																	this.lblMaxLoanLabel,
																																	this.lblCurrentDebtLabel,
																																	this.lblLoan,
																																	this.btnBuyInsurance,
																																	this.lblNoClaim,
																																	this.lblShipValue,
																																	this.btnGetLoan,
																																	this.lblMaxLoan,
																																	this.lblCurrentDebt});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormViewBank";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Bank";
			this.ResumeLayout(false);
		}
		#endregion

		private void UpdateAll()
		{
			// Loan Info
			lblCurrentDebt.Text			= Functions.FormatMoney(cmdr.Debt);
			lblMaxLoan.Text					= Functions.FormatMoney(MaxLoan);
			btnPayBack.Visible			= (cmdr.Debt > 0);

			// Insurance Info
			lblShipValue.Text				= Functions.FormatMoney(cmdr.Ship.BaseWorth(true));
			lblNoClaim.Text					= Functions.FormatPercent(cmdr.NoClaim);
			lblMaxNoClaim.Visible		= (cmdr.NoClaim == Consts.MaxNoClaim);
			lblInsAmt.Text					= Functions.StringVars(Strings.MoneyRateSuffix,
				Functions.FormatMoney(game.InsuranceCosts));
			btnBuyInsurance.Text		= Functions.StringVars(Strings.BankInsuranceButtonText, cmdr.Insurance ?
				Strings.BankInsuranceButtonStop : Strings.BankInsuranceButtonBuy);
		}

		#endregion

		#region Event Handlers

		private void btnGetLoan_Click(object sender, System.EventArgs e)
		{
			if (cmdr.Debt >= MaxLoan)
				FormAlert.Alert(AlertType.DebtTooLargeLoan, this);
			else
			{
				FormGetLoan	form	= new FormGetLoan(MaxLoan - cmdr.Debt);
				if (form.ShowDialog(this) == DialogResult.OK)
				{
					cmdr.Cash	+= form.Amount;
					cmdr.Debt	+= form.Amount;

					UpdateAll();
					game.ParentWindow.UpdateAll();
				}
			}
		}

		private void btnPayBack_Click(object sender, System.EventArgs e)
		{
			if (cmdr.Debt == 0)
				FormAlert.Alert(AlertType.DebtNone, this);
			else
			{
				FormPayBackLoan	form	= new FormPayBackLoan();
				if (form.ShowDialog(this) == DialogResult.OK)
				{
					cmdr.Cash	-= form.Amount;
					cmdr.Debt	-= form.Amount;

					UpdateAll();
					game.ParentWindow.UpdateAll();
				}
			}
		}

		private void btnBuyInsurance_Click(object sender, System.EventArgs e)
		{
			if (cmdr.Insurance)
			{
				if (FormAlert.Alert(AlertType.InsuranceStop, this) == DialogResult.Yes)
				{
					cmdr.Insurance	= false;
					cmdr.NoClaim		= 0;
				}
			}
			else if (!cmdr.Ship.EscapePod)
				FormAlert.Alert(AlertType.InsuranceNoEscapePod, this);
			else
			{
				cmdr.Insurance	= true;
				cmdr.NoClaim		= 0;
			}

			UpdateAll();
			game.ParentWindow.UpdateAll();
		}

		#endregion
	}
}
