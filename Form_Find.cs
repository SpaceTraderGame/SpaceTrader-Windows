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
	public class FormFind : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Label lblText;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtSystem;
		private System.Windows.Forms.CheckBox chkTrack;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Member Declarations

		private static string	text				= "";
		private static bool		boxChecked	= false;

		#endregion

		#region Methods

		public FormFind()
		{
			InitializeComponent();

			txtSystem.Text		= text;
			chkTrack.Checked	= boxChecked;
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
			this.lblText = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.txtSystem = new System.Windows.Forms.TextBox();
			this.chkTrack = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			//
			// lblText
			//
			this.lblText.AutoSize = true;
			this.lblText.Location = new System.Drawing.Point(8, 8);
			this.lblText.Name = "lblText";
			this.lblText.Size = new System.Drawing.Size(177, 13);
			this.lblText.TabIndex = 3;
			this.lblText.Text = "Which system are you looking for?";
			//
			// btnOk
			//
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOk.Location = new System.Drawing.Point(43, 68);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(40, 22);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "Ok";
			//
			// btnCancel
			//
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(91, 68);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(50, 22);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			//
			// txtSystem
			//
			this.txtSystem.Location = new System.Drawing.Point(8, 24);
			this.txtSystem.Name = "txtSystem";
			this.txtSystem.Size = new System.Drawing.Size(168, 20);
			this.txtSystem.TabIndex = 1;
			this.txtSystem.Text = "";
			//
			// chkTrack
			//
			this.chkTrack.Location = new System.Drawing.Point(8, 48);
			this.chkTrack.Name = "chkTrack";
			this.chkTrack.Size = new System.Drawing.Size(112, 16);
			this.chkTrack.TabIndex = 2;
			this.chkTrack.Text = "Track this system";
			//
			// FormFind
			//
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(184, 97);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.chkTrack,
																																	this.txtSystem,
																																	this.btnCancel,
																																	this.btnOk,
																																	this.lblText});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormFind";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Find System";
			this.Closed += new System.EventHandler(this.FormFind_Closed);
			this.ResumeLayout(false);
		}
		#endregion

		#endregion

		#region Event Handlers

		private void FormFind_Closed(object sender, System.EventArgs e)
		{
			text				= txtSystem.Text;
			boxChecked	= chkTrack.Checked;
		}

		#endregion

		#region Properties

		public string SystemName
		{
			get
			{
				return txtSystem.Text;
			}
		}

		public bool TrackSystem
		{
			get
			{
				return chkTrack.Checked;
			}
		}

		#endregion
	}
}
