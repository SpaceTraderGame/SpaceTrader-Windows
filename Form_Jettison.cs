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
	public class FormJettison : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnJettisonAll9;
		private System.Windows.Forms.Button btnJettisonQty9;
		private System.Windows.Forms.Button btnJettisonAll8;
		private System.Windows.Forms.Button btnJettisonQty8;
		private System.Windows.Forms.Button btnJettisonAll7;
		private System.Windows.Forms.Button btnJettisonQty7;
		private System.Windows.Forms.Button btnJettisonAll6;
		private System.Windows.Forms.Button btnJettisonQty6;
		private System.Windows.Forms.Button btnJettisonAll5;
		private System.Windows.Forms.Button btnJettisonQty5;
		private System.Windows.Forms.Button btnJettisonAll4;
		private System.Windows.Forms.Button btnJettisonQty4;
		private System.Windows.Forms.Button btnJettisonAll3;
		private System.Windows.Forms.Button btnJettisonQty3;
		private System.Windows.Forms.Button btnJettisonAll2;
		private System.Windows.Forms.Button btnJettisonQty2;
		private System.Windows.Forms.Button btnJettisonAll1;
		private System.Windows.Forms.Button btnJettisonQty1;
		private System.Windows.Forms.Button btnJettisonAll0;
		private System.Windows.Forms.Button btnJettisonQty0;
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
		private System.ComponentModel.Container components = null;

		private Button[]	btnJettisonQty;
		private Button[]	btnJettisonAll;

		#endregion

		#region Member Declarations

		private Game			game	= Game.CurrentGame;

		#endregion

		#region Methods

		public FormJettison()
		{
			InitializeComponent();

			#region Arrays of Cargo controls
			btnJettisonQty	= new Button[]
			{
				btnJettisonQty0,
				btnJettisonQty1,
				btnJettisonQty2,
				btnJettisonQty3,
				btnJettisonQty4,
				btnJettisonQty5,
				btnJettisonQty6,
				btnJettisonQty7,
				btnJettisonQty8,
				btnJettisonQty9
			};

			btnJettisonAll	= new Button[]
			{
				btnJettisonAll0,
				btnJettisonAll1,
				btnJettisonAll2,
				btnJettisonAll3,
				btnJettisonAll4,
				btnJettisonAll5,
				btnJettisonAll6,
				btnJettisonAll7,
				btnJettisonAll8,
				btnJettisonAll9
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
			this.btnJettisonAll9 = new System.Windows.Forms.Button();
			this.btnJettisonQty9 = new System.Windows.Forms.Button();
			this.btnJettisonAll8 = new System.Windows.Forms.Button();
			this.btnJettisonQty8 = new System.Windows.Forms.Button();
			this.btnJettisonAll7 = new System.Windows.Forms.Button();
			this.btnJettisonQty7 = new System.Windows.Forms.Button();
			this.btnJettisonAll6 = new System.Windows.Forms.Button();
			this.btnJettisonQty6 = new System.Windows.Forms.Button();
			this.btnJettisonAll5 = new System.Windows.Forms.Button();
			this.btnJettisonQty5 = new System.Windows.Forms.Button();
			this.btnJettisonAll4 = new System.Windows.Forms.Button();
			this.btnJettisonQty4 = new System.Windows.Forms.Button();
			this.btnJettisonAll3 = new System.Windows.Forms.Button();
			this.btnJettisonQty3 = new System.Windows.Forms.Button();
			this.btnJettisonAll2 = new System.Windows.Forms.Button();
			this.btnJettisonQty2 = new System.Windows.Forms.Button();
			this.btnJettisonAll1 = new System.Windows.Forms.Button();
			this.btnJettisonQty1 = new System.Windows.Forms.Button();
			this.btnJettisonAll0 = new System.Windows.Forms.Button();
			this.btnJettisonQty0 = new System.Windows.Forms.Button();
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
			this.SuspendLayout();
			//
			// btnJettisonAll9
			//
			this.btnJettisonAll9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonAll9.Location = new System.Drawing.Point(100, 220);
			this.btnJettisonAll9.Name = "btnJettisonAll9";
			this.btnJettisonAll9.Size = new System.Drawing.Size(32, 22);
			this.btnJettisonAll9.TabIndex = 141;
			this.btnJettisonAll9.Text = "All";
			this.btnJettisonAll9.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonQty9
			//
			this.btnJettisonQty9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonQty9.Location = new System.Drawing.Point(68, 220);
			this.btnJettisonQty9.Name = "btnJettisonQty9";
			this.btnJettisonQty9.Size = new System.Drawing.Size(28, 22);
			this.btnJettisonQty9.TabIndex = 140;
			this.btnJettisonQty9.Text = "88";
			this.btnJettisonQty9.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonAll8
			//
			this.btnJettisonAll8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonAll8.Location = new System.Drawing.Point(100, 196);
			this.btnJettisonAll8.Name = "btnJettisonAll8";
			this.btnJettisonAll8.Size = new System.Drawing.Size(32, 22);
			this.btnJettisonAll8.TabIndex = 139;
			this.btnJettisonAll8.Text = "All";
			this.btnJettisonAll8.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonQty8
			//
			this.btnJettisonQty8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonQty8.Location = new System.Drawing.Point(68, 196);
			this.btnJettisonQty8.Name = "btnJettisonQty8";
			this.btnJettisonQty8.Size = new System.Drawing.Size(28, 22);
			this.btnJettisonQty8.TabIndex = 138;
			this.btnJettisonQty8.Text = "88";
			this.btnJettisonQty8.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonAll7
			//
			this.btnJettisonAll7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonAll7.Location = new System.Drawing.Point(100, 172);
			this.btnJettisonAll7.Name = "btnJettisonAll7";
			this.btnJettisonAll7.Size = new System.Drawing.Size(32, 22);
			this.btnJettisonAll7.TabIndex = 137;
			this.btnJettisonAll7.Text = "All";
			this.btnJettisonAll7.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonQty7
			//
			this.btnJettisonQty7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonQty7.Location = new System.Drawing.Point(68, 172);
			this.btnJettisonQty7.Name = "btnJettisonQty7";
			this.btnJettisonQty7.Size = new System.Drawing.Size(28, 22);
			this.btnJettisonQty7.TabIndex = 136;
			this.btnJettisonQty7.Text = "88";
			this.btnJettisonQty7.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonAll6
			//
			this.btnJettisonAll6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonAll6.Location = new System.Drawing.Point(100, 148);
			this.btnJettisonAll6.Name = "btnJettisonAll6";
			this.btnJettisonAll6.Size = new System.Drawing.Size(32, 22);
			this.btnJettisonAll6.TabIndex = 135;
			this.btnJettisonAll6.Text = "All";
			this.btnJettisonAll6.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonQty6
			//
			this.btnJettisonQty6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonQty6.Location = new System.Drawing.Point(68, 148);
			this.btnJettisonQty6.Name = "btnJettisonQty6";
			this.btnJettisonQty6.Size = new System.Drawing.Size(28, 22);
			this.btnJettisonQty6.TabIndex = 134;
			this.btnJettisonQty6.Text = "88";
			this.btnJettisonQty6.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonAll5
			//
			this.btnJettisonAll5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonAll5.Location = new System.Drawing.Point(100, 124);
			this.btnJettisonAll5.Name = "btnJettisonAll5";
			this.btnJettisonAll5.Size = new System.Drawing.Size(32, 22);
			this.btnJettisonAll5.TabIndex = 133;
			this.btnJettisonAll5.Text = "All";
			this.btnJettisonAll5.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonQty5
			//
			this.btnJettisonQty5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonQty5.Location = new System.Drawing.Point(68, 124);
			this.btnJettisonQty5.Name = "btnJettisonQty5";
			this.btnJettisonQty5.Size = new System.Drawing.Size(28, 22);
			this.btnJettisonQty5.TabIndex = 132;
			this.btnJettisonQty5.Text = "88";
			this.btnJettisonQty5.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonAll4
			//
			this.btnJettisonAll4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonAll4.Location = new System.Drawing.Point(100, 100);
			this.btnJettisonAll4.Name = "btnJettisonAll4";
			this.btnJettisonAll4.Size = new System.Drawing.Size(32, 22);
			this.btnJettisonAll4.TabIndex = 131;
			this.btnJettisonAll4.Text = "All";
			this.btnJettisonAll4.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonQty4
			//
			this.btnJettisonQty4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonQty4.Location = new System.Drawing.Point(68, 100);
			this.btnJettisonQty4.Name = "btnJettisonQty4";
			this.btnJettisonQty4.Size = new System.Drawing.Size(28, 22);
			this.btnJettisonQty4.TabIndex = 130;
			this.btnJettisonQty4.Text = "88";
			this.btnJettisonQty4.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonAll3
			//
			this.btnJettisonAll3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonAll3.Location = new System.Drawing.Point(100, 76);
			this.btnJettisonAll3.Name = "btnJettisonAll3";
			this.btnJettisonAll3.Size = new System.Drawing.Size(32, 22);
			this.btnJettisonAll3.TabIndex = 129;
			this.btnJettisonAll3.Text = "All";
			this.btnJettisonAll3.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonQty3
			//
			this.btnJettisonQty3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonQty3.Location = new System.Drawing.Point(68, 76);
			this.btnJettisonQty3.Name = "btnJettisonQty3";
			this.btnJettisonQty3.Size = new System.Drawing.Size(28, 22);
			this.btnJettisonQty3.TabIndex = 128;
			this.btnJettisonQty3.Text = "88";
			this.btnJettisonQty3.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonAll2
			//
			this.btnJettisonAll2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonAll2.Location = new System.Drawing.Point(100, 52);
			this.btnJettisonAll2.Name = "btnJettisonAll2";
			this.btnJettisonAll2.Size = new System.Drawing.Size(32, 22);
			this.btnJettisonAll2.TabIndex = 127;
			this.btnJettisonAll2.Text = "All";
			this.btnJettisonAll2.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonQty2
			//
			this.btnJettisonQty2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonQty2.Location = new System.Drawing.Point(68, 52);
			this.btnJettisonQty2.Name = "btnJettisonQty2";
			this.btnJettisonQty2.Size = new System.Drawing.Size(28, 22);
			this.btnJettisonQty2.TabIndex = 126;
			this.btnJettisonQty2.Text = "88";
			this.btnJettisonQty2.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonAll1
			//
			this.btnJettisonAll1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonAll1.Location = new System.Drawing.Point(100, 28);
			this.btnJettisonAll1.Name = "btnJettisonAll1";
			this.btnJettisonAll1.Size = new System.Drawing.Size(32, 22);
			this.btnJettisonAll1.TabIndex = 125;
			this.btnJettisonAll1.Text = "All";
			this.btnJettisonAll1.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonQty1
			//
			this.btnJettisonQty1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonQty1.Location = new System.Drawing.Point(68, 28);
			this.btnJettisonQty1.Name = "btnJettisonQty1";
			this.btnJettisonQty1.Size = new System.Drawing.Size(28, 22);
			this.btnJettisonQty1.TabIndex = 124;
			this.btnJettisonQty1.Text = "88";
			this.btnJettisonQty1.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonAll0
			//
			this.btnJettisonAll0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonAll0.Location = new System.Drawing.Point(100, 4);
			this.btnJettisonAll0.Name = "btnJettisonAll0";
			this.btnJettisonAll0.Size = new System.Drawing.Size(32, 22);
			this.btnJettisonAll0.TabIndex = 123;
			this.btnJettisonAll0.Text = "All";
			this.btnJettisonAll0.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// btnJettisonQty0
			//
			this.btnJettisonQty0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJettisonQty0.Location = new System.Drawing.Point(68, 4);
			this.btnJettisonQty0.Name = "btnJettisonQty0";
			this.btnJettisonQty0.Size = new System.Drawing.Size(28, 22);
			this.btnJettisonQty0.TabIndex = 122;
			this.btnJettisonQty0.Text = "88";
			this.btnJettisonQty0.Click += new System.EventHandler(this.btnJettison_Click);
			//
			// lblTradeCmdty9
			//
			this.lblTradeCmdty9.AutoSize = true;
			this.lblTradeCmdty9.Location = new System.Drawing.Point(8, 224);
			this.lblTradeCmdty9.Name = "lblTradeCmdty9";
			this.lblTradeCmdty9.Size = new System.Drawing.Size(40, 13);
			this.lblTradeCmdty9.TabIndex = 151;
			this.lblTradeCmdty9.Text = "Robots";
			//
			// lblTradeCmdty8
			//
			this.lblTradeCmdty8.AutoSize = true;
			this.lblTradeCmdty8.Location = new System.Drawing.Point(8, 200);
			this.lblTradeCmdty8.Name = "lblTradeCmdty8";
			this.lblTradeCmdty8.Size = new System.Drawing.Size(51, 13);
			this.lblTradeCmdty8.TabIndex = 150;
			this.lblTradeCmdty8.Text = "Narcotics";
			//
			// lblTradeCmdty2
			//
			this.lblTradeCmdty2.AutoSize = true;
			this.lblTradeCmdty2.Location = new System.Drawing.Point(8, 56);
			this.lblTradeCmdty2.Name = "lblTradeCmdty2";
			this.lblTradeCmdty2.Size = new System.Drawing.Size(30, 13);
			this.lblTradeCmdty2.TabIndex = 149;
			this.lblTradeCmdty2.Text = "Food";
			//
			// lblTradeCmdty0
			//
			this.lblTradeCmdty0.AutoSize = true;
			this.lblTradeCmdty0.Location = new System.Drawing.Point(8, 8);
			this.lblTradeCmdty0.Name = "lblTradeCmdty0";
			this.lblTradeCmdty0.Size = new System.Drawing.Size(34, 13);
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
			this.lblTradeCmdty5.Size = new System.Drawing.Size(49, 13);
			this.lblTradeCmdty5.TabIndex = 145;
			this.lblTradeCmdty5.Text = "Firearms";
			//
			// lblTradeCmdty4
			//
			this.lblTradeCmdty4.AutoSize = true;
			this.lblTradeCmdty4.Location = new System.Drawing.Point(8, 104);
			this.lblTradeCmdty4.Name = "lblTradeCmdty4";
			this.lblTradeCmdty4.Size = new System.Drawing.Size(41, 13);
			this.lblTradeCmdty4.TabIndex = 144;
			this.lblTradeCmdty4.Text = "Games";
			//
			// lblTradeCmdty3
			//
			this.lblTradeCmdty3.AutoSize = true;
			this.lblTradeCmdty3.Location = new System.Drawing.Point(8, 80);
			this.lblTradeCmdty3.Name = "lblTradeCmdty3";
			this.lblTradeCmdty3.Size = new System.Drawing.Size(23, 13);
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
			this.lblBays.Size = new System.Drawing.Size(33, 13);
			this.lblBays.TabIndex = 153;
			this.lblBays.Text = "88/88";
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
			// FormJettison
			//
			this.AcceptButton = this.btnDone;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnDone;
			this.ClientSize = new System.Drawing.Size(218, 283);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.btnDone,
																																	this.lblBays,
																																	this.lblBaysLabel,
																																	this.lblTradeCmdty9,
																																	this.lblTradeCmdty8,
																																	this.lblTradeCmdty2,
																																	this.lblTradeCmdty0,
																																	this.lblTradeCmdty1,
																																	this.lblTradeCmdty6,
																																	this.lblTradeCmdty5,
																																	this.lblTradeCmdty4,
																																	this.lblTradeCmdty3,
																																	this.lblTradeCmdty7,
																																	this.btnJettisonAll9,
																																	this.btnJettisonQty9,
																																	this.btnJettisonAll8,
																																	this.btnJettisonQty8,
																																	this.btnJettisonAll7,
																																	this.btnJettisonQty7,
																																	this.btnJettisonAll6,
																																	this.btnJettisonQty6,
																																	this.btnJettisonAll5,
																																	this.btnJettisonQty5,
																																	this.btnJettisonAll4,
																																	this.btnJettisonQty4,
																																	this.btnJettisonAll3,
																																	this.btnJettisonQty3,
																																	this.btnJettisonAll2,
																																	this.btnJettisonQty2,
																																	this.btnJettisonAll1,
																																	this.btnJettisonQty1,
																																	this.btnJettisonAll0,
																																	this.btnJettisonQty0});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormJettison";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Jettison Cargo";
			this.ResumeLayout(false);
		}
		#endregion

		private void Jettison(int tradeItem, bool all)
		{
			game.CargoJettison(tradeItem, all, this);
			UpdateAll();
		}

		private void UpdateAll()
		{
			Ship	ship	= game.Commander.Ship;

			for (int i = 0; i < btnJettisonQty.Length; i++)
				btnJettisonQty[i].Text	= ship.Cargo[i].ToString();

			lblBays.Text	= ship.FilledCargoBays.ToString() + "/" + ship.CargoBays.ToString();
		}

		#endregion

		#region Event Handlers

		private void btnJettison_Click(object sender, System.EventArgs e)
		{
			string	name	= ((Button)sender).Name;
			bool		all		= name.IndexOf("Qty") < 0;
			int			index	= int.Parse(name.Substring(name.Length - 1));

			Jettison(index, all);
		}

		#endregion
	}
}
