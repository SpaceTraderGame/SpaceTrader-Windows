/*******************************************************************************
 *
 * Space Trader for Windows 2.00
 *
 * Copyright (C) 2004 Jay French, All Rights Reserved
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
	public class FormViewPersonnel : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.GroupBox boxCurrent;
		private System.Windows.Forms.GroupBox boxForHire;
		private System.Windows.Forms.Label lblEngineer0;
		private System.Windows.Forms.Label lblTrader0;
		private System.Windows.Forms.Label lblFighter0;
		private System.Windows.Forms.Label lblPilot0;
		private System.Windows.Forms.Label lblEngineerLabel0;
		private System.Windows.Forms.Label lblTraderLabel0;
		private System.Windows.Forms.Label lblFighterLabel0;
		private System.Windows.Forms.Label lblPilotLabel0;
		private System.Windows.Forms.Label lblName0;
		private System.Windows.Forms.Label lblRate0;
		private System.Windows.Forms.Label lblName1;
		private System.Windows.Forms.Label lblTrader1;
		private System.Windows.Forms.Label lblPilot1;
		private System.Windows.Forms.Label lblTraderLabel1;
		private System.Windows.Forms.Label lblPilotLabel1;
		private System.Windows.Forms.Label lblRate1;
		private System.Windows.Forms.Label lblEngineer1;
		private System.Windows.Forms.Label lblFighter1;
		private System.Windows.Forms.Label lblEngineerLabel1;
		private System.Windows.Forms.Label lblFighterLabel1;
		private System.Windows.Forms.Button btnFire0;
		private System.Windows.Forms.Button btnFire1;
		private System.Windows.Forms.PictureBox picLine1;
		private System.Windows.Forms.Button btnHire2;
		private System.Windows.Forms.Label lblRate2;
		private System.Windows.Forms.Label lblName2;
		private System.Windows.Forms.Label lblEngineer2;
		private System.Windows.Forms.Label lblTrader2;
		private System.Windows.Forms.Label lblFighter2;
		private System.Windows.Forms.Label lblPilot2;
		private System.Windows.Forms.Label lblEngineerLabel2;
		private System.Windows.Forms.Label lblTraderLabel2;
		private System.Windows.Forms.Label lblFighterLabel2;
		private System.Windows.Forms.Label lblPilotLabel2;
		private System.Windows.Forms.Label lblStatus2;
		private System.Windows.Forms.Label lblStatus0;
		private System.Windows.Forms.Label lblStatus1;
		private System.ComponentModel.Container components = null;

		private Label[]		lblStatus;
		private Label[]		lblName;
		private Label[]		lblRate;
		private Label[]		lblPilotLabel;
		private Label[]		lblFighterLabel;
		private Label[]		lblTraderLabel;
		private Label[]		lblEngineerLabel;
		private Label[]		lblPilot;
		private Label[]		lblFighter;
		private Label[]		lblTrader;
		private Label[]		lblEngineer;
		private Button[]	btnFire;

		#endregion

		#region Member Declarations

		private Game			game	= Game.CurrentGame;

		#endregion

		#region Methods

		public FormViewPersonnel()
		{
			InitializeComponent();

			#region Arrays of Personnel controls
			lblStatus	= new Label[]
			{
				lblStatus0,
				lblStatus1
			};

			lblName	= new Label[]
			{
				lblName0,
				lblName1
			};

			lblRate	= new Label[]
			{
				lblRate0,
				lblRate1
			};

			lblPilotLabel	= new Label[]
			{
				lblPilotLabel0,
				lblPilotLabel1
			};

			lblFighterLabel	= new Label[]
			{
				lblFighterLabel0,
				lblFighterLabel1
			};

			lblTraderLabel	= new Label[]
			{
				lblTraderLabel0,
				lblTraderLabel1
			};

			lblEngineerLabel	= new Label[]
			{
				lblEngineerLabel0,
				lblEngineerLabel1
			};

			lblPilot	= new Label[]
			{
				lblPilot0,
				lblPilot1
			};

			lblFighter	= new Label[]
			{
				lblFighter0,
				lblFighter1
			};

			lblTrader	= new Label[]
			{
				lblTrader0,
				lblTrader1
			};

			lblEngineer	= new Label[]
			{
				lblEngineer0,
				lblEngineer1
			};

			btnFire	= new Button[]
			{
				btnFire0,
				btnFire1
			};
			#endregion

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
			this.btnClose = new System.Windows.Forms.Button();
			this.boxCurrent = new System.Windows.Forms.GroupBox();
			this.picLine1 = new System.Windows.Forms.PictureBox();
			this.btnFire1 = new System.Windows.Forms.Button();
			this.btnFire0 = new System.Windows.Forms.Button();
			this.lblRate1 = new System.Windows.Forms.Label();
			this.lblName1 = new System.Windows.Forms.Label();
			this.lblEngineer1 = new System.Windows.Forms.Label();
			this.lblTrader1 = new System.Windows.Forms.Label();
			this.lblFighter1 = new System.Windows.Forms.Label();
			this.lblPilot1 = new System.Windows.Forms.Label();
			this.lblEngineerLabel1 = new System.Windows.Forms.Label();
			this.lblTraderLabel1 = new System.Windows.Forms.Label();
			this.lblFighterLabel1 = new System.Windows.Forms.Label();
			this.lblPilotLabel1 = new System.Windows.Forms.Label();
			this.lblRate0 = new System.Windows.Forms.Label();
			this.lblName0 = new System.Windows.Forms.Label();
			this.lblEngineer0 = new System.Windows.Forms.Label();
			this.lblTrader0 = new System.Windows.Forms.Label();
			this.lblFighter0 = new System.Windows.Forms.Label();
			this.lblPilot0 = new System.Windows.Forms.Label();
			this.lblEngineerLabel0 = new System.Windows.Forms.Label();
			this.lblTraderLabel0 = new System.Windows.Forms.Label();
			this.lblFighterLabel0 = new System.Windows.Forms.Label();
			this.lblPilotLabel0 = new System.Windows.Forms.Label();
			this.boxForHire = new System.Windows.Forms.GroupBox();
			this.btnHire2 = new System.Windows.Forms.Button();
			this.lblRate2 = new System.Windows.Forms.Label();
			this.lblName2 = new System.Windows.Forms.Label();
			this.lblEngineer2 = new System.Windows.Forms.Label();
			this.lblTrader2 = new System.Windows.Forms.Label();
			this.lblFighter2 = new System.Windows.Forms.Label();
			this.lblPilot2 = new System.Windows.Forms.Label();
			this.lblEngineerLabel2 = new System.Windows.Forms.Label();
			this.lblTraderLabel2 = new System.Windows.Forms.Label();
			this.lblFighterLabel2 = new System.Windows.Forms.Label();
			this.lblPilotLabel2 = new System.Windows.Forms.Label();
			this.lblStatus2 = new System.Windows.Forms.Label();
			this.lblStatus0 = new System.Windows.Forms.Label();
			this.lblStatus1 = new System.Windows.Forms.Label();
			this.boxCurrent.SuspendLayout();
			this.boxForHire.SuspendLayout();
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
			// boxCurrent
			//
			this.boxCurrent.Controls.AddRange(new System.Windows.Forms.Control[] {
																																						 this.picLine1,
																																						 this.btnFire1,
																																						 this.btnFire0,
																																						 this.lblRate1,
																																						 this.lblName1,
																																						 this.lblEngineer1,
																																						 this.lblTrader1,
																																						 this.lblFighter1,
																																						 this.lblPilot1,
																																						 this.lblEngineerLabel1,
																																						 this.lblTraderLabel1,
																																						 this.lblFighterLabel1,
																																						 this.lblPilotLabel1,
																																						 this.lblRate0,
																																						 this.lblName0,
																																						 this.lblEngineer0,
																																						 this.lblTrader0,
																																						 this.lblFighter0,
																																						 this.lblPilot0,
																																						 this.lblEngineerLabel0,
																																						 this.lblTraderLabel0,
																																						 this.lblFighterLabel0,
																																						 this.lblPilotLabel0,
																																						 this.lblStatus0,
																																						 this.lblStatus1});
			this.boxCurrent.Location = new System.Drawing.Point(8, 8);
			this.boxCurrent.Name = "boxCurrent";
			this.boxCurrent.Size = new System.Drawing.Size(200, 136);
			this.boxCurrent.TabIndex = 33;
			this.boxCurrent.TabStop = false;
			this.boxCurrent.Text = "Current Roster";
			//
			// picLine1
			//
			this.picLine1.BackColor = System.Drawing.Color.DimGray;
			this.picLine1.Location = new System.Drawing.Point(8, 70);
			this.picLine1.Name = "picLine1";
			this.picLine1.Size = new System.Drawing.Size(184, 1);
			this.picLine1.TabIndex = 132;
			this.picLine1.TabStop = false;
			//
			// btnFire1
			//
			this.btnFire1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFire1.Location = new System.Drawing.Point(152, 80);
			this.btnFire1.Name = "btnFire1";
			this.btnFire1.Size = new System.Drawing.Size(36, 22);
			this.btnFire1.TabIndex = 2;
			this.btnFire1.Text = "Fire";
			this.btnFire1.Click += new System.EventHandler(this.btnFire1_Click);
			//
			// btnFire0
			//
			this.btnFire0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFire0.Location = new System.Drawing.Point(152, 16);
			this.btnFire0.Name = "btnFire0";
			this.btnFire0.Size = new System.Drawing.Size(36, 22);
			this.btnFire0.TabIndex = 1;
			this.btnFire0.Text = "Fire";
			this.btnFire0.Click += new System.EventHandler(this.btnFire0_Click);
			//
			// lblRate1
			//
			this.lblRate1.Location = new System.Drawing.Point(90, 80);
			this.lblRate1.Name = "lblRate1";
			this.lblRate1.Size = new System.Drawing.Size(59, 13);
			this.lblRate1.TabIndex = 76;
			this.lblRate1.Text = "88 cr. daily";
			//
			// lblName1
			//
			this.lblName1.Location = new System.Drawing.Point(12, 80);
			this.lblName1.Name = "lblName1";
			this.lblName1.Size = new System.Drawing.Size(72, 13);
			this.lblName1.TabIndex = 75;
			this.lblName1.Text = "Xxxxxxxxxxx";
			//
			// lblEngineer1
			//
			this.lblEngineer1.Location = new System.Drawing.Point(128, 112);
			this.lblEngineer1.Name = "lblEngineer1";
			this.lblEngineer1.Size = new System.Drawing.Size(17, 13);
			this.lblEngineer1.TabIndex = 74;
			this.lblEngineer1.Text = "88";
			//
			// lblTrader1
			//
			this.lblTrader1.Location = new System.Drawing.Point(52, 112);
			this.lblTrader1.Name = "lblTrader1";
			this.lblTrader1.Size = new System.Drawing.Size(17, 13);
			this.lblTrader1.TabIndex = 73;
			this.lblTrader1.Text = "88";
			//
			// lblFighter1
			//
			this.lblFighter1.Location = new System.Drawing.Point(128, 96);
			this.lblFighter1.Name = "lblFighter1";
			this.lblFighter1.Size = new System.Drawing.Size(17, 13);
			this.lblFighter1.TabIndex = 72;
			this.lblFighter1.Text = "88";
			//
			// lblPilot1
			//
			this.lblPilot1.Location = new System.Drawing.Point(52, 96);
			this.lblPilot1.Name = "lblPilot1";
			this.lblPilot1.Size = new System.Drawing.Size(17, 13);
			this.lblPilot1.TabIndex = 71;
			this.lblPilot1.Text = "88";
			//
			// lblEngineerLabel1
			//
			this.lblEngineerLabel1.AutoSize = true;
			this.lblEngineerLabel1.Location = new System.Drawing.Point(76, 112);
			this.lblEngineerLabel1.Name = "lblEngineerLabel1";
			this.lblEngineerLabel1.Size = new System.Drawing.Size(53, 13);
			this.lblEngineerLabel1.TabIndex = 70;
			this.lblEngineerLabel1.Text = "Engineer:";
			//
			// lblTraderLabel1
			//
			this.lblTraderLabel1.AutoSize = true;
			this.lblTraderLabel1.Location = new System.Drawing.Point(12, 112);
			this.lblTraderLabel1.Name = "lblTraderLabel1";
			this.lblTraderLabel1.Size = new System.Drawing.Size(41, 13);
			this.lblTraderLabel1.TabIndex = 69;
			this.lblTraderLabel1.Text = "Trader:";
			//
			// lblFighterLabel1
			//
			this.lblFighterLabel1.AutoSize = true;
			this.lblFighterLabel1.Location = new System.Drawing.Point(76, 96);
			this.lblFighterLabel1.Name = "lblFighterLabel1";
			this.lblFighterLabel1.Size = new System.Drawing.Size(43, 13);
			this.lblFighterLabel1.TabIndex = 68;
			this.lblFighterLabel1.Text = "Fighter:";
			//
			// lblPilotLabel1
			//
			this.lblPilotLabel1.AutoSize = true;
			this.lblPilotLabel1.Location = new System.Drawing.Point(12, 96);
			this.lblPilotLabel1.Name = "lblPilotLabel1";
			this.lblPilotLabel1.Size = new System.Drawing.Size(29, 13);
			this.lblPilotLabel1.TabIndex = 67;
			this.lblPilotLabel1.Text = "Pilot:";
			//
			// lblRate0
			//
			this.lblRate0.Location = new System.Drawing.Point(90, 16);
			this.lblRate0.Name = "lblRate0";
			this.lblRate0.Size = new System.Drawing.Size(59, 13);
			this.lblRate0.TabIndex = 66;
			this.lblRate0.Text = "88 cr. daily";
			//
			// lblName0
			//
			this.lblName0.Location = new System.Drawing.Point(12, 16);
			this.lblName0.Name = "lblName0";
			this.lblName0.Size = new System.Drawing.Size(72, 13);
			this.lblName0.TabIndex = 65;
			this.lblName0.Text = "Xxxxxxxxxxx";
			//
			// lblEngineer0
			//
			this.lblEngineer0.Location = new System.Drawing.Point(128, 48);
			this.lblEngineer0.Name = "lblEngineer0";
			this.lblEngineer0.Size = new System.Drawing.Size(17, 13);
			this.lblEngineer0.TabIndex = 64;
			this.lblEngineer0.Text = "88";
			//
			// lblTrader0
			//
			this.lblTrader0.Location = new System.Drawing.Point(52, 48);
			this.lblTrader0.Name = "lblTrader0";
			this.lblTrader0.Size = new System.Drawing.Size(17, 13);
			this.lblTrader0.TabIndex = 63;
			this.lblTrader0.Text = "88";
			//
			// lblFighter0
			//
			this.lblFighter0.Location = new System.Drawing.Point(128, 32);
			this.lblFighter0.Name = "lblFighter0";
			this.lblFighter0.Size = new System.Drawing.Size(17, 13);
			this.lblFighter0.TabIndex = 62;
			this.lblFighter0.Text = "88";
			//
			// lblPilot0
			//
			this.lblPilot0.Location = new System.Drawing.Point(52, 32);
			this.lblPilot0.Name = "lblPilot0";
			this.lblPilot0.Size = new System.Drawing.Size(17, 13);
			this.lblPilot0.TabIndex = 61;
			this.lblPilot0.Text = "88";
			//
			// lblEngineerLabel0
			//
			this.lblEngineerLabel0.AutoSize = true;
			this.lblEngineerLabel0.Location = new System.Drawing.Point(76, 48);
			this.lblEngineerLabel0.Name = "lblEngineerLabel0";
			this.lblEngineerLabel0.Size = new System.Drawing.Size(53, 13);
			this.lblEngineerLabel0.TabIndex = 60;
			this.lblEngineerLabel0.Text = "Engineer:";
			//
			// lblTraderLabel0
			//
			this.lblTraderLabel0.AutoSize = true;
			this.lblTraderLabel0.Location = new System.Drawing.Point(12, 48);
			this.lblTraderLabel0.Name = "lblTraderLabel0";
			this.lblTraderLabel0.Size = new System.Drawing.Size(41, 13);
			this.lblTraderLabel0.TabIndex = 59;
			this.lblTraderLabel0.Text = "Trader:";
			//
			// lblFighterLabel0
			//
			this.lblFighterLabel0.AutoSize = true;
			this.lblFighterLabel0.Location = new System.Drawing.Point(76, 32);
			this.lblFighterLabel0.Name = "lblFighterLabel0";
			this.lblFighterLabel0.Size = new System.Drawing.Size(43, 13);
			this.lblFighterLabel0.TabIndex = 58;
			this.lblFighterLabel0.Text = "Fighter:";
			//
			// lblPilotLabel0
			//
			this.lblPilotLabel0.AutoSize = true;
			this.lblPilotLabel0.Location = new System.Drawing.Point(12, 32);
			this.lblPilotLabel0.Name = "lblPilotLabel0";
			this.lblPilotLabel0.Size = new System.Drawing.Size(29, 13);
			this.lblPilotLabel0.TabIndex = 57;
			this.lblPilotLabel0.Text = "Pilot:";
			//
			// boxForHire
			//
			this.boxForHire.Controls.AddRange(new System.Windows.Forms.Control[] {
																																						 this.btnHire2,
																																						 this.lblRate2,
																																						 this.lblName2,
																																						 this.lblEngineer2,
																																						 this.lblTrader2,
																																						 this.lblFighter2,
																																						 this.lblPilot2,
																																						 this.lblEngineerLabel2,
																																						 this.lblTraderLabel2,
																																						 this.lblFighterLabel2,
																																						 this.lblPilotLabel2,
																																						 this.lblStatus2});
			this.boxForHire.Location = new System.Drawing.Point(216, 8);
			this.boxForHire.Name = "boxForHire";
			this.boxForHire.Size = new System.Drawing.Size(200, 136);
			this.boxForHire.TabIndex = 34;
			this.boxForHire.TabStop = false;
			this.boxForHire.Text = "Mercenary For Hire";
			//
			// btnHire2
			//
			this.btnHire2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHire2.Location = new System.Drawing.Point(152, 16);
			this.btnHire2.Name = "btnHire2";
			this.btnHire2.Size = new System.Drawing.Size(36, 22);
			this.btnHire2.TabIndex = 4;
			this.btnHire2.Text = "Hire";
			this.btnHire2.Click += new System.EventHandler(this.btnHire2_Click);
			//
			// lblRate2
			//
			this.lblRate2.Location = new System.Drawing.Point(90, 16);
			this.lblRate2.Name = "lblRate2";
			this.lblRate2.Size = new System.Drawing.Size(59, 13);
			this.lblRate2.TabIndex = 97;
			this.lblRate2.Text = "88 cr. daily";
			//
			// lblName2
			//
			this.lblName2.Location = new System.Drawing.Point(12, 16);
			this.lblName2.Name = "lblName2";
			this.lblName2.Size = new System.Drawing.Size(72, 13);
			this.lblName2.TabIndex = 96;
			this.lblName2.Text = "Xxxxxxxxxxx";
			//
			// lblEngineer2
			//
			this.lblEngineer2.Location = new System.Drawing.Point(128, 48);
			this.lblEngineer2.Name = "lblEngineer2";
			this.lblEngineer2.Size = new System.Drawing.Size(17, 13);
			this.lblEngineer2.TabIndex = 95;
			this.lblEngineer2.Text = "88";
			//
			// lblTrader2
			//
			this.lblTrader2.Location = new System.Drawing.Point(52, 48);
			this.lblTrader2.Name = "lblTrader2";
			this.lblTrader2.Size = new System.Drawing.Size(17, 13);
			this.lblTrader2.TabIndex = 94;
			this.lblTrader2.Text = "88";
			//
			// lblFighter2
			//
			this.lblFighter2.Location = new System.Drawing.Point(128, 32);
			this.lblFighter2.Name = "lblFighter2";
			this.lblFighter2.Size = new System.Drawing.Size(17, 13);
			this.lblFighter2.TabIndex = 93;
			this.lblFighter2.Text = "88";
			//
			// lblPilot2
			//
			this.lblPilot2.Location = new System.Drawing.Point(52, 32);
			this.lblPilot2.Name = "lblPilot2";
			this.lblPilot2.Size = new System.Drawing.Size(17, 13);
			this.lblPilot2.TabIndex = 92;
			this.lblPilot2.Text = "88";
			//
			// lblEngineerLabel2
			//
			this.lblEngineerLabel2.AutoSize = true;
			this.lblEngineerLabel2.Location = new System.Drawing.Point(76, 48);
			this.lblEngineerLabel2.Name = "lblEngineerLabel2";
			this.lblEngineerLabel2.Size = new System.Drawing.Size(53, 13);
			this.lblEngineerLabel2.TabIndex = 91;
			this.lblEngineerLabel2.Text = "Engineer:";
			//
			// lblTraderLabel2
			//
			this.lblTraderLabel2.AutoSize = true;
			this.lblTraderLabel2.Location = new System.Drawing.Point(12, 48);
			this.lblTraderLabel2.Name = "lblTraderLabel2";
			this.lblTraderLabel2.Size = new System.Drawing.Size(41, 13);
			this.lblTraderLabel2.TabIndex = 90;
			this.lblTraderLabel2.Text = "Trader:";
			//
			// lblFighterLabel2
			//
			this.lblFighterLabel2.AutoSize = true;
			this.lblFighterLabel2.Location = new System.Drawing.Point(76, 32);
			this.lblFighterLabel2.Name = "lblFighterLabel2";
			this.lblFighterLabel2.Size = new System.Drawing.Size(43, 13);
			this.lblFighterLabel2.TabIndex = 89;
			this.lblFighterLabel2.Text = "Fighter:";
			//
			// lblPilotLabel2
			//
			this.lblPilotLabel2.AutoSize = true;
			this.lblPilotLabel2.Location = new System.Drawing.Point(12, 32);
			this.lblPilotLabel2.Name = "lblPilotLabel2";
			this.lblPilotLabel2.Size = new System.Drawing.Size(29, 13);
			this.lblPilotLabel2.TabIndex = 88;
			this.lblPilotLabel2.Text = "Pilot:";
			//
			// lblStatus2
			//
			this.lblStatus2.Location = new System.Drawing.Point(12, 32);
			this.lblStatus2.Name = "lblStatus2";
			this.lblStatus2.Size = new System.Drawing.Size(176, 13);
			this.lblStatus2.TabIndex = 98;
			this.lblStatus2.Text = "No one for hire.";
			this.lblStatus2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblStatus2.Visible = false;
			//
			// lblStatus0
			//
			this.lblStatus0.Location = new System.Drawing.Point(12, 32);
			this.lblStatus0.Name = "lblStatus0";
			this.lblStatus0.Size = new System.Drawing.Size(176, 13);
			this.lblStatus0.TabIndex = 133;
			this.lblStatus0.Text = "No quarters available.";
			this.lblStatus0.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblStatus0.Visible = false;
			//
			// lblStatus1
			//
			this.lblStatus1.Location = new System.Drawing.Point(12, 96);
			this.lblStatus1.Name = "lblStatus1";
			this.lblStatus1.Size = new System.Drawing.Size(176, 13);
			this.lblStatus1.TabIndex = 134;
			this.lblStatus1.Text = "No quarters available.";
			this.lblStatus1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblStatus1.Visible = false;
			//
			// FormViewPersonnel
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(424, 151);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.boxForHire,
																																	this.boxCurrent,
																																	this.btnClose});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormViewPersonnel";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Personnel";
			this.boxCurrent.ResumeLayout(false);
			this.boxForHire.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		private void Fire(int crewId)
		{
			Ship					ship	= game.Commander.Ship;
			CrewMember		merc	= game.Commander.CurrentSystem.MercenaryForHire;

			if (FormAlert.Alert(AlertType.CrewFireMercenary, this, ship.Crew[crewId].Name) == DialogResult.Yes)
			{
				ship.Fire(crewId);

				UpdateAll();
				game.ParentWindow.UpdateAll();
			}
		}

		private void UpdateAll()
		{
			CrewMember[]	crew		= game.Commander.Ship.Crew;
			bool					visible;

			for (int i = 0; i < lblName.Length; i++)
			{
				int		crewId								= i + 1;
				visible											= (crewId < crew.Length && crew[crewId] != null);

				lblName[i].Visible					= visible;
				lblRate[i].Visible					= visible;
				lblPilotLabel[i].Visible		= visible;
				lblFighterLabel[i].Visible	= visible;
				lblTraderLabel[i].Visible		= visible;
				lblEngineerLabel[i].Visible	= visible;
				lblPilot[i].Visible					= visible;
				lblFighter[i].Visible				= visible;
				lblTrader[i].Visible				= visible;
				lblEngineer[i].Visible			= visible;
				btnFire[i].Visible					= visible;
				lblStatus[i].Visible				= !visible;

				if (visible)
				{
					lblName[i].Text						= crew[crewId].Name;
					lblRate[i].Text						= Functions.StringVars(Strings.MoneyRateSuffix,
						Functions.FormatMoney(crew[crewId].Rate));
					lblPilot[i].Text					= crew[crewId].Pilot.ToString();
					lblFighter[i].Text				= crew[crewId].Fighter.ToString();
					lblTrader[i].Text					= crew[crewId].Trader.ToString();
					lblEngineer[i].Text				= crew[crewId].Engineer.ToString();

					if (crew[crewId].Id >= CrewMemberId.Wild || crew[crewId].Id == CrewMemberId.Jarek)
					{
						lblRate[i].Visible			= false;
						btnFire[i].Visible			= false;
					}
				}
				else
					lblStatus[i].Text					= (crewId >= crew.Length ? Strings.PersonnelNoQuarters : Strings.PersonnelVacancy);
			}

			CrewMember	merc							= game.Commander.CurrentSystem.MercenaryForHire;
			visible												= (merc != null);

			lblName2.Visible							= visible;
			lblRate2.Visible							= visible;
			lblPilotLabel2.Visible				= visible;
			lblFighterLabel2.Visible			= visible;
			lblTraderLabel2.Visible				= visible;
			lblEngineerLabel2.Visible			= visible;
			lblPilot2.Visible							= visible;
			lblFighter2.Visible						= visible;
			lblTrader2.Visible						= visible;
			lblEngineer2.Visible					= visible;
			btnHire2.Visible							= visible;
			lblStatus2.Visible						= !visible;

			if (visible)
			{
				lblName2.Text								= merc.Name;
				lblRate2.Text								= Functions.StringVars(Strings.MoneyRateSuffix,
					Functions.FormatMoney(merc.Rate));
				lblPilot2.Text							= merc.Pilot.ToString();
				lblFighter2.Text						= merc.Fighter.ToString();
				lblTrader2.Text							= merc.Trader.ToString();
				lblEngineer2.Text						= merc.Engineer.ToString();
			}
			else
				lblStatus2.Text							= Strings.PersonnelNoMercenaries;
		}

		#endregion

		#region Event Handlers

		private void btnFire0_Click(object sender, System.EventArgs e)
		{
			Fire(1);
		}

		private void btnFire1_Click(object sender, System.EventArgs e)
		{
			Fire(2);
		}

		private void btnHire2_Click(object sender, System.EventArgs e)
		{
			Ship					ship	= game.Commander.Ship;
			CrewMember		merc	= game.Commander.CurrentSystem.MercenaryForHire;

			if (ship.FreeCrewQuarters == 0)
				FormAlert.Alert(AlertType.CrewNoQuarters, this, merc.Name);
			else
			{
				ship.Hire(merc);

				UpdateAll();
				game.ParentWindow.UpdateAll();
			}
		}

		#endregion
	}
}
