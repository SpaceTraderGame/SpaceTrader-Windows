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
		private System.Windows.Forms.PictureBox picShip;
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

			picShip.Image	= game.Commander.Ship.Image;

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
			this.lblSellGadgets = new System.Windows.Forms.Label();
			this.lblSellShields = new System.Windows.Forms.Label();
			this.lblSellWeapons = new System.Windows.Forms.Label();
			this.lstSellGadget = new System.Windows.Forms.ListBox();
			this.lstSellShield = new System.Windows.Forms.ListBox();
			this.lstSellWeapon = new System.Windows.Forms.ListBox();
			this.boxBuy = new System.Windows.Forms.GroupBox();
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
			this.lblDescription = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.picShip = new System.Windows.Forms.PictureBox();
			this.boxSell.SuspendLayout();
			this.boxBuy.SuspendLayout();
			this.boxShipInfo.SuspendLayout();
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
			this.boxSell.Controls.AddRange(new System.Windows.Forms.Control[] {
																																					this.lblSellGadgets,
																																					this.lblSellShields,
																																					this.lblSellWeapons,
																																					this.lstSellGadget,
																																					this.lstSellShield,
																																					this.lstSellWeapon});
			this.boxSell.Location = new System.Drawing.Point(4, 2);
			this.boxSell.Name = "boxSell";
			this.boxSell.Size = new System.Drawing.Size(140, 296);
			this.boxSell.TabIndex = 1;
			this.boxSell.TabStop = false;
			this.boxSell.Text = "Current Inventory";
			// 
			// lblSellGadgets
			// 
			this.lblSellGadgets.AutoSize = true;
			this.lblSellGadgets.Location = new System.Drawing.Point(8, 204);
			this.lblSellGadgets.Name = "lblSellGadgets";
			this.lblSellGadgets.Size = new System.Drawing.Size(47, 13);
			this.lblSellGadgets.TabIndex = 146;
			this.lblSellGadgets.Text = "Gadgets";
			// 
			// lblSellShields
			// 
			this.lblSellShields.AutoSize = true;
			this.lblSellShields.Location = new System.Drawing.Point(8, 112);
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
			this.lblSellWeapons.Size = new System.Drawing.Size(52, 13);
			this.lblSellWeapons.TabIndex = 144;
			this.lblSellWeapons.Text = "Weapons";
			// 
			// lstSellGadget
			// 
			this.lstSellGadget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstSellGadget.Location = new System.Drawing.Point(8, 220);
			this.lstSellGadget.Name = "lstSellGadget";
			this.lstSellGadget.Size = new System.Drawing.Size(124, 67);
			this.lstSellGadget.TabIndex = 3;
			this.lstSellGadget.DoubleClick += new System.EventHandler(this.SellClick);
			this.lstSellGadget.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// lstSellShield
			// 
			this.lstSellShield.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstSellShield.Location = new System.Drawing.Point(8, 128);
			this.lstSellShield.Name = "lstSellShield";
			this.lstSellShield.Size = new System.Drawing.Size(124, 67);
			this.lstSellShield.TabIndex = 2;
			this.lstSellShield.DoubleClick += new System.EventHandler(this.SellClick);
			this.lstSellShield.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// lstSellWeapon
			// 
			this.lstSellWeapon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstSellWeapon.Location = new System.Drawing.Point(8, 36);
			this.lstSellWeapon.Name = "lstSellWeapon";
			this.lstSellWeapon.Size = new System.Drawing.Size(124, 67);
			this.lstSellWeapon.TabIndex = 1;
			this.lstSellWeapon.DoubleClick += new System.EventHandler(this.SellClick);
			this.lstSellWeapon.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// boxBuy
			// 
			this.boxBuy.Controls.AddRange(new System.Windows.Forms.Control[] {
																																				 this.lblBuyGadgets,
																																				 this.lblBuyShields,
																																				 this.lblBuyWeapons,
																																				 this.lstBuyGadget,
																																				 this.lstBuyShield,
																																				 this.lstBuyWeapon});
			this.boxBuy.Location = new System.Drawing.Point(152, 2);
			this.boxBuy.Name = "boxBuy";
			this.boxBuy.Size = new System.Drawing.Size(140, 296);
			this.boxBuy.TabIndex = 2;
			this.boxBuy.TabStop = false;
			this.boxBuy.Text = "Equipment For Sale";
			// 
			// lblBuyGadgets
			// 
			this.lblBuyGadgets.AutoSize = true;
			this.lblBuyGadgets.Location = new System.Drawing.Point(8, 204);
			this.lblBuyGadgets.Name = "lblBuyGadgets";
			this.lblBuyGadgets.Size = new System.Drawing.Size(47, 13);
			this.lblBuyGadgets.TabIndex = 143;
			this.lblBuyGadgets.Text = "Gadgets";
			// 
			// lblBuyShields
			// 
			this.lblBuyShields.AutoSize = true;
			this.lblBuyShields.Location = new System.Drawing.Point(8, 112);
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
			this.lblBuyWeapons.Size = new System.Drawing.Size(52, 13);
			this.lblBuyWeapons.TabIndex = 141;
			this.lblBuyWeapons.Text = "Weapons";
			// 
			// lstBuyGadget
			// 
			this.lstBuyGadget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstBuyGadget.Location = new System.Drawing.Point(8, 220);
			this.lstBuyGadget.Name = "lstBuyGadget";
			this.lstBuyGadget.Size = new System.Drawing.Size(124, 67);
			this.lstBuyGadget.TabIndex = 6;
			this.lstBuyGadget.DoubleClick += new System.EventHandler(this.BuyClick);
			this.lstBuyGadget.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// lstBuyShield
			// 
			this.lstBuyShield.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstBuyShield.Location = new System.Drawing.Point(8, 128);
			this.lstBuyShield.Name = "lstBuyShield";
			this.lstBuyShield.Size = new System.Drawing.Size(124, 67);
			this.lstBuyShield.TabIndex = 5;
			this.lstBuyShield.DoubleClick += new System.EventHandler(this.BuyClick);
			this.lstBuyShield.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// lstBuyWeapon
			// 
			this.lstBuyWeapon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstBuyWeapon.Location = new System.Drawing.Point(8, 36);
			this.lstBuyWeapon.Name = "lstBuyWeapon";
			this.lstBuyWeapon.Size = new System.Drawing.Size(124, 67);
			this.lstBuyWeapon.TabIndex = 4;
			this.lstBuyWeapon.DoubleClick += new System.EventHandler(this.BuyClick);
			this.lstBuyWeapon.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// boxShipInfo
			// 
			this.boxShipInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
																																							this.lblCharge,
																																							this.lblPower,
																																							this.lblChargeLabel,
																																							this.lblPowerLabel,
																																							this.lblType,
																																							this.lblTypeLabel,
																																							this.lblNameLabel,
																																							this.btnSell,
																																							this.btnBuy,
																																							this.lblBuyPriceLabel,
																																							this.lblBuyPrice,
																																							this.lblSellPriceLabel,
																																							this.picEquipment,
																																							this.lblSellPrice,
																																							this.lblDescription,
																																							this.lblName,
																																							this.picShip});
			this.boxShipInfo.Location = new System.Drawing.Point(300, 2);
			this.boxShipInfo.Name = "boxShipInfo";
			this.boxShipInfo.Size = new System.Drawing.Size(176, 296);
			this.boxShipInfo.TabIndex = 3;
			this.boxShipInfo.TabStop = false;
			this.boxShipInfo.Text = "Equipment Information";
			// 
			// lblCharge
			// 
			this.lblCharge.Location = new System.Drawing.Point(72, 168);
			this.lblCharge.Name = "lblCharge";
			this.lblCharge.Size = new System.Drawing.Size(89, 13);
			this.lblCharge.TabIndex = 67;
			this.lblCharge.Text = "888";
			// 
			// lblPower
			// 
			this.lblPower.Location = new System.Drawing.Point(72, 152);
			this.lblPower.Name = "lblPower";
			this.lblPower.Size = new System.Drawing.Size(89, 13);
			this.lblPower.TabIndex = 66;
			this.lblPower.Text = "888";
			// 
			// lblChargeLabel
			// 
			this.lblChargeLabel.AutoSize = true;
			this.lblChargeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblChargeLabel.Location = new System.Drawing.Point(8, 168);
			this.lblChargeLabel.Name = "lblChargeLabel";
			this.lblChargeLabel.Size = new System.Drawing.Size(46, 13);
			this.lblChargeLabel.TabIndex = 65;
			this.lblChargeLabel.Text = "Charge:";
			// 
			// lblPowerLabel
			// 
			this.lblPowerLabel.AutoSize = true;
			this.lblPowerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblPowerLabel.Location = new System.Drawing.Point(8, 152);
			this.lblPowerLabel.Name = "lblPowerLabel";
			this.lblPowerLabel.Size = new System.Drawing.Size(41, 13);
			this.lblPowerLabel.TabIndex = 64;
			this.lblPowerLabel.Text = "Power:";
			// 
			// lblType
			// 
			this.lblType.Location = new System.Drawing.Point(72, 104);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(89, 13);
			this.lblType.TabIndex = 63;
			this.lblType.Text = "Weapon";
			// 
			// lblTypeLabel
			// 
			this.lblTypeLabel.AutoSize = true;
			this.lblTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTypeLabel.Location = new System.Drawing.Point(8, 104);
			this.lblTypeLabel.Name = "lblTypeLabel";
			this.lblTypeLabel.Size = new System.Drawing.Size(34, 13);
			this.lblTypeLabel.TabIndex = 62;
			this.lblTypeLabel.Text = "Type:";
			// 
			// lblNameLabel
			// 
			this.lblNameLabel.AutoSize = true;
			this.lblNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNameLabel.Location = new System.Drawing.Point(8, 88);
			this.lblNameLabel.Name = "lblNameLabel";
			this.lblNameLabel.Size = new System.Drawing.Size(39, 13);
			this.lblNameLabel.TabIndex = 61;
			this.lblNameLabel.Text = "Name:";
			// 
			// btnSell
			// 
			this.btnSell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSell.Location = new System.Drawing.Point(95, 264);
			this.btnSell.Name = "btnSell";
			this.btnSell.Size = new System.Drawing.Size(58, 22);
			this.btnSell.TabIndex = 8;
			this.btnSell.Text = "Sell";
			this.btnSell.Click += new System.EventHandler(this.SellClick);
			// 
			// btnBuy
			// 
			this.btnBuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy.Location = new System.Drawing.Point(23, 264);
			this.btnBuy.Name = "btnBuy";
			this.btnBuy.Size = new System.Drawing.Size(58, 22);
			this.btnBuy.TabIndex = 7;
			this.btnBuy.Text = "Buy";
			this.btnBuy.Click += new System.EventHandler(this.BuyClick);
			// 
			// lblBuyPriceLabel
			// 
			this.lblBuyPriceLabel.AutoSize = true;
			this.lblBuyPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBuyPriceLabel.Location = new System.Drawing.Point(8, 120);
			this.lblBuyPriceLabel.Name = "lblBuyPriceLabel";
			this.lblBuyPriceLabel.Size = new System.Drawing.Size(58, 13);
			this.lblBuyPriceLabel.TabIndex = 57;
			this.lblBuyPriceLabel.Text = "Buy Price:";
			// 
			// lblBuyPrice
			// 
			this.lblBuyPrice.Location = new System.Drawing.Point(72, 120);
			this.lblBuyPrice.Name = "lblBuyPrice";
			this.lblBuyPrice.Size = new System.Drawing.Size(89, 13);
			this.lblBuyPrice.TabIndex = 56;
			this.lblBuyPrice.Text = "888,888 cr.";
			// 
			// lblSellPriceLabel
			// 
			this.lblSellPriceLabel.AutoSize = true;
			this.lblSellPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSellPriceLabel.Location = new System.Drawing.Point(8, 136);
			this.lblSellPriceLabel.Name = "lblSellPriceLabel";
			this.lblSellPriceLabel.Size = new System.Drawing.Size(58, 13);
			this.lblSellPriceLabel.TabIndex = 55;
			this.lblSellPriceLabel.Text = "Sell Price:";
			// 
			// picEquipment
			// 
			this.picEquipment.BackColor = System.Drawing.Color.White;
			this.picEquipment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picEquipment.Location = new System.Drawing.Point(95, 20);
			this.picEquipment.Name = "picEquipment";
			this.picEquipment.Size = new System.Drawing.Size(66, 54);
			this.picEquipment.TabIndex = 54;
			this.picEquipment.TabStop = false;
			this.picEquipment.Visible = false;
			// 
			// lblSellPrice
			// 
			this.lblSellPrice.Location = new System.Drawing.Point(72, 136);
			this.lblSellPrice.Name = "lblSellPrice";
			this.lblSellPrice.Size = new System.Drawing.Size(89, 13);
			this.lblSellPrice.TabIndex = 52;
			this.lblSellPrice.Text = "888,888 cr.";
			// 
			// lblDescription
			// 
			this.lblDescription.Location = new System.Drawing.Point(12, 192);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(156, 64);
			this.lblDescription.TabIndex = 47;
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(72, 88);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(89, 13);
			this.lblName.TabIndex = 35;
			this.lblName.Text = "Reflective Shield";
			// 
			// picShip
			// 
			this.picShip.BackColor = System.Drawing.Color.White;
			this.picShip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picShip.Location = new System.Drawing.Point(15, 20);
			this.picShip.Name = "picShip";
			this.picShip.Size = new System.Drawing.Size(66, 54);
			this.picShip.TabIndex = 12;
			this.picShip.TabStop = false;
			// 
			// FormEquipment
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(482, 303);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.boxShipInfo,
																																	this.boxBuy,
																																	this.boxSell,
																																	this.btnClose});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormEquipment";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Buy/Sell Equipment";
			this.boxSell.ResumeLayout(false);
			this.boxBuy.ResumeLayout(false);
			this.boxShipInfo.ResumeLayout(false);
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

		private void UpdateInfo()
		{
			if (selectedEquipment	== null)
			{
				lblName.Text					= "";
				lblType.Text					= "";
				lblDescription.Text		= "";
				lblBuyPrice.Text			= "";
				lblSellPrice.Text			= "";
				lblPower.Text					= "";
				lblCharge.Text				= "";
				picEquipment.Visible	= false;
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
				picEquipment.Visible	= true;
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
