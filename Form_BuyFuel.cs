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
	public class FormBuyFuel : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblQuestion;
		private System.Windows.Forms.Button btnMax;
		private System.Windows.Forms.Button btnNothing;
		private System.Windows.Forms.NumericUpDown numAmount;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Member Declarations

		private Game	game	= Game.CurrentGame;

		#endregion

		#region Methods

		public FormBuyFuel()
		{
			InitializeComponent();

			Commander	cmdr		= game.Commander;
			numAmount.Maximum	= Math.Min(cmdr.Cash, (cmdr.Ship.FuelTanks - cmdr.Ship.Fuel) * cmdr.Ship.FuelCost);
			numAmount.Value		= numAmount.Maximum;
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
			this.numAmount = new System.Windows.Forms.NumericUpDown();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnMax = new System.Windows.Forms.Button();
			this.btnNothing = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
			this.SuspendLayout();
			//
			// lblQuestion
			//
			this.lblQuestion.AutoSize = true;
			this.lblQuestion.Location = new System.Drawing.Point(8, 8);
			this.lblQuestion.Name = "lblQuestion";
			this.lblQuestion.Size = new System.Drawing.Size(211, 13);
			this.lblQuestion.TabIndex = 3;
			this.lblQuestion.Text = "How much do you want to spend on fuel?";
			//
			// numAmount
			//
			this.numAmount.Location = new System.Drawing.Point(216, 6);
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
																														888,
																														0,
																														0,
																														0});
			//
			// btnOk
			//
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOk.Location = new System.Drawing.Point(61, 32);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(41, 22);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "Ok";
			//
			// btnMax
			//
			this.btnMax.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMax.Location = new System.Drawing.Point(109, 32);
			this.btnMax.Name = "btnMax";
			this.btnMax.Size = new System.Drawing.Size(41, 22);
			this.btnMax.TabIndex = 3;
			this.btnMax.Text = "Max";
			this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
			//
			// btnNothing
			//
			this.btnNothing.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnNothing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNothing.Location = new System.Drawing.Point(157, 32);
			this.btnNothing.Name = "btnNothing";
			this.btnNothing.Size = new System.Drawing.Size(53, 22);
			this.btnNothing.TabIndex = 4;
			this.btnNothing.Text = "Nothing";
			//
			// FormBuyFuel
			//
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnNothing;
			this.ClientSize = new System.Drawing.Size(270, 63);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.btnNothing,
																																	this.btnMax,
																																	this.btnOk,
																																	this.numAmount,
																																	this.lblQuestion});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormBuyFuel";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Buy Fuel";
			((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
			this.ResumeLayout(false);
		}
		#endregion

		#endregion

		#region Event Handlers

		private void btnMax_Click(object sender, System.EventArgs e)
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
