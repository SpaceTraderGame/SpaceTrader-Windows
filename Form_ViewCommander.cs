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
	public class FormViewCommander : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblNameLabel;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblDifficulty;
		private System.Windows.Forms.Label lblTimeLabel;
		private System.Windows.Forms.Label lblCashLabel;
		private System.Windows.Forms.Label lblDebtLabel;
		private System.Windows.Forms.Label lblNetWorthLabel;
		private System.Windows.Forms.Label lblDifficultyLabel;
		private System.Windows.Forms.Label lblTime;
		private System.Windows.Forms.GroupBox boxSkills;
		private System.Windows.Forms.Label lblEngineer;
		private System.Windows.Forms.Label lblTrader;
		private System.Windows.Forms.Label lblFighter;
		private System.Windows.Forms.Label lblPilot;
		private System.Windows.Forms.Label lblEngineerLabel;
		private System.Windows.Forms.Label lblTraderLabel;
		private System.Windows.Forms.Label lblFighterLabel;
		private System.Windows.Forms.Label lblPilotLabel;
		private System.Windows.Forms.GroupBox boxFinances;
		private System.Windows.Forms.Label lblNetWorth;
		private System.Windows.Forms.Label lblDebt;
		private System.Windows.Forms.Label lblCash;
		private System.Windows.Forms.Label lblKills;
		private System.Windows.Forms.Label lblReputation;
		private System.Windows.Forms.Label lblRecord;
		private System.Windows.Forms.Label lblPoliceLabel;
		private System.Windows.Forms.Label lblReputationLabel;
		private System.Windows.Forms.Label lblKillsLabel;
		private System.Windows.Forms.GroupBox boxNotoriety;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label lblBountyLabel;
		private System.Windows.Forms.Label lblBounty;
		#endregion

		#region Member Declarations

		private Game	game	= Game.CurrentGame;

		#endregion

		#region Methods

		public FormViewCommander()
		{
			InitializeComponent();

			InitializeScreen();
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
			this.lblNameLabel = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblDifficulty = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblTimeLabel = new System.Windows.Forms.Label();
			this.lblCashLabel = new System.Windows.Forms.Label();
			this.lblDebtLabel = new System.Windows.Forms.Label();
			this.lblNetWorthLabel = new System.Windows.Forms.Label();
			this.lblDifficultyLabel = new System.Windows.Forms.Label();
			this.lblTime = new System.Windows.Forms.Label();
			this.boxSkills = new System.Windows.Forms.GroupBox();
			this.lblEngineer = new System.Windows.Forms.Label();
			this.lblTrader = new System.Windows.Forms.Label();
			this.lblFighter = new System.Windows.Forms.Label();
			this.lblPilot = new System.Windows.Forms.Label();
			this.lblEngineerLabel = new System.Windows.Forms.Label();
			this.lblTraderLabel = new System.Windows.Forms.Label();
			this.lblFighterLabel = new System.Windows.Forms.Label();
			this.lblPilotLabel = new System.Windows.Forms.Label();
			this.boxFinances = new System.Windows.Forms.GroupBox();
			this.lblCash = new System.Windows.Forms.Label();
			this.lblDebt = new System.Windows.Forms.Label();
			this.lblNetWorth = new System.Windows.Forms.Label();
			this.boxNotoriety = new System.Windows.Forms.GroupBox();
			this.lblPoliceLabel = new System.Windows.Forms.Label();
			this.lblReputationLabel = new System.Windows.Forms.Label();
			this.lblKillsLabel = new System.Windows.Forms.Label();
			this.lblKills = new System.Windows.Forms.Label();
			this.lblReputation = new System.Windows.Forms.Label();
			this.lblRecord = new System.Windows.Forms.Label();
			this.lblBountyLabel = new System.Windows.Forms.Label();
			this.lblBounty = new System.Windows.Forms.Label();
			this.boxSkills.SuspendLayout();
			this.boxFinances.SuspendLayout();
			this.boxNotoriety.SuspendLayout();
			this.SuspendLayout();
			//
			// lblNameLabel
			//
			this.lblNameLabel.AutoSize = true;
			this.lblNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNameLabel.Location = new System.Drawing.Point(8, 8);
			this.lblNameLabel.Name = "lblNameLabel";
			this.lblNameLabel.Size = new System.Drawing.Size(39, 16);
			this.lblNameLabel.TabIndex = 2;
			this.lblNameLabel.Text = "Name:";
			//
			// lblName
			//
			this.lblName.Location = new System.Drawing.Point(69, 8);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(155, 13);
			this.lblName.TabIndex = 4;
			this.lblName.Text = "XXXXXXXXXXXXXXXXXX";
			//
			// lblDifficulty
			//
			this.lblDifficulty.Location = new System.Drawing.Point(69, 24);
			this.lblDifficulty.Name = "lblDifficulty";
			this.lblDifficulty.Size = new System.Drawing.Size(58, 13);
			this.lblDifficulty.TabIndex = 5;
			this.lblDifficulty.Text = "Impossible";
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
			// lblTimeLabel
			//
			this.lblTimeLabel.AutoSize = true;
			this.lblTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTimeLabel.Location = new System.Drawing.Point(8, 40);
			this.lblTimeLabel.Name = "lblTimeLabel";
			this.lblTimeLabel.Size = new System.Drawing.Size(34, 16);
			this.lblTimeLabel.TabIndex = 37;
			this.lblTimeLabel.Text = "Time:";
			//
			// lblCashLabel
			//
			this.lblCashLabel.AutoSize = true;
			this.lblCashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCashLabel.Location = new System.Drawing.Point(8, 16);
			this.lblCashLabel.Name = "lblCashLabel";
			this.lblCashLabel.Size = new System.Drawing.Size(35, 16);
			this.lblCashLabel.TabIndex = 38;
			this.lblCashLabel.Text = "Cash:";
			//
			// lblDebtLabel
			//
			this.lblDebtLabel.AutoSize = true;
			this.lblDebtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDebtLabel.Location = new System.Drawing.Point(8, 32);
			this.lblDebtLabel.Name = "lblDebtLabel";
			this.lblDebtLabel.Size = new System.Drawing.Size(32, 16);
			this.lblDebtLabel.TabIndex = 39;
			this.lblDebtLabel.Text = "Debt:";
			//
			// lblNetWorthLabel
			//
			this.lblNetWorthLabel.AutoSize = true;
			this.lblNetWorthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNetWorthLabel.Location = new System.Drawing.Point(8, 48);
			this.lblNetWorthLabel.Name = "lblNetWorthLabel";
			this.lblNetWorthLabel.Size = new System.Drawing.Size(60, 16);
			this.lblNetWorthLabel.TabIndex = 40;
			this.lblNetWorthLabel.Text = "Net Worth:";
			//
			// lblDifficultyLabel
			//
			this.lblDifficultyLabel.AutoSize = true;
			this.lblDifficultyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblDifficultyLabel.Location = new System.Drawing.Point(8, 24);
			this.lblDifficultyLabel.Name = "lblDifficultyLabel";
			this.lblDifficultyLabel.Size = new System.Drawing.Size(53, 16);
			this.lblDifficultyLabel.TabIndex = 43;
			this.lblDifficultyLabel.Text = "Difficulty:";
			//
			// lblTime
			//
			this.lblTime.Location = new System.Drawing.Point(69, 40);
			this.lblTime.Name = "lblTime";
			this.lblTime.Size = new System.Drawing.Size(66, 13);
			this.lblTime.TabIndex = 44;
			this.lblTime.Text = "88,888 days";
			//
			// boxSkills
			//
			this.boxSkills.Controls.AddRange(new System.Windows.Forms.Control[] {
																																						this.lblEngineer,
																																						this.lblTrader,
																																						this.lblFighter,
																																						this.lblPilot,
																																						this.lblEngineerLabel,
																																						this.lblTraderLabel,
																																						this.lblFighterLabel,
																																						this.lblPilotLabel});
			this.boxSkills.Location = new System.Drawing.Point(8, 64);
			this.boxSkills.Name = "boxSkills";
			this.boxSkills.Size = new System.Drawing.Size(216, 56);
			this.boxSkills.TabIndex = 49;
			this.boxSkills.TabStop = false;
			this.boxSkills.Text = "Skills";
			//
			// lblEngineer
			//
			this.lblEngineer.Location = new System.Drawing.Point(167, 32);
			this.lblEngineer.Name = "lblEngineer";
			this.lblEngineer.Size = new System.Drawing.Size(40, 13);
			this.lblEngineer.TabIndex = 56;
			this.lblEngineer.Text = "88 (88)";
			//
			// lblTrader
			//
			this.lblTrader.Location = new System.Drawing.Point(58, 32);
			this.lblTrader.Name = "lblTrader";
			this.lblTrader.Size = new System.Drawing.Size(40, 13);
			this.lblTrader.TabIndex = 55;
			this.lblTrader.Text = "88 (88)";
			//
			// lblFighter
			//
			this.lblFighter.Location = new System.Drawing.Point(167, 16);
			this.lblFighter.Name = "lblFighter";
			this.lblFighter.Size = new System.Drawing.Size(40, 13);
			this.lblFighter.TabIndex = 54;
			this.lblFighter.Text = "88 (88)";
			//
			// lblPilot
			//
			this.lblPilot.Location = new System.Drawing.Point(58, 16);
			this.lblPilot.Name = "lblPilot";
			this.lblPilot.Size = new System.Drawing.Size(40, 13);
			this.lblPilot.TabIndex = 53;
			this.lblPilot.Text = "88 (88)";
			//
			// lblEngineerLabel
			//
			this.lblEngineerLabel.AutoSize = true;
			this.lblEngineerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblEngineerLabel.Location = new System.Drawing.Point(104, 32);
			this.lblEngineerLabel.Name = "lblEngineerLabel";
			this.lblEngineerLabel.Size = new System.Drawing.Size(55, 16);
			this.lblEngineerLabel.TabIndex = 52;
			this.lblEngineerLabel.Text = "Engineer:";
			//
			// lblTraderLabel
			//
			this.lblTraderLabel.AutoSize = true;
			this.lblTraderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTraderLabel.Location = new System.Drawing.Point(8, 32);
			this.lblTraderLabel.Name = "lblTraderLabel";
			this.lblTraderLabel.Size = new System.Drawing.Size(42, 16);
			this.lblTraderLabel.TabIndex = 51;
			this.lblTraderLabel.Text = "Trader:";
			//
			// lblFighterLabel
			//
			this.lblFighterLabel.AutoSize = true;
			this.lblFighterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblFighterLabel.Location = new System.Drawing.Point(104, 16);
			this.lblFighterLabel.Name = "lblFighterLabel";
			this.lblFighterLabel.Size = new System.Drawing.Size(44, 16);
			this.lblFighterLabel.TabIndex = 50;
			this.lblFighterLabel.Text = "Fighter:";
			//
			// lblPilotLabel
			//
			this.lblPilotLabel.AutoSize = true;
			this.lblPilotLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPilotLabel.Location = new System.Drawing.Point(8, 16);
			this.lblPilotLabel.Name = "lblPilotLabel";
			this.lblPilotLabel.Size = new System.Drawing.Size(31, 16);
			this.lblPilotLabel.TabIndex = 49;
			this.lblPilotLabel.Text = "Pilot:";
			//
			// boxFinances
			//
			this.boxFinances.Controls.AddRange(new System.Windows.Forms.Control[] {
																																							this.lblCash,
																																							this.lblDebt,
																																							this.lblNetWorth,
																																							this.lblNetWorthLabel,
																																							this.lblCashLabel,
																																							this.lblDebtLabel});
			this.boxFinances.Location = new System.Drawing.Point(8, 128);
			this.boxFinances.Name = "boxFinances";
			this.boxFinances.Size = new System.Drawing.Size(216, 72);
			this.boxFinances.TabIndex = 50;
			this.boxFinances.TabStop = false;
			this.boxFinances.Text = "Finances";
			//
			// lblCash
			//
			this.lblCash.Location = new System.Drawing.Point(104, 16);
			this.lblCash.Name = "lblCash";
			this.lblCash.Size = new System.Drawing.Size(70, 13);
			this.lblCash.TabIndex = 43;
			this.lblCash.Text = "8,888,888 cr.";
			this.lblCash.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblDebt
			//
			this.lblDebt.Location = new System.Drawing.Point(104, 32);
			this.lblDebt.Name = "lblDebt";
			this.lblDebt.Size = new System.Drawing.Size(70, 13);
			this.lblDebt.TabIndex = 42;
			this.lblDebt.Text = "8,888,888 cr.";
			this.lblDebt.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblNetWorth
			//
			this.lblNetWorth.Location = new System.Drawing.Point(104, 48);
			this.lblNetWorth.Name = "lblNetWorth";
			this.lblNetWorth.Size = new System.Drawing.Size(70, 13);
			this.lblNetWorth.TabIndex = 41;
			this.lblNetWorth.Text = "8,888,888 cr.";
			this.lblNetWorth.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// boxNotoriety
			//
			this.boxNotoriety.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblBountyLabel,
																																							 this.lblBounty,
																																							 this.lblPoliceLabel,
																																							 this.lblReputationLabel,
																																							 this.lblKillsLabel,
																																							 this.lblKills,
																																							 this.lblReputation,
																																							 this.lblRecord});
			this.boxNotoriety.Location = new System.Drawing.Point(8, 208);
			this.boxNotoriety.Name = "boxNotoriety";
			this.boxNotoriety.Size = new System.Drawing.Size(216, 88);
			this.boxNotoriety.TabIndex = 51;
			this.boxNotoriety.TabStop = false;
			this.boxNotoriety.Text = "Notoriety";
			//
			// lblPoliceLabel
			//
			this.lblPoliceLabel.AutoSize = true;
			this.lblPoliceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPoliceLabel.Location = new System.Drawing.Point(8, 48);
			this.lblPoliceLabel.Name = "lblPoliceLabel";
			this.lblPoliceLabel.Size = new System.Drawing.Size(81, 16);
			this.lblPoliceLabel.TabIndex = 46;
			this.lblPoliceLabel.Text = "Police Record:";
			//
			// lblReputationLabel
			//
			this.lblReputationLabel.AutoSize = true;
			this.lblReputationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblReputationLabel.Location = new System.Drawing.Point(8, 32);
			this.lblReputationLabel.Name = "lblReputationLabel";
			this.lblReputationLabel.Size = new System.Drawing.Size(65, 16);
			this.lblReputationLabel.TabIndex = 45;
			this.lblReputationLabel.Text = "Reputation:";
			//
			// lblKillsLabel
			//
			this.lblKillsLabel.AutoSize = true;
			this.lblKillsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblKillsLabel.Location = new System.Drawing.Point(8, 16);
			this.lblKillsLabel.Name = "lblKillsLabel";
			this.lblKillsLabel.Size = new System.Drawing.Size(30, 16);
			this.lblKillsLabel.TabIndex = 44;
			this.lblKillsLabel.Text = "Kills:";
			//
			// lblKills
			//
			this.lblKills.Location = new System.Drawing.Point(104, 16);
			this.lblKills.Name = "lblKills";
			this.lblKills.Size = new System.Drawing.Size(33, 13);
			this.lblKills.TabIndex = 43;
			this.lblKills.Text = "8,888";
			//
			// lblReputation
			//
			this.lblReputation.Location = new System.Drawing.Point(104, 32);
			this.lblReputation.Name = "lblReputation";
			this.lblReputation.Size = new System.Drawing.Size(88, 13);
			this.lblReputation.TabIndex = 42;
			this.lblReputation.Text = "Mostly Harmless";
			//
			// lblRecord
			//
			this.lblRecord.Location = new System.Drawing.Point(104, 48);
			this.lblRecord.Name = "lblRecord";
			this.lblRecord.Size = new System.Drawing.Size(63, 13);
			this.lblRecord.TabIndex = 41;
			this.lblRecord.Text = "Psychopath";
			//
			// lblBountyLabel
			//
			this.lblBountyLabel.AutoSize = true;
			this.lblBountyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBountyLabel.Location = new System.Drawing.Point(8, 64);
			this.lblBountyLabel.Name = "lblBountyLabel";
			this.lblBountyLabel.Size = new System.Drawing.Size(84, 16);
			this.lblBountyLabel.TabIndex = 48;
			this.lblBountyLabel.Text = "Bounty offered:";
			this.lblBountyLabel.Visible = false;
			//
			// lblBounty
			//
			this.lblBounty.Location = new System.Drawing.Point(104, 64);
			this.lblBounty.Name = "lblBounty";
			this.lblBounty.Size = new System.Drawing.Size(72, 13);
			this.lblBounty.TabIndex = 47;
			this.lblBounty.Text = "8,888,888 cr.";
			this.lblBounty.Visible = false;
			// FormViewCommander
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(232, 304);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.boxNotoriety,
																																	this.boxFinances,
																																	this.boxSkills,
																																	this.lblTime,
																																	this.lblDifficultyLabel,
																																	this.lblTimeLabel,
																																	this.lblNameLabel,
																																	this.btnClose,
																																	this.lblDifficulty,
																																	this.lblName});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormViewCommander";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Commander Status";
			this.boxSkills.ResumeLayout(false);
			this.boxFinances.ResumeLayout(false);
			this.boxNotoriety.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		private void InitializeScreen()
		{
			Commander			cmdr					= game.Commander;

			lblName.Text								= cmdr.Name;
			lblDifficulty.Text					= Strings.DifficultyLevels[(int)game.Difficulty];
			lblTime.Text								= Functions.Multiples(cmdr.Days, Strings.TimeUnit);

			lblPilot.Text								= cmdr.Pilot.ToString() + " (" + cmdr.Ship.Pilot + ")";
			lblFighter.Text							= cmdr.Fighter.ToString() + " (" + cmdr.Ship.Fighter + ")";
			lblTrader.Text							= cmdr.Trader.ToString() + " (" + cmdr.Ship.Trader + ")";
			lblEngineer.Text						= cmdr.Engineer.ToString() + " (" + cmdr.Ship.Engineer + ")";

			lblCash.Text								= Functions.FormatMoney(cmdr.Cash);
			lblDebt.Text								= Functions.FormatMoney(cmdr.Debt);
			lblNetWorth.Text						= Functions.FormatMoney(cmdr.Worth);

			lblKills.Text								= Functions.FormatNumber(cmdr.KillsPirate + cmdr.KillsPolice + cmdr.KillsTrader);
			lblRecord.Text							= PoliceRecord.GetPoliceRecordFromScore(cmdr.PoliceRecordScore).Name;
			lblReputation.Text					= Reputation.GetReputationFromScore(cmdr.ReputationScore).Name;

			int score = cmdr.PoliceRecordScore;
			if (score <= Consts.PoliceRecordScoreCrook)
			{
				lblBountyLabel.Visible = true;
				lblBountyLabel.Text = "Bounty offered:";
				lblBounty.Visible = true;
				lblBounty.Text = Functions.FormatMoney(-1000*score);
			}
			else if (score >= Consts.PoliceRecordScoreTrusted)
			{
				lblBountyLabel.Visible = true;
				lblBountyLabel.Text = "Angry kingpins:";
				lblBounty.Visible = true;
				lblBounty.Text = Functions.FormatNumber(score / 5);
			}
			else
			{
				lblBountyLabel.Visible = false;
				lblBounty.Visible = false;
			}
		}
		#endregion
	}
}
