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
	public class FormShipList : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnBuy0;
		private System.Windows.Forms.Label lblName0;
		private System.Windows.Forms.Button btnInfo0;
		private System.Windows.Forms.Label lblPrice0;
		private System.Windows.Forms.Label lblPrice1;
		private System.Windows.Forms.Button btnInfo1;
		private System.Windows.Forms.Label lblName1;
		private System.Windows.Forms.Button btnBuy1;
		private System.Windows.Forms.Label lblPrice2;
		private System.Windows.Forms.Button btnInfo2;
		private System.Windows.Forms.Label lblName2;
		private System.Windows.Forms.Button btnBuy2;
		private System.Windows.Forms.Label lblPrice3;
		private System.Windows.Forms.Button btnInfo3;
		private System.Windows.Forms.Label lblName3;
		private System.Windows.Forms.Button btnBuy3;
		private System.Windows.Forms.Label lblPrice4;
		private System.Windows.Forms.Button btnInfo4;
		private System.Windows.Forms.Label lblName4;
		private System.Windows.Forms.Button btnBuy4;
		private System.Windows.Forms.Label lblPrice5;
		private System.Windows.Forms.Button btnInfo5;
		private System.Windows.Forms.Label lblName5;
		private System.Windows.Forms.Button btnBuy5;
		private System.Windows.Forms.Label lblPrice6;
		private System.Windows.Forms.Button btnInfo6;
		private System.Windows.Forms.Label lblName6;
		private System.Windows.Forms.Button btnBuy6;
		private System.Windows.Forms.Label lblPrice7;
		private System.Windows.Forms.Button btnInfo7;
		private System.Windows.Forms.Label lblName7;
		private System.Windows.Forms.Button btnBuy7;
		private System.Windows.Forms.Label lblPrice8;
		private System.Windows.Forms.Button btnInfo8;
		private System.Windows.Forms.Label lblName8;
		private System.Windows.Forms.Button btnBuy8;
		private System.Windows.Forms.Label lblPrice9;
		private System.Windows.Forms.Button btnInfo9;
		private System.Windows.Forms.Label lblName9;
		private System.Windows.Forms.Button btnBuy9;
		private System.Windows.Forms.GroupBox boxShipInfo;
		private System.Windows.Forms.Label lblSizeLabel;
		private System.Windows.Forms.Label lblNameLabel;
		private System.Windows.Forms.Label lblBaysLabel;
		private System.Windows.Forms.Label lblRangeLabel;
		private System.Windows.Forms.Label lblHullLabel;
		private System.Windows.Forms.Label lblWeaponLabel;
		private System.Windows.Forms.Label lblShieldLabel;
		private System.Windows.Forms.Label lblCrewLabel;
		private System.Windows.Forms.Label lblGadgetLabel;
		private System.Windows.Forms.PictureBox picShip;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblSize;
		private System.Windows.Forms.Label lblBays;
		private System.Windows.Forms.Label lblRange;
		private System.Windows.Forms.Label lblHull;
		private System.Windows.Forms.Label lblWeapon;
		private System.Windows.Forms.Label lblShield;
		private System.Windows.Forms.Label lblGadget;
		private System.Windows.Forms.Label lblCrew;
		private System.ComponentModel.Container components = null;

		private Label[]		lblPrice;
		private Button[]	btnBuy;

		#endregion

		#region Member Declarations

		private Game			game		= Game.CurrentGame;
		private int[]			prices	= new int[Consts.ShipSpecs.Length];

		#endregion

		#region Methods

		public FormShipList()
		{
			InitializeComponent();

			#region Array of controls
			lblPrice	= new Label[]
			{
				lblPrice0,
				lblPrice1,
				lblPrice2,
				lblPrice3,
				lblPrice4,
				lblPrice5,
				lblPrice6,
				lblPrice7,
				lblPrice8,
				lblPrice9,
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
				btnBuy9,
			};
			#endregion

			UpdateAll();
			Info((int)game.Commander.Ship.Type);

			if (game.Commander.Ship.Tribbles > 0 && !game.TribbleMessage)
			{
				FormAlert.Alert(AlertType.TribblesTradeIn, this);
				game.TribbleMessage	= true;
			}
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
			this.btnBuy0 = new System.Windows.Forms.Button();
			this.lblName0 = new System.Windows.Forms.Label();
			this.btnInfo0 = new System.Windows.Forms.Button();
			this.lblPrice0 = new System.Windows.Forms.Label();
			this.lblPrice1 = new System.Windows.Forms.Label();
			this.btnInfo1 = new System.Windows.Forms.Button();
			this.lblName1 = new System.Windows.Forms.Label();
			this.btnBuy1 = new System.Windows.Forms.Button();
			this.lblPrice2 = new System.Windows.Forms.Label();
			this.btnInfo2 = new System.Windows.Forms.Button();
			this.lblName2 = new System.Windows.Forms.Label();
			this.btnBuy2 = new System.Windows.Forms.Button();
			this.lblPrice3 = new System.Windows.Forms.Label();
			this.btnInfo3 = new System.Windows.Forms.Button();
			this.lblName3 = new System.Windows.Forms.Label();
			this.btnBuy3 = new System.Windows.Forms.Button();
			this.lblPrice4 = new System.Windows.Forms.Label();
			this.btnInfo4 = new System.Windows.Forms.Button();
			this.lblName4 = new System.Windows.Forms.Label();
			this.btnBuy4 = new System.Windows.Forms.Button();
			this.lblPrice5 = new System.Windows.Forms.Label();
			this.btnInfo5 = new System.Windows.Forms.Button();
			this.lblName5 = new System.Windows.Forms.Label();
			this.btnBuy5 = new System.Windows.Forms.Button();
			this.lblPrice6 = new System.Windows.Forms.Label();
			this.btnInfo6 = new System.Windows.Forms.Button();
			this.lblName6 = new System.Windows.Forms.Label();
			this.btnBuy6 = new System.Windows.Forms.Button();
			this.lblPrice7 = new System.Windows.Forms.Label();
			this.btnInfo7 = new System.Windows.Forms.Button();
			this.lblName7 = new System.Windows.Forms.Label();
			this.btnBuy7 = new System.Windows.Forms.Button();
			this.lblPrice8 = new System.Windows.Forms.Label();
			this.btnInfo8 = new System.Windows.Forms.Button();
			this.lblName8 = new System.Windows.Forms.Label();
			this.btnBuy8 = new System.Windows.Forms.Button();
			this.lblPrice9 = new System.Windows.Forms.Label();
			this.btnInfo9 = new System.Windows.Forms.Button();
			this.lblName9 = new System.Windows.Forms.Label();
			this.btnBuy9 = new System.Windows.Forms.Button();
			this.boxShipInfo = new System.Windows.Forms.GroupBox();
			this.lblCrew = new System.Windows.Forms.Label();
			this.lblGadget = new System.Windows.Forms.Label();
			this.lblShield = new System.Windows.Forms.Label();
			this.lblWeapon = new System.Windows.Forms.Label();
			this.lblHull = new System.Windows.Forms.Label();
			this.lblRange = new System.Windows.Forms.Label();
			this.lblBays = new System.Windows.Forms.Label();
			this.lblSize = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.picShip = new System.Windows.Forms.PictureBox();
			this.lblGadgetLabel = new System.Windows.Forms.Label();
			this.lblCrewLabel = new System.Windows.Forms.Label();
			this.lblShieldLabel = new System.Windows.Forms.Label();
			this.lblWeaponLabel = new System.Windows.Forms.Label();
			this.lblHullLabel = new System.Windows.Forms.Label();
			this.lblRangeLabel = new System.Windows.Forms.Label();
			this.lblBaysLabel = new System.Windows.Forms.Label();
			this.lblNameLabel = new System.Windows.Forms.Label();
			this.lblSizeLabel = new System.Windows.Forms.Label();
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
			// btnBuy0
			// 
			this.btnBuy0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy0.Location = new System.Drawing.Point(8, 8);
			this.btnBuy0.Name = "btnBuy0";
			this.btnBuy0.Size = new System.Drawing.Size(35, 22);
			this.btnBuy0.TabIndex = 1;
			this.btnBuy0.Text = "Buy";
			this.btnBuy0.Visible = false;
			this.btnBuy0.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblName0
			// 
			this.lblName0.Location = new System.Drawing.Point(48, 12);
			this.lblName0.Name = "lblName0";
			this.lblName0.Size = new System.Drawing.Size(70, 13);
			this.lblName0.TabIndex = 34;
			this.lblName0.Text = "Flea";
			// 
			// btnInfo0
			// 
			this.btnInfo0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInfo0.Location = new System.Drawing.Point(120, 8);
			this.btnInfo0.Name = "btnInfo0";
			this.btnInfo0.Size = new System.Drawing.Size(34, 22);
			this.btnInfo0.TabIndex = 11;
			this.btnInfo0.Text = "Info";
			this.btnInfo0.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblPrice0
			// 
			this.lblPrice0.Location = new System.Drawing.Point(160, 12);
			this.lblPrice0.Name = "lblPrice0";
			this.lblPrice0.Size = new System.Drawing.Size(64, 13);
			this.lblPrice0.TabIndex = 36;
			this.lblPrice0.Text = "-888,888 cr.";
			this.lblPrice0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblPrice1
			// 
			this.lblPrice1.Location = new System.Drawing.Point(160, 36);
			this.lblPrice1.Name = "lblPrice1";
			this.lblPrice1.Size = new System.Drawing.Size(64, 13);
			this.lblPrice1.TabIndex = 40;
			this.lblPrice1.Text = "-888,888 cr.";
			this.lblPrice1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnInfo1
			// 
			this.btnInfo1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInfo1.Location = new System.Drawing.Point(120, 32);
			this.btnInfo1.Name = "btnInfo1";
			this.btnInfo1.Size = new System.Drawing.Size(34, 22);
			this.btnInfo1.TabIndex = 12;
			this.btnInfo1.Text = "Info";
			this.btnInfo1.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblName1
			// 
			this.lblName1.Location = new System.Drawing.Point(48, 36);
			this.lblName1.Name = "lblName1";
			this.lblName1.Size = new System.Drawing.Size(70, 13);
			this.lblName1.TabIndex = 38;
			this.lblName1.Text = "Gnat";
			// 
			// btnBuy1
			// 
			this.btnBuy1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy1.Location = new System.Drawing.Point(8, 32);
			this.btnBuy1.Name = "btnBuy1";
			this.btnBuy1.Size = new System.Drawing.Size(35, 22);
			this.btnBuy1.TabIndex = 2;
			this.btnBuy1.Text = "Buy";
			this.btnBuy1.Visible = false;
			this.btnBuy1.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblPrice2
			// 
			this.lblPrice2.Location = new System.Drawing.Point(160, 60);
			this.lblPrice2.Name = "lblPrice2";
			this.lblPrice2.Size = new System.Drawing.Size(64, 13);
			this.lblPrice2.TabIndex = 44;
			this.lblPrice2.Text = "-888,888 cr.";
			this.lblPrice2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnInfo2
			// 
			this.btnInfo2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInfo2.Location = new System.Drawing.Point(120, 56);
			this.btnInfo2.Name = "btnInfo2";
			this.btnInfo2.Size = new System.Drawing.Size(34, 22);
			this.btnInfo2.TabIndex = 13;
			this.btnInfo2.Text = "Info";
			this.btnInfo2.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblName2
			// 
			this.lblName2.Location = new System.Drawing.Point(48, 60);
			this.lblName2.Name = "lblName2";
			this.lblName2.Size = new System.Drawing.Size(70, 13);
			this.lblName2.TabIndex = 42;
			this.lblName2.Text = "Firefly";
			// 
			// btnBuy2
			// 
			this.btnBuy2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy2.Location = new System.Drawing.Point(8, 56);
			this.btnBuy2.Name = "btnBuy2";
			this.btnBuy2.Size = new System.Drawing.Size(35, 22);
			this.btnBuy2.TabIndex = 3;
			this.btnBuy2.Text = "Buy";
			this.btnBuy2.Visible = false;
			this.btnBuy2.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblPrice3
			// 
			this.lblPrice3.Location = new System.Drawing.Point(160, 84);
			this.lblPrice3.Name = "lblPrice3";
			this.lblPrice3.Size = new System.Drawing.Size(64, 13);
			this.lblPrice3.TabIndex = 48;
			this.lblPrice3.Text = "-888,888 cr.";
			this.lblPrice3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnInfo3
			// 
			this.btnInfo3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInfo3.Location = new System.Drawing.Point(120, 80);
			this.btnInfo3.Name = "btnInfo3";
			this.btnInfo3.Size = new System.Drawing.Size(34, 22);
			this.btnInfo3.TabIndex = 14;
			this.btnInfo3.Text = "Info";
			this.btnInfo3.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblName3
			// 
			this.lblName3.Location = new System.Drawing.Point(48, 84);
			this.lblName3.Name = "lblName3";
			this.lblName3.Size = new System.Drawing.Size(70, 13);
			this.lblName3.TabIndex = 46;
			this.lblName3.Text = "Mosquito";
			// 
			// btnBuy3
			// 
			this.btnBuy3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy3.Location = new System.Drawing.Point(8, 80);
			this.btnBuy3.Name = "btnBuy3";
			this.btnBuy3.Size = new System.Drawing.Size(35, 22);
			this.btnBuy3.TabIndex = 4;
			this.btnBuy3.Text = "Buy";
			this.btnBuy3.Visible = false;
			this.btnBuy3.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblPrice4
			// 
			this.lblPrice4.Location = new System.Drawing.Point(160, 108);
			this.lblPrice4.Name = "lblPrice4";
			this.lblPrice4.Size = new System.Drawing.Size(64, 13);
			this.lblPrice4.TabIndex = 52;
			this.lblPrice4.Text = "-888,888 cr.";
			this.lblPrice4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnInfo4
			// 
			this.btnInfo4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInfo4.Location = new System.Drawing.Point(120, 104);
			this.btnInfo4.Name = "btnInfo4";
			this.btnInfo4.Size = new System.Drawing.Size(34, 22);
			this.btnInfo4.TabIndex = 15;
			this.btnInfo4.Text = "Info";
			this.btnInfo4.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblName4
			// 
			this.lblName4.Location = new System.Drawing.Point(48, 108);
			this.lblName4.Name = "lblName4";
			this.lblName4.Size = new System.Drawing.Size(70, 13);
			this.lblName4.TabIndex = 50;
			this.lblName4.Text = "Bumblebee";
			// 
			// btnBuy4
			// 
			this.btnBuy4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy4.Location = new System.Drawing.Point(8, 104);
			this.btnBuy4.Name = "btnBuy4";
			this.btnBuy4.Size = new System.Drawing.Size(35, 22);
			this.btnBuy4.TabIndex = 5;
			this.btnBuy4.Text = "Buy";
			this.btnBuy4.Visible = false;
			this.btnBuy4.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblPrice5
			// 
			this.lblPrice5.Location = new System.Drawing.Point(160, 132);
			this.lblPrice5.Name = "lblPrice5";
			this.lblPrice5.Size = new System.Drawing.Size(64, 13);
			this.lblPrice5.TabIndex = 56;
			this.lblPrice5.Text = "got one";
			this.lblPrice5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnInfo5
			// 
			this.btnInfo5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInfo5.Location = new System.Drawing.Point(120, 128);
			this.btnInfo5.Name = "btnInfo5";
			this.btnInfo5.Size = new System.Drawing.Size(34, 22);
			this.btnInfo5.TabIndex = 16;
			this.btnInfo5.Text = "Info";
			this.btnInfo5.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblName5
			// 
			this.lblName5.Location = new System.Drawing.Point(48, 132);
			this.lblName5.Name = "lblName5";
			this.lblName5.Size = new System.Drawing.Size(70, 13);
			this.lblName5.TabIndex = 54;
			this.lblName5.Text = "Beetle";
			// 
			// btnBuy5
			// 
			this.btnBuy5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy5.Location = new System.Drawing.Point(8, 128);
			this.btnBuy5.Name = "btnBuy5";
			this.btnBuy5.Size = new System.Drawing.Size(35, 22);
			this.btnBuy5.TabIndex = 6;
			this.btnBuy5.Text = "Buy";
			this.btnBuy5.Visible = false;
			this.btnBuy5.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblPrice6
			// 
			this.lblPrice6.Location = new System.Drawing.Point(160, 156);
			this.lblPrice6.Name = "lblPrice6";
			this.lblPrice6.Size = new System.Drawing.Size(64, 13);
			this.lblPrice6.TabIndex = 60;
			this.lblPrice6.Text = "-888,888 cr.";
			this.lblPrice6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnInfo6
			// 
			this.btnInfo6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInfo6.Location = new System.Drawing.Point(120, 152);
			this.btnInfo6.Name = "btnInfo6";
			this.btnInfo6.Size = new System.Drawing.Size(34, 22);
			this.btnInfo6.TabIndex = 17;
			this.btnInfo6.Text = "Info";
			this.btnInfo6.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblName6
			// 
			this.lblName6.Location = new System.Drawing.Point(48, 156);
			this.lblName6.Name = "lblName6";
			this.lblName6.Size = new System.Drawing.Size(70, 13);
			this.lblName6.TabIndex = 58;
			this.lblName6.Text = "Hornet";
			// 
			// btnBuy6
			// 
			this.btnBuy6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy6.Location = new System.Drawing.Point(8, 152);
			this.btnBuy6.Name = "btnBuy6";
			this.btnBuy6.Size = new System.Drawing.Size(35, 22);
			this.btnBuy6.TabIndex = 7;
			this.btnBuy6.Text = "Buy";
			this.btnBuy6.Visible = false;
			this.btnBuy6.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblPrice7
			// 
			this.lblPrice7.Location = new System.Drawing.Point(160, 180);
			this.lblPrice7.Name = "lblPrice7";
			this.lblPrice7.Size = new System.Drawing.Size(64, 13);
			this.lblPrice7.TabIndex = 64;
			this.lblPrice7.Text = "-888,888 cr.";
			this.lblPrice7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnInfo7
			// 
			this.btnInfo7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInfo7.Location = new System.Drawing.Point(120, 176);
			this.btnInfo7.Name = "btnInfo7";
			this.btnInfo7.Size = new System.Drawing.Size(34, 22);
			this.btnInfo7.TabIndex = 18;
			this.btnInfo7.Text = "Info";
			this.btnInfo7.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblName7
			// 
			this.lblName7.Location = new System.Drawing.Point(48, 180);
			this.lblName7.Name = "lblName7";
			this.lblName7.Size = new System.Drawing.Size(70, 13);
			this.lblName7.TabIndex = 62;
			this.lblName7.Text = "Grasshopper";
			// 
			// btnBuy7
			// 
			this.btnBuy7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy7.Location = new System.Drawing.Point(8, 176);
			this.btnBuy7.Name = "btnBuy7";
			this.btnBuy7.Size = new System.Drawing.Size(35, 22);
			this.btnBuy7.TabIndex = 8;
			this.btnBuy7.Text = "Buy";
			this.btnBuy7.Visible = false;
			this.btnBuy7.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblPrice8
			// 
			this.lblPrice8.Location = new System.Drawing.Point(160, 204);
			this.lblPrice8.Name = "lblPrice8";
			this.lblPrice8.Size = new System.Drawing.Size(64, 13);
			this.lblPrice8.TabIndex = 68;
			this.lblPrice8.Text = "-888,888 cr.";
			this.lblPrice8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnInfo8
			// 
			this.btnInfo8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInfo8.Location = new System.Drawing.Point(120, 200);
			this.btnInfo8.Name = "btnInfo8";
			this.btnInfo8.Size = new System.Drawing.Size(34, 22);
			this.btnInfo8.TabIndex = 19;
			this.btnInfo8.Text = "Info";
			this.btnInfo8.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblName8
			// 
			this.lblName8.Location = new System.Drawing.Point(48, 204);
			this.lblName8.Name = "lblName8";
			this.lblName8.Size = new System.Drawing.Size(70, 13);
			this.lblName8.TabIndex = 66;
			this.lblName8.Text = "Termite";
			// 
			// btnBuy8
			// 
			this.btnBuy8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy8.Location = new System.Drawing.Point(8, 200);
			this.btnBuy8.Name = "btnBuy8";
			this.btnBuy8.Size = new System.Drawing.Size(35, 22);
			this.btnBuy8.TabIndex = 9;
			this.btnBuy8.Text = "Buy";
			this.btnBuy8.Visible = false;
			this.btnBuy8.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblPrice9
			// 
			this.lblPrice9.Location = new System.Drawing.Point(160, 228);
			this.lblPrice9.Name = "lblPrice9";
			this.lblPrice9.Size = new System.Drawing.Size(64, 13);
			this.lblPrice9.TabIndex = 72;
			this.lblPrice9.Text = "not sold";
			this.lblPrice9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnInfo9
			// 
			this.btnInfo9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInfo9.Location = new System.Drawing.Point(120, 224);
			this.btnInfo9.Name = "btnInfo9";
			this.btnInfo9.Size = new System.Drawing.Size(34, 22);
			this.btnInfo9.TabIndex = 20;
			this.btnInfo9.Text = "Info";
			this.btnInfo9.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// lblName9
			// 
			this.lblName9.Location = new System.Drawing.Point(48, 228);
			this.lblName9.Name = "lblName9";
			this.lblName9.Size = new System.Drawing.Size(70, 13);
			this.lblName9.TabIndex = 70;
			this.lblName9.Text = "Wasp";
			// 
			// btnBuy9
			// 
			this.btnBuy9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuy9.Location = new System.Drawing.Point(8, 224);
			this.btnBuy9.Name = "btnBuy9";
			this.btnBuy9.Size = new System.Drawing.Size(35, 22);
			this.btnBuy9.TabIndex = 10;
			this.btnBuy9.Text = "Buy";
			this.btnBuy9.Visible = false;
			this.btnBuy9.Click += new System.EventHandler(this.btnBuyInfo_Click);
			// 
			// boxShipInfo
			// 
			this.boxShipInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
																																							this.lblCrew,
																																							this.lblGadget,
																																							this.lblShield,
																																							this.lblWeapon,
																																							this.lblHull,
																																							this.lblRange,
																																							this.lblBays,
																																							this.lblSize,
																																							this.lblName,
																																							this.picShip,
																																							this.lblGadgetLabel,
																																							this.lblCrewLabel,
																																							this.lblShieldLabel,
																																							this.lblWeaponLabel,
																																							this.lblHullLabel,
																																							this.lblRangeLabel,
																																							this.lblBaysLabel,
																																							this.lblNameLabel,
																																							this.lblSizeLabel});
			this.boxShipInfo.Location = new System.Drawing.Point(232, 0);
			this.boxShipInfo.Name = "boxShipInfo";
			this.boxShipInfo.Size = new System.Drawing.Size(200, 248);
			this.boxShipInfo.TabIndex = 73;
			this.boxShipInfo.TabStop = false;
			this.boxShipInfo.Text = "Ship Information";
			// 
			// lblCrew
			// 
			this.lblCrew.Location = new System.Drawing.Point(96, 224);
			this.lblCrew.Name = "lblCrew";
			this.lblCrew.Size = new System.Drawing.Size(10, 13);
			this.lblCrew.TabIndex = 43;
			this.lblCrew.Text = "8";
			// 
			// lblGadget
			// 
			this.lblGadget.Location = new System.Drawing.Point(96, 208);
			this.lblGadget.Name = "lblGadget";
			this.lblGadget.Size = new System.Drawing.Size(10, 13);
			this.lblGadget.TabIndex = 42;
			this.lblGadget.Text = "8";
			// 
			// lblShield
			// 
			this.lblShield.Location = new System.Drawing.Point(96, 192);
			this.lblShield.Name = "lblShield";
			this.lblShield.Size = new System.Drawing.Size(10, 13);
			this.lblShield.TabIndex = 41;
			this.lblShield.Text = "8";
			// 
			// lblWeapon
			// 
			this.lblWeapon.Location = new System.Drawing.Point(96, 176);
			this.lblWeapon.Name = "lblWeapon";
			this.lblWeapon.Size = new System.Drawing.Size(10, 13);
			this.lblWeapon.TabIndex = 40;
			this.lblWeapon.Text = "8";
			// 
			// lblHull
			// 
			this.lblHull.Location = new System.Drawing.Point(96, 160);
			this.lblHull.Name = "lblHull";
			this.lblHull.Size = new System.Drawing.Size(23, 13);
			this.lblHull.TabIndex = 39;
			this.lblHull.Text = "888";
			// 
			// lblRange
			// 
			this.lblRange.Location = new System.Drawing.Point(96, 144);
			this.lblRange.Name = "lblRange";
			this.lblRange.Size = new System.Drawing.Size(59, 13);
			this.lblRange.TabIndex = 38;
			this.lblRange.Text = "88 parsecs";
			// 
			// lblBays
			// 
			this.lblBays.Location = new System.Drawing.Point(96, 128);
			this.lblBays.Name = "lblBays";
			this.lblBays.Size = new System.Drawing.Size(17, 13);
			this.lblBays.TabIndex = 37;
			this.lblBays.Text = "88";
			// 
			// lblSize
			// 
			this.lblSize.Location = new System.Drawing.Point(96, 112);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(45, 13);
			this.lblSize.TabIndex = 36;
			this.lblSize.Text = "Medium";
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(96, 96);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(100, 13);
			this.lblName.TabIndex = 35;
			this.lblName.Text = "Grasshopper";
			// 
			// picShip
			// 
			this.picShip.BackColor = System.Drawing.Color.White;
			this.picShip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picShip.Location = new System.Drawing.Point(67, 25);
			this.picShip.Name = "picShip";
			this.picShip.Size = new System.Drawing.Size(66, 54);
			this.picShip.TabIndex = 12;
			this.picShip.TabStop = false;
			// 
			// lblGadgetLabel
			// 
			this.lblGadgetLabel.AutoSize = true;
			this.lblGadgetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblGadgetLabel.Location = new System.Drawing.Point(8, 208);
			this.lblGadgetLabel.Name = "lblGadgetLabel";
			this.lblGadgetLabel.Size = new System.Drawing.Size(76, 13);
			this.lblGadgetLabel.TabIndex = 11;
			this.lblGadgetLabel.Text = "Gadget Slots:";
			// 
			// lblCrewLabel
			// 
			this.lblCrewLabel.AutoSize = true;
			this.lblCrewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCrewLabel.Location = new System.Drawing.Point(8, 224);
			this.lblCrewLabel.Name = "lblCrewLabel";
			this.lblCrewLabel.Size = new System.Drawing.Size(84, 13);
			this.lblCrewLabel.TabIndex = 10;
			this.lblCrewLabel.Text = "Crew Quarters:";
			// 
			// lblShieldLabel
			// 
			this.lblShieldLabel.AutoSize = true;
			this.lblShieldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblShieldLabel.Location = new System.Drawing.Point(8, 192);
			this.lblShieldLabel.Name = "lblShieldLabel";
			this.lblShieldLabel.Size = new System.Drawing.Size(70, 13);
			this.lblShieldLabel.TabIndex = 9;
			this.lblShieldLabel.Text = "Shield Slots:";
			// 
			// lblWeaponLabel
			// 
			this.lblWeaponLabel.AutoSize = true;
			this.lblWeaponLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblWeaponLabel.Location = new System.Drawing.Point(8, 176);
			this.lblWeaponLabel.Name = "lblWeaponLabel";
			this.lblWeaponLabel.Size = new System.Drawing.Size(81, 13);
			this.lblWeaponLabel.TabIndex = 8;
			this.lblWeaponLabel.Text = "Weapon Slots:";
			// 
			// lblHullLabel
			// 
			this.lblHullLabel.AutoSize = true;
			this.lblHullLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblHullLabel.Location = new System.Drawing.Point(8, 160);
			this.lblHullLabel.Name = "lblHullLabel";
			this.lblHullLabel.Size = new System.Drawing.Size(73, 13);
			this.lblHullLabel.TabIndex = 7;
			this.lblHullLabel.Text = "Hull Strength";
			// 
			// lblRangeLabel
			// 
			this.lblRangeLabel.AutoSize = true;
			this.lblRangeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblRangeLabel.Location = new System.Drawing.Point(8, 144);
			this.lblRangeLabel.Name = "lblRangeLabel";
			this.lblRangeLabel.Size = new System.Drawing.Size(42, 13);
			this.lblRangeLabel.TabIndex = 6;
			this.lblRangeLabel.Text = "Range:";
			// 
			// lblBaysLabel
			// 
			this.lblBaysLabel.AutoSize = true;
			this.lblBaysLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblBaysLabel.Location = new System.Drawing.Point(8, 128);
			this.lblBaysLabel.Name = "lblBaysLabel";
			this.lblBaysLabel.Size = new System.Drawing.Size(69, 13);
			this.lblBaysLabel.TabIndex = 5;
			this.lblBaysLabel.Text = "Cargo Bays:";
			// 
			// lblNameLabel
			// 
			this.lblNameLabel.AutoSize = true;
			this.lblNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblNameLabel.Location = new System.Drawing.Point(8, 96);
			this.lblNameLabel.Name = "lblNameLabel";
			this.lblNameLabel.Size = new System.Drawing.Size(39, 13);
			this.lblNameLabel.TabIndex = 4;
			this.lblNameLabel.Text = "Name:";
			// 
			// lblSizeLabel
			// 
			this.lblSizeLabel.AutoSize = true;
			this.lblSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblSizeLabel.Location = new System.Drawing.Point(8, 112);
			this.lblSizeLabel.Name = "lblSizeLabel";
			this.lblSizeLabel.Size = new System.Drawing.Size(31, 13);
			this.lblSizeLabel.TabIndex = 3;
			this.lblSizeLabel.Text = "Size:";
			// 
			// FormShipList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(438, 255);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.boxShipInfo,
																																	this.lblPrice9,
																																	this.btnInfo9,
																																	this.lblName9,
																																	this.btnBuy9,
																																	this.lblPrice8,
																																	this.btnInfo8,
																																	this.lblName8,
																																	this.btnBuy8,
																																	this.lblPrice7,
																																	this.btnInfo7,
																																	this.lblName7,
																																	this.btnBuy7,
																																	this.lblPrice6,
																																	this.btnInfo6,
																																	this.lblName6,
																																	this.btnBuy6,
																																	this.lblPrice5,
																																	this.btnInfo5,
																																	this.lblName5,
																																	this.btnBuy5,
																																	this.lblPrice4,
																																	this.btnInfo4,
																																	this.lblName4,
																																	this.btnBuy4,
																																	this.lblPrice3,
																																	this.btnInfo3,
																																	this.lblName3,
																																	this.btnBuy3,
																																	this.lblPrice2,
																																	this.btnInfo2,
																																	this.lblName2,
																																	this.btnBuy2,
																																	this.lblPrice1,
																																	this.btnInfo1,
																																	this.lblName1,
																																	this.btnBuy1,
																																	this.lblPrice0,
																																	this.btnInfo0,
																																	this.lblName0,
																																	this.btnBuy0,
																																	this.btnClose});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormShipList";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Ship List";
			this.boxShipInfo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void Buy(int id)
		{
			Info(id);

			if (game.Commander.TradeShip(Consts.ShipSpecs[id], prices[id], this))
			{
				if (game.QuestStatusScarab == SpecialEvent.StatusScarabDone)
					game.QuestStatusScarab	= SpecialEvent.StatusScarabNotStarted;

				UpdateAll();
				game.ParentWindow.UpdateAll();
			}
		}

		private void Info(int id)
		{
			ShipSpec	spec	= Consts.ShipSpecs[id];

			picShip.Image		= spec.Image;
			lblName.Text		= spec.Name;
			lblSize.Text		= Strings.Sizes[(int)spec.Size];
			lblBays.Text		= Functions.FormatNumber(spec.CargoBays);
			lblRange.Text		= Functions.Multiples(spec.FuelTanks, Strings.DistanceUnit);
			lblHull.Text		= Functions.FormatNumber(spec.HullStrength);
			lblWeapon.Text	= Functions.FormatNumber(spec.WeaponSlots);
			lblShield.Text	= Functions.FormatNumber(spec.ShieldSlots);
			lblGadget.Text	= Functions.FormatNumber(spec.GadgetSlots);
			lblCrew.Text		= Functions.FormatNumber(spec.CrewQuarters);
		}

		private void UpdateAll()
		{
			for (int i = 0; i < lblPrice.Length; i++)
			{
				btnBuy[i].Visible	= false;

				if (Consts.ShipSpecs[i].MinimumTechLevel > game.Commander.CurrentSystem.TechLevel)
					lblPrice[i].Text	= Strings.CargoBuyNA;
				else if (Consts.ShipSpecs[i].Type == game.Commander.Ship.Type)
					lblPrice[i].Text	= Strings.ShipBuyGotOne;
				else
				{
					btnBuy[i].Visible	= true;
					prices[i]					= Consts.ShipSpecs[i].Price - game.Commander.Ship.Worth(false);
					lblPrice[i].Text	= Functions.FormatMoney(prices[i]);
				}
			}
		}

		#endregion

		#region Event Handlers

		private void btnBuyInfo_Click(object sender, System.EventArgs e)
		{
			string	name	= ((Button)sender).Name;
			int			index	= int.Parse(name.Substring(name.Length - 1));

			if (name.IndexOf("Buy") < 0)
				Info(index);
			else
				Buy(index);
		}

		#endregion
	}
}
