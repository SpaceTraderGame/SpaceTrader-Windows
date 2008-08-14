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
	public class FormMonster : System.Windows.Forms.Form
	{
		#region Constants

		private const int	SplitSystems	= 31;

		#endregion

		#region Control Declarations

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Panel pnlMercs;
		private System.Windows.Forms.Panel pnlQuests;
		private System.Windows.Forms.Panel pnlShipyards;
		private System.Windows.Forms.PictureBox picLine1;
		private System.Windows.Forms.PictureBox picLine0;
		private System.Windows.Forms.PictureBox picLine2;
		private System.Windows.Forms.Label lblMercLabel;
		private System.Windows.Forms.Label lblQuestsLabel;
		private System.Windows.Forms.Label lblShipyardsLabel;
		private System.Windows.Forms.LinkLabel lblMercIDLabel;
		private System.Windows.Forms.LinkLabel lblMercNameLabel;
		private System.Windows.Forms.LinkLabel lblMercSkillLabelPilot;
		private System.Windows.Forms.LinkLabel lblMercSkillLabelFighter;
		private System.Windows.Forms.LinkLabel lblMercSkillLabelTrader;
		private System.Windows.Forms.LinkLabel lblMercSkillLabelEngineer;
		private System.Windows.Forms.LinkLabel lblMercSystemLabel;
		private System.Windows.Forms.LinkLabel lblQuestSystemLabel;
		private System.Windows.Forms.LinkLabel lblQuestDescLabel;
		private System.Windows.Forms.LinkLabel lblShipyardsSystemLabel;
		private System.Windows.Forms.LinkLabel lblShipyardsDescLabel;
		private System.Windows.Forms.Label lblMercIds;
		private System.Windows.Forms.Label lblMercNames;
		private System.Windows.Forms.Label lblMercSkillsPilot;
		private System.Windows.Forms.Label lblMercSkillsFighter;
		private System.Windows.Forms.Label lblMercSkillsTrader;
		private System.Windows.Forms.Label lblMercSkillsEngineer;
		private System.Windows.Forms.LinkLabel lblMercSystems;
		private System.Windows.Forms.LinkLabel lblMercSystems2;
		private System.Windows.Forms.LinkLabel lblQuestSystems;
		private System.Windows.Forms.Label lblQuests;
		private System.Windows.Forms.LinkLabel lblShipyardSystems;
		private System.Windows.Forms.Label lblShipyards;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Member Declarations

		private Game	game							= Game.CurrentGame;
		private int[]	mercIds;
		private int[]	questSystemIds;
		private int[]	shipyardSystemIds;

		#endregion

		#region Methods

		public FormMonster()
		{
			InitializeComponent();

			PopulateIdArrays();

			SetLabelHeights();

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
			this.picLine1 = new System.Windows.Forms.PictureBox();
			this.picLine0 = new System.Windows.Forms.PictureBox();
			this.lblQuestsLabel = new System.Windows.Forms.Label();
			this.lblMercLabel = new System.Windows.Forms.Label();
			this.lblMercSkillLabelPilot = new System.Windows.Forms.LinkLabel();
			this.lblMercSkillLabelFighter = new System.Windows.Forms.LinkLabel();
			this.lblMercSkillLabelTrader = new System.Windows.Forms.LinkLabel();
			this.lblMercSkillLabelEngineer = new System.Windows.Forms.LinkLabel();
			this.lblMercSystemLabel = new System.Windows.Forms.LinkLabel();
			this.lblQuestSystemLabel = new System.Windows.Forms.LinkLabel();
			this.lblQuestDescLabel = new System.Windows.Forms.LinkLabel();
			this.lblMercIDLabel = new System.Windows.Forms.LinkLabel();
			this.lblMercNameLabel = new System.Windows.Forms.LinkLabel();
			this.lblShipyardsDescLabel = new System.Windows.Forms.LinkLabel();
			this.lblShipyardsSystemLabel = new System.Windows.Forms.LinkLabel();
			this.lblShipyardsLabel = new System.Windows.Forms.Label();
			this.pnlMercs = new System.Windows.Forms.Panel();
			this.lblMercSkillsPilot = new System.Windows.Forms.Label();
			this.lblMercSkillsFighter = new System.Windows.Forms.Label();
			this.lblMercSkillsTrader = new System.Windows.Forms.Label();
			this.lblMercSkillsEngineer = new System.Windows.Forms.Label();
			this.lblMercSystems = new System.Windows.Forms.LinkLabel();
			this.lblMercIds = new System.Windows.Forms.Label();
			this.lblMercNames = new System.Windows.Forms.Label();
			this.lblMercSystems2 = new System.Windows.Forms.LinkLabel();
			this.pnlQuests = new System.Windows.Forms.Panel();
			this.lblQuests = new System.Windows.Forms.Label();
			this.lblQuestSystems = new System.Windows.Forms.LinkLabel();
			this.pnlShipyards = new System.Windows.Forms.Panel();
			this.lblShipyards = new System.Windows.Forms.Label();
			this.lblShipyardSystems = new System.Windows.Forms.LinkLabel();
			this.picLine2 = new System.Windows.Forms.PictureBox();
			this.pnlMercs.SuspendLayout();
			this.pnlQuests.SuspendLayout();
			this.pnlShipyards.SuspendLayout();
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
			// picLine1
			// 
			this.picLine1.BackColor = System.Drawing.Color.DimGray;
			this.picLine1.Location = new System.Drawing.Point(4, 40);
			this.picLine1.Name = "picLine1";
			this.picLine1.Size = new System.Drawing.Size(609, 1);
			this.picLine1.TabIndex = 133;
			this.picLine1.TabStop = false;
			// 
			// picLine0
			// 
			this.picLine0.BackColor = System.Drawing.Color.DimGray;
			this.picLine0.Location = new System.Drawing.Point(234, 8);
			this.picLine0.Name = "picLine0";
			this.picLine0.Size = new System.Drawing.Size(1, 347);
			this.picLine0.TabIndex = 132;
			this.picLine0.TabStop = false;
			// 
			// lblQuestsLabel
			// 
			this.lblQuestsLabel.AutoSize = true;
			this.lblQuestsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblQuestsLabel.Location = new System.Drawing.Point(88, 4);
			this.lblQuestsLabel.Name = "lblQuestsLabel";
			this.lblQuestsLabel.Size = new System.Drawing.Size(50, 19);
			this.lblQuestsLabel.TabIndex = 134;
			this.lblQuestsLabel.Text = "Quests";
			// 
			// lblMercLabel
			// 
			this.lblMercLabel.AutoSize = true;
			this.lblMercLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMercLabel.Location = new System.Drawing.Point(348, 4);
			this.lblMercLabel.Name = "lblMercLabel";
			this.lblMercLabel.Size = new System.Drawing.Size(84, 19);
			this.lblMercLabel.TabIndex = 141;
			this.lblMercLabel.Text = "Mercenaries";
			// 
			// lblMercSkillLabelPilot
			// 
			this.lblMercSkillLabelPilot.AutoSize = true;
			this.lblMercSkillLabelPilot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMercSkillLabelPilot.Location = new System.Drawing.Point(341, 24);
			this.lblMercSkillLabelPilot.Name = "lblMercSkillLabelPilot";
			this.lblMercSkillLabelPilot.Size = new System.Drawing.Size(12, 16);
			this.lblMercSkillLabelPilot.TabIndex = 7;
			this.lblMercSkillLabelPilot.TabStop = true;
			this.lblMercSkillLabelPilot.Text = "P";
			this.lblMercSkillLabelPilot.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblMercSkillLabelPilot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SortLinkClicked);
			// 
			// lblMercSkillLabelFighter
			// 
			this.lblMercSkillLabelFighter.AutoSize = true;
			this.lblMercSkillLabelFighter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMercSkillLabelFighter.Location = new System.Drawing.Point(362, 24);
			this.lblMercSkillLabelFighter.Name = "lblMercSkillLabelFighter";
			this.lblMercSkillLabelFighter.Size = new System.Drawing.Size(11, 16);
			this.lblMercSkillLabelFighter.TabIndex = 8;
			this.lblMercSkillLabelFighter.TabStop = true;
			this.lblMercSkillLabelFighter.Text = "F";
			this.lblMercSkillLabelFighter.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblMercSkillLabelFighter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SortLinkClicked);
			// 
			// lblMercSkillLabelTrader
			// 
			this.lblMercSkillLabelTrader.AutoSize = true;
			this.lblMercSkillLabelTrader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMercSkillLabelTrader.Location = new System.Drawing.Point(382, 24);
			this.lblMercSkillLabelTrader.Name = "lblMercSkillLabelTrader";
			this.lblMercSkillLabelTrader.Size = new System.Drawing.Size(11, 16);
			this.lblMercSkillLabelTrader.TabIndex = 9;
			this.lblMercSkillLabelTrader.TabStop = true;
			this.lblMercSkillLabelTrader.Text = "T";
			this.lblMercSkillLabelTrader.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblMercSkillLabelTrader.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SortLinkClicked);
			// 
			// lblMercSkillLabelEngineer
			// 
			this.lblMercSkillLabelEngineer.AutoSize = true;
			this.lblMercSkillLabelEngineer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMercSkillLabelEngineer.Location = new System.Drawing.Point(401, 24);
			this.lblMercSkillLabelEngineer.Name = "lblMercSkillLabelEngineer";
			this.lblMercSkillLabelEngineer.Size = new System.Drawing.Size(12, 16);
			this.lblMercSkillLabelEngineer.TabIndex = 10;
			this.lblMercSkillLabelEngineer.TabStop = true;
			this.lblMercSkillLabelEngineer.Text = "E";
			this.lblMercSkillLabelEngineer.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblMercSkillLabelEngineer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SortLinkClicked);
			// 
			// lblMercSystemLabel
			// 
			this.lblMercSystemLabel.AutoSize = true;
			this.lblMercSystemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMercSystemLabel.Location = new System.Drawing.Point(425, 24);
			this.lblMercSystemLabel.Name = "lblMercSystemLabel";
			this.lblMercSystemLabel.Size = new System.Drawing.Size(43, 16);
			this.lblMercSystemLabel.TabIndex = 11;
			this.lblMercSystemLabel.TabStop = true;
			this.lblMercSystemLabel.Text = "System";
			this.lblMercSystemLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SortLinkClicked);
			// 
			// lblQuestSystemLabel
			// 
			this.lblQuestSystemLabel.AutoSize = true;
			this.lblQuestSystemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblQuestSystemLabel.Location = new System.Drawing.Point(13, 24);
			this.lblQuestSystemLabel.Name = "lblQuestSystemLabel";
			this.lblQuestSystemLabel.Size = new System.Drawing.Size(43, 16);
			this.lblQuestSystemLabel.TabIndex = 1;
			this.lblQuestSystemLabel.TabStop = true;
			this.lblQuestSystemLabel.Text = "System";
			this.lblQuestSystemLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SortLinkClicked);
			// 
			// lblQuestDescLabel
			// 
			this.lblQuestDescLabel.AutoSize = true;
			this.lblQuestDescLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblQuestDescLabel.Location = new System.Drawing.Point(85, 24);
			this.lblQuestDescLabel.Name = "lblQuestDescLabel";
			this.lblQuestDescLabel.Size = new System.Drawing.Size(63, 16);
			this.lblQuestDescLabel.TabIndex = 2;
			this.lblQuestDescLabel.TabStop = true;
			this.lblQuestDescLabel.Text = "Description";
			this.lblQuestDescLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SortLinkClicked);
			// 
			// lblMercIDLabel
			// 
			this.lblMercIDLabel.AutoSize = true;
			this.lblMercIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMercIDLabel.Location = new System.Drawing.Point(247, 24);
			this.lblMercIDLabel.Name = "lblMercIDLabel";
			this.lblMercIDLabel.Size = new System.Drawing.Size(16, 16);
			this.lblMercIDLabel.TabIndex = 5;
			this.lblMercIDLabel.TabStop = true;
			this.lblMercIDLabel.Text = "ID";
			this.lblMercIDLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.lblMercIDLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SortLinkClicked);
			// 
			// lblMercNameLabel
			// 
			this.lblMercNameLabel.AutoSize = true;
			this.lblMercNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMercNameLabel.Location = new System.Drawing.Point(268, 24);
			this.lblMercNameLabel.Name = "lblMercNameLabel";
			this.lblMercNameLabel.Size = new System.Drawing.Size(35, 16);
			this.lblMercNameLabel.TabIndex = 6;
			this.lblMercNameLabel.TabStop = true;
			this.lblMercNameLabel.Text = "Name";
			this.lblMercNameLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SortLinkClicked);
			// 
			// lblShipyardsDescLabel
			// 
			this.lblShipyardsDescLabel.AutoSize = true;
			this.lblShipyardsDescLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblShipyardsDescLabel.Location = new System.Drawing.Point(85, 258);
			this.lblShipyardsDescLabel.Name = "lblShipyardsDescLabel";
			this.lblShipyardsDescLabel.Size = new System.Drawing.Size(63, 16);
			this.lblShipyardsDescLabel.TabIndex = 4;
			this.lblShipyardsDescLabel.TabStop = true;
			this.lblShipyardsDescLabel.Text = "Description";
			this.lblShipyardsDescLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SortLinkClicked);
			// 
			// lblShipyardsSystemLabel
			// 
			this.lblShipyardsSystemLabel.AutoSize = true;
			this.lblShipyardsSystemLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblShipyardsSystemLabel.Location = new System.Drawing.Point(13, 258);
			this.lblShipyardsSystemLabel.Name = "lblShipyardsSystemLabel";
			this.lblShipyardsSystemLabel.Size = new System.Drawing.Size(43, 16);
			this.lblShipyardsSystemLabel.TabIndex = 3;
			this.lblShipyardsSystemLabel.TabStop = true;
			this.lblShipyardsSystemLabel.Text = "System";
			this.lblShipyardsSystemLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SortLinkClicked);
			// 
			// lblShipyardsLabel
			// 
			this.lblShipyardsLabel.AutoSize = true;
			this.lblShipyardsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblShipyardsLabel.Location = new System.Drawing.Point(79, 238);
			this.lblShipyardsLabel.Name = "lblShipyardsLabel";
			this.lblShipyardsLabel.Size = new System.Drawing.Size(68, 19);
			this.lblShipyardsLabel.TabIndex = 155;
			this.lblShipyardsLabel.Text = "Shipyards";
			// 
			// pnlMercs
			// 
			this.pnlMercs.AutoScroll = true;
			this.pnlMercs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlMercs.Controls.Add(this.lblMercSkillsPilot);
			this.pnlMercs.Controls.Add(this.lblMercSkillsFighter);
			this.pnlMercs.Controls.Add(this.lblMercSkillsTrader);
			this.pnlMercs.Controls.Add(this.lblMercSkillsEngineer);
			this.pnlMercs.Controls.Add(this.lblMercSystems);
			this.pnlMercs.Controls.Add(this.lblMercIds);
			this.pnlMercs.Controls.Add(this.lblMercNames);
			this.pnlMercs.Controls.Add(this.lblMercSystems2);
			this.pnlMercs.Location = new System.Drawing.Point(239, 44);
			this.pnlMercs.Name = "pnlMercs";
			this.pnlMercs.Size = new System.Drawing.Size(371, 307);
			this.pnlMercs.TabIndex = 158;
			// 
			// lblMercSkillsPilot
			// 
			this.lblMercSkillsPilot.Location = new System.Drawing.Point(93, 4);
			this.lblMercSkillsPilot.Name = "lblMercSkillsPilot";
			this.lblMercSkillsPilot.Size = new System.Drawing.Size(20, 563);
			this.lblMercSkillsPilot.TabIndex = 144;
			this.lblMercSkillsPilot.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblMercSkillsFighter
			// 
			this.lblMercSkillsFighter.Location = new System.Drawing.Point(113, 4);
			this.lblMercSkillsFighter.Name = "lblMercSkillsFighter";
			this.lblMercSkillsFighter.Size = new System.Drawing.Size(20, 563);
			this.lblMercSkillsFighter.TabIndex = 145;
			this.lblMercSkillsFighter.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblMercSkillsTrader
			// 
			this.lblMercSkillsTrader.Location = new System.Drawing.Point(133, 4);
			this.lblMercSkillsTrader.Name = "lblMercSkillsTrader";
			this.lblMercSkillsTrader.Size = new System.Drawing.Size(20, 563);
			this.lblMercSkillsTrader.TabIndex = 146;
			this.lblMercSkillsTrader.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblMercSkillsEngineer
			// 
			this.lblMercSkillsEngineer.Location = new System.Drawing.Point(153, 4);
			this.lblMercSkillsEngineer.Name = "lblMercSkillsEngineer";
			this.lblMercSkillsEngineer.Size = new System.Drawing.Size(20, 563);
			this.lblMercSkillsEngineer.TabIndex = 147;
			this.lblMercSkillsEngineer.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblMercSystems
			// 
			this.lblMercSystems.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
			this.lblMercSystems.Location = new System.Drawing.Point(185, 4);
			this.lblMercSystems.Name = "lblMercSystems";
			this.lblMercSystems.Size = new System.Drawing.Size(160, 387);
			this.lblMercSystems.TabIndex = 14;
			this.lblMercSystems.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SystemLinkClicked);
			// 
			// lblMercIds
			// 
			this.lblMercIds.Location = new System.Drawing.Point(0, 4);
			this.lblMercIds.Name = "lblMercIds";
			this.lblMercIds.Size = new System.Drawing.Size(23, 563);
			this.lblMercIds.TabIndex = 142;
			this.lblMercIds.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblMercNames
			// 
			this.lblMercNames.Location = new System.Drawing.Point(28, 4);
			this.lblMercNames.Name = "lblMercNames";
			this.lblMercNames.Size = new System.Drawing.Size(69, 563);
			this.lblMercNames.TabIndex = 141;
			// 
			// lblMercSystems2
			// 
			this.lblMercSystems2.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
			this.lblMercSystems2.Location = new System.Drawing.Point(185, 391);
			this.lblMercSystems2.Name = "lblMercSystems2";
			this.lblMercSystems2.Size = new System.Drawing.Size(160, 175);
			this.lblMercSystems2.TabIndex = 148;
			this.lblMercSystems2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SystemLinkClicked);
			// 
			// pnlQuests
			// 
			this.pnlQuests.AutoScroll = true;
			this.pnlQuests.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlQuests.Controls.Add(this.lblQuests);
			this.pnlQuests.Controls.Add(this.lblQuestSystems);
			this.pnlQuests.Location = new System.Drawing.Point(8, 44);
			this.pnlQuests.Name = "pnlQuests";
			this.pnlQuests.Size = new System.Drawing.Size(222, 182);
			this.pnlQuests.TabIndex = 159;
			// 
			// lblQuests
			// 
			this.lblQuests.Location = new System.Drawing.Point(76, 4);
			this.lblQuests.Name = "lblQuests";
			this.lblQuests.Size = new System.Drawing.Size(120, 350);
			this.lblQuests.TabIndex = 48;
			// 
			// lblQuestSystems
			// 
			this.lblQuestSystems.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
			this.lblQuestSystems.Location = new System.Drawing.Point(4, 4);
			this.lblQuestSystems.Name = "lblQuestSystems";
			this.lblQuestSystems.Size = new System.Drawing.Size(68, 350);
			this.lblQuestSystems.TabIndex = 12;
			this.lblQuestSystems.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SystemLinkClicked);
			// 
			// pnlShipyards
			// 
			this.pnlShipyards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlShipyards.Controls.Add(this.lblShipyards);
			this.pnlShipyards.Controls.Add(this.lblShipyardSystems);
			this.pnlShipyards.Location = new System.Drawing.Point(8, 278);
			this.pnlShipyards.Name = "pnlShipyards";
			this.pnlShipyards.Size = new System.Drawing.Size(222, 73);
			this.pnlShipyards.TabIndex = 160;
			// 
			// lblShipyards
			// 
			this.lblShipyards.Location = new System.Drawing.Point(76, 4);
			this.lblShipyards.Name = "lblShipyards";
			this.lblShipyards.Size = new System.Drawing.Size(120, 63);
			this.lblShipyards.TabIndex = 158;
			// 
			// lblShipyardSystems
			// 
			this.lblShipyardSystems.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
			this.lblShipyardSystems.Location = new System.Drawing.Point(4, 4);
			this.lblShipyardSystems.Name = "lblShipyardSystems";
			this.lblShipyardSystems.Size = new System.Drawing.Size(68, 63);
			this.lblShipyardSystems.TabIndex = 13;
			this.lblShipyardSystems.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.SystemLinkClicked);
			// 
			// picLine2
			// 
			this.picLine2.BackColor = System.Drawing.Color.DimGray;
			this.picLine2.Location = new System.Drawing.Point(4, 274);
			this.picLine2.Name = "picLine2";
			this.picLine2.Size = new System.Drawing.Size(222, 1);
			this.picLine2.TabIndex = 161;
			this.picLine2.TabStop = false;
			// 
			// FormMonster
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(617, 358);
			this.Controls.Add(this.picLine2);
			this.Controls.Add(this.pnlShipyards);
			this.Controls.Add(this.pnlQuests);
			this.Controls.Add(this.picLine1);
			this.Controls.Add(this.picLine0);
			this.Controls.Add(this.pnlMercs);
			this.Controls.Add(this.lblShipyardsLabel);
			this.Controls.Add(this.lblShipyardsDescLabel);
			this.Controls.Add(this.lblShipyardsSystemLabel);
			this.Controls.Add(this.lblMercNameLabel);
			this.Controls.Add(this.lblMercIDLabel);
			this.Controls.Add(this.lblQuestDescLabel);
			this.Controls.Add(this.lblQuestSystemLabel);
			this.Controls.Add(this.lblMercSystemLabel);
			this.Controls.Add(this.lblMercSkillLabelEngineer);
			this.Controls.Add(this.lblMercSkillLabelTrader);
			this.Controls.Add(this.lblMercSkillLabelFighter);
			this.Controls.Add(this.lblMercSkillLabelPilot);
			this.Controls.Add(this.lblMercLabel);
			this.Controls.Add(this.lblQuestsLabel);
			this.Controls.Add(this.btnClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormMonster";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Monster.com Job Listing";
			this.pnlMercs.ResumeLayout(false);
			this.pnlQuests.ResumeLayout(false);
			this.pnlShipyards.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private int Compare(int a, int b, string sortWhat, string sortBy)
		{
			int	compareVal	= 0;

			if (sortWhat == "M") // Mercenaries
			{
				CrewMember	A						= game.Mercenaries[a];
				CrewMember	B						= game.Mercenaries[b];

				bool				strCompare	= false;
				object			valA				= null;
				object			valB				= null;

				switch (sortBy)
				{
					case "I":												// Id
						valA				= (int)A.Id;
						valB				= (int)B.Id;
						break;
					case "N":												// Name
						valA				= A.Name;
						valB				= B.Name;
						strCompare	= true;
						break;
					case "P":												// Pilot
						valA				= A.Pilot;
						valB				= B.Pilot;
						break;
					case "F":												// Fighter
						valA				= A.Fighter;
						valB				= B.Fighter;
						break;
					case "T":												// Trader
						valA				= A.Trader;
						valB				= B.Trader;
						break;
					case "E":												// Engineer
						valA				= A.Engineer;
						valB				= B.Engineer;
						break;
					case "S":												// System
						valA				= CurrentSystemDisplay(A);
						valB				= CurrentSystemDisplay(B);
						strCompare	= true;
						break;
				}

				if (strCompare)
					compareVal	= ((string)valA).CompareTo((string)valB);
				else
					compareVal	= ((int)valA).CompareTo(valB);

				// Secondary sort by Name
				if (compareVal == 0 && sortBy != "N")
					compareVal	= A.Name.CompareTo(B.Name);
			}
			else
			{
				StarSystem	A	= game.Universe[a];
				StarSystem	B	= game.Universe[b];

				if (sortBy == "D") // Description
				{
					string	nameA	= "";
					string	nameB	= "";

					switch (sortWhat)
					{
						case "Q": // Quests
							nameA	= A.SpecialEvent.Title;
							nameB	= B.SpecialEvent.Title;
							break;
						case "S": // Shipyards
							nameA	= A.Shipyard.Name;
							nameB	= B.Shipyard.Name;
							break;
					}

					compareVal	= nameA.CompareTo(nameB);
				}

				if (compareVal == 0) // Default sort - System Name
				{
					compareVal	= A.Name.CompareTo(B.Name);
				}
			}

			return compareVal;
		}

		private string CurrentSystemDisplay(CrewMember merc)
		{
			return (merc.CurrentSystem == null ? Strings.Unknown : (game.Commander.Ship.HasCrew(merc.Id) ?
							Functions.StringVars(Strings.MercOnBoard, merc.CurrentSystem.Name) : merc.CurrentSystem.Name));
		}

		private void PopulateIdArrays()
		{
			// Populate the mercenary ids array.
			ArrayList	ids	= new ArrayList();
			foreach (CrewMember merc in game.Mercenaries)
			{
				if (!Consts.SpecialCrewMemberIds.Contains(merc.Id))
					ids.Add((int)merc.Id);
			}
			mercIds				= (int[])ids.ToArray(System.Type.GetType("System.Int32"));

			// Populate the quest and shipyard system ids arrays.
			ArrayList	quests		= new ArrayList();
			ArrayList shipyards	= new ArrayList();
			foreach (StarSystem system in game.Universe)
			{
				if (system.ShowSpecialButton())
					quests.Add((int)system.Id);

				if (system.ShipyardId != ShipyardId.NA)
					shipyards.Add((int)system.Id);
			}
			questSystemIds		= (int[])quests.ToArray(System.Type.GetType("System.Int32"));
			shipyardSystemIds	= (int[])shipyards.ToArray(System.Type.GetType("System.Int32"));

			// Sort the arrays.
			Sort("M", "N");		// Sort mercenaries by name.
			Sort("Q", "S");		// Sort quests by system name.
			Sort("S", "S");		// Sort shipyards by system name.
		}

		private void SetLabelHeights()
		{
			lblQuests.Height							=
			lblQuestSystems.Height				= (int)Math.Ceiling(questSystemIds.Length * 12.5) + 1;

			lblShipyards.Height						=
			lblShipyardSystems.Height			= (int)Math.Ceiling(shipyardSystemIds.Length * 12.5) + 1;

			lblMercIds.Height							=
			lblMercNames.Height						=
			lblMercSkillsPilot.Height			=
			lblMercSkillsFighter.Height		=
			lblMercSkillsTrader.Height		=
			lblMercSkillsEngineer.Height	= (int)Math.Ceiling(mercIds.Length * 12.5) + 1;

			// Due to a limitation of the LinkLabel control, no more than 32 links can exist in the LinkLabel.
			lblMercSystems.Height					=	(int)Math.Ceiling(Math.Min(mercIds.Length, SplitSystems) * 12.5) + 1;
			if (mercIds.Length > SplitSystems)
			{
				lblMercSystems2.Visible	= true;
				lblMercSystems2.Height	= (int)Math.Ceiling((mercIds.Length - SplitSystems) * 12.5) + 1;
			}
			else
			{
				lblMercSystems2.Visible	= false;
				lblMercSystems2.Top			= lblMercSystems.Top;
			}
		}

		private void Sort(string sortWhat, string sortBy)
		{
			int[]	array	= null;
			switch (sortWhat)
			{
				case "M":
					array	= mercIds;
					break;
				case "Q":
					array	= questSystemIds;
					break;
				case "S":
					array	= shipyardSystemIds;
					break;
			}

			for (int i = 0; i < array.Length - 1; i++)
			{
				for (int j = 0; j < array.Length - i - 1; j++)
				{
					if (Compare(array[j], array[j + 1], sortWhat, sortBy) > 0)
					{
						int	temp			= array[j];
						array[j]			= array[j + 1];
						array[j + 1]	= temp;
					}
				}
			}
		}

		private void UpdateAll()
		{
			UpdateMercs();
			UpdateQuests();
			UpdateShipyards();
		}

		private void UpdateMercs()
		{
			lblMercIds.Text							= "";
			lblMercNames.Text						= "";
			lblMercSkillsPilot.Text			= "";
			lblMercSkillsFighter.Text		= "";
			lblMercSkillsTrader.Text		= "";
			lblMercSkillsEngineer.Text	= "";
			lblMercSystems.Text					= "";
			lblMercSystems2.Text				= "";
			lblMercSystems.Links.Clear();
			lblMercSystems2.Links.Clear();

			for (int i = 0; i < mercIds.Length; i++)
			{
				CrewMember	merc	= game.Mercenaries[mercIds[i]];
				bool				link	= merc.CurrentSystem != null && !game.Commander.Ship.HasCrew(merc.Id);

				lblMercIds.Text							+= ((int)merc.Id).ToString() + Environment.NewLine;
				lblMercNames.Text						+= merc.Name + Environment.NewLine;
				lblMercSkillsPilot.Text			+= merc.Pilot.ToString() + Environment.NewLine;
				lblMercSkillsFighter.Text		+= merc.Fighter.ToString() + Environment.NewLine;
				lblMercSkillsTrader.Text		+= merc.Trader.ToString() + Environment.NewLine;
				lblMercSkillsEngineer.Text	+= merc.Engineer.ToString() + Environment.NewLine;

				if (i < SplitSystems)
				{
					int	start	= lblMercSystems.Text.Length;
					lblMercSystems.Text				+= CurrentSystemDisplay(merc) + Environment.NewLine;
					if (link)
						lblMercSystems.Links.Add(start, merc.CurrentSystem.Name.Length, merc.CurrentSystem.Name);
				}
				else
				{
					int	start	= lblMercSystems2.Text.Length;
					lblMercSystems2.Text			+= CurrentSystemDisplay(merc) + Environment.NewLine;
					if (link)
						lblMercSystems2.Links.Add(start, merc.CurrentSystem.Name.Length, merc.CurrentSystem.Name);
				}
			}

			lblMercIds.Text							= lblMercIds.Text.Trim();
			lblMercNames.Text						= lblMercNames.Text.Trim();
			lblMercSkillsPilot.Text			= lblMercSkillsPilot.Text.Trim();
			lblMercSkillsFighter.Text		= lblMercSkillsFighter.Text.Trim();
			lblMercSkillsTrader.Text		= lblMercSkillsTrader.Text.Trim();
			lblMercSkillsEngineer.Text	= lblMercSkillsEngineer.Text.Trim();
			lblMercSystems.Text					= lblMercSystems.Text.Trim();
			lblMercSystems2.Text				= lblMercSystems2.Text.Trim();
		}

		private void UpdateQuests()
		{
			lblQuestSystems.Text	= "";
			lblQuests.Text				= "";
			lblQuestSystems.Links.Clear();

			for (int i = 0; i < questSystemIds.Length; i++)
			{
				StarSystem	system		= game.Universe[questSystemIds[i]];
				int					start			= lblQuestSystems.Text.Length;

				lblQuestSystems.Text	+= system.Name + Environment.NewLine;
				lblQuests.Text				+= system.SpecialEvent.Title + Environment.NewLine;

				lblQuestSystems.Links.Add(start, system.Name.Length, system.Name);
			}

			lblQuestSystems.Text	= lblQuestSystems.Text.Trim();
			lblQuests.Text				= lblQuests.Text.Trim();
		}

		private void UpdateShipyards()
		{
			lblShipyardSystems.Text	= "";
			lblShipyards.Text				= "";
			lblShipyardSystems.Links.Clear();

			for (int i = 0; i < shipyardSystemIds.Length; i++)
			{
				StarSystem	system			= game.Universe[shipyardSystemIds[i]];
				int					start				= lblShipyardSystems.Text.Length;

				lblShipyardSystems.Text	+= system.Name + Environment.NewLine;
				lblShipyards.Text				+= system.Shipyard.Name + Environment.NewLine;

				lblShipyardSystems.Links.Add(start, system.Name.Length, system.Name);
			}

			lblShipyardSystems.Text	= lblShipyardSystems.Text.Trim();
			lblShipyards.Text				= lblShipyards.Text.Trim();
		}

		#endregion

		#region Event Handlers

		private void SystemLinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			Game.CurrentGame.SelectedSystemName	= e.Link.LinkData.ToString();
			Game.CurrentGame.ParentWindow.UpdateAll();
			Close();
		}

		private void SortLinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			Sort(((LinkLabel)sender).Name.Substring(3, 1), ((LinkLabel)sender).Text.Substring(0, 1));
			UpdateAll();
		}

		#endregion
	}
}
