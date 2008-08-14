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
	public class FormCosts : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblMerc;
		private System.Windows.Forms.Label lblIns;
		private System.Windows.Forms.Label lblInt;
		private System.Windows.Forms.Label lblTax;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label lblTotalLabel;
		private System.Windows.Forms.Label lblTaxLabel;
		private System.Windows.Forms.Label lblIntLabel;
		private System.Windows.Forms.Label lblMercLabel;
		private System.Windows.Forms.Label lblInsLabel;
		private System.Windows.Forms.PictureBox picLine;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Member Declarations

		private Game	game	= Game.CurrentGame;

		#endregion

		#region Methods

		public FormCosts()
		{
			InitializeComponent();

			lblMerc.Text	= Functions.FormatMoney(game.MercenaryCosts);
			lblIns.Text		= Functions.FormatMoney(game.InsuranceCosts);
			lblInt.Text		= Functions.FormatMoney(game.InterestCosts);
			lblTax.Text		= Functions.FormatMoney(game.WormholeCosts);
			lblTotal.Text	= Functions.FormatMoney(game.CurrentCosts);
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
			this.lblMerc = new System.Windows.Forms.Label();
			this.lblIns = new System.Windows.Forms.Label();
			this.lblInt = new System.Windows.Forms.Label();
			this.lblTax = new System.Windows.Forms.Label();
			this.lblTotal = new System.Windows.Forms.Label();
			this.lblTotalLabel = new System.Windows.Forms.Label();
			this.lblTaxLabel = new System.Windows.Forms.Label();
			this.lblIntLabel = new System.Windows.Forms.Label();
			this.lblMercLabel = new System.Windows.Forms.Label();
			this.lblInsLabel = new System.Windows.Forms.Label();
			this.picLine = new System.Windows.Forms.PictureBox();
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
			// lblMerc
			//
			this.lblMerc.Location = new System.Drawing.Point(104, 8);
			this.lblMerc.Name = "lblMerc";
			this.lblMerc.Size = new System.Drawing.Size(39, 13);
			this.lblMerc.TabIndex = 36;
			this.lblMerc.Text = "888 cr.";
			this.lblMerc.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblIns
			//
			this.lblIns.Location = new System.Drawing.Point(104, 24);
			this.lblIns.Name = "lblIns";
			this.lblIns.Size = new System.Drawing.Size(39, 13);
			this.lblIns.TabIndex = 40;
			this.lblIns.Text = "888 cr.";
			this.lblIns.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblInt
			//
			this.lblInt.Location = new System.Drawing.Point(104, 40);
			this.lblInt.Name = "lblInt";
			this.lblInt.Size = new System.Drawing.Size(39, 13);
			this.lblInt.TabIndex = 44;
			this.lblInt.Text = "888 cr.";
			this.lblInt.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblTax
			//
			this.lblTax.Location = new System.Drawing.Point(104, 56);
			this.lblTax.Name = "lblTax";
			this.lblTax.Size = new System.Drawing.Size(39, 13);
			this.lblTax.TabIndex = 48;
			this.lblTax.Text = "888 cr.";
			this.lblTax.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblTotal
			//
			this.lblTotal.Location = new System.Drawing.Point(104, 79);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.Size = new System.Drawing.Size(39, 13);
			this.lblTotal.TabIndex = 52;
			this.lblTotal.Text = "888 cr.";
			this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
			//
			// lblTotalLabel
			//
			this.lblTotalLabel.AutoSize = true;
			this.lblTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTotalLabel.Location = new System.Drawing.Point(8, 79);
			this.lblTotalLabel.Name = "lblTotalLabel";
			this.lblTotalLabel.Size = new System.Drawing.Size(34, 13);
			this.lblTotalLabel.TabIndex = 7;
			this.lblTotalLabel.Text = "Total:";
			//
			// lblTaxLabel
			//
			this.lblTaxLabel.AutoSize = true;
			this.lblTaxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTaxLabel.Location = new System.Drawing.Point(8, 56);
			this.lblTaxLabel.Name = "lblTaxLabel";
			this.lblTaxLabel.Size = new System.Drawing.Size(84, 13);
			this.lblTaxLabel.TabIndex = 6;
			this.lblTaxLabel.Text = "Wormhole Tax:";
			//
			// lblIntLabel
			//
			this.lblIntLabel.AutoSize = true;
			this.lblIntLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblIntLabel.Location = new System.Drawing.Point(8, 40);
			this.lblIntLabel.Name = "lblIntLabel";
			this.lblIntLabel.Size = new System.Drawing.Size(47, 13);
			this.lblIntLabel.TabIndex = 5;
			this.lblIntLabel.Text = "Interest:";
			//
			// lblMercLabel
			//
			this.lblMercLabel.AutoSize = true;
			this.lblMercLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMercLabel.Location = new System.Drawing.Point(8, 8);
			this.lblMercLabel.Name = "lblMercLabel";
			this.lblMercLabel.Size = new System.Drawing.Size(72, 13);
			this.lblMercLabel.TabIndex = 4;
			this.lblMercLabel.Text = "Mercenaries:";
			//
			// lblInsLabel
			//
			this.lblInsLabel.AutoSize = true;
			this.lblInsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblInsLabel.Location = new System.Drawing.Point(8, 24);
			this.lblInsLabel.Name = "lblInsLabel";
			this.lblInsLabel.Size = new System.Drawing.Size(59, 13);
			this.lblInsLabel.TabIndex = 3;
			this.lblInsLabel.Text = "Insurance:";
			//
			// picLine
			//
			this.picLine.BackColor = System.Drawing.Color.DimGray;
			this.picLine.Location = new System.Drawing.Point(6, 73);
			this.picLine.Name = "picLine";
			this.picLine.Size = new System.Drawing.Size(138, 1);
			this.picLine.TabIndex = 134;
			this.picLine.TabStop = false;
			//
			// FormCosts
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(148, 99);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.picLine,
																																	this.lblTotal,
																																	this.lblTax,
																																	this.lblInt,
																																	this.lblIns,
																																	this.lblMerc,
																																	this.btnClose,
																																	this.lblInsLabel,
																																	this.lblTotalLabel,
																																	this.lblTaxLabel,
																																	this.lblIntLabel,
																																	this.lblMercLabel});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormCosts";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cost Specification";
			this.ResumeLayout(false);
		}
		#endregion

		#endregion
	}
}
