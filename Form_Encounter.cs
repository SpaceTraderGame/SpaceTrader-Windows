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
	public class FormEncounter : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Label lblEncounter;
		private System.Windows.Forms.PictureBox picShipYou;
		private System.Windows.Forms.PictureBox picShipOpponent;
		private System.Windows.Forms.Label lblOpponentLabel;
		private System.Windows.Forms.Label lblYouLabel;
		private System.Windows.Forms.Label lblOpponentShip;
		private System.Windows.Forms.Label lblYouShip;
		private System.Windows.Forms.Label lblYouHull;
		private System.Windows.Forms.Label lblYouShields;
		private System.Windows.Forms.Label lblOpponentShields;
		private System.Windows.Forms.Label lblOpponentHull;
		private System.Windows.Forms.Label lblAction;
		private System.Windows.Forms.Button btnAttack;
		private System.Windows.Forms.Button btnFlee;
		private System.Windows.Forms.Button btnSubmit;
		private System.Windows.Forms.Button btnBribe;
		private System.Windows.Forms.Button btnSurrender;
		private System.Windows.Forms.Button btnIgnore;
		private System.Windows.Forms.Button btnTrade;
		private System.Windows.Forms.Button btnPlunder;
		private System.Windows.Forms.Button btnBoard;
		private System.Windows.Forms.Button btnMeet;
		private System.Windows.Forms.Button btnDrink;
		private System.Windows.Forms.Button btnInt;
		private System.Windows.Forms.Button btnYield;
		private System.Windows.Forms.PictureBox picContinuous;
		private System.Windows.Forms.ImageList ilContinuous;
		private System.Windows.Forms.PictureBox picEncounterType;
		private System.Windows.Forms.ImageList ilEncounterType;
		private System.Windows.Forms.ImageList ilTribbles;
		private System.Windows.Forms.PictureBox picTrib00;
		private System.Windows.Forms.PictureBox picTrib50;
		private System.Windows.Forms.PictureBox picTrib10;
		private System.Windows.Forms.PictureBox picTrib40;
		private System.Windows.Forms.PictureBox picTrib20;
		private System.Windows.Forms.PictureBox picTrib30;
		private System.Windows.Forms.PictureBox picTrib04;
		private System.Windows.Forms.PictureBox picTrib03;
		private System.Windows.Forms.PictureBox picTrib02;
		private System.Windows.Forms.PictureBox picTrib01;
		private System.Windows.Forms.PictureBox picTrib05;
		private System.Windows.Forms.PictureBox picTrib11;
		private System.Windows.Forms.PictureBox picTrib12;
		private System.Windows.Forms.PictureBox picTrib13;
		private System.Windows.Forms.PictureBox picTrib14;
		private System.Windows.Forms.PictureBox picTrib15;
		private System.Windows.Forms.PictureBox picTrib21;
		private System.Windows.Forms.PictureBox picTrib22;
		private System.Windows.Forms.PictureBox picTrib23;
		private System.Windows.Forms.PictureBox picTrib24;
		private System.Windows.Forms.PictureBox picTrib25;
		private System.Windows.Forms.PictureBox picTrib31;
		private System.Windows.Forms.PictureBox picTrib32;
		private System.Windows.Forms.PictureBox picTrib33;
		private System.Windows.Forms.PictureBox picTrib34;
		private System.Windows.Forms.PictureBox picTrib35;
		private System.Windows.Forms.PictureBox picTrib41;
		private System.Windows.Forms.PictureBox picTrib51;
		private System.Windows.Forms.PictureBox picTrib42;
		private System.Windows.Forms.PictureBox picTrib52;
		private System.Windows.Forms.PictureBox picTrib43;
		private System.Windows.Forms.PictureBox picTrib53;
		private System.Windows.Forms.PictureBox picTrib44;
		private System.Windows.Forms.PictureBox picTrib45;
		private System.Windows.Forms.PictureBox picTrib54;
		private System.Windows.Forms.PictureBox picTrib55;
		private System.Windows.Forms.Timer tmrTick;
		private System.ComponentModel.IContainer components;

		private Button[]									buttons;

		#endregion

		#region Constants

		private const int									ATTACK			= 0;
		private const int									BOARD				= 1;
		private const int									BRIBE				= 2;
		private const int									DRINK				= 3;
		private const int									FLEE				= 4;
		private const int									IGNORE			= 5;
		private const int									INT					= 6;
		private const int									MEET				= 7;
		private const int									PLUNDER			= 8;
		private const int									SUBMIT			= 9;
		private const int									SURRENDER		= 10;
		private const int									TRADE				= 11;
		private const int									YIELD				= 12;

		#endregion

		#region Member Declarations

		private Game											game				= Game.CurrentGame;
		private	Ship											cmdrship		= Game.CurrentGame.Commander.Ship;
		private Ship											opponent		= Game.CurrentGame.Opponent;
		private int												contImg			= 1;

		private EncounterResult						_result			= EncounterResult.Continue;

		#endregion

		#region Methods

		public FormEncounter()
		{
			InitializeComponent();

			// Set up the Game encounter variables.
			game.EncounterBegin();

			// Enable the control box (the X button) if cheats are enabled.
			if (game.EasyEncounters)
				ControlBox	= true;

			buttons			= new Button[]
										{
											btnAttack,
											btnBoard,
											btnBribe,
											btnDrink,
											btnFlee,
											btnIgnore,
											btnInt,
											btnMeet,
											btnPlunder,
											btnSubmit,
											btnSurrender,
											btnTrade,
											btnYield
										};

			UpdateShipInfo();
			UpdateTribbles();
			UpdateButtons();

			if (game.EncounterImageIndex >= 0)
				picEncounterType.Image		= ilEncounterType.Images[game.EncounterImageIndex];
			else
				picEncounterType.Visible	= false;

			lblEncounter.Text	= game.EncounterTextInitial;
			lblAction.Text		= game.EncounterActionInitial;
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormEncounter));
			this.lblEncounter = new System.Windows.Forms.Label();
			this.picShipYou = new System.Windows.Forms.PictureBox();
			this.picShipOpponent = new System.Windows.Forms.PictureBox();
			this.lblAction = new System.Windows.Forms.Label();
			this.lblOpponentLabel = new System.Windows.Forms.Label();
			this.lblYouLabel = new System.Windows.Forms.Label();
			this.lblOpponentShip = new System.Windows.Forms.Label();
			this.lblYouShip = new System.Windows.Forms.Label();
			this.lblYouHull = new System.Windows.Forms.Label();
			this.lblYouShields = new System.Windows.Forms.Label();
			this.lblOpponentShields = new System.Windows.Forms.Label();
			this.lblOpponentHull = new System.Windows.Forms.Label();
			this.btnAttack = new System.Windows.Forms.Button();
			this.btnFlee = new System.Windows.Forms.Button();
			this.btnSubmit = new System.Windows.Forms.Button();
			this.btnBribe = new System.Windows.Forms.Button();
			this.btnSurrender = new System.Windows.Forms.Button();
			this.btnIgnore = new System.Windows.Forms.Button();
			this.btnTrade = new System.Windows.Forms.Button();
			this.btnPlunder = new System.Windows.Forms.Button();
			this.btnBoard = new System.Windows.Forms.Button();
			this.btnMeet = new System.Windows.Forms.Button();
			this.btnDrink = new System.Windows.Forms.Button();
			this.btnInt = new System.Windows.Forms.Button();
			this.btnYield = new System.Windows.Forms.Button();
			this.picContinuous = new System.Windows.Forms.PictureBox();
			this.ilContinuous = new System.Windows.Forms.ImageList(this.components);
			this.picEncounterType = new System.Windows.Forms.PictureBox();
			this.ilEncounterType = new System.Windows.Forms.ImageList(this.components);
			this.picTrib00 = new System.Windows.Forms.PictureBox();
			this.ilTribbles = new System.Windows.Forms.ImageList(this.components);
			this.picTrib50 = new System.Windows.Forms.PictureBox();
			this.picTrib10 = new System.Windows.Forms.PictureBox();
			this.picTrib40 = new System.Windows.Forms.PictureBox();
			this.picTrib20 = new System.Windows.Forms.PictureBox();
			this.picTrib30 = new System.Windows.Forms.PictureBox();
			this.picTrib04 = new System.Windows.Forms.PictureBox();
			this.picTrib03 = new System.Windows.Forms.PictureBox();
			this.picTrib02 = new System.Windows.Forms.PictureBox();
			this.picTrib01 = new System.Windows.Forms.PictureBox();
			this.picTrib05 = new System.Windows.Forms.PictureBox();
			this.picTrib11 = new System.Windows.Forms.PictureBox();
			this.picTrib12 = new System.Windows.Forms.PictureBox();
			this.picTrib13 = new System.Windows.Forms.PictureBox();
			this.picTrib14 = new System.Windows.Forms.PictureBox();
			this.picTrib15 = new System.Windows.Forms.PictureBox();
			this.picTrib21 = new System.Windows.Forms.PictureBox();
			this.picTrib22 = new System.Windows.Forms.PictureBox();
			this.picTrib23 = new System.Windows.Forms.PictureBox();
			this.picTrib24 = new System.Windows.Forms.PictureBox();
			this.picTrib25 = new System.Windows.Forms.PictureBox();
			this.picTrib31 = new System.Windows.Forms.PictureBox();
			this.picTrib32 = new System.Windows.Forms.PictureBox();
			this.picTrib33 = new System.Windows.Forms.PictureBox();
			this.picTrib34 = new System.Windows.Forms.PictureBox();
			this.picTrib35 = new System.Windows.Forms.PictureBox();
			this.picTrib41 = new System.Windows.Forms.PictureBox();
			this.picTrib51 = new System.Windows.Forms.PictureBox();
			this.picTrib42 = new System.Windows.Forms.PictureBox();
			this.picTrib52 = new System.Windows.Forms.PictureBox();
			this.picTrib43 = new System.Windows.Forms.PictureBox();
			this.picTrib53 = new System.Windows.Forms.PictureBox();
			this.picTrib44 = new System.Windows.Forms.PictureBox();
			this.picTrib45 = new System.Windows.Forms.PictureBox();
			this.picTrib54 = new System.Windows.Forms.PictureBox();
			this.picTrib55 = new System.Windows.Forms.PictureBox();
			this.tmrTick = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// lblEncounter
			// 
			this.lblEncounter.Location = new System.Drawing.Point(8, 152);
			this.lblEncounter.Name = "lblEncounter";
			this.lblEncounter.Size = new System.Drawing.Size(232, 26);
			this.lblEncounter.TabIndex = 0;
			this.lblEncounter.Text = "At 20 clicks from Tarchannen, you encounter the famous Captain Ahab.";
			// 
			// picShipYou
			// 
			this.picShipYou.BackColor = System.Drawing.Color.White;
			this.picShipYou.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picShipYou.Location = new System.Drawing.Point(26, 24);
			this.picShipYou.Name = "picShipYou";
			this.picShipYou.Size = new System.Drawing.Size(70, 58);
			this.picShipYou.TabIndex = 13;
			this.picShipYou.TabStop = false;
			this.picShipYou.Paint += new System.Windows.Forms.PaintEventHandler(this.picShipYou_Paint);
			// 
			// picShipOpponent
			// 
			this.picShipOpponent.BackColor = System.Drawing.Color.White;
			this.picShipOpponent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picShipOpponent.Location = new System.Drawing.Point(138, 24);
			this.picShipOpponent.Name = "picShipOpponent";
			this.picShipOpponent.Size = new System.Drawing.Size(70, 58);
			this.picShipOpponent.TabIndex = 14;
			this.picShipOpponent.TabStop = false;
			this.picShipOpponent.Paint += new System.Windows.Forms.PaintEventHandler(this.picShipOpponent_Paint);
			// 
			// lblAction
			// 
			this.lblAction.Location = new System.Drawing.Point(8, 192);
			this.lblAction.Name = "lblAction";
			this.lblAction.Size = new System.Drawing.Size(232, 39);
			this.lblAction.TabIndex = 15;
			this.lblAction.Text = "\"We know you removed illegal goods from the Marie Celeste. You must give them up " +
				"at once!\"";
			// 
			// lblOpponentLabel
			// 
			this.lblOpponentLabel.AutoSize = true;
			this.lblOpponentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblOpponentLabel.Location = new System.Drawing.Point(141, 8);
			this.lblOpponentLabel.Name = "lblOpponentLabel";
			this.lblOpponentLabel.Size = new System.Drawing.Size(59, 16);
			this.lblOpponentLabel.TabIndex = 16;
			this.lblOpponentLabel.Text = "Opponent:";
			// 
			// lblYouLabel
			// 
			this.lblYouLabel.AutoSize = true;
			this.lblYouLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblYouLabel.Location = new System.Drawing.Point(45, 8);
			this.lblYouLabel.Name = "lblYouLabel";
			this.lblYouLabel.Size = new System.Drawing.Size(28, 16);
			this.lblYouLabel.TabIndex = 17;
			this.lblYouLabel.Text = "You:";
			// 
			// lblOpponentShip
			// 
			this.lblOpponentShip.Location = new System.Drawing.Point(138, 88);
			this.lblOpponentShip.Name = "lblOpponentShip";
			this.lblOpponentShip.Size = new System.Drawing.Size(80, 13);
			this.lblOpponentShip.TabIndex = 18;
			this.lblOpponentShip.Text = "Space Monster";
			// 
			// lblYouShip
			// 
			this.lblYouShip.Location = new System.Drawing.Point(26, 88);
			this.lblYouShip.Name = "lblYouShip";
			this.lblYouShip.Size = new System.Drawing.Size(100, 13);
			this.lblYouShip.TabIndex = 19;
			this.lblYouShip.Text = "Grasshopper";
			// 
			// lblYouHull
			// 
			this.lblYouHull.Location = new System.Drawing.Point(26, 104);
			this.lblYouHull.Name = "lblYouHull";
			this.lblYouHull.Size = new System.Drawing.Size(68, 13);
			this.lblYouHull.TabIndex = 20;
			this.lblYouHull.Text = "Hull at 100%";
			// 
			// lblYouShields
			// 
			this.lblYouShields.Location = new System.Drawing.Point(26, 120);
			this.lblYouShields.Name = "lblYouShields";
			this.lblYouShields.Size = new System.Drawing.Size(86, 13);
			this.lblYouShields.TabIndex = 21;
			this.lblYouShields.Text = "Shields at 100%";
			// 
			// lblOpponentShields
			// 
			this.lblOpponentShields.Location = new System.Drawing.Point(138, 120);
			this.lblOpponentShields.Name = "lblOpponentShields";
			this.lblOpponentShields.Size = new System.Drawing.Size(86, 13);
			this.lblOpponentShields.TabIndex = 23;
			this.lblOpponentShields.Text = "Shields at 100%";
			// 
			// lblOpponentHull
			// 
			this.lblOpponentHull.Location = new System.Drawing.Point(138, 104);
			this.lblOpponentHull.Name = "lblOpponentHull";
			this.lblOpponentHull.Size = new System.Drawing.Size(68, 13);
			this.lblOpponentHull.TabIndex = 22;
			this.lblOpponentHull.Text = "Hull at 100%";
			// 
			// btnAttack
			// 
			this.btnAttack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAttack.Location = new System.Drawing.Point(8, 240);
			this.btnAttack.Name = "btnAttack";
			this.btnAttack.Size = new System.Drawing.Size(46, 22);
			this.btnAttack.TabIndex = 24;
			this.btnAttack.Text = "Attack";
			this.btnAttack.Visible = false;
			this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
			// 
			// btnFlee
			// 
			this.btnFlee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFlee.Location = new System.Drawing.Point(62, 240);
			this.btnFlee.Name = "btnFlee";
			this.btnFlee.Size = new System.Drawing.Size(36, 22);
			this.btnFlee.TabIndex = 25;
			this.btnFlee.Text = "Flee";
			this.btnFlee.Visible = false;
			this.btnFlee.Click += new System.EventHandler(this.btnFlee_Click);
			// 
			// btnSubmit
			// 
			this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSubmit.Location = new System.Drawing.Point(106, 240);
			this.btnSubmit.Name = "btnSubmit";
			this.btnSubmit.Size = new System.Drawing.Size(49, 22);
			this.btnSubmit.TabIndex = 26;
			this.btnSubmit.Text = "Submit";
			this.btnSubmit.Visible = false;
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			// 
			// btnBribe
			// 
			this.btnBribe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBribe.Location = new System.Drawing.Point(163, 240);
			this.btnBribe.Name = "btnBribe";
			this.btnBribe.Size = new System.Drawing.Size(41, 22);
			this.btnBribe.TabIndex = 27;
			this.btnBribe.Text = "Bribe";
			this.btnBribe.Visible = false;
			this.btnBribe.Click += new System.EventHandler(this.btnBribe_Click);
			// 
			// btnSurrender
			// 
			this.btnSurrender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSurrender.Location = new System.Drawing.Point(106, 240);
			this.btnSurrender.Name = "btnSurrender";
			this.btnSurrender.Size = new System.Drawing.Size(65, 22);
			this.btnSurrender.TabIndex = 28;
			this.btnSurrender.Text = "Surrender";
			this.btnSurrender.Visible = false;
			this.btnSurrender.Click += new System.EventHandler(this.btnSurrender_Click);
			// 
			// btnIgnore
			// 
			this.btnIgnore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnIgnore.Location = new System.Drawing.Point(62, 240);
			this.btnIgnore.Name = "btnIgnore";
			this.btnIgnore.Size = new System.Drawing.Size(46, 22);
			this.btnIgnore.TabIndex = 29;
			this.btnIgnore.Text = "Ignore";
			this.btnIgnore.Visible = false;
			this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
			// 
			// btnTrade
			// 
			this.btnTrade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTrade.Location = new System.Drawing.Point(116, 240);
			this.btnTrade.Name = "btnTrade";
			this.btnTrade.Size = new System.Drawing.Size(44, 22);
			this.btnTrade.TabIndex = 30;
			this.btnTrade.Text = "Trade";
			this.btnTrade.Visible = false;
			this.btnTrade.Click += new System.EventHandler(this.btnTrade_Click);
			// 
			// btnPlunder
			// 
			this.btnPlunder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPlunder.Location = new System.Drawing.Point(62, 240);
			this.btnPlunder.Name = "btnPlunder";
			this.btnPlunder.Size = new System.Drawing.Size(53, 22);
			this.btnPlunder.TabIndex = 31;
			this.btnPlunder.Text = "Plunder";
			this.btnPlunder.Visible = false;
			this.btnPlunder.Click += new System.EventHandler(this.btnPlunder_Click);
			// 
			// btnBoard
			// 
			this.btnBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBoard.Location = new System.Drawing.Point(8, 240);
			this.btnBoard.Name = "btnBoard";
			this.btnBoard.Size = new System.Drawing.Size(44, 22);
			this.btnBoard.TabIndex = 32;
			this.btnBoard.Text = "Board";
			this.btnBoard.Visible = false;
			this.btnBoard.Click += new System.EventHandler(this.btnBoard_Click);
			// 
			// btnMeet
			// 
			this.btnMeet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMeet.Location = new System.Drawing.Point(116, 240);
			this.btnMeet.Name = "btnMeet";
			this.btnMeet.Size = new System.Drawing.Size(39, 22);
			this.btnMeet.TabIndex = 34;
			this.btnMeet.Text = "Meet";
			this.btnMeet.Visible = false;
			this.btnMeet.Click += new System.EventHandler(this.btnMeet_Click);
			// 
			// btnDrink
			// 
			this.btnDrink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDrink.Location = new System.Drawing.Point(8, 240);
			this.btnDrink.Name = "btnDrink";
			this.btnDrink.Size = new System.Drawing.Size(41, 22);
			this.btnDrink.TabIndex = 35;
			this.btnDrink.Text = "Drink";
			this.btnDrink.Visible = false;
			this.btnDrink.Click += new System.EventHandler(this.btnDrink_Click);
			// 
			// btnInt
			// 
			this.btnInt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnInt.Location = new System.Drawing.Point(179, 240);
			this.btnInt.Name = "btnInt";
			this.btnInt.Size = new System.Drawing.Size(30, 22);
			this.btnInt.TabIndex = 36;
			this.btnInt.Text = "Int.";
			this.btnInt.Visible = false;
			this.btnInt.Click += new System.EventHandler(this.btnInt_Click);
			// 
			// btnYield
			// 
			this.btnYield.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnYield.Location = new System.Drawing.Point(106, 240);
			this.btnYield.Name = "btnYield";
			this.btnYield.Size = new System.Drawing.Size(39, 22);
			this.btnYield.TabIndex = 37;
			this.btnYield.Text = "Yield";
			this.btnYield.Visible = false;
			this.btnYield.Click += new System.EventHandler(this.btnYield_Click);
			// 
			// picContinuous
			// 
			this.picContinuous.Location = new System.Drawing.Point(214, 247);
			this.picContinuous.Name = "picContinuous";
			this.picContinuous.Size = new System.Drawing.Size(9, 9);
			this.picContinuous.TabIndex = 38;
			this.picContinuous.TabStop = false;
			this.picContinuous.Visible = false;
			// 
			// ilContinuous
			// 
			this.ilContinuous.ImageSize = new System.Drawing.Size(9, 9);
			this.ilContinuous.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilContinuous.ImageStream")));
			this.ilContinuous.TransparentColor = System.Drawing.Color.White;
			// 
			// picEncounterType
			// 
			this.picEncounterType.Location = new System.Drawing.Point(220, 2);
			this.picEncounterType.Name = "picEncounterType";
			this.picEncounterType.Size = new System.Drawing.Size(12, 12);
			this.picEncounterType.TabIndex = 39;
			this.picEncounterType.TabStop = false;
			// 
			// ilEncounterType
			// 
			this.ilEncounterType.ImageSize = new System.Drawing.Size(12, 12);
			this.ilEncounterType.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilEncounterType.ImageStream")));
			this.ilEncounterType.TransparentColor = System.Drawing.Color.White;
			// 
			// picTrib00
			// 
			this.picTrib00.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib00.Location = new System.Drawing.Point(16, 16);
			this.picTrib00.Name = "picTrib00";
			this.picTrib00.Size = new System.Drawing.Size(12, 12);
			this.picTrib00.TabIndex = 41;
			this.picTrib00.TabStop = false;
			this.picTrib00.Visible = false;
			this.picTrib00.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// ilTribbles
			// 
			this.ilTribbles.ImageSize = new System.Drawing.Size(12, 12);
			this.ilTribbles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTribbles.ImageStream")));
			this.ilTribbles.TransparentColor = System.Drawing.Color.White;
			// 
			// picTrib50
			// 
			this.picTrib50.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib50.Location = new System.Drawing.Point(16, 224);
			this.picTrib50.Name = "picTrib50";
			this.picTrib50.Size = new System.Drawing.Size(12, 12);
			this.picTrib50.TabIndex = 42;
			this.picTrib50.TabStop = false;
			this.picTrib50.Visible = false;
			this.picTrib50.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib10
			// 
			this.picTrib10.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib10.Location = new System.Drawing.Point(8, 56);
			this.picTrib10.Name = "picTrib10";
			this.picTrib10.Size = new System.Drawing.Size(12, 12);
			this.picTrib10.TabIndex = 43;
			this.picTrib10.TabStop = false;
			this.picTrib10.Visible = false;
			this.picTrib10.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib40
			// 
			this.picTrib40.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib40.Location = new System.Drawing.Point(8, 184);
			this.picTrib40.Name = "picTrib40";
			this.picTrib40.Size = new System.Drawing.Size(12, 12);
			this.picTrib40.TabIndex = 44;
			this.picTrib40.TabStop = false;
			this.picTrib40.Visible = false;
			this.picTrib40.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib20
			// 
			this.picTrib20.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib20.Location = new System.Drawing.Point(8, 96);
			this.picTrib20.Name = "picTrib20";
			this.picTrib20.Size = new System.Drawing.Size(12, 12);
			this.picTrib20.TabIndex = 45;
			this.picTrib20.TabStop = false;
			this.picTrib20.Visible = false;
			this.picTrib20.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib30
			// 
			this.picTrib30.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib30.Location = new System.Drawing.Point(16, 136);
			this.picTrib30.Name = "picTrib30";
			this.picTrib30.Size = new System.Drawing.Size(12, 12);
			this.picTrib30.TabIndex = 46;
			this.picTrib30.TabStop = false;
			this.picTrib30.Visible = false;
			this.picTrib30.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib04
			// 
			this.picTrib04.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib04.Location = new System.Drawing.Point(176, 8);
			this.picTrib04.Name = "picTrib04";
			this.picTrib04.Size = new System.Drawing.Size(12, 12);
			this.picTrib04.TabIndex = 47;
			this.picTrib04.TabStop = false;
			this.picTrib04.Visible = false;
			this.picTrib04.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib03
			// 
			this.picTrib03.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib03.Location = new System.Drawing.Point(128, 8);
			this.picTrib03.Name = "picTrib03";
			this.picTrib03.Size = new System.Drawing.Size(12, 12);
			this.picTrib03.TabIndex = 48;
			this.picTrib03.TabStop = false;
			this.picTrib03.Visible = false;
			this.picTrib03.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib02
			// 
			this.picTrib02.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib02.Location = new System.Drawing.Point(96, 16);
			this.picTrib02.Name = "picTrib02";
			this.picTrib02.Size = new System.Drawing.Size(12, 12);
			this.picTrib02.TabIndex = 49;
			this.picTrib02.TabStop = false;
			this.picTrib02.Visible = false;
			this.picTrib02.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib01
			// 
			this.picTrib01.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib01.Location = new System.Drawing.Point(56, 8);
			this.picTrib01.Name = "picTrib01";
			this.picTrib01.Size = new System.Drawing.Size(12, 12);
			this.picTrib01.TabIndex = 50;
			this.picTrib01.TabStop = false;
			this.picTrib01.Visible = false;
			this.picTrib01.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib05
			// 
			this.picTrib05.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib05.Location = new System.Drawing.Point(208, 16);
			this.picTrib05.Name = "picTrib05";
			this.picTrib05.Size = new System.Drawing.Size(12, 12);
			this.picTrib05.TabIndex = 51;
			this.picTrib05.TabStop = false;
			this.picTrib05.Visible = false;
			this.picTrib05.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib11
			// 
			this.picTrib11.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib11.Location = new System.Drawing.Point(32, 80);
			this.picTrib11.Name = "picTrib11";
			this.picTrib11.Size = new System.Drawing.Size(12, 12);
			this.picTrib11.TabIndex = 52;
			this.picTrib11.TabStop = false;
			this.picTrib11.Visible = false;
			this.picTrib11.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib12
			// 
			this.picTrib12.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib12.Location = new System.Drawing.Point(88, 56);
			this.picTrib12.Name = "picTrib12";
			this.picTrib12.Size = new System.Drawing.Size(12, 12);
			this.picTrib12.TabIndex = 53;
			this.picTrib12.TabStop = false;
			this.picTrib12.Visible = false;
			this.picTrib12.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib13
			// 
			this.picTrib13.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib13.Location = new System.Drawing.Point(128, 40);
			this.picTrib13.Name = "picTrib13";
			this.picTrib13.Size = new System.Drawing.Size(12, 12);
			this.picTrib13.TabIndex = 54;
			this.picTrib13.TabStop = false;
			this.picTrib13.Visible = false;
			this.picTrib13.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib14
			// 
			this.picTrib14.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib14.Location = new System.Drawing.Point(192, 72);
			this.picTrib14.Name = "picTrib14";
			this.picTrib14.Size = new System.Drawing.Size(12, 12);
			this.picTrib14.TabIndex = 55;
			this.picTrib14.TabStop = false;
			this.picTrib14.Visible = false;
			this.picTrib14.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib15
			// 
			this.picTrib15.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib15.Location = new System.Drawing.Point(216, 48);
			this.picTrib15.Name = "picTrib15";
			this.picTrib15.Size = new System.Drawing.Size(12, 12);
			this.picTrib15.TabIndex = 56;
			this.picTrib15.TabStop = false;
			this.picTrib15.Visible = false;
			this.picTrib15.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib21
			// 
			this.picTrib21.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib21.Location = new System.Drawing.Point(56, 96);
			this.picTrib21.Name = "picTrib21";
			this.picTrib21.Size = new System.Drawing.Size(12, 12);
			this.picTrib21.TabIndex = 57;
			this.picTrib21.TabStop = false;
			this.picTrib21.Visible = false;
			this.picTrib21.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib22
			// 
			this.picTrib22.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib22.Location = new System.Drawing.Point(96, 80);
			this.picTrib22.Name = "picTrib22";
			this.picTrib22.Size = new System.Drawing.Size(12, 12);
			this.picTrib22.TabIndex = 58;
			this.picTrib22.TabStop = false;
			this.picTrib22.Visible = false;
			this.picTrib22.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib23
			// 
			this.picTrib23.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib23.Location = new System.Drawing.Point(136, 88);
			this.picTrib23.Name = "picTrib23";
			this.picTrib23.Size = new System.Drawing.Size(12, 12);
			this.picTrib23.TabIndex = 59;
			this.picTrib23.TabStop = false;
			this.picTrib23.Visible = false;
			this.picTrib23.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib24
			// 
			this.picTrib24.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib24.Location = new System.Drawing.Point(176, 104);
			this.picTrib24.Name = "picTrib24";
			this.picTrib24.Size = new System.Drawing.Size(12, 12);
			this.picTrib24.TabIndex = 60;
			this.picTrib24.TabStop = false;
			this.picTrib24.Visible = false;
			this.picTrib24.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib25
			// 
			this.picTrib25.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib25.Location = new System.Drawing.Point(216, 96);
			this.picTrib25.Name = "picTrib25";
			this.picTrib25.Size = new System.Drawing.Size(12, 12);
			this.picTrib25.TabIndex = 61;
			this.picTrib25.TabStop = false;
			this.picTrib25.Visible = false;
			this.picTrib25.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib31
			// 
			this.picTrib31.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib31.Location = new System.Drawing.Point(56, 128);
			this.picTrib31.Name = "picTrib31";
			this.picTrib31.Size = new System.Drawing.Size(12, 12);
			this.picTrib31.TabIndex = 62;
			this.picTrib31.TabStop = false;
			this.picTrib31.Visible = false;
			this.picTrib31.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib32
			// 
			this.picTrib32.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib32.Location = new System.Drawing.Point(96, 120);
			this.picTrib32.Name = "picTrib32";
			this.picTrib32.Size = new System.Drawing.Size(12, 12);
			this.picTrib32.TabIndex = 63;
			this.picTrib32.TabStop = false;
			this.picTrib32.Visible = false;
			this.picTrib32.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib33
			// 
			this.picTrib33.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib33.Location = new System.Drawing.Point(128, 128);
			this.picTrib33.Name = "picTrib33";
			this.picTrib33.Size = new System.Drawing.Size(12, 12);
			this.picTrib33.TabIndex = 64;
			this.picTrib33.TabStop = false;
			this.picTrib33.Visible = false;
			this.picTrib33.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib34
			// 
			this.picTrib34.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib34.Location = new System.Drawing.Point(168, 144);
			this.picTrib34.Name = "picTrib34";
			this.picTrib34.Size = new System.Drawing.Size(12, 12);
			this.picTrib34.TabIndex = 65;
			this.picTrib34.TabStop = false;
			this.picTrib34.Visible = false;
			this.picTrib34.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib35
			// 
			this.picTrib35.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib35.Location = new System.Drawing.Point(208, 128);
			this.picTrib35.Name = "picTrib35";
			this.picTrib35.Size = new System.Drawing.Size(12, 12);
			this.picTrib35.TabIndex = 66;
			this.picTrib35.TabStop = false;
			this.picTrib35.Visible = false;
			this.picTrib35.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib41
			// 
			this.picTrib41.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib41.Location = new System.Drawing.Point(48, 176);
			this.picTrib41.Name = "picTrib41";
			this.picTrib41.Size = new System.Drawing.Size(12, 12);
			this.picTrib41.TabIndex = 67;
			this.picTrib41.TabStop = false;
			this.picTrib41.Visible = false;
			this.picTrib41.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib51
			// 
			this.picTrib51.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib51.Location = new System.Drawing.Point(64, 216);
			this.picTrib51.Name = "picTrib51";
			this.picTrib51.Size = new System.Drawing.Size(12, 12);
			this.picTrib51.TabIndex = 68;
			this.picTrib51.TabStop = false;
			this.picTrib51.Visible = false;
			this.picTrib51.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib42
			// 
			this.picTrib42.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib42.Location = new System.Drawing.Point(88, 168);
			this.picTrib42.Name = "picTrib42";
			this.picTrib42.Size = new System.Drawing.Size(12, 12);
			this.picTrib42.TabIndex = 69;
			this.picTrib42.TabStop = false;
			this.picTrib42.Visible = false;
			this.picTrib42.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib52
			// 
			this.picTrib52.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib52.Location = new System.Drawing.Point(96, 224);
			this.picTrib52.Name = "picTrib52";
			this.picTrib52.Size = new System.Drawing.Size(12, 12);
			this.picTrib52.TabIndex = 70;
			this.picTrib52.TabStop = false;
			this.picTrib52.Visible = false;
			this.picTrib52.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib43
			// 
			this.picTrib43.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib43.Location = new System.Drawing.Point(136, 176);
			this.picTrib43.Name = "picTrib43";
			this.picTrib43.Size = new System.Drawing.Size(12, 12);
			this.picTrib43.TabIndex = 71;
			this.picTrib43.TabStop = false;
			this.picTrib43.Visible = false;
			this.picTrib43.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib53
			// 
			this.picTrib53.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib53.Location = new System.Drawing.Point(144, 216);
			this.picTrib53.Name = "picTrib53";
			this.picTrib53.Size = new System.Drawing.Size(12, 12);
			this.picTrib53.TabIndex = 72;
			this.picTrib53.TabStop = false;
			this.picTrib53.Visible = false;
			this.picTrib53.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib44
			// 
			this.picTrib44.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib44.Location = new System.Drawing.Point(184, 184);
			this.picTrib44.Name = "picTrib44";
			this.picTrib44.Size = new System.Drawing.Size(12, 12);
			this.picTrib44.TabIndex = 73;
			this.picTrib44.TabStop = false;
			this.picTrib44.Visible = false;
			this.picTrib44.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib45
			// 
			this.picTrib45.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib45.Location = new System.Drawing.Point(216, 176);
			this.picTrib45.Name = "picTrib45";
			this.picTrib45.Size = new System.Drawing.Size(12, 12);
			this.picTrib45.TabIndex = 74;
			this.picTrib45.TabStop = false;
			this.picTrib45.Visible = false;
			this.picTrib45.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib54
			// 
			this.picTrib54.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib54.Location = new System.Drawing.Point(176, 224);
			this.picTrib54.Name = "picTrib54";
			this.picTrib54.Size = new System.Drawing.Size(12, 12);
			this.picTrib54.TabIndex = 75;
			this.picTrib54.TabStop = false;
			this.picTrib54.Visible = false;
			this.picTrib54.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// picTrib55
			// 
			this.picTrib55.BackColor = System.Drawing.SystemColors.Control;
			this.picTrib55.Location = new System.Drawing.Point(208, 216);
			this.picTrib55.Name = "picTrib55";
			this.picTrib55.Size = new System.Drawing.Size(12, 12);
			this.picTrib55.TabIndex = 76;
			this.picTrib55.TabStop = false;
			this.picTrib55.Visible = false;
			this.picTrib55.Click += new System.EventHandler(this.picTrib_Click);
			// 
			// tmrTick
			// 
			this.tmrTick.Interval = 1000;
			this.tmrTick.Tick += new System.EventHandler(this.tmrTick_Tick);
			// 
			// FormEncounter
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(234, 271);
			this.ControlBox = false;
			this.Controls.Add(this.picTrib55);
			this.Controls.Add(this.picTrib54);
			this.Controls.Add(this.picTrib45);
			this.Controls.Add(this.picTrib44);
			this.Controls.Add(this.picTrib53);
			this.Controls.Add(this.picTrib43);
			this.Controls.Add(this.picTrib52);
			this.Controls.Add(this.picTrib42);
			this.Controls.Add(this.picTrib51);
			this.Controls.Add(this.picTrib41);
			this.Controls.Add(this.picTrib35);
			this.Controls.Add(this.picTrib34);
			this.Controls.Add(this.picTrib33);
			this.Controls.Add(this.picTrib32);
			this.Controls.Add(this.picTrib31);
			this.Controls.Add(this.picTrib25);
			this.Controls.Add(this.picTrib24);
			this.Controls.Add(this.picTrib23);
			this.Controls.Add(this.picTrib22);
			this.Controls.Add(this.picTrib21);
			this.Controls.Add(this.picTrib15);
			this.Controls.Add(this.picTrib14);
			this.Controls.Add(this.picTrib13);
			this.Controls.Add(this.picTrib12);
			this.Controls.Add(this.picTrib11);
			this.Controls.Add(this.picTrib05);
			this.Controls.Add(this.picTrib01);
			this.Controls.Add(this.picTrib02);
			this.Controls.Add(this.picTrib03);
			this.Controls.Add(this.picTrib04);
			this.Controls.Add(this.picTrib30);
			this.Controls.Add(this.picTrib20);
			this.Controls.Add(this.picTrib40);
			this.Controls.Add(this.picTrib10);
			this.Controls.Add(this.picTrib50);
			this.Controls.Add(this.picTrib00);
			this.Controls.Add(this.picEncounterType);
			this.Controls.Add(this.picContinuous);
			this.Controls.Add(this.btnYield);
			this.Controls.Add(this.btnInt);
			this.Controls.Add(this.btnMeet);
			this.Controls.Add(this.btnPlunder);
			this.Controls.Add(this.btnTrade);
			this.Controls.Add(this.btnIgnore);
			this.Controls.Add(this.btnSurrender);
			this.Controls.Add(this.btnBribe);
			this.Controls.Add(this.btnSubmit);
			this.Controls.Add(this.btnFlee);
			this.Controls.Add(this.lblOpponentShields);
			this.Controls.Add(this.lblOpponentHull);
			this.Controls.Add(this.lblYouShields);
			this.Controls.Add(this.lblYouHull);
			this.Controls.Add(this.lblYouShip);
			this.Controls.Add(this.lblOpponentShip);
			this.Controls.Add(this.lblYouLabel);
			this.Controls.Add(this.lblOpponentLabel);
			this.Controls.Add(this.lblAction);
			this.Controls.Add(this.picShipOpponent);
			this.Controls.Add(this.picShipYou);
			this.Controls.Add(this.lblEncounter);
			this.Controls.Add(this.btnDrink);
			this.Controls.Add(this.btnBoard);
			this.Controls.Add(this.btnAttack);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormEncounter";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Encounter";
			this.ResumeLayout(false);

		}
		#endregion

		private void DisableAuto()
		{
			tmrTick.Stop();

			game.EncounterContinueFleeing		= false;
			game.EncounterContinueAttacking	= false;
			btnInt.Visible									= false;
			picContinuous.Visible						= false;
		}

		private void ExecuteAction()
		{
			if ((_result = game.EncounterExecuteAction(this)) == EncounterResult.Continue)
			{
				UpdateButtons();
				UpdateShipStats();

				lblEncounter.Text	= game.EncounterText;
				lblAction.Text		= game.EncounterAction;

				if (game.EncounterContinueFleeing || game.EncounterContinueAttacking)
					tmrTick.Start();
			}
			else
				Close();
		}

		private void Exit(EncounterResult result)
		{
			_result	= result;
			Close();
		}

		private void UpdateButtons()
		{
			bool[]	visible	= new bool[buttons.Length];

			switch (game.EncounterType)
			{
				case EncounterType.BottleGood:
				case EncounterType.BottleOld:
					visible[DRINK]			= true;
					visible[IGNORE]			= true;
					btnIgnore.Left			= btnDrink.Left + btnDrink.Width + 8;
					break;
				case EncounterType.CaptainAhab:
				case EncounterType.CaptainConrad:
				case EncounterType.CaptainHuie:
					visible[ATTACK]			= true;
					visible[IGNORE]			= true;
					visible[MEET]				= true;
					break;
				case EncounterType.DragonflyAttack:
				case EncounterType.FamousCaptainAttack:
				case EncounterType.ScorpionAttack:
				case EncounterType.SpaceMonsterAttack:
				case EncounterType.TraderAttack:
					visible[ATTACK]			= true;
					visible[FLEE]				= true;
					btnInt.Left					= btnFlee.Left + btnFlee.Width + 8;
					break;
				case EncounterType.DragonflyIgnore:
				case EncounterType.FamousCaptDisabled:
				case EncounterType.PoliceDisabled:
				case EncounterType.PoliceFlee:
				case EncounterType.PoliceIgnore:
				case EncounterType.PirateFlee:
				case EncounterType.PirateIgnore:
				case EncounterType.ScarabIgnore:
				case EncounterType.ScorpionIgnore:
				case EncounterType.SpaceMonsterIgnore:
				case EncounterType.TraderFlee:
				case EncounterType.TraderIgnore:
					visible[ATTACK]			= true;
					visible[IGNORE]			= true;
					break;
				case EncounterType.MarieCeleste:
					visible[BOARD]			= true;
					visible[IGNORE]			= true;
					btnIgnore.Left			= btnBoard.Left + btnBoard.Width + 8;
					break;
				case EncounterType.MarieCelestePolice:
					visible[ATTACK]			= true;
					visible[FLEE]				= true;
					visible[YIELD]			= true;
					visible[BRIBE]			= true;
					btnBribe.Left				= btnYield.Left + btnYield.Width + 8;
					break;
				case EncounterType.PirateAttack:
				case EncounterType.PoliceAttack:
				case EncounterType.PoliceSurrender:
				case EncounterType.ScarabAttack:
					visible[ATTACK]			= true;
					visible[FLEE]				= true;
					visible[SURRENDER]	= true;
					btnInt.Left					= btnSurrender.Left + btnSurrender.Width + 8;
					break;
				case EncounterType.PirateDisabled:
				case EncounterType.PirateSurrender:
				case EncounterType.TraderDisabled:
				case EncounterType.TraderSurrender:
					visible[ATTACK]			= true;
					visible[PLUNDER]		= true;
					break;
				case EncounterType.PoliceInspect:
					visible[ATTACK]			= true;
					visible[FLEE]				= true;
					visible[SUBMIT]			= true;
					visible[BRIBE]			= true;
					break;
				case EncounterType.TraderBuy:
				case EncounterType.TraderSell:
					visible[ATTACK]			= true;
					visible[IGNORE]			= true;
					visible[TRADE]			= true;
					break;
			}

			if (game.EncounterContinueAttacking || game.EncounterContinueFleeing)
				visible[INT]	= true;

			for (int i = 0; i < visible.Length; i++)
			{
				if (visible[i] != buttons[i].Visible)
				{
					buttons[i].Visible	= visible[i];
					if (i == INT)
						picContinuous.Visible	= visible[i];
				}
			}

			if (picContinuous.Visible)
				picContinuous.Image	= ilContinuous.Images[contImg = (contImg + 1) % 2];
		}

		private void UpdateShipInfo()
		{
			lblYouShip.Text				= cmdrship.Name;
			lblOpponentShip.Text	= opponent.Name;

			UpdateShipStats();
		}

		private void UpdateShipStats()
		{
			lblYouHull.Text					= cmdrship.HullText;
			lblYouShields.Text			= cmdrship.ShieldText;
			lblOpponentHull.Text		= opponent.HullText;
			lblOpponentShields.Text	= opponent.ShieldText;

			picShipYou.Refresh();
			picShipOpponent.Refresh();
		}

		private void UpdateTribbles()
		{
			PictureBox[]	tribbles	= new PictureBox[]
																{
																	picTrib00, picTrib01, picTrib02, picTrib03, picTrib04, picTrib05,
																	picTrib10, picTrib11, picTrib12, picTrib13, picTrib14, picTrib15,
																	picTrib20, picTrib21, picTrib22, picTrib23, picTrib24, picTrib25,
																	picTrib30, picTrib31, picTrib32, picTrib33, picTrib34, picTrib35,
																	picTrib40, picTrib41, picTrib42, picTrib43, picTrib44, picTrib45,
																	picTrib50, picTrib51, picTrib52, picTrib53, picTrib54, picTrib55
																};
			int						toShow		= Math.Min(tribbles.Length, (int)Math.Sqrt(cmdrship.Tribbles /
																Math.Ceiling(Consts.MaxTribbles / Math.Pow(tribbles.Length + 1, 2))));

			for (int i = 0; i < toShow; i++)
			{
				int	index	= Functions.GetRandom(tribbles.Length);
				while (tribbles[index].Visible)
					index	= (index + 1) % tribbles.Length;

				tribbles[index].Image		= ilTribbles.Images[Functions.GetRandom(ilTribbles.Images.Count)];
				tribbles[index].Visible	= true;
			}
		}

		#endregion

		#region Event Handlers

		private void btnAttack_Click(object sender, System.EventArgs e)
		{
			DisableAuto();

			if (game.EncounterVerifyAttack(this))
				ExecuteAction();
		}

		private void btnBoard_Click(object sender, System.EventArgs e)
		{
			if (game.EncounterVerifyBoard(this))
				Exit(EncounterResult.Normal);
		}

		private void btnBribe_Click(object sender, System.EventArgs e)
		{
			if (game.EncounterVerifyBribe(this))
				Exit(EncounterResult.Normal);
		}

		private void btnDrink_Click(object sender, System.EventArgs e)
		{
			game.EncounterDrink(this);

			Exit(EncounterResult.Normal);
		}

		private void btnFlee_Click(object sender, System.EventArgs e)
		{
			DisableAuto();

			if (game.EncounterVerifyFlee(this))
				ExecuteAction();
		}

		private void btnIgnore_Click(object sender, System.EventArgs e)
		{
			DisableAuto();

			Exit(EncounterResult.Normal);
		}

		private void btnInt_Click(object sender, System.EventArgs e)
		{
			DisableAuto();
		}

		private void btnMeet_Click(object sender, System.EventArgs e)
		{
			game.EncounterMeet(this);

			Exit(EncounterResult.Normal);
		}

		private void btnPlunder_Click(object sender, System.EventArgs e)
		{
			DisableAuto();

			game.EncounterPlunder(this);

			Exit(EncounterResult.Normal);
		}

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if (game.EncounterVerifySubmit(this))
				Exit(cmdrship.IllegalSpecialCargo ? EncounterResult.Arrested : EncounterResult.Normal);
		}

		private void btnSurrender_Click(object sender, System.EventArgs e)
		{
			DisableAuto();

			if ((_result = game.EncounterVerifySurrender(this)) != EncounterResult.Continue)
				Close();
		}

		private void btnTrade_Click(object sender, System.EventArgs e)
		{
			game.EncounterTrade(this);

			Exit(EncounterResult.Normal);
		}

		private void btnYield_Click(object sender, System.EventArgs e)
		{
			if ((_result = game.EncounterVerifyYield(this)) != EncounterResult.Continue)
				Close();
		}

		private void picShipOpponent_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Functions.PaintShipImage(opponent, e.Graphics, picShipOpponent.BackColor);
		}

		private void picShipYou_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Functions.PaintShipImage(cmdrship, e.Graphics, picShipYou.BackColor);
		}

		private void picTrib_Click(object sender, System.EventArgs e)
		{
			FormAlert.Alert(AlertType.TribblesSqueek, this);
		}

		private void tmrTick_Tick(object sender, System.EventArgs e)
		{
			DisableAuto();

			ExecuteAction();
		}

		#endregion

		#region Properties

		public EncounterResult Result
		{
			get
			{
				return _result;
			}
		}

		#endregion
	}
}
