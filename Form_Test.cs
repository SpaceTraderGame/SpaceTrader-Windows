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
	public class FormTest : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Label lblAlertType;
		private System.Windows.Forms.GroupBox boxAlert;
		private System.Windows.Forms.Label lblValue2;
		private System.Windows.Forms.Label lblValue1;
		private System.Windows.Forms.Label lblValue3;
		private System.Windows.Forms.ComboBox selAlertType;
		private System.Windows.Forms.TextBox txtValue1;
		private System.Windows.Forms.TextBox txtValue2;
		private System.Windows.Forms.TextBox txtValue3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnTestAlert;
		private System.Windows.Forms.Button btnTestSpecialEvent;
		private System.Windows.Forms.ComboBox selSpecialEvent;
		private System.Windows.Forms.Label lblSpecialEvent;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Methods

		public FormTest()
		{
			InitializeComponent();

			for (AlertType type = AlertType.Alert; type <= AlertType.WildWontStayAboardReactor; type++)
				selAlertType.Items.Add(type);
			selAlertType.SelectedIndex	= 0;

			for (SpecialEventType type = SpecialEventType.Artifact; type < SpecialEventType.WildGetsOut; type++)
				selSpecialEvent.Items.Add(type);
			selSpecialEvent.SelectedIndex	= 0;
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
			this.lblAlertType = new System.Windows.Forms.Label();
			this.boxAlert = new System.Windows.Forms.GroupBox();
			this.btnTestAlert = new System.Windows.Forms.Button();
			this.txtValue3 = new System.Windows.Forms.TextBox();
			this.txtValue2 = new System.Windows.Forms.TextBox();
			this.txtValue1 = new System.Windows.Forms.TextBox();
			this.selAlertType = new System.Windows.Forms.ComboBox();
			this.lblValue3 = new System.Windows.Forms.Label();
			this.lblValue1 = new System.Windows.Forms.Label();
			this.lblValue2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnTestSpecialEvent = new System.Windows.Forms.Button();
			this.selSpecialEvent = new System.Windows.Forms.ComboBox();
			this.lblSpecialEvent = new System.Windows.Forms.Label();
			this.boxAlert.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			//
			// lblAlertType
			//
			this.lblAlertType.AutoSize = true;
			this.lblAlertType.Location = new System.Drawing.Point(8, 19);
			this.lblAlertType.Name = "lblAlertType";
			this.lblAlertType.Size = new System.Drawing.Size(56, 13);
			this.lblAlertType.TabIndex = 0;
			this.lblAlertType.Text = "Alert Type";
			//
			// boxAlert
			//
			this.boxAlert.Controls.AddRange(new System.Windows.Forms.Control[] {
																																					 this.btnTestAlert,
																																					 this.txtValue3,
																																					 this.txtValue2,
																																					 this.txtValue1,
																																					 this.selAlertType,
																																					 this.lblValue3,
																																					 this.lblValue1,
																																					 this.lblValue2,
																																					 this.lblAlertType});
			this.boxAlert.Location = new System.Drawing.Point(8, 8);
			this.boxAlert.Name = "boxAlert";
			this.boxAlert.Size = new System.Drawing.Size(200, 152);
			this.boxAlert.TabIndex = 1;
			this.boxAlert.TabStop = false;
			this.boxAlert.Text = "Test Alert";
			//
			// btnTestAlert
			//
			this.btnTestAlert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTestAlert.Location = new System.Drawing.Point(80, 120);
			this.btnTestAlert.Name = "btnTestAlert";
			this.btnTestAlert.Size = new System.Drawing.Size(41, 22);
			this.btnTestAlert.TabIndex = 8;
			this.btnTestAlert.Text = "Test";
			this.btnTestAlert.Click += new System.EventHandler(this.btnTestAlert_Click);
			//
			// txtValue3
			//
			this.txtValue3.Location = new System.Drawing.Point(72, 88);
			this.txtValue3.Name = "txtValue3";
			this.txtValue3.Size = new System.Drawing.Size(120, 20);
			this.txtValue3.TabIndex = 7;
			this.txtValue3.Text = "";
			//
			// txtValue2
			//
			this.txtValue2.Location = new System.Drawing.Point(72, 64);
			this.txtValue2.Name = "txtValue2";
			this.txtValue2.Size = new System.Drawing.Size(120, 20);
			this.txtValue2.TabIndex = 6;
			this.txtValue2.Text = "";
			//
			// txtValue1
			//
			this.txtValue1.Location = new System.Drawing.Point(72, 40);
			this.txtValue1.Name = "txtValue1";
			this.txtValue1.Size = new System.Drawing.Size(120, 20);
			this.txtValue1.TabIndex = 5;
			this.txtValue1.Text = "";
			//
			// selAlertType
			//
			this.selAlertType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.selAlertType.Location = new System.Drawing.Point(72, 16);
			this.selAlertType.Name = "selAlertType";
			this.selAlertType.Size = new System.Drawing.Size(120, 21);
			this.selAlertType.TabIndex = 4;
			//
			// lblValue3
			//
			this.lblValue3.AutoSize = true;
			this.lblValue3.Location = new System.Drawing.Point(8, 91);
			this.lblValue3.Name = "lblValue3";
			this.lblValue3.Size = new System.Drawing.Size(43, 13);
			this.lblValue3.TabIndex = 3;
			this.lblValue3.Text = "Value 3";
			//
			// lblValue1
			//
			this.lblValue1.AutoSize = true;
			this.lblValue1.Location = new System.Drawing.Point(8, 43);
			this.lblValue1.Name = "lblValue1";
			this.lblValue1.Size = new System.Drawing.Size(43, 13);
			this.lblValue1.TabIndex = 2;
			this.lblValue1.Text = "Value 1";
			//
			// lblValue2
			//
			this.lblValue2.AutoSize = true;
			this.lblValue2.Location = new System.Drawing.Point(8, 67);
			this.lblValue2.Name = "lblValue2";
			this.lblValue2.Size = new System.Drawing.Size(43, 13);
			this.lblValue2.TabIndex = 1;
			this.lblValue2.Text = "Value 2";
			//
			// groupBox1
			//
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																																						this.btnTestSpecialEvent,
																																						this.selSpecialEvent,
																																						this.lblSpecialEvent});
			this.groupBox1.Location = new System.Drawing.Point(8, 168);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 80);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Test Special Alert";
			//
			// btnTestSpecialEvent
			//
			this.btnTestSpecialEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTestSpecialEvent.Location = new System.Drawing.Point(80, 48);
			this.btnTestSpecialEvent.Name = "btnTestSpecialEvent";
			this.btnTestSpecialEvent.Size = new System.Drawing.Size(41, 22);
			this.btnTestSpecialEvent.TabIndex = 8;
			this.btnTestSpecialEvent.Text = "Test";
			this.btnTestSpecialEvent.Click += new System.EventHandler(this.btnTestSpecialEvent_Click);
			//
			// selSpecialEvent
			//
			this.selSpecialEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.selSpecialEvent.Location = new System.Drawing.Point(88, 16);
			this.selSpecialEvent.Name = "selSpecialEvent";
			this.selSpecialEvent.Size = new System.Drawing.Size(104, 21);
			this.selSpecialEvent.TabIndex = 4;
			//
			// lblSpecialEvent
			//
			this.lblSpecialEvent.AutoSize = true;
			this.lblSpecialEvent.Location = new System.Drawing.Point(8, 19);
			this.lblSpecialEvent.Name = "lblSpecialEvent";
			this.lblSpecialEvent.Size = new System.Drawing.Size(73, 13);
			this.lblSpecialEvent.TabIndex = 0;
			this.lblSpecialEvent.Text = "Special Event";
			//
			// FormTest
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(370, 255);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.groupBox1,
																																	this.boxAlert});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormTest";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Test";
			this.boxAlert.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion

		#endregion

		#region Event Handlers

		private void btnTestAlert_Click(object sender, System.EventArgs e)
		{
			FormAlert.Alert(AlertType.Alert, this, "Result", "The result was " +
				FormAlert.Alert((AlertType)selAlertType.SelectedItem,
				this, txtValue1.Text, txtValue2.Text, txtValue3.Text).ToString());
		}

		private void btnTestSpecialEvent_Click(object sender, System.EventArgs e)
		{
			SpecialEvent	specEvent	= Consts.SpecialEvents[(int)selSpecialEvent.SelectedItem];
			string				btn1, btn2;
			DialogResult	res1, res2;

			if (specEvent.MessageOnly)
			{
				btn1	= "Ok";
				btn2	= null;
				res1	= DialogResult.OK;
				res2	= DialogResult.None;
			}
			else
			{
				btn1	= "Yes";
				btn2	= "No";
				res1	= DialogResult.Yes;
				res2	= DialogResult.No;
			}

			(new FormAlert(specEvent.Title, specEvent.String, btn1, res1, btn2, res2, null)).ShowDialog(this);
		}

		#endregion
	}
}
