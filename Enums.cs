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

namespace Fryz.Apps.SpaceTrader
{
	#region AlertType
	public enum AlertType: int
	{
		Alert,
		AntidoteOnBoard,
		AntidoteDestroyed,
		AntidoteTaken,
		AppStart,
		ArrivalBuyNewspaper,
		ArrivalIFFuel,
		ArrivalIFFuelRepairs,
		ArrivalIFNewspaper,
		ArrivalIFRepairs,
		ArtifactLost,
		ArtifactRelinquished,
		CargoIF,
		CargoNoEmptyBays,
		CargoNoneAvailable,
		CargoNoneToSell,
		CargoNotInterested,
		CargoNotSold,
		ChartJump,
		ChartJumpCurrent,
		ChartJumpNoSystemSelected,
		ChartTrackSystem,
		ChartWormholeUnreachable,
		Cheater,
		CrewFireMercenary,
		CrewNoQuarters,
		DebtNoBuy,
		DebtNone,
		DebtReminder,
		DebtTooLargeGrounded,
		DebtTooLargeLoan,
		DebtTooLargeTrade,
		DebtWarning,
		Egg,
		EncounterAliensSurrender,
		EncounterArrested,
		EncounterAttackCaptain,
		EncounterAttackNoDisruptors,
		EncounterAttackNoLasers,
		EncounterAttackNoWeapons,
		EncounterAttackPolice,
		EncounterAttackTrader,
		EncounterBothDestroyed,
		EncounterDisabledOpponent,
		EncounterDrinkContents,
		EncounterDumpAll,
		EncounterDumpWarning,
		EncounterEscaped,
		EncounterEscapedHit,
		EncounterEscapePodActivated,
		EncounterLooting,
		EncounterMarieCeleste,
		EncounterMarieCelesteNoBribe,
		EncounterOpponentEscaped,
		EncounterPiratesBounty,
		EncounterPiratesExamineReactor,
		EncounterPiratesFindNoCargo,
		EncounterPiratesSurrenderPrincess,
		EncounterPiratesTakeSculpture,
		EncounterPoliceBribe,
		EncounterPoliceBribeCant,
		EncounterPoliceBribeLowCash,
		EncounterPoliceFine,
		EncounterPoliceNothingFound,
		EncounterPoliceNothingIllegal,
		EncounterPoliceSubmit,
		EncounterPoliceSurrender,
		EncounterPostMarie,
		EncounterPostMarieFlee,
		EncounterScoop,
		EncounterScoopNoRoom,
		EncounterScoopNoScoop,
		EncounterSurrenderRefused,
		EncounterTonicConsumedGood,
		EncounterTonicConsumedStrange,
		EncounterTradeCompleted,
		EncounterYouLose,
		EncounterYouWin,
		EquipmentAlreadyOwn,
		EquipmentBuy,
		EquipmentEscapePod,
		EquipmentExtraBaysInUse,
		EquipmentFuelCompactor,
		EquipmentHiddenCompartments,
		EquipmentIF,
		EquipmentLightningShield,
		EquipmentMorgansLaser,
		EquipmentNotEnoughSlots,
		EquipmentQuantumDisruptor,
		EquipmentSell,
		FileErrorOpen,
		FileErrorSave,
		FleaBuilt,
		GameAbandonConfirm,
		GameClearHighScores,
		GameEndBoughtMoon,
		GameEndBoughtMoonGirl,
		GameEndHighScoreAchieved,
		GameEndHighScoreCheat,
		GameEndHighScoreMissed,
		GameEndKilled,
		GameEndRetired,
		GameEndScore,
		GameRetire,
		InsuranceNoEscapePod,
		InsurancePayoff,
		InsuranceStop,
		JailConvicted,
		JailFleaReceived,
		JailHiddenCargoBaysRemoved,
		JailIllegalGoodsImpounded,
		JailInsuranceLost,
		JailMercenariesLeave,
		JailShipSold,
		JarekTakenHome,
		LeavingIFInsurance,
		LeavingIFMercenaries,
		LeavingIFWormholeTax,
		MeetCaptainAhab,
		MeetCaptainConrad,
		MeetCaptainHuie,
		NewGameConfirm,
		NewGameMoreSkillPoints,
		OptionsNoGame,
		PreciousHidden,
		PrincessTakenHome,
		ReactorConfiscated,
		ReactorDestroyed,
		ReactorOnBoard,
		ReactorMeltdown,
		ReactorWarningFuel,
		ReactorWarningFuelGone,
		ReactorWarningTemp,
		RegistryError,
		SculptureConfiscated,
		SculptureSaved,
		ShipBuyConfirm,
		ShipBuyCrewQuarters,
		ShipBuyIF,
		ShipBuyIFTransfer,
		ShipBuyNoSlots,
		ShipBuyNotAvailable,
		ShipBuyNoTransfer,
		ShipBuyPassengerQuarters,
		ShipBuyReactor,
		ShipBuyTransfer,
		ShipDesignIF,
		ShipDesignThanks,
		ShipHullUpgraded,
		SpecialCleanRecord,
		SpecialExperimentPerformed,
		SpecialIF,
		SpecialMoonBought,
		SpecialNoQuarters,
		SpecialNotEnoughBays,
		SpecialPassengerConcernedJarek,
		SpecialPassengerConcernedPrincess,
		SpecialPassengerConcernedWild,
		SpecialPassengerImpatientJarek,
		SpecialPassengerImpatientPrincess,
		SpecialPassengerImpatientWild,
		SpecialPassengerOnBoard,
		SpecialSealedCanisters,
		SpecialSkillIncrease,
		SpecialTimespaceFabricRip,
		SpecialTrainingCompleted,
		TravelArrival,
		TravelUneventfulTrip,
		TribblesAllDied,
		TribblesAteFood,
		TribblesGone,
		TribblesHalfDied,
		TribblesKilled,
		TribblesMostDied,
		TribblesOwn,
		TribblesRemoved,
		TribblesInspector,
		TribblesSqueek,
		TribblesTradeIn,
		WildArrested,
		WildChatsPirates,
		WildGoesPirates,
		WildLeavesShip,
		WildSculpture,
		WildWontBoardLaser,
		WildWontBoardReactor,
		WildWontStayAboardLaser,
		WildWontStayAboardReactor
	};
	#endregion

