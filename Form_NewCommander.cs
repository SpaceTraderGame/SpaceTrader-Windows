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
	public class FormNewCommander : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblDifficulty;
		private System.Windows.Forms.Label lblSkillPoints;
		private System.Windows.Forms.Label lblPilot;
		private System.Windows.Forms.Label lblFighter;
		private System.Windows.Forms.Label lblTrader;
		private System.Windows.Forms.Label lblEngineer;
		private System.Windows.Forms.ComboBox selDifficulty;
		private System.Windows.Forms.NumericUpDown numPilot;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblPointsRemaining;
		private System.Windows.Forms.Label lblPoints;
		private System.Windows.Forms.NumericUpDown numFighter;
		private System.Windows.Forms.NumericUpDown numTrader;
		private System.Windows.Forms.NumericUpDown numEngineer;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Methods

		public FormNewCommander()
		{
			InitializeComponent();

			selDifficulty.SelectedIndex	= 2;
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
			this.lblName = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblDifficulty = new System.Windows.Forms.Label();
			this.lblSkillPoints = new System.Windows.Forms.Label();
			this.lblPilot = new System.Windows.Forms.Label();
			this.lblFighter = new System.Windows.Forms.Label();
			this.lblTrader = new System.Windows.Forms.Label();
			this.lblEngineer = new System.Windows.Forms.Label();
			this.selDifficulty = new System.Windows.Forms.ComboBox();
			this.numPilot = new System.Windows.Forms.NumericUpDown();
			this.numFighter = new System.Windows.Forms.NumericUpDown();
			this.numTrader = new System.Windows.Forms.NumericUpDown();
			this.numEngineer = new System.Windows.Forms.NumericUpDown();
			this.btnOk = new System.Windows.Forms.Button();
			this.lblPointsRemaining = new System.Windows.Forms.Label();
			this.lblPoints = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numPilot)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numFighter)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numTrader)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numEngineer)).BeginInit();
			this.SuspendLayout();
			//
			// lblName
			//
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(8, 8);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(38, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "Name:";
			//
			// txtName
			//
			this.txtName.Location = new System.Drawing.Point(72, 5);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(120, 20);
			this.txtName.TabIndex = 1;
			this.txtName.Text = "";
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			//
			// btnClose
			//
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(-32, -32);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(30, 31);
			this.btnClose.TabIndex = 33;
			this.btnClose.TabStop = false;
			this.btnClose.Text = "X";
			//
			// lblDifficulty
			//
			this.lblDifficulty.AutoSize = true;
			this.lblDifficulty.Location = new System.Drawing.Point(8, 40);
			this.lblDifficulty.Name = "lblDifficulty";
			this.lblDifficulty.Size = new System.Drawing.Size(50, 13);
			this.lblDifficulty.TabIndex = 34;
			this.lblDifficulty.Text = "Difficulty:";
			//
			// lblSkillPoints
			//
			this.lblSkillPoints.AutoSize = true;
			this.lblSkillPoints.Location = new System.Drawing.Point(8, 72);
			this.lblSkillPoints.Name = "lblSkillPoints";
			this.lblSkillPoints.Size = new System.Drawing.Size(63, 13);
			this.lblSkillPoints.TabIndex = 35;
			this.lblSkillPoints.Text = "Skill Points:";
			//
			// lblPilot
			//
			this.lblPilot.AutoSize = true;
			this.lblPilot.Location = new System.Drawing.Point(16, 96);
			this.lblPilot.Name = "lblPilot";
			this.lblPilot.Size = new System.Drawing.Size(29, 13);
			this.lblPilot.TabIndex = 36;
			this.lblPilot.Text = "Pilot:";
			//
			// lblFighter
			//
			this.lblFighter.AutoSize = true;
			this.lblFighter.Location = new System.Drawing.Point(16, 120);
			this.lblFighter.Name = "lblFighter";
			this.lblFighter.Size = new System.Drawing.Size(43, 13);
			this.lblFighter.TabIndex = 37;
			this.lblFighter.Text = "Fighter:";
			//
			// lblTrader
			//
			this.lblTrader.AutoSize = true;
			this.lblTrader.Location = new System.Drawing.Point(16, 144);
			this.lblTrader.Name = "lblTrader";
			this.lblTrader.Size = new System.Drawing.Size(41, 13);
			this.lblTrader.TabIndex = 38;
			this.lblTrader.Text = "Trader:";
			//
			// lblEngineer
			//
			this.lblEngineer.AutoSize = true;
			this.lblEngineer.Location = new System.Drawing.Point(16, 168);
			this.lblEngineer.Name = "lblEngineer";
			this.lblEngineer.Size = new System.Drawing.Size(53, 13);
			this.lblEngineer.TabIndex = 39;
			this.lblEngineer.Text = "Engineer:";
			//
			// selDifficulty
			//
			this.selDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.selDifficulty.Items.AddRange(new object[] {
																											 "Beginner",
																											 "Easy",
																											 "Normal",
																											 "Hard",
																											 "Impossible"});
			this.selDifficulty.Location = new System.Drawing.Point(72, 37);
			this.selDifficulty.Name = "selDifficulty";
			this.selDifficulty.Size = new System.Drawing.Size(120, 21);
			this.selDifficulty.TabIndex = 2;
			//
			// numPilot
			//
			this.numPilot.Location = new System.Drawing.Point(72, 94);
			this.numPilot.Maximum = new System.Decimal(new int[] {
																														 10,
																														 0,
																														 0,
																														 0});
			this.numPilot.Minimum = new System.Decimal(new int[] {
																														 1,
																														 0,
																														 0,
																														 0});
			this.numPilot.Name = "numPilot";
			this.numPilot.Size = new System.Drawing.Size(36, 20);
			this.numPilot.TabIndex = 3;
			this.numPilot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numPilot.Value = new System.Decimal(new int[] {
																													 1,
																													 0,
																													 0,
																													 0});
			this.numPilot.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numPilot.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			this.numPilot.Leave += new System.EventHandler(this.num_ValueChanged);
			//
			// numFighter
			//
			this.numFighter.Location = new System.Drawing.Point(72, 118);
			this.numFighter.Maximum = new System.Decimal(new int[] {
																															 10,
																															 0,
																															 0,
																															 0});
			this.numFighter.Minimum = new System.Decimal(new int[] {
																															 1,
																															 0,
																															 0,
																															 0});
			this.numFighter.Name = "numFighter";
			this.numFighter.Size = new System.Drawing.Size(36, 20);
			this.numFighter.TabIndex = 4;
			this.numFighter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numFighter.Value = new System.Decimal(new int[] {
																														 1,
																														 0,
																														 0,
																														 0});
			this.numFighter.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numFighter.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			this.numFighter.Leave += new System.EventHandler(this.num_ValueChanged);
			//
			// numTrader
			//
			this.numTrader.Location = new System.Drawing.Point(72, 142);
			this.numTrader.Maximum = new System.Decimal(new int[] {
																															10,
																															0,
																															0,
																															0});
			this.numTrader.Minimum = new System.Decimal(new int[] {
																															1,
																															0,
																															0,
																															0});
			this.numTrader.Name = "numTrader";
			this.numTrader.Size = new System.Drawing.Size(36, 20);
			this.numTrader.TabIndex = 5;
			this.numTrader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numTrader.Value = new System.Decimal(new int[] {
																														1,
																														0,
																														0,
																														0});
			this.numTrader.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numTrader.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			this.numTrader.Leave += new System.EventHandler(this.num_ValueChanged);
			//
			// numEngineer
			//
			this.numEngineer.Location = new System.Drawing.Point(72, 166);
			this.numEngineer.Maximum = new System.Decimal(new int[] {
																																10,
																																0,
																																0,
																																0});
			this.numEngineer.Minimum = new System.Decimal(new int[] {
																																1,
																																0,
																																0,
																																0});
			this.numEngineer.Name = "numEngineer";
			this.numEngineer.Size = new System.Drawing.Size(36, 20);
			this.numEngineer.TabIndex = 6;
			this.numEngineer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numEngineer.Value = new System.Decimal(new int[] {
																															1,
																															0,
																															0,
																															0});
			this.numEngineer.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numEngineer.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			this.numEngineer.Leave += new System.EventHandler(this.num_ValueChanged);
			//
			// btnOk
			//
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Enabled = false;
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOk.Location = new System.Drawing.Point(83, 200);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(36, 22);
			this.btnOk.TabIndex = 7;
			this.btnOk.Text = "Ok";
			//
			// lblPointsRemaining
			//
			this.lblPointsRemaining.AutoSize = true;
			this.lblPointsRemaining.Location = new System.Drawing.Point(91, 72);
			this.lblPointsRemaining.Name = "lblPointsRemaining";
			this.lblPointsRemaining.Size = new System.Drawing.Size(90, 13);
			this.lblPointsRemaining.TabIndex = 40;
			this.lblPointsRemaining.Text = "points remaining.";
			//
			// lblPoints
			//
			this.lblPoints.Location = new System.Drawing.Point(73, 72);
			this.lblPoints.Name = "lblPoints";
			this.lblPoints.Size = new System.Drawing.Size(17, 13);
			this.lblPoints.TabIndex = 41;
			this.lblPoints.Text = "16";
			this.lblPoints.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// FormNewCommander
			//
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(202, 231);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.lblPoints,
																																	this.lblPointsRemaining,
																																	this.lblEngineer,
																																	this.lblTrader,
																																	this.lblFighter,
																																	this.lblPilot,
																																	this.lblSkillPoints,
																																	this.lblDifficulty,
																																	this.lblName,
																																	this.btnOk,
																																	this.numEngineer,
																																	this.numTrader,
																																	this.numFighter,
																																	this.numPilot,
																																	this.selDifficulty,
																																	this.btnClose,
																																	this.txtName});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormNewCommander";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Commander";
			((System.ComponentModel.ISupportInitialize)(this.numPilot)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numFighter)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numTrader)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numEngineer)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void UpdateOkEnabled()
		{
			btnOk.Enabled	= (lblPoints.Text == "0" && txtName.Text.Length > 0);
		}

		#endregion

		#region Event Handlers

		private void num_ValueChanged(object sender, System.EventArgs e)
		{
			int	points					= 20 - (Pilot + Fighter + Trader + Engineer);
			lblPoints.Text			= points.ToString();
			numPilot.Maximum		= Math.Min(10, Pilot + points);
			numFighter.Maximum	= Math.Min(10, Fighter + points);
			numTrader.Maximum		= Math.Min(10, Trader + points);
			numEngineer.Maximum	= Math.Min(10, Engineer + points);

			UpdateOkEnabled();
		}

		private void num_ValueEnter(object sender, System.EventArgs e)
		{
			((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Value.ToString().Length);
		}

		private void txtName_TextChanged(object sender, System.EventArgs e)
		{
			UpdateOkEnabled();
		}

		#endregion

		#region Properties

		public string CommanderName
		{
			get
			{
				return txtName.Text;
			}
		}

		public Difficulty Difficulty
		{
			get
			{
				return (Difficulty)selDifficulty.SelectedIndex;
			}
		}

		public int Pilot
		{
			get
			{
				return (int)numPilot.Value;
			}
		}

		public int Fighter
		{
			get
			{
				return (int)numFighter.Value;
			}
		}

		public int Trader
		{
			get
			{
				return (int)numTrader.Value;
			}
		}

		public int Engineer
		{
			get
			{
				return (int)numEngineer.Value;
			}
		}

		#endregion
	}
}
