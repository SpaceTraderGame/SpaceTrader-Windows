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
	public class Form_Shipyard : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label lblWelcome;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.PictureBox picShip;
		private System.Windows.Forms.Label lblDesignFee;
		private System.Windows.Forms.Button btnBuild;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.PictureBox picLogo;
		private System.Windows.Forms.GroupBox boxCosts;
		private System.Windows.Forms.GroupBox boxAllocation;
		private System.Windows.Forms.NumericUpDown numHullStrength;
		private System.Windows.Forms.Label lblHullStrenghLabel;
		private System.Windows.Forms.NumericUpDown numCargoBays;
		private System.Windows.Forms.NumericUpDown numCrewQuarters;
		private System.Windows.Forms.NumericUpDown numFuelTanks;
		private System.Windows.Forms.NumericUpDown numShieldSlots;
		private System.Windows.Forms.NumericUpDown numGadgetSlots;
		private System.Windows.Forms.NumericUpDown numWeaponSlots;
		private System.Windows.Forms.Label lblCargoBays;
		private System.Windows.Forms.Label lblFuelTanks;
		private System.Windows.Forms.Label lblCrewQuarters;
		private System.Windows.Forms.Label lblShieldSlots;
		private System.Windows.Forms.Label lblGadgetSlots;
		private System.Windows.Forms.Label lblWeaponsSlots;
		private System.Windows.Forms.Label lblShipCost;
		private System.Windows.Forms.Label lblTotalCost;
		private System.Windows.Forms.Label lblTotalCostLabel;
		private System.Windows.Forms.Label lblShipCostLabel;
		private System.Windows.Forms.Label lblDesignFeeLabel;
		private System.Windows.Forms.GroupBox boxWelcome;
		private System.Windows.Forms.GroupBox boxInfo;
		private System.Windows.Forms.Label lblUnitsLeft;
		private System.Windows.Forms.Label lblSize;
		private System.Windows.Forms.ComboBox selSize;
		private System.Windows.Forms.Label lblTemplate;
		private System.Windows.Forms.ComboBox selTemplate;
		private System.Windows.Forms.Button btnSetCustomImage;
		private System.Windows.Forms.Label lblImageLabel;
		private System.Windows.Forms.Button btnNextImage;
		private System.Windows.Forms.Button btnPrevImage;
		private System.Windows.Forms.Label lblImage;
		private System.Windows.Forms.Label lblUnitsUsedLabel;
		private System.Windows.Forms.PictureBox picInfoLine;
		private System.Windows.Forms.Label lblPctLabel;
		private System.Windows.Forms.Label lblPct;
		private System.Windows.Forms.Label lblPenaltyLabel;
		private System.Windows.Forms.Label lblPenalty;
		private System.Windows.Forms.PictureBox picCostsLine;
		private System.Windows.Forms.Label lblSizeSpecialtyLabel;
		private System.Windows.Forms.Label lblSkillLabel;
		private System.Windows.Forms.Label lblSizeSpecialty;
		private System.Windows.Forms.Label lblSkill;
		private System.Windows.Forms.Label lblSkillDescription;
		private System.Windows.Forms.Label lblWarning;
		private System.Windows.Forms.ImageList ilShipyardLogos;
		private System.Windows.Forms.OpenFileDialog dlgOpen;

		#endregion

		#region Member variables

		private Game			game					= Game.CurrentGame;
		private Shipyard	shipyard			= Game.CurrentGame.Commander.CurrentSystem.Shipyard;
		private bool			initializing	= false;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnSave;
		private ArrayList	sizes					= null;

		#endregion

		#region Methods

		public Form_Shipyard()
		{
			InitializeComponent();

			this.Text							= Functions.StringVars(Strings.ShipyardTitle, shipyard.Name);
			lblSizeSpecialty.Text	= Strings.Sizes[(int)shipyard.SpecialtySize];
			lblSkill.Text					= Strings.ShipyardSkills[(int)shipyard.Skill];
			lblWarning.Text				= Functions.StringVars(Strings.ShipyardWarning, Shipyard.PENALTY_FIRST_PCT.ToString(),
															Shipyard.PENALTY_SECOND_PCT.ToString());

			shipyard.InitializeShipSpec();
			LoadSizes();
			LoadTemplates();

			initializing					= true;
			// TODO: more stuff
			initializing					= false;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form_Shipyard));
			this.boxWelcome = new System.Windows.Forms.GroupBox();
			this.lblSkillDescription = new System.Windows.Forms.Label();
			this.lblSkill = new System.Windows.Forms.Label();
			this.lblSizeSpecialty = new System.Windows.Forms.Label();
			this.lblSkillLabel = new System.Windows.Forms.Label();
			this.lblSizeSpecialtyLabel = new System.Windows.Forms.Label();
			this.lblWelcome = new System.Windows.Forms.Label();
			this.lblWarning = new System.Windows.Forms.Label();
			this.picLogo = new System.Windows.Forms.PictureBox();
			this.boxInfo = new System.Windows.Forms.GroupBox();
			this.picInfoLine = new System.Windows.Forms.PictureBox();
			this.btnPrevImage = new System.Windows.Forms.Button();
			this.btnNextImage = new System.Windows.Forms.Button();
			this.lblImage = new System.Windows.Forms.Label();
			this.lblImageLabel = new System.Windows.Forms.Label();
			this.selTemplate = new System.Windows.Forms.ComboBox();
			this.lblTemplate = new System.Windows.Forms.Label();
			this.selSize = new System.Windows.Forms.ComboBox();
			this.lblSize = new System.Windows.Forms.Label();
			this.btnSetCustomImage = new System.Windows.Forms.Button();
			this.picShip = new System.Windows.Forms.PictureBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.lblUnitsLeft = new System.Windows.Forms.Label();
			this.lblUnitsUsedLabel = new System.Windows.Forms.Label();
			this.boxCosts = new System.Windows.Forms.GroupBox();
			this.picCostsLine = new System.Windows.Forms.PictureBox();
			this.lblPenalty = new System.Windows.Forms.Label();
			this.lblPenaltyLabel = new System.Windows.Forms.Label();
			this.lblShipCost = new System.Windows.Forms.Label();
			this.lblTotalCost = new System.Windows.Forms.Label();
			this.lblTotalCostLabel = new System.Windows.Forms.Label();
			this.lblShipCostLabel = new System.Windows.Forms.Label();
			this.lblDesignFee = new System.Windows.Forms.Label();
			this.lblDesignFeeLabel = new System.Windows.Forms.Label();
			this.btnBuild = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.boxAllocation = new System.Windows.Forms.GroupBox();
			this.lblPct = new System.Windows.Forms.Label();
			this.lblPctLabel = new System.Windows.Forms.Label();
			this.numHullStrength = new System.Windows.Forms.NumericUpDown();
			this.lblHullStrenghLabel = new System.Windows.Forms.Label();
			this.numCargoBays = new System.Windows.Forms.NumericUpDown();
			this.numCrewQuarters = new System.Windows.Forms.NumericUpDown();
			this.numFuelTanks = new System.Windows.Forms.NumericUpDown();
			this.numShieldSlots = new System.Windows.Forms.NumericUpDown();
			this.numGadgetSlots = new System.Windows.Forms.NumericUpDown();
			this.numWeaponSlots = new System.Windows.Forms.NumericUpDown();
			this.lblCargoBays = new System.Windows.Forms.Label();
			this.lblFuelTanks = new System.Windows.Forms.Label();
			this.lblCrewQuarters = new System.Windows.Forms.Label();
			this.lblShieldSlots = new System.Windows.Forms.Label();
			this.lblGadgetSlots = new System.Windows.Forms.Label();
			this.lblWeaponsSlots = new System.Windows.Forms.Label();
			this.ilShipyardLogos = new System.Windows.Forms.ImageList(this.components);
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.boxWelcome.SuspendLayout();
			this.boxInfo.SuspendLayout();
			this.boxCosts.SuspendLayout();
			this.boxAllocation.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numHullStrength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCargoBays)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCrewQuarters)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numFuelTanks)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numShieldSlots)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numGadgetSlots)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numWeaponSlots)).BeginInit();
			this.SuspendLayout();
			// 
			// boxWelcome
			// 
			this.boxWelcome.Controls.AddRange(new System.Windows.Forms.Control[] {
																																						 this.lblSkillDescription,
																																						 this.lblSkill,
																																						 this.lblSizeSpecialty,
																																						 this.lblSkillLabel,
																																						 this.lblSizeSpecialtyLabel,
																																						 this.lblWelcome,
																																						 this.lblWarning,
																																						 this.picLogo});
			this.boxWelcome.Location = new System.Drawing.Point(8, 0);
			this.boxWelcome.Name = "boxWelcome";
			this.boxWelcome.Size = new System.Drawing.Size(274, 188);
			this.boxWelcome.TabIndex = 5;
			this.boxWelcome.TabStop = false;
			// 
			// lblSkillDescription
			// 
			this.lblSkillDescription.Location = new System.Drawing.Point(8, 96);
			this.lblSkillDescription.Name = "lblSkillDescription";
			this.lblSkillDescription.Size = new System.Drawing.Size(260, 26);
			this.lblSkillDescription.TabIndex = 27;
			this.lblSkillDescription.Text = "All ships constructed at this shipyard use 2 fewer units per crew quarter.";
			// 
			// lblSkill
			// 
			this.lblSkill.Location = new System.Drawing.Point(180, 76);
			this.lblSkill.Name = "lblSkill";
			this.lblSkill.Size = new System.Drawing.Size(87, 13);
			this.lblSkill.TabIndex = 26;
			this.lblSkill.Text = "Crew Quartering";
			// 
			// lblSizeSpecialty
			// 
			this.lblSizeSpecialty.Location = new System.Drawing.Point(180, 60);
			this.lblSizeSpecialty.Name = "lblSizeSpecialty";
			this.lblSizeSpecialty.Size = new System.Drawing.Size(64, 13);
			this.lblSizeSpecialty.TabIndex = 25;
			this.lblSizeSpecialty.Text = "Gargantuan";
			// 
			// lblSkillLabel
			// 
			this.lblSkillLabel.AutoSize = true;
			this.lblSkillLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSkillLabel.Location = new System.Drawing.Point(92, 76);
			this.lblSkillLabel.Name = "lblSkillLabel";
			this.lblSkillLabel.Size = new System.Drawing.Size(72, 13);
			this.lblSkillLabel.TabIndex = 24;
			this.lblSkillLabel.Text = "Special Skill:";
			// 
			// lblSizeSpecialtyLabel
			// 
			this.lblSizeSpecialtyLabel.AutoSize = true;
			this.lblSizeSpecialtyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSizeSpecialtyLabel.Location = new System.Drawing.Point(92, 60);
			this.lblSizeSpecialtyLabel.Name = "lblSizeSpecialtyLabel";
			this.lblSizeSpecialtyLabel.Size = new System.Drawing.Size(82, 13);
			this.lblSizeSpecialtyLabel.TabIndex = 23;
			this.lblSizeSpecialtyLabel.Text = "Size Specialty:";
			// 
			// lblWelcome
			// 
			this.lblWelcome.Location = new System.Drawing.Point(92, 12);
			this.lblWelcome.Name = "lblWelcome";
			this.lblWelcome.Size = new System.Drawing.Size(176, 40);
			this.lblWelcome.TabIndex = 3;
			this.lblWelcome.Text = "Welcome to Loronar Corporation Shipyards! Our best engineer, Obi-Wan, is at your " +
				"service.";
			// 
			// lblWarning
			// 
			this.lblWarning.Location = new System.Drawing.Point(8, 130);
			this.lblWarning.Name = "lblWarning";
			this.lblWarning.Size = new System.Drawing.Size(260, 52);
			this.lblWarning.TabIndex = 5;
			this.lblWarning.Text = "Bear in mind that getting too close to the maximum number of units will result in" +
				" a \"Crowding Penalty.\"  There is a modest penalty at 80%, and a more severe one " +
				"at 90%.";
			// 
			// picLogo
			// 
			this.picLogo.Image = ((System.Drawing.Bitmap)(resources.GetObject("picLogo.Image")));
			this.picLogo.Location = new System.Drawing.Point(8, 12);
			this.picLogo.Name = "picLogo";
			this.picLogo.Size = new System.Drawing.Size(80, 80);
			this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picLogo.TabIndex = 22;
			this.picLogo.TabStop = false;
			// 
			// boxInfo
			// 
			this.boxInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
																																					this.btnSave,
																																					this.btnLoad,
																																					this.picInfoLine,
																																					this.btnPrevImage,
																																					this.btnNextImage,
																																					this.lblImage,
																																					this.lblImageLabel,
																																					this.selTemplate,
																																					this.lblTemplate,
																																					this.selSize,
																																					this.lblSize,
																																					this.btnSetCustomImage,
																																					this.picShip,
																																					this.txtName,
																																					this.lblName});
			this.boxInfo.Location = new System.Drawing.Point(8, 192);
			this.boxInfo.Name = "boxInfo";
			this.boxInfo.Size = new System.Drawing.Size(274, 160);
			this.boxInfo.TabIndex = 6;
			this.boxInfo.TabStop = false;
			this.boxInfo.Text = "Info";
			// 
			// picInfoLine
			// 
			this.picInfoLine.BackColor = System.Drawing.Color.DimGray;
			this.picInfoLine.Location = new System.Drawing.Point(8, 89);
			this.picInfoLine.Name = "picInfoLine";
			this.picInfoLine.Size = new System.Drawing.Size(258, 1);
			this.picInfoLine.TabIndex = 132;
			this.picInfoLine.TabStop = false;
			// 
			// btnPrevImage
			// 
			this.btnPrevImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrevImage.Location = new System.Drawing.Point(158, 95);
			this.btnPrevImage.Name = "btnPrevImage";
			this.btnPrevImage.Size = new System.Drawing.Size(18, 18);
			this.btnPrevImage.TabIndex = 59;
			this.btnPrevImage.Text = "<";
			this.btnPrevImage.Click += new System.EventHandler(this.btnPrevImage_Click);
			// 
			// btnNextImage
			// 
			this.btnNextImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNextImage.Location = new System.Drawing.Point(246, 95);
			this.btnNextImage.Name = "btnNextImage";
			this.btnNextImage.Size = new System.Drawing.Size(18, 18);
			this.btnNextImage.TabIndex = 60;
			this.btnNextImage.Text = ">";
			this.btnNextImage.Click += new System.EventHandler(this.btnNextImage_Click);
			// 
			// lblImage
			// 
			this.lblImage.Location = new System.Drawing.Point(178, 98);
			this.lblImage.Name = "lblImage";
			this.lblImage.Size = new System.Drawing.Size(70, 13);
			this.lblImage.TabIndex = 61;
			this.lblImage.Text = "Grasshopper";
			this.lblImage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblImageLabel
			// 
			this.lblImageLabel.AutoSize = true;
			this.lblImageLabel.Location = new System.Drawing.Point(8, 95);
			this.lblImageLabel.Name = "lblImageLabel";
			this.lblImageLabel.Size = new System.Drawing.Size(39, 13);
			this.lblImageLabel.TabIndex = 22;
			this.lblImageLabel.Text = "Image:";
			// 
			// selTemplate
			// 
			this.selTemplate.Location = new System.Drawing.Point(80, 16);
			this.selTemplate.Name = "selTemplate";
			this.selTemplate.Size = new System.Drawing.Size(136, 21);
			this.selTemplate.TabIndex = 21;
			this.selTemplate.Text = "Gargantuan";
			// 
			// lblTemplate
			// 
			this.lblTemplate.AutoSize = true;
			this.lblTemplate.Location = new System.Drawing.Point(8, 19);
			this.lblTemplate.Name = "lblTemplate";
			this.lblTemplate.Size = new System.Drawing.Size(55, 13);
			this.lblTemplate.TabIndex = 20;
			this.lblTemplate.Text = "Template:";
			// 
			// selSize
			// 
			this.selSize.Location = new System.Drawing.Point(80, 63);
			this.selSize.Name = "selSize";
			this.selSize.Size = new System.Drawing.Size(184, 21);
			this.selSize.TabIndex = 19;
			this.selSize.Text = "Gargantuan (Max 888 Units)";
			this.selSize.SelectedIndexChanged += new System.EventHandler(this.selSize_SelectedIndexChanged);
			// 
			// lblSize
			// 
			this.lblSize.AutoSize = true;
			this.lblSize.Location = new System.Drawing.Point(8, 66);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(29, 13);
			this.lblSize.TabIndex = 18;
			this.lblSize.Text = "Size:";
			// 
			// btnSetCustomImage
			// 
			this.btnSetCustomImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSetCustomImage.Location = new System.Drawing.Point(158, 121);
			this.btnSetCustomImage.Name = "btnSetCustomImage";
			this.btnSetCustomImage.Size = new System.Drawing.Size(106, 22);
			this.btnSetCustomImage.TabIndex = 15;
			this.btnSetCustomImage.Text = "Set Custom...";
			this.btnSetCustomImage.Click += new System.EventHandler(this.btnSetCustomImage_Click);
			// 
			// picShip
			// 
			this.picShip.BackColor = System.Drawing.Color.White;
			this.picShip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picShip.Location = new System.Drawing.Point(80, 95);
			this.picShip.Name = "picShip";
			this.picShip.Size = new System.Drawing.Size(70, 58);
			this.picShip.TabIndex = 14;
			this.picShip.TabStop = false;
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(80, 40);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(136, 20);
			this.txtName.TabIndex = 6;
			this.txtName.Text = "";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(8, 44);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(63, 13);
			this.lblName.TabIndex = 5;
			this.lblName.Text = "Ship Name:";
			// 
			// lblUnitsLeft
			// 
			this.lblUnitsLeft.Location = new System.Drawing.Point(110, 186);
			this.lblUnitsLeft.Name = "lblUnitsLeft";
			this.lblUnitsLeft.Size = new System.Drawing.Size(23, 13);
			this.lblUnitsLeft.TabIndex = 17;
			this.lblUnitsLeft.Text = "888";
			// 
			// lblUnitsUsedLabel
			// 
			this.lblUnitsUsedLabel.AutoSize = true;
			this.lblUnitsUsedLabel.Location = new System.Drawing.Point(8, 186);
			this.lblUnitsUsedLabel.Name = "lblUnitsUsedLabel";
			this.lblUnitsUsedLabel.Size = new System.Drawing.Size(63, 13);
			this.lblUnitsUsedLabel.TabIndex = 16;
			this.lblUnitsUsedLabel.Text = "Units Used:";
			// 
			// boxCosts
			// 
			this.boxCosts.Controls.AddRange(new System.Windows.Forms.Control[] {
																																					 this.picCostsLine,
																																					 this.lblPenalty,
																																					 this.lblPenaltyLabel,
																																					 this.lblShipCost,
																																					 this.lblTotalCost,
																																					 this.lblTotalCostLabel,
																																					 this.lblShipCostLabel,
																																					 this.lblDesignFee,
																																					 this.lblDesignFeeLabel});
			this.boxCosts.Location = new System.Drawing.Point(290, 230);
			this.boxCosts.Name = "boxCosts";
			this.boxCosts.Size = new System.Drawing.Size(184, 90);
			this.boxCosts.TabIndex = 14;
			this.boxCosts.TabStop = false;
			this.boxCosts.Text = "Costs";
			// 
			// picCostsLine
			// 
			this.picCostsLine.BackColor = System.Drawing.Color.DimGray;
			this.picCostsLine.Location = new System.Drawing.Point(8, 64);
			this.picCostsLine.Name = "picCostsLine";
			this.picCostsLine.Size = new System.Drawing.Size(168, 1);
			this.picCostsLine.TabIndex = 133;
			this.picCostsLine.TabStop = false;
			// 
			// lblPenalty
			// 
			this.lblPenalty.Location = new System.Drawing.Point(110, 32);
			this.lblPenalty.Name = "lblPenalty";
			this.lblPenalty.Size = new System.Drawing.Size(70, 16);
			this.lblPenalty.TabIndex = 21;
			this.lblPenalty.Text = "8,888,888 cr.";
			this.lblPenalty.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblPenaltyLabel
			// 
			this.lblPenaltyLabel.AutoSize = true;
			this.lblPenaltyLabel.Location = new System.Drawing.Point(8, 32);
			this.lblPenaltyLabel.Name = "lblPenaltyLabel";
			this.lblPenaltyLabel.Size = new System.Drawing.Size(96, 13);
			this.lblPenaltyLabel.TabIndex = 20;
			this.lblPenaltyLabel.Text = "Crowding Penalty:";
			// 
			// lblShipCost
			// 
			this.lblShipCost.Location = new System.Drawing.Point(110, 16);
			this.lblShipCost.Name = "lblShipCost";
			this.lblShipCost.Size = new System.Drawing.Size(70, 16);
			this.lblShipCost.TabIndex = 19;
			this.lblShipCost.Text = "8,888,888 cr.";
			this.lblShipCost.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTotalCost
			// 
			this.lblTotalCost.Location = new System.Drawing.Point(110, 68);
			this.lblTotalCost.Name = "lblTotalCost";
			this.lblTotalCost.Size = new System.Drawing.Size(70, 16);
			this.lblTotalCost.TabIndex = 18;
			this.lblTotalCost.Text = "8,888,888 cr.";
			this.lblTotalCost.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTotalCostLabel
			// 
			this.lblTotalCostLabel.AutoSize = true;
			this.lblTotalCostLabel.Location = new System.Drawing.Point(8, 68);
			this.lblTotalCostLabel.Name = "lblTotalCostLabel";
			this.lblTotalCostLabel.Size = new System.Drawing.Size(59, 13);
			this.lblTotalCostLabel.TabIndex = 17;
			this.lblTotalCostLabel.Text = "Total Cost:";
			// 
			// lblShipCostLabel
			// 
			this.lblShipCostLabel.AutoSize = true;
			this.lblShipCostLabel.Location = new System.Drawing.Point(8, 16);
			this.lblShipCostLabel.Name = "lblShipCostLabel";
			this.lblShipCostLabel.Size = new System.Drawing.Size(56, 13);
			this.lblShipCostLabel.TabIndex = 16;
			this.lblShipCostLabel.Text = "Ship Cost:";
			// 
			// lblDesignFee
			// 
			this.lblDesignFee.Location = new System.Drawing.Point(110, 48);
			this.lblDesignFee.Name = "lblDesignFee";
			this.lblDesignFee.Size = new System.Drawing.Size(70, 16);
			this.lblDesignFee.TabIndex = 15;
			this.lblDesignFee.Text = "888,888 cr.";
			this.lblDesignFee.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblDesignFeeLabel
			// 
			this.lblDesignFeeLabel.AutoSize = true;
			this.lblDesignFeeLabel.Location = new System.Drawing.Point(8, 48);
			this.lblDesignFeeLabel.Name = "lblDesignFeeLabel";
			this.lblDesignFeeLabel.Size = new System.Drawing.Size(65, 13);
			this.lblDesignFeeLabel.TabIndex = 14;
			this.lblDesignFeeLabel.Text = "Design Fee:";
			// 
			// btnBuild
			// 
			this.btnBuild.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnBuild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuild.Location = new System.Drawing.Point(386, 328);
			this.btnBuild.Name = "btnBuild";
			this.btnBuild.Size = new System.Drawing.Size(88, 22);
			this.btnBuild.TabIndex = 21;
			this.btnBuild.Text = "Construct Ship";
			this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(290, 328);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(88, 22);
			this.btnCancel.TabIndex = 20;
			this.btnCancel.Text = "Cancel Design";
			// 
			// boxAllocation
			// 
			this.boxAllocation.Controls.AddRange(new System.Windows.Forms.Control[] {
																																								this.lblPct,
																																								this.lblPctLabel,
																																								this.numHullStrength,
																																								this.lblHullStrenghLabel,
																																								this.numCargoBays,
																																								this.numCrewQuarters,
																																								this.numFuelTanks,
																																								this.numShieldSlots,
																																								this.numGadgetSlots,
																																								this.numWeaponSlots,
																																								this.lblCargoBays,
																																								this.lblFuelTanks,
																																								this.lblCrewQuarters,
																																								this.lblShieldSlots,
																																								this.lblGadgetSlots,
																																								this.lblWeaponsSlots,
																																								this.lblUnitsUsedLabel,
																																								this.lblUnitsLeft});
			this.boxAllocation.Location = new System.Drawing.Point(290, 0);
			this.boxAllocation.Name = "boxAllocation";
			this.boxAllocation.Size = new System.Drawing.Size(184, 226);
			this.boxAllocation.TabIndex = 15;
			this.boxAllocation.TabStop = false;
			this.boxAllocation.Text = "Space Allocation";
			// 
			// lblPct
			// 
			this.lblPct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPct.ForeColor = System.Drawing.Color.Red;
			this.lblPct.Location = new System.Drawing.Point(110, 204);
			this.lblPct.Name = "lblPct";
			this.lblPct.Size = new System.Drawing.Size(34, 13);
			this.lblPct.TabIndex = 19;
			this.lblPct.Text = "888%";
			// 
			// lblPctLabel
			// 
			this.lblPctLabel.AutoSize = true;
			this.lblPctLabel.Location = new System.Drawing.Point(8, 204);
			this.lblPctLabel.Name = "lblPctLabel";
			this.lblPctLabel.Size = new System.Drawing.Size(54, 13);
			this.lblPctLabel.TabIndex = 18;
			this.lblPctLabel.Text = "% of Max:";
			// 
			// numHullStrength
			// 
			this.numHullStrength.Location = new System.Drawing.Point(110, 16);
			this.numHullStrength.Name = "numHullStrength";
			this.numHullStrength.Size = new System.Drawing.Size(64, 20);
			this.numHullStrength.TabIndex = 14;
			this.numHullStrength.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numHullStrength.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// lblHullStrenghLabel
			// 
			this.lblHullStrenghLabel.AutoSize = true;
			this.lblHullStrenghLabel.Location = new System.Drawing.Point(8, 18);
			this.lblHullStrenghLabel.Name = "lblHullStrenghLabel";
			this.lblHullStrenghLabel.Size = new System.Drawing.Size(70, 13);
			this.lblHullStrenghLabel.TabIndex = 13;
			this.lblHullStrenghLabel.Text = "Hull Strengh:";
			// 
			// numCargoBays
			// 
			this.numCargoBays.Enabled = false;
			this.numCargoBays.Location = new System.Drawing.Point(110, 64);
			this.numCargoBays.Name = "numCargoBays";
			this.numCargoBays.Size = new System.Drawing.Size(64, 20);
			this.numCargoBays.TabIndex = 11;
			this.numCargoBays.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numCargoBays.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// numCrewQuarters
			// 
			this.numCrewQuarters.Location = new System.Drawing.Point(110, 88);
			this.numCrewQuarters.Name = "numCrewQuarters";
			this.numCrewQuarters.Size = new System.Drawing.Size(64, 20);
			this.numCrewQuarters.TabIndex = 10;
			this.numCrewQuarters.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numCrewQuarters.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// numFuelTanks
			// 
			this.numFuelTanks.Location = new System.Drawing.Point(110, 40);
			this.numFuelTanks.Name = "numFuelTanks";
			this.numFuelTanks.Size = new System.Drawing.Size(64, 20);
			this.numFuelTanks.TabIndex = 9;
			this.numFuelTanks.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numFuelTanks.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// numShieldSlots
			// 
			this.numShieldSlots.Location = new System.Drawing.Point(110, 136);
			this.numShieldSlots.Name = "numShieldSlots";
			this.numShieldSlots.Size = new System.Drawing.Size(64, 20);
			this.numShieldSlots.TabIndex = 8;
			this.numShieldSlots.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numShieldSlots.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// numGadgetSlots
			// 
			this.numGadgetSlots.Location = new System.Drawing.Point(110, 160);
			this.numGadgetSlots.Name = "numGadgetSlots";
			this.numGadgetSlots.Size = new System.Drawing.Size(64, 20);
			this.numGadgetSlots.TabIndex = 7;
			this.numGadgetSlots.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numGadgetSlots.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// numWeaponSlots
			// 
			this.numWeaponSlots.Location = new System.Drawing.Point(110, 112);
			this.numWeaponSlots.Name = "numWeaponSlots";
			this.numWeaponSlots.Size = new System.Drawing.Size(64, 20);
			this.numWeaponSlots.TabIndex = 6;
			this.numWeaponSlots.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numWeaponSlots.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// lblCargoBays
			// 
			this.lblCargoBays.AutoSize = true;
			this.lblCargoBays.Location = new System.Drawing.Point(8, 66);
			this.lblCargoBays.Name = "lblCargoBays";
			this.lblCargoBays.Size = new System.Drawing.Size(66, 13);
			this.lblCargoBays.TabIndex = 5;
			this.lblCargoBays.Text = "Cargo Bays:";
			// 
			// lblFuelTanks
			// 
			this.lblFuelTanks.AutoSize = true;
			this.lblFuelTanks.Location = new System.Drawing.Point(8, 42);
			this.lblFuelTanks.Name = "lblFuelTanks";
			this.lblFuelTanks.Size = new System.Drawing.Size(63, 13);
			this.lblFuelTanks.TabIndex = 4;
			this.lblFuelTanks.Text = "Fuel Tanks:";
			// 
			// lblCrewQuarters
			// 
			this.lblCrewQuarters.AutoSize = true;
			this.lblCrewQuarters.Location = new System.Drawing.Point(8, 90);
			this.lblCrewQuarters.Name = "lblCrewQuarters";
			this.lblCrewQuarters.Size = new System.Drawing.Size(81, 13);
			this.lblCrewQuarters.TabIndex = 3;
			this.lblCrewQuarters.Text = "Crew Quarters:";
			// 
			// lblShieldSlots
			// 
			this.lblShieldSlots.AutoSize = true;
			this.lblShieldSlots.Location = new System.Drawing.Point(8, 138);
			this.lblShieldSlots.Name = "lblShieldSlots";
			this.lblShieldSlots.Size = new System.Drawing.Size(67, 13);
			this.lblShieldSlots.TabIndex = 2;
			this.lblShieldSlots.Text = "Shield Slots:";
			// 
			// lblGadgetSlots
			// 
			this.lblGadgetSlots.AutoSize = true;
			this.lblGadgetSlots.Location = new System.Drawing.Point(8, 162);
			this.lblGadgetSlots.Name = "lblGadgetSlots";
			this.lblGadgetSlots.Size = new System.Drawing.Size(73, 13);
			this.lblGadgetSlots.TabIndex = 1;
			this.lblGadgetSlots.Text = "Gadget Slots:";
			// 
			// lblWeaponsSlots
			// 
			this.lblWeaponsSlots.AutoSize = true;
			this.lblWeaponsSlots.Location = new System.Drawing.Point(8, 114);
			this.lblWeaponsSlots.Name = "lblWeaponsSlots";
			this.lblWeaponsSlots.Size = new System.Drawing.Size(78, 13);
			this.lblWeaponsSlots.TabIndex = 0;
			this.lblWeaponsSlots.Text = "Weapon Slots:";
			// 
			// ilShipyardLogos
			// 
			this.ilShipyardLogos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.ilShipyardLogos.ImageSize = new System.Drawing.Size(80, 80);
			this.ilShipyardLogos.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// dlgOpen
			// 
			this.dlgOpen.Filter = "Windows Bitmaps (*.bmp)|*bmp|All Files (*.*)|*.*";
			this.dlgOpen.Title = "Open Ship Image";
			// 
			// btnLoad
			// 
			this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoad.Location = new System.Drawing.Point(220, 16);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(44, 20);
			this.btnLoad.TabIndex = 133;
			this.btnLoad.Text = "Load";
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnSave
			// 
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Location = new System.Drawing.Point(220, 40);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(44, 20);
			this.btnSave.TabIndex = 134;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// Form_Shipyard
			// 
			this.AcceptButton = this.btnBuild;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(482, 359);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.boxAllocation,
																																	this.boxCosts,
																																	this.boxInfo,
																																	this.boxWelcome,
																																	this.btnCancel,
																																	this.btnBuild});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form_Shipyard";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Ship Design at XXXX Shipyards";
			this.boxWelcome.ResumeLayout(false);
			this.boxInfo.ResumeLayout(false);
			this.boxCosts.ResumeLayout(false);
			this.boxAllocation.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numHullStrength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCargoBays)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCrewQuarters)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numFuelTanks)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numShieldSlots)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numGadgetSlots)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numWeaponSlots)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void LoadSizes()
		{
			sizes	= new ArrayList(6);

			foreach (Size size in shipyard.AvailableSizes)
			{
				sizes.Add(size);
				selSize.Items.Add(Functions.StringVars(Strings.ShipyardSizeItem, Strings.Sizes[(int)size],
					Functions.Multiples(Shipyard.MAX_UNITS[(int)size], Strings.ShipyardUnit)));
			}

			selSize.SelectedIndex	= 0;
		}

		private void LoadTemplates()
		{
			selTemplate.Items.Add("<new>");

			foreach (int i in new int[] { 0, 1, 2 })
				selTemplate.Items.Add("item " + i.ToString());

			selTemplate.SelectedIndex	= 0;
		}

		private void UpdateAllocation()
		{
			numHullStrength.Minimum		= shipyard.BaseHull;
			numHullStrength.Increment	= shipyard.PerUnitHull;

			numFuelTanks.Minimum			= shipyard.BaseFuel;
			numFuelTanks.Increment		= shipyard.PerUnitFuel;
		}

		#endregion

		#region Event Handlers

		private void btnBuild_Click(object sender, System.EventArgs e)
		{
			return;
			// Pay the design fee and construction price
			int price = shipyard.ShipSpec.Price + shipyard.DesignFee;
			if (game.Commander.Cash >= price)
			{
				shipyard.ShipSpec.FuelCost		= 0;
				shipyard.ShipSpec.RepairCost	= 0;
				shipyard.ShipSpec.Price				= 0;
				Consts.ShipSpecs[(int)ShipType.Custom]	 = shipyard.ShipSpec;
				game.Commander.Ship											 = new Ship(ShipType.Custom);
				game.Commander.Cash											-= price;
				FormAlert.Alert(AlertType.ShipDesignThanks, this, shipyard.Name);
			}
			else
			{
				FormAlert.Alert(AlertType.ShipDesignIF, this);
			}
		}

		private void btnLoad_Click(object sender, System.EventArgs e)
		{
			// TODO: Load Template
		}

		private void btnNextImage_Click(object sender, System.EventArgs e)
		{
			// TODO: Show next ship image.
		}

		private void btnPrevImage_Click(object sender, System.EventArgs e)
		{
			// TODO: Show previous ship image.
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			// TODO: save template.
		}

		private void btnSetCustomImage_Click(object sender, System.EventArgs e)
		{
			if (dlgOpen.ShowDialog(this) == DialogResult.OK)
			{
				// TODO: get ship images.

				ImageList	shipImages	= game.ParentWindow.ShipImages;
				for (int i = 0; i < 4; i++)
					shipImages.Images.RemoveAt(shipImages.Images.Count);

				shipImages.Images.Add(new Bitmap(""));
			}
		}

		private void num_ValueChanged(object sender, System.EventArgs e)
		{
//			if (!initializing)
//				checkValidity(false);
		}

		private void num_ValueEnter(object sender, System.EventArgs e)
		{
			((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Value.ToString().Length);
		}

		private void selSize_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			shipyard.ShipSpec.Size	= (Size)sizes[selSize.SelectedIndex];
			UpdateAllocation();
		}

		#endregion
	}
}
