/*******************************************************************************
 *
 * Space Trader for Windows 1.3.0
 *
 * Copyright (C) 2004 Jay French, All Rights Reserved
 *
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

namespace Fryz.Apps.SpaceTrader
{
	public class Consts
	{
		#region Individual Constants
		public const	int			BountyModifier								= 1000;

		public const	string	HighScoreFile									= "HighScores.bin";
		public const	string	DefaultSettingsFile						= "DefaultSettings.bin";

		public const	int			GalaxyWidth										= 154;
		public const	int			GalaxyHeight									= 110;
		public const	int			MinDistance										= 7;
		public const	int			CloseDistance									= 13;
		public const	int			MaxRange											= 20;
		public const	int			WormDist											= 25;

		public const	int			DebtWarning										= 75000;
		public const	int			DebtTooLarge									= 100000;
		public const	double	InsRate												= 0.0025;
		public const	double	IntRate												= 0.1;
		public const	int			MaxNoClaim										= 90;

		public const	int			SkillBonus										= 3;
		public const	int			CloakBonus										= 2;

		public const	int			MaxSkill											= 10;
		public const	int			PilotSkill										= 0;
		public const	int			FighterSkill									= 1;
		public const	int			TraderSkill										= 2;
		public const	int			EngineerSkill									= 3;

		public const	int			StartClicks										= 20;
		public const	int			MaxFuelTanks									= 18;
		public const	int			HullUpgrade										= 50;
		public const	int			MaxShip												= 9;
		public const	int			FleaConversionCost						= 500;

		public const	int			ImagesPerShip									= 4;
		public const	int			ShipImgOffsetNormal						= 0;
		public const	int			ShipImgOffsetDamage						= 1;
		public const	int			ShipImgOffsetShield						= 2;
		public const	int			ShipImgOffsetSheildDamage			= 3;
		public const	int			EncounterImgAlien							= 0;
		public const	int			EncounterImgPirate						= 1;
		public const	int			EncounterImgPolice						= 2;
		public const	int			EncounterImgSpecial						= 3;
		public const	int			EncounterImgTrader						= 4;

		public const	int			StoryProbability							= 50/8;
		public const	int			FabricRipInitialProbability		= 25;

		public const	int			MaxTribbles										= 100000;

		public const	int			PoliceRecordScorePsychopath		= -100;
		public const	int			PoliceRecordScoreVillain			=  -70;
		public const	int			PoliceRecordScoreCriminal			=  -30;
		public const	int			PoliceRecordScoreCrook				=  -10;
		public const	int			PoliceRecordScoreDubious			=   -5;
		public const	int			PoliceRecordScoreClean				=    0;
		public const	int			PoliceRecordScoreLawful				=    5;
		public const	int			PoliceRecordScoreTrusted			=   10;
		public const	int			PoliceRecordScoreLiked				=   25;
		public const	int			PoliceRecordScoreHero					=   75;

		public const	int			ReputationScoreHarmless				=    0;
		public const	int			ReputationScoreMostlyHarmless	=   10;
		public const	int			ReputationScorePoor						=   20;
		public const	int			ReputationScoreAverage				=   40;
		public const	int			ReputationScoreAboveAverage		=   80;
		public const	int			ReputationScoreCompetent			=  150;
		public const	int			ReputationScoreDangerous			=  300;
		public const	int			ReputationScoreDeadly					=  600;
		public const	int			ReputationScoreElite					= 1500;

		public const	int			ScoreAttackPirate							=   0;
		public const	int			ScoreAttackPolice							=  -3;
		public const	int			ScoreAttackTrader							=  -2;
		public const	int			ScoreCaughtWithWild						=  -4;
		public const	int			ScoreFleePolice								=  -2;
		public const	int			ScoreKillCaptain							= 100;
		public const	int			ScoreKillPirate								=   1;
		public const	int			ScoreKillPolice								=  -6;
		public const	int			ScoreKillTrader								=  -4;
		public const	int			ScorePlunderPirate						=  -1;
		public const	int			ScorePlunderTrader						=  -2;
		public const	int			ScoreTrafficking							=  -1;

		#endregion

		#region Constant Arrays

		#region AlertTypes
		public static AlertType[]	AlertTypes	= new AlertType[]
		{
			AlertType.Alert,
			AlertType.AntidoteOnBoard,
			AlertType.AntidoteDestroyed,
			AlertType.AntidoteTaken,
			AlertType.ArrivalBuyNewspaper,
			AlertType.ArrivalIFFuel,
			AlertType.ArrivalIFFuelRepairs,
			AlertType.ArrivalIFNewspaper,
			AlertType.ArrivalIFRepairs,
			AlertType.ArtifactLost,
			AlertType.ArtifactRelinquished,
			AlertType.CargoIF,
			AlertType.CargoNoEmptyBays,
			AlertType.CargoNoneAvailable,
			AlertType.CargoNoneToSell,
			AlertType.CargoNotInterested,
			AlertType.CargoNotSold,
			AlertType.ChartJump,
			AlertType.ChartJumpCurrent,
			AlertType.ChartJumpNoSystemSelected,
			AlertType.ChartTrackSystem,
			AlertType.ChartWormholeUnreachable,
			AlertType.CrewFireMercenary,
			AlertType.CrewNoQuarters,
			AlertType.DebtNoBuy,
			AlertType.DebtNone,
			AlertType.DebtReminder,
			AlertType.DebtTooLargeGrounded,
			AlertType.DebtTooLargeLoan,
			AlertType.DebtTooLargeTrade,
			AlertType.DebtWarning,
			AlertType.Egg,
			AlertType.EncounterAliensSurrender,
			AlertType.EncounterArrested,
			AlertType.EncounterAttackCaptain,
			AlertType.EncounterAttackNoWeapons,
			AlertType.EncounterAttackPolice,
			AlertType.EncounterAttackTrader,
			AlertType.EncounterBothDestroyed,
			AlertType.EncounterDrinkContents,
			AlertType.EncounterDumpAll,
			AlertType.EncounterDumpWarning,
			AlertType.EncounterEscaped,
			AlertType.EncounterEscapedHit,
			AlertType.EncounterEscapePodActivated,
			AlertType.EncounterLooting,
			AlertType.EncounterMarieCeleste,
			AlertType.EncounterMarieCelesteNoBribe,
			AlertType.EncounterOpponentEscaped,
			AlertType.EncounterPiratesBounty,
			AlertType.EncounterPiratesExamineReactor,
			AlertType.EncounterPiratesFindNoCargo,
			AlertType.EncounterPoliceBribe,
			AlertType.EncounterPoliceBribeCant,
			AlertType.EncounterPoliceBribeLowCash,
			AlertType.EncounterPoliceFine,
			AlertType.EncounterPoliceNothingFound,
			AlertType.EncounterPoliceNothingIllegal,
			AlertType.EncounterPoliceSubmit,
			AlertType.EncounterPoliceSurrender,
			AlertType.EncounterPostMarie,
			AlertType.EncounterPostMarieFlee,
			AlertType.EncounterScoop,
			AlertType.EncounterScoopNoRoom,
			AlertType.EncounterScoopNoScoop,
			AlertType.EncounterSurrenderRefused,
			AlertType.EncounterTonicConsumedGood,
			AlertType.EncounterTonicConsumedStrange,
			AlertType.EncounterTradeCompleted,
			AlertType.EncounterYouLose,
			AlertType.EncounterYouWin,
			AlertType.EquipmentAlreadyOwn,
			AlertType.EquipmentBuy,
			AlertType.EquipmentEscapePod,
			AlertType.EquipmentExtraBaysInUse,
			AlertType.EquipmentFuelCompactor,
			AlertType.EquipmentIF,
			AlertType.EquipmentLightningShield,
			AlertType.EquipmentMorgansLaser,
			AlertType.EquipmentNotEnoughSlots,
			AlertType.EquipmentSell,
			AlertType.FileErrorOpen,
			AlertType.FileErrorSave,
			AlertType.FileOpenConfirm,
			AlertType.FleaBuilt,
			AlertType.GameClearHighScores,
			AlertType.GameRetire,
			AlertType.InsuranceNoEscapePod,
			AlertType.InsurancePayoff,
			AlertType.InsuranceStop,
			AlertType.JailConvicted,
			AlertType.JailFleaReceived,
			AlertType.JailIllegalGoodsImpounded,
			AlertType.JailInsuranceLost,
			AlertType.JailMercenariesLeave,
			AlertType.JailShipSold,
			AlertType.JarekTakenHome,
			AlertType.LeavingIFInsurance,
			AlertType.LeavingIFMercenaries,
			AlertType.LeavingIFWormholeTax,
			AlertType.MeetCaptainAhab,
			AlertType.MeetCaptainConrad,
			AlertType.MeetCaptainHuie,
			AlertType.NewGameConfirm,
			AlertType.NewGameMoreSkillPoints,
			AlertType.ReactorConfiscated,
			AlertType.ReactorDestroyed,
			AlertType.ReactorOnBoard,
			AlertType.ReactorMeltdown,
			AlertType.ReactorWarningFuel,
			AlertType.ReactorWarningFuelGone,
			AlertType.ReactorWarningTemp,
			AlertType.ShipBuyConfirm,
			AlertType.ShipBuyCrewQuarters,
			AlertType.ShipBuyIF,
			AlertType.ShipBuyIFTransfer,
			AlertType.ShipBuyNoSlots,
			AlertType.ShipBuyNotAvailable,
			AlertType.ShipBuyNoTransfer,
			AlertType.ShipBuyPassengerQuarters,
			AlertType.ShipBuyReactor,
			AlertType.ShipBuyTransfer,
			AlertType.ShipHullUpgraded,
			AlertType.SpecialCleanRecord,
			AlertType.SpecialExperimentPerformed,
			AlertType.SpecialIF,
			AlertType.SpecialMoonBought,
			AlertType.SpecialNoQuarters,
			AlertType.SpecialNotEnoughBays,
			AlertType.SpecialPassengerOnBoard,
			AlertType.SpecialSealedCanisters,
			AlertType.SpecialSkillIncrease,
			AlertType.SpecialTimespaceFabricRip,
			AlertType.SpecialTrainingCompleted,
			AlertType.TravelArrival,
			AlertType.TravelUneventfulTrip,
			AlertType.TribblesAllDied,
			AlertType.TribblesAteFood,
			AlertType.TribblesGone,
			AlertType.TribblesHalfDied,
			AlertType.TribblesKilled,
			AlertType.TribblesMostDied,
			AlertType.TribblesOwn,
			AlertType.TribblesRemoved,
			AlertType.TribblesInspector,
			AlertType.TribblesSqueek,
			AlertType.TribblesTradeIn,
			AlertType.WildArrested,
			AlertType.WildChatsPirates,
			AlertType.WildGoesPirates,
			AlertType.WildLeavesShip,
			AlertType.WildWontBoardLaser,
			AlertType.WildWontBoardReactor,
			AlertType.WildWontStayAboardLaser,
			AlertType.WildWontStayAboardReactor,
			AlertType.GameEndKilled,
			AlertType.GameEndRetired,
			AlertType.GameEndBoughtMoon
		};
		#endregion

		#region CrewMemberIds
		public static CrewMemberId[]	CrewMemberIds	= new CrewMemberId[]
		{
			CrewMemberId.Commander,
			CrewMemberId.Alyssa,
			CrewMemberId.Armatur,
			CrewMemberId.Bentos,
			CrewMemberId.C2U2,
			CrewMemberId.ChiTi,
			CrewMemberId.Crystal,
			CrewMemberId.Dane,
			CrewMemberId.Deirdre,
			CrewMemberId.Doc,
			CrewMemberId.Draco,
			CrewMemberId.Iranda,
			CrewMemberId.Jeremiah,
			CrewMemberId.Jujubal,
			CrewMemberId.Krydon,
			CrewMemberId.Luis,
			CrewMemberId.Mercedez,
			CrewMemberId.Milete,
			CrewMemberId.MuriL,
			CrewMemberId.Mystyc,
			CrewMemberId.Nandi,
			CrewMemberId.Orestes,
			CrewMemberId.Pancho,
			CrewMemberId.PS37,
			CrewMemberId.Quarck,
			CrewMemberId.Sosumi,
			CrewMemberId.Uma,
			CrewMemberId.Wesley,
			CrewMemberId.Wonton,
			CrewMemberId.Yorvick,
			CrewMemberId.Zeethibal
		};
		#endregion

		#region Difficulties
		public static Difficulty[]	Difficulties	= new Difficulty[]
		{
			Difficulty.Beginner,
			Difficulty.Easy,
			Difficulty.Normal,
			Difficulty.Hard,
			Difficulty.Impossible
		};
		#endregion

		#region EquipmentTypes
		public static EquipmentType[]	EquipmentTypes	= new EquipmentType[]
		{
			EquipmentType.Weapon,
			EquipmentType.Shield,
			EquipmentType.Gadget
		};
		#endregion

		#region Gadgets
		public static Gadget[]	Gadgets	= new Gadget[]
		{
			new Gadget(GadgetType.ExtraCargoBays,     2500, TechLevel.EarlyIndustrial, 35), // 5 extra holds
			new Gadget(GadgetType.AutoRepairSystem,   7500, TechLevel.Industrial,      20), // Increases engineer's effectivity
			new Gadget(GadgetType.NavigatingSystem,  15000, TechLevel.PostIndustrial,  20), // Increases pilot's effectivity
			new Gadget(GadgetType.TargetingSystem,   25000, TechLevel.PostIndustrial,  20), // Increases fighter's effectivity
			new Gadget(GadgetType.CloakingDevice,   100000, TechLevel.HiTech,           5), // If you have a good engineer, neither pirates nor police will notice you
			// The gadgets below can't be bought
			new Gadget(GadgetType.FuelCompactor,     30000, TechLevel.Unavailable,      0)
		};
		#endregion

		#region PoliceRecords
		public static PoliceRecord[]	PoliceRecords	= new PoliceRecord[]
		{
			new PoliceRecord(PoliceRecordType.Psychopath, PoliceRecordScorePsychopath),
			new PoliceRecord(PoliceRecordType.Villain,    PoliceRecordScoreVillain),
			new PoliceRecord(PoliceRecordType.Criminal,   PoliceRecordScoreCriminal),
			new PoliceRecord(PoliceRecordType.Crook,      PoliceRecordScoreCrook),
			new PoliceRecord(PoliceRecordType.Dubious,    PoliceRecordScoreDubious),
			new PoliceRecord(PoliceRecordType.Clean,      PoliceRecordScoreClean),
			new PoliceRecord(PoliceRecordType.Lawful,     PoliceRecordScoreLawful),
			new PoliceRecord(PoliceRecordType.Trusted,    PoliceRecordScoreTrusted),
			new PoliceRecord(PoliceRecordType.Liked,      PoliceRecordScoreLiked),
			new PoliceRecord(PoliceRecordType.Hero,       PoliceRecordScoreHero)
		};
		#endregion

		#region PoliticalSystems
		public static PoliticalSystem[]	PoliticalSystems	= new PoliticalSystem[]
		{
			new PoliticalSystem(PoliticalSystemType.Anarchy,      0, Activity.Absent,   Activity.Swarms,   Activity.Minimal,  TechLevel.PreAgricultural, TechLevel.Industrial,      7, true,  true,  TradeItemType.Food),
			new PoliticalSystem(PoliticalSystemType.Capitalist,   2, Activity.Some,     Activity.Few,      Activity.Swarms,   TechLevel.EarlyIndustrial, TechLevel.HiTech,          1, true,  true,  TradeItemType.Ore),
			new PoliticalSystem(PoliticalSystemType.Communist,    6, Activity.Abundant, Activity.Moderate, Activity.Moderate, TechLevel.Agricultural,    TechLevel.Industrial,      5, true,  true,  TradeItemType.NA),
			new PoliticalSystem(PoliticalSystemType.Confederacy,  5, Activity.Moderate, Activity.Some,     Activity.Many,     TechLevel.Agricultural,    TechLevel.PostIndustrial,  3, true,  true,  TradeItemType.Games),
			new PoliticalSystem(PoliticalSystemType.Corporate,    2, Activity.Abundant, Activity.Few,      Activity.Swarms,   TechLevel.EarlyIndustrial, TechLevel.HiTech,          2, true,  true,  TradeItemType.Robots),
			new PoliticalSystem(PoliticalSystemType.Cybernetic,   0, Activity.Swarms,   Activity.Swarms,   Activity.Many,     TechLevel.PostIndustrial,  TechLevel.HiTech,          0, false, false, TradeItemType.Ore),
			new PoliticalSystem(PoliticalSystemType.Democracy,    4, Activity.Some,     Activity.Few,      Activity.Many,     TechLevel.Renaissance,     TechLevel.HiTech,          2, true,  true,  TradeItemType.Games),
			new PoliticalSystem(PoliticalSystemType.Dictatorship, 3, Activity.Moderate, Activity.Many,     Activity.Some,     TechLevel.PreAgricultural, TechLevel.HiTech,          2, true,  true,  TradeItemType.NA),
			new PoliticalSystem(PoliticalSystemType.Fascist,      7, Activity.Swarms,   Activity.Swarms,   Activity.Minimal,  TechLevel.EarlyIndustrial, TechLevel.HiTech,          0, false, true,  TradeItemType.Machines),
			new PoliticalSystem(PoliticalSystemType.Feudal,       1, Activity.Minimal,  Activity.Abundant, Activity.Few,      TechLevel.PreAgricultural, TechLevel.Renaissance,     6, true,  true,  TradeItemType.Firearms),
			new PoliticalSystem(PoliticalSystemType.Military,     7, Activity.Swarms,   Activity.Absent,   Activity.Abundant, TechLevel.Medieval,        TechLevel.HiTech,          0, false, true,  TradeItemType.Robots),
			new PoliticalSystem(PoliticalSystemType.Monarchy,     3, Activity.Moderate, Activity.Some,     Activity.Moderate, TechLevel.PreAgricultural, TechLevel.Industrial,      4, true,  true,  TradeItemType.Medicine),
			new PoliticalSystem(PoliticalSystemType.Pacifist,     7, Activity.Few,      Activity.Minimal,  Activity.Many,     TechLevel.PreAgricultural, TechLevel.Renaissance,     1, true,  false, TradeItemType.NA),
			new PoliticalSystem(PoliticalSystemType.Socialist,    4, Activity.Few,      Activity.Many,     Activity.Some,     TechLevel.PreAgricultural, TechLevel.Industrial,      6, true,  true,  TradeItemType.NA),
			new PoliticalSystem(PoliticalSystemType.Satori,       0, Activity.Minimal,  Activity.Minimal,  Activity.Minimal,  TechLevel.PreAgricultural, TechLevel.Agricultural,    0, false, false, TradeItemType.NA),
			new PoliticalSystem(PoliticalSystemType.Technocracy,  1, Activity.Abundant, Activity.Some,     Activity.Abundant, TechLevel.EarlyIndustrial, TechLevel.HiTech,          2, true,  true,  TradeItemType.Water),
			new PoliticalSystem(PoliticalSystemType.Theocracy,    5, Activity.Abundant, Activity.Minimal,  Activity.Moderate, TechLevel.PreAgricultural, TechLevel.EarlyIndustrial, 0, true,  true,  TradeItemType.Narcotics)
		};
		#endregion

		#region Reputations
		public static Reputation[]	Reputations	= new Reputation[]
		{
			new Reputation(ReputationType.Harmless,       ReputationScoreHarmless),
			new Reputation(ReputationType.MostlyHarmless, ReputationScoreMostlyHarmless),
			new Reputation(ReputationType.Poor,           ReputationScorePoor),
			new Reputation(ReputationType.Average,        ReputationScoreAverage),
			new Reputation(ReputationType.AboveAverage,   ReputationScoreAboveAverage),
			new Reputation(ReputationType.Competent,      ReputationScoreCompetent),
			new Reputation(ReputationType.Dangerous,      ReputationScoreDangerous),
			new Reputation(ReputationType.Deadly,         ReputationScoreDeadly),
			new Reputation(ReputationType.Elite,          ReputationScoreElite)
		};
		#endregion

		#region Shields
		public static Shield[]	Shields	= new Shield[]
		{
			new Shield(ShieldType.Energy,     100,  5000, TechLevel.Industrial,	    70),
			new Shield(ShieldType.Reflective, 200, 20000, TechLevel.PostIndustrial, 30),
			// The weapons below cannot be bought
			new Shield(ShieldType.Lightning,  350, 45000, TechLevel.Unavailable,     0)
		};
		#endregion

		#region ShipImageOffsets
		public static Rectangle[]	ShipImageOffsets	= new Rectangle[]
		{
			// We only care about X and Width, so set Y and Height to 0.
			new Rectangle(22, 0, 19, 0),	// Flea
			new Rectangle(18, 0, 27, 0),	// Gnat
			new Rectangle(18, 0, 27, 0),	// Firefly
			new Rectangle(18, 0, 27, 0),	// Mosquito
			new Rectangle(12, 0, 40, 0),	// Bumblebee
			new Rectangle(12, 0, 40, 0),	// Beetle
			new Rectangle( 7, 0, 50, 0),	// Hornet
			new Rectangle( 7, 0, 50, 0),	// Grasshopper
			new Rectangle( 2, 0, 60, 0),	// Termite
			new Rectangle( 2, 0, 60, 0),	// Wasp
			new Rectangle( 7, 0, 49, 0),	// Space Monster
			new Rectangle(21, 0, 22, 0),	// Dragonfly
			new Rectangle(15, 0, 34, 0),	// Mantis
			new Rectangle( 7, 0, 49, 0),	// Scarab
			new Rectangle( 9, 0, 46, 0)		// Bottle
		};
		#endregion

		#region ShipSpecs
		public static ShipSpec[]	ShipSpecs = new ShipSpec[]
		{
			new ShipSpec(ShipType.Flea,         Size.Tiny,   10, 0, 0, 0, 1, 20, 1,  25,  1,   2000,  2, -1, -1,  0, TechLevel.EarlyIndustrial),
			new ShipSpec(ShipType.Gnat,         Size.Small,  15, 1, 0, 1, 1, 14, 1, 100,  2,  10000, 28,  0,  0,  0, TechLevel.Industrial),
			new ShipSpec(ShipType.Firefly,      Size.Small,  20, 1, 1, 1, 1, 17, 1, 100,  3,  25000, 20,  0,  0,  0, TechLevel.Industrial),
			new ShipSpec(ShipType.Mosquito,     Size.Small,  15, 2, 1, 1, 1, 13, 1, 100,  5,  30000, 20,  0,  1,  0, TechLevel.Industrial),
			new ShipSpec(ShipType.Bumblebee,    Size.Medium, 25, 1, 2, 2, 2, 15, 1, 100,  7,  60000, 15,  1,  1,  0, TechLevel.Industrial),
			new ShipSpec(ShipType.Beetle,       Size.Medium, 50, 0, 1, 1, 3, 14, 1,  50, 10,  80000,  3, -1, -1,  0, TechLevel.Industrial),
			new ShipSpec(ShipType.Hornet,       Size.Large,  20, 3, 2, 1, 2, 16, 2, 150, 15, 100000,  6,  2,  3,  1, TechLevel.PostIndustrial),
			new ShipSpec(ShipType.Grasshopper,  Size.Large,  30, 2, 2, 3, 3, 15, 3, 150, 15, 150000,  2,  3,  4,  2, TechLevel.PostIndustrial),
			new ShipSpec(ShipType.Termite,      Size.Huge,   60, 1, 3, 2, 3, 13, 4, 200, 20, 225000,  2,  4,  5,  3, TechLevel.HiTech),
			new ShipSpec(ShipType.Wasp,         Size.Huge,   35, 3, 2, 2, 3, 14, 5, 200, 20, 300000,  2,  5,  6,  4, TechLevel.HiTech),
			// The ships below can't be bought
			new ShipSpec(ShipType.SpaceMonster, Size.Huge,    0, 3, 0, 0, 1,  1, 1, 500,  1, 500000,  0,  8,  8,  8, TechLevel.Unavailable),
			new ShipSpec(ShipType.Dragonfly,    Size.Small,   0, 2, 3, 2, 1,  1, 1,  10,  1, 500000,  0,  8,  8,  8, TechLevel.Unavailable),
			new ShipSpec(ShipType.Mantis,       Size.Medium,  0, 3, 1, 3, 3,  1, 1, 300,  1, 500000,  0,  8,  8,  8, TechLevel.Unavailable),
			new ShipSpec(ShipType.Scarab,       Size.Large,  20, 2, 0, 0, 2,  1, 1, 400,  1, 500000,  0,  8,  8,  8, TechLevel.Unavailable),
			new ShipSpec(ShipType.Bottle,       Size.Small,   0, 0, 0, 0, 0,  1, 1,  10,  1,    100,  0,  8,  8,  8, TechLevel.Unavailable)
		};
		#endregion

		#region Sizes
		public static Size[]	Sizes	= new Size[]
		{
			Size.Tiny,
			Size.Small,
			Size.Medium,
			Size.Large,
			Size.Huge
		};
		#endregion

		#region SpecialEvents
		public static SpecialEvent[]	SpecialEvents	= new SpecialEvent[]
		{
			new SpecialEvent(SpecialEventType.Artifact,                0, 1, false),
			new SpecialEvent(SpecialEventType.ArtifactDelivery,   -20000, 0, true),
			new SpecialEvent(SpecialEventType.CargoForSale,         1000, 3, false),
			new SpecialEvent(SpecialEventType.Dragonfly,               0, 1, true),
			new SpecialEvent(SpecialEventType.DragonflyBaratas,        0, 0, true),
			new SpecialEvent(SpecialEventType.DragonflyDestroyed,      0, 0, true),
			new SpecialEvent(SpecialEventType.DragonflyMelina,         0, 0, true),
			new SpecialEvent(SpecialEventType.DragonflyRegulas,        0, 0, true),
			new SpecialEvent(SpecialEventType.DragonflyShield,         0, 0, false),
			new SpecialEvent(SpecialEventType.EraseRecord,          5000, 3, false),
			new SpecialEvent(SpecialEventType.Experiment,              0, 0, true),
			new SpecialEvent(SpecialEventType.ExperimentFailed,        0, 0, true),
			new SpecialEvent(SpecialEventType.ExperimentStopped,       0, 0, true),
			new SpecialEvent(SpecialEventType.Gemulon,                 0, 0, true),
			new SpecialEvent(SpecialEventType.GemulonFuel,             0, 0, false),
			new SpecialEvent(SpecialEventType.GemulonInvaded,          0, 0, true),
			new SpecialEvent(SpecialEventType.GemulonRescued,          0, 0, true),
			new SpecialEvent(SpecialEventType.Japori,                  0, 1, false),
			new SpecialEvent(SpecialEventType.JaporiDelivery,          0, 0, true),
			new SpecialEvent(SpecialEventType.Jarek,                   0, 1, false),
			new SpecialEvent(SpecialEventType.JarekGetsOut,            0, 0, true),
			new SpecialEvent(SpecialEventType.Lottery,             -1000, 0, true),
			new SpecialEvent(SpecialEventType.Moon,               500000, 4, false),
			new SpecialEvent(SpecialEventType.MoonRetirement,          0, 0, false),
			new SpecialEvent(SpecialEventType.Reactor,                 0, 0, false),
			new SpecialEvent(SpecialEventType.ReactorDelivered,        0, 0, true),
			new SpecialEvent(SpecialEventType.ReactorLaser,            0, 0, false),
			new SpecialEvent(SpecialEventType.Scarab,                  0, 1, true),
			new SpecialEvent(SpecialEventType.ScarabDestroyed,         0, 0, true),
			new SpecialEvent(SpecialEventType.ScarabUpgradeHull,       0, 0, false),
			new SpecialEvent(SpecialEventType.Skill,                3000, 3, false),
			new SpecialEvent(SpecialEventType.SpaceMonster,            0, 1, true),
			new SpecialEvent(SpecialEventType.SpaceMonsterKilled, -15000, 0, true),
			new SpecialEvent(SpecialEventType.Tribble,              1000, 1, false),
			new SpecialEvent(SpecialEventType.TribbleBuyer,            0, 3, false),
			new SpecialEvent(SpecialEventType.Wild,                    0, 1, false),
			new	SpecialEvent(SpecialEventType.WildGetsOut,			   0, 0, true),
			new	SpecialEvent(SpecialEventType.KesselShipyard,	  150000, 0, false),
			new	SpecialEvent(SpecialEventType.LoronarShipyard,	  150000, 0, false),
			new	SpecialEvent(SpecialEventType.SienarShipyard,	  150000, 0, false),
			new	SpecialEvent(SpecialEventType.RepublicShipyard,	  150000, 0, false),
			new	SpecialEvent(SpecialEventType.SorosuubShipyard,	  150000, 0, false)
		};
		#endregion

		#region SpecialResources
		public static SpecialResource[]	SpecialResources	= new SpecialResource[]
		{
			SpecialResource.Nothing,
			SpecialResource.MineralRich,
			SpecialResource.MineralPoor,
			SpecialResource.Desert,
			SpecialResource.SweetOceans,
			SpecialResource.RichSoil,
			SpecialResource.PoorSoil,
			SpecialResource.RichFauna,
			SpecialResource.Lifeless,
			SpecialResource.WeirdMushrooms,
			SpecialResource.SpecialHerbs,
			SpecialResource.Artistic,
			SpecialResource.Warlike
		};
		#endregion

		#region StarSystemIds
		public static StarSystemId[]	StarSystemIds	= new StarSystemId[]
		{
			StarSystemId.Acamar,
			StarSystemId.Adahn,
			StarSystemId.Aldea,
			StarSystemId.Andevian,
			StarSystemId.Antedi,
			StarSystemId.Balosnee,
			StarSystemId.Baratas,
			StarSystemId.Brax,
			StarSystemId.Bretel,
			StarSystemId.Calondia,
			StarSystemId.Campor,
			StarSystemId.Capelle,
			StarSystemId.Carzon,
			StarSystemId.Castor,
			StarSystemId.Cestus,
			StarSystemId.Cheron,
			StarSystemId.Courteney,
			StarSystemId.Daled,
			StarSystemId.Damast,
			StarSystemId.Davlos,
			StarSystemId.Deneb,
			StarSystemId.Deneva,
			StarSystemId.Devidia,
			StarSystemId.Draylon,
			StarSystemId.Drema,
			StarSystemId.Endor,
			StarSystemId.Esmee,
			StarSystemId.Exo,
			StarSystemId.Ferris,
			StarSystemId.Festen,
			StarSystemId.Fourmi,
			StarSystemId.Frolix,
			StarSystemId.Gemulon,
			StarSystemId.Guinifer,
			StarSystemId.Hades,
			StarSystemId.Hamlet,
			StarSystemId.Helena,
			StarSystemId.Hulst,
			StarSystemId.Iodine,
			StarSystemId.Iralius,
			StarSystemId.Janus,
			StarSystemId.Japori,
			StarSystemId.Jarada,
			StarSystemId.Jason,
			StarSystemId.Kaylon,
			StarSystemId.Khefka,
			StarSystemId.Kira,
			StarSystemId.Klaatu,
			StarSystemId.Klaestron,
			StarSystemId.Korma,
			StarSystemId.Kravat,
			StarSystemId.Krios,
			StarSystemId.Laertes,
			StarSystemId.Largo,
			StarSystemId.Lave,
			StarSystemId.Ligon,
			StarSystemId.Lowry,
			StarSystemId.Magrat,
			StarSystemId.Malcoria,
			StarSystemId.Melina,
			StarSystemId.Mentar,
			StarSystemId.Merik,
			StarSystemId.Mintaka,
			StarSystemId.Montor,
			StarSystemId.Mordan,
			StarSystemId.Myrthe,
			StarSystemId.Nelvana,
			StarSystemId.Nix,
			StarSystemId.Nyle,
			StarSystemId.Odet,
			StarSystemId.Og,
			StarSystemId.Omega,
			StarSystemId.Omphalos,
			StarSystemId.Orias,
			StarSystemId.Othello,
			StarSystemId.Parade,
			StarSystemId.Penthara,
			StarSystemId.Picard,
			StarSystemId.Pollux,
			StarSystemId.Quator,
			StarSystemId.Rakhar,
			StarSystemId.Ran,
			StarSystemId.Regulas,
			StarSystemId.Relva,
			StarSystemId.Rhymus,
			StarSystemId.Rochani,
			StarSystemId.Rubicum,
			StarSystemId.Rutia,
			StarSystemId.Sarpeidon,
			StarSystemId.Sefalla,
			StarSystemId.Seltrice,
			StarSystemId.Sigma,
			StarSystemId.Sol,
			StarSystemId.Somari,
			StarSystemId.Stakoron,
			StarSystemId.Styris,
			StarSystemId.Talani,
			StarSystemId.Tamus,
			StarSystemId.Tantalos,
			StarSystemId.Tanuga,
			StarSystemId.Tarchannen,
			StarSystemId.Terosa,
			StarSystemId.Thera,
			StarSystemId.Titan,
			StarSystemId.Torin,
			StarSystemId.Triacus,
			StarSystemId.Turkana,
			StarSystemId.Tyrus,
			StarSystemId.Umberlee,
			StarSystemId.Utopia,
			StarSystemId.Vadera,
			StarSystemId.Vagra,
			StarSystemId.Vandor,
			StarSystemId.Ventax,
			StarSystemId.Xenon,
			StarSystemId.Xerxes,
			StarSystemId.Yew,
			StarSystemId.Yojimbo,
			StarSystemId.Zalkon,
			StarSystemId.Zuul
		};
		#endregion

		#region SystemPressures
		public static SystemPressure[]	SystemPressures	= new SystemPressure[]
		{
			SystemPressure.None,
			SystemPressure.War,
			SystemPressure.Plague,
			SystemPressure.Drought,
			SystemPressure.Boredom,
			SystemPressure.Cold,
			SystemPressure.CropFailure,
			SystemPressure.Employment
		};
		#endregion

		#region TechLevels
		public static TechLevel[]	TechLevels	= new TechLevel[]
		{
			TechLevel.PreAgricultural,
			TechLevel.Agricultural,
			TechLevel.Medieval,
			TechLevel.Renaissance,
			TechLevel.EarlyIndustrial,
			TechLevel.Industrial,
			TechLevel.PostIndustrial,
			TechLevel.HiTech
		};
		#endregion

		#region TradeItems
		public static TradeItem[]	TradeItems	= new TradeItem[]
		{
			new TradeItem(TradeItemType.Water,     TechLevel.PreAgricultural, TechLevel.PreAgricultural, TechLevel.Medieval,          30,    3,   4, SystemPressure.Drought,     SpecialResource.SweetOceans,    SpecialResource.Desert,        30,   50,   1),
			new TradeItem(TradeItemType.Furs, 	   TechLevel.PreAgricultural, TechLevel.PreAgricultural, TechLevel.PreAgricultural,  250,   10,  10, SystemPressure.Cold,        SpecialResource.RichFauna,      SpecialResource.Lifeless,     230,  280,   5),
			new TradeItem(TradeItemType.Food, 	   TechLevel.Agricultural,    TechLevel.PreAgricultural, TechLevel.Agricultural,     100,    5,   5, SystemPressure.CropFailure, SpecialResource.RichSoil,       SpecialResource.PoorSoil,      90,  160,   5),
			new TradeItem(TradeItemType.Ore,       TechLevel.Medieval,        TechLevel.Medieval,        TechLevel.Renaissance,      350,   20,  10, SystemPressure.War,         SpecialResource.MineralRich,    SpecialResource.MineralPoor,  350,  420,  10),
			new TradeItem(TradeItemType.Games,     TechLevel.Renaissance,     TechLevel.Agricultural,    TechLevel.PostIndustrial,   250,  -10,   5, SystemPressure.Boredom,     SpecialResource.Artistic,       SpecialResource.NA,           160,  270,   5),
			new TradeItem(TradeItemType.Firearms,  TechLevel.Renaissance,     TechLevel.Agricultural,    TechLevel.Industrial,      1250,  -75, 100, SystemPressure.War,         SpecialResource.Warlike,        SpecialResource.NA,           600, 1100,  25),
			new TradeItem(TradeItemType.Medicine,  TechLevel.EarlyIndustrial, TechLevel.Agricultural,    TechLevel.PostIndustrial,   650,  -20,  10, SystemPressure.Plague,      SpecialResource.SpecialHerbs,   SpecialResource.NA,           400,  700,  25),
			new TradeItem(TradeItemType.Machines,  TechLevel.EarlyIndustrial, TechLevel.Renaissance,     TechLevel.Industrial,       900,  -30,   5, SystemPressure.Employment,  SpecialResource.NA,             SpecialResource.NA,           600,  800,  25),
			new TradeItem(TradeItemType.Narcotics, TechLevel.Industrial,      TechLevel.PreAgricultural, TechLevel.Industrial,      3500, -125, 150, SystemPressure.Boredom,     SpecialResource.WeirdMushrooms, SpecialResource.NA,          2000, 3000,  50),
			new TradeItem(TradeItemType.Robots,    TechLevel.PostIndustrial,  TechLevel.EarlyIndustrial, TechLevel.HiTech,          5000, -150, 100, SystemPressure.Employment,  SpecialResource.NA,             SpecialResource.NA,          3500, 5000, 100)
		};
		#endregion

		#region Weapons
		public static Weapon[]	Weapons	= new Weapon[]
		{
			new Weapon(WeaponType.PulseLaser,    15,  2000, TechLevel.Industrial,	    50),
			new Weapon(WeaponType.BeamLaser,     25, 12500, TechLevel.PostIndustrial, 35),
			new Weapon(WeaponType.MilitaryLaser, 35, 35000, TechLevel.HiTech,         15),
			// The weapons below cannot be bought
			new Weapon(WeaponType.MorgansLaser,	 85, 50000, TechLevel.Unavailable,     0)
		};
		#endregion

		#region EquipmentForSale (This comes at the end because it depends on other Constant Arrays)
		public static Equipment[]	EquipmentForSale	= new Equipment[]
		{
			Weapons[(int)WeaponType.PulseLaser],
			Weapons[(int)WeaponType.BeamLaser],
			Weapons[(int)WeaponType.MilitaryLaser],
			Shields[(int)ShieldType.Energy],
			Shields[(int)ShieldType.Reflective],
			Gadgets[(int)GadgetType.ExtraCargoBays],
			Gadgets[(int)GadgetType.AutoRepairSystem],
			Gadgets[(int)GadgetType.NavigatingSystem],
			Gadgets[(int)GadgetType.TargetingSystem],
			Gadgets[(int)GadgetType.CloakingDevice]
		};
		#endregion

		#endregion
	}
}
