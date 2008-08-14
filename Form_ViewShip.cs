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
	public class FormViewShip : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblTypeLabel;
		private System.Windows.Forms.Label lblType;
		private System.Windows.Forms.GroupBox boxSpecialCargo;
		private System.Windows.Forms.Label lblSpecialCargo;
		private System.Windows.Forms.Label lblEquipLabel;
		private System.Windows.Forms.Label lblEquip;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Member Declarations

		private Game	game	= Game.CurrentGame;
		private Ship	ship	= Game.CurrentGame.Commander.Ship;

		#endregion

		#region Methods

		public FormViewShip()
		{
			InitializeComponent();

			lblType.Text				= ship.Name;
			lblEquipLabel.Text	= "";
			lblEquip.Text				= "";

			DisplayEquipment();
			DisplaySpecialCargo();
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
			this.lblTypeLabel = new System.Windows.Forms.Label();
			this.lblType = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblEquipLabel = new System.Windows.Forms.Label();
			this.lblEquip = new System.Windows.Forms.Label();
			this.boxSpecialCargo = new System.Windows.Forms.GroupBox();
			this.lblSpecialCargo = new System.Windows.Forms.Label();
			this.boxSpecialCargo.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTypeLabel
			// 
			this.lblTypeLabel.AutoSize = true;
			this.lblTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTypeLabel.Location = new System.Drawing.Point(8, 8);
			this.lblTypeLabel.Name = "lblTypeLabel";
			this.lblTypeLabel.Size = new System.Drawing.Size(34, 13);
			this.lblTypeLabel.TabIndex = 2;
			this.lblTypeLabel.Text = "Type:";
			// 
			// lblType
			// 
			this.lblType.Location = new System.Drawing.Point(80, 8);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(100, 13);
			this.lblType.TabIndex = 4;
			this.lblType.Text = "Grasshopper";
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
			// lblEquipLabel
			// 
			this.lblEquipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblEquipLabel.Location = new System.Drawing.Point(8, 34);
			this.lblEquipLabel.Name = "lblEquipLabel";
			this.lblEquipLabel.Size = new System.Drawing.Size(64, 176);
			this.lblEquipLabel.TabIndex = 43;
			this.lblEquipLabel.Text = "Hull:\r\n\r\nEquipment:\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nUnfilled:";
			// 
			// lblEquip
			// 
			this.lblEquip.Location = new System.Drawing.Point(80, 34);
			this.lblEquip.Name = "lblEquip";
			this.lblEquip.Size = new System.Drawing.Size(120, 176);
			this.lblEquip.TabIndex = 44;
			this.lblEquip.Text = "Hardened\r\n\r\n1 Military Laser\r\n1 Morgan\'s Laser\r\n1 Energy Shield\r\n1 Reflective Shi" +
				"eld\r\n1 Lightning Shield\r\nNavigating System\r\nAuto-Repair System\r\n10 Extra Cargo Bays\r\nAn Escape Pod\r\n" +
				"\r\n1 weapon slot\r\n1 gadget slot";
			// 
			// boxSpecialCargo
			// 
			this.boxSpecialCargo.Controls.AddRange(new System.Windows.Forms.Control[] {
																																									this.lblSpecialCargo});
			this.boxSpecialCargo.Location = new System.Drawing.Point(192, 8);
			this.boxSpecialCargo.Name = "boxSpecialCargo";
			this.boxSpecialCargo.Size = new System.Drawing.Size(200, 204);
			this.boxSpecialCargo.TabIndex = 64;
			this.boxSpecialCargo.TabStop = false;
			this.boxSpecialCargo.Text = "Special Cargo";
			// 
			// lblSpecialCargo
			// 
			this.lblSpecialCargo.Location = new System.Drawing.Point(8, 16);
			this.lblSpecialCargo.Name = "lblSpecialCargo";
			this.lblSpecialCargo.Size = new System.Drawing.Size(190, 176);
			this.lblSpecialCargo.TabIndex = 0;
			this.lblSpecialCargo.Text = "No special items.";
			// 
			// FormViewShip
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(402, 219);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.boxSpecialCargo,
																																	this.lblEquip,
																																	this.lblEquipLabel,
																																	this.btnClose,
																																	this.lblTypeLabel,
																																	this.lblType});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormViewShip";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Current Ship";
			this.boxSpecialCargo.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void DisplayEquipment()
		{
			if (game.QuestStatusScarab == SpecialEvent.StatusScarabDone)
			{
				lblEquipLabel.Text	+= "Hull:" + Environment.NewLine + Environment.NewLine;
				lblEquip.Text				+= "Hardened" + Environment.NewLine + Environment.NewLine;
			}

			bool	equipPrinted	= false;

			for (int i = 0; i < Consts.Weapons.Length; i++)
			{
				int count	= 0;
				for (int j = 0; j < ship.Weapons.Length; j++)
				{
					if (ship.Weapons[j] != null && ship.Weapons[j].Type == Consts.Weapons[i].Type)
						count++;
				}
				if (count > 0)
				{
					lblEquipLabel.Text	+= equipPrinted ? Environment.NewLine : "Equipment:" + Environment.NewLine;
					lblEquip.Text				+= Functions.Multiples(count, Consts.Weapons[i].Name) + Environment.NewLine;
					equipPrinted				= true;
				}
			}

			for (int i = 0; i < Consts.Shields.Length; i++)
			{
				int count	= 0;
				for (int j = 0; j < ship.Shields.Length; j++)
				{
					if (ship.Shields[j] != null && ship.Shields[j].Type == Consts.Shields[i].Type)
						count++;
				}
				if (count > 0)
				{
					lblEquipLabel.Text	+= equipPrinted ? Environment.NewLine : "Equipment:" + Environment.NewLine;
					lblEquip.Text				+= Functions.Multiples(count, Consts.Shields[i].Name) + Environment.NewLine;
					equipPrinted				= true;
				}
			}

			for (int i = 0; i < Consts.Gadgets.Length; i++)
			{
				int count	= 0;
				for (int j = 0; j < ship.Gadgets.Length; j++)
				{
					if (ship.Gadgets[j] != null && ship.Gadgets[j].Type == Consts.Gadgets[i].Type)
						count++;
				}
				if (count > 0)
				{
					lblEquipLabel.Text	+= equipPrinted ? Environment.NewLine : "Equipment:" + Environment.NewLine;

					if (i == (int)GadgetType.ExtraCargoBays || i == (int)GadgetType.HiddenCargoBays)
					{
						count	*= 5;
						lblEquip.Text			+= Functions.FormatNumber(count) + Consts.Gadgets[i].Name.Substring(1) + Environment.NewLine;
					}
					else
						lblEquip.Text			+= Functions.Multiples(count, Consts.Gadgets[i].Name) + Environment.NewLine;

					equipPrinted				= true;
				}
			}

			if (ship.EscapePod)
			{
				lblEquipLabel.Text	+= equipPrinted ? Environment.NewLine : "Equipment:" + Environment.NewLine;
				lblEquip.Text				+= "1 " + Strings.ShipInfoEscapePod + Environment.NewLine;
				equipPrinted				= true;
			}

			if (ship.FreeSlots > 0)
			{
				lblEquipLabel.Text	+= (equipPrinted ? Environment.NewLine : "") + "Unfilled:";
				lblEquip.Text				+= (equipPrinted ? Environment.NewLine : "");

				if (ship.FreeSlotsWeapon > 0)
					lblEquip.Text				+= Functions.Multiples(ship.FreeSlotsWeapon, "weapon slot") + Environment.NewLine;

				if (ship.FreeSlotsShield > 0)
					lblEquip.Text				+= Functions.Multiples(ship.FreeSlotsShield, "shield slot") + Environment.NewLine;

				if (ship.FreeSlotsGadget > 0)
					lblEquip.Text				+= Functions.Multiples(ship.FreeSlotsGadget, "gadget slot") + Environment.NewLine;
			}
		}

		private void DisplaySpecialCargo()
		{
			ArrayList	specialCargo	= new ArrayList(12);

			if (ship.Tribbles > 0)
			{
				if (ship.Tribbles == Consts.MaxTribbles)
					specialCargo.Add(Strings.SpecialCargoTribblesInfest);
				else
					specialCargo.Add(Functions.Multiples(ship.Tribbles, Strings.SpecialCargoTribblesCute) + ".");
			}

			if (game.QuestStatusJapori == SpecialEvent.StatusJaporiInTransit)
				specialCargo.Add(Strings.SpecialCargoJapori);

			if (ship.ArtifactOnBoard)
				specialCargo.Add(Strings.SpecialCargoArtifact);

			if (game.QuestStatusJarek == SpecialEvent.StatusJarekDone)
				specialCargo.Add(Strings.SpecialCargoJarek);

			if (ship.ReactorOnBoard)
			{
				specialCargo.Add(Strings.SpecialCargoReactor);
				specialCargo.Add(Functions.Multiples(10 - ((game.QuestStatusReactor - 1) / 2), "bay") +
					Strings.SpecialCargoReactorBays);
			}

			if (ship.SculptureOnBoard)
				specialCargo.Add(Strings.SpecialCargoSculpture);

			if (game.CanSuperWarp)
				specialCargo.Add(Strings.SpecialCargoExperiment);

			lblSpecialCargo.Text	= specialCargo.Count == 0 ? Strings.SpecialCargoNone :
															String.Join(Environment.NewLine + Environment.NewLine, Functions.ArrayListToStringArray(specialCargo));
		}

		#endregion
	}
}
