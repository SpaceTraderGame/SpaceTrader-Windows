/*******************************************************************************
 *
 * Space Trader for Windows File Converter 2.00
 *
 * Copyright (C) 2005 Jay French, All Rights Reserved
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
 ******************************************************************************/
using System;

namespace Fryz.Apps.SpaceTrader
{
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
		Swarms							= 7
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
		SpaceMonster				= 37
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

	#region EncounterType
	public enum EncounterType: int
	{
		BottleGood					= 0,
		BottleOld						= 1,
		CaptainAhab					= 2,
		CaptainConrad				= 3,
		CaptainHuie					= 4,
		FamousCaptainAttack	= 5,
		DragonflyAttack			= 6,
		DragonflyIgnore			= 7,
		MarieCeleste				= 8,
		MarieCelestePolice	= 9,
		PirateAttack				= 10,
		PirateIgnore				= 11,
		PirateFlee					= 12,
		PirateSurrender			= 13,
		PoliceAttack				= 14,
		PoliceIgnore				= 15,
		PoliceFlee					= 16,
		PoliceSurrender			= 17,
		PoliceInspect				= 18,
		ScarabAttack				= 19,
		ScarabIgnore				= 20,
		SpaceMonsterAttack	= 21,
		SpaceMonsterIgnore	= 22,
		TraderAttack				= 23,
		TraderIgnore				= 24,
		TraderFlee					= 25,
		TraderSurrender			= 26,
		TraderBuy						= 27,
		TraderSell					= 28
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
		FuelCompactor				= 5
	};
	#endregion

	#region GameEndType
	public enum GameEndType: int
	{
		NA									= -1,
		Killed							= 0,
		Retired							= 1,
		BoughtMoon					= 2
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
		WildGetsOut					= 30
	};
	#endregion

	#region OpponentType
	public enum OpponentType: int
	{
		Bottle							= 0,
		FamousCaptain				= 1,
		Mantis							= 2,
		Pirate							= 3,
		Police							= 4,
		Trader							= 5
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
		Bottle							= 14
	};
	#endregion

	#region ShipyardId
	public enum ShipyardId: int
	{
		NA									= -1,
		Kessel							= 0,
		Kuat								= 1,
		Loronar							= 2,
		Sienar							= 3,
		Sorosuub						= 4
	};
	#endregion

	#region Size
	public enum Size: int
	{
		Tiny								= 0,
		Small								= 1,
		Medium							= 2,
		Large								= 3,
		Huge								= 4
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
		WildGetsOut					= 36
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
		Zuul								= 119
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
		MorgansLaser				= 3
	};
	#endregion
}
