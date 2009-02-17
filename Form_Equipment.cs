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
	public class FormEquipment : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.GroupBox boxSell;
		private System.Windows.Forms.GroupBox boxBuy;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ListBox lstSellWeapon;
		private System.Windows.Forms.ListBox lstSellShield;
		private System.Windows.Forms.ListBox lstSellGadget;
		private System.Windows.Forms.ListBox lstBuyGadget;
		private System.Windows.Forms.ListBox lstBuyShield;
		private System.Windows.Forms.ListBox lstBuyWeapon;
		private System.Windows.Forms.GroupBox boxShipInfo;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.PictureBox picEquipment;
		private System.Windows.Forms.Label lblSellPrice;
		private System.Windows.Forms.Label lblBuyPrice;
		private System.Windows.Forms.Label lblSellGadgets;
		private System.Windows.Forms.Label lblSellShields;
		private System.Windows.Forms.Label lblSellWeapons;
		private System.Windows.Forms.Label lblBuyGadgets;
		private System.Windows.Forms.Label lblBuyShields;
		private System.Windows.Forms.Label lblBuyWeapons;
		private System.Windows.Forms.Button btnBuy;
		private System.Windows.Forms.Button btnSell;
		private System.Windows.Forms.Label lblBuyPriceLabel;
		private System.Windows.Forms.Label lblSellPriceLabel;
		private System.Windows.Forms.Label lblNameLabel;
		private System.Windows.Forms.Label lblTypeLabel;
		private System.Windows.Forms.Label lblType;
		private System.Windows.Forms.Label lblPowerLabel;
		private System.Windows.Forms.Label lblChargeLabel;
		private System.Windows.Forms.Label lblPower;
		private System.Windows.Forms.Label lblCharge;
		private System.Windows.Forms.Label lblSellWeaponNoSlots;
		private System.Windows.Forms.Label lblSellShieldNoSlots;
		private System.Windows.Forms.Label lblSellGadgetNoSlots;
		private System.Windows.Forms.Label lblBuyWeaponNone;
		private System.Windows.Forms.Label lblBuyShieldNone;
		private System.Windows.Forms.Label lblBuyGadgetNone;

		#endregion

		#region Member Declarations

		private Game				game							= Game.CurrentGame;
		private Equipment[]	equipBuy					= Consts.EquipmentForSale;
		private Equipment		selectedEquipment	= null;
		private bool				sellSideSelected	= false;
		private bool				handlingSelect		= false;

		#endregion

		#region Methods

		public FormEquipment()
		{
			InitializeComponent();

			UpdateBuy();
			UpdateSell();
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
			this.boxSell = new System.Windows.Forms.GroupBox();
			this.lblSellGadgetNoSlots = new System.Windows.Forms.Label();
			this.lblSellShieldNoSlots = new System.Windows.Forms.Label();
			this.lblSellWeaponNoSlots = new System.Windows.Forms.Label();
			this.lblSellGadgets = new System.Windows.Forms.Label();
			this.lblSellShields = new System.Windows.Forms.Label();
			this.lblSellWeapons = new System.Windows.Forms.Label();
			this.lstSellGadget = new System.Windows.Forms.ListBox();
			this.lstSellShield = new System.Windows.Forms.ListBox();
			this.lstSellWeapon = new System.Windows.Forms.ListBox();
			this.boxBuy = new System.Windows.Forms.GroupBox();
			this.lblBuyGadgetNone = new System.Windows.Forms.Label();
			this.lblBuyShieldNone = new System.Windows.Forms.Label();
			this.lblBuyWeaponNone = new System.Windows.Forms.Label();
			this.lblBuyGadgets = new System.Windows.Forms.Label();
			this.lblBuyShields = new System.Windows.Forms.Label();
			this.lblBuyWeapons = new System.Windows.Forms.Label();
			this.lstBuyGadget = new System.Windows.Forms.ListBox();
			this.lstBuyShield = new System.Windows.Forms.ListBox();
			this.lstBuyWeapon = new System.Windows.Forms.ListBox();
			this.boxShipInfo = new System.Windows.Forms.GroupBox();
			this.lblCharge = new System.Windows.Forms.Label();
			this.lblPower = new System.Windows.Forms.Label();
			this.lblChargeLabel = new System.Windows.Forms.Label();
			this.lblPowerLabel = new System.Windows.Forms.Label();
			this.lblType = new System.Windows.Forms.Label();
			this.lblTypeLabel = new System.Windows.Forms.Label();
			this.lblNameLabel = new System.Windows.Forms.Label();
			this.btnSell = new System.Windows.Forms.Button();
			this.btnBuy = new System.Windows.Forms.Button();
			this.lblBuyPriceLabel = new System.Windows.Forms.Label();
			this.lblBuyPrice = new System.Windows.Forms.Label();
			this.lblSellPriceLabel = new System.Windows.Forms.Label();
			this.picEquipment = new System.Windows.Forms.PictureBox();
			this.lblSellPrice = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.boxSell.SuspendLayout();
			this.boxBuy.SuspendLayout();
			this.boxShipInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picEquipment)).BeginInit();
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
			// boxSell
			// 
			this.boxSell.Controls.Add(this.lblSellWeapons);
			this.boxSell.Controls.Add(this.lblSellGadgetNoSlots);
			this.boxSell.Controls.Add(this.lblSellShieldNoSlots);
			this.boxSell.Controls.Add(this.lblSellWeaponNoSlots);
			this.boxSell.Controls.Add(this.lstSellGadget);
			this.boxSell.Controls.Add(this.lstSellShield);
			this.boxSell.Controls.Add(this.lstSellWeapon);
			this.boxSell.Controls.Add(this.lblSellShields);
			this.boxSell.Controls.Add(this.lblSellGadgets);
			this.boxSell.Location = new System.Drawing.Point(4, 2);
			this.boxSell.Name = "boxSell";
			this.boxSell.Size = new System.Drawing.Size(144, 304);
			this.boxSell.TabIndex = 1;
			this.boxSell.TabStop = false;
			this.boxSell.Text = "Current Inventory";
			// 
			// lblSellGadgetNoSlots
			// 
			this.lblSellGadgetNoSlots.Location = new System.Drawing.Point(24, 228);
			this.lblSellGadgetNoSlots.Name = "lblSellGadgetNoSlots";
			this.lblSellGadgetNoSlots.Size = new System.Drawing.Size(104, 16);
			this.lblSellGadgetNoSlots.TabIndex = 149;
			this.lblSellGadgetNoSlots.Text = "No slots";
			this.lblSellGadgetNoSlots.Visible = false;
			// 
			// lblSellShieldNoSlots
			// 
			this.lblSellShieldNoSlots.Location = new System.Drawing.Point(24, 132);
			this.lblSellShieldNoSlots.Name = "lblSellShieldNoSlots";
			this.lblSellShieldNoSlots.Size = new System.Drawing.Size(104, 16);
			this.lblSellShieldNoSlots.TabIndex = 148;
			this.lblSellShieldNoSlots.Text = "No slots";
			this.lblSellShieldNoSlots.Visible = false;
			// 
			// lblSellWeaponNoSlots
			// 
			this.lblSellWeaponNoSlots.Location = new System.Drawing.Point(24, 36);
			this.lblSellWeaponNoSlots.Name = "lblSellWeaponNoSlots";
			this.lblSellWeaponNoSlots.Size = new System.Drawing.Size(104, 16);
			this.lblSellWeaponNoSlots.TabIndex = 147;
			this.lblSellWeaponNoSlots.Text = "No slots";
			this.lblSellWeaponNoSlots.Visible = false;
			// 
			// lblSellGadgets
			// 
			this.lblSellGadgets.AutoSize = true;
			this.lblSellGadgets.Location = new System.Drawing.Point(8, 212);
			this.lblSellGadgets.Name = "lblSellGadgets";
			this.lblSellGadgets.Size = new System.Drawing.Size(47, 13);
			this.lblSellGadgets.TabIndex = 146;
			this.lblSellGadgets.Text = "Gadgets";
			// 
			// lblSellShields
			// 
			this.lblSellShields.AutoSize = true;
			this.lblSellShields.Location = new System.Drawing.Point(8, 116);
			this.lblSellShields.Name = "lblSellShields";
			this.lblSellShields.Size = new System.Drawing.Size(41, 13);
			this.lblSellShields.TabIndex = 145;
			this.lblSellShields.Text = "Shields";
			// 
			// lblSellWeapons
			// 
			this.lblSellWeapons.AutoSize = true;
			this.lblSellWeapons.Location = new System.Drawing.Point(8, 20);
			this.lblSellWeapons.Name = "lblSellWeapons";
			this.lblSellWeapons.Size = new System.Drawing.Size(53, 13);
			this.lblSellWeapons.TabIndex = 144;
			this.lblSellWeapons.Text = "Weapons";
			// 
			// lstSellGadget
			// 
			this.lstSellGadget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstSellGadget.Location = new System.Drawing.Point(8, 229);
			this.lstSellGadget.Name = "lstSellGadget";
			this.lstSellGadget.Size = new System.Drawing.Size(128, 67);
			this.lstSellGadget.TabIndex = 3;
			this.lstSellGadget.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			this.lstSellGadget.DoubleClick += new System.EventHandler(this.SellClick);
			// 
			// lstSellShield
			// 
			this.lstSellShield.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstSellShield.Location = new System.Drawing.Point(8, 133);
			this.lstSellShield.Name = "lstSellShield";
			this.lstSellShield.Size = new System.Drawing.Size(128, 67);
			this.lstSellShield.TabIndex = 2;
			this.lstSellShield.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			this.lstSellShield.DoubleClick += new System.EventHandler(this.SellClick);
			// 
			// lstSellWeapon
			// 
			this.lstSellWeapon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstSellWeapon.Location = new System.Drawing.Point(8, 37);
			this.lstSellWeapon.Name = "lstSellWeapon";
			this.lstSellWeapon.Size = new System.Drawing.Size(128, 67);
			this.lstSellWeapon.TabIndex = 1;
			this.lstSellWeapon.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			this.lstSellWeapon.DoubleClick += new System.EventHandler(this.SellClick);
			// 
			// boxBuy
			// 
			this.boxBuy.Controls.Add(this.lblBuyGadgetNone);
			this.boxBuy.Controls.Add(this.lblBuyShieldNone);
			this.boxBuy.Controls.Add(this.lblBuyWeaponNone);
			this.boxBuy.Controls.Add(this.lblBuyGadgets);
			this.boxBuy.Controls.Add(this.lblBuyShields);
			this.boxBuy.Controls.Add(this.lblBuyWeapons);
			this.boxBuy.Controls.Add(this.lstBuyGadget);
			this.boxBuy.Controls.Add(this.lstBuyShield);
			this.boxBuy.Controls.Add(this.lstBuyWeapon);
			this.boxBuy.Location = new System.Drawing.Point(156, 2);
			this.boxBuy.Name = "boxBuy";
			this.boxBuy.Size = new System.Drawing.Size(144, 304);
			this.boxBuy.TabIndex = 2;
			this.boxBuy.TabStop = false;
			this.boxBuy.Text = "Equipment For Sale";
			// 
			// lblBuyGadgetNone
			// 
			this.lblBuyGadgetNone.Location = new System.Drawing.Point(24, 228);
			this.lblBuyGadgetNone.Name = "lblBuyGadgetNone";
			this.lblBuyGadgetNone.Size = new System.Drawing.Size(104, 16);
			this.lblBuyGadgetNone.TabIndex = 150;
			this.lblBuyGadgetNone.Text = "None for sale";
			this.lblBuyGadgetNone.Visible = false;
			// 
			// lblBuyShieldNone
			// 
			this.lblBuyShieldNone.Location = new System.Drawing.Point(24, 132);
			this.lblBuyShieldNone.Name = "lblBuyShieldNone";
			this.lblBuyShieldNone.Size = new System.Drawing.Size(104, 16);
			this.lblBuyShieldNone.TabIndex = 149;
			this.lblBuyShieldNone.Text = "None for sale";
			this.lblBuyShieldNone.Visible = false;
			// 
			// lblBuyWeaponNone
			// 
			this.lblBuyWeaponNone.Location = new System.Drawing.Point(24, 36);
			this.lblBuyWeaponNone.Name = "lblBuyWeaponNone";
			this.lblBuyWeaponNone.Size = new System.Drawing.Size(104, 16);
			this.lblBuyWeaponNone.TabIndex = 148;
			this.lblBuyWeaponNone.Text = "None for sale";
			this.lblBuyWeaponNone.Visible = false;
			// 
			// lblBuyGadgets
			// 
			this.lblBuyGadgets.AutoSize = true;
			this.lblBuyGadgets.Location = new System.Drawing.Point(8, 212);
			this.lblBuyGadgets.Name = "lblBuyGadgets";
			this.lblBuyGadgets.Size = new System.Drawing.Size(47, 13);
			this.lblBuyGadgets.TabIndex = 143;
			this.lblBuyGadgets.Text = "Gadgets";
			// 
			// lblBuyShields
			// 
			this.lblBuyShields.AutoSize = true;
			this.lblBuyShields.Location = new System.Drawing.Point(8, 116);
			this.lblBuyShields.Name = "lblBuyShields";
			this.lblBuyShields.Size = new System.Drawing.Size(41, 13);
			this.lblBuyShields.TabIndex = 142;
			this.lblBuyShields.Text = "Shields";
			// 
			// lblBuyWeapons
			// 
			this.lblBuyWeapons.AutoSize = true;
			this.lblBuyWeapons.Location = new System.Drawing.Point(8, 20);
			this.lblBuyWeapons.Name = "lblBuyWeapons";
			this.lblBuyWeapons.Size = new System.Drawing.Size(53, 13);
			this.lblBuyWeapons.TabIndex = 141;
			this.lblBuyWeapons.Text = "Weapons";
			// 
			// lstBuyGadget
			// 
			this.lstBuyGadget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstBuyGadget.Location = new System.Drawing.Point(8, 229);
			this.lstBuyGadget.Name = "lstBuyGadget";
			this.lstBuyGadget.Size = new System.Drawing.Size(128, 67);
			this.lstBuyGadget.TabIndex = 6;
			this.lstBuyGadget.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			this.lstBuyGadget.DoubleClick += new System.EventHandler(this.BuyClick);
			// 
			// lstBuyShield
			// 
			this.lstBuyShield.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstBuyShield.Location = new System.Drawing.Point(8, 133);
			this.lstBuyShield.Name = "lstBuyShield";
			this.lstBuyShield.Size = new System.Drawing.Size(128, 67);
			this.lstBuyShield.TabIndex = 5;
			this.lstBuyShield.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			this.lstBuyShield.DoubleClick += new System.EventHandler(this.BuyClick);
			// 
			// lstBuyWeapon
			// 
			this.lstBuyWeapon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstBuyWeapon.Location = new System.Drawing.Point(8, 37);
			this.lstBuyWeapon.Name = "lstBuyWeapon";
			this.lstBuyWeapon.Size = new System.Drawing.Size(128, 67);
			this.lstBuyWeapon.TabIndex = 4;
			this.lstBuyWeapon.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			this.lstBuyWeapon.DoubleClick += new System.EventHandler(this.BuyClick);
			// 
			// boxShipInfo
			// 
			this.boxShipInfo.Controls.Add(this.lblCharge);
			this.boxShipInfo.Controls.Add(this.lblPower);
			this.boxShipInfo.Controls.Add(this.lblChargeLabel);
			this.boxShipInfo.Controls.Add(this.lblPowerLabel);
			this.boxShipInfo.Controls.Add(this.lblType);
			this.boxShipInfo.Controls.Add(this.lblTypeLabel);
			this.boxShipInfo.Controls.Add(this.lblNameLabel);
			this.boxShipInfo.Controls.Add(this.btnSell);
			this.boxShipInfo.Controls.Add(this.btnBuy);
			this.boxShipInfo.Controls.Add(this.lblBuyPriceLabel);
			this.boxShipInfo.Controls.Add(this.lblBuyPrice);
			this.boxShipInfo.Controls.Add(this.lblSellPriceLabel);
			this.boxShipInfo.Controls.Add(this.picEquipment);
			this.boxShipInfo.Controls.Add(this.lblSellPrice);
			this.boxShipInfo.Controls.Add(this.lblName);
			this.boxShipInfo.Controls.Add(this.lblDescription);
			this.boxShipInfo.Location = new System.Drawing.Point(308, 2);
			this.boxShipInfo.Name = "boxShipInfo";
			this.boxShipInfo.Size = new System.Drawing.Size(208, 304);
			this.boxShipInfo.TabIndex = 3;
			this.boxShipInfo.TabStop = false;
			this.boxShipInfo.Text = "Equipment Information";
			// 
			// lblCharge
			// 
			this.lblCharge.Location = new System.Drawing.Point(80, 164);
			this.lblCharge.Name = "lblCharge";
			this.lblCharge.Size = new System.Drawing.Size(116, 16);
			this.lblCharge.TabIndex = 67;
			this.lblCharge.Text = "888";
			// 
			// lblPower
			// 
			this.lblPower.Location = new System.Drawing.Point(80, 148);
			this.lblPower.Name = "lblPower";
			this.lblPower.Size = new System.Drawing.Size(116, 16);
			this.lblPower.TabIndex = 66;
			this.lblPower.Text = "888";
			// 
			// lblChargeLabel
			// 
			this.lblChargeLabel.AutoSize = true;
			this.lblChargeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblChargeLabel.Location = new System.Drawing.Point(8, 164);
			this.lblChargeLabel.Name = "lblChargeLabel";
			this.lblChargeLabel.Size = new System.Drawing.Size(51, 13);
			this.lblChargeLabel.TabIndex = 65;
			this.lblChargeLabel.Text = "Charge:";
			// 
			// lblPowerLabel
			// 
			this.lblPowerLabel.AutoSize = true;
			this.lblPowerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPowerLabel.Location = new System.Drawing.Point(8, 148);
			this.lblPowerLabel.Name = "lblPowerLabel";
			this.lblPowerLabel.Size = new System.Drawing.Size(46, 13);
			this.lblPowerLabel.TabIndex = 64;
			this.lblPowerLabel.Text = "Power:";
			// 
			// lblType
			// 
			this.lblType.Location = new System.Drawing.Point(80, 100);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(116, 16);
			this.lblType.TabIndex = 63;
			this.lblType.Text = "Weapon";
			// 
			// lblTypeLabel
			// 
			this.lblTypeLabel.AutoSize = true;
			this.lblTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTypeLabel.Location = new System.Drawing.Point(8, 100);
			this.lblTypeLabel.Name = "lblTypeLabel";
			this.lblTypeLabel.Size = new System.Drawing.Size(39, 13);
			this.lblTypeLabel.TabIndex = 62;
			this.lblTypeLabel.Text = "Type:";
			// 
			// lblNameLabel
			// 
			this.lblNameLabel.AutoSize = true;
			this.lblNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblNameLabel.Location = new System.Drawing.Point(8, 84);
			this.lblNameLabel.Name = "lblNameLabel";
			this.lblNameLabel.Size = new System.Drawing.Size(43, 13);
			this.lblNameLabel.TabIndex = 61;
			this.lblNameLabel.Text = "Name:";
			// 
			// btnSell
			// 
			this.btnSell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSell.Location = new System.Drawing.Point(103, 272);
			this.btnSell.Name = "btnSell";
			this.btnSell.Size = new System.Drawing.Size(58, 22);
			this.btnSell.TabIndex = 8;
			this.btnSell.Text = "Sell";
			this.btnSell.Click += new System.EventHandler(this.SellClick);
			// 
			// btnBuy
			// 
			this.btnBuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy.Location = new System.Drawing.Point(31, 272);
			this.btnBuy.Name = "btnBuy";
			this.btnBuy.Size = new System.Drawing.Size(58, 22);
			this.btnBuy.TabIndex = 7;
			this.btnBuy.Text = "Buy";
			this.btnBuy.Click += new System.EventHandler(this.BuyClick);
			// 
			// lblBuyPriceLabel
			// 
			this.lblBuyPriceLabel.AutoSize = true;
			this.lblBuyPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBuyPriceLabel.Location = new System.Drawing.Point(8, 116);
			this.lblBuyPriceLabel.Name = "lblBuyPriceLabel";
			this.lblBuyPriceLabel.Size = new System.Drawing.Size(65, 13);
			this.lblBuyPriceLabel.TabIndex = 57;
			this.lblBuyPriceLabel.Text = "Buy Price:";
			// 
			// lblBuyPrice
			// 
			this.lblBuyPrice.Location = new System.Drawing.Point(80, 116);
			this.lblBuyPrice.Name = "lblBuyPrice";
			this.lblBuyPrice.Size = new System.Drawing.Size(116, 16);
			this.lblBuyPrice.TabIndex = 56;
			this.lblBuyPrice.Text = "888,888 cr.";
			// 
			// lblSellPriceLabel
			// 
			this.lblSellPriceLabel.AutoSize = true;
			this.lblSellPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSellPriceLabel.Location = new System.Drawing.Point(8, 132);
			this.lblSellPriceLabel.Name = "lblSellPriceLabel";
			this.lblSellPriceLabel.Size = new System.Drawing.Size(65, 13);
			this.lblSellPriceLabel.TabIndex = 55;
			this.lblSellPriceLabel.Text = "Sell Price:";
			// 
			// picEquipment
			// 
			this.picEquipment.BackColor = System.Drawing.Color.White;
			this.picEquipment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picEquipment.Location = new System.Drawing.Point(71, 20);
			this.picEquipment.Name = "picEquipment";
			this.picEquipment.Size = new System.Drawing.Size(66, 54);
			this.picEquipment.TabIndex = 54;
			this.picEquipment.TabStop = false;
			this.picEquipment.Visible = false;
			// 
			// lblSellPrice
			// 
			this.lblSellPrice.Location = new System.Drawing.Point(80, 132);
			this.lblSellPrice.Name = "lblSellPrice";
			this.lblSellPrice.Size = new System.Drawing.Size(116, 16);
			this.lblSellPrice.TabIndex = 52;
			this.lblSellPrice.Text = "888,888 cr.";
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(80, 84);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(116, 16);
			this.lblName.TabIndex = 35;
			this.lblName.Text = "Auto-Repair System";
			// 
			// lblDescription
			// 
			this.lblDescription.Location = new System.Drawing.Point(8, 188);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(196, 75);
			this.lblDescription.TabIndex = 47;
			// 
			// FormEquipment
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(522, 311);
			this.Controls.Add(this.boxShipInfo);
			this.Controls.Add(this.boxBuy);
			this.Controls.Add(this.boxSell);
			this.Controls.Add(this.btnClose);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormEquipment";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Buy/Sell Equipment";
			this.boxSell.ResumeLayout(false);
			this.boxSell.PerformLayout();
			this.boxBuy.ResumeLayout(false);
			this.boxBuy.PerformLayout();
			this.boxShipInfo.ResumeLayout(false);
			this.boxShipInfo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picEquipment)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void Buy()
		{
			if (selectedEquipment != null && !sellSideSelected)
			{
				Commander			cmdr			= game.Commander;
				EquipmentType	baseType	= selectedEquipment.EquipmentType;

				if (baseType == EquipmentType.Gadget && cmdr.Ship.HasGadget(((Gadget)selectedEquipment).Type) &&
					((Gadget)selectedEquipment).Type != GadgetType.ExtraCargoBays)
					FormAlert.Alert(AlertType.EquipmentAlreadyOwn, this);
				else if (cmdr.Debt > 0)
					FormAlert.Alert(AlertType.DebtNoBuy, this);
				else if (selectedEquipment.Price > cmdr.CashToSpend)
					FormAlert.Alert(AlertType.EquipmentIF, this);
				else if ((baseType == EquipmentType.Weapon && cmdr.Ship.FreeSlotsWeapon == 0) ||
					(baseType == EquipmentType.Shield && cmdr.Ship.FreeSlotsShield == 0) ||
					(baseType == EquipmentType.Gadget && cmdr.Ship.FreeSlotsGadget == 0))
					FormAlert.Alert(AlertType.EquipmentNotEnoughSlots, this);
				else if (FormAlert.Alert(AlertType.EquipmentBuy, this, selectedEquipment.Name,
					Functions.FormatNumber(selectedEquipment.Price)) == DialogResult.Yes)
				{
					cmdr.Ship.AddEquipment(selectedEquipment);
					cmdr.Cash	-= selectedEquipment.Price;

					DeselectAll();
					UpdateSell();
					game.ParentWindow.UpdateAll();
				}
			}
		}

		private void DeselectAll()
		{
			lstSellWeapon.ClearSelected();
			lstSellShield.ClearSelected();
			lstSellGadget.ClearSelected();
			lstBuyWeapon.ClearSelected();
			lstBuyShield.ClearSelected();
			lstBuyGadget.ClearSelected();
		}

		private void Sell()
		{
			if (selectedEquipment != null && sellSideSelected)
			{
				if (FormAlert.Alert(AlertType.EquipmentSell, this) == DialogResult.Yes)
				{
					// The slot is the selected index. Two of the three list boxes will have selected indices of -1, so adding
					// 2 to the total cancels those out.
					int				slot	= lstSellWeapon.SelectedIndex + lstSellShield.SelectedIndex + lstSellGadget.SelectedIndex + 2;
					Commander	cmdr	= game.Commander;

					if (selectedEquipment.EquipmentType == EquipmentType.Gadget &&
						(((Gadget)selectedEquipment).Type == GadgetType.ExtraCargoBays ||
						((Gadget)selectedEquipment).Type == GadgetType.HiddenCargoBays) &&
						cmdr.Ship.FreeCargoBays < 5)
					{
						FormAlert.Alert(AlertType.EquipmentExtraBaysInUse, this);
					}
					else
					{
						cmdr.Cash	+= selectedEquipment.SellPrice;
						cmdr.Ship.RemoveEquipment(selectedEquipment.EquipmentType, slot);

						UpdateSell();
						game.ParentWindow.UpdateAll();
					}
				}
			}
		}

		private void UpdateBuy()
		{
			for (int i = 0; i < equipBuy.Length; i++)
			{
				if (equipBuy[i].Price > 0)
				{
					switch(equipBuy[i].EquipmentType)
					{
						case EquipmentType.Weapon:
							lstBuyWeapon.Items.Add(equipBuy[i]);
							break;
						case EquipmentType.Shield:
							lstBuyShield.Items.Add(equipBuy[i]);
							break;
						case EquipmentType.Gadget:
							lstBuyGadget.Items.Add(equipBuy[i]);
							break;
					}
				}
			}

			ListBox[]	buyBoxes	= new ListBox[]	{ lstBuyWeapon, lstBuyShield, lstBuyGadget };
			Label[]		buyLabels	= new Label[]		{ lblBuyWeaponNone, lblBuyShieldNone, lblBuyGadgetNone };
			for (int i = 0; i < buyBoxes.Length; i++)
			{
				bool entries					= (buyBoxes[i].Items.Count > 0);
				buyBoxes[i].Visible		= entries;
				buyLabels[i].Visible	= !entries;
				if (entries)
					buyBoxes[i].Height	= buyBoxes[i].ItemHeight * Math.Min(buyBoxes[i].Items.Count, 5) + 2;
			}
		}

		private void UpdateInfo()
		{
			picEquipment.Visible			=
			lblNameLabel.Visible			=
			lblTypeLabel.Visible			=
			lblBuyPriceLabel.Visible	=
			lblSellPriceLabel.Visible	=
			lblPowerLabel.Visible			=
			lblChargeLabel.Visible		=	(selectedEquipment != null);

			if (selectedEquipment	== null)
			{
				lblName.Text					= "";
				lblType.Text					= "";
				lblDescription.Text		= "";
				lblBuyPrice.Text			= "";
				lblSellPrice.Text			= "";
				lblPower.Text					= "";
				lblCharge.Text				= "";
				btnBuy.Visible				= false;
				btnSell.Visible				= false;
			}
			else
			{
				string	power		= "";
				string	charge	= "";
				switch (selectedEquipment.EquipmentType)
				{
					case EquipmentType.Weapon:
						power		= ((Weapon)selectedEquipment).Power.ToString();
						charge	= Strings.NA;
						break;
					case EquipmentType.Shield:
						power		= ((Shield)selectedEquipment).Power.ToString();
						charge	= sellSideSelected ? ((Shield)selectedEquipment).Charge.ToString() : Strings.NA;
						break;
					case EquipmentType.Gadget:
						power		= Strings.NA;
						charge	= Strings.NA;
						break;
				}

				lblName.Text					= selectedEquipment.Name;
				lblType.Text					= Strings.EquipmentTypes[(int)selectedEquipment.EquipmentType];
				lblDescription.Text		= Strings.EquipmentDescriptions[(int)selectedEquipment.EquipmentType]
																[(int)selectedEquipment.SubType];
				lblBuyPrice.Text			= Functions.FormatMoney(selectedEquipment.Price);
				lblSellPrice.Text			= Functions.FormatMoney(selectedEquipment.SellPrice);
				lblPower.Text					= power;
				lblCharge.Text				= charge;
				picEquipment.Image		= selectedEquipment.Image;
				btnBuy.Visible				= !sellSideSelected && (selectedEquipment.Price > 0);
				btnSell.Visible				= sellSideSelected;
			}
		}

		private void UpdateSell()
		{
			sellSideSelected	= false;
			selectedEquipment	= null;
			UpdateInfo();

			lstSellWeapon.Items.Clear();
			lstSellShield.Items.Clear();
			lstSellGadget.Items.Clear();

			Ship				ship			= Game.CurrentGame.Commander.Ship;
			Equipment[]	equipSell;
			int					index;

			equipSell	= ship.EquipmentByType(EquipmentType.Weapon);
			for (index = 0; index < equipSell.Length; index++)
				lstSellWeapon.Items.Add(equipSell[index] == null ? (object)Strings.EquipmentFreeSlot : equipSell[index]);

			equipSell	= ship.EquipmentByType(EquipmentType.Shield);
			for (index = 0; index < equipSell.Length; index++)
				lstSellShield.Items.Add(equipSell[index] == null ? (object)Strings.EquipmentFreeSlot : equipSell[index]);

			equipSell	= ship.EquipmentByType(EquipmentType.Gadget);
			for (index = 0; index < equipSell.Length; index++)
				lstSellGadget.Items.Add(equipSell[index] == null ? (object)Strings.EquipmentFreeSlot : equipSell[index]);

			ListBox[]	sellBoxes		= new ListBox[]	{ lstSellWeapon, lstSellShield, lstSellGadget };
			Label[]		sellLabels	= new Label[]		{ lblSellWeaponNoSlots, lblSellShieldNoSlots, lblSellGadgetNoSlots };
			for (int i = 0; i < sellBoxes.Length; i++)
			{
				bool entries					= (sellBoxes[i].Items.Count > 0);
				sellBoxes[i].Visible	= entries;
				sellLabels[i].Visible	= !entries;
				if (entries)
					sellBoxes[i].Height	= sellBoxes[i].ItemHeight * Math.Min(sellBoxes[i].Items.Count, 5) + 2;
			}
		}

		#endregion

		#region Event Handlers

		private void BuyClick(object sender, System.EventArgs e)
		{
			if (selectedEquipment != null)
				Buy();
		}

		private void SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (!handlingSelect)
			{
				handlingSelect	= true;

				object obj	= ((ListBox)sender).SelectedItem;
				DeselectAll();
				((ListBox)sender).SelectedItem	= obj;

				sellSideSelected	= (((ListBox)sender).Name.IndexOf("Sell") >= 0);

				if (typeof(Equipment).IsInstanceOfType(obj))
					selectedEquipment	= (Equipment)obj;
				else
					selectedEquipment	= null;

				handlingSelect	= false;
				UpdateInfo();
			}
		}

		private void SellClick(object sender, System.EventArgs e)
		{
			if (selectedEquipment != null)
				Sell();
		}

		#endregion
	}
}
