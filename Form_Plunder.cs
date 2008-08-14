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
	public class FormPlunder : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnPlunderAll9;
		private System.Windows.Forms.Button btnPlunderQty9;
		private System.Windows.Forms.Button btnPlunderAll8;
		private System.Windows.Forms.Button btnPlunderQty8;
		private System.Windows.Forms.Button btnPlunderAll7;
		private System.Windows.Forms.Button btnPlunderQty7;
		private System.Windows.Forms.Button btnPlunderAll6;
		private System.Windows.Forms.Button btnPlunderQty6;
		private System.Windows.Forms.Button btnPlunderAll5;
		private System.Windows.Forms.Button btnPlunderQty5;
		private System.Windows.Forms.Button btnPlunderAll4;
		private System.Windows.Forms.Button btnPlunderQty4;
		private System.Windows.Forms.Button btnPlunderAll3;
		private System.Windows.Forms.Button btnPlunderQty3;
		private System.Windows.Forms.Button btnPlunderAll2;
		private System.Windows.Forms.Button btnPlunderQty2;
		private System.Windows.Forms.Button btnPlunderAll1;
		private System.Windows.Forms.Button btnPlunderQty1;
		private System.Windows.Forms.Button btnPlunderAll0;
		private System.Windows.Forms.Button btnPlunderQty0;
		private System.Windows.Forms.Label lblTradeCmdty9;
		private System.Windows.Forms.Label lblTradeCmdty8;
		private System.Windows.Forms.Label lblTradeCmdty2;
		private System.Windows.Forms.Label lblTradeCmdty0;
		private System.Windows.Forms.Label lblTradeCmdty1;
		private System.Windows.Forms.Label lblTradeCmdty6;
		private System.Windows.Forms.Label lblTradeCmdty5;
		private System.Windows.Forms.Label lblTradeCmdty4;
		private System.Windows.Forms.Label lblTradeCmdty3;
		private System.Windows.Forms.Label lblTradeCmdty7;
		private System.Windows.Forms.Label lblBaysLabel;
		private System.Windows.Forms.Label lblBays;
		private System.Windows.Forms.Button btnDone;
		private System.Windows.Forms.Button btnJettison;
		private System.ComponentModel.Container components = null;

		private Button[]	btnPlunderQty;
		private Button[]	btnPlunderAll;

		#endregion

		#region Member Declarations

		private Game			game	= Game.CurrentGame;

		#endregion

		#region Methods

		public FormPlunder()
		{
			InitializeComponent();

			#region Arrays of Cargo controls
			btnPlunderQty	= new Button[]
			{
				btnPlunderQty0,
				btnPlunderQty1,
				btnPlunderQty2,
				btnPlunderQty3,
				btnPlunderQty4,
				btnPlunderQty5,
				btnPlunderQty6,
				btnPlunderQty7,
				btnPlunderQty8,
				btnPlunderQty9
			};

			btnPlunderAll	= new Button[]
			{
				btnPlunderAll0,
				btnPlunderAll1,
				btnPlunderAll2,
				btnPlunderAll3,
				btnPlunderAll4,
				btnPlunderAll5,
				btnPlunderAll6,
				btnPlunderAll7,
				btnPlunderAll8,
				btnPlunderAll9
			};
			#endregion

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
			this.btnPlunderAll9 = new System.Windows.Forms.Button();
			this.btnPlunderQty9 = new System.Windows.Forms.Button();
			this.btnPlunderAll8 = new System.Windows.Forms.Button();
			this.btnPlunderQty8 = new System.Windows.Forms.Button();
			this.btnPlunderAll7 = new System.Windows.Forms.Button();
			this.btnPlunderQty7 = new System.Windows.Forms.Button();
			this.btnPlunderAll6 = new System.Windows.Forms.Button();
			this.btnPlunderQty6 = new System.Windows.Forms.Button();
			this.btnPlunderAll5 = new System.Windows.Forms.Button();
			this.btnPlunderQty5 = new System.Windows.Forms.Button();
			this.btnPlunderAll4 = new System.Windows.Forms.Button();
			this.btnPlunderQty4 = new System.Windows.Forms.Button();
			this.btnPlunderAll3 = new System.Windows.Forms.Button();
			this.btnPlunderQty3 = new System.Windows.Forms.Button();
			this.btnPlunderAll2 = new System.Windows.Forms.Button();
			this.btnPlunderQty2 = new System.Windows.Forms.Button();
			this.btnPlunderAll1 = new System.Windows.Forms.Button();
			this.btnPlunderQty1 = new System.Windows.Forms.Button();
			this.btnPlunderAll0 = new System.Windows.Forms.Button();
			this.btnPlunderQty0 = new System.Windows.Forms.Button();
			this.lblTradeCmdty9 = new System.Windows.Forms.Label();
			this.lblTradeCmdty8 = new System.Windows.Forms.Label();
			this.lblTradeCmdty2 = new System.Windows.Forms.Label();
			this.lblTradeCmdty0 = new System.Windows.Forms.Label();
			this.lblTradeCmdty1 = new System.Windows.Forms.Label();
			this.lblTradeCmdty6 = new System.Windows.Forms.Label();
			this.lblTradeCmdty5 = new System.Windows.Forms.Label();
			this.lblTradeCmdty4 = new System.Windows.Forms.Label();
			this.lblTradeCmdty3 = new System.Windows.Forms.Label();
			this.lblTradeCmdty7 = new System.Windows.Forms.Label();
			this.lblBaysLabel = new System.Windows.Forms.Label();
			this.lblBays = new System.Windows.Forms.Label();
			this.btnDone = new System.Windows.Forms.Button();
			this.btnJettison = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnPlunderAll9
			// 
			this.btnPlunderAll9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderAll9.Location = new System.Drawing.Point(100, 220);
			this.btnPlunderAll9.Name = "btnPlunderAll9";
			this.btnPlunderAll9.Size = new System.Drawing.Size(32, 22);
			this.btnPlunderAll9.TabIndex = 141;
			this.btnPlunderAll9.Text = "All";
			this.btnPlunderAll9.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderQty9
			// 
			this.btnPlunderQty9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderQty9.Location = new System.Drawing.Point(68, 220);
			this.btnPlunderQty9.Name = "btnPlunderQty9";
			this.btnPlunderQty9.Size = new System.Drawing.Size(28, 22);
			this.btnPlunderQty9.TabIndex = 140;
			this.btnPlunderQty9.Text = "88";
			this.btnPlunderQty9.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderAll8
			// 
			this.btnPlunderAll8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderAll8.Location = new System.Drawing.Point(100, 196);
			this.btnPlunderAll8.Name = "btnPlunderAll8";
			this.btnPlunderAll8.Size = new System.Drawing.Size(32, 22);
			this.btnPlunderAll8.TabIndex = 139;
			this.btnPlunderAll8.Text = "All";
			this.btnPlunderAll8.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderQty8
			// 
			this.btnPlunderQty8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderQty8.Location = new System.Drawing.Point(68, 196);
			this.btnPlunderQty8.Name = "btnPlunderQty8";
			this.btnPlunderQty8.Size = new System.Drawing.Size(28, 22);
			this.btnPlunderQty8.TabIndex = 138;
			this.btnPlunderQty8.Text = "88";
			this.btnPlunderQty8.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderAll7
			// 
			this.btnPlunderAll7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderAll7.Location = new System.Drawing.Point(100, 172);
			this.btnPlunderAll7.Name = "btnPlunderAll7";
			this.btnPlunderAll7.Size = new System.Drawing.Size(32, 22);
			this.btnPlunderAll7.TabIndex = 137;
			this.btnPlunderAll7.Text = "All";
			this.btnPlunderAll7.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderQty7
			// 
			this.btnPlunderQty7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderQty7.Location = new System.Drawing.Point(68, 172);
			this.btnPlunderQty7.Name = "btnPlunderQty7";
			this.btnPlunderQty7.Size = new System.Drawing.Size(28, 22);
			this.btnPlunderQty7.TabIndex = 136;
			this.btnPlunderQty7.Text = "88";
			this.btnPlunderQty7.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderAll6
			// 
			this.btnPlunderAll6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderAll6.Location = new System.Drawing.Point(100, 148);
			this.btnPlunderAll6.Name = "btnPlunderAll6";
			this.btnPlunderAll6.Size = new System.Drawing.Size(32, 22);
			this.btnPlunderAll6.TabIndex = 135;
			this.btnPlunderAll6.Text = "All";
			this.btnPlunderAll6.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderQty6
			// 
			this.btnPlunderQty6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderQty6.Location = new System.Drawing.Point(68, 148);
			this.btnPlunderQty6.Name = "btnPlunderQty6";
			this.btnPlunderQty6.Size = new System.Drawing.Size(28, 22);
			this.btnPlunderQty6.TabIndex = 134;
			this.btnPlunderQty6.Text = "88";
			this.btnPlunderQty6.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderAll5
			// 
			this.btnPlunderAll5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderAll5.Location = new System.Drawing.Point(100, 124);
			this.btnPlunderAll5.Name = "btnPlunderAll5";
			this.btnPlunderAll5.Size = new System.Drawing.Size(32, 22);
			this.btnPlunderAll5.TabIndex = 133;
			this.btnPlunderAll5.Text = "All";
			this.btnPlunderAll5.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderQty5
			// 
			this.btnPlunderQty5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderQty5.Location = new System.Drawing.Point(68, 124);
			this.btnPlunderQty5.Name = "btnPlunderQty5";
			this.btnPlunderQty5.Size = new System.Drawing.Size(28, 22);
			this.btnPlunderQty5.TabIndex = 132;
			this.btnPlunderQty5.Text = "88";
			this.btnPlunderQty5.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderAll4
			// 
			this.btnPlunderAll4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderAll4.Location = new System.Drawing.Point(100, 100);
			this.btnPlunderAll4.Name = "btnPlunderAll4";
			this.btnPlunderAll4.Size = new System.Drawing.Size(32, 22);
			this.btnPlunderAll4.TabIndex = 131;
			this.btnPlunderAll4.Text = "All";
			this.btnPlunderAll4.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderQty4
			// 
			this.btnPlunderQty4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderQty4.Location = new System.Drawing.Point(68, 100);
			this.btnPlunderQty4.Name = "btnPlunderQty4";
			this.btnPlunderQty4.Size = new System.Drawing.Size(28, 22);
			this.btnPlunderQty4.TabIndex = 130;
			this.btnPlunderQty4.Text = "88";
			this.btnPlunderQty4.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderAll3
			// 
			this.btnPlunderAll3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderAll3.Location = new System.Drawing.Point(100, 76);
			this.btnPlunderAll3.Name = "btnPlunderAll3";
			this.btnPlunderAll3.Size = new System.Drawing.Size(32, 22);
			this.btnPlunderAll3.TabIndex = 129;
			this.btnPlunderAll3.Text = "All";
			this.btnPlunderAll3.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderQty3
			// 
			this.btnPlunderQty3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderQty3.Location = new System.Drawing.Point(68, 76);
			this.btnPlunderQty3.Name = "btnPlunderQty3";
			this.btnPlunderQty3.Size = new System.Drawing.Size(28, 22);
			this.btnPlunderQty3.TabIndex = 128;
			this.btnPlunderQty3.Text = "88";
			this.btnPlunderQty3.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderAll2
			// 
			this.btnPlunderAll2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderAll2.Location = new System.Drawing.Point(100, 52);
			this.btnPlunderAll2.Name = "btnPlunderAll2";
			this.btnPlunderAll2.Size = new System.Drawing.Size(32, 22);
			this.btnPlunderAll2.TabIndex = 127;
			this.btnPlunderAll2.Text = "All";
			this.btnPlunderAll2.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderQty2
			// 
			this.btnPlunderQty2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderQty2.Location = new System.Drawing.Point(68, 52);
			this.btnPlunderQty2.Name = "btnPlunderQty2";
			this.btnPlunderQty2.Size = new System.Drawing.Size(28, 22);
			this.btnPlunderQty2.TabIndex = 126;
			this.btnPlunderQty2.Text = "88";
			this.btnPlunderQty2.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderAll1
			// 
			this.btnPlunderAll1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderAll1.Location = new System.Drawing.Point(100, 28);
			this.btnPlunderAll1.Name = "btnPlunderAll1";
			this.btnPlunderAll1.Size = new System.Drawing.Size(32, 22);
			this.btnPlunderAll1.TabIndex = 125;
			this.btnPlunderAll1.Text = "All";
			this.btnPlunderAll1.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderQty1
			// 
			this.btnPlunderQty1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderQty1.Location = new System.Drawing.Point(68, 28);
			this.btnPlunderQty1.Name = "btnPlunderQty1";
			this.btnPlunderQty1.Size = new System.Drawing.Size(28, 22);
			this.btnPlunderQty1.TabIndex = 124;
			this.btnPlunderQty1.Text = "88";
			this.btnPlunderQty1.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderAll0
			// 
			this.btnPlunderAll0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderAll0.Location = new System.Drawing.Point(100, 4);
			this.btnPlunderAll0.Name = "btnPlunderAll0";
			this.btnPlunderAll0.Size = new System.Drawing.Size(32, 22);
			this.btnPlunderAll0.TabIndex = 123;
			this.btnPlunderAll0.Text = "All";
			this.btnPlunderAll0.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnPlunderQty0
			// 
			this.btnPlunderQty0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunderQty0.Location = new System.Drawing.Point(68, 4);
			this.btnPlunderQty0.Name = "btnPlunderQty0";
			this.btnPlunderQty0.Size = new System.Drawing.Size(28, 22);
			this.btnPlunderQty0.TabIndex = 122;
			this.btnPlunderQty0.Text = "88";
			this.btnPlunderQty0.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// lblTradeCmdty9
			// 
			this.lblTradeCmdty9.AutoSize = true;
			this.lblTradeCmdty9.Location = new System.Drawing.Point(8, 224);
			this.lblTradeCmdty9.Name = "lblTradeCmdty9";
			this.lblTradeCmdty9.Size = new System.Drawing.Size(41, 13);
			this.lblTradeCmdty9.TabIndex = 151;
			this.lblTradeCmdty9.Text = "Robots";
			// 
			// lblTradeCmdty8
			// 
			this.lblTradeCmdty8.AutoSize = true;
			this.lblTradeCmdty8.Location = new System.Drawing.Point(8, 200);
			this.lblTradeCmdty8.Name = "lblTradeCmdty8";
			this.lblTradeCmdty8.Size = new System.Drawing.Size(52, 13);
			this.lblTradeCmdty8.TabIndex = 150;
			this.lblTradeCmdty8.Text = "Narcotics";
			// 
			// lblTradeCmdty2
			// 
			this.lblTradeCmdty2.AutoSize = true;
			this.lblTradeCmdty2.Location = new System.Drawing.Point(8, 56);
			this.lblTradeCmdty2.Name = "lblTradeCmdty2";
			this.lblTradeCmdty2.Size = new System.Drawing.Size(31, 13);
			this.lblTradeCmdty2.TabIndex = 149;
			this.lblTradeCmdty2.Text = "Food";
			// 
			// lblTradeCmdty0
			// 
			this.lblTradeCmdty0.AutoSize = true;
			this.lblTradeCmdty0.Location = new System.Drawing.Point(8, 8);
			this.lblTradeCmdty0.Name = "lblTradeCmdty0";
			this.lblTradeCmdty0.Size = new System.Drawing.Size(36, 13);
			this.lblTradeCmdty0.TabIndex = 148;
			this.lblTradeCmdty0.Text = "Water";
			// 
			// lblTradeCmdty1
			// 
			this.lblTradeCmdty1.AutoSize = true;
			this.lblTradeCmdty1.Location = new System.Drawing.Point(8, 32);
			this.lblTradeCmdty1.Name = "lblTradeCmdty1";
			this.lblTradeCmdty1.Size = new System.Drawing.Size(27, 13);
			this.lblTradeCmdty1.TabIndex = 147;
			this.lblTradeCmdty1.Text = "Furs";
			// 
			// lblTradeCmdty6
			// 
			this.lblTradeCmdty6.AutoSize = true;
			this.lblTradeCmdty6.Location = new System.Drawing.Point(8, 152);
			this.lblTradeCmdty6.Name = "lblTradeCmdty6";
			this.lblTradeCmdty6.Size = new System.Drawing.Size(50, 13);
			this.lblTradeCmdty6.TabIndex = 146;
			this.lblTradeCmdty6.Text = "Medicine";
			// 
			// lblTradeCmdty5
			// 
			this.lblTradeCmdty5.AutoSize = true;
			this.lblTradeCmdty5.Location = new System.Drawing.Point(8, 128);
			this.lblTradeCmdty5.Name = "lblTradeCmdty5";
			this.lblTradeCmdty5.Size = new System.Drawing.Size(46, 13);
			this.lblTradeCmdty5.TabIndex = 145;
			this.lblTradeCmdty5.Text = "Firearms";
			// 
			// lblTradeCmdty4
			// 
			this.lblTradeCmdty4.AutoSize = true;
			this.lblTradeCmdty4.Location = new System.Drawing.Point(8, 104);
			this.lblTradeCmdty4.Name = "lblTradeCmdty4";
			this.lblTradeCmdty4.Size = new System.Drawing.Size(40, 13);
			this.lblTradeCmdty4.TabIndex = 144;
			this.lblTradeCmdty4.Text = "Games";
			// 
			// lblTradeCmdty3
			// 
			this.lblTradeCmdty3.AutoSize = true;
			this.lblTradeCmdty3.Location = new System.Drawing.Point(8, 80);
			this.lblTradeCmdty3.Name = "lblTradeCmdty3";
			this.lblTradeCmdty3.Size = new System.Drawing.Size(24, 13);
			this.lblTradeCmdty3.TabIndex = 143;
			this.lblTradeCmdty3.Text = "Ore";
			// 
			// lblTradeCmdty7
			// 
			this.lblTradeCmdty7.AutoSize = true;
			this.lblTradeCmdty7.Location = new System.Drawing.Point(8, 176);
			this.lblTradeCmdty7.Name = "lblTradeCmdty7";
			this.lblTradeCmdty7.Size = new System.Drawing.Size(53, 13);
			this.lblTradeCmdty7.TabIndex = 142;
			this.lblTradeCmdty7.Text = "Machines";
			// 
			// lblBaysLabel
			// 
			this.lblBaysLabel.AutoSize = true;
			this.lblBaysLabel.Location = new System.Drawing.Point(144, 8);
			this.lblBaysLabel.Name = "lblBaysLabel";
			this.lblBaysLabel.Size = new System.Drawing.Size(33, 13);
			this.lblBaysLabel.TabIndex = 152;
			this.lblBaysLabel.Text = "Bays:";
			// 
			// lblBays
			// 
			this.lblBays.Location = new System.Drawing.Point(176, 8);
			this.lblBays.Name = "lblBays";
			this.lblBays.Size = new System.Drawing.Size(48, 13);
			this.lblBays.TabIndex = 153;
			this.lblBays.Text = "888/888";
			// 
			// btnDone
			// 
			this.btnDone.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDone.Location = new System.Drawing.Point(87, 252);
			this.btnDone.Name = "btnDone";
			this.btnDone.Size = new System.Drawing.Size(44, 22);
			this.btnDone.TabIndex = 154;
			this.btnDone.Text = "Done";
			// 
			// btnJettison
			// 
			this.btnJettison.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettison.Location = new System.Drawing.Point(150, 24);
			this.btnJettison.Name = "btnJettison";
			this.btnJettison.Size = new System.Drawing.Size(53, 22);
			this.btnJettison.TabIndex = 155;
			this.btnJettison.Text = "Jettison";
			this.btnJettison.Click += new System.EventHandler(this.btnJettison_Click);
			// 
			// FormPlunder
			// 
			this.AcceptButton = this.btnDone;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnDone;
			this.ClientSize = new System.Drawing.Size(230, 283);
			this.Controls.Add(this.btnJettison);
			this.Controls.Add(this.btnDone);
			this.Controls.Add(this.lblBays);
			this.Controls.Add(this.lblBaysLabel);
			this.Controls.Add(this.lblTradeCmdty9);
			this.Controls.Add(this.lblTradeCmdty8);
			this.Controls.Add(this.lblTradeCmdty2);
			this.Controls.Add(this.lblTradeCmdty0);
			this.Controls.Add(this.lblTradeCmdty1);
			this.Controls.Add(this.lblTradeCmdty6);
			this.Controls.Add(this.lblTradeCmdty5);
			this.Controls.Add(this.lblTradeCmdty4);
			this.Controls.Add(this.lblTradeCmdty3);
			this.Controls.Add(this.lblTradeCmdty7);
			this.Controls.Add(this.btnPlunderAll9);
			this.Controls.Add(this.btnPlunderQty9);
			this.Controls.Add(this.btnPlunderAll8);
			this.Controls.Add(this.btnPlunderQty8);
			this.Controls.Add(this.btnPlunderAll7);
			this.Controls.Add(this.btnPlunderQty7);
			this.Controls.Add(this.btnPlunderAll6);
			this.Controls.Add(this.btnPlunderQty6);
			this.Controls.Add(this.btnPlunderAll5);
			this.Controls.Add(this.btnPlunderQty5);
			this.Controls.Add(this.btnPlunderAll4);
			this.Controls.Add(this.btnPlunderQty4);
			this.Controls.Add(this.btnPlunderAll3);
			this.Controls.Add(this.btnPlunderQty3);
			this.Controls.Add(this.btnPlunderAll2);
			this.Controls.Add(this.btnPlunderQty2);
			this.Controls.Add(this.btnPlunderAll1);
			this.Controls.Add(this.btnPlunderQty1);
			this.Controls.Add(this.btnPlunderAll0);
			this.Controls.Add(this.btnPlunderQty0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormPlunder";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Plunder Cargo";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void Plunder(int tradeItem, bool all)
		{
			game.CargoPlunder(tradeItem, all, this);

			UpdateAll();
		}

		private void UpdateAll()
		{
			Ship	ship	= game.Commander.Ship;
			Ship	opp		= game.Opponent;

			for (int i = 0; i < btnPlunderQty.Length; i++)
				btnPlunderQty[i].Text	= opp.Cargo[i].ToString();

			lblBays.Text	= ship.FilledCargoBays.ToString() + "/" + ship.CargoBays.ToString();
		}

		#endregion

		#region Event Handlers

		private void btnJettison_Click(object sender, System.EventArgs e)
		{
			(new FormJettison()).ShowDialog(this);
		}

		#endregion

		#region Properties

		private void btnPlunder_Click(object sender, System.EventArgs e)
		{
			string	name	= ((Button)sender).Name;
			bool		all		= name.IndexOf("Qty") < 0;
			int			index	= int.Parse(name.Substring(name.Length - 1));

			Plunder(index, all);
		}

		#endregion
	}
}
