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
		private System.Windows.Forms.Button btnSell0;
		private System.Windows.Forms.Button btnSell1;
		private System.Windows.Forms.Button btnSell2;
		private System.Windows.Forms.Button btnSell3;
		private System.Windows.Forms.Button btnSell4;
		private System.Windows.Forms.Button btnSell5;
		private System.Windows.Forms.Button btnSell6;
		private System.Windows.Forms.Button btnSell7;
		private System.Windows.Forms.Button btnSell8;
		private System.Windows.Forms.PictureBox picSellLine0;
		private System.Windows.Forms.PictureBox picSellLine1;
		private System.Windows.Forms.Label lblSellItem0;
		private System.Windows.Forms.Label lblSellItem1;
		private System.Windows.Forms.Label lblSellItem2;
		private System.Windows.Forms.Label lblSellItem3;
		private System.Windows.Forms.Label lblSellItem5;
		private System.Windows.Forms.Label lblSellItem6;
		private System.Windows.Forms.Label lblSellItem7;
		private System.Windows.Forms.Label lblSellItem8;
		private System.Windows.Forms.Label lblSellItem4;
		private System.Windows.Forms.Label lblSellPrice0;
		private System.Windows.Forms.Label lblSellPrice1;
		private System.Windows.Forms.Label lblSellPrice2;
		private System.Windows.Forms.Label lblSellPrice3;
		private System.Windows.Forms.Label lblSellPrice4;
		private System.Windows.Forms.Label lblSellPrice5;
		private System.Windows.Forms.Label lblSellPrice6;
		private System.Windows.Forms.Label lblSellPrice7;
		private System.Windows.Forms.Label lblSellPrice8;
		private System.Windows.Forms.GroupBox boxBuy;
		private System.Windows.Forms.Label lblBuyPrice0;
		private System.Windows.Forms.Label lblBuyItem0;
		private System.Windows.Forms.Button btnBuy0;
		private System.Windows.Forms.PictureBox picBuyLine1;
		private System.Windows.Forms.PictureBox picBuyLine0;
		private System.Windows.Forms.Label lblBuyPrice8;
		private System.Windows.Forms.Label lblBuyPrice7;
		private System.Windows.Forms.Label lblBuyPrice6;
		private System.Windows.Forms.Label lblBuyPrice5;
		private System.Windows.Forms.Label lblBuyPrice4;
		private System.Windows.Forms.Label lblBuyPrice3;
		private System.Windows.Forms.Label lblBuyPrice2;
		private System.Windows.Forms.Label lblBuyPrice1;
		private System.Windows.Forms.Label lblBuyItem4;
		private System.Windows.Forms.Label lblBuyItem8;
		private System.Windows.Forms.Label lblBuyItem7;
		private System.Windows.Forms.Label lblBuyItem6;
		private System.Windows.Forms.Label lblBuyItem5;
		private System.Windows.Forms.Label lblBuyItem3;
		private System.Windows.Forms.Label lblBuyItem2;
		private System.Windows.Forms.Label lblBuyItem1;
		private System.Windows.Forms.Button btnBuy8;
		private System.Windows.Forms.Button btnBuy7;
		private System.Windows.Forms.Button btnBuy6;
		private System.Windows.Forms.Button btnBuy5;
		private System.Windows.Forms.Button btnBuy4;
		private System.Windows.Forms.Button btnBuy3;
		private System.Windows.Forms.Button btnBuy2;
		private System.Windows.Forms.Button btnBuy1;
		private System.Windows.Forms.Label lblBuyPrice9;
		private System.Windows.Forms.Label lblBuyItem9;
		private System.Windows.Forms.Button btnBuy9;
		private System.ComponentModel.Container components = null;

		private Label[]			lblBuyItem;
		private Label[]			lblBuyPrice;
		private Label[]			lblSellItem;
		private Label[]			lblSellPrice;
		private Button[]		btnBuy;
		private Button[]		btnSell;

		#endregion

		#region Member Declarations

		private Game				game			= Game.CurrentGame;
		private Equipment[]	equipBuy	= Consts.EquipmentForSale;

		#endregion

		#region Methods

		public FormEquipment()
		{
			InitializeComponent();

			#region Arrays of Item controls
			lblBuyItem	= new Label[]
			{
				lblBuyItem0,
				lblBuyItem1,
				lblBuyItem2,
				lblBuyItem3,
				lblBuyItem4,
				lblBuyItem5,
				lblBuyItem6,
				lblBuyItem7,
				lblBuyItem8,
				lblBuyItem9
			};

			lblBuyPrice	= new Label[]
			{
				lblBuyPrice0,
				lblBuyPrice1,
				lblBuyPrice2,
				lblBuyPrice3,
				lblBuyPrice4,
				lblBuyPrice5,
				lblBuyPrice6,
				lblBuyPrice7,
				lblBuyPrice8,
				lblBuyPrice9
			};

			lblSellPrice	= new Label[]
			{
				lblSellPrice0,
				lblSellPrice1,
				lblSellPrice2,
				lblSellPrice3,
				lblSellPrice4,
				lblSellPrice5,
				lblSellPrice6,
				lblSellPrice7,
				lblSellPrice8
			};

			lblSellItem	= new Label[]
			{
				lblSellItem0,
				lblSellItem1,
				lblSellItem2,
				lblSellItem3,
				lblSellItem4,
				lblSellItem5,
				lblSellItem6,
				lblSellItem7,
				lblSellItem8
			};

			btnBuy	= new Button[]
			{
				btnBuy0,
				btnBuy1,
				btnBuy2,
				btnBuy3,
				btnBuy4,
				btnBuy5,
				btnBuy6,
				btnBuy7,
				btnBuy8,
				btnBuy9
			};

			btnSell	= new Button[]
			{
				btnSell0,
				btnSell1,
				btnSell2,
				btnSell3,
				btnSell4,
				btnSell5,
				btnSell6,
				btnSell7,
				btnSell8
			};
			#endregion

			UpdateBuy();
			UpdateSell();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		#region Windows Form Designer genePriced code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnClose = new System.Windows.Forms.Button();
			this.boxSell = new System.Windows.Forms.GroupBox();
			this.lblSellPrice8 = new System.Windows.Forms.Label();
			this.lblSellPrice7 = new System.Windows.Forms.Label();
			this.lblSellPrice6 = new System.Windows.Forms.Label();
			this.lblSellPrice5 = new System.Windows.Forms.Label();
			this.lblSellPrice4 = new System.Windows.Forms.Label();
			this.lblSellPrice3 = new System.Windows.Forms.Label();
			this.lblSellPrice2 = new System.Windows.Forms.Label();
			this.lblSellPrice1 = new System.Windows.Forms.Label();
			this.lblSellPrice0 = new System.Windows.Forms.Label();
			this.lblSellItem4 = new System.Windows.Forms.Label();
			this.lblSellItem8 = new System.Windows.Forms.Label();
			this.lblSellItem7 = new System.Windows.Forms.Label();
			this.lblSellItem6 = new System.Windows.Forms.Label();
			this.lblSellItem5 = new System.Windows.Forms.Label();
			this.lblSellItem3 = new System.Windows.Forms.Label();
			this.lblSellItem2 = new System.Windows.Forms.Label();
			this.lblSellItem1 = new System.Windows.Forms.Label();
			this.lblSellItem0 = new System.Windows.Forms.Label();
			this.picSellLine1 = new System.Windows.Forms.PictureBox();
			this.picSellLine0 = new System.Windows.Forms.PictureBox();
			this.btnSell8 = new System.Windows.Forms.Button();
			this.btnSell7 = new System.Windows.Forms.Button();
			this.btnSell6 = new System.Windows.Forms.Button();
			this.btnSell5 = new System.Windows.Forms.Button();
			this.btnSell4 = new System.Windows.Forms.Button();
			this.btnSell3 = new System.Windows.Forms.Button();
			this.btnSell2 = new System.Windows.Forms.Button();
			this.btnSell1 = new System.Windows.Forms.Button();
			this.btnSell0 = new System.Windows.Forms.Button();
			this.boxBuy = new System.Windows.Forms.GroupBox();
			this.lblBuyPrice9 = new System.Windows.Forms.Label();
			this.lblBuyItem9 = new System.Windows.Forms.Label();
			this.btnBuy9 = new System.Windows.Forms.Button();
			this.lblBuyPrice8 = new System.Windows.Forms.Label();
			this.lblBuyPrice7 = new System.Windows.Forms.Label();
			this.lblBuyPrice6 = new System.Windows.Forms.Label();
			this.lblBuyPrice5 = new System.Windows.Forms.Label();
			this.lblBuyPrice4 = new System.Windows.Forms.Label();
			this.lblBuyPrice3 = new System.Windows.Forms.Label();
			this.lblBuyPrice2 = new System.Windows.Forms.Label();
			this.lblBuyPrice1 = new System.Windows.Forms.Label();
			this.lblBuyPrice0 = new System.Windows.Forms.Label();
			this.lblBuyItem4 = new System.Windows.Forms.Label();
			this.lblBuyItem8 = new System.Windows.Forms.Label();
			this.lblBuyItem7 = new System.Windows.Forms.Label();
			this.lblBuyItem6 = new System.Windows.Forms.Label();
			this.lblBuyItem5 = new System.Windows.Forms.Label();
			this.lblBuyItem3 = new System.Windows.Forms.Label();
			this.lblBuyItem2 = new System.Windows.Forms.Label();
			this.lblBuyItem1 = new System.Windows.Forms.Label();
			this.lblBuyItem0 = new System.Windows.Forms.Label();
			this.picBuyLine1 = new System.Windows.Forms.PictureBox();
			this.picBuyLine0 = new System.Windows.Forms.PictureBox();
			this.btnBuy8 = new System.Windows.Forms.Button();
			this.btnBuy7 = new System.Windows.Forms.Button();
			this.btnBuy6 = new System.Windows.Forms.Button();
			this.btnBuy5 = new System.Windows.Forms.Button();
			this.btnBuy4 = new System.Windows.Forms.Button();
			this.btnBuy3 = new System.Windows.Forms.Button();
			this.btnBuy2 = new System.Windows.Forms.Button();
			this.btnBuy1 = new System.Windows.Forms.Button();
			this.btnBuy0 = new System.Windows.Forms.Button();
			this.boxSell.SuspendLayout();
			this.boxBuy.SuspendLayout();
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
																																					this.lblSellPrice8,
																																					this.lblSellPrice7,
																																					this.lblSellPrice6,
																																					this.lblSellPrice5,
																																					this.lblSellPrice4,
																																					this.lblSellPrice3,
																																					this.lblSellPrice2,
																																					this.lblSellPrice1,
																																					this.lblSellPrice0,
																																					this.lblSellItem4,
																																					this.lblSellItem8,
																																					this.lblSellItem7,
																																					this.lblSellItem6,
																																					this.lblSellItem5,
																																					this.lblSellItem3,
																																					this.lblSellItem2,
																																					this.lblSellItem1,
																																					this.lblSellItem0,
																																					this.picSellLine1,
																																					this.picSellLine0,
																																					this.btnSell8,
																																					this.btnSell7,
																																					this.btnSell6,
																																					this.btnSell5,
																																					this.btnSell4,
																																					this.btnSell3,
																																					this.btnSell2,
																																					this.btnSell1,
																																					this.btnSell0});
			this.boxSell.Location = new System.Drawing.Point(8, 8);
			this.boxSell.Name = "boxSell";
			this.boxSell.Size = new System.Drawing.Size(232, 280);
			this.boxSell.TabIndex = 33;
			this.boxSell.TabStop = false;
			this.boxSell.Text = "Current Inventory";
			//
			// lblSellPrice8
			//
			this.lblSellPrice8.Location = new System.Drawing.Point(160, 230);
			this.lblSellPrice8.Name = "lblSellPrice8";
			this.lblSellPrice8.Size = new System.Drawing.Size(61, 13);
			this.lblSellPrice8.TabIndex = 152;
			this.lblSellPrice8.Text = "888,888 cr.";
			this.lblSellPrice8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblSellPrice7
			//
			this.lblSellPrice7.Location = new System.Drawing.Point(160, 206);
			this.lblSellPrice7.Name = "lblSellPrice7";
			this.lblSellPrice7.Size = new System.Drawing.Size(61, 13);
			this.lblSellPrice7.TabIndex = 151;
			this.lblSellPrice7.Text = "888,888 cr.";
			this.lblSellPrice7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblSellPrice6
			//
			this.lblSellPrice6.Location = new System.Drawing.Point(160, 182);
			this.lblSellPrice6.Name = "lblSellPrice6";
			this.lblSellPrice6.Size = new System.Drawing.Size(61, 13);
			this.lblSellPrice6.TabIndex = 150;
			this.lblSellPrice6.Text = "888,888 cr.";
			this.lblSellPrice6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblSellPrice5
			//
			this.lblSellPrice5.Location = new System.Drawing.Point(160, 148);
			this.lblSellPrice5.Name = "lblSellPrice5";
			this.lblSellPrice5.Size = new System.Drawing.Size(61, 13);
			this.lblSellPrice5.TabIndex = 149;
			this.lblSellPrice5.Text = "888,888 cr.";
			this.lblSellPrice5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblSellPrice4
			//
			this.lblSellPrice4.Location = new System.Drawing.Point(160, 125);
			this.lblSellPrice4.Name = "lblSellPrice4";
			this.lblSellPrice4.Size = new System.Drawing.Size(61, 13);
			this.lblSellPrice4.TabIndex = 148;
			this.lblSellPrice4.Text = "888,888 cr.";
			this.lblSellPrice4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblSellPrice3
			//
			this.lblSellPrice3.Location = new System.Drawing.Point(160, 101);
			this.lblSellPrice3.Name = "lblSellPrice3";
			this.lblSellPrice3.Size = new System.Drawing.Size(61, 13);
			this.lblSellPrice3.TabIndex = 147;
			this.lblSellPrice3.Text = "888,888 cr.";
			this.lblSellPrice3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblSellPrice2
			//
			this.lblSellPrice2.Location = new System.Drawing.Point(160, 68);
			this.lblSellPrice2.Name = "lblSellPrice2";
			this.lblSellPrice2.Size = new System.Drawing.Size(61, 13);
			this.lblSellPrice2.TabIndex = 146;
			this.lblSellPrice2.Text = "888,888 cr.";
			this.lblSellPrice2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblSellPrice1
			//
			this.lblSellPrice1.Location = new System.Drawing.Point(160, 44);
			this.lblSellPrice1.Name = "lblSellPrice1";
			this.lblSellPrice1.Size = new System.Drawing.Size(61, 13);
			this.lblSellPrice1.TabIndex = 145;
			this.lblSellPrice1.Text = "888,888 cr.";
			this.lblSellPrice1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblSellPrice0
			//
			this.lblSellPrice0.Location = new System.Drawing.Point(160, 20);
			this.lblSellPrice0.Name = "lblSellPrice0";
			this.lblSellPrice0.Size = new System.Drawing.Size(61, 13);
			this.lblSellPrice0.TabIndex = 144;
			this.lblSellPrice0.Text = "888,888 cr.";
			this.lblSellPrice0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblSellItem4
			//
			this.lblSellItem4.Location = new System.Drawing.Point(48, 125);
			this.lblSellItem4.Name = "lblSellItem4";
			this.lblSellItem4.Size = new System.Drawing.Size(105, 13);
			this.lblSellItem4.TabIndex = 143;
			this.lblSellItem4.Text = "Auto-Repair System";
			//
			// lblSellItem8
			//
			this.lblSellItem8.Location = new System.Drawing.Point(48, 230);
			this.lblSellItem8.Name = "lblSellItem8";
			this.lblSellItem8.Size = new System.Drawing.Size(105, 13);
			this.lblSellItem8.TabIndex = 142;
			this.lblSellItem8.Text = "Auto-Repair System";
			//
			// lblSellItem7
			//
			this.lblSellItem7.Location = new System.Drawing.Point(48, 206);
			this.lblSellItem7.Name = "lblSellItem7";
			this.lblSellItem7.Size = new System.Drawing.Size(105, 13);
			this.lblSellItem7.TabIndex = 141;
			this.lblSellItem7.Text = "Auto-Repair System";
			//
			// lblSellItem6
			//
			this.lblSellItem6.Location = new System.Drawing.Point(48, 182);
			this.lblSellItem6.Name = "lblSellItem6";
			this.lblSellItem6.Size = new System.Drawing.Size(105, 13);
			this.lblSellItem6.TabIndex = 140;
			this.lblSellItem6.Text = "Auto-Repair System";
			//
			// lblSellItem5
			//
			this.lblSellItem5.Location = new System.Drawing.Point(48, 148);
			this.lblSellItem5.Name = "lblSellItem5";
			this.lblSellItem5.Size = new System.Drawing.Size(105, 13);
			this.lblSellItem5.TabIndex = 139;
			this.lblSellItem5.Text = "Auto-Repair System";
			//
			// lblSellItem3
			//
			this.lblSellItem3.Location = new System.Drawing.Point(48, 101);
			this.lblSellItem3.Name = "lblSellItem3";
			this.lblSellItem3.Size = new System.Drawing.Size(105, 13);
			this.lblSellItem3.TabIndex = 138;
			this.lblSellItem3.Text = "Auto-Repair System";
			//
			// lblSellItem2
			//
			this.lblSellItem2.Location = new System.Drawing.Point(48, 68);
			this.lblSellItem2.Name = "lblSellItem2";
			this.lblSellItem2.Size = new System.Drawing.Size(105, 13);
			this.lblSellItem2.TabIndex = 137;
			this.lblSellItem2.Text = "Auto-Repair System";
			//
			// lblSellItem1
			//
			this.lblSellItem1.Location = new System.Drawing.Point(48, 44);
			this.lblSellItem1.Name = "lblSellItem1";
			this.lblSellItem1.Size = new System.Drawing.Size(105, 13);
			this.lblSellItem1.TabIndex = 136;
			this.lblSellItem1.Text = "Auto-Repair System";
			//
			// lblSellItem0
			//
			this.lblSellItem0.Location = new System.Drawing.Point(48, 20);
			this.lblSellItem0.Name = "lblSellItem0";
			this.lblSellItem0.Size = new System.Drawing.Size(105, 13);
			this.lblSellItem0.TabIndex = 135;
			this.lblSellItem0.Text = "Auto-Repair System";
			//
			// picSellLine1
			//
			this.picSellLine1.BackColor = System.Drawing.Color.DimGray;
			this.picSellLine1.Location = new System.Drawing.Point(6, 172);
			this.picSellLine1.Name = "picSellLine1";
			this.picSellLine1.Size = new System.Drawing.Size(220, 1);
			this.picSellLine1.TabIndex = 134;
			this.picSellLine1.TabStop = false;
			//
			// picSellLine0
			//
			this.picSellLine0.BackColor = System.Drawing.Color.DimGray;
			this.picSellLine0.Location = new System.Drawing.Point(6, 91);
			this.picSellLine0.Name = "picSellLine0";
			this.picSellLine0.Size = new System.Drawing.Size(220, 1);
			this.picSellLine0.TabIndex = 133;
			this.picSellLine0.TabStop = false;
			//
			// btnSell8
			//
			this.btnSell8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSell8.Location = new System.Drawing.Point(8, 226);
			this.btnSell8.Name = "btnSell8";
			this.btnSell8.Size = new System.Drawing.Size(33, 22);
			this.btnSell8.TabIndex = 9;
			this.btnSell8.Text = "Sell";
			this.btnSell8.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnSell7
			//
			this.btnSell7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSell7.Location = new System.Drawing.Point(8, 202);
			this.btnSell7.Name = "btnSell7";
			this.btnSell7.Size = new System.Drawing.Size(33, 22);
			this.btnSell7.TabIndex = 8;
			this.btnSell7.Text = "Sell";
			this.btnSell7.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnSell6
			//
			this.btnSell6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSell6.Location = new System.Drawing.Point(8, 178);
			this.btnSell6.Name = "btnSell6";
			this.btnSell6.Size = new System.Drawing.Size(33, 22);
			this.btnSell6.TabIndex = 7;
			this.btnSell6.Text = "Sell";
			this.btnSell6.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnSell5
			//
			this.btnSell5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSell5.Location = new System.Drawing.Point(8, 145);
			this.btnSell5.Name = "btnSell5";
			this.btnSell5.Size = new System.Drawing.Size(33, 22);
			this.btnSell5.TabIndex = 6;
			this.btnSell5.Text = "Sell";
			this.btnSell5.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnSell4
			//
			this.btnSell4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSell4.Location = new System.Drawing.Point(8, 121);
			this.btnSell4.Name = "btnSell4";
			this.btnSell4.Size = new System.Drawing.Size(33, 22);
			this.btnSell4.TabIndex = 5;
			this.btnSell4.Text = "Sell";
			this.btnSell4.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnSell3
			//
			this.btnSell3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSell3.Location = new System.Drawing.Point(8, 97);
			this.btnSell3.Name = "btnSell3";
			this.btnSell3.Size = new System.Drawing.Size(33, 22);
			this.btnSell3.TabIndex = 4;
			this.btnSell3.Text = "Sell";
			this.btnSell3.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnSell2
			//
			this.btnSell2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSell2.Location = new System.Drawing.Point(8, 64);
			this.btnSell2.Name = "btnSell2";
			this.btnSell2.Size = new System.Drawing.Size(33, 22);
			this.btnSell2.TabIndex = 3;
			this.btnSell2.Text = "Sell";
			this.btnSell2.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnSell1
			//
			this.btnSell1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSell1.Location = new System.Drawing.Point(8, 40);
			this.btnSell1.Name = "btnSell1";
			this.btnSell1.Size = new System.Drawing.Size(33, 22);
			this.btnSell1.TabIndex = 2;
			this.btnSell1.Text = "Sell";
			this.btnSell1.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnSell0
			//
			this.btnSell0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSell0.Location = new System.Drawing.Point(8, 16);
			this.btnSell0.Name = "btnSell0";
			this.btnSell0.Size = new System.Drawing.Size(33, 22);
			this.btnSell0.TabIndex = 1;
			this.btnSell0.Text = "Sell";
			this.btnSell0.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// boxBuy
			//
			this.boxBuy.Controls.AddRange(new System.Windows.Forms.Control[] {
																																				 this.lblBuyPrice9,
																																				 this.lblBuyItem9,
																																				 this.btnBuy9,
																																				 this.lblBuyPrice8,
																																				 this.lblBuyPrice7,
																																				 this.lblBuyPrice6,
																																				 this.lblBuyPrice5,
																																				 this.lblBuyPrice4,
																																				 this.lblBuyPrice3,
																																				 this.lblBuyPrice2,
																																				 this.lblBuyPrice1,
																																				 this.lblBuyPrice0,
																																				 this.lblBuyItem4,
																																				 this.lblBuyItem8,
																																				 this.lblBuyItem7,
																																				 this.lblBuyItem6,
																																				 this.lblBuyItem5,
																																				 this.lblBuyItem3,
																																				 this.lblBuyItem2,
																																				 this.lblBuyItem1,
																																				 this.lblBuyItem0,
																																				 this.picBuyLine1,
																																				 this.picBuyLine0,
																																				 this.btnBuy8,
																																				 this.btnBuy7,
																																				 this.btnBuy6,
																																				 this.btnBuy5,
																																				 this.btnBuy4,
																																				 this.btnBuy3,
																																				 this.btnBuy2,
																																				 this.btnBuy1,
																																				 this.btnBuy0});
			this.boxBuy.Location = new System.Drawing.Point(248, 8);
			this.boxBuy.Name = "boxBuy";
			this.boxBuy.Size = new System.Drawing.Size(234, 280);
			this.boxBuy.TabIndex = 34;
			this.boxBuy.TabStop = false;
			this.boxBuy.Text = "Equipment For Sale";
			//
			// lblBuyPrice9
			//
			this.lblBuyPrice9.Location = new System.Drawing.Point(162, 254);
			this.lblBuyPrice9.Name = "lblBuyPrice9";
			this.lblBuyPrice9.Size = new System.Drawing.Size(61, 13);
			this.lblBuyPrice9.TabIndex = 155;
			this.lblBuyPrice9.Text = "888,888 cr.";
			this.lblBuyPrice9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblBuyItem9
			//
			this.lblBuyItem9.Location = new System.Drawing.Point(50, 254);
			this.lblBuyItem9.Name = "lblBuyItem9";
			this.lblBuyItem9.Size = new System.Drawing.Size(105, 13);
			this.lblBuyItem9.TabIndex = 154;
			this.lblBuyItem9.Text = "Auto-Repair System";
			//
			// btnBuy9
			//
			this.btnBuy9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy9.Location = new System.Drawing.Point(8, 250);
			this.btnBuy9.Name = "btnBuy9";
			this.btnBuy9.Size = new System.Drawing.Size(35, 22);
			this.btnBuy9.TabIndex = 19;
			this.btnBuy9.Text = "Buy";
			this.btnBuy9.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// lblBuyPrice8
			//
			this.lblBuyPrice8.Location = new System.Drawing.Point(162, 230);
			this.lblBuyPrice8.Name = "lblBuyPrice8";
			this.lblBuyPrice8.Size = new System.Drawing.Size(61, 13);
			this.lblBuyPrice8.TabIndex = 152;
			this.lblBuyPrice8.Text = "888,888 cr.";
			this.lblBuyPrice8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblBuyPrice7
			//
			this.lblBuyPrice7.Location = new System.Drawing.Point(162, 206);
			this.lblBuyPrice7.Name = "lblBuyPrice7";
			this.lblBuyPrice7.Size = new System.Drawing.Size(61, 13);
			this.lblBuyPrice7.TabIndex = 151;
			this.lblBuyPrice7.Text = "888,888 cr.";
			this.lblBuyPrice7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblBuyPrice6
			//
			this.lblBuyPrice6.Location = new System.Drawing.Point(162, 182);
			this.lblBuyPrice6.Name = "lblBuyPrice6";
			this.lblBuyPrice6.Size = new System.Drawing.Size(61, 13);
			this.lblBuyPrice6.TabIndex = 150;
			this.lblBuyPrice6.Text = "888,888 cr.";
			this.lblBuyPrice6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblBuyPrice5
			//
			this.lblBuyPrice5.Location = new System.Drawing.Point(162, 158);
			this.lblBuyPrice5.Name = "lblBuyPrice5";
			this.lblBuyPrice5.Size = new System.Drawing.Size(61, 13);
			this.lblBuyPrice5.TabIndex = 149;
			this.lblBuyPrice5.Text = "888,888 cr.";
			this.lblBuyPrice5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblBuyPrice4
			//
			this.lblBuyPrice4.Location = new System.Drawing.Point(162, 125);
			this.lblBuyPrice4.Name = "lblBuyPrice4";
			this.lblBuyPrice4.Size = new System.Drawing.Size(61, 13);
			this.lblBuyPrice4.TabIndex = 148;
			this.lblBuyPrice4.Text = "888,888 cr.";
			this.lblBuyPrice4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblBuyPrice3
			//
			this.lblBuyPrice3.Location = new System.Drawing.Point(162, 101);
			this.lblBuyPrice3.Name = "lblBuyPrice3";
			this.lblBuyPrice3.Size = new System.Drawing.Size(61, 13);
			this.lblBuyPrice3.TabIndex = 147;
			this.lblBuyPrice3.Text = "888,888 cr.";
			this.lblBuyPrice3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblBuyPrice2
			//
			this.lblBuyPrice2.Location = new System.Drawing.Point(162, 68);
			this.lblBuyPrice2.Name = "lblBuyPrice2";
			this.lblBuyPrice2.Size = new System.Drawing.Size(61, 13);
			this.lblBuyPrice2.TabIndex = 146;
			this.lblBuyPrice2.Text = "888,888 cr.";
			this.lblBuyPrice2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblBuyPrice1
			//
			this.lblBuyPrice1.Location = new System.Drawing.Point(162, 44);
			this.lblBuyPrice1.Name = "lblBuyPrice1";
			this.lblBuyPrice1.Size = new System.Drawing.Size(61, 13);
			this.lblBuyPrice1.TabIndex = 145;
			this.lblBuyPrice1.Text = "888,888 cr.";
			this.lblBuyPrice1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblBuyPrice0
			//
			this.lblBuyPrice0.Location = new System.Drawing.Point(162, 20);
			this.lblBuyPrice0.Name = "lblBuyPrice0";
			this.lblBuyPrice0.Size = new System.Drawing.Size(61, 13);
			this.lblBuyPrice0.TabIndex = 144;
			this.lblBuyPrice0.Text = "888,888 cr.";
			this.lblBuyPrice0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblBuyItem4
			//
			this.lblBuyItem4.Location = new System.Drawing.Point(50, 125);
			this.lblBuyItem4.Name = "lblBuyItem4";
			this.lblBuyItem4.Size = new System.Drawing.Size(105, 13);
			this.lblBuyItem4.TabIndex = 143;
			this.lblBuyItem4.Text = "Auto-Repair System";
			//
			// lblBuyItem8
			//
			this.lblBuyItem8.Location = new System.Drawing.Point(50, 230);
			this.lblBuyItem8.Name = "lblBuyItem8";
			this.lblBuyItem8.Size = new System.Drawing.Size(105, 13);
			this.lblBuyItem8.TabIndex = 142;
			this.lblBuyItem8.Text = "Auto-Repair System";
			//
			// lblBuyItem7
			//
			this.lblBuyItem7.Location = new System.Drawing.Point(50, 206);
			this.lblBuyItem7.Name = "lblBuyItem7";
			this.lblBuyItem7.Size = new System.Drawing.Size(105, 13);
			this.lblBuyItem7.TabIndex = 141;
			this.lblBuyItem7.Text = "Auto-Repair System";
			//
			// lblBuyItem6
			//
			this.lblBuyItem6.Location = new System.Drawing.Point(50, 182);
			this.lblBuyItem6.Name = "lblBuyItem6";
			this.lblBuyItem6.Size = new System.Drawing.Size(105, 13);
			this.lblBuyItem6.TabIndex = 140;
			this.lblBuyItem6.Text = "Auto-Repair System";
			//
			// lblBuyItem5
			//
			this.lblBuyItem5.Location = new System.Drawing.Point(50, 158);
			this.lblBuyItem5.Name = "lblBuyItem5";
			this.lblBuyItem5.Size = new System.Drawing.Size(105, 13);
			this.lblBuyItem5.TabIndex = 139;
			this.lblBuyItem5.Text = "Auto-Repair System";
			//
			// lblBuyItem3
			//
			this.lblBuyItem3.Location = new System.Drawing.Point(50, 101);
			this.lblBuyItem3.Name = "lblBuyItem3";
			this.lblBuyItem3.Size = new System.Drawing.Size(105, 13);
			this.lblBuyItem3.TabIndex = 138;
			this.lblBuyItem3.Text = "Auto-Repair System";
			//
			// lblBuyItem2
			//
			this.lblBuyItem2.Location = new System.Drawing.Point(50, 68);
			this.lblBuyItem2.Name = "lblBuyItem2";
			this.lblBuyItem2.Size = new System.Drawing.Size(105, 13);
			this.lblBuyItem2.TabIndex = 137;
			this.lblBuyItem2.Text = "Auto-Repair System";
			//
			// lblBuyItem1
			//
			this.lblBuyItem1.Location = new System.Drawing.Point(50, 44);
			this.lblBuyItem1.Name = "lblBuyItem1";
			this.lblBuyItem1.Size = new System.Drawing.Size(105, 13);
			this.lblBuyItem1.TabIndex = 136;
			this.lblBuyItem1.Text = "Auto-Repair System";
			//
			// lblBuyItem0
			//
			this.lblBuyItem0.Location = new System.Drawing.Point(50, 20);
			this.lblBuyItem0.Name = "lblBuyItem0";
			this.lblBuyItem0.Size = new System.Drawing.Size(105, 13);
			this.lblBuyItem0.TabIndex = 135;
			this.lblBuyItem0.Text = "Auto-Repair System";
			//
			// picBuyLine1
			//
			this.picBuyLine1.BackColor = System.Drawing.Color.DimGray;
			this.picBuyLine1.Location = new System.Drawing.Point(6, 148);
			this.picBuyLine1.Name = "picBuyLine1";
			this.picBuyLine1.Size = new System.Drawing.Size(222, 1);
			this.picBuyLine1.TabIndex = 134;
			this.picBuyLine1.TabStop = false;
			//
			// picBuyLine0
			//
			this.picBuyLine0.BackColor = System.Drawing.Color.DimGray;
			this.picBuyLine0.Location = new System.Drawing.Point(6, 91);
			this.picBuyLine0.Name = "picBuyLine0";
			this.picBuyLine0.Size = new System.Drawing.Size(222, 1);
			this.picBuyLine0.TabIndex = 133;
			this.picBuyLine0.TabStop = false;
			//
			// btnBuy8
			//
			this.btnBuy8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy8.Location = new System.Drawing.Point(8, 226);
			this.btnBuy8.Name = "btnBuy8";
			this.btnBuy8.Size = new System.Drawing.Size(35, 22);
			this.btnBuy8.TabIndex = 18;
			this.btnBuy8.Text = "Buy";
			this.btnBuy8.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnBuy7
			//
			this.btnBuy7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy7.Location = new System.Drawing.Point(8, 202);
			this.btnBuy7.Name = "btnBuy7";
			this.btnBuy7.Size = new System.Drawing.Size(35, 22);
			this.btnBuy7.TabIndex = 17;
			this.btnBuy7.Text = "Buy";
			this.btnBuy7.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnBuy6
			//
			this.btnBuy6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy6.Location = new System.Drawing.Point(8, 178);
			this.btnBuy6.Name = "btnBuy6";
			this.btnBuy6.Size = new System.Drawing.Size(35, 22);
			this.btnBuy6.TabIndex = 16;
			this.btnBuy6.Text = "Buy";
			this.btnBuy6.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnBuy5
			//
			this.btnBuy5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy5.Location = new System.Drawing.Point(8, 154);
			this.btnBuy5.Name = "btnBuy5";
			this.btnBuy5.Size = new System.Drawing.Size(35, 22);
			this.btnBuy5.TabIndex = 15;
			this.btnBuy5.Text = "Buy";
			this.btnBuy5.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnBuy4
			//
			this.btnBuy4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy4.Location = new System.Drawing.Point(8, 121);
			this.btnBuy4.Name = "btnBuy4";
			this.btnBuy4.Size = new System.Drawing.Size(35, 22);
			this.btnBuy4.TabIndex = 14;
			this.btnBuy4.Text = "Buy";
			this.btnBuy4.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnBuy3
			//
			this.btnBuy3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy3.Location = new System.Drawing.Point(8, 97);
			this.btnBuy3.Name = "btnBuy3";
			this.btnBuy3.Size = new System.Drawing.Size(35, 22);
			this.btnBuy3.TabIndex = 13;
			this.btnBuy3.Text = "Buy";
			this.btnBuy3.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnBuy2
			//
			this.btnBuy2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy2.Location = new System.Drawing.Point(8, 64);
			this.btnBuy2.Name = "btnBuy2";
			this.btnBuy2.Size = new System.Drawing.Size(35, 22);
			this.btnBuy2.TabIndex = 12;
			this.btnBuy2.Text = "Buy";
			this.btnBuy2.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnBuy1
			//
			this.btnBuy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy1.Location = new System.Drawing.Point(8, 40);
			this.btnBuy1.Name = "btnBuy1";
			this.btnBuy1.Size = new System.Drawing.Size(35, 22);
			this.btnBuy1.TabIndex = 11;
			this.btnBuy1.Text = "Buy";
			this.btnBuy1.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// btnBuy0
			//
			this.btnBuy0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy0.Location = new System.Drawing.Point(8, 16);
			this.btnBuy0.Name = "btnBuy0";
			this.btnBuy0.Size = new System.Drawing.Size(35, 22);
			this.btnBuy0.TabIndex = 10;
			this.btnBuy0.Text = "Buy";
			this.btnBuy0.Click += new System.EventHandler(this.btnBuySell_Click);
			//
			// FormEquipment
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(490, 297);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
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
			this.ResumeLayout(false);
		}
		#endregion

		private void Buy(int item)
		{
			Commander			cmdr			= game.Commander;
			EquipmentType	baseType	= equipBuy[item].EquipmentType;

			if (baseType == EquipmentType.Gadget && cmdr.Ship.HasGadget(((Gadget)equipBuy[item]).Type) &&
					((Gadget)equipBuy[item]).Type != GadgetType.ExtraCargoBays)
				FormAlert.Alert(AlertType.EquipmentAlreadyOwn, this);
			else if (cmdr.Debt > 0)
				FormAlert.Alert(AlertType.DebtNoBuy, this);
			else if (equipBuy[item].Price > cmdr.CashToSpend)
				FormAlert.Alert(AlertType.EquipmentIF, this);
			else if ((baseType == EquipmentType.Weapon && cmdr.Ship.FreeSlotsWeapon == 0) ||
							 (baseType == EquipmentType.Shield && cmdr.Ship.FreeSlotsShield == 0) ||
							 (baseType == EquipmentType.Gadget && cmdr.Ship.FreeSlotsGadget == 0))
				FormAlert.Alert(AlertType.EquipmentNotEnoughSlots, this);
			else if (FormAlert.Alert(AlertType.EquipmentBuy, this, equipBuy[item].Name,
				Functions.FormatNumber(equipBuy[item].Price)) == DialogResult.Yes)
			{
				cmdr.Ship.AddEquipment(equipBuy[item]);
				cmdr.Cash	-= equipBuy[item].Price;

				UpdateSell();
				game.ParentWindow.UpdateAll();
			}
		}

		private void Sell(int item)
		{
			if (FormAlert.Alert(AlertType.EquipmentSell, this) == DialogResult.Yes)
			{
				Commander			cmdr	= game.Commander;
				EquipmentType	type	= (EquipmentType)(item / 3);
				int						slot	= item % 3;

				if (type == EquipmentType.Gadget &&
					cmdr.Ship.Gadgets[slot].Type == GadgetType.ExtraCargoBays &&
					cmdr.Ship.FreeCargoBays < 5)
				{
					FormAlert.Alert(AlertType.EquipmentExtraBaysInUse, this);
				}
				else
				{
					cmdr.Cash	+= game.Commander.Ship.Equipment[item].SellPrice;
					cmdr.Ship.RemoveEquipment(type, slot);

					UpdateSell();
					game.ParentWindow.UpdateAll();
				}
			}
		}

		private void UpdateBuy()
		{
			for (int i = 0; i < equipBuy.Length; i++)
			{
				lblBuyItem[i].Text				= equipBuy[i].Name;
				if (equipBuy[i].Price > 0)
					lblBuyPrice[i].Text			= Functions.FormatMoney(equipBuy[i].Price);
				else
				{
					lblBuyPrice[i].Text			= Strings.CargoBuyNA;
					btnBuy[i].Visible				= false;
				}
			}
		}

		private void UpdateSell()
		{
			Equipment[]	equipSell	= Game.CurrentGame.Commander.Ship.Equipment;

			for (int i = 0; i < equipSell.Length; i++)
			{
				if (equipSell[i] != null)
				{
					lblSellItem[i].Text				= equipSell[i].Name;
					lblSellPrice[i].Text			= Functions.FormatMoney(equipSell[i].SellPrice);
					lblSellItem[i].Visible		= true;
					lblSellPrice[i].Visible		= true;
					btnSell[i].Visible				= true;
				}
				else
				{
					if (i % 3 == 0)
						lblSellItem[i].Text			= Functions.StringVars(Strings.EquipmentNone, Strings.EquipmentTypes[i / 3]);
					else
						lblSellItem[i].Visible	= false;
					lblSellPrice[i].Visible		= false;
					btnSell[i].Visible				= false;
				}
			}
		}

		#endregion

		#region Event Handlers

		private void btnBuySell_Click(object sender, System.EventArgs e)
		{
			string	name	= ((Button)sender).Name;
			int			index	= int.Parse(name.Substring(name.Length - 1));

			if (name.IndexOf("Buy") < 0)
				Sell(index);
			else
				Buy(index);
		}

		#endregion
	}
}
