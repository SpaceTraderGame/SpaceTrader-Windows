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
using System.IO;
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
		private System.Windows.Forms.Button btnConstruct;
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
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Label lblTradeInLabel;
		private System.Windows.Forms.Label lblTradeIn;
		private System.Windows.Forms.Label lblUnitsUsed;
		private System.Windows.Forms.Label lblDisabledPct;
		private System.Windows.Forms.SaveFileDialog dlgSave;

		#endregion

		#region Member variables

		private Game				game					= Game.CurrentGame;
		private Shipyard		shipyard			= Game.CurrentGame.Commander.CurrentSystem.Shipyard;
		private bool				loading				= false;
		private ArrayList		sizes					= null;
		private Image[]			customImages	= new Image[Consts.ImagesPerShip];
		private int					imgIndex			= 0;
		private System.Windows.Forms.Label lblDisabledName;
		private ShipType[]	imgTypes			= new ShipType[]
																				{
																					ShipType.Flea,
																					ShipType.Gnat,
																					ShipType.Firefly,
																					ShipType.Mosquito,
																					ShipType.Bumblebee,
																					ShipType.Beetle,
																					ShipType.Hornet,
																					ShipType.Grasshopper,
																					ShipType.Termite,
																					ShipType.Wasp,
																					ShipType.Custom
																				};

		#endregion

		#region Methods

		public Form_Shipyard()
		{
			InitializeComponent();

			this.Text									= Functions.StringVars(Strings.ShipyardTitle, shipyard.Name);
			picLogo.Image							= ilShipyardLogos.Images[(int)shipyard.Id];
			lblWelcome.Text						= Functions.StringVars(Strings.ShipyardWelcome, shipyard.Name, shipyard.Engineer);
			lblSizeSpecialty.Text			= Strings.Sizes[(int)shipyard.SpecialtySize];
			lblSkill.Text							= Strings.ShipyardSkills[(int)shipyard.Skill];
			lblSkillDescription.Text	= Strings.ShipyardSkillDescriptions[(int)shipyard.Skill];
			lblWarning.Text						= Functions.StringVars(Strings.ShipyardWarning, Shipyard.PENALTY_FIRST_PCT.ToString(),
																	Shipyard.PENALTY_SECOND_PCT.ToString());

			dlgOpen.InitialDirectory	= Consts.CustomImagesDirectory;
			dlgSave.InitialDirectory	= Consts.CustomTemplatesDirectory;
			lblDisabledName.Image			= game.ParentWindow.DirectionImages.Images[Consts.DirectionDown];
			lblDisabledPct.Image			= game.ParentWindow.DirectionImages.Images[Consts.DirectionDown];

			LoadSizes();
			LoadTemplateList();
			LoadSelectedTemplate();
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
			this.btnSave = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
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
			this.lblUnitsUsed = new System.Windows.Forms.Label();
			this.lblUnitsUsedLabel = new System.Windows.Forms.Label();
			this.boxCosts = new System.Windows.Forms.GroupBox();
			this.lblTradeIn = new System.Windows.Forms.Label();
			this.lblTradeInLabel = new System.Windows.Forms.Label();
			this.picCostsLine = new System.Windows.Forms.PictureBox();
			this.lblPenalty = new System.Windows.Forms.Label();
			this.lblPenaltyLabel = new System.Windows.Forms.Label();
			this.lblShipCost = new System.Windows.Forms.Label();
			this.lblTotalCost = new System.Windows.Forms.Label();
			this.lblTotalCostLabel = new System.Windows.Forms.Label();
			this.lblShipCostLabel = new System.Windows.Forms.Label();
			this.lblDesignFee = new System.Windows.Forms.Label();
			this.lblDesignFeeLabel = new System.Windows.Forms.Label();
			this.btnConstruct = new System.Windows.Forms.Button();
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
			this.lblDisabledPct = new System.Windows.Forms.Label();
			this.dlgSave = new System.Windows.Forms.SaveFileDialog();
			this.lblDisabledName = new System.Windows.Forms.Label();
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
																																						 this.lblWarning,
																																						 this.picLogo,
																																						 this.lblWelcome});
			this.boxWelcome.Location = new System.Drawing.Point(8, 0);
			this.boxWelcome.Name = "boxWelcome";
			this.boxWelcome.Size = new System.Drawing.Size(270, 204);
			this.boxWelcome.TabIndex = 1;
			this.boxWelcome.TabStop = false;
			// 
			// lblSkillDescription
			// 
			this.lblSkillDescription.Location = new System.Drawing.Point(8, 98);
			this.lblSkillDescription.Name = "lblSkillDescription";
			this.lblSkillDescription.Size = new System.Drawing.Size(258, 26);
			this.lblSkillDescription.TabIndex = 27;
			this.lblSkillDescription.Text = "All ships constructed at this shipyard use 2 fewer units per crew quarter.";
			// 
			// lblSkill
			// 
			this.lblSkill.Location = new System.Drawing.Point(180, 79);
			this.lblSkill.Name = "lblSkill";
			this.lblSkill.Size = new System.Drawing.Size(87, 13);
			this.lblSkill.TabIndex = 26;
			this.lblSkill.Text = "Crew Quartering";
			// 
			// lblSizeSpecialty
			// 
			this.lblSizeSpecialty.Location = new System.Drawing.Point(180, 65);
			this.lblSizeSpecialty.Name = "lblSizeSpecialty";
			this.lblSizeSpecialty.Size = new System.Drawing.Size(64, 13);
			this.lblSizeSpecialty.TabIndex = 25;
			this.lblSizeSpecialty.Text = "Gargantuan";
			// 
			// lblSkillLabel
			// 
			this.lblSkillLabel.AutoSize = true;
			this.lblSkillLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSkillLabel.Location = new System.Drawing.Point(92, 79);
			this.lblSkillLabel.Name = "lblSkillLabel";
			this.lblSkillLabel.Size = new System.Drawing.Size(72, 13);
			this.lblSkillLabel.TabIndex = 24;
			this.lblSkillLabel.Text = "Special Skill:";
			// 
			// lblSizeSpecialtyLabel
			// 
			this.lblSizeSpecialtyLabel.AutoSize = true;
			this.lblSizeSpecialtyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSizeSpecialtyLabel.Location = new System.Drawing.Point(92, 65);
			this.lblSizeSpecialtyLabel.Name = "lblSizeSpecialtyLabel";
			this.lblSizeSpecialtyLabel.Size = new System.Drawing.Size(82, 13);
			this.lblSizeSpecialtyLabel.TabIndex = 23;
			this.lblSizeSpecialtyLabel.Text = "Size Specialty:";
			// 
			// lblWelcome
			// 
			this.lblWelcome.Location = new System.Drawing.Point(92, 12);
			this.lblWelcome.Name = "lblWelcome";
			this.lblWelcome.Size = new System.Drawing.Size(176, 52);
			this.lblWelcome.TabIndex = 3;
			this.lblWelcome.Text = "Welcome to Sorosuub Engineering Shipyards! Our best engineer, Obi-Wan, is at your" +
				" service.";
			// 
			// lblWarning
			// 
			this.lblWarning.Location = new System.Drawing.Point(8, 134);
			this.lblWarning.Name = "lblWarning";
			this.lblWarning.Size = new System.Drawing.Size(258, 65);
			this.lblWarning.TabIndex = 5;
			this.lblWarning.Text = "Bear in mind that getting too close to the maximum number of units will result in" +
				" a \"Crowding Penalty\" due to the engineering difficulty of squeezing everything " +
				"in.  There is a modest penalty at 80%, and a more severe one at 90%.";
			// 
			// picLogo
			// 
			this.picLogo.BackColor = System.Drawing.Color.Black;
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
			this.boxInfo.Location = new System.Drawing.Point(8, 208);
			this.boxInfo.Name = "boxInfo";
			this.boxInfo.Size = new System.Drawing.Size(270, 160);
			this.boxInfo.TabIndex = 2;
			this.boxInfo.TabStop = false;
			this.boxInfo.Text = "Info";
			// 
			// btnSave
			// 
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Location = new System.Drawing.Point(216, 40);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(44, 20);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnSave.MouseEnter += new System.EventHandler(this.btnSave_MouseEnter);
			this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
			// 
			// btnLoad
			// 
			this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLoad.Location = new System.Drawing.Point(216, 16);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(44, 20);
			this.btnLoad.TabIndex = 2;
			this.btnLoad.Text = "Load";
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// picInfoLine
			// 
			this.picInfoLine.BackColor = System.Drawing.Color.DimGray;
			this.picInfoLine.Location = new System.Drawing.Point(8, 89);
			this.picInfoLine.Name = "picInfoLine";
			this.picInfoLine.Size = new System.Drawing.Size(254, 1);
			this.picInfoLine.TabIndex = 132;
			this.picInfoLine.TabStop = false;
			// 
			// btnPrevImage
			// 
			this.btnPrevImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrevImage.Location = new System.Drawing.Point(154, 95);
			this.btnPrevImage.Name = "btnPrevImage";
			this.btnPrevImage.Size = new System.Drawing.Size(18, 18);
			this.btnPrevImage.TabIndex = 6;
			this.btnPrevImage.Text = "<";
			this.btnPrevImage.Click += new System.EventHandler(this.btnPrevImage_Click);
			// 
			// btnNextImage
			// 
			this.btnNextImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNextImage.Location = new System.Drawing.Point(242, 95);
			this.btnNextImage.Name = "btnNextImage";
			this.btnNextImage.Size = new System.Drawing.Size(18, 18);
			this.btnNextImage.TabIndex = 7;
			this.btnNextImage.Text = ">";
			this.btnNextImage.Click += new System.EventHandler(this.btnNextImage_Click);
			// 
			// lblImage
			// 
			this.lblImage.Location = new System.Drawing.Point(174, 98);
			this.lblImage.Name = "lblImage";
			this.lblImage.Size = new System.Drawing.Size(70, 13);
			this.lblImage.TabIndex = 61;
			this.lblImage.Text = "Custom Ship";
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
			this.selTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.selTemplate.Location = new System.Drawing.Point(80, 16);
			this.selTemplate.Name = "selTemplate";
			this.selTemplate.Size = new System.Drawing.Size(132, 21);
			this.selTemplate.TabIndex = 1;
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
			this.selSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.selSize.Location = new System.Drawing.Point(80, 63);
			this.selSize.Name = "selSize";
			this.selSize.Size = new System.Drawing.Size(180, 21);
			this.selSize.TabIndex = 5;
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
			this.btnSetCustomImage.Location = new System.Drawing.Point(154, 121);
			this.btnSetCustomImage.Name = "btnSetCustomImage";
			this.btnSetCustomImage.Size = new System.Drawing.Size(106, 22);
			this.btnSetCustomImage.TabIndex = 8;
			this.btnSetCustomImage.Text = "Set Custom...";
			this.btnSetCustomImage.Click += new System.EventHandler(this.btnSetCustomImage_Click);
			// 
			// picShip
			// 
			this.picShip.BackColor = System.Drawing.Color.White;
			this.picShip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picShip.Location = new System.Drawing.Point(80, 95);
			this.picShip.Name = "picShip";
			this.picShip.Size = new System.Drawing.Size(66, 54);
			this.picShip.TabIndex = 14;
			this.picShip.TabStop = false;
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(80, 40);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(132, 20);
			this.txtName.TabIndex = 3;
			this.txtName.Text = "";
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
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
			// lblUnitsUsed
			// 
			this.lblUnitsUsed.Location = new System.Drawing.Point(110, 186);
			this.lblUnitsUsed.Name = "lblUnitsUsed";
			this.lblUnitsUsed.Size = new System.Drawing.Size(23, 13);
			this.lblUnitsUsed.TabIndex = 17;
			this.lblUnitsUsed.Text = "888";
			this.lblUnitsUsed.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
																																					 this.lblTradeIn,
																																					 this.lblTradeInLabel,
																																					 this.picCostsLine,
																																					 this.lblPenalty,
																																					 this.lblPenaltyLabel,
																																					 this.lblShipCost,
																																					 this.lblTotalCost,
																																					 this.lblTotalCostLabel,
																																					 this.lblShipCostLabel,
																																					 this.lblDesignFee,
																																					 this.lblDesignFeeLabel});
			this.boxCosts.Location = new System.Drawing.Point(286, 230);
			this.boxCosts.Name = "boxCosts";
			this.boxCosts.Size = new System.Drawing.Size(184, 106);
			this.boxCosts.TabIndex = 4;
			this.boxCosts.TabStop = false;
			this.boxCosts.Text = "Costs";
			// 
			// lblTradeIn
			// 
			this.lblTradeIn.Location = new System.Drawing.Point(106, 64);
			this.lblTradeIn.Name = "lblTradeIn";
			this.lblTradeIn.Size = new System.Drawing.Size(75, 16);
			this.lblTradeIn.TabIndex = 135;
			this.lblTradeIn.Text = "-8,888,888 cr.";
			this.lblTradeIn.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTradeInLabel
			// 
			this.lblTradeInLabel.AutoSize = true;
			this.lblTradeInLabel.Location = new System.Drawing.Point(8, 64);
			this.lblTradeInLabel.Name = "lblTradeInLabel";
			this.lblTradeInLabel.Size = new System.Drawing.Size(77, 13);
			this.lblTradeInLabel.TabIndex = 134;
			this.lblTradeInLabel.Text = "Less Trade-In:";
			// 
			// picCostsLine
			// 
			this.picCostsLine.BackColor = System.Drawing.Color.DimGray;
			this.picCostsLine.Location = new System.Drawing.Point(8, 80);
			this.picCostsLine.Name = "picCostsLine";
			this.picCostsLine.Size = new System.Drawing.Size(168, 1);
			this.picCostsLine.TabIndex = 133;
			this.picCostsLine.TabStop = false;
			// 
			// lblPenalty
			// 
			this.lblPenalty.Location = new System.Drawing.Point(106, 32);
			this.lblPenalty.Name = "lblPenalty";
			this.lblPenalty.Size = new System.Drawing.Size(74, 16);
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
			this.lblShipCost.Location = new System.Drawing.Point(106, 16);
			this.lblShipCost.Name = "lblShipCost";
			this.lblShipCost.Size = new System.Drawing.Size(74, 16);
			this.lblShipCost.TabIndex = 19;
			this.lblShipCost.Text = "8,888,888 cr.";
			this.lblShipCost.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTotalCost
			// 
			this.lblTotalCost.Location = new System.Drawing.Point(106, 84);
			this.lblTotalCost.Name = "lblTotalCost";
			this.lblTotalCost.Size = new System.Drawing.Size(74, 16);
			this.lblTotalCost.TabIndex = 18;
			this.lblTotalCost.Text = "8,888,888 cr.";
			this.lblTotalCost.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTotalCostLabel
			// 
			this.lblTotalCostLabel.AutoSize = true;
			this.lblTotalCostLabel.Location = new System.Drawing.Point(8, 84);
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
			this.lblDesignFee.Location = new System.Drawing.Point(106, 48);
			this.lblDesignFee.Name = "lblDesignFee";
			this.lblDesignFee.Size = new System.Drawing.Size(74, 16);
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
			// btnConstruct
			// 
			this.btnConstruct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnConstruct.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnConstruct.Location = new System.Drawing.Point(382, 344);
			this.btnConstruct.Name = "btnConstruct";
			this.btnConstruct.Size = new System.Drawing.Size(88, 22);
			this.btnConstruct.TabIndex = 6;
			this.btnConstruct.Text = "Construct Ship";
			this.btnConstruct.Click += new System.EventHandler(this.btnConstruct_Click);
			this.btnConstruct.MouseEnter += new System.EventHandler(this.btnConstruct_MouseEnter);
			this.btnConstruct.MouseLeave += new System.EventHandler(this.btnConstruct_MouseLeave);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(286, 344);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(88, 22);
			this.btnCancel.TabIndex = 5;
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
																																								this.lblUnitsUsed});
			this.boxAllocation.Location = new System.Drawing.Point(286, 0);
			this.boxAllocation.Name = "boxAllocation";
			this.boxAllocation.Size = new System.Drawing.Size(184, 226);
			this.boxAllocation.TabIndex = 3;
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
			this.lblPct.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
			this.numHullStrength.BackColor = System.Drawing.Color.White;
			this.numHullStrength.Location = new System.Drawing.Point(110, 64);
			this.numHullStrength.Maximum = new System.Decimal(new int[] {
																																		9999,
																																		0,
																																		0,
																																		0});
			this.numHullStrength.Name = "numHullStrength";
			this.numHullStrength.ReadOnly = true;
			this.numHullStrength.Size = new System.Drawing.Size(64, 20);
			this.numHullStrength.TabIndex = 1;
			this.numHullStrength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numHullStrength.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numHullStrength.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// lblHullStrenghLabel
			// 
			this.lblHullStrenghLabel.AutoSize = true;
			this.lblHullStrenghLabel.Location = new System.Drawing.Point(8, 66);
			this.lblHullStrenghLabel.Name = "lblHullStrenghLabel";
			this.lblHullStrenghLabel.Size = new System.Drawing.Size(70, 13);
			this.lblHullStrenghLabel.TabIndex = 13;
			this.lblHullStrenghLabel.Text = "Hull Strengh:";
			// 
			// numCargoBays
			// 
			this.numCargoBays.BackColor = System.Drawing.Color.White;
			this.numCargoBays.Location = new System.Drawing.Point(110, 16);
			this.numCargoBays.Maximum = new System.Decimal(new int[] {
																																 999,
																																 0,
																																 0,
																																 0});
			this.numCargoBays.Name = "numCargoBays";
			this.numCargoBays.ReadOnly = true;
			this.numCargoBays.Size = new System.Drawing.Size(64, 20);
			this.numCargoBays.TabIndex = 3;
			this.numCargoBays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numCargoBays.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numCargoBays.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// numCrewQuarters
			// 
			this.numCrewQuarters.BackColor = System.Drawing.Color.White;
			this.numCrewQuarters.Location = new System.Drawing.Point(110, 160);
			this.numCrewQuarters.Minimum = new System.Decimal(new int[] {
																																		1,
																																		0,
																																		0,
																																		0});
			this.numCrewQuarters.Name = "numCrewQuarters";
			this.numCrewQuarters.ReadOnly = true;
			this.numCrewQuarters.Size = new System.Drawing.Size(64, 20);
			this.numCrewQuarters.TabIndex = 4;
			this.numCrewQuarters.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numCrewQuarters.Value = new System.Decimal(new int[] {
																																	1,
																																	0,
																																	0,
																																	0});
			this.numCrewQuarters.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numCrewQuarters.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// numFuelTanks
			// 
			this.numFuelTanks.BackColor = System.Drawing.Color.White;
			this.numFuelTanks.Location = new System.Drawing.Point(110, 40);
			this.numFuelTanks.Name = "numFuelTanks";
			this.numFuelTanks.ReadOnly = true;
			this.numFuelTanks.Size = new System.Drawing.Size(64, 20);
			this.numFuelTanks.TabIndex = 2;
			this.numFuelTanks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numFuelTanks.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numFuelTanks.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// numShieldSlots
			// 
			this.numShieldSlots.BackColor = System.Drawing.Color.White;
			this.numShieldSlots.Location = new System.Drawing.Point(110, 112);
			this.numShieldSlots.Name = "numShieldSlots";
			this.numShieldSlots.ReadOnly = true;
			this.numShieldSlots.Size = new System.Drawing.Size(64, 20);
			this.numShieldSlots.TabIndex = 6;
			this.numShieldSlots.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numShieldSlots.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numShieldSlots.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// numGadgetSlots
			// 
			this.numGadgetSlots.BackColor = System.Drawing.Color.White;
			this.numGadgetSlots.Location = new System.Drawing.Point(110, 136);
			this.numGadgetSlots.Name = "numGadgetSlots";
			this.numGadgetSlots.ReadOnly = true;
			this.numGadgetSlots.Size = new System.Drawing.Size(64, 20);
			this.numGadgetSlots.TabIndex = 7;
			this.numGadgetSlots.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numGadgetSlots.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numGadgetSlots.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// numWeaponSlots
			// 
			this.numWeaponSlots.BackColor = System.Drawing.Color.White;
			this.numWeaponSlots.Location = new System.Drawing.Point(110, 88);
			this.numWeaponSlots.Name = "numWeaponSlots";
			this.numWeaponSlots.ReadOnly = true;
			this.numWeaponSlots.Size = new System.Drawing.Size(64, 20);
			this.numWeaponSlots.TabIndex = 5;
			this.numWeaponSlots.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numWeaponSlots.Enter += new System.EventHandler(this.num_ValueEnter);
			this.numWeaponSlots.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// lblCargoBays
			// 
			this.lblCargoBays.AutoSize = true;
			this.lblCargoBays.Location = new System.Drawing.Point(8, 18);
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
			this.lblFuelTanks.Size = new System.Drawing.Size(41, 13);
			this.lblFuelTanks.TabIndex = 4;
			this.lblFuelTanks.Text = "Range:";
			// 
			// lblCrewQuarters
			// 
			this.lblCrewQuarters.AutoSize = true;
			this.lblCrewQuarters.Location = new System.Drawing.Point(8, 162);
			this.lblCrewQuarters.Name = "lblCrewQuarters";
			this.lblCrewQuarters.Size = new System.Drawing.Size(81, 13);
			this.lblCrewQuarters.TabIndex = 3;
			this.lblCrewQuarters.Text = "Crew Quarters:";
			// 
			// lblShieldSlots
			// 
			this.lblShieldSlots.AutoSize = true;
			this.lblShieldSlots.Location = new System.Drawing.Point(8, 114);
			this.lblShieldSlots.Name = "lblShieldSlots";
			this.lblShieldSlots.Size = new System.Drawing.Size(67, 13);
			this.lblShieldSlots.TabIndex = 2;
			this.lblShieldSlots.Text = "Shield Slots:";
			// 
			// lblGadgetSlots
			// 
			this.lblGadgetSlots.AutoSize = true;
			this.lblGadgetSlots.Location = new System.Drawing.Point(8, 138);
			this.lblGadgetSlots.Name = "lblGadgetSlots";
			this.lblGadgetSlots.Size = new System.Drawing.Size(73, 13);
			this.lblGadgetSlots.TabIndex = 1;
			this.lblGadgetSlots.Text = "Gadget Slots:";
			// 
			// lblWeaponsSlots
			// 
			this.lblWeaponsSlots.AutoSize = true;
			this.lblWeaponsSlots.Location = new System.Drawing.Point(8, 90);
			this.lblWeaponsSlots.Name = "lblWeaponsSlots";
			this.lblWeaponsSlots.Size = new System.Drawing.Size(78, 13);
			this.lblWeaponsSlots.TabIndex = 0;
			this.lblWeaponsSlots.Text = "Weapon Slots:";
			// 
			// ilShipyardLogos
			// 
			this.ilShipyardLogos.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.ilShipyardLogos.ImageSize = new System.Drawing.Size(80, 80);
			this.ilShipyardLogos.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilShipyardLogos.ImageStream")));
			this.ilShipyardLogos.TransparentColor = System.Drawing.Color.Black;
			// 
			// dlgOpen
			// 
			this.dlgOpen.Filter = "Windows Bitmaps (*.bmp)|*bmp";
			this.dlgOpen.Title = "Open Ship Image";
			// 
			// lblDisabledPct
			// 
			this.lblDisabledPct.BackColor = System.Drawing.SystemColors.Info;
			this.lblDisabledPct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDisabledPct.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblDisabledPct.Location = new System.Drawing.Point(154, 182);
			this.lblDisabledPct.Name = "lblDisabledPct";
			this.lblDisabledPct.Size = new System.Drawing.Size(276, 20);
			this.lblDisabledPct.TabIndex = 8;
			this.lblDisabledPct.Text = "Your % of Max must be less than or equal to 100%.";
			this.lblDisabledPct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lblDisabledPct.Visible = false;
			// 
			// dlgSave
			// 
			this.dlgSave.DefaultExt = "sst";
			this.dlgSave.FileName = "CustomShip.sst";
			this.dlgSave.Filter = "SpaceTrader Ship Template Files (*.sst)|*.sst";
			this.dlgSave.Title = "Save Ship Template";
			// 
			// lblDisabledName
			// 
			this.lblDisabledName.BackColor = System.Drawing.SystemColors.Info;
			this.lblDisabledName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblDisabledName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblDisabledName.Location = new System.Drawing.Point(96, 222);
			this.lblDisabledName.Name = "lblDisabledName";
			this.lblDisabledName.Size = new System.Drawing.Size(170, 20);
			this.lblDisabledName.TabIndex = 7;
			this.lblDisabledName.Text = "You must enter a Ship Name.";
			this.lblDisabledName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblDisabledName.Visible = false;
			// 
			// Form_Shipyard
			// 
			this.AcceptButton = this.btnConstruct;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(478, 375);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.lblDisabledPct,
																																	this.boxWelcome,
																																	this.lblDisabledName,
																																	this.boxAllocation,
																																	this.boxCosts,
																																	this.boxInfo,
																																	this.btnCancel,
																																	this.btnConstruct});
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

		private bool ConstructButtonEnabled()
		{
			return (shipyard.PercentOfMaxUnits <= 100 && txtName.Text.Length > 0);
		}

		private Bitmap GetImageFile(string fileName)
		{
			Bitmap	image	= null;

			try
			{
				image	= new Bitmap(fileName);
			}
			catch (Exception ex)
			{
				FormAlert.Alert(AlertType.FileErrorOpen, this, fileName, ex.Message);
			}

			return image;
		}

		private void LoadSelectedTemplate()
		{
			if (typeof(ShipTemplate).IsInstanceOfType(selTemplate.SelectedItem))
			{
				loading									= true;

				ShipTemplate	template	= (ShipTemplate)selTemplate.SelectedItem;

				if (template.Name == Strings.ShipNameCurrentShip)
					txtName.Text					= game.Commander.Ship.Name;
				else if (template.Name.EndsWith(Strings.ShipNameTemplateSuffixDefault) ||
					template.Name.EndsWith(Strings.ShipNameTemplateSuffixMinimum))
					txtName.Text					= "";
				else
					txtName.Text					= template.Name;

				selSize.SelectedIndex		= Math.Max(0, sizes.IndexOf(template.Size));
				imgIndex								= template.ImageIndex == (int)ShipType.Custom ? imgTypes.Length - 1 : template.ImageIndex;

				if (template.Images != null)
					customImages	= template.Images;
				else
					customImages	= game.ParentWindow.CustomShipImages;

				numCargoBays.Value			= template.CargoBays;
				numFuelTanks.Value			= Math.Min(Math.Max(numFuelTanks.Minimum, template.FuelTanks), numFuelTanks.Maximum);
				numHullStrength.Value		= Math.Min(Math.Max(numHullStrength.Minimum, template.HullStrength), numHullStrength.Maximum);
				numWeaponSlots.Value		= template.WeaponSlots;
				numShieldSlots.Value		= template.ShieldSlots;
				numGadgetSlots.Value		= template.GadgetSlots;
				numCrewQuarters.Value		= Math.Max(numCrewQuarters.Minimum, template.CrewQuarters);

				UpdateShip();
				UpdateCalculatedFigures();

				if (selTemplate.Items[0].ToString() == Strings.ShipNameModified)
					selTemplate.Items.RemoveAt(0);

				loading	= false;
			}
		}

		private void LoadSizes()
		{
			sizes	= new ArrayList(6);

			foreach (Size size in shipyard.AvailableSizes)
			{
				sizes.Add(size);
				selSize.Items.Add(Functions.StringVars(Strings.ShipyardSizeItem, Strings.Sizes[(int)size],
					Functions.Multiples(Shipyard.MAX_UNITS[(int)size], Strings.ShipyardUnit)));
			}
		}

		private void LoadTemplateList()
		{
			ShipTemplate	currentShip	= new ShipTemplate(game.Commander.Ship, Strings.ShipNameCurrentShip);
			selTemplate.Items.Add(currentShip);

			selTemplate.Items.Add(Consts.ShipTemplateSeparator);

			// Add the minimal sizes templates.
			foreach (Size size in sizes)
				selTemplate.Items.Add(new ShipTemplate(size, Strings.Sizes[(int)size] + Strings.ShipNameTemplateSuffixMinimum));

			selTemplate.Items.Add(Consts.ShipTemplateSeparator);

			// Add the buyable ship spec templates.
			foreach (ShipSpec spec in Consts.ShipSpecs)
			{
				if (sizes.Contains(spec.Size) && (int)spec.Type <= Consts.MaxShip)
					selTemplate.Items.Add(new ShipTemplate(spec, spec.Name + Strings.ShipNameTemplateSuffixDefault));
			}

			selTemplate.Items.Add(Consts.ShipTemplateSeparator);

			// Add the user-created templates.
			ArrayList	userTemplates	= new ArrayList();
			foreach (string fileName in Directory.GetFiles(Consts.CustomTemplatesDirectory, "*.sst"))
			{
				ShipTemplate	template	= new ShipTemplate((Hashtable)Functions.LoadFile(fileName, true, this));
				if (sizes.Contains(template.Size))
					userTemplates.Add(template);
			}
			userTemplates.Sort();
			selTemplate.Items.AddRange((ShipTemplate[])userTemplates.ToArray(typeof(ShipTemplate)));

			selTemplate.SelectedIndex	= 0;
		}

		private bool SaveButtonEnabled()
		{
			return (txtName.Text.Length > 0);
		}

		private void SetTemplateModified()
		{
			if (!loading)
			{
				if (selTemplate.Items[0].ToString() != Strings.ShipNameModified)
					selTemplate.Items.Insert(0, Strings.ShipNameModified);

				selTemplate.SelectedIndex	= 0;
			}
		}

		private void UpdateAllocation()
		{
			bool	fuelMinimum					= numFuelTanks.Value == numFuelTanks.Minimum;
			bool	hullMinimum					= numHullStrength.Value == numHullStrength.Minimum;

			numFuelTanks.Minimum			= shipyard.BaseFuel;
			numFuelTanks.Increment		= shipyard.PerUnitFuel;
			numFuelTanks.Maximum			= Consts.MaxFuelTanks;
			if (fuelMinimum)
				numFuelTanks.Value			= numFuelTanks.Minimum;

			numHullStrength.Minimum		= shipyard.BaseHull;
			numHullStrength.Increment	= shipyard.PerUnitHull;
			if (hullMinimum)
				numHullStrength.Value		= numHullStrength.Minimum;

			numWeaponSlots.Maximum		= Consts.MaxSlots;
			numShieldSlots.Maximum		= Consts.MaxSlots;
			numGadgetSlots.Maximum		= Consts.MaxSlots;
			numCrewQuarters.Maximum		= Consts.MaxSlots;
		}

		private void UpdateCalculatedFigures()
		{
			// Fix the fuel value to be a multiple of the per unit value less the base.
			int extraFuel	= (int)numFuelTanks.Value - shipyard.BaseFuel;
			if (extraFuel % shipyard.PerUnitFuel > 0 && numFuelTanks.Value < numFuelTanks.Maximum)
				numFuelTanks.Value		= Math.Max(numFuelTanks.Minimum, Math.Min(numFuelTanks.Maximum,
																(extraFuel + shipyard.PerUnitFuel) / shipyard.PerUnitFuel * shipyard.PerUnitFuel +
																shipyard.BaseFuel));

			// Fix the hull value to be a multiple of the unit value value less the base.
			int extraHull	= (int)numHullStrength.Value - shipyard.BaseHull;
			if (extraHull % shipyard.PerUnitHull > 0)
				numHullStrength.Value	= Math.Max(numHullStrength.Minimum, (extraHull + shipyard.PerUnitHull) /
					shipyard.PerUnitHull * shipyard.PerUnitHull + shipyard.BaseHull);

			shipyard.ShipSpec.CargoBays			= (int)numCargoBays.Value;
			shipyard.ShipSpec.FuelTanks			= (int)numFuelTanks.Value;
			shipyard.ShipSpec.HullStrength	= (int)numHullStrength.Value;
			shipyard.ShipSpec.WeaponSlots		= (int)numWeaponSlots.Value;
			shipyard.ShipSpec.ShieldSlots		= (int)numShieldSlots.Value;
			shipyard.ShipSpec.GadgetSlots		= (int)numGadgetSlots.Value;
			shipyard.ShipSpec.CrewQuarters	= (int)numCrewQuarters.Value;

			shipyard.CalculateDependantVariables();

			lblUnitsUsed.Text								= shipyard.UnitsUsed.ToString();
			lblPct.Text											= Functions.FormatPercent(shipyard.PercentOfMaxUnits);
			if (shipyard.PercentOfMaxUnits >= Shipyard.PENALTY_FIRST_PCT)
				lblPct.Font										= lblSkillLabel.Font;
			else
				lblPct.Font										= lblPctLabel.Font;
			if (shipyard.UnitsUsed > shipyard.MaxUnits)
				lblPct.ForeColor							= Color.Red;
			else if (shipyard.PercentOfMaxUnits >= Shipyard.PENALTY_SECOND_PCT)
				lblPct.ForeColor							= Color.Orange;
			else if (shipyard.PercentOfMaxUnits >= Shipyard.PENALTY_FIRST_PCT)
				lblPct.ForeColor							= Color.Yellow;
			else
				lblPct.ForeColor							= lblPctLabel.ForeColor;


			lblShipCost.Text								= Functions.FormatMoney(shipyard.AdjustedPrice);
			lblDesignFee.Text								= Functions.FormatMoney(shipyard.AdjustedDesignFee);
			lblPenalty.Text									= Functions.FormatMoney(shipyard.AdjustedPenaltyCost);
			lblTradeIn.Text									= Functions.FormatMoney(-shipyard.TradeIn);
			lblTotalCost.Text								= Functions.FormatMoney(shipyard.TotalCost);

			UpdateButtonEnabledState();
		}

		private void UpdateButtonEnabledState()
		{
			btnConstruct.ForeColor	= ConstructButtonEnabled() ? Color.Black : Color.Gray;
			btnSave.ForeColor				= SaveButtonEnabled() ? Color.Black : Color.Gray;
		}

		private void UpdateShip()
		{
			shipyard.ShipSpec.ImageIndex	= (int)imgTypes[imgIndex];
			picShip.Image									= (imgIndex > Consts.MaxShip ? customImages[0] :
																			Consts.ShipSpecs[(int)imgTypes[imgIndex]].Image);
			lblImage.Text									= (imgIndex > Consts.MaxShip ? Strings.ShipNameCustomShip :
																			Consts.ShipSpecs[(int)imgTypes[imgIndex]].Name);
		}

		#endregion

		#region Event Handlers

		private void btnConstruct_Click(object sender, System.EventArgs e)
		{
			if (ConstructButtonEnabled())
			{
				if (game.Commander.TradeShip(shipyard.ShipSpec, shipyard.TotalCost, txtName.Text, this))
				{
					Strings.ShipNames[(int)ShipType.Custom]	= txtName.Text;

					if (game.QuestStatusScarab == SpecialEvent.StatusScarabDone)
						game.QuestStatusScarab = SpecialEvent.StatusScarabNotStarted;

					// Replace the current custom images with the new ones.
					if (game.Commander.Ship.ImageIndex == (int)ShipType.Custom)
					{
						game.ParentWindow.CustomShipImages	= customImages;

						game.Commander.Ship.UpdateCustomImageOffsetConstants();
					}

					FormAlert.Alert(AlertType.ShipDesignThanks, this, shipyard.Name);
					Close();
				}
			}
		}

		private void btnConstruct_MouseEnter(object sender, System.EventArgs e)
		{
			lblDisabledName.Visible	= txtName.Text.Length == 0;
			lblDisabledPct.Visible	= shipyard.PercentOfMaxUnits > 100;
		}

		private void btnConstruct_MouseLeave(object sender, System.EventArgs e)
		{
			lblDisabledName.Visible	= false;
			lblDisabledPct.Visible	= false;
		}

		private void btnLoad_Click(object sender, System.EventArgs e)
		{
			LoadSelectedTemplate();
		}

		private void btnNextImage_Click(object sender, System.EventArgs e)
		{
			SetTemplateModified();
			imgIndex	= (imgIndex + 1) % imgTypes.Length;
			UpdateShip();
		}

		private void btnPrevImage_Click(object sender, System.EventArgs e)
		{
			SetTemplateModified();
			imgIndex	= (imgIndex + imgTypes.Length - 1) % imgTypes.Length;
			UpdateShip();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if (SaveButtonEnabled())
			{
				if (dlgSave.ShowDialog(this) == DialogResult.OK)
				{
					ShipTemplate	template	= new ShipTemplate(shipyard.ShipSpec, txtName.Text);

					if (imgIndex > Consts.MaxShip)
					{
						template.ImageIndex	= (int)ShipType.Custom;
						template.Images			= customImages;
					}
					else
						template.ImageIndex	= imgIndex;

					Functions.SaveFile(dlgSave.FileName, template.Serialize(), this);

					LoadTemplateList();
				}
			}
		}

		private void btnSave_MouseEnter(object sender, System.EventArgs e)
		{
			lblDisabledName.Visible	= txtName.Text.Length == 0;
		}

		private void btnSave_MouseLeave(object sender, System.EventArgs e)
		{
			lblDisabledName.Visible	= false;
		}

		private void btnSetCustomImage_Click(object sender, System.EventArgs e)
		{
			if (dlgOpen.ShowDialog(this) == DialogResult.OK)
			{
				string	baseFileName				= Path.ChangeExtension(dlgOpen.FileName, null);
				string	ext									= Path.GetExtension(dlgOpen.FileName);

				Bitmap	image								= GetImageFile(baseFileName + ext);
				Bitmap	imageDamaged				= GetImageFile(baseFileName + "d" + ext);
				Bitmap	imageShields				= GetImageFile(baseFileName + "s" + ext);
				Bitmap	imageShieldsDamaged	= GetImageFile(baseFileName + "sd" + ext);

				if (image != null && imageDamaged != null && imageShields != null && imageShieldsDamaged != null)
				{
					customImages[Consts.ShipImgOffsetNormal]				= image;
					customImages[Consts.ShipImgOffsetDamage]				= imageDamaged;
					customImages[Consts.ShipImgOffsetShield]				= imageShields;
					customImages[Consts.ShipImgOffsetSheildDamage]	= imageShieldsDamaged;
				}

				imgIndex	= imgTypes.Length - 1;
				UpdateShip();
			}
		}

		private void num_ValueChanged(object sender, System.EventArgs e)
		{
			SetTemplateModified();
			UpdateCalculatedFigures();
		}

		private void num_ValueEnter(object sender, System.EventArgs e)
		{
			((NumericUpDown)sender).Select(0, ((NumericUpDown)sender).Value.ToString().Length);
		}

		private void selSize_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			SetTemplateModified();
			shipyard.ShipSpec.Size	= (Size)sizes[selSize.SelectedIndex];
			UpdateAllocation();
			UpdateCalculatedFigures();
		}

		private void txtName_TextChanged(object sender, System.EventArgs e)
		{
			SetTemplateModified();
			UpdateButtonEnabledState();
		}

		#endregion
	}
}