	#region Activity
	public enum Activity: int
	{
		Absent							= 0,
		Minimal							= 1,
		Few									= 2,
		Some								= 3,
		Moderate						= 4,
		Many								= 5,
		Abundant						= 6,
		Swarms							= 7,
		NA									= 100
	};
	#endregion

	#region CargoBuyOp
	public enum CargoBuyOp: int
	{
		BuySystem,
		BuyTrader,
		Plunder
	};
	#endregion

	#region CargoSellOp
	public enum CargoSellOp: int
	{
		SellSystem,
		SellTrader,
		Dump,
		Jettison
	};
	#endregion

	#region CrewMemberId
	public enum CrewMemberId: int
	{
		NA									= -1,
		Commander						= 0,
		Alyssa							= 1,
		Armatur							= 2,
		Bentos							= 3,
		C2U2								= 4,
		ChiTi								= 5,
		Crystal							= 6,
		Dane								= 7,
		Deirdre							= 8,
		Doc									= 9,
		Draco								= 10,
		Iranda							= 11,
		Jeremiah						= 12,
		Jujubal							= 13,
		Krydon							= 14,
		Luis								= 15,
		Mercedez						= 16,
		Milete							= 17,
		MuriL								= 18,
		Mystyc							= 19,
		Nandi								= 20,
		Orestes							= 21,
		Pancho							= 22,
		PS37								= 23,
		Quarck							= 24,
		Sosumi							= 25,
		Uma									= 26,
		Wesley							= 27,
		Wonton							= 28,
		Yorvick							= 29,
		Zeethibal						= 30,
		Opponent						= 31,
		Wild								= 32,
		Jarek								= 33,
		FamousCaptain				= 34,
		Dragonfly						= 35,
		Scarab							= 36,
		SpaceMonster				= 37,
		Aragorn							= 38,
		Brady								= 39,
		EightOfNine					= 40,
		Fangorn							= 41,
		Gagarin							= 42,
		Hoshi								= 43,
		Jackson							= 44,
		Kaylee							= 45,
		Marcus							= 46,
		ONeill							= 47,
		Ripley							= 48,
		Stilgar							= 49,
		Taggart							= 50,
		Vansen							= 51,
		Xizor								= 52,
		Princess						= 53,
		Scorpion						= 54
	};
	#endregion

