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
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnBuy;
		private System.Windows.Forms.Button btnSell;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.PictureBox picEquipment;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lblSellPrice;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label lblBuyPrice;

		#endregion

		#region Member Declarations

		private Equipment[]	equipBuy	= Consts.EquipmentForSale;
		private Game				game			= Game.CurrentGame;
		private Equipment[]	equipSellWeapons;
		private Equipment[]	equipSellShields;
		private Equipment[]	equipSellGadgets;
		private Equipment[]	equipBuyWeapons;
		private Equipment[]	equipBuyShields;
		private Equipment[]	equipBuyGadgets;
		private bool inUnselect = false;
		private Equipment currentlySelectedEquipment = null;
		private int currentlySelectedIndex = -1;
		private bool buySideSelected = false;
		private System.Windows.Forms.Label label9;
		private bool sellSideSelected = false;

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

		#region Windows Form Designer generateed code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnClose = new System.Windows.Forms.Button();
			this.boxSell = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lstSellGadget = new System.Windows.Forms.ListBox();
			this.lstSellShield = new System.Windows.Forms.ListBox();
			this.lstSellWeapon = new System.Windows.Forms.ListBox();
			this.boxBuy = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lstBuyGadget = new System.Windows.Forms.ListBox();
			this.lstBuyShield = new System.Windows.Forms.ListBox();
			this.lstBuyWeapon = new System.Windows.Forms.ListBox();
			this.boxShipInfo = new System.Windows.Forms.GroupBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.lblBuyPrice = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.picEquipment = new System.Windows.Forms.PictureBox();
			this.lblSellPrice = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.btnSell = new System.Windows.Forms.Button();
			this.btnBuy = new System.Windows.Forms.Button();
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
																																					this.label4,
																																					this.label5,
																																					this.label6,
																																					this.lstSellGadget,
																																					this.lstSellShield,
																																					this.lstSellWeapon});
			this.boxSell.Location = new System.Drawing.Point(8, 8);
			this.boxSell.Name = "boxSell";
			this.boxSell.Size = new System.Drawing.Size(136, 286);
			this.boxSell.TabIndex = 33;
			this.boxSell.TabStop = false;
			this.boxSell.Text = "Current Inventory";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 196);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 146;
			this.label4.Text = "Gadgets";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.Location = new System.Drawing.Point(8, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 16);
			this.label5.TabIndex = 145;
			this.label5.Text = "Shields";
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 16);
			this.label6.TabIndex = 144;
			this.label6.Text = "Weapons";
			// 
			// lstSellGadget
			// 
			this.lstSellGadget.BackColor = System.Drawing.SystemColors.Control;
			this.lstSellGadget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstSellGadget.Location = new System.Drawing.Point(8, 212);
			this.lstSellGadget.Name = "lstSellGadget";
			this.lstSellGadget.Size = new System.Drawing.Size(124, 67);
			this.lstSellGadget.TabIndex = 137;
			this.lstSellGadget.DoubleClick += new System.EventHandler(this.lstSellGadget_DoubleClick);
			this.lstSellGadget.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// lstSellShield
			// 
			this.lstSellShield.BackColor = System.Drawing.SystemColors.Control;
			this.lstSellShield.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstSellShield.Location = new System.Drawing.Point(8, 128);
			this.lstSellShield.Name = "lstSellShield";
			this.lstSellShield.Size = new System.Drawing.Size(124, 67);
			this.lstSellShield.TabIndex = 136;
			this.lstSellShield.DoubleClick += new System.EventHandler(this.lstSellShield_DoubleClick);
			this.lstSellShield.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// lstSellWeapon
			// 
			this.lstSellWeapon.BackColor = System.Drawing.SystemColors.Control;
			this.lstSellWeapon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstSellWeapon.Location = new System.Drawing.Point(8, 40);
			this.lstSellWeapon.Name = "lstSellWeapon";
			this.lstSellWeapon.Size = new System.Drawing.Size(124, 67);
			this.lstSellWeapon.TabIndex = 135;
			this.lstSellWeapon.DoubleClick += new System.EventHandler(this.lstSellWeapon_DoubleClick);
			this.lstSellWeapon.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// boxBuy
			// 
			this.boxBuy.Controls.AddRange(new System.Windows.Forms.Control[] {
																																				 this.label3,
																																				 this.label2,
																																				 this.label1,
																																				 this.lstBuyGadget,
																																				 this.lstBuyShield,
																																				 this.lstBuyWeapon});
			this.boxBuy.Location = new System.Drawing.Point(144, 8);
			this.boxBuy.Name = "boxBuy";
			this.boxBuy.Size = new System.Drawing.Size(136, 286);
			this.boxBuy.TabIndex = 34;
			this.boxBuy.TabStop = false;
			this.boxBuy.Text = "Equipment For Sale";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 196);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 16);
			this.label3.TabIndex = 143;
			this.label3.Text = "Gadgets";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 112);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 142;
			this.label2.Text = "Shields";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 141;
			this.label1.Text = "Weapons";
			// 
			// lstBuyGadget
			// 
			this.lstBuyGadget.BackColor = System.Drawing.SystemColors.Control;
			this.lstBuyGadget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstBuyGadget.Location = new System.Drawing.Point(8, 212);
			this.lstBuyGadget.Name = "lstBuyGadget";
			this.lstBuyGadget.Size = new System.Drawing.Size(124, 67);
			this.lstBuyGadget.TabIndex = 140;
			this.lstBuyGadget.DoubleClick += new System.EventHandler(this.lstBuyGadget_DoubleClick);
			this.lstBuyGadget.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// lstBuyShield
			// 
			this.lstBuyShield.BackColor = System.Drawing.SystemColors.Control;
			this.lstBuyShield.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstBuyShield.Location = new System.Drawing.Point(8, 128);
			this.lstBuyShield.Name = "lstBuyShield";
			this.lstBuyShield.Size = new System.Drawing.Size(124, 67);
			this.lstBuyShield.TabIndex = 139;
			this.lstBuyShield.DoubleClick += new System.EventHandler(this.lstBuyShield_DoubleClick);
			this.lstBuyShield.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// lstBuyWeapon
			// 
			this.lstBuyWeapon.BackColor = System.Drawing.SystemColors.Control;
			this.lstBuyWeapon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstBuyWeapon.Location = new System.Drawing.Point(9, 40);
			this.lstBuyWeapon.Name = "lstBuyWeapon";
			this.lstBuyWeapon.Size = new System.Drawing.Size(124, 67);
			this.lstBuyWeapon.TabIndex = 138;
			this.lstBuyWeapon.DoubleClick += new System.EventHandler(this.lstBuyWeapon_DoubleClick);
			this.lstBuyWeapon.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
			// 
			// boxShipInfo
			// 
			this.boxShipInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
																																							this.label9,
																																							this.label8,
																																							this.lblBuyPrice,
																																							this.label7,
																																							this.picEquipment,
																																							this.lblSellPrice,
																																							this.lblDescription,
																																							this.btnSell,
																																							this.btnBuy,
																																							this.lblName,
																																							this.picShip});
			this.boxShipInfo.Location = new System.Drawing.Point(284, 8);
			this.boxShipInfo.Name = "boxShipInfo";
			this.boxShipInfo.Size = new System.Drawing.Size(176, 286);
			this.boxShipInfo.TabIndex = 74;
			this.boxShipInfo.TabStop = false;
			this.boxShipInfo.Text = "Equipment Information";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(8, 92);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(156, 48);
			this.label9.TabIndex = 58;
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(16, 224);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(57, 13);
			this.label8.TabIndex = 57;
			this.label8.Text = "Buy price:";
			// 
			// lblBuyPrice
			// 
			this.lblBuyPrice.Location = new System.Drawing.Point(80, 224);
			this.lblBuyPrice.Name = "lblBuyPrice";
			this.lblBuyPrice.Size = new System.Drawing.Size(80, 13);
			this.lblBuyPrice.TabIndex = 56;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(16, 240);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 13);
			this.label7.TabIndex = 55;
			this.label7.Text = "Sell price:";
			// 
			// picEquipment
			// 
			this.picEquipment.BackColor = System.Drawing.Color.White;
			this.picEquipment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picEquipment.Location = new System.Drawing.Point(96, 16);
			this.picEquipment.Name = "picEquipment";
			this.picEquipment.Size = new System.Drawing.Size(66, 54);
			this.picEquipment.TabIndex = 54;
			this.picEquipment.TabStop = false;
			this.picEquipment.Visible = false;
			// 
			// lblSellPrice
			// 
			this.lblSellPrice.Location = new System.Drawing.Point(80, 240);
			this.lblSellPrice.Name = "lblSellPrice";
			this.lblSellPrice.Size = new System.Drawing.Size(80, 13);
			this.lblSellPrice.TabIndex = 52;
			// 
			// lblDescription
			// 
			this.lblDescription.Location = new System.Drawing.Point(12, 176);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(156, 48);
			this.lblDescription.TabIndex = 47;
			this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnSell
			// 
			this.btnSell.Enabled = false;
			this.btnSell.Location = new System.Drawing.Point(92, 260);
			this.btnSell.Name = "btnSell";
			this.btnSell.TabIndex = 45;
			this.btnSell.Text = "Sell";
			this.btnSell.Click += new System.EventHandler(this.SellButtonClick);
			// 
			// btnBuy
			// 
			this.btnBuy.Enabled = false;
			this.btnBuy.Location = new System.Drawing.Point(8, 260);
			this.btnBuy.Name = "btnBuy";
			this.btnBuy.TabIndex = 44;
			this.btnBuy.Text = "Buy";
			this.btnBuy.Click += new System.EventHandler(this.BuyButtonClick);
			// 
			// lblName
			// 
			this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblName.Location = new System.Drawing.Point(12, 160);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(156, 13);
			this.lblName.TabIndex = 35;
			this.lblName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// picShip
			// 
			this.picShip.BackColor = System.Drawing.Color.White;
			this.picShip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picShip.Location = new System.Drawing.Point(16, 16);
			this.picShip.Name = "picShip";
			this.picShip.Size = new System.Drawing.Size(66, 54);
			this.picShip.TabIndex = 12;
			this.picShip.TabStop = false;
			// 
			// FormEquipment
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(462, 296);
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

		private void Buy(EquipmentType type, int item)
		{
			Commander			cmdr	= game.Commander;
			Equipment[]		equipArray= null;
			switch(type) 
			{
				case EquipmentType.Weapon : 
					equipArray = equipBuyWeapons;
					break;
				case EquipmentType.Shield :
					equipArray = equipBuyShields;
					break;
				case EquipmentType.Gadget :
					equipArray = equipBuyGadgets;
					break;
			}
			if (equipArray == null) return;
			Equipment equip = equipArray[item];
			
			if (FormAlert.Alert(AlertType.EquipmentBuy, this, equip.Name,
				Functions.FormatNumber(equip.Price)) == DialogResult.Yes)
			{
				cmdr.Ship.AddEquipment(equip);
				cmdr.Cash	-= equip.Price;

				UpdateSell();
				game.ParentWindow.UpdateAll();
			}
			EnableDisableButtons();
		}

		private void Sell(EquipmentType type, int item)
		{
			if (FormAlert.Alert(AlertType.EquipmentSell, this) == DialogResult.Yes)
			{
				Commander			cmdr	= game.Commander;
				Equipment[]		equipArray= null;
				switch(type) 
				{
					case EquipmentType.Weapon : 
						equipArray = equipSellWeapons;
						break;
					case EquipmentType.Shield :
						equipArray = equipSellShields;
						break;
					case EquipmentType.Gadget :
						equipArray = equipSellGadgets;
						break;
				}
				if (equipArray == null) return;
				Equipment equip = equipArray[item];
				if (equip == null) return;
				
				cmdr.Cash	+= equip.SellPrice;
				cmdr.Ship.RemoveEquipment(type, item);
				UpdateSell();
				game.ParentWindow.UpdateAll();
			}
			EnableDisableButtons();
		}

		private void UpdateBuy()
		{
			Equipment[]	equipBuy	= Consts.EquipmentForSale;
			equipBuyGadgets = new Equipment[equipBuy.Length];
			equipBuyShields = new Equipment[equipBuy.Length];
			equipBuyWeapons = new Equipment[equipBuy.Length];
			int w = 0;
			int s = 0;
			int g = 0;

			for (int i = 0; i < equipBuy.Length; i++)
			{
				Equipment equip =  equipBuy[i];
				ListBox list = null;
				if (equip != null)
				{
					switch(equip.EquipmentType) 
					{
						case EquipmentType.Weapon : 
							list = lstBuyWeapon;
							equipBuyWeapons[w++] = equip;
							break;
						case EquipmentType.Shield :
							list = lstBuyShield;
							equipBuyShields[s++] = equip;
							break;
						case EquipmentType.Gadget :
							list = lstBuyGadget;
							equipBuyGadgets[g++] = equip;
							break;
					}
					if (list != null) 
					{
						list.Items.Add(equip);
					}
				}
			}
		}

		private void UpdateSell()
		{
			Ship ship = Game.CurrentGame.Commander.Ship;
			equipSellGadgets = ship.Gadgets;
			equipSellShields = ship.Shields;
			equipSellWeapons = ship.Weapons;
			lstSellWeapon.Items.Clear();
			lstSellShield.Items.Clear();
			lstSellGadget.Items.Clear();

			for (int i = 0; i < equipSellWeapons.Length; i++)
			{
				Equipment equip =  equipSellWeapons[i];
				if (equip != null)
					lstSellWeapon.Items.Add(equip);
				else
					lstSellWeapon.Items.Add(" - FREE SLOT - ");
			}

			for (int i = 0; i < equipSellShields.Length; i++)
			{
				Equipment equip =  equipSellShields[i];
				if (equip != null)
					lstSellShield.Items.Add(equip);
				else
					lstSellShield.Items.Add(" - FREE SLOT - ");
			}
		
			for (int i = 0; i < equipSellGadgets.Length; i++)
			{
				Equipment equip =  equipSellGadgets[i];
				if (equip != null)
					lstSellGadget.Items.Add(equip);
				else
					lstSellGadget.Items.Add(" - FREE SLOT - ");
			}
		}

		private void unselectListboxes(object sender)
		{
			if (sender != lstBuyGadget) lstBuyGadget.ClearSelected();
			else 
			{
				buySideSelected = true;
				sellSideSelected = false;
			}
			if (sender != lstBuyWeapon) lstBuyWeapon.ClearSelected();
			else 
			{
				buySideSelected = true;
				sellSideSelected = false;
			}
			if (sender != lstBuyShield) lstBuyShield.ClearSelected();
			else 
			{
				buySideSelected = true;
				sellSideSelected = false;
			}
			if (sender != lstSellGadget) lstSellGadget.ClearSelected();
			else 
			{
				buySideSelected = false;
				sellSideSelected = true;
			}
			if (sender != lstSellShield) lstSellShield.ClearSelected();
			else 
			{
				buySideSelected = false;
				sellSideSelected = true;
			}
			if (sender != lstSellWeapon) lstSellWeapon.ClearSelected();
			else 
			{
				buySideSelected = false;
				sellSideSelected = true;
			}
		}

		private void SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (inUnselect) return;
			inUnselect = true;
			unselectListboxes(sender);
			object o = ((ListBox)sender).SelectedItem;
			currentlySelectedIndex = ((ListBox)sender).SelectedIndex;
			if (!(o.ToString().Equals(" - FREE SLOT - "))) 
			{
				currentlySelectedEquipment = (Equipment)o;
				int type = 0;
				switch(currentlySelectedEquipment.EquipmentType) 
				{
					case EquipmentType.Weapon : 
						type = (int) ((Weapon)currentlySelectedEquipment).Type;
						break;
					case EquipmentType.Shield :
						type = (int) ((Shield)currentlySelectedEquipment).Type;
						break;
					case EquipmentType.Gadget :
						type = (int) ((Gadget)currentlySelectedEquipment).Type;
						break;
				}
				lblName.Text = currentlySelectedEquipment.Name;
				lblDescription.Text = Strings.EquipmentDescriptions[(int)currentlySelectedEquipment.EquipmentType][type];
				lblBuyPrice.Text = Functions.FormatMoney(currentlySelectedEquipment.Price);
				lblSellPrice.Text = Functions.FormatMoney(currentlySelectedEquipment.SellPrice);
				picEquipment.Image = currentlySelectedEquipment.Image;
				picEquipment.Visible = true;
			}
			inUnselect = false;
			EnableDisableButtons();
		}

		private bool canSell(Equipment equip)
		{
			Commander cmdr = Game.CurrentGame.Commander;
			return sellSideSelected && !((equip.EquipmentType == EquipmentType.Gadget) && (((Gadget)equip).Type == GadgetType.ExtraCargoBays) && (cmdr.Ship.FreeCargoBays < 5));
		}

		private bool canBuy(Equipment equip)
		{
			Commander cmdr = Game.CurrentGame.Commander;
			EquipmentType type = equip.EquipmentType;

			if (type == EquipmentType.Gadget && cmdr.Ship.HasGadget(((Gadget)equip).Type) 
				&& ((Gadget)equip).Type != GadgetType.ExtraCargoBays)
				return false;
			else if (cmdr.Debt > 0)
				return false;
			else if (equip.Price > cmdr.CashToSpend)
				return false;
			else if ((type == EquipmentType.Weapon && cmdr.Ship.FreeSlotsWeapon == 0) ||
				(type == EquipmentType.Shield && cmdr.Ship.FreeSlotsShield == 0) ||
				(type == EquipmentType.Gadget && cmdr.Ship.FreeSlotsGadget == 0))
				return false;
			else return buySideSelected;
		}

		private void EnableDisableButtons()
		{
			btnBuy.Enabled = canBuy(currentlySelectedEquipment);
			btnSell.Enabled = canSell(currentlySelectedEquipment);
		}

		public void SetReadOnlyMode()
		{
			boxSell.Enabled = false;
			lstSellGadget.Enabled = false;
			lstSellShield.Enabled = false;
			lstSellWeapon.Enabled = false;
			boxBuy.Enabled = false;
			lstBuyGadget.Enabled = false;
			lstBuyShield.Enabled = false;
			lstBuyWeapon.Enabled = false;
			boxShipInfo.Enabled = false;
			btnSell.Enabled = false;
			btnBuy.Enabled = false;
		}
		#endregion

		#region Event Handlers

		private void BuyButtonClick(object sender, System.EventArgs e)
		{
			if ((currentlySelectedEquipment != null) && canBuy(currentlySelectedEquipment))
				Buy(currentlySelectedEquipment.EquipmentType, currentlySelectedIndex);
		}

		private void SellButtonClick(object sender, System.EventArgs e)
		{
			if ((currentlySelectedEquipment != null) && canSell(currentlySelectedEquipment))
				Sell(currentlySelectedEquipment.EquipmentType, currentlySelectedIndex);
		}

/* DPI	private void picShip_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Game.CurrentGame.Commander.Ship.PaintShipImage(e.Graphics, picShip.BackColor);		
		} */

		private void lstSellWeapon_DoubleClick(object sender, System.EventArgs e)
		{
			SellButtonClick(sender, e);
		}

		private void lstSellShield_DoubleClick(object sender, System.EventArgs e)
		{
			SellButtonClick(sender, e);
		}

		private void lstSellGadget_DoubleClick(object sender, System.EventArgs e)
		{
			SellButtonClick(sender, e);
		}

		private void lstBuyWeapon_DoubleClick(object sender, System.EventArgs e)
		{
			BuyButtonClick(sender, e);
		}

		private void lstBuyShield_DoubleClick(object sender, System.EventArgs e)
		{
			BuyButtonClick(sender, e);
		}

		private void lstBuyGadget_DoubleClick(object sender, System.EventArgs e)
		{
			BuyButtonClick(sender, e);
		}
		#endregion

	}
}
