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
	public class FormViewPersonnel : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.GroupBox boxForHire;
		private System.Windows.Forms.GroupBox boxInfo;
		private System.Windows.Forms.GroupBox boxCurrentCrew;
		private System.Windows.Forms.Button btnHireFire;
		private System.Windows.Forms.Label lblRate;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblEngineer;
		private System.Windows.Forms.Label lblTrader;
		private System.Windows.Forms.Label lblFighter;
		private System.Windows.Forms.Label lblPilot;
		private System.Windows.Forms.Label lblEngineerLabel;
		private System.Windows.Forms.Label lblTraderLabel;
		private System.Windows.Forms.Label lblFighterLabel;
		private System.Windows.Forms.Label lblPilotLabel;
		private System.Windows.Forms.ListBox lstForHire;
		private System.Windows.Forms.ListBox lstCrew;
		private System.Windows.Forms.Label lblCrewNoQuarters;
		private System.Windows.Forms.Label lblForHireNone;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Member Declarations

		private Game				game								= Game.CurrentGame;
		private CrewMember	selectedCrewMember	= null;
		private bool				handlingSelect			= false;

		#endregion

		#region Methods

		public FormViewPersonnel()
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
			this.btnClose = new System.Windows.Forms.Button();
			this.boxCurrentCrew = new System.Windows.Forms.GroupBox();
			this.lstCrew = new System.Windows.Forms.ListBox();
			this.boxForHire = new System.Windows.Forms.GroupBox();
			this.lstForHire = new System.Windows.Forms.ListBox();
			this.boxInfo = new System.Windows.Forms.GroupBox();
			this.btnHireFire = new System.Windows.Forms.Button();
			this.lblRate = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblEngineer = new System.Windows.Forms.Label();
			this.lblTrader = new System.Windows.Forms.Label();
			this.lblFighter = new System.Windows.Forms.Label();
			this.lblPilot = new System.Windows.Forms.Label();
			this.lblEngineerLabel = new System.Windows.Forms.Label();
			this.lblTraderLabel = new System.Windows.Forms.Label();
			this.lblFighterLabel = new System.Windows.Forms.Label();
			this.lblPilotLabel = new System.Windows.Forms.Label();
			this.lblCrewNoQuarters = new System.Windows.Forms.Label();
			this.lblForHireNone = new System.Windows.Forms.Label();
			this.boxCurrentCrew.SuspendLayout();
			this.boxForHire.SuspendLayout();
			this.boxInfo.SuspendLayout();
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
			// boxCurrentCrew
			// 
			this.boxCurrentCrew.Controls.Add(this.lblCrewNoQuarters);
			this.boxCurrentCrew.Controls.Add(this.lstCrew);
			this.boxCurrentCrew.Location = new System.Drawing.Point(8, 8);
			this.boxCurrentCrew.Name = "boxCurrentCrew";
			this.boxCurrentCrew.Size = new System.Drawing.Size(144, 114);
			this.boxCurrentCrew.TabIndex = 33;
			this.boxCurrentCrew.TabStop = false;
			this.boxCurrentCrew.Text = "Current Crew";
			// 
			// lstCrew
			// 
			this.lstCrew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstCrew.Location = new System.Drawing.Point(8, 24);
			this.lstCrew.Name = "lstCrew";
			this.lstCrew.Size = new System.Drawing.Size(126, 80);
			this.lstCrew.TabIndex = 6;
			this.lstCrew.DoubleClick += new System.EventHandler(this.HireFire);
			this.lstCrew.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// boxForHire
			// 
			this.boxForHire.Controls.Add(this.lblForHireNone);
			this.boxForHire.Controls.Add(this.lstForHire);
			this.boxForHire.Location = new System.Drawing.Point(160, 8);
			this.boxForHire.Name = "boxForHire";
			this.boxForHire.Size = new System.Drawing.Size(144, 114);
			this.boxForHire.TabIndex = 34;
			this.boxForHire.TabStop = false;
			this.boxForHire.Text = "Mercenaries For Hire";
			// 
			// lstForHire
			// 
			this.lstForHire.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstForHire.Location = new System.Drawing.Point(8, 24);
			this.lstForHire.Name = "lstForHire";
			this.lstForHire.Size = new System.Drawing.Size(126, 80);
			this.lstForHire.TabIndex = 5;
			this.lstForHire.DoubleClick += new System.EventHandler(this.HireFire);
			this.lstForHire.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// boxInfo
			// 
			this.boxInfo.Controls.Add(this.btnHireFire);
			this.boxInfo.Controls.Add(this.lblRate);
			this.boxInfo.Controls.Add(this.lblName);
			this.boxInfo.Controls.Add(this.lblEngineer);
			this.boxInfo.Controls.Add(this.lblTrader);
			this.boxInfo.Controls.Add(this.lblFighter);
			this.boxInfo.Controls.Add(this.lblPilot);
			this.boxInfo.Controls.Add(this.lblEngineerLabel);
			this.boxInfo.Controls.Add(this.lblTraderLabel);
			this.boxInfo.Controls.Add(this.lblFighterLabel);
			this.boxInfo.Controls.Add(this.lblPilotLabel);
			this.boxInfo.Location = new System.Drawing.Point(312, 8);
			this.boxInfo.Name = "boxInfo";
			this.boxInfo.Size = new System.Drawing.Size(168, 114);
			this.boxInfo.TabIndex = 35;
			this.boxInfo.TabStop = false;
			this.boxInfo.Text = "Mercenary Information";
			// 
			// btnHireFire
			// 
			this.btnHireFire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnHireFire.Location = new System.Drawing.Point(120, 80);
			this.btnHireFire.Name = "btnHireFire";
			this.btnHireFire.Size = new System.Drawing.Size(36, 22);
			this.btnHireFire.TabIndex = 4;
			this.btnHireFire.Text = "Hire";
			this.btnHireFire.Click += new System.EventHandler(this.HireFire);
			// 
			// lblRate
			// 
			this.lblRate.Location = new System.Drawing.Point(104, 40);
			this.lblRate.Name = "lblRate";
			this.lblRate.Size = new System.Drawing.Size(59, 13);
			this.lblRate.TabIndex = 97;
			this.lblRate.Text = "88 cr. daily";
			// 
			// lblName
			// 
			this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblName.Location = new System.Drawing.Point(12, 18);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(72, 13);
			this.lblName.TabIndex = 96;
			this.lblName.Text = "Xxxxxxxxxxx";
			// 
			// lblEngineer
			// 
			this.lblEngineer.Location = new System.Drawing.Point(64, 88);
			this.lblEngineer.Name = "lblEngineer";
			this.lblEngineer.Size = new System.Drawing.Size(17, 13);
			this.lblEngineer.TabIndex = 95;
			this.lblEngineer.Text = "88";
			// 
			// lblTrader
			// 
			this.lblTrader.Location = new System.Drawing.Point(64, 72);
			this.lblTrader.Name = "lblTrader";
			this.lblTrader.Size = new System.Drawing.Size(17, 13);
			this.lblTrader.TabIndex = 94;
			this.lblTrader.Text = "88";
			// 
			// lblFighter
			// 
			this.lblFighter.Location = new System.Drawing.Point(64, 56);
			this.lblFighter.Name = "lblFighter";
			this.lblFighter.Size = new System.Drawing.Size(17, 13);
			this.lblFighter.TabIndex = 93;
			this.lblFighter.Text = "88";
			// 
			// lblPilot
			// 
			this.lblPilot.Location = new System.Drawing.Point(64, 40);
			this.lblPilot.Name = "lblPilot";
			this.lblPilot.Size = new System.Drawing.Size(17, 13);
			this.lblPilot.TabIndex = 92;
			this.lblPilot.Text = "88";
			// 
			// lblEngineerLabel
			// 
			this.lblEngineerLabel.AutoSize = true;
			this.lblEngineerLabel.Location = new System.Drawing.Point(12, 88);
			this.lblEngineerLabel.Name = "lblEngineerLabel";
			this.lblEngineerLabel.Size = new System.Drawing.Size(53, 16);
			this.lblEngineerLabel.TabIndex = 91;
			this.lblEngineerLabel.Text = "Engineer:";
			// 
			// lblTraderLabel
			// 
			this.lblTraderLabel.AutoSize = true;
			this.lblTraderLabel.Location = new System.Drawing.Point(12, 72);
			this.lblTraderLabel.Name = "lblTraderLabel";
			this.lblTraderLabel.Size = new System.Drawing.Size(41, 16);
			this.lblTraderLabel.TabIndex = 90;
			this.lblTraderLabel.Text = "Trader:";
			// 
			// lblFighterLabel
			// 
			this.lblFighterLabel.AutoSize = true;
			this.lblFighterLabel.Location = new System.Drawing.Point(12, 56);
			this.lblFighterLabel.Name = "lblFighterLabel";
			this.lblFighterLabel.Size = new System.Drawing.Size(43, 16);
			this.lblFighterLabel.TabIndex = 89;
			this.lblFighterLabel.Text = "Fighter:";
			// 
			// lblPilotLabel
			// 
			this.lblPilotLabel.AutoSize = true;
			this.lblPilotLabel.Location = new System.Drawing.Point(12, 40);
			this.lblPilotLabel.Name = "lblPilotLabel";
			this.lblPilotLabel.Size = new System.Drawing.Size(29, 16);
			this.lblPilotLabel.TabIndex = 88;
			this.lblPilotLabel.Text = "Pilot:";
			// 
			// lblCrewNoQuarters
			// 
			this.lblCrewNoQuarters.Location = new System.Drawing.Point(16, 24);
			this.lblCrewNoQuarters.Name = "lblCrewNoQuarters";
			this.lblCrewNoQuarters.Size = new System.Drawing.Size(120, 16);
			this.lblCrewNoQuarters.TabIndex = 7;
			this.lblCrewNoQuarters.Text = "No quarters available";
			this.lblCrewNoQuarters.Visible = false;
			// 
			// lblForHireNone
			// 
			this.lblForHireNone.Location = new System.Drawing.Point(16, 24);
			this.lblForHireNone.Name = "lblForHireNone";
			this.lblForHireNone.Size = new System.Drawing.Size(120, 16);
			this.lblForHireNone.TabIndex = 8;
			this.lblForHireNone.Text = "No one for hire";
			this.lblForHireNone.Visible = false;
			// 
			// FormViewPersonnel
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(488, 129);
			this.Controls.Add(this.boxInfo);
			this.Controls.Add(this.boxForHire);
			this.Controls.Add(this.boxCurrentCrew);
			this.Controls.Add(this.btnClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormViewPersonnel";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Personnel";
			this.boxCurrentCrew.ResumeLayout(false);
			this.boxForHire.ResumeLayout(false);
			this.boxInfo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void DeselectAll()
		{
			lstForHire.ClearSelected();
			lstCrew.ClearSelected();
		}

		private void UpdateAll()
		{
			selectedCrewMember	= null;

			UpdateForHire();
			UpdateCurrentCrew();
			UpdateInfo();
		}

		private void UpdateCurrentCrew()
		{
			CrewMember[]	crew				= game.Commander.Ship.Crew;

			lstCrew.Items.Clear();
			for (int i = 1; i < crew.Length; i++)
			{
				if (crew[i] == null)
					lstCrew.Items.Add(Strings.PersonnelVacancy);
				else
					lstCrew.Items.Add(crew[i]);
			}

			bool					entries			= (lstCrew.Items.Count > 0);

			lstCrew.Visible						= entries;
			lblCrewNoQuarters.Visible	= !entries;

			if (entries)
				lstCrew.Height					= lstCrew.ItemHeight * Math.Min(lstCrew.Items.Count, 6) + 2;
			else
				// TODO: remove this when strings are moved to resource.
				lblCrewNoQuarters.Text	= Strings.PersonnelNoQuarters;
		}

		private void UpdateForHire()
		{
			CrewMember[]	mercs			= game.Commander.CurrentSystem.MercenariesForHire;

			lstForHire.Items.Clear();
			for (int i = 0; i < mercs.Length; i++)
				lstForHire.Items.Add(mercs[i]);

			bool					entries		= (lstForHire.Items.Count > 0);

			lstForHire.Visible			= entries;
			lblForHireNone.Visible	= !entries;

			if (entries)
				lstForHire.Height			= lstForHire.ItemHeight * Math.Min(lstForHire.Items.Count, 6) + 2;
			else
				// TODO: remove this when strings are moved to resource.
				lblForHireNone.Text		= Strings.PersonnelNoMercenaries;
		}

		private void UpdateInfo()
		{
			bool	visible							= false;
			bool	rateVisible					= false;
			bool	hireFireVisible			= false;

			if (selectedCrewMember != null)
			{
				visible									= true;
				if (selectedCrewMember.Rate > 0)
					rateVisible						= true;

				lblName.Text						= selectedCrewMember.Name;
				lblRate.Text						= Functions.StringVars(Strings.MoneyRateSuffix,
																	Functions.FormatMoney(selectedCrewMember.Rate));
				lblPilot.Text						= selectedCrewMember.Pilot.ToString();
				lblFighter.Text					= selectedCrewMember.Fighter.ToString();
				lblTrader.Text					= selectedCrewMember.Trader.ToString();
				lblEngineer.Text				= selectedCrewMember.Engineer.ToString();

				btnHireFire.Text				= game.Commander.Ship.HasCrew(selectedCrewMember.Id) ? Strings.MercenaryFire :
																	Strings.MercenaryHire;
				hireFireVisible					= rateVisible || selectedCrewMember.Id == CrewMemberId.Zeethibal;
			}

			lblName.Visible						= visible;
			lblRate.Visible						= rateVisible;
			lblPilotLabel.Visible			= visible;
			lblFighterLabel.Visible		= visible;
			lblTraderLabel.Visible		= visible;
			lblEngineerLabel.Visible	= visible;
			lblPilot.Visible					= visible;
			lblFighter.Visible				= visible;
			lblTrader.Visible					= visible;
			lblEngineer.Visible				= visible;
			btnHireFire.Visible				= hireFireVisible;
		}

		#endregion

		#region Event Handlers

		private void HireFire(object sender, System.EventArgs e)
		{
			if (selectedCrewMember != null && btnHireFire.Visible)
			{
				if (game.Commander.Ship.HasCrew(selectedCrewMember.Id))
				{
					if (FormAlert.Alert(AlertType.CrewFireMercenary, this, selectedCrewMember.Name) == DialogResult.Yes)
					{
						game.Commander.Ship.Fire(selectedCrewMember.Id);

						UpdateAll();
						game.ParentWindow.UpdateAll();
					}
				}
				else
				{
					if (game.Commander.Ship.FreeCrewQuarters == 0)
						FormAlert.Alert(AlertType.CrewNoQuarters, this, selectedCrewMember.Name);
					else
					{
						game.Commander.Ship.Hire(selectedCrewMember);

						UpdateAll();
						game.ParentWindow.UpdateAll();
					}
				}
			}
		}

		private void SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (!handlingSelect)
			{
				handlingSelect	= true;

				object obj			= ((ListBox)sender).SelectedItem;
				DeselectAll();

				if (typeof(CrewMember).IsInstanceOfType(obj))
				{
					((ListBox)sender).SelectedItem	= obj;
					selectedCrewMember							= (CrewMember)obj;
				}
				else
					selectedCrewMember							= null;

				handlingSelect	= false;
				UpdateInfo();
			}
		}

		#endregion
	}
}