	#region Difficulty
	public enum Difficulty: int
	{
		Beginner						= 0,
		Easy								= 1,
		Normal							= 2,
		Hard								= 3,
		Impossible					= 4
	};
	#endregion

	#region EncounterResult
	public enum EncounterResult: int
	{
		Continue,
		Normal,
		Killed,
		EscapePod,
		Arrested
	};
	#endregion

	#region EncounterType
	public enum EncounterType: int
	{
		BottleGood					= 0,
		BottleOld						= 1,
		CaptainAhab					= 2,
		CaptainConrad				= 3,
		CaptainHuie					= 4,
		DragonflyAttack			= 5,
		DragonflyIgnore			= 6,
		FamousCaptainAttack	= 7,
		FamousCaptDisabled	= 8,
		MarieCeleste				= 9,
		MarieCelestePolice	= 10,
		PirateAttack				= 11,
		PirateIgnore				= 12,
		PirateFlee					= 13,
		PirateSurrender			= 14,
		PirateDisabled			= 15,
		PoliceAttack				= 16,
		PoliceIgnore				= 17,
		PoliceFlee					= 18,
		PoliceSurrender			= 19,
		PoliceDisabled			= 20,
		PoliceInspect				= 21,
		ScarabAttack				= 22,
		ScarabIgnore				= 23,
		ScorpionAttack			= 24,
		ScorpionIgnore			= 25,
		SpaceMonsterAttack	= 26,
		SpaceMonsterIgnore	= 27,
		TraderAttack				= 28,
		TraderIgnore				= 29,
		TraderFlee					= 30,
		TraderSurrender			= 31,
		TraderDisabled			= 32,
		TraderBuy						= 33,
		TraderSell					= 34
	};
	#endregion

	#region EquipmentType
	public enum EquipmentType: int
	{
		Weapon							= 0,
		Shield							= 1,
		Gadget							= 2
	};
	#endregion

	#region GadgetType
	public enum GadgetType: int
	{
		ExtraCargoBays			= 0,
		AutoRepairSystem		= 1,
		NavigatingSystem		= 2,
		TargetingSystem			= 3,
		CloakingDevice			= 4,
		FuelCompactor				= 5,
		HiddenCargoBays			= 6
	};
	#endregion

	#region GameEndType
	public enum GameEndType: int
	{
		NA									= -1,
		Killed							= 0,
		Retired							= 1,
		BoughtMoon					= 2,
		BoughtMoonGirl			= 3
	};
	#endregion

