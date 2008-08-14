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
	public class FormViewQuests : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.LinkLabel lblQuests;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Methods

		public FormViewQuests()
		{
			InitializeComponent();

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
			this.btnClose = new System.Windows.Forms.Button();
			this.lblQuests = new System.Windows.Forms.LinkLabel();
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
			// lblQuests
			//
			this.lblQuests.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
			this.lblQuests.Location = new System.Drawing.Point(8, 8);
			this.lblQuests.Name = "lblQuests";
			this.lblQuests.Size = new System.Drawing.Size(368, 312);
			this.lblQuests.TabIndex = 44;
			this.lblQuests.Text = @"Kill the space monster at Acamar.

Get your lightning shield at Zalkon.

Deliver antidote to Japori.

Deliver the alien artifact to Professor Berger at some hi-tech system.

Bring ambassador Jarek to Devidia.  Jarek is wondering why the journey is taking so long, and is no longer of much help in negotiating trades.

Inform Gemulon about alien invasion within 8 days.

Stop Dr. Fehler's experiment at Daled within 8 days.

Deliver the unstable reactor to Nix before it consumes all its fuel.

Find and destroy the Scarab (which is hiding at the exit to a wormhole).

Smuggle Jonathan Wild to Kravat.  Wild is getting impatient, and will no longer aid your crew along the way.

Get rid of those pesky tribbles.

Claim your moon at Utopia.";
			this.lblQuests.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblQuests_LinkClicked);
			//
			// FormViewQuests
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(378, 325);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.btnClose,
																																	this.lblQuests});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormViewQuests";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Quests";
			this.ResumeLayout(false);
		}
		#endregion

		private string[] GetQuestStrings()
		{
			Game			game		= Game.CurrentGame;
			ArrayList	quests	= new ArrayList(12);

			if (game.QuestStatusGemulon > SpecialEvent.StatusGemulonNotStarted &&
				game.QuestStatusGemulon < SpecialEvent.StatusGemulonDate)
			{
				if (game.QuestStatusGemulon == SpecialEvent.StatusGemulonDate - 1)
					quests.Add(Strings.QuestGemulonInformTomorrow);
				else
					quests.Add(Functions.StringVars(Strings.QuestGemulonInformDays,
						Functions.Multiples(SpecialEvent.StatusGemulonDate - game.QuestStatusGemulon, "day")));
			}
			else if (game.QuestStatusGemulon == SpecialEvent.StatusGemulonFuel)
				quests.Add(Strings.QuestGemulonFuel);

			if (game.QuestStatusExperiment > SpecialEvent.StatusExperimentNotStarted &&
				game.QuestStatusExperiment < SpecialEvent.StatusExperimentDate)
			{
				if (game.QuestStatusExperiment == SpecialEvent.StatusExperimentDate - 1)
					quests.Add(Strings.QuestExperimentInformTomorrow);
				else
					quests.Add(Functions.StringVars(Strings.QuestExperimentInformDays,
						Functions.Multiples(SpecialEvent.StatusExperimentDate - game.QuestStatusExperiment, "day")));
			}

			if (game.Commander.Ship.ReactorOnBoard)
			{
				if (game.QuestStatusReactor == SpecialEvent.StatusReactorFuelOk)
					quests.Add(Strings.QuestReactor);
				else
					quests.Add(Strings.QuestReactorFuel);
			}
			else if (game.QuestStatusReactor == SpecialEvent.StatusReactorDelivered)
				quests.Add(Strings.QuestReactorLaser);

			if (game.QuestStatusSpaceMonster == SpecialEvent.StatusSpaceMonsterAtAcamar)
				quests.Add(Strings.QuestSpaceMonsterKill);

			if (game.QuestStatusJapori == SpecialEvent.StatusJaporiInTransit)
				quests.Add(Strings.QuestJaporiDeliver);

			switch (game.QuestStatusDragonfly)
			{
				case SpecialEvent.StatusDragonflyFlyBaratas:
					quests.Add(Strings.QuestDragonflyBaratas);
					break;
				case SpecialEvent.StatusDragonflyFlyMelina:
					quests.Add(Strings.QuestDragonflyMelina);
					break;
				case SpecialEvent.StatusDragonflyFlyRegulas:
					quests.Add(Strings.QuestDragonflyRegulas);
					break;
				case SpecialEvent.StatusDragonflyFlyZalkon:
					quests.Add(Strings.QuestDragonflyZalkon);
					break;
				case SpecialEvent.StatusDragonflyDestroyed:
					quests.Add(Strings.QuestDragonflyShield);
					break;
			}

			switch (game.QuestStatusPrincess)
			{
				case SpecialEvent.StatusPrincessFlyCentauri:
					quests.Add(Strings.QuestPrincessCentauri);
					break;
				case SpecialEvent.StatusPrincessFlyInthara:
					quests.Add(Strings.QuestPrincessInthara);
					break;
				case SpecialEvent.StatusPrincessFlyQonos:
					quests.Add(Strings.QuestPrincessQonos);
					break;
				case SpecialEvent.StatusPrincessRescued:
					if (game.Commander.Ship.PrincessOnBoard)
					{
						if (game.QuestStatusPrincess == SpecialEvent.StatusPrincessImpatient)
							quests.Add(Functions.StringVars(Strings.QuestPrincessReturningImpatient,
								game.Mercenaries[(int)CrewMemberId.Princess].Name));
						else
							quests.Add(Functions.StringVars(Strings.QuestPrincessReturning,
								game.Mercenaries[(int)CrewMemberId.Princess].Name));
					}
					else
						quests.Add(Functions.StringVars(Strings.QuestPrincessReturn,
							game.Mercenaries[(int)CrewMemberId.Princess].Name));
					break;
				case SpecialEvent.StatusPrincessReturned:
					quests.Add(Strings.QuestPrincessQuantum);
					break;
			}

			if (game.QuestStatusScarab == SpecialEvent.StatusScarabHunting)
				quests.Add(Strings.QuestScarabFind);
			else if (game.QuestStatusScarab == SpecialEvent.StatusScarabDestroyed)
			{
				if (Consts.SpecialEvents[(int)SpecialEventType.ScarabUpgradeHull].Location == null)
					quests.Add(Functions.StringVars(Strings.QuestScarabNotify,
						Consts.SpecialEvents[(int)SpecialEventType.ScarabDestroyed].Location.Name));
				else
					quests.Add(Functions.StringVars(Strings.QuestScarabHull,
						Consts.SpecialEvents[(int)SpecialEventType.ScarabUpgradeHull].Location.Name));
			}

			if (game.Commander.Ship.SculptureOnBoard)
				quests.Add(Strings.QuestSculpture);
			else if (game.QuestStatusReactor == SpecialEvent.StatusReactorDelivered)
				quests.Add(Strings.QuestSculptureHiddenBays);

			if (game.QuestStatusArtifact == SpecialEvent.StatusArtifactOnBoard)
				quests.Add(Strings.QuestArtifact);

			if (game.Commander.Ship.JarekOnBoard)
			{
				if (game.QuestStatusJarek == SpecialEvent.StatusJarekImpatient)
					quests.Add(Strings.QuestJarekImpatient);
				else
					quests.Add(Strings.QuestJarek);
			}

			if (game.Commander.Ship.WildOnBoard)
			{
				if (game.QuestStatusWild == SpecialEvent.StatusWildImpatient)
					quests.Add(Strings.QuestWildImpatient);
				else
					quests.Add(Strings.QuestWild);
			}

			if (game.Commander.Ship.Tribbles > 0)
				quests.Add(Strings.QuestTribbles);

			if (game.QuestStatusMoon == SpecialEvent.StatusMoonBought)
				quests.Add(Strings.QuestMoon);

			return Functions.ArrayListToStringArray(quests);
		}

		private void UpdateAll()
		{
			string[]	quests	= GetQuestStrings();
			if (quests.Length == 0)
				lblQuests.Text	= Strings.QuestNone;
			else
			{
				lblQuests.Text	= String.Join(Environment.NewLine + Environment.NewLine, quests);

				for (int i = 0; i < Strings.SystemNames.Length; i++)
				{
					string	systemName	= Strings.SystemNames[i];
					int			start				= 0;
					int			index				= -1;

					while ((index = lblQuests.Text.IndexOf(systemName, start)) >= 0)
					{
						lblQuests.Links.Add(index, systemName.Length, systemName);
						start	= index + systemName.Length;
					}
				}
			}
		}

		#endregion

		#region Event Handlers

		private void lblQuests_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			Game.CurrentGame.SelectedSystemName	= e.Link.LinkData.ToString();
			Game.CurrentGame.ParentWindow.UpdateAll();
			Close();
		}

		#endregion
	}
}
