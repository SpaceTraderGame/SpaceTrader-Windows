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
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Fryz.Apps.SpaceTrader
{
	public class SpaceTrader : System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.Button btnDesign;
		private System.Windows.Forms.Button btnNews;
		private System.Windows.Forms.Button btnSpecial;
		private System.Windows.Forms.Button btnMerc;
		private System.Windows.Forms.Button btnFuel;
		private System.Windows.Forms.Button btnRepair;
		private System.Windows.Forms.Button btnBuyShip;
		private System.Windows.Forms.Button btnEquip;
		private System.Windows.Forms.Button btnPod;
		private System.Windows.Forms.Button btnBuyMax0;
		private System.Windows.Forms.Button btnBuyQty0;
		private System.Windows.Forms.Button btnSellQty0;
		private System.Windows.Forms.Button btnSellAll0;
		private System.Windows.Forms.Button btnBuyMax1;
		private System.Windows.Forms.Button btnBuyQty1;
		private System.Windows.Forms.Button btnSellQty1;
		private System.Windows.Forms.Button btnSellAll1;
		private System.Windows.Forms.Button btnSellQty2;
		private System.Windows.Forms.Button btnSellAll2;
		private System.Windows.Forms.Button btnBuyQty2;
		private System.Windows.Forms.Button btnBuyMax2;
		private System.Windows.Forms.Button btnSellQty3;
		private System.Windows.Forms.Button btnSellAll3;
		private System.Windows.Forms.Button btnBuyQty3;
		private System.Windows.Forms.Button btnBuyMax3;
		private System.Windows.Forms.Button btnSellQty4;
		private System.Windows.Forms.Button btnSellAll4;
		private System.Windows.Forms.Button btnBuyQty4;
		private System.Windows.Forms.Button btnBuyMax4;
		private System.Windows.Forms.Button btnSellQty5;
		private System.Windows.Forms.Button btnSellAll5;
		private System.Windows.Forms.Button btnBuyQty5;
		private System.Windows.Forms.Button btnBuyMax5;
		private System.Windows.Forms.Button btnSellQty6;
		private System.Windows.Forms.Button btnSellAll6;
		private System.Windows.Forms.Button btnBuyQty6;
		private System.Windows.Forms.Button btnBuyMax6;
		private System.Windows.Forms.Button btnSellQty7;
		private System.Windows.Forms.Button btnSellAll7;
		private System.Windows.Forms.Button btnBuyQty7;
		private System.Windows.Forms.Button btnBuyMax7;
		private System.Windows.Forms.Button btnSellQty8;
		private System.Windows.Forms.Button btnSellAll8;
		private System.Windows.Forms.Button btnBuyQty8;
		private System.Windows.Forms.Button btnBuyMax8;
		private System.Windows.Forms.Button btnSellQty9;
		private System.Windows.Forms.Button btnSellAll9;
		private System.Windows.Forms.Button btnBuyQty9;
		private System.Windows.Forms.Button btnBuyMax9;
		private System.Windows.Forms.Button btnJump;
		private System.Windows.Forms.Button btnFind;
		private System.Windows.Forms.Button btnPrevSystem;
		private System.Windows.Forms.Button btnNextSystem;
		private System.Windows.Forms.Button btnTrack;
		private System.Windows.Forms.Button btnWarp;
		private System.Windows.Forms.ImageList ilChartImages;
		private System.Windows.Forms.ImageList ilDirectionImages;
		private System.Windows.Forms.ImageList ilEquipmentImages;
		private System.Windows.Forms.ImageList ilShipImages;
		private System.Windows.Forms.Label lblBuy;
		private System.Windows.Forms.Label lblBuyPrice0;
		private System.Windows.Forms.Label lblBuyPrice1;
		private System.Windows.Forms.Label lblBuyPrice2;
		private System.Windows.Forms.Label lblBuyPrice3;
		private System.Windows.Forms.Label lblBuyPrice4;
		private System.Windows.Forms.Label lblBuyPrice5;
		private System.Windows.Forms.Label lblBuyPrice6;
		private System.Windows.Forms.Label lblBuyPrice7;
		private System.Windows.Forms.Label lblBuyPrice8;
		private System.Windows.Forms.Label lblBuyPrice9;
		private System.Windows.Forms.Label lblEquipForSale;
		private System.Windows.Forms.Label lblEscapePod;
		private System.Windows.Forms.Label lblFuelCost;
		private System.Windows.Forms.Label lblFuelStatus;
		private System.Windows.Forms.Label lblHullStatus;
		private System.Windows.Forms.Label lblRepairCost;
		private System.Windows.Forms.Label lblSell;
		private System.Windows.Forms.Label lblSellPrice0;
		private System.Windows.Forms.Label lblSellPrice1;
		private System.Windows.Forms.Label lblSellPrice2;
		private System.Windows.Forms.Label lblSellPrice3;
		private System.Windows.Forms.Label lblSellPrice4;
		private System.Windows.Forms.Label lblSellPrice5;
		private System.Windows.Forms.Label lblSellPrice6;
		private System.Windows.Forms.Label lblSellPrice7;
		private System.Windows.Forms.Label lblSellPrice8;
		private System.Windows.Forms.Label lblSellPrice9;
		private System.Windows.Forms.Label lblShipsForSale;
		private System.Windows.Forms.Label lblSystemGovtLabel;
		private System.Windows.Forms.Label lblSystemName;
		private System.Windows.Forms.Label lblSystemNameLabel;
		private System.Windows.Forms.Label lblSystemPirates;
		private System.Windows.Forms.Label lblSystemPiratesLabel;
		private System.Windows.Forms.Label lblSystemPolice;
		private System.Windows.Forms.Label lblSystemPoliceLabel;
		private System.Windows.Forms.Label lblSystemPolSys;
		private System.Windows.Forms.Label lblSystemPressure;
		private System.Windows.Forms.Label lblSystemPressurePre;
		private System.Windows.Forms.Label lblSystemResource;
		private System.Windows.Forms.Label lblSystemResourseLabel;
		private System.Windows.Forms.Label lblSystemSize;
		private System.Windows.Forms.Label lblSystemSizeLabel;
		private System.Windows.Forms.Label lblSystemTech;
		private System.Windows.Forms.Label lblSystemTechLabel;
		private System.Windows.Forms.Label lblTargetDiff0;
		private System.Windows.Forms.Label lblTargetDiff1;
		private System.Windows.Forms.Label lblTargetDiff2;
		private System.Windows.Forms.Label lblTargetDiff3;
		private System.Windows.Forms.Label lblTargetDiff4;
		private System.Windows.Forms.Label lblTargetDiff5;
		private System.Windows.Forms.Label lblTargetDiff6;
		private System.Windows.Forms.Label lblTargetDiff7;
		private System.Windows.Forms.Label lblTargetDiff8;
		private System.Windows.Forms.Label lblTargetDiff9;
		private System.Windows.Forms.Label lblTargetDiffLabel;
		private System.Windows.Forms.Label lblTargetDistance;
		private System.Windows.Forms.Label lblTargetDistanceLabel;
		private System.Windows.Forms.Label lblTargetGovtLabel;
		private System.Windows.Forms.Label lblTargetName;
		private System.Windows.Forms.Label lblTargetNameLabel;
		private System.Windows.Forms.Label lblTargetOutOfRange;
		private System.Windows.Forms.Label lblTargetPct0;
		private System.Windows.Forms.Label lblTargetPct1;
		private System.Windows.Forms.Label lblTargetPct2;
		private System.Windows.Forms.Label lblTargetPct3;
		private System.Windows.Forms.Label lblTargetPct4;
		private System.Windows.Forms.Label lblTargetPct5;
		private System.Windows.Forms.Label lblTargetPct6;
		private System.Windows.Forms.Label lblTargetPct7;
		private System.Windows.Forms.Label lblTargetPct8;
		private System.Windows.Forms.Label lblTargetPct9;
		private System.Windows.Forms.Label lblTargetPctLabel;
		private System.Windows.Forms.Label lblTargetPirates;
		private System.Windows.Forms.Label lblTargetPiratesLabel;
		private System.Windows.Forms.Label lblTargetPolice;
		private System.Windows.Forms.Label lblTargetPoliceLabel;
		private System.Windows.Forms.Label lblTargetPolSys;
		private System.Windows.Forms.Label lblTargetPrice0;
		private System.Windows.Forms.Label lblTargetPrice1;
		private System.Windows.Forms.Label lblTargetPrice2;
		private System.Windows.Forms.Label lblTargetPrice3;
		private System.Windows.Forms.Label lblTargetPrice4;
		private System.Windows.Forms.Label lblTargetPrice5;
		private System.Windows.Forms.Label lblTargetPrice6;
		private System.Windows.Forms.Label lblTargetPrice7;
		private System.Windows.Forms.Label lblTargetPrice8;
		private System.Windows.Forms.Label lblTargetPrice9;
		private System.Windows.Forms.Label lblTargetPriceLabel;
		private System.Windows.Forms.Label lblTargetResource;
		private System.Windows.Forms.Label lblTargetResourceLabel;
		private System.Windows.Forms.Label lblTargetSize;
		private System.Windows.Forms.Label lblTargetTech;
		private System.Windows.Forms.Label lblTargetTechLabel;
		private System.Windows.Forms.Label lblTargetSizeLabel;
		private System.Windows.Forms.Label lblTradeCmdty0;
		private System.Windows.Forms.Label lblTradeCmdty1;
		private System.Windows.Forms.Label lblTradeCmdty2;
		private System.Windows.Forms.Label lblTradeCmdty3;
		private System.Windows.Forms.Label lblTradeCmdty4;
		private System.Windows.Forms.Label lblTradeCmdty5;
		private System.Windows.Forms.Label lblTradeCmdty6;
		private System.Windows.Forms.Label lblTradeCmdty7;
		private System.Windows.Forms.Label lblTradeCmdty8;
		private System.Windows.Forms.Label lblTradeCmdty9;
		private System.Windows.Forms.Label lblTradeTarget;
		private System.Windows.Forms.Label lblWormhole;
		private System.Windows.Forms.Label lblWormholeLabel;
		private System.Windows.Forms.GroupBox boxCargo;
		private System.Windows.Forms.GroupBox boxDock;
		private System.Windows.Forms.GroupBox boxGalacticChart;
		private System.Windows.Forms.GroupBox boxShipYard;
		private System.Windows.Forms.GroupBox boxShortRangeChart;
		private System.Windows.Forms.GroupBox boxSystem;
		private System.Windows.Forms.GroupBox boxTargetSystem;
		private System.Windows.Forms.MainMenu mnuMain;
		private System.Windows.Forms.MenuItem mnuGame;
		private System.Windows.Forms.MenuItem mnuGameExit;
		private System.Windows.Forms.MenuItem mnuGameLine1;
		private System.Windows.Forms.MenuItem mnuGameLine2;
		private System.Windows.Forms.MenuItem mnuGameLoad;
		private System.Windows.Forms.MenuItem mnuGameNew;
		private System.Windows.Forms.MenuItem mnuGameSave;
		private System.Windows.Forms.MenuItem mnuGameSaveAs;
		private System.Windows.Forms.MenuItem mnuHelp;
		private System.Windows.Forms.MenuItem mnuHelpAbout;
		private System.Windows.Forms.MenuItem mnuHighScores;
		private System.Windows.Forms.MenuItem mnuOptions;
		private System.Windows.Forms.MenuItem mnuRetire;
		private System.Windows.Forms.MenuItem mnuView;
		private System.Windows.Forms.MenuItem mnuViewBank;
		private System.Windows.Forms.MenuItem mnuViewCommander;
		private System.Windows.Forms.MenuItem mnuViewLine1;
		private System.Windows.Forms.MenuItem mnuViewLine2;
		private System.Windows.Forms.MenuItem mnuViewPersonnel;
		private System.Windows.Forms.MenuItem mnuViewQuests;
		private System.Windows.Forms.MenuItem mnuViewShip;
		private System.Windows.Forms.OpenFileDialog dlgOpen;
		private System.Windows.Forms.PictureBox picCargoLine0;
		private System.Windows.Forms.PictureBox picCargoLine1;
		private System.Windows.Forms.PictureBox picCargoLine2;
		private System.Windows.Forms.PictureBox picCargoLine3;
		private System.Windows.Forms.PictureBox picGalacticChart;
		private System.Windows.Forms.PictureBox picLine;
		private System.Windows.Forms.PictureBox picShortRangeChart;
		private System.Windows.Forms.SaveFileDialog dlgSave;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.StatusBarPanel statusBarPanelBays;
		private System.Windows.Forms.StatusBarPanel statusBarPanelCash;
		private System.Windows.Forms.StatusBarPanel statusBarPanelCosts;
		private System.Windows.Forms.StatusBarPanel statusBarPanelExtra;
		private System.Windows.Forms.ToolTip tipSpecial;
		private System.Windows.Forms.ToolTip tipMerc;

		private System.ComponentModel.IContainer components;

		private Label[]				lblSellPrice;
		private Label[]				lblBuyPrice;
		private Label[]				lblTargetPrice;
		private Label[]				lblTargetDiff;
		private Label[]				lblTargetPct;
		private Button[]			btnSellQty;
		private Button[]			btnSellAll;
		private Button[]			btnBuyQty;
		private Button[]			btnBuyMax;

		#endregion

		#region Member Declarations

		private const string	SAVE_ARRIVAL		= "autosave_arrival.sav";
		private const string	SAVE_DEPARTURE	= "autosave_departure.sav";

		private const	int			OFF_X						= 3;
		private const	int			OFF_Y						= 3;
		private const	int			OFF_X_WORM			= OFF_X + 1;
		private const	int			IMG_G_N					= 0;
		private const	int			IMG_G_V					= 1;
		private const	int			IMG_G_W					= 2;
		private const	int			IMG_S_N					= 3;
		private const	int			IMG_S_NS				= 4;
		private const	int			IMG_S_V					= 5;
		private const	int			IMG_S_VS				= 6;
		private const	int			IMG_S_W					= 7;

		private Game					game;

		private Pen						DEFAULT_PEN		= new Pen(Color.Black);
		private	Brush					DEFAULT_BRUSH	= new SolidBrush(Color.White);

		private string				SaveGameFile	= null;
		private int						SaveGameDays	= -1;

		#endregion

		#region Methods

		public SpaceTrader(string loadFileName)
		{
			InitializeComponent();
			InitFileStructure();

			#region Arrays of Cargo controls
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
				lblSellPrice8,
				lblSellPrice9
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

			lblTargetPrice	= new Label[]
			{
				lblTargetPrice0,
				lblTargetPrice1,
				lblTargetPrice2,
				lblTargetPrice3,
				lblTargetPrice4,
				lblTargetPrice5,
				lblTargetPrice6,
				lblTargetPrice7,
				lblTargetPrice8,
				lblTargetPrice9
			};

			lblTargetDiff	= new Label[]
			{
				lblTargetDiff0,
				lblTargetDiff1,
				lblTargetDiff2,
				lblTargetDiff3,
				lblTargetDiff4,
				lblTargetDiff5,
				lblTargetDiff6,
				lblTargetDiff7,
				lblTargetDiff8,
				lblTargetDiff9
			};

			lblTargetPct	= new Label[]
			{
				lblTargetPct0,
				lblTargetPct1,
				lblTargetPct2,
				lblTargetPct3,
				lblTargetPct4,
				lblTargetPct5,
				lblTargetPct6,
				lblTargetPct7,
				lblTargetPct8,
				lblTargetPct9
			};

			btnSellQty	= new Button[]
			{
				btnSellQty0,
				btnSellQty1,
				btnSellQty2,
				btnSellQty3,
				btnSellQty4,
				btnSellQty5,
				btnSellQty6,
				btnSellQty7,
				btnSellQty8,
				btnSellQty9
			};

			btnSellAll	= new Button[]
			{
				btnSellAll0,
				btnSellAll1,
				btnSellAll2,
				btnSellAll3,
				btnSellAll4,
				btnSellAll5,
				btnSellAll6,
				btnSellAll7,
				btnSellAll8,
				btnSellAll9
			};

			btnBuyQty	= new Button[]
			{
				btnBuyQty0,
				btnBuyQty1,
				btnBuyQty2,
				btnBuyQty3,
				btnBuyQty4,
				btnBuyQty5,
				btnBuyQty6,
				btnBuyQty7,
				btnBuyQty8,
				btnBuyQty9
			};

			btnBuyMax	= new Button[]
			{
				btnBuyMax0,
				btnBuyMax1,
				btnBuyMax2,
				btnBuyMax3,
				btnBuyMax4,
				btnBuyMax5,
				btnBuyMax6,
				btnBuyMax7,
				btnBuyMax8,
				btnBuyMax9
			};
			#endregion

			if (loadFileName != null)
				LoadGame(loadFileName);

			UpdateAll();
		}

		[STAThread]
		static void Main(string[] args)
		{
			Application.Run(new SpaceTrader(args.Length > 0 ? args[0] : null));
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpaceTrader));
			this.mnuMain = new System.Windows.Forms.MainMenu(this.components);
			this.mnuGame = new System.Windows.Forms.MenuItem();
			this.mnuGameNew = new System.Windows.Forms.MenuItem();
			this.mnuGameLoad = new System.Windows.Forms.MenuItem();
			this.mnuGameSave = new System.Windows.Forms.MenuItem();
			this.mnuGameSaveAs = new System.Windows.Forms.MenuItem();
			this.mnuGameLine1 = new System.Windows.Forms.MenuItem();
			this.mnuRetire = new System.Windows.Forms.MenuItem();
			this.mnuGameLine2 = new System.Windows.Forms.MenuItem();
			this.mnuGameExit = new System.Windows.Forms.MenuItem();
			this.mnuView = new System.Windows.Forms.MenuItem();
			this.mnuViewCommander = new System.Windows.Forms.MenuItem();
			this.mnuViewShip = new System.Windows.Forms.MenuItem();
			this.mnuViewPersonnel = new System.Windows.Forms.MenuItem();
			this.mnuViewQuests = new System.Windows.Forms.MenuItem();
			this.mnuViewBank = new System.Windows.Forms.MenuItem();
			this.mnuViewLine1 = new System.Windows.Forms.MenuItem();
			this.mnuHighScores = new System.Windows.Forms.MenuItem();
			this.mnuViewLine2 = new System.Windows.Forms.MenuItem();
			this.mnuOptions = new System.Windows.Forms.MenuItem();
			this.mnuHelp = new System.Windows.Forms.MenuItem();
			this.mnuHelpAbout = new System.Windows.Forms.MenuItem();
			this.picGalacticChart = new System.Windows.Forms.PictureBox();
			this.picShortRangeChart = new System.Windows.Forms.PictureBox();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.statusBarPanelCash = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanelBays = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanelCosts = new System.Windows.Forms.StatusBarPanel();
			this.statusBarPanelExtra = new System.Windows.Forms.StatusBarPanel();
			this.boxShortRangeChart = new System.Windows.Forms.GroupBox();
			this.boxGalacticChart = new System.Windows.Forms.GroupBox();
			this.lblWormhole = new System.Windows.Forms.Label();
			this.lblWormholeLabel = new System.Windows.Forms.Label();
			this.btnJump = new System.Windows.Forms.Button();
			this.btnFind = new System.Windows.Forms.Button();
			this.boxTargetSystem = new System.Windows.Forms.GroupBox();
			this.btnTrack = new System.Windows.Forms.Button();
			this.btnNextSystem = new System.Windows.Forms.Button();
			this.btnPrevSystem = new System.Windows.Forms.Button();
			this.lblTargetOutOfRange = new System.Windows.Forms.Label();
			this.btnWarp = new System.Windows.Forms.Button();
			this.lblTargetPolSys = new System.Windows.Forms.Label();
			this.lblTargetSize = new System.Windows.Forms.Label();
			this.lblTargetTech = new System.Windows.Forms.Label();
			this.lblTargetDistance = new System.Windows.Forms.Label();
			this.lblTargetPirates = new System.Windows.Forms.Label();
			this.lblTargetPolice = new System.Windows.Forms.Label();
			this.lblTargetResource = new System.Windows.Forms.Label();
			this.lblTargetDistanceLabel = new System.Windows.Forms.Label();
			this.lblTargetPiratesLabel = new System.Windows.Forms.Label();
			this.lblTargetPoliceLabel = new System.Windows.Forms.Label();
			this.lblTargetResourceLabel = new System.Windows.Forms.Label();
			this.lblTargetGovtLabel = new System.Windows.Forms.Label();
			this.lblTargetTechLabel = new System.Windows.Forms.Label();
			this.lblTargetSizeLabel = new System.Windows.Forms.Label();
			this.lblTargetName = new System.Windows.Forms.Label();
			this.lblTargetNameLabel = new System.Windows.Forms.Label();
			this.boxCargo = new System.Windows.Forms.GroupBox();
			this.picCargoLine3 = new System.Windows.Forms.PictureBox();
			this.picCargoLine2 = new System.Windows.Forms.PictureBox();
			this.picCargoLine0 = new System.Windows.Forms.PictureBox();
			this.picCargoLine1 = new System.Windows.Forms.PictureBox();
			this.lblTargetPct9 = new System.Windows.Forms.Label();
			this.lblTargetDiff9 = new System.Windows.Forms.Label();
			this.lblTargetPrice9 = new System.Windows.Forms.Label();
			this.btnBuyMax9 = new System.Windows.Forms.Button();
			this.btnBuyQty9 = new System.Windows.Forms.Button();
			this.lblBuyPrice9 = new System.Windows.Forms.Label();
			this.btnSellAll9 = new System.Windows.Forms.Button();
			this.btnSellQty9 = new System.Windows.Forms.Button();
			this.lblSellPrice9 = new System.Windows.Forms.Label();
			this.lblTargetPct8 = new System.Windows.Forms.Label();
			this.lblTargetDiff8 = new System.Windows.Forms.Label();
			this.lblTargetPrice8 = new System.Windows.Forms.Label();
			this.btnBuyMax8 = new System.Windows.Forms.Button();
			this.btnBuyQty8 = new System.Windows.Forms.Button();
			this.lblBuyPrice8 = new System.Windows.Forms.Label();
			this.btnSellAll8 = new System.Windows.Forms.Button();
			this.btnSellQty8 = new System.Windows.Forms.Button();
			this.lblSellPrice8 = new System.Windows.Forms.Label();
			this.lblTargetPct7 = new System.Windows.Forms.Label();
			this.lblTargetDiff7 = new System.Windows.Forms.Label();
			this.lblTargetPrice7 = new System.Windows.Forms.Label();
			this.btnBuyMax7 = new System.Windows.Forms.Button();
			this.btnBuyQty7 = new System.Windows.Forms.Button();
			this.lblBuyPrice7 = new System.Windows.Forms.Label();
			this.btnSellAll7 = new System.Windows.Forms.Button();
			this.btnSellQty7 = new System.Windows.Forms.Button();
			this.lblSellPrice7 = new System.Windows.Forms.Label();
			this.lblTargetPct6 = new System.Windows.Forms.Label();
			this.lblTargetDiff6 = new System.Windows.Forms.Label();
			this.lblTargetPrice6 = new System.Windows.Forms.Label();
			this.btnBuyMax6 = new System.Windows.Forms.Button();
			this.btnBuyQty6 = new System.Windows.Forms.Button();
			this.lblBuyPrice6 = new System.Windows.Forms.Label();
			this.btnSellAll6 = new System.Windows.Forms.Button();
			this.btnSellQty6 = new System.Windows.Forms.Button();
			this.lblSellPrice6 = new System.Windows.Forms.Label();
			this.lblTargetPct5 = new System.Windows.Forms.Label();
			this.lblTargetDiff5 = new System.Windows.Forms.Label();
			this.lblTargetPrice5 = new System.Windows.Forms.Label();
			this.btnBuyMax5 = new System.Windows.Forms.Button();
			this.btnBuyQty5 = new System.Windows.Forms.Button();
			this.lblBuyPrice5 = new System.Windows.Forms.Label();
			this.btnSellAll5 = new System.Windows.Forms.Button();
			this.btnSellQty5 = new System.Windows.Forms.Button();
			this.lblSellPrice5 = new System.Windows.Forms.Label();
			this.lblTargetPct4 = new System.Windows.Forms.Label();
			this.lblTargetDiff4 = new System.Windows.Forms.Label();
			this.lblTargetPrice4 = new System.Windows.Forms.Label();
			this.btnBuyMax4 = new System.Windows.Forms.Button();
			this.btnBuyQty4 = new System.Windows.Forms.Button();
			this.lblBuyPrice4 = new System.Windows.Forms.Label();
			this.btnSellAll4 = new System.Windows.Forms.Button();
			this.btnSellQty4 = new System.Windows.Forms.Button();
			this.lblSellPrice4 = new System.Windows.Forms.Label();
			this.lblTargetPct3 = new System.Windows.Forms.Label();
			this.lblTargetDiff3 = new System.Windows.Forms.Label();
			this.lblTargetPrice3 = new System.Windows.Forms.Label();
			this.btnBuyMax3 = new System.Windows.Forms.Button();
			this.btnBuyQty3 = new System.Windows.Forms.Button();
			this.lblBuyPrice3 = new System.Windows.Forms.Label();
			this.btnSellAll3 = new System.Windows.Forms.Button();
			this.btnSellQty3 = new System.Windows.Forms.Button();
			this.lblSellPrice3 = new System.Windows.Forms.Label();
			this.lblTargetPct2 = new System.Windows.Forms.Label();
			this.lblTargetDiff2 = new System.Windows.Forms.Label();
			this.lblTargetPrice2 = new System.Windows.Forms.Label();
			this.btnBuyMax2 = new System.Windows.Forms.Button();
			this.btnBuyQty2 = new System.Windows.Forms.Button();
			this.lblBuyPrice2 = new System.Windows.Forms.Label();
			this.btnSellAll2 = new System.Windows.Forms.Button();
			this.btnSellQty2 = new System.Windows.Forms.Button();
			this.lblSellPrice2 = new System.Windows.Forms.Label();
			this.lblTargetPct1 = new System.Windows.Forms.Label();
			this.lblTargetDiff1 = new System.Windows.Forms.Label();
			this.lblTargetPrice1 = new System.Windows.Forms.Label();
			this.btnBuyMax1 = new System.Windows.Forms.Button();
			this.btnBuyQty1 = new System.Windows.Forms.Button();
			this.lblBuyPrice1 = new System.Windows.Forms.Label();
			this.lblTargetPctLabel = new System.Windows.Forms.Label();
			this.lblTargetDiffLabel = new System.Windows.Forms.Label();
			this.lblTargetPriceLabel = new System.Windows.Forms.Label();
			this.lblTargetPct0 = new System.Windows.Forms.Label();
			this.lblTargetDiff0 = new System.Windows.Forms.Label();
			this.lblTargetPrice0 = new System.Windows.Forms.Label();
			this.btnBuyMax0 = new System.Windows.Forms.Button();
			this.btnBuyQty0 = new System.Windows.Forms.Button();
			this.lblBuyPrice0 = new System.Windows.Forms.Label();
			this.btnSellAll1 = new System.Windows.Forms.Button();
			this.btnSellQty1 = new System.Windows.Forms.Button();
			this.lblSellPrice1 = new System.Windows.Forms.Label();
			this.btnSellAll0 = new System.Windows.Forms.Button();
			this.btnSellQty0 = new System.Windows.Forms.Button();
			this.lblSellPrice0 = new System.Windows.Forms.Label();
			this.lblTradeTarget = new System.Windows.Forms.Label();
			this.lblBuy = new System.Windows.Forms.Label();
			this.lblSell = new System.Windows.Forms.Label();
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
			this.boxSystem = new System.Windows.Forms.GroupBox();
			this.btnMerc = new System.Windows.Forms.Button();
			this.btnSpecial = new System.Windows.Forms.Button();
			this.btnNews = new System.Windows.Forms.Button();
			this.lblSystemPressure = new System.Windows.Forms.Label();
			this.lblSystemPressurePre = new System.Windows.Forms.Label();
			this.lblSystemPolSys = new System.Windows.Forms.Label();
			this.lblSystemSize = new System.Windows.Forms.Label();
			this.lblSystemTech = new System.Windows.Forms.Label();
			this.lblSystemPirates = new System.Windows.Forms.Label();
			this.lblSystemPolice = new System.Windows.Forms.Label();
			this.lblSystemResource = new System.Windows.Forms.Label();
			this.lblSystemPiratesLabel = new System.Windows.Forms.Label();
			this.lblSystemPoliceLabel = new System.Windows.Forms.Label();
			this.lblSystemResourseLabel = new System.Windows.Forms.Label();
			this.lblSystemGovtLabel = new System.Windows.Forms.Label();
			this.lblSystemTechLabel = new System.Windows.Forms.Label();
			this.lblSystemSizeLabel = new System.Windows.Forms.Label();
			this.lblSystemName = new System.Windows.Forms.Label();
			this.lblSystemNameLabel = new System.Windows.Forms.Label();
			this.boxShipYard = new System.Windows.Forms.GroupBox();
			this.btnDesign = new System.Windows.Forms.Button();
			this.btnPod = new System.Windows.Forms.Button();
			this.lblEscapePod = new System.Windows.Forms.Label();
			this.btnEquip = new System.Windows.Forms.Button();
			this.btnBuyShip = new System.Windows.Forms.Button();
			this.lblEquipForSale = new System.Windows.Forms.Label();
			this.lblShipsForSale = new System.Windows.Forms.Label();
			this.boxDock = new System.Windows.Forms.GroupBox();
			this.btnRepair = new System.Windows.Forms.Button();
			this.btnFuel = new System.Windows.Forms.Button();
			this.lblFuelStatus = new System.Windows.Forms.Label();
			this.lblFuelCost = new System.Windows.Forms.Label();
			this.lblHullStatus = new System.Windows.Forms.Label();
			this.lblRepairCost = new System.Windows.Forms.Label();
			this.picLine = new System.Windows.Forms.PictureBox();
			this.dlgOpen = new System.Windows.Forms.OpenFileDialog();
			this.dlgSave = new System.Windows.Forms.SaveFileDialog();
			this.ilChartImages = new System.Windows.Forms.ImageList(this.components);
			this.ilShipImages = new System.Windows.Forms.ImageList(this.components);
			this.ilDirectionImages = new System.Windows.Forms.ImageList(this.components);
			this.tipSpecial = new System.Windows.Forms.ToolTip(this.components);
			this.tipMerc = new System.Windows.Forms.ToolTip(this.components);
			this.ilEquipmentImages = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.picGalacticChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picShortRangeChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelCash)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelBays)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelCosts)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelExtra)).BeginInit();
			this.boxShortRangeChart.SuspendLayout();
			this.boxGalacticChart.SuspendLayout();
			this.boxTargetSystem.SuspendLayout();
			this.boxCargo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picCargoLine3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picCargoLine2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picCargoLine0)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picCargoLine1)).BeginInit();
			this.boxSystem.SuspendLayout();
			this.boxShipYard.SuspendLayout();
			this.boxDock.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picLine)).BeginInit();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuGame,
            this.mnuView,
            this.mnuHelp});
			// 
			// mnuGame
			// 
			this.mnuGame.Index = 0;
			this.mnuGame.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuGameNew,
            this.mnuGameLoad,
            this.mnuGameSave,
            this.mnuGameSaveAs,
            this.mnuGameLine1,
            this.mnuRetire,
            this.mnuGameLine2,
            this.mnuGameExit});
			this.mnuGame.Text = "&Game";
			// 
			// mnuGameNew
			// 
			this.mnuGameNew.Index = 0;
			this.mnuGameNew.Text = "&New...";
			this.mnuGameNew.Click += new System.EventHandler(this.mnuGameNew_Click);
			// 
			// mnuGameLoad
			// 
			this.mnuGameLoad.Index = 1;
			this.mnuGameLoad.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
			this.mnuGameLoad.Text = "&Load...";
			this.mnuGameLoad.Click += new System.EventHandler(this.mnuGameLoad_Click);
			// 
			// mnuGameSave
			// 
			this.mnuGameSave.Enabled = false;
			this.mnuGameSave.Index = 2;
			this.mnuGameSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.mnuGameSave.Text = "&Save";
			this.mnuGameSave.Click += new System.EventHandler(this.mnuGameSave_Click);
			// 
			// mnuGameSaveAs
			// 
			this.mnuGameSaveAs.Enabled = false;
			this.mnuGameSaveAs.Index = 3;
			this.mnuGameSaveAs.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
			this.mnuGameSaveAs.Text = "Save &As...";
			this.mnuGameSaveAs.Click += new System.EventHandler(this.mnuGameSaveAs_Click);
			// 
			// mnuGameLine1
			// 
			this.mnuGameLine1.Index = 4;
			this.mnuGameLine1.Text = "-";
			// 
			// mnuRetire
			// 
			this.mnuRetire.Enabled = false;
			this.mnuRetire.Index = 5;
			this.mnuRetire.Text = "&Retire";
			this.mnuRetire.Click += new System.EventHandler(this.mnuRetire_Click);
			// 
			// mnuGameLine2
			// 
			this.mnuGameLine2.Index = 6;
			this.mnuGameLine2.Text = "-";
			// 
			// mnuGameExit
			// 
			this.mnuGameExit.Index = 7;
			this.mnuGameExit.Text = "E&xit";
			this.mnuGameExit.Click += new System.EventHandler(this.mnuGameExit_Click);
			// 
			// mnuView
			// 
			this.mnuView.Index = 1;
			this.mnuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuViewCommander,
            this.mnuViewShip,
            this.mnuViewPersonnel,
            this.mnuViewQuests,
            this.mnuViewBank,
            this.mnuViewLine1,
            this.mnuHighScores,
            this.mnuViewLine2,
            this.mnuOptions});
			this.mnuView.Text = "&View";
			// 
			// mnuViewCommander
			// 
			this.mnuViewCommander.Enabled = false;
			this.mnuViewCommander.Index = 0;
			this.mnuViewCommander.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
			this.mnuViewCommander.Text = "&Commander Status";
			this.mnuViewCommander.Click += new System.EventHandler(this.mnuViewCommander_Click);
			// 
			// mnuViewShip
			// 
			this.mnuViewShip.Enabled = false;
			this.mnuViewShip.Index = 1;
			this.mnuViewShip.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
			this.mnuViewShip.Text = "&Ship";
			this.mnuViewShip.Click += new System.EventHandler(this.mnuViewShip_Click);
			// 
			// mnuViewPersonnel
			// 
			this.mnuViewPersonnel.Enabled = false;
			this.mnuViewPersonnel.Index = 2;
			this.mnuViewPersonnel.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
			this.mnuViewPersonnel.Text = "&Personnel";
			this.mnuViewPersonnel.Click += new System.EventHandler(this.mnuViewPersonnel_Click);
			// 
			// mnuViewQuests
			// 
			this.mnuViewQuests.Enabled = false;
			this.mnuViewQuests.Index = 3;
			this.mnuViewQuests.Shortcut = System.Windows.Forms.Shortcut.CtrlQ;
			this.mnuViewQuests.Text = "&Quests";
			this.mnuViewQuests.Click += new System.EventHandler(this.mnuViewQuests_Click);
			// 
			// mnuViewBank
			// 
			this.mnuViewBank.Enabled = false;
			this.mnuViewBank.Index = 4;
			this.mnuViewBank.Shortcut = System.Windows.Forms.Shortcut.CtrlB;
			this.mnuViewBank.Text = "&Bank";
			this.mnuViewBank.Click += new System.EventHandler(this.mnuViewBank_Click);
			// 
			// mnuViewLine1
			// 
			this.mnuViewLine1.Index = 5;
			this.mnuViewLine1.Text = "-";
			// 
			// mnuHighScores
			// 
			this.mnuHighScores.Index = 6;
			this.mnuHighScores.Text = "&High Scores";
			this.mnuHighScores.Click += new System.EventHandler(this.mnuHighScores_Click);
			// 
			// mnuViewLine2
			// 
			this.mnuViewLine2.Index = 7;
			this.mnuViewLine2.Text = "-";
			// 
			// mnuOptions
			// 
			this.mnuOptions.Index = 8;
			this.mnuOptions.Text = "Options";
			this.mnuOptions.Click += new System.EventHandler(this.mnuOptions_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.Index = 2;
			this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuHelpAbout});
			this.mnuHelp.Text = "&Help";
			// 
			// mnuHelpAbout
			// 
			this.mnuHelpAbout.Index = 0;
			this.mnuHelpAbout.Text = "&About Space Trader";
			this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
			// 
			// picGalacticChart
			// 
			this.picGalacticChart.BackColor = System.Drawing.Color.White;
			this.picGalacticChart.Location = new System.Drawing.Point(8, 16);
			this.picGalacticChart.Name = "picGalacticChart";
			this.picGalacticChart.Size = new System.Drawing.Size(160, 116);
			this.picGalacticChart.TabIndex = 0;
			this.picGalacticChart.TabStop = false;
			this.picGalacticChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picGalacticChart_MouseDown);
			this.picGalacticChart.Paint += new System.Windows.Forms.PaintEventHandler(this.picGalacticChart_Paint);
			// 
			// picShortRangeChart
			// 
			this.picShortRangeChart.BackColor = System.Drawing.Color.White;
			this.picShortRangeChart.Location = new System.Drawing.Point(8, 16);
			this.picShortRangeChart.Name = "picShortRangeChart";
			this.picShortRangeChart.Size = new System.Drawing.Size(160, 145);
			this.picShortRangeChart.TabIndex = 1;
			this.picShortRangeChart.TabStop = false;
			this.picShortRangeChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picShortRangeChart_MouseDown);
			this.picShortRangeChart.Paint += new System.Windows.Forms.PaintEventHandler(this.picShortRangeChart_Paint);
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 481);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanelCash,
            this.statusBarPanelBays,
            this.statusBarPanelCosts,
            this.statusBarPanelExtra});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(768, 24);
			this.statusBar.SizingGrip = false;
			this.statusBar.TabIndex = 2;
			this.statusBar.PanelClick += new System.Windows.Forms.StatusBarPanelClickEventHandler(this.statusBar_PanelClick);
			// 
			// statusBarPanelCash
			// 
			this.statusBarPanelCash.MinWidth = 112;
			this.statusBarPanelCash.Name = "statusBarPanelCash";
			this.statusBarPanelCash.Text = " Cash: 88,888,888 cr.";
			this.statusBarPanelCash.Width = 112;
			// 
			// statusBarPanelBays
			// 
			this.statusBarPanelBays.MinWidth = 80;
			this.statusBarPanelBays.Name = "statusBarPanelBays";
			this.statusBarPanelBays.Text = " Bays: 88/88";
			this.statusBarPanelBays.Width = 80;
			// 
			// statusBarPanelCosts
			// 
			this.statusBarPanelCosts.MinWidth = 120;
			this.statusBarPanelCosts.Name = "statusBarPanelCosts";
			this.statusBarPanelCosts.Text = " Current Costs: 888 cr.";
			this.statusBarPanelCosts.Width = 120;
			// 
			// statusBarPanelExtra
			// 
			this.statusBarPanelExtra.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.statusBarPanelExtra.Name = "statusBarPanelExtra";
			this.statusBarPanelExtra.Width = 456;
			// 
			// boxShortRangeChart
			// 
			this.boxShortRangeChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.boxShortRangeChart.Controls.Add(this.picShortRangeChart);
			this.boxShortRangeChart.Location = new System.Drawing.Point(364, 306);
			this.boxShortRangeChart.Name = "boxShortRangeChart";
			this.boxShortRangeChart.Size = new System.Drawing.Size(176, 168);
			this.boxShortRangeChart.TabIndex = 6;
			this.boxShortRangeChart.TabStop = false;
			this.boxShortRangeChart.Text = "Short-Range Chart";
			// 
			// boxGalacticChart
			// 
			this.boxGalacticChart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.boxGalacticChart.BackColor = System.Drawing.SystemColors.Control;
			this.boxGalacticChart.Controls.Add(this.lblWormhole);
			this.boxGalacticChart.Controls.Add(this.lblWormholeLabel);
			this.boxGalacticChart.Controls.Add(this.btnJump);
			this.boxGalacticChart.Controls.Add(this.btnFind);
			this.boxGalacticChart.Controls.Add(this.picGalacticChart);
			this.boxGalacticChart.Location = new System.Drawing.Point(180, 306);
			this.boxGalacticChart.Name = "boxGalacticChart";
			this.boxGalacticChart.Size = new System.Drawing.Size(176, 168);
			this.boxGalacticChart.TabIndex = 5;
			this.boxGalacticChart.TabStop = false;
			this.boxGalacticChart.Text = "Galactic Chart";
			// 
			// lblWormhole
			// 
			this.lblWormhole.Location = new System.Drawing.Point(8, 148);
			this.lblWormhole.Name = "lblWormhole";
			this.lblWormhole.Size = new System.Drawing.Size(72, 13);
			this.lblWormhole.TabIndex = 29;
			this.lblWormhole.Text = "Tarchannen";
			// 
			// lblWormholeLabel
			// 
			this.lblWormholeLabel.Location = new System.Drawing.Point(8, 135);
			this.lblWormholeLabel.Name = "lblWormholeLabel";
			this.lblWormholeLabel.Size = new System.Drawing.Size(72, 13);
			this.lblWormholeLabel.TabIndex = 28;
			this.lblWormholeLabel.Text = "Wormhole to";
			// 
			// btnJump
			// 
			this.btnJump.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnJump.Location = new System.Drawing.Point(81, 138);
			this.btnJump.Name = "btnJump";
			this.btnJump.Size = new System.Drawing.Size(42, 22);
			this.btnJump.TabIndex = 55;
			this.btnJump.Text = "Jump";
			this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
			// 
			// btnFind
			// 
			this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFind.Location = new System.Drawing.Point(132, 138);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(36, 22);
			this.btnFind.TabIndex = 56;
			this.btnFind.Text = "Find";
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
			// 
			// boxTargetSystem
			// 
			this.boxTargetSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.boxTargetSystem.Controls.Add(this.btnTrack);
			this.boxTargetSystem.Controls.Add(this.btnNextSystem);
			this.boxTargetSystem.Controls.Add(this.btnPrevSystem);
			this.boxTargetSystem.Controls.Add(this.lblTargetOutOfRange);
			this.boxTargetSystem.Controls.Add(this.btnWarp);
			this.boxTargetSystem.Controls.Add(this.lblTargetPolSys);
			this.boxTargetSystem.Controls.Add(this.lblTargetSize);
			this.boxTargetSystem.Controls.Add(this.lblTargetTech);
			this.boxTargetSystem.Controls.Add(this.lblTargetDistance);
			this.boxTargetSystem.Controls.Add(this.lblTargetPirates);
			this.boxTargetSystem.Controls.Add(this.lblTargetPolice);
			this.boxTargetSystem.Controls.Add(this.lblTargetResource);
			this.boxTargetSystem.Controls.Add(this.lblTargetDistanceLabel);
			this.boxTargetSystem.Controls.Add(this.lblTargetPiratesLabel);
			this.boxTargetSystem.Controls.Add(this.lblTargetPoliceLabel);
			this.boxTargetSystem.Controls.Add(this.lblTargetResourceLabel);
			this.boxTargetSystem.Controls.Add(this.lblTargetGovtLabel);
			this.boxTargetSystem.Controls.Add(this.lblTargetTechLabel);
			this.boxTargetSystem.Controls.Add(this.lblTargetSizeLabel);
			this.boxTargetSystem.Controls.Add(this.lblTargetName);
			this.boxTargetSystem.Controls.Add(this.lblTargetNameLabel);
			this.boxTargetSystem.Location = new System.Drawing.Point(548, 306);
			this.boxTargetSystem.Name = "boxTargetSystem";
			this.boxTargetSystem.Size = new System.Drawing.Size(216, 168);
			this.boxTargetSystem.TabIndex = 7;
			this.boxTargetSystem.TabStop = false;
			this.boxTargetSystem.Text = "Target System";
			// 
			// btnTrack
			// 
			this.btnTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnTrack.Location = new System.Drawing.Point(160, 140);
			this.btnTrack.Name = "btnTrack";
			this.btnTrack.Size = new System.Drawing.Size(44, 22);
			this.btnTrack.TabIndex = 60;
			this.btnTrack.Text = "Track";
			this.btnTrack.Visible = false;
			this.btnTrack.Click += new System.EventHandler(this.btnTrack_Click);
			// 
			// btnNextSystem
			// 
			this.btnNextSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNextSystem.Location = new System.Drawing.Point(186, 16);
			this.btnNextSystem.Name = "btnNextSystem";
			this.btnNextSystem.Size = new System.Drawing.Size(18, 18);
			this.btnNextSystem.TabIndex = 58;
			this.btnNextSystem.Text = ">";
			this.btnNextSystem.Click += new System.EventHandler(this.btnNextSystem_Click);
			// 
			// btnPrevSystem
			// 
			this.btnPrevSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPrevSystem.Location = new System.Drawing.Point(160, 16);
			this.btnPrevSystem.Name = "btnPrevSystem";
			this.btnPrevSystem.Size = new System.Drawing.Size(18, 18);
			this.btnPrevSystem.TabIndex = 57;
			this.btnPrevSystem.Text = "<";
			this.btnPrevSystem.Click += new System.EventHandler(this.btnPrevSystem_Click);
			// 
			// lblTargetOutOfRange
			// 
			this.lblTargetOutOfRange.Location = new System.Drawing.Point(8, 144);
			this.lblTargetOutOfRange.Name = "lblTargetOutOfRange";
			this.lblTargetOutOfRange.Size = new System.Drawing.Size(144, 13);
			this.lblTargetOutOfRange.TabIndex = 17;
			this.lblTargetOutOfRange.Text = "This system is out of range.";
			// 
			// btnWarp
			// 
			this.btnWarp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnWarp.Location = new System.Drawing.Point(160, 98);
			this.btnWarp.Name = "btnWarp";
			this.btnWarp.Size = new System.Drawing.Size(44, 44);
			this.btnWarp.TabIndex = 59;
			this.btnWarp.Text = "Warp";
			this.btnWarp.Click += new System.EventHandler(this.btnWarp_Click);
			// 
			// lblTargetPolSys
			// 
			this.lblTargetPolSys.Location = new System.Drawing.Point(88, 64);
			this.lblTargetPolSys.Name = "lblTargetPolSys";
			this.lblTargetPolSys.Size = new System.Drawing.Size(91, 13);
			this.lblTargetPolSys.TabIndex = 15;
			this.lblTargetPolSys.Text = "Communist State";
			// 
			// lblTargetSize
			// 
			this.lblTargetSize.Location = new System.Drawing.Point(88, 32);
			this.lblTargetSize.Name = "lblTargetSize";
			this.lblTargetSize.Size = new System.Drawing.Size(45, 13);
			this.lblTargetSize.TabIndex = 14;
			this.lblTargetSize.Text = "Medium";
			// 
			// lblTargetTech
			// 
			this.lblTargetTech.Location = new System.Drawing.Point(88, 48);
			this.lblTargetTech.Name = "lblTargetTech";
			this.lblTargetTech.Size = new System.Drawing.Size(82, 13);
			this.lblTargetTech.TabIndex = 13;
			this.lblTargetTech.Text = "Pre-Agricultural";
			// 
			// lblTargetDistance
			// 
			this.lblTargetDistance.Location = new System.Drawing.Point(88, 128);
			this.lblTargetDistance.Name = "lblTargetDistance";
			this.lblTargetDistance.Size = new System.Drawing.Size(66, 13);
			this.lblTargetDistance.TabIndex = 12;
			this.lblTargetDistance.Text = "888 parsecs";
			// 
			// lblTargetPirates
			// 
			this.lblTargetPirates.Location = new System.Drawing.Point(88, 112);
			this.lblTargetPirates.Name = "lblTargetPirates";
			this.lblTargetPirates.Size = new System.Drawing.Size(53, 13);
			this.lblTargetPirates.TabIndex = 11;
			this.lblTargetPirates.Text = "Abundant";
			// 
			// lblTargetPolice
			// 
			this.lblTargetPolice.Location = new System.Drawing.Point(88, 96);
			this.lblTargetPolice.Name = "lblTargetPolice";
			this.lblTargetPolice.Size = new System.Drawing.Size(53, 13);
			this.lblTargetPolice.TabIndex = 10;
			this.lblTargetPolice.Text = "Abundant";
			// 
			// lblTargetResource
			// 
			this.lblTargetResource.Location = new System.Drawing.Point(88, 80);
			this.lblTargetResource.Name = "lblTargetResource";
			this.lblTargetResource.Size = new System.Drawing.Size(105, 13);
			this.lblTargetResource.TabIndex = 9;
			this.lblTargetResource.Text = "Sweetwater Oceans";
			// 
			// lblTargetDistanceLabel
			// 
			this.lblTargetDistanceLabel.AutoSize = true;
			this.lblTargetDistanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTargetDistanceLabel.Location = new System.Drawing.Point(8, 128);
			this.lblTargetDistanceLabel.Name = "lblTargetDistanceLabel";
			this.lblTargetDistanceLabel.Size = new System.Drawing.Size(61, 13);
			this.lblTargetDistanceLabel.TabIndex = 8;
			this.lblTargetDistanceLabel.Text = "Distance:";
			// 
			// lblTargetPiratesLabel
			// 
			this.lblTargetPiratesLabel.AutoSize = true;
			this.lblTargetPiratesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTargetPiratesLabel.Location = new System.Drawing.Point(8, 112);
			this.lblTargetPiratesLabel.Name = "lblTargetPiratesLabel";
			this.lblTargetPiratesLabel.Size = new System.Drawing.Size(50, 13);
			this.lblTargetPiratesLabel.TabIndex = 7;
			this.lblTargetPiratesLabel.Text = "Pirates:";
			// 
			// lblTargetPoliceLabel
			// 
			this.lblTargetPoliceLabel.AutoSize = true;
			this.lblTargetPoliceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTargetPoliceLabel.Location = new System.Drawing.Point(8, 96);
			this.lblTargetPoliceLabel.Name = "lblTargetPoliceLabel";
			this.lblTargetPoliceLabel.Size = new System.Drawing.Size(46, 13);
			this.lblTargetPoliceLabel.TabIndex = 6;
			this.lblTargetPoliceLabel.Text = "Police:";
			// 
			// lblTargetResourceLabel
			// 
			this.lblTargetResourceLabel.AutoSize = true;
			this.lblTargetResourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTargetResourceLabel.Location = new System.Drawing.Point(8, 80);
			this.lblTargetResourceLabel.Name = "lblTargetResourceLabel";
			this.lblTargetResourceLabel.Size = new System.Drawing.Size(65, 13);
			this.lblTargetResourceLabel.TabIndex = 5;
			this.lblTargetResourceLabel.Text = "Resource:";
			// 
			// lblTargetGovtLabel
			// 
			this.lblTargetGovtLabel.AutoSize = true;
			this.lblTargetGovtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTargetGovtLabel.Location = new System.Drawing.Point(8, 64);
			this.lblTargetGovtLabel.Name = "lblTargetGovtLabel";
			this.lblTargetGovtLabel.Size = new System.Drawing.Size(79, 13);
			this.lblTargetGovtLabel.TabIndex = 4;
			this.lblTargetGovtLabel.Text = "Government:";
			// 
			// lblTargetTechLabel
			// 
			this.lblTargetTechLabel.AutoSize = true;
			this.lblTargetTechLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTargetTechLabel.Location = new System.Drawing.Point(8, 48);
			this.lblTargetTechLabel.Name = "lblTargetTechLabel";
			this.lblTargetTechLabel.Size = new System.Drawing.Size(75, 13);
			this.lblTargetTechLabel.TabIndex = 3;
			this.lblTargetTechLabel.Text = "Tech Level:";
			// 
			// lblTargetSizeLabel
			// 
			this.lblTargetSizeLabel.AutoSize = true;
			this.lblTargetSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTargetSizeLabel.Location = new System.Drawing.Point(8, 32);
			this.lblTargetSizeLabel.Name = "lblTargetSizeLabel";
			this.lblTargetSizeLabel.Size = new System.Drawing.Size(35, 13);
			this.lblTargetSizeLabel.TabIndex = 2;
			this.lblTargetSizeLabel.Text = "Size:";
			// 
			// lblTargetName
			// 
			this.lblTargetName.Location = new System.Drawing.Point(88, 16);
			this.lblTargetName.Name = "lblTargetName";
			this.lblTargetName.Size = new System.Drawing.Size(65, 13);
			this.lblTargetName.TabIndex = 1;
			this.lblTargetName.Text = "Tarchannen";
			// 
			// lblTargetNameLabel
			// 
			this.lblTargetNameLabel.AutoSize = true;
			this.lblTargetNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTargetNameLabel.Location = new System.Drawing.Point(8, 16);
			this.lblTargetNameLabel.Name = "lblTargetNameLabel";
			this.lblTargetNameLabel.Size = new System.Drawing.Size(43, 13);
			this.lblTargetNameLabel.TabIndex = 0;
			this.lblTargetNameLabel.Text = "Name:";
			// 
			// boxCargo
			// 
			this.boxCargo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.boxCargo.Controls.Add(this.picCargoLine3);
			this.boxCargo.Controls.Add(this.picCargoLine2);
			this.boxCargo.Controls.Add(this.picCargoLine0);
			this.boxCargo.Controls.Add(this.picCargoLine1);
			this.boxCargo.Controls.Add(this.lblTargetPct9);
			this.boxCargo.Controls.Add(this.lblTargetDiff9);
			this.boxCargo.Controls.Add(this.lblTargetPrice9);
			this.boxCargo.Controls.Add(this.btnBuyMax9);
			this.boxCargo.Controls.Add(this.btnBuyQty9);
			this.boxCargo.Controls.Add(this.lblBuyPrice9);
			this.boxCargo.Controls.Add(this.btnSellAll9);
			this.boxCargo.Controls.Add(this.btnSellQty9);
			this.boxCargo.Controls.Add(this.lblSellPrice9);
			this.boxCargo.Controls.Add(this.lblTargetPct8);
			this.boxCargo.Controls.Add(this.lblTargetDiff8);
			this.boxCargo.Controls.Add(this.lblTargetPrice8);
			this.boxCargo.Controls.Add(this.btnBuyMax8);
			this.boxCargo.Controls.Add(this.btnBuyQty8);
			this.boxCargo.Controls.Add(this.lblBuyPrice8);
			this.boxCargo.Controls.Add(this.btnSellAll8);
			this.boxCargo.Controls.Add(this.btnSellQty8);
			this.boxCargo.Controls.Add(this.lblSellPrice8);
			this.boxCargo.Controls.Add(this.lblTargetPct7);
			this.boxCargo.Controls.Add(this.lblTargetDiff7);
			this.boxCargo.Controls.Add(this.lblTargetPrice7);
			this.boxCargo.Controls.Add(this.btnBuyMax7);
			this.boxCargo.Controls.Add(this.btnBuyQty7);
			this.boxCargo.Controls.Add(this.lblBuyPrice7);
			this.boxCargo.Controls.Add(this.btnSellAll7);
			this.boxCargo.Controls.Add(this.btnSellQty7);
			this.boxCargo.Controls.Add(this.lblSellPrice7);
			this.boxCargo.Controls.Add(this.lblTargetPct6);
			this.boxCargo.Controls.Add(this.lblTargetDiff6);
			this.boxCargo.Controls.Add(this.lblTargetPrice6);
			this.boxCargo.Controls.Add(this.btnBuyMax6);
			this.boxCargo.Controls.Add(this.btnBuyQty6);
			this.boxCargo.Controls.Add(this.lblBuyPrice6);
			this.boxCargo.Controls.Add(this.btnSellAll6);
			this.boxCargo.Controls.Add(this.btnSellQty6);
			this.boxCargo.Controls.Add(this.lblSellPrice6);
			this.boxCargo.Controls.Add(this.lblTargetPct5);
			this.boxCargo.Controls.Add(this.lblTargetDiff5);
			this.boxCargo.Controls.Add(this.lblTargetPrice5);
			this.boxCargo.Controls.Add(this.btnBuyMax5);
			this.boxCargo.Controls.Add(this.btnBuyQty5);
			this.boxCargo.Controls.Add(this.lblBuyPrice5);
			this.boxCargo.Controls.Add(this.btnSellAll5);
			this.boxCargo.Controls.Add(this.btnSellQty5);
			this.boxCargo.Controls.Add(this.lblSellPrice5);
			this.boxCargo.Controls.Add(this.lblTargetPct4);
			this.boxCargo.Controls.Add(this.lblTargetDiff4);
			this.boxCargo.Controls.Add(this.lblTargetPrice4);
			this.boxCargo.Controls.Add(this.btnBuyMax4);
			this.boxCargo.Controls.Add(this.btnBuyQty4);
			this.boxCargo.Controls.Add(this.lblBuyPrice4);
			this.boxCargo.Controls.Add(this.btnSellAll4);
			this.boxCargo.Controls.Add(this.btnSellQty4);
			this.boxCargo.Controls.Add(this.lblSellPrice4);
			this.boxCargo.Controls.Add(this.lblTargetPct3);
			this.boxCargo.Controls.Add(this.lblTargetDiff3);
			this.boxCargo.Controls.Add(this.lblTargetPrice3);
			this.boxCargo.Controls.Add(this.btnBuyMax3);
			this.boxCargo.Controls.Add(this.btnBuyQty3);
			this.boxCargo.Controls.Add(this.lblBuyPrice3);
			this.boxCargo.Controls.Add(this.btnSellAll3);
			this.boxCargo.Controls.Add(this.btnSellQty3);
			this.boxCargo.Controls.Add(this.lblSellPrice3);
			this.boxCargo.Controls.Add(this.lblTargetPct2);
			this.boxCargo.Controls.Add(this.lblTargetDiff2);
			this.boxCargo.Controls.Add(this.lblTargetPrice2);
			this.boxCargo.Controls.Add(this.btnBuyMax2);
			this.boxCargo.Controls.Add(this.btnBuyQty2);
			this.boxCargo.Controls.Add(this.lblBuyPrice2);
			this.boxCargo.Controls.Add(this.btnSellAll2);
			this.boxCargo.Controls.Add(this.btnSellQty2);
			this.boxCargo.Controls.Add(this.lblSellPrice2);
			this.boxCargo.Controls.Add(this.lblTargetPct1);
			this.boxCargo.Controls.Add(this.lblTargetDiff1);
			this.boxCargo.Controls.Add(this.lblTargetPrice1);
			this.boxCargo.Controls.Add(this.btnBuyMax1);
			this.boxCargo.Controls.Add(this.btnBuyQty1);
			this.boxCargo.Controls.Add(this.lblBuyPrice1);
			this.boxCargo.Controls.Add(this.lblTargetPctLabel);
			this.boxCargo.Controls.Add(this.lblTargetDiffLabel);
			this.boxCargo.Controls.Add(this.lblTargetPriceLabel);
			this.boxCargo.Controls.Add(this.lblTargetPct0);
			this.boxCargo.Controls.Add(this.lblTargetDiff0);
			this.boxCargo.Controls.Add(this.lblTargetPrice0);
			this.boxCargo.Controls.Add(this.btnBuyMax0);
			this.boxCargo.Controls.Add(this.btnBuyQty0);
			this.boxCargo.Controls.Add(this.lblBuyPrice0);
			this.boxCargo.Controls.Add(this.btnSellAll1);
			this.boxCargo.Controls.Add(this.btnSellQty1);
			this.boxCargo.Controls.Add(this.lblSellPrice1);
			this.boxCargo.Controls.Add(this.btnSellAll0);
			this.boxCargo.Controls.Add(this.btnSellQty0);
			this.boxCargo.Controls.Add(this.lblSellPrice0);
			this.boxCargo.Controls.Add(this.lblTradeTarget);
			this.boxCargo.Controls.Add(this.lblBuy);
			this.boxCargo.Controls.Add(this.lblSell);
			this.boxCargo.Controls.Add(this.lblTradeCmdty9);
			this.boxCargo.Controls.Add(this.lblTradeCmdty8);
			this.boxCargo.Controls.Add(this.lblTradeCmdty2);
			this.boxCargo.Controls.Add(this.lblTradeCmdty0);
			this.boxCargo.Controls.Add(this.lblTradeCmdty1);
			this.boxCargo.Controls.Add(this.lblTradeCmdty6);
			this.boxCargo.Controls.Add(this.lblTradeCmdty5);
			this.boxCargo.Controls.Add(this.lblTradeCmdty4);
			this.boxCargo.Controls.Add(this.lblTradeCmdty3);
			this.boxCargo.Controls.Add(this.lblTradeCmdty7);
			this.boxCargo.Location = new System.Drawing.Point(252, 2);
			this.boxCargo.Name = "boxCargo";
			this.boxCargo.Size = new System.Drawing.Size(512, 300);
			this.boxCargo.TabIndex = 8;
			this.boxCargo.TabStop = false;
			this.boxCargo.Text = "Cargo";
			// 
			// picCargoLine3
			// 
			this.picCargoLine3.BackColor = System.Drawing.Color.DimGray;
			this.picCargoLine3.Location = new System.Drawing.Point(8, 52);
			this.picCargoLine3.Name = "picCargoLine3";
			this.picCargoLine3.Size = new System.Drawing.Size(496, 1);
			this.picCargoLine3.TabIndex = 131;
			this.picCargoLine3.TabStop = false;
			// 
			// picCargoLine2
			// 
			this.picCargoLine2.BackColor = System.Drawing.Color.DimGray;
			this.picCargoLine2.Location = new System.Drawing.Point(352, 32);
			this.picCargoLine2.Name = "picCargoLine2";
			this.picCargoLine2.Size = new System.Drawing.Size(1, 262);
			this.picCargoLine2.TabIndex = 130;
			this.picCargoLine2.TabStop = false;
			// 
			// picCargoLine0
			// 
			this.picCargoLine0.BackColor = System.Drawing.Color.DimGray;
			this.picCargoLine0.Location = new System.Drawing.Point(71, 32);
			this.picCargoLine0.Name = "picCargoLine0";
			this.picCargoLine0.Size = new System.Drawing.Size(1, 262);
			this.picCargoLine0.TabIndex = 129;
			this.picCargoLine0.TabStop = false;
			// 
			// picCargoLine1
			// 
			this.picCargoLine1.BackColor = System.Drawing.Color.DimGray;
			this.picCargoLine1.Location = new System.Drawing.Point(218, 32);
			this.picCargoLine1.Name = "picCargoLine1";
			this.picCargoLine1.Size = new System.Drawing.Size(1, 262);
			this.picCargoLine1.TabIndex = 128;
			this.picCargoLine1.TabStop = false;
			// 
			// lblTargetPct9
			// 
			this.lblTargetPct9.Location = new System.Drawing.Point(466, 276);
			this.lblTargetPct9.Name = "lblTargetPct9";
			this.lblTargetPct9.Size = new System.Drawing.Size(37, 13);
			this.lblTargetPct9.TabIndex = 127;
			this.lblTargetPct9.Text = "--------";
			this.lblTargetPct9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetDiff9
			// 
			this.lblTargetDiff9.Location = new System.Drawing.Point(410, 276);
			this.lblTargetDiff9.Name = "lblTargetDiff9";
			this.lblTargetDiff9.Size = new System.Drawing.Size(52, 13);
			this.lblTargetDiff9.TabIndex = 126;
			this.lblTargetDiff9.Text = "------------";
			this.lblTargetDiff9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPrice9
			// 
			this.lblTargetPrice9.Location = new System.Drawing.Point(358, 276);
			this.lblTargetPrice9.Name = "lblTargetPrice9";
			this.lblTargetPrice9.Size = new System.Drawing.Size(48, 13);
			this.lblTargetPrice9.TabIndex = 125;
			this.lblTargetPrice9.Text = "-----------";
			this.lblTargetPrice9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnBuyMax9
			// 
			this.btnBuyMax9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyMax9.Location = new System.Drawing.Point(262, 272);
			this.btnBuyMax9.Name = "btnBuyMax9";
			this.btnBuyMax9.Size = new System.Drawing.Size(36, 22);
			this.btnBuyMax9.TabIndex = 51;
			this.btnBuyMax9.Text = "Max";
			this.btnBuyMax9.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnBuyQty9
			// 
			this.btnBuyQty9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyQty9.Location = new System.Drawing.Point(227, 272);
			this.btnBuyQty9.Name = "btnBuyQty9";
			this.btnBuyQty9.Size = new System.Drawing.Size(28, 22);
			this.btnBuyQty9.TabIndex = 50;
			this.btnBuyQty9.Text = "88";
			this.btnBuyQty9.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblBuyPrice9
			// 
			this.lblBuyPrice9.Location = new System.Drawing.Point(302, 276);
			this.lblBuyPrice9.Name = "lblBuyPrice9";
			this.lblBuyPrice9.Size = new System.Drawing.Size(48, 13);
			this.lblBuyPrice9.TabIndex = 122;
			this.lblBuyPrice9.Text = "not sold";
			this.lblBuyPrice9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnSellAll9
			// 
			this.btnSellAll9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellAll9.Location = new System.Drawing.Point(115, 272);
			this.btnSellAll9.Name = "btnSellAll9";
			this.btnSellAll9.Size = new System.Drawing.Size(44, 22);
			this.btnSellAll9.TabIndex = 49;
			this.btnSellAll9.Text = "Dump";
			this.btnSellAll9.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnSellQty9
			// 
			this.btnSellQty9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellQty9.Location = new System.Drawing.Point(80, 272);
			this.btnSellQty9.Name = "btnSellQty9";
			this.btnSellQty9.Size = new System.Drawing.Size(28, 22);
			this.btnSellQty9.TabIndex = 48;
			this.btnSellQty9.Text = "88";
			this.btnSellQty9.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblSellPrice9
			// 
			this.lblSellPrice9.Location = new System.Drawing.Point(163, 276);
			this.lblSellPrice9.Name = "lblSellPrice9";
			this.lblSellPrice9.Size = new System.Drawing.Size(48, 13);
			this.lblSellPrice9.TabIndex = 119;
			this.lblSellPrice9.Text = "no trade";
			this.lblSellPrice9.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPct8
			// 
			this.lblTargetPct8.Location = new System.Drawing.Point(466, 252);
			this.lblTargetPct8.Name = "lblTargetPct8";
			this.lblTargetPct8.Size = new System.Drawing.Size(37, 13);
			this.lblTargetPct8.TabIndex = 118;
			this.lblTargetPct8.Text = "-888%";
			this.lblTargetPct8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetDiff8
			// 
			this.lblTargetDiff8.Location = new System.Drawing.Point(410, 252);
			this.lblTargetDiff8.Name = "lblTargetDiff8";
			this.lblTargetDiff8.Size = new System.Drawing.Size(52, 13);
			this.lblTargetDiff8.TabIndex = 117;
			this.lblTargetDiff8.Text = "-8,888 cr.";
			this.lblTargetDiff8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPrice8
			// 
			this.lblTargetPrice8.Location = new System.Drawing.Point(358, 252);
			this.lblTargetPrice8.Name = "lblTargetPrice8";
			this.lblTargetPrice8.Size = new System.Drawing.Size(48, 13);
			this.lblTargetPrice8.TabIndex = 116;
			this.lblTargetPrice8.Text = "8,888 cr.";
			this.lblTargetPrice8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnBuyMax8
			// 
			this.btnBuyMax8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyMax8.Location = new System.Drawing.Point(262, 248);
			this.btnBuyMax8.Name = "btnBuyMax8";
			this.btnBuyMax8.Size = new System.Drawing.Size(36, 22);
			this.btnBuyMax8.TabIndex = 47;
			this.btnBuyMax8.Text = "Max";
			this.btnBuyMax8.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnBuyQty8
			// 
			this.btnBuyQty8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyQty8.Location = new System.Drawing.Point(227, 248);
			this.btnBuyQty8.Name = "btnBuyQty8";
			this.btnBuyQty8.Size = new System.Drawing.Size(28, 22);
			this.btnBuyQty8.TabIndex = 46;
			this.btnBuyQty8.Text = "88";
			this.btnBuyQty8.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblBuyPrice8
			// 
			this.lblBuyPrice8.Location = new System.Drawing.Point(302, 252);
			this.lblBuyPrice8.Name = "lblBuyPrice8";
			this.lblBuyPrice8.Size = new System.Drawing.Size(48, 13);
			this.lblBuyPrice8.TabIndex = 113;
			this.lblBuyPrice8.Text = "8,888 cr.";
			this.lblBuyPrice8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnSellAll8
			// 
			this.btnSellAll8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellAll8.Location = new System.Drawing.Point(115, 248);
			this.btnSellAll8.Name = "btnSellAll8";
			this.btnSellAll8.Size = new System.Drawing.Size(44, 22);
			this.btnSellAll8.TabIndex = 45;
			this.btnSellAll8.Text = "All";
			this.btnSellAll8.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnSellQty8
			// 
			this.btnSellQty8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellQty8.Location = new System.Drawing.Point(80, 248);
			this.btnSellQty8.Name = "btnSellQty8";
			this.btnSellQty8.Size = new System.Drawing.Size(28, 22);
			this.btnSellQty8.TabIndex = 44;
			this.btnSellQty8.Text = "88";
			this.btnSellQty8.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblSellPrice8
			// 
			this.lblSellPrice8.Location = new System.Drawing.Point(163, 252);
			this.lblSellPrice8.Name = "lblSellPrice8";
			this.lblSellPrice8.Size = new System.Drawing.Size(48, 13);
			this.lblSellPrice8.TabIndex = 110;
			this.lblSellPrice8.Text = "8,888 cr.";
			this.lblSellPrice8.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPct7
			// 
			this.lblTargetPct7.Location = new System.Drawing.Point(466, 228);
			this.lblTargetPct7.Name = "lblTargetPct7";
			this.lblTargetPct7.Size = new System.Drawing.Size(37, 13);
			this.lblTargetPct7.TabIndex = 109;
			this.lblTargetPct7.Text = "-888%";
			this.lblTargetPct7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetDiff7
			// 
			this.lblTargetDiff7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTargetDiff7.Location = new System.Drawing.Point(410, 228);
			this.lblTargetDiff7.Name = "lblTargetDiff7";
			this.lblTargetDiff7.Size = new System.Drawing.Size(52, 13);
			this.lblTargetDiff7.TabIndex = 108;
			this.lblTargetDiff7.Text = "-8,888 cr.";
			this.lblTargetDiff7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPrice7
			// 
			this.lblTargetPrice7.Location = new System.Drawing.Point(358, 228);
			this.lblTargetPrice7.Name = "lblTargetPrice7";
			this.lblTargetPrice7.Size = new System.Drawing.Size(48, 13);
			this.lblTargetPrice7.TabIndex = 107;
			this.lblTargetPrice7.Text = "8,888 cr.";
			this.lblTargetPrice7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnBuyMax7
			// 
			this.btnBuyMax7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyMax7.Location = new System.Drawing.Point(262, 224);
			this.btnBuyMax7.Name = "btnBuyMax7";
			this.btnBuyMax7.Size = new System.Drawing.Size(36, 22);
			this.btnBuyMax7.TabIndex = 43;
			this.btnBuyMax7.Text = "Max";
			this.btnBuyMax7.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnBuyQty7
			// 
			this.btnBuyQty7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyQty7.Location = new System.Drawing.Point(227, 224);
			this.btnBuyQty7.Name = "btnBuyQty7";
			this.btnBuyQty7.Size = new System.Drawing.Size(28, 22);
			this.btnBuyQty7.TabIndex = 42;
			this.btnBuyQty7.Text = "88";
			this.btnBuyQty7.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblBuyPrice7
			// 
			this.lblBuyPrice7.Location = new System.Drawing.Point(302, 228);
			this.lblBuyPrice7.Name = "lblBuyPrice7";
			this.lblBuyPrice7.Size = new System.Drawing.Size(48, 13);
			this.lblBuyPrice7.TabIndex = 104;
			this.lblBuyPrice7.Text = "8,888 cr.";
			this.lblBuyPrice7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnSellAll7
			// 
			this.btnSellAll7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellAll7.Location = new System.Drawing.Point(115, 224);
			this.btnSellAll7.Name = "btnSellAll7";
			this.btnSellAll7.Size = new System.Drawing.Size(44, 22);
			this.btnSellAll7.TabIndex = 41;
			this.btnSellAll7.Text = "All";
			this.btnSellAll7.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnSellQty7
			// 
			this.btnSellQty7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellQty7.Location = new System.Drawing.Point(80, 224);
			this.btnSellQty7.Name = "btnSellQty7";
			this.btnSellQty7.Size = new System.Drawing.Size(28, 22);
			this.btnSellQty7.TabIndex = 40;
			this.btnSellQty7.Text = "88";
			this.btnSellQty7.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblSellPrice7
			// 
			this.lblSellPrice7.Location = new System.Drawing.Point(163, 228);
			this.lblSellPrice7.Name = "lblSellPrice7";
			this.lblSellPrice7.Size = new System.Drawing.Size(48, 13);
			this.lblSellPrice7.TabIndex = 101;
			this.lblSellPrice7.Text = "8,888 cr.";
			this.lblSellPrice7.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPct6
			// 
			this.lblTargetPct6.Location = new System.Drawing.Point(466, 204);
			this.lblTargetPct6.Name = "lblTargetPct6";
			this.lblTargetPct6.Size = new System.Drawing.Size(37, 13);
			this.lblTargetPct6.TabIndex = 100;
			this.lblTargetPct6.Text = "-888%";
			this.lblTargetPct6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetDiff6
			// 
			this.lblTargetDiff6.Location = new System.Drawing.Point(410, 204);
			this.lblTargetDiff6.Name = "lblTargetDiff6";
			this.lblTargetDiff6.Size = new System.Drawing.Size(52, 13);
			this.lblTargetDiff6.TabIndex = 99;
			this.lblTargetDiff6.Text = "-8,888 cr.";
			this.lblTargetDiff6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPrice6
			// 
			this.lblTargetPrice6.Location = new System.Drawing.Point(358, 204);
			this.lblTargetPrice6.Name = "lblTargetPrice6";
			this.lblTargetPrice6.Size = new System.Drawing.Size(48, 13);
			this.lblTargetPrice6.TabIndex = 98;
			this.lblTargetPrice6.Text = "8,888 cr.";
			this.lblTargetPrice6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnBuyMax6
			// 
			this.btnBuyMax6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyMax6.Location = new System.Drawing.Point(262, 200);
			this.btnBuyMax6.Name = "btnBuyMax6";
			this.btnBuyMax6.Size = new System.Drawing.Size(36, 22);
			this.btnBuyMax6.TabIndex = 39;
			this.btnBuyMax6.Text = "Max";
			this.btnBuyMax6.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnBuyQty6
			// 
			this.btnBuyQty6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyQty6.Location = new System.Drawing.Point(227, 200);
			this.btnBuyQty6.Name = "btnBuyQty6";
			this.btnBuyQty6.Size = new System.Drawing.Size(28, 22);
			this.btnBuyQty6.TabIndex = 38;
			this.btnBuyQty6.Text = "88";
			this.btnBuyQty6.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblBuyPrice6
			// 
			this.lblBuyPrice6.Location = new System.Drawing.Point(302, 204);
			this.lblBuyPrice6.Name = "lblBuyPrice6";
			this.lblBuyPrice6.Size = new System.Drawing.Size(48, 13);
			this.lblBuyPrice6.TabIndex = 95;
			this.lblBuyPrice6.Text = "8,888 cr.";
			this.lblBuyPrice6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnSellAll6
			// 
			this.btnSellAll6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellAll6.Location = new System.Drawing.Point(115, 200);
			this.btnSellAll6.Name = "btnSellAll6";
			this.btnSellAll6.Size = new System.Drawing.Size(44, 22);
			this.btnSellAll6.TabIndex = 37;
			this.btnSellAll6.Text = "All";
			this.btnSellAll6.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnSellQty6
			// 
			this.btnSellQty6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellQty6.Location = new System.Drawing.Point(80, 200);
			this.btnSellQty6.Name = "btnSellQty6";
			this.btnSellQty6.Size = new System.Drawing.Size(28, 22);
			this.btnSellQty6.TabIndex = 36;
			this.btnSellQty6.Text = "88";
			this.btnSellQty6.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblSellPrice6
			// 
			this.lblSellPrice6.Location = new System.Drawing.Point(163, 204);
			this.lblSellPrice6.Name = "lblSellPrice6";
			this.lblSellPrice6.Size = new System.Drawing.Size(48, 13);
			this.lblSellPrice6.TabIndex = 92;
			this.lblSellPrice6.Text = "8,888 cr.";
			this.lblSellPrice6.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPct5
			// 
			this.lblTargetPct5.Location = new System.Drawing.Point(466, 180);
			this.lblTargetPct5.Name = "lblTargetPct5";
			this.lblTargetPct5.Size = new System.Drawing.Size(37, 13);
			this.lblTargetPct5.TabIndex = 91;
			this.lblTargetPct5.Text = "-888%";
			this.lblTargetPct5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetDiff5
			// 
			this.lblTargetDiff5.Location = new System.Drawing.Point(410, 180);
			this.lblTargetDiff5.Name = "lblTargetDiff5";
			this.lblTargetDiff5.Size = new System.Drawing.Size(52, 13);
			this.lblTargetDiff5.TabIndex = 90;
			this.lblTargetDiff5.Text = "-8,888 cr.";
			this.lblTargetDiff5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPrice5
			// 
			this.lblTargetPrice5.Location = new System.Drawing.Point(358, 180);
			this.lblTargetPrice5.Name = "lblTargetPrice5";
			this.lblTargetPrice5.Size = new System.Drawing.Size(48, 13);
			this.lblTargetPrice5.TabIndex = 89;
			this.lblTargetPrice5.Text = "8,888 cr.";
			this.lblTargetPrice5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnBuyMax5
			// 
			this.btnBuyMax5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyMax5.Location = new System.Drawing.Point(262, 176);
			this.btnBuyMax5.Name = "btnBuyMax5";
			this.btnBuyMax5.Size = new System.Drawing.Size(36, 22);
			this.btnBuyMax5.TabIndex = 35;
			this.btnBuyMax5.Text = "Max";
			this.btnBuyMax5.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnBuyQty5
			// 
			this.btnBuyQty5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyQty5.Location = new System.Drawing.Point(227, 176);
			this.btnBuyQty5.Name = "btnBuyQty5";
			this.btnBuyQty5.Size = new System.Drawing.Size(28, 22);
			this.btnBuyQty5.TabIndex = 34;
			this.btnBuyQty5.Text = "88";
			this.btnBuyQty5.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblBuyPrice5
			// 
			this.lblBuyPrice5.Location = new System.Drawing.Point(302, 180);
			this.lblBuyPrice5.Name = "lblBuyPrice5";
			this.lblBuyPrice5.Size = new System.Drawing.Size(48, 13);
			this.lblBuyPrice5.TabIndex = 86;
			this.lblBuyPrice5.Text = "8,888 cr.";
			this.lblBuyPrice5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnSellAll5
			// 
			this.btnSellAll5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellAll5.Location = new System.Drawing.Point(115, 176);
			this.btnSellAll5.Name = "btnSellAll5";
			this.btnSellAll5.Size = new System.Drawing.Size(44, 22);
			this.btnSellAll5.TabIndex = 33;
			this.btnSellAll5.Text = "All";
			this.btnSellAll5.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnSellQty5
			// 
			this.btnSellQty5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellQty5.Location = new System.Drawing.Point(80, 176);
			this.btnSellQty5.Name = "btnSellQty5";
			this.btnSellQty5.Size = new System.Drawing.Size(28, 22);
			this.btnSellQty5.TabIndex = 32;
			this.btnSellQty5.Text = "88";
			this.btnSellQty5.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblSellPrice5
			// 
			this.lblSellPrice5.Location = new System.Drawing.Point(163, 180);
			this.lblSellPrice5.Name = "lblSellPrice5";
			this.lblSellPrice5.Size = new System.Drawing.Size(48, 13);
			this.lblSellPrice5.TabIndex = 83;
			this.lblSellPrice5.Text = "8,888 cr.";
			this.lblSellPrice5.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPct4
			// 
			this.lblTargetPct4.Location = new System.Drawing.Point(466, 156);
			this.lblTargetPct4.Name = "lblTargetPct4";
			this.lblTargetPct4.Size = new System.Drawing.Size(37, 13);
			this.lblTargetPct4.TabIndex = 82;
			this.lblTargetPct4.Text = "-888%";
			this.lblTargetPct4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetDiff4
			// 
			this.lblTargetDiff4.Location = new System.Drawing.Point(410, 156);
			this.lblTargetDiff4.Name = "lblTargetDiff4";
			this.lblTargetDiff4.Size = new System.Drawing.Size(52, 13);
			this.lblTargetDiff4.TabIndex = 81;
			this.lblTargetDiff4.Text = "-8,888 cr.";
			this.lblTargetDiff4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPrice4
			// 
			this.lblTargetPrice4.Location = new System.Drawing.Point(358, 156);
			this.lblTargetPrice4.Name = "lblTargetPrice4";
			this.lblTargetPrice4.Size = new System.Drawing.Size(48, 13);
			this.lblTargetPrice4.TabIndex = 80;
			this.lblTargetPrice4.Text = "8,888 cr.";
			this.lblTargetPrice4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnBuyMax4
			// 
			this.btnBuyMax4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyMax4.Location = new System.Drawing.Point(262, 152);
			this.btnBuyMax4.Name = "btnBuyMax4";
			this.btnBuyMax4.Size = new System.Drawing.Size(36, 22);
			this.btnBuyMax4.TabIndex = 31;
			this.btnBuyMax4.Text = "Max";
			this.btnBuyMax4.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnBuyQty4
			// 
			this.btnBuyQty4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyQty4.Location = new System.Drawing.Point(227, 152);
			this.btnBuyQty4.Name = "btnBuyQty4";
			this.btnBuyQty4.Size = new System.Drawing.Size(28, 22);
			this.btnBuyQty4.TabIndex = 30;
			this.btnBuyQty4.Text = "88";
			this.btnBuyQty4.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblBuyPrice4
			// 
			this.lblBuyPrice4.Location = new System.Drawing.Point(302, 156);
			this.lblBuyPrice4.Name = "lblBuyPrice4";
			this.lblBuyPrice4.Size = new System.Drawing.Size(48, 13);
			this.lblBuyPrice4.TabIndex = 77;
			this.lblBuyPrice4.Text = "8,888 cr.";
			this.lblBuyPrice4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnSellAll4
			// 
			this.btnSellAll4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellAll4.Location = new System.Drawing.Point(115, 152);
			this.btnSellAll4.Name = "btnSellAll4";
			this.btnSellAll4.Size = new System.Drawing.Size(44, 22);
			this.btnSellAll4.TabIndex = 29;
			this.btnSellAll4.Text = "All";
			this.btnSellAll4.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnSellQty4
			// 
			this.btnSellQty4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellQty4.Location = new System.Drawing.Point(80, 152);
			this.btnSellQty4.Name = "btnSellQty4";
			this.btnSellQty4.Size = new System.Drawing.Size(28, 22);
			this.btnSellQty4.TabIndex = 28;
			this.btnSellQty4.Text = "88";
			this.btnSellQty4.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblSellPrice4
			// 
			this.lblSellPrice4.Location = new System.Drawing.Point(163, 156);
			this.lblSellPrice4.Name = "lblSellPrice4";
			this.lblSellPrice4.Size = new System.Drawing.Size(48, 13);
			this.lblSellPrice4.TabIndex = 74;
			this.lblSellPrice4.Text = "8,888 cr.";
			this.lblSellPrice4.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPct3
			// 
			this.lblTargetPct3.Location = new System.Drawing.Point(466, 132);
			this.lblTargetPct3.Name = "lblTargetPct3";
			this.lblTargetPct3.Size = new System.Drawing.Size(37, 13);
			this.lblTargetPct3.TabIndex = 73;
			this.lblTargetPct3.Text = "-888%";
			this.lblTargetPct3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetDiff3
			// 
			this.lblTargetDiff3.Location = new System.Drawing.Point(410, 132);
			this.lblTargetDiff3.Name = "lblTargetDiff3";
			this.lblTargetDiff3.Size = new System.Drawing.Size(52, 13);
			this.lblTargetDiff3.TabIndex = 72;
			this.lblTargetDiff3.Text = "-8,888 cr.";
			this.lblTargetDiff3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPrice3
			// 
			this.lblTargetPrice3.Location = new System.Drawing.Point(358, 132);
			this.lblTargetPrice3.Name = "lblTargetPrice3";
			this.lblTargetPrice3.Size = new System.Drawing.Size(48, 13);
			this.lblTargetPrice3.TabIndex = 71;
			this.lblTargetPrice3.Text = "8,888 cr.";
			this.lblTargetPrice3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnBuyMax3
			// 
			this.btnBuyMax3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyMax3.Location = new System.Drawing.Point(262, 128);
			this.btnBuyMax3.Name = "btnBuyMax3";
			this.btnBuyMax3.Size = new System.Drawing.Size(36, 22);
			this.btnBuyMax3.TabIndex = 27;
			this.btnBuyMax3.Text = "Max";
			this.btnBuyMax3.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnBuyQty3
			// 
			this.btnBuyQty3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyQty3.Location = new System.Drawing.Point(227, 128);
			this.btnBuyQty3.Name = "btnBuyQty3";
			this.btnBuyQty3.Size = new System.Drawing.Size(28, 22);
			this.btnBuyQty3.TabIndex = 26;
			this.btnBuyQty3.Text = "88";
			this.btnBuyQty3.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblBuyPrice3
			// 
			this.lblBuyPrice3.Location = new System.Drawing.Point(302, 132);
			this.lblBuyPrice3.Name = "lblBuyPrice3";
			this.lblBuyPrice3.Size = new System.Drawing.Size(48, 13);
			this.lblBuyPrice3.TabIndex = 68;
			this.lblBuyPrice3.Text = "8,888 cr.";
			this.lblBuyPrice3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnSellAll3
			// 
			this.btnSellAll3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellAll3.Location = new System.Drawing.Point(115, 128);
			this.btnSellAll3.Name = "btnSellAll3";
			this.btnSellAll3.Size = new System.Drawing.Size(44, 22);
			this.btnSellAll3.TabIndex = 25;
			this.btnSellAll3.Text = "All";
			this.btnSellAll3.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnSellQty3
			// 
			this.btnSellQty3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellQty3.Location = new System.Drawing.Point(80, 128);
			this.btnSellQty3.Name = "btnSellQty3";
			this.btnSellQty3.Size = new System.Drawing.Size(28, 22);
			this.btnSellQty3.TabIndex = 24;
			this.btnSellQty3.Text = "88";
			this.btnSellQty3.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblSellPrice3
			// 
			this.lblSellPrice3.Location = new System.Drawing.Point(163, 132);
			this.lblSellPrice3.Name = "lblSellPrice3";
			this.lblSellPrice3.Size = new System.Drawing.Size(48, 13);
			this.lblSellPrice3.TabIndex = 65;
			this.lblSellPrice3.Text = "8,888 cr.";
			this.lblSellPrice3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPct2
			// 
			this.lblTargetPct2.Location = new System.Drawing.Point(466, 108);
			this.lblTargetPct2.Name = "lblTargetPct2";
			this.lblTargetPct2.Size = new System.Drawing.Size(37, 13);
			this.lblTargetPct2.TabIndex = 64;
			this.lblTargetPct2.Text = "-888%";
			this.lblTargetPct2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetDiff2
			// 
			this.lblTargetDiff2.Location = new System.Drawing.Point(410, 108);
			this.lblTargetDiff2.Name = "lblTargetDiff2";
			this.lblTargetDiff2.Size = new System.Drawing.Size(52, 13);
			this.lblTargetDiff2.TabIndex = 63;
			this.lblTargetDiff2.Text = "-8,888 cr.";
			this.lblTargetDiff2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPrice2
			// 
			this.lblTargetPrice2.Location = new System.Drawing.Point(358, 108);
			this.lblTargetPrice2.Name = "lblTargetPrice2";
			this.lblTargetPrice2.Size = new System.Drawing.Size(48, 13);
			this.lblTargetPrice2.TabIndex = 62;
			this.lblTargetPrice2.Text = "8,888 cr.";
			this.lblTargetPrice2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnBuyMax2
			// 
			this.btnBuyMax2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyMax2.Location = new System.Drawing.Point(262, 104);
			this.btnBuyMax2.Name = "btnBuyMax2";
			this.btnBuyMax2.Size = new System.Drawing.Size(36, 22);
			this.btnBuyMax2.TabIndex = 23;
			this.btnBuyMax2.Text = "Max";
			this.btnBuyMax2.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnBuyQty2
			// 
			this.btnBuyQty2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyQty2.Location = new System.Drawing.Point(227, 104);
			this.btnBuyQty2.Name = "btnBuyQty2";
			this.btnBuyQty2.Size = new System.Drawing.Size(28, 22);
			this.btnBuyQty2.TabIndex = 22;
			this.btnBuyQty2.Text = "88";
			this.btnBuyQty2.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblBuyPrice2
			// 
			this.lblBuyPrice2.Location = new System.Drawing.Point(302, 108);
			this.lblBuyPrice2.Name = "lblBuyPrice2";
			this.lblBuyPrice2.Size = new System.Drawing.Size(48, 13);
			this.lblBuyPrice2.TabIndex = 59;
			this.lblBuyPrice2.Text = "8,888 cr.";
			this.lblBuyPrice2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnSellAll2
			// 
			this.btnSellAll2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellAll2.Location = new System.Drawing.Point(115, 104);
			this.btnSellAll2.Name = "btnSellAll2";
			this.btnSellAll2.Size = new System.Drawing.Size(44, 22);
			this.btnSellAll2.TabIndex = 21;
			this.btnSellAll2.Text = "All";
			this.btnSellAll2.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnSellQty2
			// 
			this.btnSellQty2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellQty2.Location = new System.Drawing.Point(80, 104);
			this.btnSellQty2.Name = "btnSellQty2";
			this.btnSellQty2.Size = new System.Drawing.Size(28, 22);
			this.btnSellQty2.TabIndex = 20;
			this.btnSellQty2.Text = "88";
			this.btnSellQty2.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblSellPrice2
			// 
			this.lblSellPrice2.Location = new System.Drawing.Point(163, 108);
			this.lblSellPrice2.Name = "lblSellPrice2";
			this.lblSellPrice2.Size = new System.Drawing.Size(48, 13);
			this.lblSellPrice2.TabIndex = 56;
			this.lblSellPrice2.Text = "8,888 cr.";
			this.lblSellPrice2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPct1
			// 
			this.lblTargetPct1.Location = new System.Drawing.Point(466, 84);
			this.lblTargetPct1.Name = "lblTargetPct1";
			this.lblTargetPct1.Size = new System.Drawing.Size(37, 13);
			this.lblTargetPct1.TabIndex = 55;
			this.lblTargetPct1.Text = "-888%";
			this.lblTargetPct1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetDiff1
			// 
			this.lblTargetDiff1.Location = new System.Drawing.Point(410, 84);
			this.lblTargetDiff1.Name = "lblTargetDiff1";
			this.lblTargetDiff1.Size = new System.Drawing.Size(52, 13);
			this.lblTargetDiff1.TabIndex = 54;
			this.lblTargetDiff1.Text = "-8,888 cr.";
			this.lblTargetDiff1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPrice1
			// 
			this.lblTargetPrice1.Location = new System.Drawing.Point(358, 84);
			this.lblTargetPrice1.Name = "lblTargetPrice1";
			this.lblTargetPrice1.Size = new System.Drawing.Size(48, 13);
			this.lblTargetPrice1.TabIndex = 53;
			this.lblTargetPrice1.Text = "8,888 cr.";
			this.lblTargetPrice1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnBuyMax1
			// 
			this.btnBuyMax1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyMax1.Location = new System.Drawing.Point(262, 80);
			this.btnBuyMax1.Name = "btnBuyMax1";
			this.btnBuyMax1.Size = new System.Drawing.Size(36, 22);
			this.btnBuyMax1.TabIndex = 19;
			this.btnBuyMax1.Text = "Max";
			this.btnBuyMax1.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnBuyQty1
			// 
			this.btnBuyQty1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyQty1.Location = new System.Drawing.Point(227, 80);
			this.btnBuyQty1.Name = "btnBuyQty1";
			this.btnBuyQty1.Size = new System.Drawing.Size(28, 22);
			this.btnBuyQty1.TabIndex = 18;
			this.btnBuyQty1.Text = "88";
			this.btnBuyQty1.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblBuyPrice1
			// 
			this.lblBuyPrice1.Location = new System.Drawing.Point(302, 84);
			this.lblBuyPrice1.Name = "lblBuyPrice1";
			this.lblBuyPrice1.Size = new System.Drawing.Size(48, 13);
			this.lblBuyPrice1.TabIndex = 50;
			this.lblBuyPrice1.Text = "8,888 cr.";
			this.lblBuyPrice1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPctLabel
			// 
			this.lblTargetPctLabel.AutoSize = true;
			this.lblTargetPctLabel.Location = new System.Drawing.Point(476, 34);
			this.lblTargetPctLabel.Name = "lblTargetPctLabel";
			this.lblTargetPctLabel.Size = new System.Drawing.Size(15, 13);
			this.lblTargetPctLabel.TabIndex = 49;
			this.lblTargetPctLabel.Text = "%";
			// 
			// lblTargetDiffLabel
			// 
			this.lblTargetDiffLabel.AutoSize = true;
			this.lblTargetDiffLabel.Location = new System.Drawing.Point(424, 34);
			this.lblTargetDiffLabel.Name = "lblTargetDiffLabel";
			this.lblTargetDiffLabel.Size = new System.Drawing.Size(21, 13);
			this.lblTargetDiffLabel.TabIndex = 48;
			this.lblTargetDiffLabel.Text = "+/-";
			// 
			// lblTargetPriceLabel
			// 
			this.lblTargetPriceLabel.AutoSize = true;
			this.lblTargetPriceLabel.Location = new System.Drawing.Point(360, 34);
			this.lblTargetPriceLabel.Name = "lblTargetPriceLabel";
			this.lblTargetPriceLabel.Size = new System.Drawing.Size(31, 13);
			this.lblTargetPriceLabel.TabIndex = 47;
			this.lblTargetPriceLabel.Text = "Price";
			// 
			// lblTargetPct0
			// 
			this.lblTargetPct0.Location = new System.Drawing.Point(466, 60);
			this.lblTargetPct0.Name = "lblTargetPct0";
			this.lblTargetPct0.Size = new System.Drawing.Size(37, 13);
			this.lblTargetPct0.TabIndex = 46;
			this.lblTargetPct0.Text = "-888%";
			this.lblTargetPct0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetDiff0
			// 
			this.lblTargetDiff0.Location = new System.Drawing.Point(410, 60);
			this.lblTargetDiff0.Name = "lblTargetDiff0";
			this.lblTargetDiff0.Size = new System.Drawing.Size(52, 13);
			this.lblTargetDiff0.TabIndex = 45;
			this.lblTargetDiff0.Text = "-8,888 cr.";
			this.lblTargetDiff0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTargetPrice0
			// 
			this.lblTargetPrice0.Location = new System.Drawing.Point(358, 60);
			this.lblTargetPrice0.Name = "lblTargetPrice0";
			this.lblTargetPrice0.Size = new System.Drawing.Size(48, 13);
			this.lblTargetPrice0.TabIndex = 44;
			this.lblTargetPrice0.Text = "8,888 cr.";
			this.lblTargetPrice0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnBuyMax0
			// 
			this.btnBuyMax0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyMax0.Location = new System.Drawing.Point(262, 56);
			this.btnBuyMax0.Name = "btnBuyMax0";
			this.btnBuyMax0.Size = new System.Drawing.Size(36, 22);
			this.btnBuyMax0.TabIndex = 15;
			this.btnBuyMax0.Text = "Max";
			this.btnBuyMax0.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnBuyQty0
			// 
			this.btnBuyQty0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyQty0.Location = new System.Drawing.Point(227, 56);
			this.btnBuyQty0.Name = "btnBuyQty0";
			this.btnBuyQty0.Size = new System.Drawing.Size(28, 22);
			this.btnBuyQty0.TabIndex = 14;
			this.btnBuyQty0.Text = "88";
			this.btnBuyQty0.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblBuyPrice0
			// 
			this.lblBuyPrice0.Location = new System.Drawing.Point(302, 60);
			this.lblBuyPrice0.Name = "lblBuyPrice0";
			this.lblBuyPrice0.Size = new System.Drawing.Size(48, 13);
			this.lblBuyPrice0.TabIndex = 41;
			this.lblBuyPrice0.Text = "8,888 cr.";
			this.lblBuyPrice0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnSellAll1
			// 
			this.btnSellAll1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellAll1.Location = new System.Drawing.Point(115, 80);
			this.btnSellAll1.Name = "btnSellAll1";
			this.btnSellAll1.Size = new System.Drawing.Size(44, 22);
			this.btnSellAll1.TabIndex = 17;
			this.btnSellAll1.Text = "All";
			this.btnSellAll1.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnSellQty1
			// 
			this.btnSellQty1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellQty1.Location = new System.Drawing.Point(80, 80);
			this.btnSellQty1.Name = "btnSellQty1";
			this.btnSellQty1.Size = new System.Drawing.Size(28, 22);
			this.btnSellQty1.TabIndex = 16;
			this.btnSellQty1.Text = "88";
			this.btnSellQty1.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblSellPrice1
			// 
			this.lblSellPrice1.Location = new System.Drawing.Point(163, 84);
			this.lblSellPrice1.Name = "lblSellPrice1";
			this.lblSellPrice1.Size = new System.Drawing.Size(48, 13);
			this.lblSellPrice1.TabIndex = 38;
			this.lblSellPrice1.Text = "8,888 cr.";
			this.lblSellPrice1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnSellAll0
			// 
			this.btnSellAll0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellAll0.Location = new System.Drawing.Point(115, 56);
			this.btnSellAll0.Name = "btnSellAll0";
			this.btnSellAll0.Size = new System.Drawing.Size(44, 22);
			this.btnSellAll0.TabIndex = 13;
			this.btnSellAll0.Text = "All";
			this.btnSellAll0.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// btnSellQty0
			// 
			this.btnSellQty0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSellQty0.Location = new System.Drawing.Point(80, 56);
			this.btnSellQty0.Name = "btnSellQty0";
			this.btnSellQty0.Size = new System.Drawing.Size(28, 22);
			this.btnSellQty0.TabIndex = 12;
			this.btnSellQty0.Text = "88";
			this.btnSellQty0.Click += new System.EventHandler(this.btnBuySell_Click);
			// 
			// lblSellPrice0
			// 
			this.lblSellPrice0.Location = new System.Drawing.Point(163, 60);
			this.lblSellPrice0.Name = "lblSellPrice0";
			this.lblSellPrice0.Size = new System.Drawing.Size(48, 13);
			this.lblSellPrice0.TabIndex = 35;
			this.lblSellPrice0.Text = "8,888 cr.";
			this.lblSellPrice0.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblTradeTarget
			// 
			this.lblTradeTarget.AutoSize = true;
			this.lblTradeTarget.Location = new System.Drawing.Point(391, 16);
			this.lblTradeTarget.Name = "lblTradeTarget";
			this.lblTradeTarget.Size = new System.Drawing.Size(75, 13);
			this.lblTradeTarget.TabIndex = 28;
			this.lblTradeTarget.Text = "Target System";
			// 
			// lblBuy
			// 
			this.lblBuy.AutoSize = true;
			this.lblBuy.Location = new System.Drawing.Point(273, 34);
			this.lblBuy.Name = "lblBuy";
			this.lblBuy.Size = new System.Drawing.Size(25, 13);
			this.lblBuy.TabIndex = 27;
			this.lblBuy.Text = "Buy";
			// 
			// lblSell
			// 
			this.lblSell.AutoSize = true;
			this.lblSell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSell.Location = new System.Drawing.Point(132, 34);
			this.lblSell.Name = "lblSell";
			this.lblSell.Size = new System.Drawing.Size(24, 13);
			this.lblSell.TabIndex = 26;
			this.lblSell.Text = "Sell";
			// 
			// lblTradeCmdty9
			// 
			this.lblTradeCmdty9.AutoSize = true;
			this.lblTradeCmdty9.Location = new System.Drawing.Point(8, 276);
			this.lblTradeCmdty9.Name = "lblTradeCmdty9";
			this.lblTradeCmdty9.Size = new System.Drawing.Size(41, 13);
			this.lblTradeCmdty9.TabIndex = 25;
			this.lblTradeCmdty9.Text = "Robots";
			// 
			// lblTradeCmdty8
			// 
			this.lblTradeCmdty8.AutoSize = true;
			this.lblTradeCmdty8.Location = new System.Drawing.Point(8, 252);
			this.lblTradeCmdty8.Name = "lblTradeCmdty8";
			this.lblTradeCmdty8.Size = new System.Drawing.Size(52, 13);
			this.lblTradeCmdty8.TabIndex = 24;
			this.lblTradeCmdty8.Text = "Narcotics";
			// 
			// lblTradeCmdty2
			// 
			this.lblTradeCmdty2.AutoSize = true;
			this.lblTradeCmdty2.Location = new System.Drawing.Point(8, 108);
			this.lblTradeCmdty2.Name = "lblTradeCmdty2";
			this.lblTradeCmdty2.Size = new System.Drawing.Size(31, 13);
			this.lblTradeCmdty2.TabIndex = 23;
			this.lblTradeCmdty2.Text = "Food";
			// 
			// lblTradeCmdty0
			// 
			this.lblTradeCmdty0.AutoSize = true;
			this.lblTradeCmdty0.Location = new System.Drawing.Point(8, 60);
			this.lblTradeCmdty0.Name = "lblTradeCmdty0";
			this.lblTradeCmdty0.Size = new System.Drawing.Size(36, 13);
			this.lblTradeCmdty0.TabIndex = 22;
			this.lblTradeCmdty0.Text = "Water";
			// 
			// lblTradeCmdty1
			// 
			this.lblTradeCmdty1.AutoSize = true;
			this.lblTradeCmdty1.Location = new System.Drawing.Point(8, 84);
			this.lblTradeCmdty1.Name = "lblTradeCmdty1";
			this.lblTradeCmdty1.Size = new System.Drawing.Size(27, 13);
			this.lblTradeCmdty1.TabIndex = 21;
			this.lblTradeCmdty1.Text = "Furs";
			// 
			// lblTradeCmdty6
			// 
			this.lblTradeCmdty6.AutoSize = true;
			this.lblTradeCmdty6.Location = new System.Drawing.Point(8, 204);
			this.lblTradeCmdty6.Name = "lblTradeCmdty6";
			this.lblTradeCmdty6.Size = new System.Drawing.Size(50, 13);
			this.lblTradeCmdty6.TabIndex = 20;
			this.lblTradeCmdty6.Text = "Medicine";
			// 
			// lblTradeCmdty5
			// 
			this.lblTradeCmdty5.AutoSize = true;
			this.lblTradeCmdty5.Location = new System.Drawing.Point(8, 180);
			this.lblTradeCmdty5.Name = "lblTradeCmdty5";
			this.lblTradeCmdty5.Size = new System.Drawing.Size(46, 13);
			this.lblTradeCmdty5.TabIndex = 19;
			this.lblTradeCmdty5.Text = "Firearms";
			// 
			// lblTradeCmdty4
			// 
			this.lblTradeCmdty4.AutoSize = true;
			this.lblTradeCmdty4.Location = new System.Drawing.Point(8, 156);
			this.lblTradeCmdty4.Name = "lblTradeCmdty4";
			this.lblTradeCmdty4.Size = new System.Drawing.Size(40, 13);
			this.lblTradeCmdty4.TabIndex = 18;
			this.lblTradeCmdty4.Text = "Games";
			// 
			// lblTradeCmdty3
			// 
			this.lblTradeCmdty3.AutoSize = true;
			this.lblTradeCmdty3.Location = new System.Drawing.Point(8, 132);
			this.lblTradeCmdty3.Name = "lblTradeCmdty3";
			this.lblTradeCmdty3.Size = new System.Drawing.Size(24, 13);
			this.lblTradeCmdty3.TabIndex = 17;
			this.lblTradeCmdty3.Text = "Ore";
			// 
			// lblTradeCmdty7
			// 
			this.lblTradeCmdty7.AutoSize = true;
			this.lblTradeCmdty7.Location = new System.Drawing.Point(8, 228);
			this.lblTradeCmdty7.Name = "lblTradeCmdty7";
			this.lblTradeCmdty7.Size = new System.Drawing.Size(53, 13);
			this.lblTradeCmdty7.TabIndex = 16;
			this.lblTradeCmdty7.Text = "Machines";
			// 
			// boxSystem
			// 
			this.boxSystem.Controls.Add(this.btnMerc);
			this.boxSystem.Controls.Add(this.btnSpecial);
			this.boxSystem.Controls.Add(this.btnNews);
			this.boxSystem.Controls.Add(this.lblSystemPressure);
			this.boxSystem.Controls.Add(this.lblSystemPressurePre);
			this.boxSystem.Controls.Add(this.lblSystemPolSys);
			this.boxSystem.Controls.Add(this.lblSystemSize);
			this.boxSystem.Controls.Add(this.lblSystemTech);
			this.boxSystem.Controls.Add(this.lblSystemPirates);
			this.boxSystem.Controls.Add(this.lblSystemPolice);
			this.boxSystem.Controls.Add(this.lblSystemResource);
			this.boxSystem.Controls.Add(this.lblSystemPiratesLabel);
			this.boxSystem.Controls.Add(this.lblSystemPoliceLabel);
			this.boxSystem.Controls.Add(this.lblSystemResourseLabel);
			this.boxSystem.Controls.Add(this.lblSystemGovtLabel);
			this.boxSystem.Controls.Add(this.lblSystemTechLabel);
			this.boxSystem.Controls.Add(this.lblSystemSizeLabel);
			this.boxSystem.Controls.Add(this.lblSystemName);
			this.boxSystem.Controls.Add(this.lblSystemNameLabel);
			this.boxSystem.Location = new System.Drawing.Point(4, 2);
			this.boxSystem.Name = "boxSystem";
			this.boxSystem.Size = new System.Drawing.Size(240, 206);
			this.boxSystem.TabIndex = 1;
			this.boxSystem.TabStop = false;
			this.boxSystem.Text = "System Info";
			// 
			// btnMerc
			// 
			this.btnMerc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnMerc.Location = new System.Drawing.Point(118, 174);
			this.btnMerc.Name = "btnMerc";
			this.btnMerc.Size = new System.Drawing.Size(112, 22);
			this.btnMerc.TabIndex = 3;
			this.btnMerc.Text = "Mercenary For Hire";
			this.btnMerc.Click += new System.EventHandler(this.btnMerc_Click);
			// 
			// btnSpecial
			// 
			this.btnSpecial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.btnSpecial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSpecial.Location = new System.Drawing.Point(58, 174);
			this.btnSpecial.Name = "btnSpecial";
			this.btnSpecial.Size = new System.Drawing.Size(52, 22);
			this.btnSpecial.TabIndex = 2;
			this.btnSpecial.Text = "Special";
			this.btnSpecial.UseVisualStyleBackColor = false;
			this.btnSpecial.Click += new System.EventHandler(this.btnSpecial_Click);
			// 
			// btnNews
			// 
			this.btnNews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNews.Location = new System.Drawing.Point(8, 174);
			this.btnNews.Name = "btnNews";
			this.btnNews.Size = new System.Drawing.Size(42, 22);
			this.btnNews.TabIndex = 1;
			this.btnNews.Text = "News";
			this.btnNews.Click += new System.EventHandler(this.btnNews_Click);
			// 
			// lblSystemPressure
			// 
			this.lblSystemPressure.Location = new System.Drawing.Point(8, 147);
			this.lblSystemPressure.Name = "lblSystemPressure";
			this.lblSystemPressure.Size = new System.Drawing.Size(168, 16);
			this.lblSystemPressure.TabIndex = 18;
			this.lblSystemPressure.Text = "suffering from extreme bordom.";
			// 
			// lblSystemPressurePre
			// 
			this.lblSystemPressurePre.AutoSize = true;
			this.lblSystemPressurePre.Location = new System.Drawing.Point(8, 134);
			this.lblSystemPressurePre.Name = "lblSystemPressurePre";
			this.lblSystemPressurePre.Size = new System.Drawing.Size(115, 13);
			this.lblSystemPressurePre.TabIndex = 17;
			this.lblSystemPressurePre.Text = "This system is currently";
			// 
			// lblSystemPolSys
			// 
			this.lblSystemPolSys.Location = new System.Drawing.Point(88, 64);
			this.lblSystemPolSys.Name = "lblSystemPolSys";
			this.lblSystemPolSys.Size = new System.Drawing.Size(91, 13);
			this.lblSystemPolSys.TabIndex = 15;
			this.lblSystemPolSys.Text = "Cybernetic State";
			// 
			// lblSystemSize
			// 
			this.lblSystemSize.Location = new System.Drawing.Point(88, 32);
			this.lblSystemSize.Name = "lblSystemSize";
			this.lblSystemSize.Size = new System.Drawing.Size(45, 13);
			this.lblSystemSize.TabIndex = 14;
			this.lblSystemSize.Text = "Medium";
			// 
			// lblSystemTech
			// 
			this.lblSystemTech.Location = new System.Drawing.Point(88, 48);
			this.lblSystemTech.Name = "lblSystemTech";
			this.lblSystemTech.Size = new System.Drawing.Size(82, 13);
			this.lblSystemTech.TabIndex = 13;
			this.lblSystemTech.Text = "Pre-Agricultural";
			// 
			// lblSystemPirates
			// 
			this.lblSystemPirates.Location = new System.Drawing.Point(88, 112);
			this.lblSystemPirates.Name = "lblSystemPirates";
			this.lblSystemPirates.Size = new System.Drawing.Size(53, 13);
			this.lblSystemPirates.TabIndex = 11;
			this.lblSystemPirates.Text = "Abundant";
			// 
			// lblSystemPolice
			// 
			this.lblSystemPolice.Location = new System.Drawing.Point(88, 96);
			this.lblSystemPolice.Name = "lblSystemPolice";
			this.lblSystemPolice.Size = new System.Drawing.Size(53, 13);
			this.lblSystemPolice.TabIndex = 10;
			this.lblSystemPolice.Text = "Moderate";
			// 
			// lblSystemResource
			// 
			this.lblSystemResource.Location = new System.Drawing.Point(88, 80);
			this.lblSystemResource.Name = "lblSystemResource";
			this.lblSystemResource.Size = new System.Drawing.Size(105, 13);
			this.lblSystemResource.TabIndex = 9;
			this.lblSystemResource.Text = "Sweetwater Oceans";
			// 
			// lblSystemPiratesLabel
			// 
			this.lblSystemPiratesLabel.AutoSize = true;
			this.lblSystemPiratesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSystemPiratesLabel.Location = new System.Drawing.Point(8, 112);
			this.lblSystemPiratesLabel.Name = "lblSystemPiratesLabel";
			this.lblSystemPiratesLabel.Size = new System.Drawing.Size(50, 13);
			this.lblSystemPiratesLabel.TabIndex = 7;
			this.lblSystemPiratesLabel.Text = "Pirates:";
			// 
			// lblSystemPoliceLabel
			// 
			this.lblSystemPoliceLabel.AutoSize = true;
			this.lblSystemPoliceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSystemPoliceLabel.Location = new System.Drawing.Point(8, 96);
			this.lblSystemPoliceLabel.Name = "lblSystemPoliceLabel";
			this.lblSystemPoliceLabel.Size = new System.Drawing.Size(46, 13);
			this.lblSystemPoliceLabel.TabIndex = 6;
			this.lblSystemPoliceLabel.Text = "Police:";
			// 
			// lblSystemResourseLabel
			// 
			this.lblSystemResourseLabel.AutoSize = true;
			this.lblSystemResourseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSystemResourseLabel.Location = new System.Drawing.Point(8, 80);
			this.lblSystemResourseLabel.Name = "lblSystemResourseLabel";
			this.lblSystemResourseLabel.Size = new System.Drawing.Size(65, 13);
			this.lblSystemResourseLabel.TabIndex = 5;
			this.lblSystemResourseLabel.Text = "Resource:";
			// 
			// lblSystemGovtLabel
			// 
			this.lblSystemGovtLabel.AutoSize = true;
			this.lblSystemGovtLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSystemGovtLabel.Location = new System.Drawing.Point(8, 64);
			this.lblSystemGovtLabel.Name = "lblSystemGovtLabel";
			this.lblSystemGovtLabel.Size = new System.Drawing.Size(79, 13);
			this.lblSystemGovtLabel.TabIndex = 4;
			this.lblSystemGovtLabel.Text = "Government:";
			// 
			// lblSystemTechLabel
			// 
			this.lblSystemTechLabel.AutoSize = true;
			this.lblSystemTechLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSystemTechLabel.Location = new System.Drawing.Point(8, 48);
			this.lblSystemTechLabel.Name = "lblSystemTechLabel";
			this.lblSystemTechLabel.Size = new System.Drawing.Size(75, 13);
			this.lblSystemTechLabel.TabIndex = 3;
			this.lblSystemTechLabel.Text = "Tech Level:";
			// 
			// lblSystemSizeLabel
			// 
			this.lblSystemSizeLabel.AutoSize = true;
			this.lblSystemSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSystemSizeLabel.Location = new System.Drawing.Point(8, 32);
			this.lblSystemSizeLabel.Name = "lblSystemSizeLabel";
			this.lblSystemSizeLabel.Size = new System.Drawing.Size(35, 13);
			this.lblSystemSizeLabel.TabIndex = 2;
			this.lblSystemSizeLabel.Text = "Size:";
			// 
			// lblSystemName
			// 
			this.lblSystemName.Location = new System.Drawing.Point(88, 16);
			this.lblSystemName.Name = "lblSystemName";
			this.lblSystemName.Size = new System.Drawing.Size(65, 13);
			this.lblSystemName.TabIndex = 1;
			this.lblSystemName.Text = "Tarchannen";
			// 
			// lblSystemNameLabel
			// 
			this.lblSystemNameLabel.AutoSize = true;
			this.lblSystemNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSystemNameLabel.Location = new System.Drawing.Point(8, 16);
			this.lblSystemNameLabel.Name = "lblSystemNameLabel";
			this.lblSystemNameLabel.Size = new System.Drawing.Size(43, 13);
			this.lblSystemNameLabel.TabIndex = 0;
			this.lblSystemNameLabel.Text = "Name:";
			// 
			// boxShipYard
			// 
			this.boxShipYard.Controls.Add(this.btnDesign);
			this.boxShipYard.Controls.Add(this.btnPod);
			this.boxShipYard.Controls.Add(this.lblEscapePod);
			this.boxShipYard.Controls.Add(this.btnEquip);
			this.boxShipYard.Controls.Add(this.btnBuyShip);
			this.boxShipYard.Controls.Add(this.lblEquipForSale);
			this.boxShipYard.Controls.Add(this.lblShipsForSale);
			this.boxShipYard.Location = new System.Drawing.Point(4, 306);
			this.boxShipYard.Name = "boxShipYard";
			this.boxShipYard.Size = new System.Drawing.Size(168, 168);
			this.boxShipYard.TabIndex = 4;
			this.boxShipYard.TabStop = false;
			this.boxShipYard.Text = "Shipyard";
			// 
			// btnDesign
			// 
			this.btnDesign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDesign.Location = new System.Drawing.Point(8, 32);
			this.btnDesign.Name = "btnDesign";
			this.btnDesign.Size = new System.Drawing.Size(54, 22);
			this.btnDesign.TabIndex = 55;
			this.btnDesign.Text = "Design";
			this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
			// 
			// btnPod
			// 
			this.btnPod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPod.Location = new System.Drawing.Point(98, 138);
			this.btnPod.Name = "btnPod";
			this.btnPod.Size = new System.Drawing.Size(58, 22);
			this.btnPod.TabIndex = 54;
			this.btnPod.Text = "Buy Pod";
			this.btnPod.Click += new System.EventHandler(this.btnPod_Click);
			// 
			// lblEscapePod
			// 
			this.lblEscapePod.Location = new System.Drawing.Point(8, 122);
			this.lblEscapePod.Name = "lblEscapePod";
			this.lblEscapePod.Size = new System.Drawing.Size(152, 26);
			this.lblEscapePod.TabIndex = 27;
			this.lblEscapePod.Text = "You can buy an escape pod for  2,000 cr.";
			// 
			// btnEquip
			// 
			this.btnEquip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnEquip.Location = new System.Drawing.Point(43, 85);
			this.btnEquip.Name = "btnEquip";
			this.btnEquip.Size = new System.Drawing.Size(113, 22);
			this.btnEquip.TabIndex = 53;
			this.btnEquip.Text = "Buy/Sell Equipment";
			this.btnEquip.Click += new System.EventHandler(this.btnEquip_Click);
			// 
			// btnBuyShip
			// 
			this.btnBuyShip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBuyShip.Location = new System.Drawing.Point(70, 32);
			this.btnBuyShip.Name = "btnBuyShip";
			this.btnBuyShip.Size = new System.Drawing.Size(86, 22);
			this.btnBuyShip.TabIndex = 52;
			this.btnBuyShip.Text = "View Ship Info";
			this.btnBuyShip.Click += new System.EventHandler(this.btnBuyShip_Click);
			// 
			// lblEquipForSale
			// 
			this.lblEquipForSale.Location = new System.Drawing.Point(8, 69);
			this.lblEquipForSale.Name = "lblEquipForSale";
			this.lblEquipForSale.Size = new System.Drawing.Size(152, 13);
			this.lblEquipForSale.TabIndex = 21;
			this.lblEquipForSale.Text = "There is equipment for sale.";
			// 
			// lblShipsForSale
			// 
			this.lblShipsForSale.Location = new System.Drawing.Point(8, 16);
			this.lblShipsForSale.Name = "lblShipsForSale";
			this.lblShipsForSale.Size = new System.Drawing.Size(152, 13);
			this.lblShipsForSale.TabIndex = 20;
			this.lblShipsForSale.Text = "There are new ships for sale.";
			// 
			// boxDock
			// 
			this.boxDock.Controls.Add(this.btnRepair);
			this.boxDock.Controls.Add(this.btnFuel);
			this.boxDock.Controls.Add(this.lblFuelStatus);
			this.boxDock.Controls.Add(this.lblFuelCost);
			this.boxDock.Controls.Add(this.lblHullStatus);
			this.boxDock.Controls.Add(this.lblRepairCost);
			this.boxDock.Location = new System.Drawing.Point(4, 212);
			this.boxDock.Name = "boxDock";
			this.boxDock.Size = new System.Drawing.Size(240, 90);
			this.boxDock.TabIndex = 2;
			this.boxDock.TabStop = false;
			this.boxDock.Text = "Dock";
			// 
			// btnRepair
			// 
			this.btnRepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRepair.Location = new System.Drawing.Point(180, 56);
			this.btnRepair.Name = "btnRepair";
			this.btnRepair.Size = new System.Drawing.Size(48, 22);
			this.btnRepair.TabIndex = 5;
			this.btnRepair.Text = "Repair";
			this.btnRepair.Click += new System.EventHandler(this.btnRepair_Click);
			// 
			// btnFuel
			// 
			this.btnFuel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnFuel.Location = new System.Drawing.Point(192, 18);
			this.btnFuel.Name = "btnFuel";
			this.btnFuel.Size = new System.Drawing.Size(36, 22);
			this.btnFuel.TabIndex = 4;
			this.btnFuel.Text = "Fuel";
			this.btnFuel.Click += new System.EventHandler(this.btnFuel_Click);
			// 
			// lblFuelStatus
			// 
			this.lblFuelStatus.Location = new System.Drawing.Point(8, 16);
			this.lblFuelStatus.Name = "lblFuelStatus";
			this.lblFuelStatus.Size = new System.Drawing.Size(162, 13);
			this.lblFuelStatus.TabIndex = 20;
			this.lblFuelStatus.Text = "You have fuel to fly 88 parsecs.";
			// 
			// lblFuelCost
			// 
			this.lblFuelCost.Location = new System.Drawing.Point(8, 31);
			this.lblFuelCost.Name = "lblFuelCost";
			this.lblFuelCost.Size = new System.Drawing.Size(121, 13);
			this.lblFuelCost.TabIndex = 19;
			this.lblFuelCost.Text = "A full tank costs 888 cr.";
			// 
			// lblHullStatus
			// 
			this.lblHullStatus.Location = new System.Drawing.Point(8, 52);
			this.lblHullStatus.Name = "lblHullStatus";
			this.lblHullStatus.Size = new System.Drawing.Size(152, 13);
			this.lblHullStatus.TabIndex = 18;
			this.lblHullStatus.Text = "Your hull strength is at 888%.";
			// 
			// lblRepairCost
			// 
			this.lblRepairCost.Location = new System.Drawing.Point(8, 67);
			this.lblRepairCost.Name = "lblRepairCost";
			this.lblRepairCost.Size = new System.Drawing.Size(150, 13);
			this.lblRepairCost.TabIndex = 19;
			this.lblRepairCost.Text = "Full repairs will cost 8,888 cr.";
			// 
			// picLine
			// 
			this.picLine.BackColor = System.Drawing.Color.DimGray;
			this.picLine.Location = new System.Drawing.Point(0, 0);
			this.picLine.Name = "picLine";
			this.picLine.Size = new System.Drawing.Size(770, 1);
			this.picLine.TabIndex = 132;
			this.picLine.TabStop = false;
			// 
			// dlgOpen
			// 
			this.dlgOpen.Filter = "Saved-Game Files (*.sav)|*.sav|All Files (*.*)|*.*";
			// 
			// dlgSave
			// 
			this.dlgSave.FileName = "SpaceTrader.sav";
			this.dlgSave.Filter = "Saved-Game Files (*.sav)|*.sav|All Files (*.*)|*.*";
			// 
			// ilChartImages
			// 
			this.ilChartImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilChartImages.ImageStream")));
			this.ilChartImages.TransparentColor = System.Drawing.Color.White;
			this.ilChartImages.Images.SetKeyName(0, "");
			this.ilChartImages.Images.SetKeyName(1, "");
			this.ilChartImages.Images.SetKeyName(2, "");
			this.ilChartImages.Images.SetKeyName(3, "");
			this.ilChartImages.Images.SetKeyName(4, "");
			this.ilChartImages.Images.SetKeyName(5, "");
			this.ilChartImages.Images.SetKeyName(6, "");
			this.ilChartImages.Images.SetKeyName(7, "");
			// 
			// ilShipImages
			// 
			this.ilShipImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilShipImages.ImageStream")));
			this.ilShipImages.TransparentColor = System.Drawing.Color.White;
			this.ilShipImages.Images.SetKeyName(0, "");
			this.ilShipImages.Images.SetKeyName(1, "");
			this.ilShipImages.Images.SetKeyName(2, "");
			this.ilShipImages.Images.SetKeyName(3, "");
			this.ilShipImages.Images.SetKeyName(4, "");
			this.ilShipImages.Images.SetKeyName(5, "");
			this.ilShipImages.Images.SetKeyName(6, "");
			this.ilShipImages.Images.SetKeyName(7, "");
			this.ilShipImages.Images.SetKeyName(8, "");
			this.ilShipImages.Images.SetKeyName(9, "");
			this.ilShipImages.Images.SetKeyName(10, "");
			this.ilShipImages.Images.SetKeyName(11, "");
			this.ilShipImages.Images.SetKeyName(12, "");
			this.ilShipImages.Images.SetKeyName(13, "");
			this.ilShipImages.Images.SetKeyName(14, "");
			this.ilShipImages.Images.SetKeyName(15, "");
			this.ilShipImages.Images.SetKeyName(16, "");
			this.ilShipImages.Images.SetKeyName(17, "");
			this.ilShipImages.Images.SetKeyName(18, "");
			this.ilShipImages.Images.SetKeyName(19, "");
			this.ilShipImages.Images.SetKeyName(20, "");
			this.ilShipImages.Images.SetKeyName(21, "");
			this.ilShipImages.Images.SetKeyName(22, "");
			this.ilShipImages.Images.SetKeyName(23, "");
			this.ilShipImages.Images.SetKeyName(24, "");
			this.ilShipImages.Images.SetKeyName(25, "");
			this.ilShipImages.Images.SetKeyName(26, "");
			this.ilShipImages.Images.SetKeyName(27, "");
			this.ilShipImages.Images.SetKeyName(28, "");
			this.ilShipImages.Images.SetKeyName(29, "");
			this.ilShipImages.Images.SetKeyName(30, "");
			this.ilShipImages.Images.SetKeyName(31, "");
			this.ilShipImages.Images.SetKeyName(32, "");
			this.ilShipImages.Images.SetKeyName(33, "");
			this.ilShipImages.Images.SetKeyName(34, "");
			this.ilShipImages.Images.SetKeyName(35, "");
			this.ilShipImages.Images.SetKeyName(36, "");
			this.ilShipImages.Images.SetKeyName(37, "");
			this.ilShipImages.Images.SetKeyName(38, "");
			this.ilShipImages.Images.SetKeyName(39, "");
			this.ilShipImages.Images.SetKeyName(40, "");
			this.ilShipImages.Images.SetKeyName(41, "");
			this.ilShipImages.Images.SetKeyName(42, "");
			this.ilShipImages.Images.SetKeyName(43, "");
			this.ilShipImages.Images.SetKeyName(44, "");
			this.ilShipImages.Images.SetKeyName(45, "");
			this.ilShipImages.Images.SetKeyName(46, "");
			this.ilShipImages.Images.SetKeyName(47, "");
			this.ilShipImages.Images.SetKeyName(48, "");
			this.ilShipImages.Images.SetKeyName(49, "");
			this.ilShipImages.Images.SetKeyName(50, "");
			this.ilShipImages.Images.SetKeyName(51, "");
			this.ilShipImages.Images.SetKeyName(52, "");
			this.ilShipImages.Images.SetKeyName(53, "");
			this.ilShipImages.Images.SetKeyName(54, "");
			this.ilShipImages.Images.SetKeyName(55, "");
			this.ilShipImages.Images.SetKeyName(56, "");
			this.ilShipImages.Images.SetKeyName(57, "");
			this.ilShipImages.Images.SetKeyName(58, "");
			this.ilShipImages.Images.SetKeyName(59, "");
			this.ilShipImages.Images.SetKeyName(60, "");
			this.ilShipImages.Images.SetKeyName(61, "");
			this.ilShipImages.Images.SetKeyName(62, "");
			this.ilShipImages.Images.SetKeyName(63, "");
			this.ilShipImages.Images.SetKeyName(64, "");
			this.ilShipImages.Images.SetKeyName(65, "");
			this.ilShipImages.Images.SetKeyName(66, "");
			this.ilShipImages.Images.SetKeyName(67, "");
			// 
			// ilDirectionImages
			// 
			this.ilDirectionImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilDirectionImages.ImageStream")));
			this.ilDirectionImages.TransparentColor = System.Drawing.Color.White;
			this.ilDirectionImages.Images.SetKeyName(0, "");
			this.ilDirectionImages.Images.SetKeyName(1, "");
			this.ilDirectionImages.Images.SetKeyName(2, "");
			this.ilDirectionImages.Images.SetKeyName(3, "");
			// 
			// ilEquipmentImages
			// 
			this.ilEquipmentImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilEquipmentImages.ImageStream")));
			this.ilEquipmentImages.TransparentColor = System.Drawing.Color.Transparent;
			this.ilEquipmentImages.Images.SetKeyName(0, "");
			this.ilEquipmentImages.Images.SetKeyName(1, "");
			this.ilEquipmentImages.Images.SetKeyName(2, "");
			this.ilEquipmentImages.Images.SetKeyName(3, "");
			this.ilEquipmentImages.Images.SetKeyName(4, "");
			this.ilEquipmentImages.Images.SetKeyName(5, "");
			this.ilEquipmentImages.Images.SetKeyName(6, "");
			this.ilEquipmentImages.Images.SetKeyName(7, "");
			this.ilEquipmentImages.Images.SetKeyName(8, "");
			this.ilEquipmentImages.Images.SetKeyName(9, "");
			this.ilEquipmentImages.Images.SetKeyName(10, "");
			this.ilEquipmentImages.Images.SetKeyName(11, "");
			this.ilEquipmentImages.Images.SetKeyName(12, "");
			this.ilEquipmentImages.Images.SetKeyName(13, "");
			this.ilEquipmentImages.Images.SetKeyName(14, "");
			this.ilEquipmentImages.Images.SetKeyName(15, "");
			// 
			// SpaceTrader
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(768, 505);
			this.Controls.Add(this.picLine);
			this.Controls.Add(this.boxDock);
			this.Controls.Add(this.boxCargo);
			this.Controls.Add(this.boxTargetSystem);
			this.Controls.Add(this.boxGalacticChart);
			this.Controls.Add(this.boxShortRangeChart);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.boxSystem);
			this.Controls.Add(this.boxShipYard);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Menu = this.mnuMain;
			this.Name = "SpaceTrader";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Space Trader";
			this.Load += new System.EventHandler(this.SpaceTrader_Load);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.SpaceTrader_Closing);
			((System.ComponentModel.ISupportInitialize)(this.picGalacticChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picShortRangeChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelCash)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelBays)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelCosts)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanelExtra)).EndInit();
			this.boxShortRangeChart.ResumeLayout(false);
			this.boxGalacticChart.ResumeLayout(false);
			this.boxTargetSystem.ResumeLayout(false);
			this.boxTargetSystem.PerformLayout();
			this.boxCargo.ResumeLayout(false);
			this.boxCargo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picCargoLine3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picCargoLine2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picCargoLine0)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picCargoLine1)).EndInit();
			this.boxSystem.ResumeLayout(false);
			this.boxSystem.PerformLayout();
			this.boxShipYard.ResumeLayout(false);
			this.boxDock.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.picLine)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void AddHighScore(HighScoreRecord highScore)
		{
			HighScoreRecord[]	highScores	= Functions.GetHighScores(this);
			highScores[0]									= highScore;
			Array.Sort(highScores);

			Functions.SaveFile(Consts.HighScoreFile, STSerializableObject.ArrayToArrayList(highScores), this);
		}

		private void CargoBuy(int tradeItem, bool max)
		{
			game.CargoBuySystem(tradeItem, max, this);
			UpdateAll();
		}

		private void CargoSell(int tradeItem, bool all)
		{
			if (game.PriceCargoSell[tradeItem] > 0)
				game.CargoSellSystem(tradeItem, all, this);
			else
				game.CargoDump(tradeItem, this);
			UpdateAll();
		}

		private void ClearHighScores()
		{
			HighScoreRecord[]	highScores	= new HighScoreRecord[3];
			Functions.SaveFile(Consts.HighScoreFile, STSerializableObject.ArrayToArrayList(highScores), this);
		}

		private void GameEnd()
		{
			SetInGameControlsEnabled(false);

			AlertType	alertType	= AlertType.Alert;
			switch (game.EndStatus)
			{
				case GameEndType.Killed:
					alertType	= AlertType.GameEndKilled;
					break;
				case GameEndType.Retired:
					alertType	= AlertType.GameEndRetired;
					break;
				case GameEndType.BoughtMoon:
					alertType	= AlertType.GameEndBoughtMoon;
					break;
			}

			FormAlert.Alert(alertType, this);

			FormAlert.Alert(AlertType.GameEndScore, this, Functions.FormatNumber(game.Score / 10),
				Functions.FormatNumber(game.Score % 10));

			HighScoreRecord	candidate	= new HighScoreRecord(game.Commander.Name, game.Score, game.EndStatus,
				game.Commander.Days, game.Commander.Worth, game.Difficulty);
			if (candidate > Functions.GetHighScores(this)[0])
			{
				if (game.CheatEnabled)
					FormAlert.Alert(AlertType.GameEndHighScoreCheat, this);
				else
				{
					AddHighScore(candidate);
					FormAlert.Alert(AlertType.GameEndHighScoreAchieved, this);
				}
			}
			else
				FormAlert.Alert(AlertType.GameEndHighScoreMissed, this);

			Game.CurrentGame	= null;
			game							= null;
		}

		private string GetRegistrySetting(string settingName, string defaultValue)
		{
			string	settingValue	= defaultValue;

			try
			{
				RegistryKey	key	= Functions.GetRegistryKey();
				object	objectValue	= key.GetValue(settingName);
				if (objectValue != null)
					settingValue	= objectValue.ToString();
				key.Close();
			}
			catch (NullReferenceException ex)
			{
				FormAlert.Alert(AlertType.RegistryError, this, ex.Message);
			}

			return settingValue;
		}

		// Make sure all directories exists.
		private void InitFileStructure()
		{
			string[]	paths	= new string[]
												{
													Consts.CustomDirectory,
													Consts.CustomImagesDirectory,
													Consts.CustomTemplatesDirectory,
													Consts.DataDirectory,
													Consts.SaveDirectory
												};

			foreach (string path in paths)
			{
				if (!Directory.Exists(path))
					Directory.CreateDirectory(path);
			}

			dlgOpen.InitialDirectory	= Consts.SaveDirectory;
			dlgSave.InitialDirectory	= Consts.SaveDirectory;
		}

		private void LoadGame(string fileName)
		{
			try
			{
				object		obj		= Functions.LoadFile(fileName, false, this);
				if (obj != null)
				{
					game					= new Game((Hashtable)obj, this);
					SaveGameFile	= fileName;
					SaveGameDays	= game.Commander.Days;

					SetInGameControlsEnabled(true);
					UpdateAll();
				}
			}
			catch (FutureVersionException)
			{
				FormAlert.Alert(AlertType.FileErrorOpen, this, fileName, Strings.FileFutureVersion);
			}
		}

		private void SaveGame(string fileName, bool saveFileName)
		{
			if (Functions.SaveFile(fileName, game.Serialize(), this) && saveFileName)
				SaveGameFile	= fileName;

			SaveGameDays	= game.Commander.Days;
		}

		private void SetInGameControlsEnabled(bool enabled)
		{
			mnuGameSave.Enabled				= enabled;
			mnuGameSaveAs.Enabled			= enabled;
			mnuRetire.Enabled					= enabled;
			mnuViewCommander.Enabled	= enabled;
			mnuViewShip.Enabled				= enabled;
			mnuViewPersonnel.Enabled	= enabled;
			mnuViewQuests.Enabled			= enabled;
			mnuViewBank.Enabled				= enabled;
		}

		private void SetRegistrySetting(string settingName, string settingValue)
		{
			try
			{
				RegistryKey	key	= Functions.GetRegistryKey();
				key.SetValue(settingName, settingValue);
				key.Close();
			}
			catch (NullReferenceException ex)
			{
				FormAlert.Alert(AlertType.RegistryError, this, ex.Message);
			}
		}

		public void UpdateAll()
		{
			UpdateCargo();
			UpdateDock();
			UpdateShipyard();
			UpdateStatusBar();
			UpdateSystemInfo();
			UpdateTargetSystemInfo();
			UpdateCharts();
		}

		private void UpdateCargo()
		{
			int	i;

			if (game == null || game.Commander.CurrentSystem == null)
			{
				for (i = 0; i < lblSellPrice.Length; i++)
				{
					lblSellPrice[i].Text		= "";
					lblBuyPrice[i].Text			= "";
					lblTargetPrice[i].Text	= "";
					lblTargetDiff[i].Text		= "";
					lblTargetPct[i].Text		= "";
					btnSellQty[i].Visible		= false;
					btnSellAll[i].Visible		= false;
					btnBuyQty[i].Visible		= false;
					btnBuyMax[i].Visible		= false;
				}
			}
			else
			{
				int[]				buy			= game.PriceCargoBuy;
				int[]				sell		= game.PriceCargoSell;
				Commander		cmdr		= game.Commander;
				StarSystem	warpSys	= game.WarpSystem;

				for (i = 0; i < lblSellPrice.Length; i++)
				{
					int price = warpSys == null ? 0 : Consts.TradeItems[i].StandardPrice(warpSys);

					lblSellPrice[i].Text		= sell[i] > 0 ? Functions.FormatMoney(sell[i]) : Strings.CargoSellNA;
					btnSellQty[i].Text			= cmdr.Ship.Cargo[i].ToString();
					btnSellQty[i].Visible		= true;
					btnSellAll[i].Text			= sell[i] > 0 ? "All" : "Dump";
					btnSellAll[i].Visible		= true;
					lblBuyPrice[i].Text			= buy[i] > 0 ? Functions.FormatMoney(buy[i]) : Strings.CargoBuyNA;
					btnBuyQty[i].Text				= cmdr.CurrentSystem.TradeItems[i].ToString();
					btnBuyQty[i].Visible		= buy[i] > 0;
					btnBuyMax[i].Visible		= buy[i] > 0;

					if (sell[i] * cmdr.Ship.Cargo[i] > cmdr.PriceCargo[i])
						lblSellPrice[i].Font	= lblSystemNameLabel.Font;
					else
						lblSellPrice[i].Font	= lblSell.Font;

					if (warpSys != null && warpSys.DestOk && price > 0)
						lblTargetPrice[i].Text	= Functions.FormatMoney(price);
					else
						lblTargetPrice[i].Text	= "-----------";

					if (warpSys != null && warpSys.DestOk && price > 0 && buy[i] > 0)
					{
						int	diff								= price - buy[i];
						lblTargetDiff[i].Text		= (diff > 0 ? "+" : "") + Functions.FormatMoney(diff);
						lblTargetPct[i].Text		= (diff > 0 ? "+" : "") + Functions.FormatNumber(100 * diff / buy[i]) + "%";
						lblBuyPrice[i].Font			= (diff > 0 && cmdr.CurrentSystem.TradeItems[i] > 0) ?
																			lblSystemNameLabel.Font : lblBuy.Font;
					}
					else
					{
						lblTargetDiff[i].Text		= "------------";
						lblTargetPct[i].Text		= "--------";
						lblBuyPrice[i].Font			= lblBuy.Font;
					}

					lblTargetPrice[i].Font	= lblBuyPrice[i].Font;
					lblTargetDiff[i].Font		= lblBuyPrice[i].Font;
					lblTargetPct[i].Font		= lblBuyPrice[i].Font;
				}
			}
		}

		private void UpdateCharts()
		{
			picGalacticChart.Refresh();
			picShortRangeChart.Refresh();

			if (game == null)
			{
				lblWormholeLabel.Visible		= false;
				lblWormhole.Visible					= false;
				btnJump.Visible							= false;
				btnFind.Visible							= false;
			}
			else
			{
				if (game.TargetWormhole)
				{
					lblWormholeLabel.Visible	= true;
					lblWormhole.Visible				= true;
					lblWormhole.Text					= game.WarpSystem.Name;
				}
				else
				{
					lblWormholeLabel.Visible		= false;
					lblWormhole.Visible					= false;
				}
				btnJump.Visible							= game.CanSuperWarp;
				btnFind.Visible							= true;
			}
		}

		private void UpdateDock()
		{
			if (game == null)
			{
				lblFuelStatus.Text	= "";
				lblFuelCost.Text		= "";
				btnFuel.Visible			= false;
				lblHullStatus.Text	= "";
				lblRepairCost.Text	= "";
				btnRepair.Visible		= false;
			}
			else
			{
				Ship	ship					= game.Commander.Ship;

				lblFuelStatus.Text	= Functions.StringVars(Strings.DockFuelStatus, Functions.Multiples(ship.Fuel, "parsec"));
				int	tanksEmpty			= ship.FuelTanks - ship.Fuel;
				lblFuelCost.Text		= tanksEmpty > 0 ? Functions.StringVars(Strings.DockFuelCost,
					Functions.FormatMoney(tanksEmpty * ship.FuelCost)) : Strings.DockFuelFull;
				btnFuel.Visible			= tanksEmpty > 0;

				lblHullStatus.Text	= Functions.StringVars(Strings.DockHullStatus,
					Functions.FormatNumber((int)Math.Floor((double)100 * ship.Hull / ship.HullStrength)));
				int	hullLoss				= ship.HullStrength - ship.Hull;
				lblRepairCost.Text	= hullLoss > 0 ? Functions.StringVars(Strings.DockHullCost,
					Functions.FormatMoney(hullLoss * ship.RepairCost)) : Strings.DockHullFull;
				btnRepair.Visible		= hullLoss > 0;
			}
		}

		private void UpdateShipyard()
		{
			if (game == null)
			{
				lblShipsForSale.Text	= "";
				lblEquipForSale.Text	= "";
				lblEscapePod.Text			= "";
				btnPod.Visible				= false;
				btnBuyShip.Visible		= false;
				btnDesign.Visible			= false;
				btnEquip.Visible			= false;
			}
			else
			{
				bool	noTech					= ((int)game.Commander.CurrentSystem.TechLevel <
					(int)Consts.ShipSpecs[(int)ShipType.Flea].MinimumTechLevel);

				lblShipsForSale.Text	= noTech ? Strings.ShipyardShipNoSale : Strings.ShipyardShipForSale;
				btnBuyShip.Visible		= true;
				btnDesign.Visible			= (Game.CurrentGame.Commander.CurrentSystem.Shipyard != null);

				lblEquipForSale.Text	= noTech ? Strings.ShipyardEquipNoSale : Strings.ShipyardEquipForSale;
				btnEquip.Visible			= true;

				btnPod.Visible				= false;
				if (game.Commander.Ship.EscapePod)
					lblEscapePod.Text		= Strings.ShipyardPodInstalled;
				else if (noTech)
					lblEscapePod.Text		= Strings.ShipyardPodNoSale;
				else if (game.Commander.Cash < 2000)
					lblEscapePod.Text		= Strings.ShipyardPodIF;
				else
				{
					lblEscapePod.Text		= Strings.ShipyardPodCost;
					btnPod.Visible			= true;
				}
			}
		}

		public void UpdateStatusBar()
		{
			if (game == null)
			{
				statusBarPanelCash.Text		= "";
				statusBarPanelBays.Text		= "";
				statusBarPanelCosts.Text	= "";
				statusBarPanelExtra.Text	= "No Game Loaded.";
			}
			else
			{
				statusBarPanelCash.Text		= "Cash: " + Functions.FormatMoney(game.Commander.Cash);
				statusBarPanelBays.Text		= "Bays: " + game.Commander.Ship.FilledCargoBays.ToString() + "/" +
					game.Commander.Ship.CargoBays.ToString();
				statusBarPanelCosts.Text	= "Current Costs: " + Functions.FormatMoney(game.CurrentCosts);
				statusBarPanelExtra.Text	= "";
			}
		}

		private void UpdateSystemInfo()
		{
			if (game == null || game.Commander.CurrentSystem == null)
			{
				lblSystemName.Text						= "";
				lblSystemSize.Text						= "";
				lblSystemTech.Text						= "";
				lblSystemPolSys.Text					= "";
				lblSystemResource.Text				= "";
				lblSystemPolice.Text					= "";
				lblSystemPirates.Text					= "";
				lblSystemPressure.Text				= "";
				lblSystemPressurePre.Visible	= false;
				btnNews.Visible								= false;
				btnMerc.Visible								= false;
				btnSpecial.Visible						= false;
			}
			else
			{
				StarSystem		system					= game.Commander.CurrentSystem;
				CrewMember[]	mercs						= system.MercenariesForHire;

				lblSystemName.Text						= system.Name;
				lblSystemSize.Text						= Strings.Sizes[(int)system.Size];
				lblSystemTech.Text						= Strings.TechLevelNames[(int)system.TechLevel];
				lblSystemPolSys.Text					= system.PoliticalSystem.Name;
				lblSystemResource.Text				= Strings.SpecialResources[(int)system.SpecialResource];
				lblSystemPolice.Text					= Strings.ActivityLevels[(int)system.PoliticalSystem.ActivityPolice];
				lblSystemPirates.Text					= Strings.ActivityLevels[(int)system.PoliticalSystem.ActivityPirates];
				lblSystemPressure.Text				= Strings.SystemPressures[(int)system.SystemPressure];
				lblSystemPressurePre.Visible	= true;
				btnNews.Visible								= true;
				btnMerc.Visible								= mercs.Length > 0;
				if (btnMerc.Visible)
				{
					tipMerc.SetToolTip(btnMerc, Functions.StringVars(Strings.MercenariesForHire, mercs.Length == 1 ? mercs[0].Name :
						mercs.Length.ToString() + Strings.Mercenaries));
				}
				btnSpecial.Visible						= system.ShowSpecialButton();
				if (btnSpecial.Visible)
					tipSpecial.SetToolTip(btnSpecial, system.SpecialEvent.Title);
			}
		}

		private void UpdateTargetSystemInfo()
		{
			btnNextSystem.Visible						= game != null;
			btnPrevSystem.Visible						= game != null;

			if (game == null || game.WarpSystem == null)
			{
				lblTargetName.Text						= "";
				lblTargetSize.Text						= "";
				lblTargetTech.Text						= "";
				lblTargetPolSys.Text					= "";
				lblTargetResource.Text				= "";
				lblTargetPolice.Text					= "";
				lblTargetPirates.Text					= "";
				lblTargetDistance.Text				= "";
				lblTargetOutOfRange.Visible		= false;
				btnWarp.Visible								= false;
				btnTrack.Visible							= false;
			}
			else
			{
				StarSystem	system						= game.WarpSystem;
				int					distance					= Functions.Distance(game.Commander.CurrentSystem, system);

				lblTargetName.Text						= system.Name;
				lblTargetSize.Text						= Strings.Sizes[(int)system.Size];
				lblTargetTech.Text						= Strings.TechLevelNames[(int)system.TechLevel];
				lblTargetPolSys.Text					= system.PoliticalSystem.Name;
				lblTargetResource.Text				= system.Visited ? Strings.SpecialResources[(int)system.SpecialResource] :
																				Strings.Unknown;
				lblTargetPolice.Text					= Strings.ActivityLevels[(int)system.PoliticalSystem.ActivityPolice];
				lblTargetPirates.Text					= Strings.ActivityLevels[(int)system.PoliticalSystem.ActivityPirates];
				lblTargetDistance.Text				= distance.ToString();
				lblTargetOutOfRange.Visible		= !system.DestOk && system != game.Commander.CurrentSystem;
				btnWarp.Visible								= system.DestOk;
				btnTrack.Visible							= lblTargetOutOfRange.Visible && system != game.TrackedSystem;
			}
		}

		#endregion

		#region Event Handlers

		private void SpaceTrader_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (game == null || game.Commander.Days == SaveGameDays ||
				FormAlert.Alert(AlertType.GameAbandonConfirm, this) == DialogResult.Yes)
			{
				if (this.WindowState == FormWindowState.Normal)
				{
					SetRegistrySetting("X", this.Left.ToString());
					SetRegistrySetting("Y", this.Top.ToString());
				}
			}
			else
				e.Cancel	= true;
		}

		private void SpaceTrader_Load(object sender, System.EventArgs e)
		{
			this.Left	= int.Parse(GetRegistrySetting("X", "0"));
			this.Top	= int.Parse(GetRegistrySetting("Y", "0"));

			FormAlert.Alert(AlertType.AppStart, this);
		}

		private void btnBuySell_Click(object sender, System.EventArgs e)
		{
			string	name	= ((Button)sender).Name;
			bool		all		= name.IndexOf("Qty") < 0;
			int			index	= int.Parse(name.Substring(name.Length - 1));

			if (name.IndexOf("Buy") < 0)
				CargoSell(index, all);
			else
				CargoBuy(index, all);
		}

		private void btnBuyShip_Click(object sender, System.EventArgs e)
		{
			(new FormShipList()).ShowDialog(this);
			UpdateAll();
		}

		private void btnDesign_Click(object sender, System.EventArgs e)
		{
			(new Form_Shipyard()).ShowDialog(this);
			UpdateAll();
		}

		private void btnEquip_Click(object sender, System.EventArgs e)
		{
			(new FormEquipment()).ShowDialog(this);
			UpdateAll();
		}

		private void btnFind_Click(object sender, System.EventArgs e)
		{
			FormFind	form	= new FormFind();
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				Ship			ship		= game.Commander.Ship;

				string[]	words		= form.SystemName.Split(' ');

				string		first		= words.Length > 0 ? words[0] : "";
				string		second	= words.Length > 1 ? words[1] : "";
				string		third		= words.Length > 2 ? words[2] : "";
				int				num1		= Functions.IsInt(second) ? int.Parse(second) : 0;
				int				num2		= Functions.IsInt(third) ? int.Parse(third) : 0;

				bool			find		= false;

				if (game.CheatEnabled)
				{
					switch (first)
					{
						case "Bazaar":
							game.ChanceOfTradeInOrbit	= Math.Max(0, Math.Min(1000, num1));
							break;
						case "Cover":
							if (num1 >= 0 && num1 < ship.Shields.Length && num2 >= 0 && num2 < Consts.Shields.Length)
								ship.Shields[num1]	= (Shield)Consts.Shields[num2].Clone();
							break;
						case "DeLorean":
							game.Commander.Days	= Math.Max(0, num1);
							break;
						case "Diamond":
							ship.HullUpgraded	= !ship.HullUpgraded;
							break;
						case "Energize":
							game.CanSuperWarp	= !game.CanSuperWarp;
							break;
						case "Events":
							if (second == "Reset")
								game.ResetVeryRareEncounters();
							else
							{
								string	text	= "";
								for (IEnumerator list = game.VeryRareEncounters.GetEnumerator(); list.MoveNext();)
									text	+= Strings.VeryRareEncounters[(int)list.Current] + Environment.NewLine;
								text	= text.Trim();

								FormAlert.Alert(AlertType.Alert, this, "Remaining Very Rare Encounters", text);
							}
							break;
						case "Fame":
							game.Commander.ReputationScore	= Math.Max(0, num1);
							break;
						case "Go":
							game.SelectedSystemName	= second;
							if (game.SelectedSystem.Name.ToLower() == second.ToLower())
							{
								if (game.AutoSave)
									SaveGame(SAVE_DEPARTURE, false);

								game.WarpDirect();

								if (game.AutoSave)
									SaveGame(SAVE_ARRIVAL, false);
							}
							break;
						case "Ice":
						{
							switch (second)
							{
								case "Pirate":
									game.Commander.KillsPirate	= Math.Max(0, num2);
									break;
								case "Police":
									game.Commander.KillsPolice	= Math.Max(0, num2);
									break;
								case "Trader":
									game.Commander.KillsTrader	= Math.Max(0, num2);
									break;
							}
						}
							break;
						case "Indemnity":
							game.Commander.NoClaim	= Math.Max(0, num1);
							break;
						case "IOU":
							game.Commander.Debt	= Math.Max(0, num1);
							break;
						case "Iron":
							if (num1 >= 0 && num1 < ship.Weapons.Length && num2 >= 0 && num2 < Consts.Weapons.Length)
								ship.Weapons[num1]	= (Weapon)Consts.Weapons[num2].Clone();
							break;
						case "Juice":
							ship.Fuel	= Math.Max(0, Math.Min(ship.FuelTanks, num1));
							break;
						case "Knack":
							if (num1 >= 0 && num1 < game.Mercenaries.Length)
							{
								string[] skills = third.Split(',');
								for (int i = 0; i < game.Mercenaries[num1].Skills.Length && i < skills.Length; i++)
								{
									if (Functions.IsInt(skills[i]))
										game.Mercenaries[num1].Skills[i]	= Math.Max(1, Math.Min(Consts.MaxSkill, int.Parse(skills[i])));
								}
							}
							break;
						case "L'Engle":
							game.FabricRipProbability	= Math.Max(0, Math.Min(Consts.FabricRipInitialProbability, num1));
							break;
						case "LifeBoat":
							ship.EscapePod	= !ship.EscapePod;
							break;
						case "Monster.com":
							(new FormMonster()).ShowDialog(this);
							break;
						case "PlanB":
							game.AutoSave	= true;
							break;
						case "Posse":
							if (num1 > 0 && num1 < ship.Crew.Length && num2 > 0 && num2 < game.Mercenaries.Length &&
								!Consts.SpecialCrewMemberIds.Contains((CrewMemberId)num2))
							{
								int	skill	= ship.Trader;
								ship.Crew[num1]	= game.Mercenaries[num2];
								if (ship.Trader != skill)
									game.RecalculateBuyPrices(game.Commander.CurrentSystem);
							}
							break;
						case "RapSheet":
							game.Commander.PoliceRecordScore	= num1;
							break;
						case "Rarity":
							game.ChanceOfVeryRareEncounter	= Math.Max(0, Math.Min(1000, num1));
							break;
						case "Scratch":
							game.Commander.Cash	= Math.Max(0, num1);
							break;
						case "Skin":
							ship.Hull	= Math.Max(0, Math.Min(ship.HullStrength, num1));
							break;
						case "Status":
						{
							switch (second)
							{
								case "Artifact":
									game.QuestStatusArtifact	= Math.Max(0, num2);
									break;
								case "Dragonfly":
									game.QuestStatusDragonfly	= Math.Max(0, num2);
									break;
								case "Experiment":
									game.QuestStatusExperiment	= Math.Max(0, num2);
									break;
								case "Gemulon":
									game.QuestStatusGemulon	= Math.Max(0, num2);
									break;
								case "Japori":
									game.QuestStatusJapori	= Math.Max(0, num2);
									break;
								case "Jarek":
									game.QuestStatusJarek	= Math.Max(0, num2);
									break;
								case "Moon":
									game.QuestStatusMoon	= Math.Max(0, num2);
									break;
								case "Reactor":
									game.QuestStatusReactor	= Math.Max(0, num2);
									break;
								case "Princess":
									game.QuestStatusPrincess	= Math.Max(0, num2);
									break;
								case "Scarab":
									game.QuestStatusScarab	= Math.Max(0, num2);
									break;
								case "Sculpture":
									game.QuestStatusSculpture	= Math.Max(0, num2);
									break;
								case "SpaceMonster":
									game.QuestStatusSpaceMonster	= Math.Max(0, num2);
									break;
								case "Wild":
									game.QuestStatusWild	= Math.Max(0, num2);
									break;
								default:
									string	text	= "Artifact: " + game.QuestStatusArtifact.ToString() + Environment.NewLine +
																	"Dragonfly: " + game.QuestStatusDragonfly.ToString() + Environment.NewLine +
																	"Experiment: " + game.QuestStatusExperiment.ToString() + Environment.NewLine +
																	"Gemulon: " + game.QuestStatusGemulon.ToString() + Environment.NewLine +
																	"Japori: " + game.QuestStatusJapori.ToString() + Environment.NewLine +
																	"Jarek: " + game.QuestStatusJarek.ToString() + Environment.NewLine +
																	"Moon: " + game.QuestStatusMoon.ToString() + Environment.NewLine +
																	"Princess: " + game.QuestStatusPrincess.ToString() + Environment.NewLine +
																	"Reactor: " + game.QuestStatusReactor.ToString() + Environment.NewLine +
																	"Scarab: " + game.QuestStatusScarab.ToString() + Environment.NewLine +
																	"Sculpture: " + game.QuestStatusSculpture.ToString() + Environment.NewLine +
																	"SpaceMonster: " + game.QuestStatusSpaceMonster.ToString() + Environment.NewLine +
																	"Wild: " + game.QuestStatusWild.ToString();

									FormAlert.Alert(AlertType.Alert, this, "Status of Quests", text);
									break;
							}
						}
							break;
						case "Swag":
							if (num1 >= 0 && num1 < ship.Cargo.Length)
								ship.Cargo[num1]	= Math.Max(0, Math.Min(ship.FreeCargoBays + ship.Cargo[num1], num2));
							break;
						case "Test":
							(new FormTest()).ShowDialog(this);
							break;
						case "Tool":
							if (num1 >= 0 && num1 < ship.Gadgets.Length && num2 >= 0 && num2 < Consts.Gadgets.Length)
								ship.Gadgets[num1]	= (Gadget)Consts.Gadgets[num2].Clone();
							break;
						case "Varmints":
							ship.Tribbles	= Math.Max(0, num1);
							break;
						case "Yellow":
							game.EasyEncounters	= true;
							break;
						default:
							find	= true;
							break;
					}
				}
				else
				{
					switch (first)
					{
						case "Cheetah":
							FormAlert.Alert(AlertType.Cheater, this);
							game.CheatEnabled	= true;
							break;
						default:
							find	= true;
							break;
					}
				}

				if (find)
				{
					game.SelectedSystemName	= form.SystemName;
					if (form.TrackSystem && game.SelectedSystem.Name.ToLower() == form.SystemName.ToLower())
						game.TrackedSystemId	= game.SelectedSystemId;
				}

				UpdateAll();
			}
		}

		private void btnFuel_Click(object sender, System.EventArgs e)
		{
			FormBuyFuel	form	= new FormBuyFuel();
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				int	toAdd	= form.Amount / game.Commander.Ship.FuelCost;
				game.Commander.Ship.Fuel	+= toAdd;
				game.Commander.Cash				-= toAdd * game.Commander.Ship.FuelCost;
				UpdateAll();
			}
		}

		private void btnJump_Click(object sender, System.EventArgs e)
		{
			if (game.WarpSystem == null)
				FormAlert.Alert(AlertType.ChartJumpNoSystemSelected, this);
			else if (game.WarpSystem == game.Commander.CurrentSystem)
				FormAlert.Alert(AlertType.ChartJumpCurrent, this);
			else if (FormAlert.Alert(AlertType.ChartJump, this, game.WarpSystem.Name) == DialogResult.Yes)
			{
				game.CanSuperWarp	= false;
				try
				{
					if (game.AutoSave)
						SaveGame(SAVE_DEPARTURE, false);

					game.Warp(true);

					if (game.AutoSave)
						SaveGame(SAVE_ARRIVAL, false);
				}
				catch (GameEndException)
				{
					GameEnd();
				}
				UpdateAll();
			}
		}

		private void btnMerc_Click(object sender, System.EventArgs e)
		{
			(new FormViewPersonnel()).ShowDialog(this);
			UpdateAll();
		}

		private void btnNews_Click(object sender, System.EventArgs e)
		{
			game.ShowNewspaper();
		}

		private void btnNextSystem_Click(object sender, System.EventArgs e)
		{
			game.SelectNextSystemWithinRange(true);
			UpdateAll();
		}

		private void btnPod_Click(object sender, System.EventArgs e)
		{
			if (FormAlert.Alert(AlertType.EquipmentEscapePod, this) == DialogResult.Yes)
			{
				game.Commander.Cash						-= 2000;
				game.Commander.Ship.EscapePod	= true;
				UpdateAll();
			}
		}

		private void btnPrevSystem_Click(object sender, System.EventArgs e)
		{
			game.SelectNextSystemWithinRange(false);
			UpdateAll();
		}

		private void btnRepair_Click(object sender, System.EventArgs e)
		{
			FormBuyRepairs	form	= new FormBuyRepairs();
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				int	toAdd	= form.Amount / game.Commander.Ship.RepairCost;
				game.Commander.Ship.Hull	+= toAdd;
				game.Commander.Cash				-= toAdd * game.Commander.Ship.RepairCost;
				UpdateAll();
			}
		}

		private void btnSpecial_Click(object sender, System.EventArgs e)
		{
			SpecialEvent	specEvent	= game.Commander.CurrentSystem.SpecialEvent;
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

			FormAlert	alert	= new FormAlert(specEvent.Title, specEvent.String, btn1, res1, btn2, res2, null);
			if (alert.ShowDialog() != DialogResult.No)
			{
				if (game.Commander.CashToSpend < specEvent.Price)
					FormAlert.Alert(AlertType.SpecialIF, this);
				else
				{
					try
					{
						game.HandleSpecialEvent();
					}
					catch (GameEndException)
					{
						GameEnd();
					}
				}
			}

			UpdateAll();
		}

		private void btnTrack_Click(object sender, System.EventArgs e)
		{
			game.TrackedSystemId	= game.SelectedSystemId;
			UpdateAll();
		}

		private void btnWarp_Click(object sender, System.EventArgs e)
		{
			try
			{
				if (game.AutoSave)
					SaveGame(SAVE_DEPARTURE, false);

				game.Warp(false);

				if (game.AutoSave)
					SaveGame(SAVE_ARRIVAL, false);
			}
			catch (GameEndException)
			{
				GameEnd();
			}
			UpdateAll();
		}

		private void mnuGameExit_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void mnuGameNew_Click(object sender, System.EventArgs e)
		{
			FormNewCommander	form	= new FormNewCommander();
			if ((game == null || game.Commander.Days == SaveGameDays ||
				FormAlert.Alert(AlertType.GameAbandonConfirm, this) == DialogResult.Yes) &&
				form.ShowDialog(this) == DialogResult.OK)
			{
				game					= new Game(form.CommanderName, form.Difficulty, form.Pilot, form.Fighter, form.Trader,
												form.Engineer, this);
				SaveGameFile	= null;
				SaveGameDays	= 0;

				SetInGameControlsEnabled(true);
				UpdateAll();

				if (game.Options.NewsAutoShow)
					game.ShowNewspaper();
			}
		}

		private void mnuGameLoad_Click(object sender, System.EventArgs e)
		{
			if ((game == null || game.Commander.Days == SaveGameDays ||
				FormAlert.Alert(AlertType.GameAbandonConfirm, this) == DialogResult.Yes) &&
				dlgOpen.ShowDialog(this) == DialogResult.OK)
				LoadGame(dlgOpen.FileName);
		}

		private void mnuGameSave_Click(object sender, System.EventArgs e)
		{
			if (Game.CurrentGame != null)
			{
				if (SaveGameFile != null)
					SaveGame(SaveGameFile, false);
				else
					mnuGameSaveAs_Click(sender, e);
			}
		}

		private void mnuGameSaveAs_Click(object sender, System.EventArgs e)
		{
			if (Game.CurrentGame != null && dlgSave.ShowDialog(this) == DialogResult.OK)
				SaveGame(dlgSave.FileName, true);
		}

		private void mnuHelpAbout_Click(object sender, System.EventArgs e)
		{
			(new FormAbout()).ShowDialog(this);
		}

		private void mnuHighScores_Click(object sender, System.EventArgs e)
		{
			(new FormViewHighScores()).ShowDialog(this);
		}

		private void mnuOptions_Click(object sender, System.EventArgs e)
		{
			FormOptions	form	= new FormOptions();
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				game.Options.CopyValues(form.Options);
				UpdateAll();
			}
		}

		private void mnuRetire_Click(object sender, System.EventArgs e)
		{
			if (FormAlert.Alert(AlertType.GameRetire, this) == DialogResult.Yes)
			{
				game.EndStatus	= GameEndType.Retired;
				GameEnd();
				UpdateAll();
			}
		}

		private void mnuViewBank_Click(object sender, System.EventArgs e)
		{
			(new FormViewBank()).ShowDialog(this);
		}

		private void mnuViewCommander_Click(object sender, System.EventArgs e)
		{
			(new FormViewCommander()).ShowDialog(this);
		}

		private void mnuViewPersonnel_Click(object sender, System.EventArgs e)
		{
			(new FormViewPersonnel()).ShowDialog(this);
		}

		private void mnuViewQuests_Click(object sender, System.EventArgs e)
		{
			(new FormViewQuests()).ShowDialog(this);
		}

		private void mnuViewShip_Click(object sender, System.EventArgs e)
		{
			(new FormViewShip()).ShowDialog(this);
		}

		private void picGalacticChart_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && game != null)
			{
				StarSystem[]	universe			= game.Universe;

				bool					clickedSystem	= false;

				for (int i = 0; i < universe.Length && !clickedSystem; i++)
				{
					int	x	= universe[i].X + OFF_X;
					int	y	= universe[i].Y + OFF_Y;

					if (e.X >= x - 2 &&
						e.X <= x + 2 &&
						e.Y >= y - 2 &&
						e.Y <= y + 2)
					{
						clickedSystem					= true;
						game.SelectedSystemId	= (StarSystemId)i;
					}
					else if (Functions.WormholeExists(i, -1))
					{
						int	xW	= x + OFF_X_WORM;

						if (e.X >= xW - 2 &&
							e.X <= xW + 2 &&
							e.Y >= y - 2 &&
							e.Y <= y + 2)
						{
							clickedSystem					= true;
							game.SelectedSystemId	= (StarSystemId)i;
							game.TargetWormhole		= true;
						}
					}
				}

				if (clickedSystem)
					UpdateAll();
			}
		}

		private void picGalacticChart_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (game != null)
			{
				StarSystem[]	universe	= game.Universe;
				int[]					wormholes	= game.Wormholes;
				StarSystem		targetSys	= game.SelectedSystem;
				StarSystem		curSys		= game.Commander.CurrentSystem;
				int						fuel			= game.Commander.Ship.Fuel;

				if (fuel > 0)
					e.Graphics.DrawEllipse(DEFAULT_PEN, curSys.X + OFF_X - fuel, curSys.Y + OFF_Y - fuel, fuel * 2, fuel * 2);

				int index	= (int)game.SelectedSystemId;
				if (game.TargetWormhole)
				{
					int					dest		= wormholes[(Array.IndexOf(wormholes, index) + 1) % wormholes.Length];
					StarSystem	destSys	= universe[dest];
					e.Graphics.DrawLine(DEFAULT_PEN, targetSys.X + OFF_X_WORM + OFF_X, targetSys.Y + OFF_Y, destSys.X + OFF_X, destSys.Y + OFF_Y);
				}

				for (int i = 0; i < universe.Length; i++)
				{
					int		imageIndex	= universe[i].Visited ? IMG_S_V : IMG_S_N;
					if (universe[i] == game.WarpSystem)
						imageIndex++;
					Image	image				= ilChartImages.Images[imageIndex];

					if (universe[i] == game.TrackedSystem)
					{
						e.Graphics.DrawLine(DEFAULT_PEN, universe[i].X, universe[i].Y, universe[i].X + image.Width - 1, universe[i].Y + image.Height - 1);
						e.Graphics.DrawLine(DEFAULT_PEN, universe[i].X, universe[i].Y + image.Height - 1, universe[i].X + image.Width - 1, universe[i].Y);
					}

					ilChartImages.Draw(e.Graphics, universe[i].X, universe[i].Y, imageIndex);

					if (Functions.WormholeExists(i, -1))
						ilChartImages.Draw(e.Graphics, universe[i].X + OFF_X_WORM, universe[i].Y, IMG_S_W);
				}
			}
			else
				e.Graphics.FillRectangle(DEFAULT_BRUSH, 0, 0, picGalacticChart.Width, picGalacticChart.Height);
		}

		private void picShortRangeChart_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && game != null)
			{
				StarSystem[]	universe			= game.Universe;
				StarSystem		curSys				= game.Commander.CurrentSystem;

				bool					clickedSystem	= false;
				int						centerX				= picShortRangeChart.Width / 2;
				int						centerY				= picShortRangeChart.Height / 2;
				int						delta					= picShortRangeChart.Height / (Consts.MaxRange * 2);

				for (int i = 0; i < universe.Length && !clickedSystem; i++)
				{
					if ((Math.Abs(universe[i].X - curSys.X) * delta <= picShortRangeChart.Width / 2 - 10) &&
						(Math.Abs(universe[i].Y - curSys.Y) * delta <= picShortRangeChart.Height / 2 - 10))
					{
						int	x	= centerX + (universe[i].X - curSys.X) * delta;
						int	y	= centerY + (universe[i].Y - curSys.Y) * delta;

						if (e.X >= x - OFF_X &&
							e.X <= x + OFF_X &&
							e.Y >= y - OFF_Y &&
							e.Y <= y + OFF_Y)
						{
							clickedSystem					= true;
							game.SelectedSystemId	= (StarSystemId)i;
						}
						else if (Functions.WormholeExists(i, -1))
						{
							int	xW	= x + 9;

							if (e.X >= xW - OFF_X &&
								e.X <= xW + OFF_X &&
								e.Y >= y - OFF_Y &&
								e.Y <= y + OFF_Y)
							{
								clickedSystem					= true;
								game.SelectedSystemId	= (StarSystemId)i;
								game.TargetWormhole		= true;
							}
						}
					}
				}

				if (clickedSystem)
					UpdateAll();
			}
		}

		private void picShortRangeChart_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (game != null)
			{
				StarSystem[]	universe	= game.Universe;
				int[]					wormholes	= game.Wormholes;
				StarSystem		trackSys	= game.TrackedSystem;
				StarSystem		curSys		= game.Commander.CurrentSystem;
				int						fuel			= game.Commander.Ship.Fuel;

				int						centerX		= picShortRangeChart.Width / 2;
				int						centerY		= picShortRangeChart.Height / 2;
				int						delta			= picShortRangeChart.Height / (Consts.MaxRange * 2);

				e.Graphics.DrawLine(DEFAULT_PEN, centerX-1, centerY-1, centerX+1, centerY+1);
				e.Graphics.DrawLine(DEFAULT_PEN, centerX-1, centerY+1, centerX+1, centerY-1);
				if (fuel > 0)
					e.Graphics.DrawEllipse(DEFAULT_PEN, centerX - fuel * delta, centerY - fuel * delta, fuel * delta * 2, fuel * delta * 2);

				if (trackSys != null)
				{
					int	dist	= Functions.Distance(curSys, trackSys);
					if (dist > 0)
					{
						int	dX	= (int)Math.Round(25 * (trackSys.X - curSys.X) / (double)dist);
						int	dY	= (int)Math.Round(25 * (trackSys.Y - curSys.Y) / (double)dist);

						int	dX2	= (int)Math.Round(4 * (trackSys.Y - curSys.Y) / (double)dist);
						int	dY2	= (int)Math.Round(4 * (curSys.X - trackSys.X) / (double)dist);

						e.Graphics.FillPolygon(new SolidBrush(Color.Crimson), new Point[] { new Point(centerX + dX, centerY + dY),
																																								new Point(centerX - dX2, centerY - dY2), new Point(centerX + dX2, centerY + dY2) });
					}

					if (game.Options.ShowTrackedRange)
						e.Graphics.DrawString(Functions.StringVars(Strings.ChartDistance, Functions.Multiples(dist,
							Strings.DistanceUnit), trackSys.Name), Font, new SolidBrush(Color.Black), 0,
							picShortRangeChart.Height - 13);
				}

				// Two loops: first draw the names and then the systems. The names may
				// overlap and the systems may be drawn on the names, but at least every
				// system is visible.
				for (int j = 0; j < 2; j++)
				{
					for (int i = 0; i < universe.Length; i++)
					{
						if ((Math.Abs(universe[i].X - curSys.X) * delta <= picShortRangeChart.Width / 2 - 10) &&
							(Math.Abs(universe[i].Y - curSys.Y) * delta <= picShortRangeChart.Height / 2 - 10))
						{
							int	x	= centerX + (universe[i].X - curSys.X) * delta;
							int	y	= centerY + (universe[i].Y - curSys.Y) * delta;

							if (j == 1)
							{
								if (universe[i] == game.WarpSystem)
								{
									e.Graphics.DrawLine(DEFAULT_PEN, x - 6, y, x + 6, y);
									e.Graphics.DrawLine(DEFAULT_PEN, x, y - 6, x, y + 6);
								}

								if (universe[i] == game.TrackedSystem)
								{
									e.Graphics.DrawLine(DEFAULT_PEN, x - 5, y - 5, x + 5, y + 5);
									e.Graphics.DrawLine(DEFAULT_PEN, x - 5, y + 5, x + 5, y - 5);
								}

								ilChartImages.Draw(e.Graphics, x - OFF_X, y - OFF_Y, universe[i].Visited ? IMG_G_V : IMG_G_N);

								if (Functions.WormholeExists(i, -1))
								{
									int	xW	= x + 9;
									if (game.TargetWormhole && universe[i] == game.SelectedSystem)
									{
										e.Graphics.DrawLine(DEFAULT_PEN, xW - 6, y, xW + 6, y);
										e.Graphics.DrawLine(DEFAULT_PEN, xW, y - 6, xW, y + 6);
									}
									ilChartImages.Draw(e.Graphics, xW - OFF_X, y - OFF_Y, IMG_G_W);
								}
							}
							else
							{
								Font	font	= new Font(Font.FontFamily.Name, 7);
								SizeF	size	= e.Graphics.MeasureString(universe[i].Name, Font);
								e.Graphics.DrawString(universe[i].Name, font, new SolidBrush(Color.Black),
									x - size.Width / 2 + OFF_X, y - size.Height);
							}
						}
					}
				}
			}
			else
				e.Graphics.FillRectangle(DEFAULT_BRUSH, 0, 0, picShortRangeChart.Width, picShortRangeChart.Height);
		}

		private void statusBar_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
		{
			if (game != null)
			{
				if (e.StatusBarPanel == this.statusBarPanelCash)
					mnuViewBank_Click(sender, e);
				else if (e.StatusBarPanel == this.statusBarPanelCosts)
					(new FormCosts()).ShowDialog(this);
			}
		}

		#endregion

		#region Properties

		public Image[] CustomShipImages
		{
			get
			{
				Image[]	images		= new Image[Consts.ImagesPerShip];
				int			baseIndex	= (int)ShipType.Custom * Consts.ImagesPerShip;
				for (int index = 0; index < Consts.ImagesPerShip; index++)
					images[index]	= ilShipImages.Images[baseIndex + index];

				return images;
			}
			set
			{
				Image[]	images		= value;
				int			baseIndex	= (int)ShipType.Custom * Consts.ImagesPerShip;
				for (int index = 0; index < Consts.ImagesPerShip; index++)
					ilShipImages.Images[baseIndex + index]	= images[index];
			}
		}

		public ImageList DirectionImages
		{
			get
			{
				return ilDirectionImages;
			}
		}

		public ImageList EquipmentImages
		{
			get
			{
				return ilEquipmentImages;
			}
		}

		public ImageList ShipImages
		{
			get
			{
				return ilShipImages;
			}
		}

		#endregion
	}
}