	#region NewsEvent
	public enum NewsEvent: int
	{
		ArtifactDelivery		= 0,
		CaughtLittering			= 1,
		Dragonfly						= 2,
		DragonflyBaratas		= 3,
		DragonflyDestroyed	= 4,
		DragonflyMelina			= 5,
		DragonflyRegulas		= 6,
		DragonflyZalkon			= 7,
		ExperimentFailed		= 8,
		ExperimentPerformed	= 9,
		ExperimentStopped		= 10,
		ExperimentArrival		= 11,
		Gemulon							= 12,
		GemulonInvaded			= 13,
		GemulonRescued			= 14,
		CaptAhabAttacked		= 15,
		CaptAhabDestroyed		= 16,
		CaptConradAttacked	= 17,
		CaptConradDestroyed	= 18,
		CaptHuieAttacked		= 19,
		CaptHuieDestroyed		= 20,
		Japori							= 21,
		JaporiDelivery			= 22,
		JarekGetsOut				= 23,
		Scarab							= 24,
		ScarabDestroyed			= 25,
		ScarabHarass				= 26,
		SpaceMonster				= 27,
		SpaceMonsterKilled	= 28,
		WildArrested				= 29,
		WildGetsOut					= 30,
		SculptureStolen			= 31,
		SculptureTracked		= 32,
		Princess						= 33,
		PrincessCentauri		= 34,
		PrincessInthara			= 35,
		PrincessQonos				= 36,
		PrincessRescued			= 37,
		PrincessReturned		= 38
	};
	#endregion

	#region OpponentType
	public enum OpponentType: int
	{
		Bottle,
		FamousCaptain,
		Mantis,
		Pirate,
		Police,
		Trader
	};
	#endregion

	#region PoliceRecordType
	public enum PoliceRecordType: int
	{
		Psychopath					= 0,
		Villain							= 1,
		Criminal						= 2,
		Crook								= 3,
		Dubious							= 4,
		Clean								= 5,
		Lawful							= 6,
		Trusted							= 7,
		Liked								= 8,
		Hero								= 9
	};
	#endregion

	#region PoliticalSystemType
	public enum PoliticalSystemType: int
	{
		Anarchy							= 0,
		Capitalist					= 1,
		Communist						= 2,
		Confederacy					= 3,
		Corporate						= 4,
		Cybernetic					= 5,
		Democracy						= 6,
		Dictatorship				= 7,
		Fascist							= 8,
		Feudal							= 9,
		Military						= 10,
		Monarchy						= 11,
		Pacifist						= 12,
		Socialist						= 13,
		Satori							= 14,
		Technocracy					= 15,
		Theocracy						= 16
	};
	#endregion

	#region ReputationType
	public enum ReputationType: int
	{
		Harmless						= 0,
		MostlyHarmless			= 1,
		Poor								= 2,
		Average							= 3,
		AboveAverage				= 4,
		Competent						= 5,
		Dangerous						= 6,
		Deadly							= 7,
		Elite								= 8
	};
	#endregion

	#region ShieldType
	public enum ShieldType: int
	{
		Energy							= 0,
		Reflective					= 1,
		Lightning						= 2
	};
	#endregion

	#region ShipType
	public enum ShipType: int
	{
		Flea								= 0,
		Gnat								= 1,
		Firefly							= 2,
		Mosquito						= 3,
		Bumblebee						= 4,
		Beetle							= 5,
		Hornet							= 6,
		Grasshopper					= 7,
		Termite							= 8,
		Wasp								= 9,
		SpaceMonster				= 10,
		Dragonfly						= 11,
		Mantis							= 12,
		Scarab							= 13,
		Bottle							= 14,
		Custom							= 15,
		Scorpion						= 16
	};
	#endregion

	#region ShipyardId
	public enum ShipyardId: int
	{
		NA									= -1,
		Corellian						= 0,
		Incom								= 1,
		Kuat								= 2,
		Sienar							= 3,
		Sorosuub						= 4
	};
	#endregion

	#region ShipyardSkill
	public enum ShipyardSkill: int
	{
		CrewQuarters				= 0,	// Crew Quarters take up 2 fewer units
		FuelBase						= 1,	// Fuel Base is 2 greater
		HullPerUnit					= 2,	// Number of Hull Points per unit is 5 greater
		ShieldSlotUnits			= 3,	// Shield Slots take up 2 fewer units
		WeaponSlotUnits			= 4		// Weapon Slots take up 2 fewer units
	};
	#endregion

