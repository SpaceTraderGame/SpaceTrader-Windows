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
	public class FormOptions : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblEmpty;
		private System.Windows.Forms.Label lblIgnore;
		private System.Windows.Forms.CheckBox chkFuel;
		private System.Windows.Forms.CheckBox chkContinuousAttack;
		private System.Windows.Forms.CheckBox chkAttackFleeing;
		private System.Windows.Forms.CheckBox chkDisable;
		private System.Windows.Forms.CheckBox chkNewspaper;
		private System.Windows.Forms.CheckBox chkNewspaperShow;
		private System.Windows.Forms.CheckBox chkRange;
		private System.Windows.Forms.CheckBox chkStopTracking;
		private System.Windows.Forms.CheckBox chkLoan;
		private System.Windows.Forms.CheckBox chkIgnoreTradersDealing;
		private System.Windows.Forms.CheckBox chkReserveMoney;
		private System.Windows.Forms.CheckBox chkIgnoreTraders;
		private System.Windows.Forms.CheckBox chkIgnorePirates;
		private System.Windows.Forms.CheckBox chkIgnorePolice;
		private System.Windows.Forms.CheckBox chkRepair;
		private System.Windows.Forms.NumericUpDown numEmpty;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnLoad;

		#endregion

		#region Member Declarations

		private Game				game					= Game.CurrentGame;
		private bool				initializing	= true;

		private GameOptions	_options			= new GameOptions(false);

		#endregion

		#region Methods

		public FormOptions()
		{
			InitializeComponent();

			if (game != null)
				Options.CopyValues(game.Options);
			else
			{
				Options.LoadFromDefaults(false, this);
				btnOk.Enabled	= false;
				FormAlert.Alert(AlertType.OptionsNoGame, this);
			}

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
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblEmpty = new System.Windows.Forms.Label();
			this.chkFuel = new System.Windows.Forms.CheckBox();
			this.chkContinuousAttack = new System.Windows.Forms.CheckBox();
			this.chkAttackFleeing = new System.Windows.Forms.CheckBox();
			this.chkNewspaper = new System.Windows.Forms.CheckBox();
			this.chkRange = new System.Windows.Forms.CheckBox();
			this.chkStopTracking = new System.Windows.Forms.CheckBox();
			this.chkLoan = new System.Windows.Forms.CheckBox();
			this.chkIgnoreTradersDealing = new System.Windows.Forms.CheckBox();
			this.chkReserveMoney = new System.Windows.Forms.CheckBox();
			this.chkIgnoreTraders = new System.Windows.Forms.CheckBox();
			this.chkIgnorePirates = new System.Windows.Forms.CheckBox();
			this.chkIgnorePolice = new System.Windows.Forms.CheckBox();
			this.chkRepair = new System.Windows.Forms.CheckBox();
			this.lblIgnore = new System.Windows.Forms.Label();
			this.numEmpty = new System.Windows.Forms.NumericUpDown();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
			this.chkNewspaperShow = new System.Windows.Forms.CheckBox();
			this.chkDisable = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.numEmpty)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOk.Location = new System.Drawing.Point(14, 240);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(40, 22);
			this.btnOk.TabIndex = 15;
			this.btnOk.Text = "Ok";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(62, 240);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(49, 22);
			this.btnCancel.TabIndex = 16;
			this.btnCancel.Text = "Cancel";
			// 
			// lblEmpty
			// 
			this.lblEmpty.AutoSize = true;
			this.lblEmpty.Location = new System.Drawing.Point(52, 90);
			this.lblEmpty.Name = "lblEmpty";
			this.lblEmpty.Size = new System.Drawing.Size(292, 16);
			this.lblEmpty.TabIndex = 38;
			this.lblEmpty.Text = "Cargo Bays to leave empty when buying goods in-system";
			// 
			// chkFuel
			// 
			this.chkFuel.Location = new System.Drawing.Point(8, 8);
			this.chkFuel.Name = "chkFuel";
			this.chkFuel.Size = new System.Drawing.Size(160, 16);
			this.chkFuel.TabIndex = 1;
			this.chkFuel.Text = "Get full fuel tanks on arrival";
			this.chkFuel.CheckedChanged += new System.EventHandler(this.controlChanged);
			// 
			// chkContinuousAttack
			// 
			this.chkContinuousAttack.Location = new System.Drawing.Point(8, 176);
			this.chkContinuousAttack.Name = "chkContinuousAttack";
			this.chkContinuousAttack.Size = new System.Drawing.Size(163, 16);
			this.chkContinuousAttack.TabIndex = 13;
			this.chkContinuousAttack.Text = "Continuous attack and flight";
			this.chkContinuousAttack.CheckedChanged += new System.EventHandler(this.controlChanged);
			// 
			// chkAttackFleeing
			// 
			this.chkAttackFleeing.Location = new System.Drawing.Point(24, 192);
			this.chkAttackFleeing.Name = "chkAttackFleeing";
			this.chkAttackFleeing.Size = new System.Drawing.Size(177, 16);
			this.chkAttackFleeing.TabIndex = 14;
			this.chkAttackFleeing.Text = "Continue attacking fleeing ship";
			this.chkAttackFleeing.CheckedChanged += new System.EventHandler(this.controlChanged);
			// 
			// chkNewspaper
			// 
			this.chkNewspaper.Location = new System.Drawing.Point(8, 40);
			this.chkNewspaper.Name = "chkNewspaper";
			this.chkNewspaper.Size = new System.Drawing.Size(155, 16);
			this.chkNewspaper.TabIndex = 3;
			this.chkNewspaper.Text = "Always pay for newspaper";
			this.chkNewspaper.CheckedChanged += new System.EventHandler(this.controlChanged);
			// 
			// chkRange
			// 
			this.chkRange.Location = new System.Drawing.Point(184, 8);
			this.chkRange.Name = "chkRange";
			this.chkRange.Size = new System.Drawing.Size(175, 16);
			this.chkRange.TabIndex = 5;
			this.chkRange.Text = "Show range to tracked system";
			this.chkRange.CheckedChanged += new System.EventHandler(this.controlChanged);
			// 
			// chkStopTracking
			// 
			this.chkStopTracking.Location = new System.Drawing.Point(184, 24);
			this.chkStopTracking.Name = "chkStopTracking";
			this.chkStopTracking.Size = new System.Drawing.Size(139, 16);
			this.chkStopTracking.TabIndex = 6;
			this.chkStopTracking.Text = "Stop tracking on arrival";
			this.chkStopTracking.CheckedChanged += new System.EventHandler(this.controlChanged);
			// 
			// chkLoan
			// 
			this.chkLoan.Location = new System.Drawing.Point(184, 56);
			this.chkLoan.Name = "chkLoan";
			this.chkLoan.Size = new System.Drawing.Size(124, 16);
			this.chkLoan.TabIndex = 4;
			this.chkLoan.Text = "Remind about loans";
			this.chkLoan.CheckedChanged += new System.EventHandler(this.controlChanged);
			// 
			// chkIgnoreTradersDealing
			// 
			this.chkIgnoreTradersDealing.Location = new System.Drawing.Point(152, 152);
			this.chkIgnoreTradersDealing.Name = "chkIgnoreTradersDealing";
			this.chkIgnoreTradersDealing.Size = new System.Drawing.Size(133, 16);
			this.chkIgnoreTradersDealing.TabIndex = 12;
			this.chkIgnoreTradersDealing.Text = "Ignore dealing traders";
			this.chkIgnoreTradersDealing.CheckedChanged += new System.EventHandler(this.controlChanged);
			// 
			// chkReserveMoney
			// 
			this.chkReserveMoney.Location = new System.Drawing.Point(184, 40);
			this.chkReserveMoney.Name = "chkReserveMoney";
			this.chkReserveMoney.Size = new System.Drawing.Size(176, 16);
			this.chkReserveMoney.TabIndex = 7;
			this.chkReserveMoney.Text = "Reserve money for warp costs";
			this.chkReserveMoney.CheckedChanged += new System.EventHandler(this.controlChanged);
			// 
			// chkIgnoreTraders
			// 
			this.chkIgnoreTraders.Location = new System.Drawing.Point(136, 136);
			this.chkIgnoreTraders.Name = "chkIgnoreTraders";
			this.chkIgnoreTraders.Size = new System.Drawing.Size(62, 16);
			this.chkIgnoreTraders.TabIndex = 11;
			this.chkIgnoreTraders.Text = "Traders";
			this.chkIgnoreTraders.CheckedChanged += new System.EventHandler(this.controlChanged);
			// 
			// chkIgnorePirates
			// 
			this.chkIgnorePirates.Location = new System.Drawing.Point(8, 136);
			this.chkIgnorePirates.Name = "chkIgnorePirates";
			this.chkIgnorePirates.Size = new System.Drawing.Size(58, 16);
			this.chkIgnorePirates.TabIndex = 9;
			this.chkIgnorePirates.Text = "Pirates";
			this.chkIgnorePirates.CheckedChanged += new System.EventHandler(this.controlChanged);
			// 
			// chkIgnorePolice
			// 
			this.chkIgnorePolice.Location = new System.Drawing.Point(74, 136);
			this.chkIgnorePolice.Name = "chkIgnorePolice";
			this.chkIgnorePolice.Size = new System.Drawing.Size(54, 16);
			this.chkIgnorePolice.TabIndex = 10;
			this.chkIgnorePolice.Text = "Police";
			this.chkIgnorePolice.CheckedChanged += new System.EventHandler(this.controlChanged);
			// 
			// chkRepair
			// 
			this.chkRepair.Location = new System.Drawing.Point(8, 24);
			this.chkRepair.Name = "chkRepair";
			this.chkRepair.Size = new System.Drawing.Size(167, 16);
			this.chkRepair.TabIndex = 2;
			this.chkRepair.Text = "Get full hull repairs on arrival";
			this.chkRepair.CheckedChanged += new System.EventHandler(this.controlChanged);
			// 
			// lblIgnore
			// 
			this.lblIgnore.AutoSize = true;
			this.lblIgnore.Location = new System.Drawing.Point(8, 120);
			this.lblIgnore.Name = "lblIgnore";
			this.lblIgnore.Size = new System.Drawing.Size(152, 16);
			this.lblIgnore.TabIndex = 52;
			this.lblIgnore.Text = "Always ignore when it is safe:";
			// 
			// numEmpty
			// 
			this.numEmpty.Location = new System.Drawing.Point(8, 88);
			this.numEmpty.Maximum = new System.Decimal(new int[] {
																														 99,
																														 0,
																														 0,
																														 0});
			this.numEmpty.Name = "numEmpty";
			this.numEmpty.Size = new System.Drawing.Size(40, 20);
			this.numEmpty.TabIndex = 8;
			this.numEmpty.Value = new System.Decimal(new int[] {
																													 88,
																													 0,
																													 0,
																													 0});
			this.numEmpty.ValueChanged += new System.EventHandler(this.controlChanged);
			// 
			// btnSave
			// 
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Location = new System.Drawing.Point(119, 240);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(107, 22);
			this.btnSave.TabIndex = 17;
			this.btnSave.Text = "Save As Defaults";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnLoad
			// 
			this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoad.Location = new System.Drawing.Point(234, 240);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(114, 22);
			this.btnLoad.TabIndex = 18;
			this.btnLoad.Text = "Load from Defaults";
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// chkNewspaperShow
			// 
			this.chkNewspaperShow.Location = new System.Drawing.Point(24, 56);
			this.chkNewspaperShow.Name = "chkNewspaperShow";
			this.chkNewspaperShow.Size = new System.Drawing.Size(160, 16);
			this.chkNewspaperShow.TabIndex = 53;
			this.chkNewspaperShow.Text = "Show newspaper on arrival";
			this.chkNewspaperShow.CheckedChanged += new System.EventHandler(this.controlChanged);
			// 
			// chkDisable
			// 
			this.chkDisable.Location = new System.Drawing.Point(8, 208);
			this.chkDisable.Name = "chkDisable";
			this.chkDisable.Size = new System.Drawing.Size(244, 16);
			this.chkDisable.TabIndex = 54;
			this.chkDisable.Text = "Attempt to disable opponents when possible";
			this.chkDisable.CheckedChanged += new System.EventHandler(this.controlChanged);
			// 
			// FormOptions
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(362, 271);
			this.Controls.Add(this.chkDisable);
			this.Controls.Add(this.chkLoan);
			this.Controls.Add(this.chkNewspaperShow);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.numEmpty);
			this.Controls.Add(this.lblIgnore);
			this.Controls.Add(this.lblEmpty);
			this.Controls.Add(this.chkRepair);
			this.Controls.Add(this.chkIgnorePolice);
			this.Controls.Add(this.chkIgnorePirates);
			this.Controls.Add(this.chkIgnoreTraders);
			this.Controls.Add(this.chkReserveMoney);
			this.Controls.Add(this.chkIgnoreTradersDealing);
			this.Controls.Add(this.chkStopTracking);
			this.Controls.Add(this.chkRange);
			this.Controls.Add(this.chkNewspaper);
			this.Controls.Add(this.chkAttackFleeing);
			this.Controls.Add(this.chkContinuousAttack);
			this.Controls.Add(this.chkFuel);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormOptions";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			((System.ComponentModel.ISupportInitialize)(this.numEmpty)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void UpdateAll()
		{
			initializing										= true;

			chkFuel.Checked									= Options.AutoFuel;
			chkRepair.Checked								= Options.AutoRepair;
			chkNewspaper.Checked						= Options.NewsAutoPay;
			chkNewspaperShow.Checked				= Options.NewsAutoShow;
			chkLoan.Checked									= Options.RemindLoans;
			chkRange.Checked								= Options.ShowTrackedRange;
			chkStopTracking.Checked					= Options.TrackAutoOff;
			chkReserveMoney.Checked					= Options.ReserveMoney;
			numEmpty.Value									= Options.LeaveEmpty;
			chkIgnorePirates.Checked				= Options.AlwaysIgnorePirates;
			chkIgnorePolice.Checked					= Options.AlwaysIgnorePolice;
			chkIgnoreTraders.Checked				= Options.AlwaysIgnoreTraders;
			chkIgnoreTradersDealing.Checked	= Options.AlwaysIgnoreTradeInOrbit;
			chkContinuousAttack.Checked			= Options.ContinuousAttack;
			chkAttackFleeing.Checked				= Options.ContinuousAttackFleeing;
			chkDisable.Checked							= Options.DisableOpponents;

			UpdateContinueAttackFleeing();
			UpdateIgnoreTradersDealing();
			UpdateNewsAutoShow();

			initializing										= false;
		}

		private void UpdateContinueAttackFleeing()
		{
			if (!chkContinuousAttack.Checked)
				chkAttackFleeing.Checked	= false;

			chkAttackFleeing.Enabled	= chkContinuousAttack.Checked;
		}

		private void UpdateIgnoreTradersDealing()
		{
			if (!chkIgnoreTraders.Checked)
				chkIgnoreTradersDealing.Checked	= false;

			chkIgnoreTradersDealing.Enabled	= chkIgnoreTraders.Checked;
		}

		private void UpdateNewsAutoShow()
		{
			if (!chkNewspaper.Checked)
				chkNewspaperShow.Checked	= false;

			chkNewspaperShow.Enabled	= chkNewspaper.Checked;
		}

		#endregion

		#region Event Handlers

		private void btnLoad_Click(object sender, System.EventArgs e)
		{
			Options.LoadFromDefaults(true, this);
			UpdateAll();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			Options.SaveAsDefaults(this);
		}

		private void controlChanged(object sender, System.EventArgs e)
		{
			if (!initializing)
			{
				initializing	= true;
				UpdateContinueAttackFleeing();
				UpdateIgnoreTradersDealing();
				UpdateNewsAutoShow();
				initializing	= false;

				Options.AutoFuel									= chkFuel.Checked;
				Options.AutoRepair								= chkRepair.Checked;
				Options.NewsAutoPay								= chkNewspaper.Checked;
				Options.NewsAutoShow							= chkNewspaperShow.Checked;
				Options.RemindLoans								= chkLoan.Checked;
				Options.ShowTrackedRange					= chkRange.Checked;
				Options.TrackAutoOff							= chkStopTracking.Checked;
				Options.ReserveMoney							= chkReserveMoney.Checked;
				Options.LeaveEmpty								= (int)numEmpty.Value;
				Options.AlwaysIgnorePirates				= chkIgnorePirates.Checked;
				Options.AlwaysIgnorePolice				= chkIgnorePolice.Checked;
				Options.AlwaysIgnoreTraders				= chkIgnoreTraders.Checked;
				Options.AlwaysIgnoreTradeInOrbit	= chkIgnoreTradersDealing.Checked;
				Options.ContinuousAttack					= chkContinuousAttack.Checked;
				Options.ContinuousAttackFleeing		= chkAttackFleeing.Checked;
				Options.DisableOpponents					= chkDisable.Checked;
			}
		}

		#endregion

		#region Properties

		public GameOptions Options
		{
			get
			{
				return _options;
			}
		}

		#endregion
	}
}