	#region Size
	public enum Size: int
	{
		Tiny								= 0,
		Small								= 1,
		Medium							= 2,
		Large								= 3,
		Huge								= 4,
		Gargantuan					= 5
	};
	#endregion

	#region SkillType
	public enum SkillType: int
	{
		NA									= -1,
		Pilot								= 0,
		Fighter							= 1,
		Trader							= 2,
		Engineer						= 3
	};
	#endregion

	#region SpecialEventType
	public enum SpecialEventType: int
	{
		NA									= -1,
		Artifact						= 0,
		ArtifactDelivery		= 1,
		CargoForSale				= 2,
		Dragonfly						= 3,
		DragonflyBaratas		= 4,
		DragonflyDestroyed	= 5,
		DragonflyMelina			= 6,
		DragonflyRegulas		= 7,
		DragonflyShield			= 8,
		EraseRecord					= 9,
		Experiment					= 10,
		ExperimentFailed		= 11,
		ExperimentStopped		= 12,
		Gemulon							= 13,
		GemulonFuel					= 14,
		GemulonInvaded			= 15,
		GemulonRescued			= 16,
		Japori							= 17,
		JaporiDelivery			= 18,
		Jarek								= 19,
		JarekGetsOut				= 20,
		Lottery							= 21,
		Moon								= 22,
		MoonRetirement			= 23,
		Reactor							= 24,
		ReactorDelivered		= 25,
		ReactorLaser				= 26,
		Scarab							= 27,
		ScarabDestroyed			= 28,
		ScarabUpgradeHull		= 29,
		Skill								= 30,
		SpaceMonster				= 31,
		SpaceMonsterKilled	= 32,
		Tribble							= 33,
		TribbleBuyer				= 34,
		Wild								= 35,
		WildGetsOut					= 36,
		Sculpture						= 37,
		SculptureDelivered	= 38,
		SculptureHiddenBays	= 39,
		Princess						= 40,
		PrincessCentauri		= 41,
		PrincessInthara			= 42,
		PrincessQonos				= 43,
		PrincessQuantum			= 44,
		PrincessReturned		= 45
	};
	#endregion

	#region SpecialResource
	public enum SpecialResource: int
	{
		NA									= -1,
		Nothing							= 0,
		MineralRich					= 1,
		MineralPoor					= 2,
		Desert							= 3,
		SweetOceans					= 4,
		RichSoil						= 5,
		PoorSoil						= 6,
		RichFauna						= 7,
		Lifeless						= 8,
		WeirdMushrooms			= 9,
		SpecialHerbs				= 10,
		Artistic						= 11,
		Warlike							= 12
	};
	#endregion

	#region StarSystemId
	public enum StarSystemId: int
	{
		NA									= -1,
		Acamar							= 0,
		Adahn								= 1,
		Aldea								= 2,
		Andevian						= 3,
		Antedi							= 4,
		Balosnee						= 5,
		Baratas							= 6,
		Brax								= 7,
		Bretel							= 8,
		Calondia						= 9,
		Campor							= 10,
		Capelle							= 11,
		Carzon							= 12,
		Castor							= 13,
		Cestus							= 14,
		Cheron							= 15,
		Courteney						= 16,
		Daled								= 17,
		Damast							= 18,
		Davlos							= 19,
		Deneb								= 20,
		Deneva							= 21,
		Devidia							= 22,
		Draylon							= 23,
		Drema								= 24,
		Endor								= 25,
		Esmee								= 26,
		Exo									= 27,
		Ferris							= 28,
		Festen							= 29,
		Fourmi							= 30,
		Frolix							= 31,
		Gemulon							= 32,
		Guinifer						= 33,
		Hades								= 34,
		Hamlet							= 35,
		Helena							= 36,
		Hulst								= 37,
		Iodine							= 38,
		Iralius							= 39,
		Janus								= 40,
		Japori							= 41,
		Jarada							= 42,
		Jason								= 43,
		Kaylon							= 44,
		Khefka							= 45,
		Kira								= 46,
		Klaatu							= 47,
		Klaestron						= 48,
		Korma								= 49,
		Kravat							= 50,
		Krios								= 51,
		Laertes							= 52,
		Largo								= 53,
		Lave								= 54,
		Ligon								= 55,
		Lowry								= 56,
		Magrat							= 57,
		Malcoria						= 58,
		Melina							= 59,
		Mentar							= 60,
		Merik								= 61,
		Mintaka							= 62,
		Montor							= 63,
		Mordan							= 64,
		Myrthe							= 65,
		Nelvana							= 66,
		Nix									= 67,
		Nyle								= 68,
		Odet								= 69,
		Og									= 70,
		Omega								= 71,
		Omphalos						= 72,
		Orias								= 73,
		Othello							= 74,
		Parade							= 75,
		Penthara						= 76,
		Picard							= 77,
		Pollux							= 78,
		Quator							= 79,
		Rakhar							= 80,
		Ran									= 81,
		Regulas							= 82,
		Relva								= 83,
		Rhymus							= 84,
		Rochani							= 85,
		Rubicum							= 86,
		Rutia								= 87,
		Sarpeidon						= 88,
		Sefalla							= 89,
		Seltrice						= 90,
		Sigma								= 91,
		Sol									= 92,
		Somari							= 93,
		Stakoron						= 94,
		Styris							= 95,
		Talani							= 96,
		Tamus								= 97,
		Tantalos						= 98,
		Tanuga							= 99,
		Tarchannen					= 100,
		Terosa							= 101,
		Thera								= 102,
		Titan								= 103,
		Torin								= 104,
		Triacus							= 105,
		Turkana							= 106,
		Tyrus								= 107,
		Umberlee						= 108,
		Utopia							= 109,
		Vadera							= 110,
		Vagra								= 111,
		Vandor							= 112,
		Ventax							= 113,
		Xenon								= 114,
		Xerxes							= 115,
		Yew									= 116,
		Yojimbo							= 117,
		Zalkon							= 118,
		Zuul								= 119,
		Centauri						= 120,
		Galvon							= 121,
		Inthara							= 122,
		Meridian						= 123,
		Qonos								= 124,
		Rae									= 125,
		Weytahn							= 126,
		Zonama							= 127
	};
	#endregion

	#region SystemPressure
	public enum SystemPressure: int
	{
		None								= 0,
		War									= 1,
		Plague							= 2,
		Drought							= 3,
		Boredom							= 4,
		Cold								= 5,
		CropFailure					= 6,
		Employment					= 7
	};
	#endregion

	#region TechLevel
	public enum TechLevel: int
	{
		PreAgricultural			= 0,
		Agricultural				= 1,
		Medieval						= 2,
		Renaissance					= 3,
		EarlyIndustrial			= 4,
		Industrial					= 5,
		PostIndustrial			= 6,
		HiTech							= 7,
		Unavailable					= 8
	};
	#endregion

	#region TradeItemType
	public enum TradeItemType: int
	{
		NA									= -1,
		Water								= 0,
		Furs								= 1,
		Food								= 2,
		Ore									= 3,
		Games								= 4,
		Firearms						= 5,
		Medicine						= 6,
		Machines						= 7,
		Narcotics						= 8,
		Robots							= 9
	};
	#endregion

	#region VeryRareEncounter
	public enum VeryRareEncounter: int
	{
		MarieCeleste				= 0,
		CaptainAhab					= 1,
		CaptainConrad				= 2,
		CaptainHuie					= 3,
		BottleOld						= 4,
		BottleGood					= 5
	};
	#endregion

	#region WeaponType
	public enum WeaponType: int
	{
		PulseLaser					= 0,
		BeamLaser						= 1,
		MilitaryLaser				= 2,
		MorgansLaser				= 3,
		PhotonDisruptor			= 4,
		QuantumDistruptor		= 5
	};
	#endregion
}
