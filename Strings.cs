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
	public class Strings
	{
		#region Individual String Constants

		public static string	BankInsuranceButtonText					= "^1 Insurance";
		public static string	BankInsuranceButtonBuy					= "Buy";
		public static string	BankInsuranceButtonStop					= "Stop";
		public static string	BankLoanStatementBorrow					= "You can borrow up to ^1.";
		public static string	BankLoanStatementDebt						= "You have a debt of ^1.";

		public static string	ChartDistance										= "^1 to ^2.";

		public static string	CargoBuyAfford									= "You can afford to buy ^1.";
		public static string	CargoBuyAvailable								= "The trader has ^1 for sale.";
		public static string	CargoBuying											= "buying";
		public static string	CargoBuyNA											= "not sold";
		public static string	CargoBuyQuestion								= "How many do you want to ^1?";
		public static string	CargoBuyStatement								= "At ^1 each, you can buy up to ^2.";
		public static string	CargoBuyStatementSteal					= "Your victim has ^1 of these goods.";
		public static string	CargoBuyStatementTrader					= "The trader wants to sell ^1 for the price of ^2 each.";
		public static string	CargoSellDumpCost								= "It costs ^1 per unit for disposal.";
		public static string	CargoSelling										= "selling";
		public static string	CargoSellNA											= "no trade";
		public static string	CargoSellPaid										= "You paid about ^1 per unit.";
		public static string	CargoSellPaidTrader							= "You paid about ^1 per unit, and can sell ^2.";
		public static string	CargoSellProfit									= "Your ^1 per unit is ^2";
		public static string	CargoSellQuestion								= "How many do you want to ^1?";
		public static string	CargoSellStatement							= "You can sell up to ^1 at ^2 each.";
		public static string	CargoSellStatementDump					= "You can ^1 up to ^2.";
		public static string	CargoSellStatementTrader				= "The trader wants to buy ^1 and offers ^2 each.";
		public static string	CargoTitle											= "^1 ^2";
		public static string	CargoUnit												= "unit";

		public static string	CopyrightChar										= char.ToString((char)169);

		public static string	DistanceUnit										= "parsec";
		public static string	DistanceSubunit									= "click";

		public static string	DockFuelCost										= "A full tank costs ^1";
		public static string	DockFuelFull										= "Your tank is full.";
		public static string	DockFuelStatus									= "You have fuel to fly ^1.";
		public static string	DockHullCost										= "Full repairs will cost ^1";
		public static string	DockHullFull										= "No repairs are needed.";
		public static string	DockHullStatus									= "Your hull strength is at ^1%.";

		public static string	EncounterActionCmdrChased				= "The ^1 is still following you.";
		public static string	EncounterActionCmdrHit					= "The ^1 hits you.";
		public static string	EncounterActionCmdrMissed				= "The ^1 missed you.";
		public static string	EncounterActionOppAttacks				= "The ^1 attacks.";
		public static string	EncounterActionOppChased				= "The ^1 didn't get away.";
		public static string	EncounterActionOppDisabled			= "The ^1 has been disabled.";
		public static string	EncounterActionOppFleeing				= "The ^1 is fleeing.";
		public static string	EncounterActionOppHit						= "You hit the ^1.";
		public static string	EncounterActionOppMissed				= "You missed the ^1.";
		public static string	EncounterActionOppSurrender			= "The ^1 hails that they wish to surrender to you.";
		public static string	EncounterHidePrincess						= "the Princess";
		public static string	EncounterHideSculpture					= "the stolen sculpture";
		public static string	EncounterHullStrength						= "Hull at ^1%";
		public static string	EncounterPiratesDestroyed				= "destroyed";
		public static string	EncounterPiratesDisabled				= "disabled";
		public static string	EncounterPiratesLocation				= " (informing the police of the pirate's location)";
		public static string	EncounterPoliceSubmitArrested		= "You will be arrested!";
		public static string	EncounterPoliceSubmitGoods			= "illegal goods";
		public static string	EncounterPoliceSubmitReactor		= "an illegal Ion Reactor";
		public static string	EncounterPoliceSubmitSculpture	= "a stolen sculpture";
		public static string	EncounterPoliceSubmitWild				= "Jonathan Wild";
		public static string	EncounterPoliceSurrenderCargo		= "You have ^1 on board! ";
		public static string	EncounterPoliceSurrenderAction	= "They will ^1. ";
		public static string	EncounterPoliceSurrenderReactor	= "destroy the reactor";
		public static string	EncounterPoliceSurrenderSculpt	= "confiscate the sculpture";
		public static string	EncounterPoliceSurrenderWild		= "arrest Wild, too";
		public static string	EncounterPretextAlien						= "an alien";
		public static string	EncounterPretextBottle					= "a floating";
		public static string	EncounterPretextCaptainAhab			= "the famous Captain Ahab in a";
		public static string	EncounterPretextCaptainConrad		= "the famous Captain Conrad in a";
		public static string	EncounterPretextCaptainHuie			= "the famous Captain Huie in a";
		public static string	EncounterPretextMarie						= "a drifting";
		public static string	EncounterPretextMariePolice			= "the Customs Police in a";
		public static string	EncounterPretextPirate					= "a pirate";
		public static string	EncounterPretextPolice					= "a police";
		public static string	EncounterPretextScorpion				= "the kidnappers in a";
		public static string	EncounterPretextSpaceMonster		= "a horrifying";
		public static string	EncounterPretextStolen					= "a stolen";
		public static string	EncounterPretextTrader					= "a trader";
		public static string	EncounterPrincessRescued				= Environment.NewLine + Environment.NewLine + "You land your ship near where the Space Corps has landed with the Scorpion in tow. The Princess is revived from hibernation and you get to see her for the first time. Instead of the spoiled child you were expecting, Ziyal is possible the most beautiful woman you've ever seen. \"What took you so long?\" she demands. You notice a twinkle in her eye, and then she smiles. Not only is she beautiful, but she's got a sense of humor. She says, \"Thank you for freeing me. I am in your debt.\" With that she give you a kiss on the cheek, then leaves. You hear her mumble, \"Now about a ride home.\"";
		public static string	EncounterShieldStrength					= "Shields at ^1%";
		public static string	EncounterShieldNone							= "No Shields";
		public static string	EncounterShipCaptain						= "Captain";
		public static string	EncounterShipMantis							= "alien ship";
		public static string	EncounterShipPirate							= "pirate ship";
		public static string	EncounterShipPolice							= "police ship";
		public static string	EncounterShipTrader							= "trader ship";
		public static string	EncounterText										= "At ^1 from ^2 you encounter ^3 ^4.";
		public static string	EncounterTextBottle							= "It appears to be a rare bottle of Captain Marmoset's Skill Tonic!";
		public static string	EncounterTextFamousCaptain			= "The Captain requests a brief meeting with you.";
		public static string	EncounterTextMarieCeleste				= "The Marie Celeste appears to be completely abandoned.";
		public static string	EncounterTextOpponentAttack			= "Your opponent attacks.";
		public static string	EncounterTextOpponentFlee				= "Your opponent is fleeing.";
		public static string	EncounterTextOpponentIgnore			= "It ignores you.";
		public static string	EncounterTextOpponentNoNotice		= "It doesn't notice you.";
		public static string	EncounterTextPoliceInspection		= "The police summon you to submit to an inspection.";
		public static string	EncounterTextPolicePostMarie		= "\"We know you removed illegal goods from the Marie Celeste. You must give them up at once!\"";
		public static string	EncounterTextPoliceSurrender		= "The police hail they want you to surrender.";
		public static string	EncounterTextTrader							= "You are hailed with an offer to trade goods.";

		public static string	EquipmentNoneForSale						= "None for sale";
		public static string	EquipmentNoSlots								= "No slots";
		public static string	EquipmentFreeSlot								= " - FREE SLOT - ";

		public static string	FileFormatBad										= "The file is not a Space Trader for Windows file, or is the wrong version or has been corrupted.";
		public static string	FileFutureVersion								= "The version of the file is greater than the current version. You should upgrade to the latest version of Space Trader for Windows.";

		public static string	HighScoreStatus									= "^1 in ^2, worth ^3 on ^4 level.";

		public static string	Mercenaries											= " mercenaries";
		public static string	MercenariesForHire							= "^1 available for hire.";
		public static string	MercenaryFire										= "Fire";
		public static string	MercenaryHire										= "Hire";
		public static string	MercOnBoard											= "Member of Crew (^1)";

		public static string	MoneyRateSuffix									= "^1 daily";
		public static string	MoneyUnit												= "credit";

		public static string	NA															= "N/A";

		public static string	NewsMoonForSale									= "Seller in ^1 System has Utopian Moon available.";
		public static string	NewsShipyard										= "Shipyard in ^1 System offers to design custom ships.";
		public static string	NewsTribbleBuyer								= "Collector in ^1 System seeks to purchase Tribbles.";

		public static string	PersonnelNoMercenaries					= "No one for hire";
		public static string	PersonnelNoQuarters							= "No quarters available";
		public static string	PersonnelVacancy								= "Vacancy";

		public static string	QuestNone												= "There are no open quests.";
		public static string	QuestArtifact										= "Deliver the alien artifact to Professor Berger at some hi-tech system.";
		public static string	QuestDragonflyBaratas						= "Follow the Dragonfly to Baratas.";
		public static string	QuestDragonflyMelina						= "Follow the Dragonfly to Melina.";
		public static string	QuestDragonflyRegulas						= "Follow the Dragonfly to Regulas.";
		public static string	QuestDragonflyShield						= "Get your lightning shield at Zalkon.";
		public static string	QuestDragonflyZalkon						= "Follow the Dragonfly to Zalkon.";
		public static string	QuestExperimentInformDays				= "Stop Dr. Fehler's experiment at Daled within ^1.";
		public static string	QuestExperimentInformTomorrow		= "Stop Dr. Fehler's experiment at Daled by tomorrow.";
		public static string	QuestGemulonFuel								= "Get your fuel compactor at Gemulon.";
		public static string	QuestGemulonInformDays					= "Inform Gemulon about alien invasion within ^1.";
		public static string	QuestGemulonInformTomorrow			= "Inform Gemulon about alien invasion by tomorrow.";
		public static string	QuestJarek											= "Take ambassador Jarek to Devidia.";
		public static string	QuestJarekImpatient							= QuestJarek + Environment.NewLine + "Jarek is wondering why the journey is taking so long, and is no longer of much help in negotiating trades.";
		public static string	QuestJaporiDeliver							= "Deliver antidote to Japori.";
		public static string	QuestMoon												= "Claim your moon at Utopia.";
		public static string	QuestPrincessCentauri						= "Follow the Scorpion to Centauri.";
		public static string	QuestPrincessInthara						= "Follow the Scorpion to Inthara.";
		public static string	QuestPrincessQonos							= "Follow the Scorpion to Qonos.";
		public static string	QuestPrincessQuantum						= "Get your Quantum Disruptor at Galvon.";
		public static string	QuestPrincessReturn							= "Transport ^1 from Qonos to Galvon.";
		public static string	QuestPrincessReturning					= "Return ^1 to Galvon.";
		public static string	QuestPrincessReturningImpatient	= QuestPrincessReturning + Environment.NewLine + "She is becoming anxious to arrive at home, and is no longer of any help in engineering functions.";
		public static string	QuestReactor										= "Deliver the unstable reactor to Nix for Henry Morgan.";
		public static string	QuestReactorFuel								= "Deliver the unstable reactor to Nix before it consumes all its fuel.";
		public static string	QuestReactorLaser								= "Get your special laser at Nix.";
		public static string	QuestScarabFind									= "Find and destroy the Scarab (which is hiding at the exit to a wormhole).";
		public static string	QuestScarabHull									= "Get your hull upgraded at ^1.";
		public static string	QuestScarabNotify								= "Notify the authorities at ^1 that the Scarab has been destroyed.";
		public static string	QuestSculpture									= "Deliver the stolen sculpture to Endor.";
		public static string	QuestSculptureHiddenBays				= "Have hidden compartments installed at Endor.";
		public static string	QuestSpaceMonsterKill						= "Kill the space monster at Acamar.";
		public static string	QuestTribbles										= "Get rid of those pesky tribbles.";
		public static string	QuestWild												= "Smuggle Jonathan Wild to Kravat.";
		public static string	QuestWildImpatient							= QuestWild + Environment.NewLine + "Wild is getting impatient, and will no longer aid your crew along the way.";

		public static string	ShipBuyGotOne										= "got one";
		public static string	ShipBuyTransfer									= ", and transfer your unique equipment to the new ship";

		public static string	ShipInfoEscapePod								= "Escape Pod";

		public static string	ShipNameCurrentShip							= "<current ship>";
		public static string	ShipNameCustomShip							= "Custom Ship";
		public static string	ShipNameModified								= "<modified>";
		public static string	ShipNameTemplateSuffixDefault		= " (Default)";
		public static string	ShipNameTemplateSuffixMinimum		= " (Minimum)";

		public static string	ShipyardEquipForSale						= "There is equipment for sale.";
		public static string	ShipyardEquipNoSale							= "No equipment for sale.";
		public static string	ShipyardPodCost									= "You can buy an escape pod for 2,000 cr.";
		public static string	ShipyardPodIF										= "You need 2,000 cr. to buy an escape pod.";
		public static string	ShipyardPodInstalled						= "You have an escape pod installed.";
		public static string	ShipyardPodNoSale								= "No escape pods for sale.";
		public static string	ShipyardShipForSale							= "There are ships for sale.";
		public static string	ShipyardShipNoSale							= "No ships for sale.";
		public static string	ShipyardSizeItem								= "^1 (Max ^2)";
		public static string	ShipyardTitle										= "Ship Design at ^1 Shipyards";
		public static string	ShipyardUnit										= "Unit";
		public static string	ShipyardWarning									= "Bear in mind that getting too close to the maximum number of units will result in a \"Crowding Penalty\" due to the engineering difficulty of squeezing everything in.  There is a modest penalty at 80%, and a more severe one at 90%.";
		public static string	ShipyardWelcome									= "Welcome to ^1 Shipyards! Our best engineer, ^2, is at your service.";

		public static string	SpecialCargoArtifact						= "An alien artifact.";
		public static string	SpecialCargoExperiment					= "A portable singularity.";
		public static string	SpecialCargoJapori							= "10 bays of antidote.";
		public static string	SpecialCargoJarek								= "A haggling computer.";
		public static string	SpecialCargoNone								= "No special items.";
		public static string	SpecialCargoReactor							= "An unstable reactor taking up 5 bays.";
		public static string	SpecialCargoSculpture						= "A stolen plastic sculpture of a man holding some kind of light sword.";
		public static string	SpecialCargoReactorBays					= " of enriched fuel.";
		public static string	SpecialCargoTribblesInfest			= "An infestation of tribbles.";
		public static string	SpecialCargoTribblesCute				= "cute, furry tribble";

		public static string	TimeUnit												= "day";

		public static string	TribbleDangerousNumber					= "a dangerous number of";

		public static string	Unknown													= "Unknown";

		#endregion

		#region String Arrays

		#region ActivityLevels
		public static string[]	ActivityLevels	= new string[]
		{
			"Absent",
			"Minimal",
			"Few",
			"Some",
			"Moderate",
			"Many",
			"Abundant",
			"Swarms"
		};
		#endregion

		#region CargoBuyOps
		public static string[]	CargoBuyOps	= new string[]
		{
			"Buy",
			"Buy",
			"Steal"
		};
		#endregion

		#region CargoSellOps
		public static string[]	CargoSellOps	= new string[]
		{
			"Sell",
			"Sell",
			"Dump",
			"Jettison"
		};
		#endregion

		#region CrewMemberNames
		public static string[]	CrewMemberNames	= new string[]
		{
			"Commander",
			"Alyssa",
			"Armatur",
			"Bentos",
			"C2U2",
			"Chi'Ti",
			"Crystal",
			"Dane",
			"Deirdre",
			"Doc",
			"Draco",
			"Iranda",
			"Jeremiah",
			"Jujubal",
			"Krydon",
			"Luis",
			"Mercedez",
			"Milete",
			"Muri-L",
			"Mystyc",
			"Nandi",
			"Orestes",
			"Pancho",
			"PS37",
			"Quarck",
			"Sosumi",
			"Uma",
			"Wesley",
			"Wonton",
			"Yorvick",
			"Zeethibal",			// anagram for Elizabeth

			// The rest are mercenaries I added - JAF
			"Opponent",				// crew of opponent mantis, pirate, police, and trader ships
			"Wild",						// now earns his keep!
			"Jarek",					// now earns his keep!
			"Captain",				// crew of famous captain ships
			"Dragonfly",			// dummy crew member used in opponent ship
			"Scarab",					// dummy crew member used in opponent ship
			"SpaceMonster",		// dummy crew member used in opponent ship
			"Aragorn",				// My first son's middle name, and from Lord of the Rings
			"Brady",					// My third son's middle name, and QB of the New England Patriots
			"Eight of Nine",	// From Star Trek - Seven's younger sibling ;)
			"Fangorn",				// From Lord of the Rings
			"Gagarin",				// The first man in space
			"Hoshi",					// From ST: Enterprise
			"Jackson",				// From Stargate - and my nephew's first name
			"Kaylee",					// From FireFly
			"Marcus",					// My second son's middle name
			"O'Neill",				// From Stargate
			"Ripley",					// From the Alien series
			"Stilgar",				// From Dune
			"Taggart",				// From Galaxy Quest
			"Vansen",					// From Space: Above and Beyond
			"Xizor",					// From Star Wars: Shadows of the Empire
			"Ziyal",					// From ST: Deep Space 9
			"Scorpion"				// dummy crew member used in opponent ship 
		};
		#endregion

		#region DifficultyLevels
		public static string[]	DifficultyLevels	= new string[]
		{
			"Beginner",
			"Easy",
			"Normal",
			"Hard",
			"Impossible"
		};
		#endregion

		#region EquipmentDescriptions
		public static string[][]     EquipmentDescriptions     = new string[][]
		{
			new string[]
			{
				"The Pulse Laser is the weakest weapon available. It's small size allows only enough energy to build up to emit pulses of light.",
				"The Beam Laser is larger than the Pulse Laser, so can build up enough charge to power what are essentially two Pulse Lasers. The resulting effect appears more like a constant beam.",
				"The Military Laser is the largest commecially available weapon. It can build up enough charge to power three Pulse Lasers in series, resulting in a more dense and concentrated beam.",
				"Morgan's Laser has been constructed from a Beam Laser, which has been attached to an Ion Reactor that builds up an immense charge, resulting in the strongest weapon known to exist.",
				"The Photon Disruptor is a relatively weak weapon, but has the ability to disable an opponent's electrical systems, rendering them helpless.",
				"The Quantum Disruptor is a very powerful disabling weapon. Once an opponent's sheilds are down it will usually require only a single shot with the Quantum Disruptor to disable them."
			},
			new string[]
			{
				"The Energy Shield is a very basic deflector shield. Its operating principle is to absorb the energy directed at it.",
				"The Reflective Shield is twice as powerful as the Energy Shield. It works by reflecting the energy directed at it instead of absorbing that energy.",
				"The Lightning Shield is the most powerful shield known to exist. It features a Reflective Shield operating on a rotating frequency, which causes what looks like lightning to play across the shield barrier."
			},
			new string[]
			{
				"Extra Cargo Bays to store anything your ship can take on as cargo.",
				"The Auto-Repair System works to reduce the damage your ship sustains in battle, and repairs some damage in between encounters. It also boosts all other engineering functions.",
				"The Navigating System increases the overall Pilot skill of the ship, making it harder to hit in battle, and making it easier to flee an encounter.",
				"The Targeting System increases the overall Fighter skill of the ship, which increases the amount of damage done to an opponent in battle.",
				"The Cloaking Device can enable your ship to evade detection by an opponent, but only if the Engineer skill of your ship is greater than that of your opponent. It also makes your ship harder to hit in battle.",
				"The Fuel Compactor that you got as a reward for warning Gemulon of the invasion will increase the range of your ship by 3 parsecs.",
				"These extra bays will not be detected during routine police searches. They may be detected if you are arrested and the police perform a more thorough search."
			}
		};
		#endregion

		#region EquipmentTypes
		public static string[]	EquipmentTypes	= new string[]
		{
			"Weapon",
			"Shield",
			"Gadget"
		};
		#endregion

		#region GadgetNames
		public static string[]	GadgetNames	= new string[]
		{
			"5 Extra Cargo Bays",
			"Auto-Repair System",
			"Navigating System",
			"Targeting System",
			"Cloaking Device",
			"Fuel Compactor",
			"5 Hidden Cargo Bays"
		};
		#endregion

		#region GameCompletionTypes
		public static string[]	GameCompletionTypes	= new string[]
		{
			"Was killed",
			"Retired",
			"Claimed moon"
		};
		#endregion

		#region ListStrings
		public static string[]	ListStrings	= new string[]
		{
			"",
			"^1",
			"^1 and ^2",
			"^1, ^2, and ^3",
			"^1, ^2, ^3, and ^4"
		};
		#endregion

		#region NewsEvent
		/* In News Events, the following variables can be used:
		 * ^1 Commander Name
		 * ^2 Current System
		 * ^3 Commander's Ship Type
		 */
		public static string[]	NewsEvent	= new string[]
		{
			"Scientist Adds Alien Artifact to Museum Collection.",
			"Police Trace Orbiting Space Litter to ^1.",
			"Experimental Craft Stolen! Critics Demand Security Review.",
			"Investigators Report Strange Craft.",
			"Spectacular Display as Stolen Ship Destroyed in Fierce Space Battle.",
			"Rumors Continue: Melina Orbitted by Odd Starcraft.",
			"Strange Ship Observed in Regulas Orbit.",
			"Unidentified Ship: A Threat to Zalkon?",
			"Huge Explosion Reported at Research Facility.",
			"Travelers Report Timespace Damage, Warp Problems!",
			"Scientists Cancel High-profile Test! Committee to Investigate Design.",
			"Travelers Claim Sighting of Ship Materializing in Orbit!",
			"Editorial: Who Will Warn Gemulon?",
			"Alien Invasion Devastates Planet!",
			"Invasion Imminent! Plans in Place to Repel Hostile Invaders.",
			"Thug Assaults Captain Ahab!",
			"Destruction of Captain Ahab's Ship Causes Anger!",
			"Captain Conrad Comes Under Attack By Criminal!",
			"Captain Conrad's Ship Destroyed by Villain!",
			"Famed Captain Huie Attacked by Brigand!",
			"Citizens Mourn Destruction of Captain Huie's Ship!",
			"Editorial: We Must Help Japori!",
			"Disease Antidotes Arrive! Health Officials Optimistic.",
			"Ambassador Jarek Returns from Crisis.",
			"Security Scandal: Test Craft Confirmed Stolen.",
			"Wormhole Traffic Delayed as Stolen Craft Destroyed.",
			"Wormhole Travelers Harassed by Unusual Ship!",
			"Space Monster Threatens Homeworld!",
			"Hero Slays Space Monster! Parade, Honors Planned for Today.",
			"Notorious Criminal Jonathan Wild Arrested!",
			"Rumors Suggest Known Criminal J. Wild May Come to Kravat!",
			"Priceless collector's item stolen from home of Geurge Locas!",
			"Space Corps follows ^3 with alleged stolen sculpture to ^2.",
			"Member of Royal Family kidnapped!",
			"Aggressive Ship Seen in Orbit Around Centauri",
			"Dangerous Scorpion Damages Several Other Ships Near Inthara",
			"Kidnappers Holding Out at Qonos",
			"Scorpion Defeated! Kidnapped Member of Galvon Royal Family Freed!",
			"Beloved Royal Returns Home!"
		};
		#endregion

		#region NewsHeadlines
		public static string[][]	NewsHeadlines	= new string[][]
		{
			new string[] { "Riots, Looting Mar Factional Negotiations.", "Communities Seek Consensus.", "Successful Bakunin Day Rally!", "Major Faction Conflict Expected for the Weekend!" },
			new string[] { "Editorial: Taxes Too High!", "Market Indices Read Record Levels!", "Corporate Profits Up!", "Restrictions on Corporate Freedom Abolished by Courts!" },
			new string[] { "Party Reports Productivity Increase.", "Counter-Revolutionary Bureaucrats Purged from Party!", "Party: Bold New Future Predicted!", "Politburo Approves New 5-Year Plan!" },
			new string[] { "States Dispute Natural Resource Rights!", "States Denied Federal Funds over Local Laws!", "Southern States Resist Federal Taxation for Capital Projects!", "States Request Federal Intervention in Citrus Conflict!" },
			new string[] { "Robot Shortages Predicted for Q4.", "Profitable Quarter Predicted.", "CEO: Corporate Rebranding Progressing.", "Advertising Budgets to Increase." },
			new string[] { "Olympics: Software Beats Wetware in All Events!", "New Network Protocols To Be Deployed.", "Storage Banks to be Upgraded!", "System Backup Rescheduled." },
			new string[] { "Local Elections on Schedule!", "Polls: Voter Satisfaction High!", "Campaign Spending Aids Economy!", "Police, Politicians Vow Improvements." },
			new string[] { "New Palace Planned; Taxes Increase.", "Future Presents More Opportunities for Sacrifice!", "Insurrection Crushed: Rebels Executed!", "Police Powers to Increase!" },
			new string[] { "Drug Smugglers Sentenced to Death!", "Aliens Required to Carry Visible Identification at All Times!", "Foreign Sabotage Suspected.", "Stricter Immigration Laws Installed." },
			new string[] { "Farmers Drafted to Defend Lord's Castle!", "Report: Kingdoms Near Flashpoint!", "Baron Ignores Ultimatum!", "War of Succession Threatens!" },
			new string[] { "Court-Martials Up 2% This Year.", "Editorial: Why Wait to Invade?", "HQ: Invasion Plans Reviewed.", "Weapons Research Increases Kill-Ratio!" },
			new string[] { "King to Attend Celebrations.", "Queen's Birthday Celebration Ends in Riots!", "King Commissions New Artworks.", "Prince Exiled for Palace Plot!" },
			new string[] { "Dialog Averts Eastern Conflict!", "Universal Peace: Is it Possible?", "Editorial: Life in Harmony.", "Polls: Happiness Quotient High!" },
			new string[] { "Government Promises Increased Welfare Benefits!", "State Denies Food Rationing Required to Prevent Famine.", "'Welfare Actually Boosts Economy,' Minister Says.", "Hoarder Lynched by Angry Mob!" },
			new string[] { "Millions at Peace.", "Sun Rises.", "Countless Hearts Awaken.", "Serenity Reigns." },
			new string[] { "New Processor Hits 10 ZettaHerz!", "Nanobot Output Exceeds Expectation.", "Last Human Judge Retires.", "Software Bug Causes Mass Confusion." },
			new string[] { "High Priest to Hold Special Services.", "Temple Restoration Fund at 81%.", "Sacred Texts on Public Display.", "Dozen Blasphemers Excommunicated!" }
		};
		#endregion

		#region NewsMastheads
		public static string[][]	NewsMastheads		= new string[][]
		{
			new string[] { "The ^1 Arsenal", "The Grassroot", "Kick It!" },
			new string[] { "The Objectivist", "The ^1 Market", "The Invisible Hand" },
			new string[] { "The Daily Worker", "The People's Voice", "The ^1 Proletariat" },
			new string[] { "Planet News", "The ^1 Times", "Interstate Update" },
			new string[] { "^1 Memo", "News From The Board", "Status Report" },
			new string[] { "Pulses", "Binary Stream", "The System Clock" },
			new string[] { "The Daily Planet", "The ^1 Majority", "Unanimity" },
			new string[] { "The Command", "Leader's Voice", "The ^1 Mandate" },
			new string[] { "State Tribune", "Motherland News", "Homeland Report" },
			new string[] { "News from the Keep", "The Town Crier", "The ^1 Herald" },
			new string[] { "General Report", "^1 Dispatch", "The ^1 Sentry" },
			new string[] { "Royal Times", "The Loyal Subject", "The Fanfare" },
			new string[] { "Pax Humani", "Principle", "The ^1 Chorus" },
			new string[] { "All for One", "Brotherhood", "The People's Syndicate" },
			new string[] { "The Daily Koan", "Haiku", "One Hand Clapping" },
			new string[] { "The Future", "Hardware Dispatch", "TechNews" },
			new string[] { "The Spiritual Advisor", "Church Tidings", "The Temple Tribune" }
		};
		#endregion

		#region NewsPoliceRecordHero
		public static string[]	NewsPoliceRecordHero	= new string[]
		{
			"Locals Welcome Visiting Hero ^1!",
			"Famed Hero ^1 to Visit System!",
			"Large Turnout At Spaceport to Welcome ^1!"
		};
		#endregion

		#region NewsPoliceRecordPsychopath
		public static string[]	NewsPoliceRecordPsychopath	= new string[]
		{
			"Police Warning: ^1 Will Dock At ^2!",
			"Notorious Criminal ^1 Sighted in ^2!",
			"Locals Rally to Deny Spaceport Access to ^1!",
			"Terror Strikes Locals on Arrival of ^1!"
		};
		#endregion

		#region NewsPressureExternal
		public static string[]	NewsPressureExternal	= new string[]
		{
			"Reports of ^1 in the ^2 System.",
			"News of ^1 in the ^2 System.",
			"New Rumors of ^1 in the ^2 System.",
			"Sources report ^1 in the ^2 System.",
			"Notice: ^1 in the ^2 System.",
			"Evidence Suggests ^1 in the ^2 System."
		};
		#endregion

		#region NewsPressureExternalPressures
		public static string[]	NewsPressureExternalPressures	= new string[]
		{
			"",
			"Strife and War",
			"Plague Outbreaks",
			"Severe Drought",
			"Terrible Boredom",
			"Cold Weather",
			"Crop Failures",
			"Labor Shortages"
		};
		#endregion

		#region NewsPressureInternal
		public static string[]	NewsPressureInternal	= new string[]
		{
			"",
			"War News: Offensives Continue!",
			"Plague Spreads! Outlook Grim.",
			"No Rain in Sight!",
			"Editors: Won't Someone Entertain Us?",
			"Cold Snap Continues!",
			"Serious Crop Failure! Must We Ration?",
			"Jobless Rate at All-Time Low!"
		};
		#endregion

		#region PoliceRecordNames
		public static string[]	PoliceRecordNames	= new string[]
		{
			"Psychopath",
			"Villain",
			"Criminal",
			"Crook",
			"Dubious",
			"Clean",
			"Lawful",
			"Trusted",
			"Liked",
			"Hero"
		};
		#endregion

		#region PoliticalSystemNames
		public static string[]	PoliticalSystemNames	= new string[]
		{
			"Anarchy",
			"Capitalist State",
			"Communist State",
			"Confederacy",
			"Corporate State",
			"Cybernetic State",
			"Democracy",
			"Dictatorship",
			"Fascist State",
			"Feudal State",
			"Military State",
			"Monarchy",
			"Pacifist State",
			"Socialist State",
			"State of Satori",
			"Technocracy",
			"Theocracy"
		};
		#endregion

		#region ReputationNames
		public static string[]	ReputationNames	= new string[]
		{
			"Harmless",
			"Mostly harmless",
			"Poor",
			"Average",
			"Above average",
			"Competent",
			"Dangerous",
			"Deadly",
			"Elite"
		};
		#endregion

		#region ShieldNames
		public static string[]	ShieldNames	= new string[]
		{
			"Energy Shield",
			"Reflective Shield",
			"Lightning Shield"
		};
		#endregion

		#region ShipNames
		public static string[]	ShipNames	= new string[]
		{
			"Flea",
			"Gnat",
			"Firefly",
			"Mosquito",
			"Bumblebee",
			"Beetle",
			"Hornet",
			"Grasshopper",
			"Termite",
			"Wasp",
			"Space Monster",
			"Dragonfly",
			"Mantis",
			"Scarab",
			"Bottle",
			ShipNameCustomShip,
			"Scorpion"
		};
		#endregion

		#region ShipyardEngineers
		public static string[]	ShipyardEngineers	= new string[]
		{
			"Wedge",
			"Luke",
			"Lando",
			"Mara",
			"Obi-Wan"
	};
		#endregion

		#region ShipyardNames
		public static string[]	ShipyardNames	= new string[]
		{
			"Corellian Engineering",
			"Incom Corporation",
			"Kuat Drive Yards",
			"Sienar Fleet Systems",
			"Sorosuub Engineering"
		};
		#endregion

		#region ShipyardSkillDescriptions
		public static string[]	ShipyardSkillDescriptions	= new string[]
		{
			"All ships constructed at this shipyard use 2 fewer units per crew quarter.",
			"All ships constructed at this shipyard have 2 extra base fuel tanks.",
			"All ships constructed at this shipyard have the hull points increment by 5 more than usual.",
			"All ships constructed at this shipyard get shield slots for 2 fewer units.",
			"All ships constructed at this shipyard get weapon slots for 2 fewer units."
		};
		#endregion

		#region ShipyardSkills
		public static string[]	ShipyardSkills	= new string[]
		{
			"Crew Quartering",
			"Fuel Efficienty",
			"Hull Strength",
			"Shielding",
			"Weaponry"
		};
		#endregion

		#region Sizes
		public static string[]	Sizes	= new string[]
		{
			"Tiny",
			"Small",
			"Medium",
			"Large",
			"Huge",
			"Gargantuan"
		};
		#endregion

		#region SpecialEventStrings
		public static string[]	SpecialEventStrings	= new string[]
		{
			"This alien artifact should be delivered to professor Berger, who is currently traveling. You can probably find him at a hi-tech solar system. The alien race which produced this artifact seems keen on getting it back, however, and may hinder the carrier. Are you, for a price, willing to deliver it?",
			"This is professor Berger. I thank you for delivering the alien artifact to me. I hope the aliens weren't too much of a nuisance. I have transferred 20000 credits to your account, which I assume compensates for your troubles.",
			"A trader in second-hand goods offers you 3 sealed cargo canisters for the sum of 1000 credits. It could be a good deal: they could contain robots. Then again, it might just be water. Do you want the canisters?",
			"This is Colonel Jackson of the Space Corps. An experimental ship, code-named \"Dragonfly\", has been stolen. It is equipped with very special, almost indestructible shields. It shouldn't fall into the wrong hands and we will reward you if you destroy it. It has been last seen in the Baratas system.",
			"A small ship of a weird design docked here recently for repairs. The engineer who worked on it said that it had a weak hull, but incredibly strong shields. I heard it took off in the direction of the Melina system.",
			"Hello, Commander. This is Colonel Jackson again. On behalf of the Space Corps, I thank you for your valuable assistance in destroying the Dragonfly. As a reward, we will install one of the experimental shields on your ship. Return here for that when you're ready.",
			"A ship with shields that seemed to be like lightning recently fought many other ships in our system. I have never seen anything like it before. After it left, I heard it went to the Regulas system.",
			"A small ship with shields like I have never seen before was here a few days ago. It destroyed at least ten police ships! Last thing I heard was that it went to the Zalkon system.",
			"Colonel Jackson here. Do you want us to install a lightning shield on your current ship?",
			"A hacker conveys to you that he has cracked the passwords to the galaxy-wide police computer network, and that he can erase your police record for the sum of 5000 credits. Do you want him to do that?",
			"While reviewing the plans for Dr. Fehler's new space-warping drive, Dr. Lowenstam discovered a critical error. If you don't go to Daled and stop the experiment within ten days, the time-space continuum itself could be damaged!",
			"Dr. Fehler can't understand why the experiment failed. But the failure has had a dramatic and disastrous effect on the fabric of space-time itself. It seems that Dr. Fehler won't be getting tenure any time soon... and you may have trouble when you warp!",
			"Upon your warning, Dr. Fehler calls off the experiment. As your  reward, you are given a Portable Singularity. This device will, for one time only, instantaneously transport you to any system in the galaxy. The Singularity can be accessed  by clicking the \"J\" (Jump) button on the Galactic Chart.",
			"We received word that aliens will invade Gemulon seven days from now. We know exactly at which coordinates they will arrive, but we can't warn Gemulon because an ion storm disturbs all forms of communication. We need someone, anyone, to deliver this info to Gemulon within six days.",
			"Do you wish us to install the fuel compactor on your current ship? (You need a free gadget slot)",
			"Alas, Gemulon has been invaded by aliens, which has thrown us back to pre-agricultural times. If only we had known the exact coordinates where they first arrived at our system, we might have prevented this tragedy from happening.",
			"This information of the arrival of the alien invasion force allows us to prepare a defense. You have saved our way of life. As a reward, we have a fuel compactor gadget for you, which will increase the travel distance by 3 parsecs for any ship. Return here to get it installed.",
			"A strange disease has invaded the Japori system. We would like you to deliver these ten canisters of special antidote to Japori. Note that, if you accept, ten of your cargo bays will remain in use on your way to Japori. Do you accept this mission?",
			"Thank you for delivering the medicine to us. We don't have any money to reward you, but we do have an alien fast-learning machine with which we will increase your skills.",
			"A recent change in the political climate of this solar system has forced Ambassador Jarek to flee back to his home system, Devidia. Would you be willing to give him a lift?",
			"Ambassador Jarek is very grateful to you for delivering him back to Devidia. As a reward, he gives you an experimental handheld haggling computer, which allows you to gain larger discounts when purchasing goods and equipment.",
			"You are lucky! While docking on the space port, you receive a message that you won 1000 credits in a lottery. The prize had been added to your account.",
			"There is a small but habitable moon for sale in the Utopia system, for the very reasonable sum of half a million credits. If you accept it, you can retire to it and live a peaceful, happy, and wealthy life. Do you wish to buy it?",
			"Welcome to the Utopia system. Your own moon is available for you to retire to it, if you feel inclined to do that. Are you ready to retire and lead a happy, peaceful, and wealthy life?",
			"Galactic criminal Henry Morgan wants this illegal ion reactor delivered to Nix. It's a very dangerous mission! The reactor and its fuel are bulky, taking up 15 bays. Worse, it's not stable -- its resonant energy will weaken your shields and hull strength while it's aboard your ship. Are you willing to deliver it?",
			"Henry Morgan takes delivery of the reactor with great glee. His men immediately set about stabilizing the fuel system. As a reward, Morgan offers you a special, high-powered laser that he designed. Return with an empty weapon slot when you want them to install it.",
			"Morgan's technicians are standing by with something that looks a lot like a military laser -- if you ignore the additional cooling vents and anodized ducts. Do you want them to install Morgan's special laser?",
			"Captain Renwick developed a new organic hull material for his ship which cannot be damaged except by Pulse lasers. While he was celebrating this success, pirates boarded and stole the craft, which they have named the Scarab. Rumors suggest it's being hidden at the exit to a wormhole. Destroy the ship for a reward!",
			"Space Corps is indebted to you for destroying the Scarab and the pirates who stole it. As a reward, we can have Captain Renwick upgrade the hull of your ship. Note that his upgrades won't be transferable if you buy a new ship! Come back with the ship you wish to upgrade.",
			"The organic hull used in the Scarab is still not ready for day-to-day use. But Captain Renwick can certainly upgrade your hull with some of his retrofit technology. It's light stuff, and won't reduce your ship's range. Should he upgrade your ship?",
			"An alien with a fast-learning machine offers to increase one of your skills for the reasonable sum of 3000 credits. You won't be able to pick that skill, though. Do you accept his offer?",
			"A space monster has invaded the Acamar system and is disturbing the trade routes. You'll be rewarded handsomely if you manage to destroy it.",
			"We thank you for destroying the space monster that circled our system for so long. Please accept 15000 credits as reward for your heroic deed.",
			"A merchant prince offers you a very special and wondrous item for the sum of 1000 credits. Do you accept?",
			"An eccentric alien billionaire wants to buy your collection of tribbles and offers half a credit for each of them. Do you accept his offer?",
			"Law Enforcement is closing in on notorious criminal kingpin Jonathan Wild. He would reward you handsomely for smuggling him home to Kravat. You'd have to avoid capture by the Police on the way. Are you willing to give him a berth?",
			"Jonathan Wild is most grateful to you for spiriting him to safety. As a reward, he has one of his Cyber Criminals hack into the Police Database, and clean up your record. He also offers you the opportunity to take his talented nephew Zeethibal along as a Mercenary with no pay.",
			"A hooded figure approaches you and asks if you'd be willing to deliver some recently aquired merchandise to Endor. He's holding a small sculpture of a man holding some kind of light sword that you strongly suspect was stolen. It appears to be made of plastic and not very valuable. \"I'll pay you 2,000 credits now, plus 15,000 on delivery,\" the figure says. After seeing the look on your face he adds, \"It's a collector's item. Will you deliver it or not?\"",
			"Yet another dark, hooded figure approaches. \"Do you have the action fig- umm, the sculpture?\" You hand it over and hear what sounds very much like a giggle from under the hood. \"I know you were promised 15,000 credits on delivery, but I'm strapped for cash right now. However, I have something better for you. I have an acquaintance who can install hidden compartments in your ship.\" Return with an empty gadget slot when you're ready to have it installed.",
			"You're taken to a warehouse and whisked through the door. A grubby alien of some humanoid species - you're not sure which one - approaches. \"So you're the being who needs Hidden Compartments. Should I install them in your ship?\" (It requires a free gadget slot.)",
			"A member of the Royal Family of Galvon has been kidnapped! Princess Ziyal was abducted by men while travelling across the planet. They escaped in a hi-tech ship called the Scorpion. Please rescue her! (You'll need to equip your ship with disruptors to be able to defeat the Scorpion without destroying it.) A ship bristling with weapons was blasting out of the system. It's trajectory before going to warp indicates that its destination was Centauri.",
			"A ship had its shields upgraded to Lighting Shields just two days ago. A shipyard worker overheard one of the crew saying they were headed to Inthara.",
			"Just yesterday a ship was seen in docking bay 327. A trader sold goods to a member of the crew, who was a native of Qonos. It's possible that's where they were going next.",
			"The Galvonian Ambassador to Qonos approaches you. The Princess needs a ride home. Will you take her? I don't think she'll feel safe with anyone else.",
			"His Majesty's Shipyard: Do you want us to install a quantum disruptor on your current ship?",
			"The King and Queen are extremely grateful to you for returning their daughter to them. The King says, \"Ziyal is priceless to us, but we feel we must offer you something as a reward. Visit my shipyard captain and he'll install one of our new Quantum Disruptors.\""
		};
		#endregion

		#region SpecialEventTitles
		public static string[]	SpecialEventTitles	= new string[]
		{
			"Alien Artifact",
			"Artifact Delivery",
			"Cargo For Sale",
			"Dragonfly",
			"Dragonfly Destroyed",
			"Weird Ship",
			"Lightning Ship",
			"Lightning Shield",
			"Strange Ship",
			"Erase Record",
			"Dangerous Experiment",
			"Experiment Failed",
			"Disaster Averted",
			"Alien Invasion",
			"Fuel Compactor",
			"Gemulon Invaded",
			"Gemulon Rescued",
			"Japori Disease",
			"Medicine Delivery",
			"Ambassador Jarek",
			"Jarek Gets Out",
			"Lottery Winner",
			"Moon For Sale",
			"Retirement",
			"Morgan's Reactor",
			"Reactor Delivered",
			"Install Morgan's Laser",
			"Scarab Stolen",
			"Scarab Destroyed",
			"Upgrade Hull",
			"Skill Increase",
			"Space Monster",
			"Monster Killed",
			"Merchant Prince",
			"Tribble Buyer",
			"Jonathan Wild",
			"Wild Gets Out",
			"Stolen Sculpture",
			"Sculpture Delivered",
			"Install Hidden Compartments",
			"Kidnapped",
			"Aggressive Ship",
			"Dangerous Scorpion",
			"Royal Rescue",
			"Quantum Disruptor",
			"Royal Return"
		};
		#endregion

		#region SpecialResources
		public static string[]	SpecialResources	= new string[]
		{
			"Nothing Special",
			"Mineral Rich",
			"Mineral Poor",
			"Desert",
			"Sweetwater Oceans",
			"Rich Soil",
			"Poor Soil",
			"Rich Fauna",
			"Lifeless",
			"Weird Mushrooms",
			"Special Herbs",
			"Artistic Populace",
			"Warlike Populace"
		};
		#endregion

		// *************************************************************************
		// Many of these names are from Star Trek: The Next Generation, or are small changes
		// to names of this series. A few have different origins.
		// JAF - Except where noted these comments are the previous author's.
		// *************************************************************************
		#region SystemNames
		public static string[]	SystemNames	= new string[]
		{
			"Acamar",			// JAF - TNG "The Vengeance Factor (Acamar III)"
			"Adahn",			// The alternate personality for The Nameless One in "Planescape: Torment"
			"Aldea",			// JAF - TNG "When the Bough Breaks"
			"Andevian",		// JAF - ST Andoria?
			"Antedi",			// JAF - TNG "Manhunt" (Antede III)
			"Balosnee",
			"Baratas",		// JAF - TNG "The Emissary" (Barradas III)
			"Brax",				// One of the heroes in Master of Magic
			"Bretel",			// This is a Dutch device for keeping your pants up.
			"Calondia",		// JAF - TNG "The Price" (Caldonia)
			"Campor",			// JAF - TNG "Bloodlines" (Camor V) or DS9 "Defiant" (Campa III)
			"Capelle",		// The city I lived in while programming this game
			"Carzon",			// JAF - Character from DS9 (Kurzon)?
			"Castor",			// A Greek demi-god
			"Cestus",			// JAF - several ST episodes (Cestus III)
			"Cheron",			// JAF - TOS "Let That Be Your Last Battlefield"
			"Courteney",	// After Courteney Cox...
			"Daled",			// JAF - TNG "The Dauphin" (Daled IV)
			"Damast",
			"Davlos",			// JAF - DS9 "Time's Orphan" (Davlos Prime) or DS9 "Visionary" (Davlos III)
			"Deneb",			// JAF - TOS "Wolf in the Fold" (Deneb II) or TOS "Where No Man Has Gone Before" and TNG "Encounter at Farpoint" (Deneb IV)
			"Deneva",			// JAF - TOS "Operation -- Annihilate!"
			"Devidia",		// JAF - TNG "Time's Arrow" (Devidia II)
			"Draylon",		// JAF - DS9 "Sanctuary" (Draylon II)
			"Drema",			// JAF - TNG "Pen Pals" (Drema IV)
			"Endor",			// JAF - From Return of the Jedi
			"Esmee",			// One of the witches in Pratchett's Discworld
			"Exo",				// JAF - TOS "What Are Little Girls Made Of?" (Exo III)
			"Ferris",			// Iron
			"Festen",			// A great Scandinavian movie
			"Fourmi",			// An ant, in French
			"Frolix",			// A solar system in one of Philip K. Dick's novels
			"Gemulon",		// JAF - TNG "Final Mission" (Gamalon V) or DS9 "Paradise" (Germulon V)
			"Guinifer",		// One way of writing the name of king Arthur's wife
			"Hades",			// The underworld
			"Hamlet",			// From Shakespeare
			"Helena",			// Of Troy
			"Hulst",			// A Dutch plant
			"Iodine",			// An element
			"Iralius",
			"Janus",			// A seldom encountered Dutch boy's name
			"Japori",			// JAF - DS9 "Improbable Cause" (Jaforay II)?
			"Jarada",			// JAF - DS9 "Progress" (Jarido)?
			"Jason",			// A Greek hero
			"Kaylon",			// JAF - TNG "Half a Life" (Kalon II)
			"Khefka",			// JAF - DS9 "Invasive Procedures" (Kafka IV)
			"Kira",				// My dog's name
			"Klaatu",			// From a classic SF movie
			"Klaestron",	// JAF - DS9 "Dax" (Klaestron IV)
			"Korma",			// An Indian sauce
			"Kravat",			// Interesting spelling of the French word for "tie"
			"Krios",			// JAF - TNG "The Mind's Eye"
			"Laertes",		// A king in a Greek tragedy
			"Largo",			// JAF - DS9 "Babel" (Largo V)
			"Lave",				// The starting system in Elite
			"Ligon",			// JAF - TNG "Code of Honor" (Ligon II)
			"Lowry",			// The name of the "hero" in Terry Gilliam's "Brazil"
			"Magrat",			// The second of the witches in Pratchett's Discworld
			"Malcoria",		// JAF - "Star Trek: First Contact" (Malkor III)?
			"Melina",			// JAF - TNG "Silicon Avatar" (Malona IV)?
			"Mentar",			// The Psilon home system in Master of Orion
			"Merik",			// JAF - TOS "The Cloud Minders" (Merak II)
			"Mintaka",		// JAF - TNG "Who Watches the Watchers" (Mintaka III)
			"Montor",			// A city in Ultima III and Ultima VII part 2
			"Mordan",			// JAF - TNG "Too Short a Season" (Mordan IV)
			"Myrthe",			// The name of my daughter
			"Nelvana",		// JAF - TNG "The Defector" (Nelvana III)
			"Nix",				// An interesting spelling of a word meaning "nothing" in Dutch
			"Nyle",				// An interesting spelling of the great river
			"Odet",
			"Og",					// The last of the witches in Pratchett's Discworld
			"Omega",			// The end of it all
			"Omphalos",		// Greek for navel
			"Orias",
			"Othello",		// From Shakespeare
			"Parade",			// This word means the same in Dutch and in English
			"Penthara",		// JAF - TNG "A Matter of Time" (Penthara IV)
			"Picard",			// The enigmatic captain from ST:TNG
			"Pollux",			// Brother of Castor
			"Quator",			// JAF - TNG "Unification: Part I" (Qualar II)?
			"Rakhar",			// JAF - DS9 "Vortex"
			"Ran",				// A film by Akira Kurosawa
			"Regulas",		// JAF - "Star Trek II: The Wrath of Khan" (Regula) or DS9 "Fascination" (Regulus III) or TOS "Amok Time" (Regulus V)
			"Relva",			// JAF - TNG "Coming of Age" (Relva VII)
			"Rhymus",
			"Rochani",		// JAF - DS9 "Dramatis Personae" (Rochanie III)
			"Rubicum",		// The river Ceasar crossed to get into Rome
			"Rutia",			// JAF - TNG "The High Ground" (Ruteeya IV)
			"Sarpeidon",	// JAF - DS9 "Tacking into the Wind" (Sarpeidon V) or TOS "All Our Yesterdays" (Sarpeidon)
			"Sefalla",
			"Seltrice",
			"Sigma",
			"Sol",				// That's our own solar system
			"Somari",
			"Stakoron",
			"Styris",			// JAF - TNG "Code of Honor" (Styrus IV)
			"Talani",			// JAF - DS9 "Armageddon Game" (T'Lani III and T'Lani Prime)
			"Tamus",
			"Tantalos",		// A king from a Greek tragedy
			"Tanuga",
			"Tarchannen",
			"Terosa",			// JAF - DS9 "Second Sight" (Terosa Prime)
			"Thera",			// A seldom encountered Dutch girl's name
			"Titan",			// The largest moon of Jupiter
			"Torin",			// A hero from Master of Magic
			"Triacus",		// JAF - TOS "And the Children Shall Lead"
			"Turkana",		// JAF - TNG "Legacy" (Turkana IV)
			"Tyrus",
			"Umberlee",		// A god from AD&D, which has a prominent role in Baldur's Gate
			"Utopia",			// The ultimate goal
			"Vadera",
			"Vagra",			// JAF - TNG "Skin of Evil" (Vagra II)
			"Vandor",			// JAF - TNG "We'll Always Have Paris" (Vando VI)?
			"Ventax",			// JAF - TNG "Devil's Due" (Ventax II)
			"Xenon",
			"Xerxes",			// A Greek hero
			"Yew",				// A city which is in almost all of the Ultima games
			"Yojimbo",		// A film by Akira Kurosawa
			"Zalkon",			// TNG "Transfigurations" (Zalcon)
			"Zuul",				// From the first Ghostbusters movie

			// The rest are systems I added - JAF
			"Centauri",		// As in Alpha Centauri - the closest star outside our solar system 
			"Galvon",			// Star Trek: The Next Generation "Data's Day"
			"Inthara",		// Star Trek: Voyager "Retrospect"
			"Meridian",		// Star Trek: Deep Space Nine "Meridian"
			"Qonos",			// Star Trek - Klinon Homeworld (QonoS - Kronos)
			"Rae",				// My wife's middle name
			"Weytahn",		// Star Trek: Enterprise "Cease Fire"
			"Zonama"			// From the Star Wars: New Jedi Order series (and Rogue Planet)
		};
		#endregion

		#region SystemPressures
		public static string[]	SystemPressures	= new string[]
		{
			"under no particular pressure",		// Uneventful
			"at war",													// Ore and Weapons in demand
			"ravaged by a plague",						// Medicine in demand
			"suffering from a drought",				// Water in demand
			"suffering from extreme boredom",	// Games and Narcotics in demand
			"suffering from a cold spell",		// Furs in demand
			"suffering from a crop failure",	// Food in demand
			"lacking enough workers"					// Machinery and Robots in demand
		};
		#endregion

		#region TechLevelNames
		public static string[]	TechLevelNames	= new string[]
		{
			"Pre-Agricultural",
			"Agricultural",
			"Medieval",
			"Renaissance",
			"Early Industrial",
			"Industrial",
			"Post-Industrial",
			"Hi-Tech"
		};
		#endregion

		#region TradeItemNames
		public static string[]	TradeItemNames	= new string[]
		{
			"Water",
			"Furs",
			"Food",
			"Ore",
			"Games",
			"Firearms",
			"Medicine",
			"Machines",
			"Narcotics",
			"Robots"
		};
		#endregion

		#region VeryRareEncounters
		public static string[]	VeryRareEncounters	= new string[]
		{
			"Marie Celeste",
			"Captain Ahab",
			"Captain Conrad",
			"Captain Huie",
			"Dated Tonic",
			"Good Tonic"
		};
		#endregion

		#region WeaponNames
		public static string[]	WeaponNames	= new string[]
		{
			"Pulse Laser",
			"Beam Laser",
			"Military Laser",
			"Morgan's Laser",
			"Photon Disruptor",
			"Quantum Disruptor"
		};
		#endregion

		#endregion

		#region Commented-Out Strings
/*
		public static string	WarpString											= "Tap the system you wish to warp to. The game will show you what is known about that system, or the average price list for that system (depending on your preferences and what you viewed last). You can warp from that screen.\r\n\r\nOn color Palms, systems you have visited are blue, other systems are green, and wormholes are reddish. On grayscale Palms, visited systems are slightly lighter than other systems, and wormholes are very light. On monochrome Palms, systems you have already visited are shaded, other systems are unshaded, and wormholes are black.\r\n\r\nThe wide circle shows the range you can fly on your current fuel tanks. If it seems a bit small, you should visit the Ship Yard to refill your tanks.\r\n\r\n A wormhole is a hole into the space-time continuum which leads somewhere else in the galaxy. Before you can warp through the wormhole, you must first fly to the system that owns it, which is displayed to the left of it. From that system, you can tap the wormhole and warp immediately to the system at the other side.\r\n\r\nIf you are Tracking a system (which you can do from the Galactic Chart), there will be an arrow from your current system in the direction of the system being tracked, and the distance will be displayed at the top of the screen.";
		public static string	ExecuteWarpString								= "This screen shows information on the system you have selected. If the system is reachable by a wormhole, it says so next to \"Distance\". To warp through a wormhole you have to pay wormhole taxes, which depend on the type of your ship. The \"Current Costs\" item indicates what you have to pay your mercenaries, the current system as wormhole tax, the bank as interest on a loan and the bank as insurance, before you can warp. \r\n\r\nIf the system isn't out of range, you can warp to it by tapping the Warp button. If the system is out of range, or if you decide you don't want to warp, you can get to other options through the menu, or you can immediately return to the Short Range Chart by tapping the appropriate button. You can also view the average price list for the target system by tapping the Average Price List button.\r\n\r\nThe arrows in the top right area of the screen can be used to scroll through the systems which are within range.\r\n";
		public static string	GalacticChartString							= "Tapping a system on the galactic chart shows information on that system at the bottom of the screen. Tapping on a wormhole will display a line indicating the system to which the wormhole goes, as well as the name of both systems.\r\n\r\n Tapping a system twice will cause that system to be tracked, which will be indicated with an \"X\". On the Short-Range chart, an arrow will indicate the direction to the tracked system. Tapping on a tracked system will turn off tracking.\r\n\r\n On color Palms, systems you have already visited are blue, unvisited systems are green, and wormholes are red. On grayscale Palms, visited systems are slightly lighter than unvisited systems, and wormholes are very light. On monochrome Palms, systems you have already visited are black, unvisited systems are \"open\" circles, and wormholes are small crosses.\r\n\r\n You can alphabetically scroll through the systems by using the PalmPilot Scroll button.\r\n\r\nThe Find button allows you to enter a system name, on which the chart will then focus; you also have the option to track the system.";
		public static string	MainString											= "While you are docked at a system, you can use the menu to access functions to buy and sell cargo, equip your ship or sell equipment, visit the ship yard to buy fuel, make repairs, or buy a new ship, get information on the system where you are currently docked and neighbouring systems, visit the bank and warp to another system by using the short range chart.";
		public static string	NewCommanderString							= "In the New Commander screen you can set your name, and set skill values. There are four skills, each with a value between 1 and 10 points, 10 being the best. You can divide 20 points over the skills, though each skill must get at least 1 point. The pilot skill determines how well you handle your ship, which is especially important to escape fights and to dodge shots. The fighter skill influences how well you can attack other ships, which is especially important to score hits on other ships. The trader skill influences your profit margins. The engineer skill determines how well you manage to keep your ship in shape, which is especially important to keep your shields up and hull intact. The engineer skill is also important for tuning a cloaking device, when you have bought one. Finally, a good engineer may influence the effectiveness of your weapons.";
		public static string	SystemInformationString					= "This screen shows information on the system where you are currently docked. You can click on the News button to buy a newspaper, which will have headlines about local and nearby events. If there is a Special button visible, tap it to get a special offer, only available in this system. If there is a mercenary available in this system, a Mercenary For Hire button is visible. Tapping it will take you to the Personnel Roster.";
		public static string	ConfirmNewString								= "Starting a new game will erase all data on your current game.";
		public static string	MoreSkillPointsString						= "You have 20 skill points to divide over the four commander skills. You should award them all.";
		public static string	BuyCargoString									= "Use this screen to buy cargo. The leftmost column shows quantities available. The second column shows the name of the goods. The fourth column shows the price. To buy goods, either tap the quantity cell, after which you can specify how much you want to buy, or tap the \"Max\" cell, which will automatically buy the maximum number of items, limited by the quantity available, the number of empty cargo holds you have, and your cash position. If you have \"Reserve Money\" checked in the Options menu, the game will reserve at least enough money to pay for insurance and mercenaries.";
		public static string	SellCargoString									= "Use this screen to sell cargo. The leftmost column shows quantities you have stored in your cargo holds. The second column shows the name of the goods. If the name of the goods is in bold, it means you can sell these goods with a profit. The fourth column shows the price you can get for your goods. To sell, either tap the quantity cell, after which you can specify how much you want to sell, or tap the \"All\" cell, which will automatically sell all goods you own of the selected item.\r\n\r\nIf there is no trade in a particular item, you can dump it using the \"Dump\" button. You will be charged a disposal fee per item dumped.\r\n\r\nNote that criminals receive less for their goods, since they can't sell goods directly: they have to use an intermediary whom they have to pay 10%. This is already accounted for in the quoted price, but it's good to know that you could have made a better sale if you had only been a bit more careful. The Commander Status screen shows whether or not you are considered to be a criminal.";
		public static string	NothingAvailableString					= "On the Buy Cargo screen, the button to the left of the goods displays the amount available. If the amount is zero, none of these goods are available.";
		public static string	CantAffordString								= "At the bottom of the Buy Cargo screen, you see the credits you have available. You don't seem to have enough to buy at least one of the selected items. If you have \"Reserve Money\" checked in the Options menu, the game will reserve at least enough money to pay for insurance and mercenaries.";
		public static string	NoEmptyBaysString								= "On the screen where you can get the cargo, you see the number of cargo bays that are full, and the total number of cargo bays available. If these are equal, you don't have room for more goods. If in the options menu you have specified that you want to reserve some cargo bays for storing goods you acquire during flight, this is taken into account.";
		public static string	AmountToBuyString								= "Specify the amount to buy and tap the OK button. If you specify more than there is available, or than you can afford, or than your cargo bays can hold, the maximum possible amount will be bought. The same goes if you tap the All button. If you don't want to buy anything, tap the None button.";
		public static string	NothingForSaleString						= "On the Sell Cargo screen, the leftmost button shows the number of cargo bays you have which contain these goods. If that amount is zero, you can't sell anything.";
		public static string	AmountToSellString							= "If you are selling items, specify the amount to sell and tap the OK button. If you specify more than you have in your cargo bays, the maximum possible amount will be sold. The same goes if you tap the All button. If you don't want to sell anything, tap the None button.\r\n\r\nSimilarly, if you are dumping items, specify the amount to sell and tap the OK button. If you specify more than you have in your cargo bays, all of them will be dumped. The same goes if you tap the All button. If you don't want to dump anything, tap the None button.";
		public static string	ShipYardString									= "At the Ship Yard, you can buy fuel, get your hull repaired, buy an escape pod, or even buy a new ship. When you buy a new ship, the total worth of your current ship (including equipment and cargo) is subtracted from the price of a new ship.\r\n\r\nAn escape pod will automatically eject you and your crew from your ship when it gets destroyed.\r\n\r\nIf you want to automatically buy a full tank and/or automatically get a full hull repair when you dock at a new system, you can check the appropriate options in the Options menu, available through the game menu.\r\n\r\nWhen buying a new ship or an escape pod, if you have \"Reserve Money\" checked in the Options menu, the game will reserve at least enough money to pay for insurance and mercenaries.";
		public static string	BuyFuelString										= "Enter the amount of credits you wish to spend on fuel and tap OK. If you tap Maximum, as much as needed for a full tank will be spent, up to your total amount of cash. If you tap Nothing, you won't buy fuel.";
		public static string	BuyRepairsString								= "Enter the amount of credits you wish to spend on repairs and tap OK. If you tap Maximum, as much as needed for full repairs will be spent, up to your total amount of cash. If you tap Nothing, you won't buy any repairs.";
		public static string	NotInterestedString							= "Notice that on the Sell Cargo screen, it says \"no trade\" next to these goods. This means that people aren't interested in buying them, either because of their political system, or because their tech level isn't high enough to make use of them.";
		public static string	BuyShipString										= "Information on a ship type you can get buy tapping the Info button to the right of it. Buy a new ship by tapping the corresponding Buy button. The price quoted for the ship takes into account the discount you get for trading in your current ship, including its  equipment and cargo. The ship delivered to you will lack any equipment and cargo. Note that if you are carrying cargo which the current system isn't interested in, you lose that cargo also without receiving any compensation for it.\r\n\r\nIf you have an escape pod it will be transferred to your new ship. Insurance will also be transferred, including your no-claim.\r\n\r\nIf you have \"Reserve Money\" checked in the Options menu, the game will reserve at least enough money to pay for insurance and mercenaries.";
		public static string	TradeShipString									= "If you say Yes, you lose your current ship, including equipment and cargo, and get a brand new ship of the indicated type, without equipment and cargo.";
		public static string	TooManyCrewmembersString				= "The information on a ship will show how many crew quarters it has. If there are enough to hold your current crew, they will simply be transferred to the new ship. Otherwise you have to fire as many of them as needed, before you can buy a new ship.";
		public static string	ShiptypeInfoString							= "The Ship Information screen shows the specs of the selected ship type. You can return to the Buy Ship screen by tapping the button at the bottom of the screen.";
		public static string	CantBuyShipString								= "The ship's price takes into account the trade-in value of your current ship. You have to pay the remaining price with your cash total. If you have \"Reserve Money\" checked in the Options menu, the game will reserve at least enough money to pay for insurance and mercenaries.";
		public static string	BuyEquipmentString							= "Tap the Buy button to the left of a piece of equipment to buy it for the price to the right of it. Note that each ship type can only carry a limited number of items in each equipment category. \r\n\r\nThe three categories are weapons, shields and gadgets. The weapons category contains the three types of lasers, the shields category contains the two types of shields, and the gadget category contains the following gadgets: 1) 5 extra cargo bays; 2)  auto-repair system (which helps your engineering functions); 3) navigating system (which helps you pilot your ship); 4) targeting system (which helps you fighting); and 5) cloaking device (which allows you to travel undetected, unless you attack yourself or your opponent has a better engineer than you).\r\n\r\nIf you have \"Reserve Money\" checked in the Options menu, the game will reserve at least enough money to pay for insurance and mercenaries.";
		public static string	SellEquipmentString							= "To sell a piece of equipment for the price indicated to the right of it, tap the Sell button to the left of it.";
		public static string	CantBuyItemString								= "If you can't pay the price mentioned to the right of an item, you can't get it. If you have \"Reserve Money\" checked in the Options menu, the game will reserve at least enough money to pay for insurance and mercenaries.";
		public static string	NotEnoughSlotsString						= "For each item type, each ship type has only a limited number of slots available. If you really want to buy the specified item, you have to empty a slot of this item type buy selling an item of the same type. Some ships don't have any slots of certain types.";
		public static string	NoMoreOfItemString							= "Except for extra cargo bays, of the available gadgets you only need to buy one: a second one isn't of any use.";
		public static string	ItemNotSoldString								= "Each item is only available in a system which has the technological development needed to produce it.";
		public static string	CargoBaysFullString							= "First you need to sell some trade goods. When you have at least 5 empty bays, you can sell the extra cargo bays.";
		public static string	PersonnelRosterString						= "On the Personnel Roster screen, there are three areas. The upper two are reserved for mercenaries in your service. If you have hired someone, he or she is visible in one of these areas. To fire someone in your service, just tap the corresponding Fire button.\r\n\r\nThe bottom area is reserved for a mercenary who is for hire in the current system. To hire him or her, just tap the Hire button. Note that if you fire someone, he or she will probably decide to return to his or her home system.";
		public static string	NoFreeQuartersString						= "If you hire someone, you must give him or her quarters on your ship. Depending on the type of ship, you can hire zero, one or two mercenaries.";
		public static string	SpecialEventString							= "In a special meeting, you can do something unique to this system. Usually this is a special offer or an assignment. \r\n\r\nIf it is an offer you have to agree to, there are a Yes and a No button visible. Tap Yes to accept the offer, tap No to return to the System Information screen. As long as you don't accept the special offer, it will remain available in this system. \r\n\r\nNote that the special offer \"Moon For Sale\" will allow you to win the game if you accept it.";
		public static string	NotEnoughForEventString					= "If you don't have enough credits to agree to accept an offer, you'll have to wait until you have amassed enough money and then return. If you have \"Reserve Money\" checked in the Options menu, the game will reserve at least enough money to pay for insurance and mercenaries.";
		public static string	MustPayMercenariesString				= "You must pay your mercenaries daily, that is, before you warp to another system. If you don't have the cash, you must either sell something so you have enough cash, or fire the mercenaries you can't pay. Until then, warping is out of the question.";
		public static string	TribblesAteFoodString						= "Alas, tribbles are hungry and fast-multiplying animals. You shouldn't expect to be able to hold them out of your cargo bays. You should find a way to get rid of them.";
		public static string	YouHaveATribbleString						= "The merchant prince sold you a cute, furry tribble. You can see your new acquisition on the Commander Status screen.";
		public static string	BeamOverTribblesString					= "No more tribbles!";
		public static string	SkillIncreaseString							= "On the Commander Status screen you can see your new skill values.";
		public static string	CleanRecordString								= "With a clean police record, the police will usually let you slip by without searching your ship. Also, if you were a criminal before, you can now sell you goods again for full prices.";
		public static string	CommanderStatusString						= "On the Commander Status screen you can examine your skills, your reputation and your total worth. Note that if your police record indicates that you are a criminal or worse, you have to use an intermediary to sell goods, who charges 10 percent of the selling price for his services. The numbers within brackets with the skills are the skill values which take into account mercenaries and equipment on your ship.\r\n\r\nThe Ship button allows you to examine your current ship. The Quests button allows you to see details on the quests you are currently on.";
		public static string	OptionsString										= "\"Always ignore when it is safe\" will fly past encounters where you can safely ignore your opponent. This means you won't encounter any peaceful ships along the way. You also won't see ships which immediately start to flee from you, and neither will you see any ships which ignore you because you have a cloaking device. You can set this option separately for police, pirates,  traders, and traders wanting to make deals in orbit. As long as you play as a peaceful trader, you can check the first three, but you might want to make sure the fourth is unchecked. When you become a bounty hunter, you should uncheck the \"pirates\" one. When you become a pirate, you should uncheck the \"traders\" one. If you want to attack everybody and anybody (in other words, when you are a real evil psychopath), you should uncheck all four.\r\n\r\n\"Get full tank on arrival\", if checked, will automatically get a full tank of fuel when docking at a new system, if, of course, you have enough credits. \r\n\r\n\"Get full hull repair on arrival\" will automatically get your hull repaired to 100% when docking at a new system, if, of course, you have enough credits. \r\n\r\n\"Reserve money for warp costs\" will not spend all your money when buying cargo, equipment or a new ship, but will reserve at least enough to pay your mercenaries and insurance. It won't take into account interest, because your debt will simply increase if you can't pay interest, and it won't take into account wormhole tax, because it's not known whether or not you will fly through a wormhole. It also won't protect you when buying fuel or repairs.\r\n\r\n\"Always go from Chart to Info\", if checked, will always present the target system Info screen when you tap that system on the Short Range Chart. If not checked, the game will remember whether you were last on the Info screen or on the Average Price List, and will go to the screen you last accessed (if you are allowed " +
																														"to go to that screen).\r\n\r\n\"Continuous attack and flight\" automatically executes, once started, an attack or an attempt to flee every second, until either the player chooses a new action, or one of the ships gets destroyed, or one of the ships manages to escape, or the opponent changes his attitude (for instance, switches from attacking to fleeing or surrendering). You can also interrupt the repetition by tapping the \"Int.\" button or by simply selecting another action.\r\n\r\n\"Continue attacking fleeing ship\", if checked, will automatically continue the automatic attack, if it is activated, on a ship that stops attacking you and starts fleeing.\r\n\r\n\"Cargo bays to leave empty\" is the number of cargo bays you want to leave empty when buying trade goods. This is useful if you like to use the \"Max\" button but still would like to leave some bays empty in case you can pick up cargo while flying to another system.\r\n\r\nClick \"Done\" when you're done, or \"More...\" for other options.\r\n\r\n";
		public static string	AveragePricesString							= "This screen shows the average prices you get for goods in the target system. If the trade good is shown in a bold font, it means the average price mentioned here is better than the buying price in the current system. \r\n\r\nNote that these prices do take into account the system size, government and tech level. Special resources (like rich soil) are also taken into account if you know about them. Special situations (like war) are temporary and are therefore not taken into account. \r\n\r\nRemember that criminals can't sell their goods directly, but have to use an intermediary, who keeps 10 percent of the selling price for himself. This is also not taken into account in the calculation of the average prices. \r\n\r\nThe button \"Price Differences\" switches to an overview of the differences between the average prices in the target system and the buying prices in the current system. When price differences are shown, this button is replaced by an \"Absolute Prices\" button, which, if tapped, will switch back to absolute prices.\r\n\r\nThe buttons labeled \"<\" and \">\" can be used to scroll through the systems which are within range.\r\n\r\nTo return to the target system information screen, tap the System Information button and to return to the short range chart, tap the Shot Range Chart button. You can also immediately go into warp by tapping the Warp button.";
		public static string	BankString											= "At the bank you can get a loan, if you are really in need of cash. As long as your police record is at least clean, you can have a loan of at least 1000 credits, more if you are rich yourself. When you don't have a clean police record, the bank will maximally lend you 500 credits.\r\n\r\nWhen your debt is more than the amount the bank is willing to lend you, you won't get a new loan. There is an interest of 10% to be paid daily, which will be subtracted from your cash right before you warp to another system. If you don't have enough cash, this will simply add to your debt. Settle your debts as quickly as possible, because as long as you have debts, you won't be able to buy a new ship or new equipment for your ship.\r\n\r\nAt the bank, you can also buy insurance for your ship. This is only useful if you also have an escape pod on your ship, because the insurance pays out when your ship gets destroyed and you manage to escape in a pod. The cost of the insurance is to be paid daily: 0.25 percent of the trade-in value of your current ship, including its equipment (but excluding cargo). For each day you fly without claim, 1% is subtracted from the amount to be paid. Note that if you stop your insurance, your \"no claim\" returns to zero percent. Also note that if the trade-in value of your ship changes, your insurance costs also change.";
		public static string	YoureInDebtString								= "Before you can buy a new ship or new equipment, you must settle your debts at the bank.";
		public static string	GetLoanString										= "As long as your debt is below the amount the bank is willing to lend you, you can get a loan up to that amount. There is a 10% interest to be paid each day, until you have paid back your loan. The interest will be automatically subtracted from your cash. If you don't have the cash, it will be added to your loan. As long as you are in debt, you can't buy equipment and you can't trade in your ship for a more expensive ship.";
		public static string	PayBackString										= "Pay back your loan by specifying an amount and tapping OK. You will never pay back more than your actual debt.";
		public static string	DebtTooHighString								= "You can't get a loan if your debt exceeds what the bank is willing to lend you.";
		public static string	NoDebtString										= "You don't need to pay back anything if you have no debts. Be happy.";
		public static string	EncounterString									= "When you encounter another ship, your and your opponent's stats are shown at the top of the encounter screen. When in pure text mode (you can set this in the Options menu), you see percentages indicating the hull and shield strength of both ships. When in graphical mode, these stats are visualized. The percentage of a ship that is colored red, indicates how much the hull is weakened. When a ship is colored red completely, its hull is (almost) gone. The shield strength is indicated by the size of the shield that surrounds a ship. Your own ship is shown to the left, and your opponent's ship is shown to the right. The icon in the upper right corner shows who your opponent is: a skull indicates a pirate, a badge indicates a police ship and a coin indicates a trader.\r\n\r\nIn an encounter with another ship, there are several options:\r\n\r\nA trader won't attack you, but if you attack, might fight back, flee, or surrender. If it surrenders, you can steal from its cargo. In a fight with a trader, if it goes bad for you, you might try to flee.\r\n\r\nAn encounter with a pirate goes along the same lines as an encounter with a trader, except that a pirate will probably attack you on sight and will never surrender.\r\n\r\nAn encounter with a police ship is different. They may choose to ignore you, or ask you to submit to inspection. If you are a known criminal, they might attack you on sight. If you submit to inspection and are carrying illegal goods (firearms or narcotics), these goods will be impounded and you will be fined. Your reputation will suffer, but just a little. However, instead of submitting to inspection, you may try to bribe the police. You can also flee from them or attack them, of course, in which case the ensuing fight resembles the fight with a pirate. Fleeing from the police will immediately set your record to \"dubious\", and attacking, of course, will make you a criminal without further ado. " +
																														"Surrendering to the police will cost you a hefty fine and some time in jail.\r\n\r\nIf you check the option \"Automatic attack and flight\" in the Options screen, after you tapped \"Attack\" or \"Flee\" this action will be repeated every second, until the opponent changes his attitude. During that time, a button marked \"Int.\" (for Interrupt) will be shown in the bottom right corner of the Encounter screen. If you tap this button, the repetition will be interrupted. However, it is also possible to simply tap on another button to change actions. To show you that the action is still continuing a blinking spot is shown right next to the \"Int.\" button. \r\n\r\nSometimes you will have a special encounter with another ship.\r\n\r\nIn a special encounter with another ship, there are several options:\r\n\r\nIf you ignore a ship in a special encounter, you will continue on your journey and will have no further interaction with the ship.\r\n\r\nIn a special encounter, you may engage the other ship. While the exact nature of the engagement will vary (depending on the encounter), this will usually present you with some opportunity. You will always have an option to accept or decline any opportunity that such an encounter may present.\n \nBecause these encounters are out of the ordinary,  the option \"Automatic attack and flight\" from the Options screen is ignored.";
		public static string	UneventfulTripString						= "Be glad you didn't encounter any pirates.";
		public static string	ArrivalString										= "Another trip you have survived.";
		public static string	IllegalGoodsString							= "Firearms and narcotics are illegal goods, and you lose these. You are fined a percentage of your total worth. This is subtracted from your credits. If you don't have enough credits, it increases your debt.";
		public static string	NoIllegalGoodsString						= "Firearms and narcotics are illegal goods. Since you don't carry these, the police have no problems with you.";
		public static string	BribeString											= "If the police officers can be bribed, it depends on the type of government of the target system how much it's going to cost you. If you pay the bribe, the police will forego inspection and you can continue your way. It's only useful to bribe if you are carrying illegal goods, that is, firearms or narcotics. You can only offer a bribe if you have enough cash.";
		public static string	CantBeBribedString							= "Certain governments have such an incorruptible police force that you can't bribe them.";
		public static string	NoMoneyForBribeString						= "You can only use your cash to pay a bribe; you can't trade your goods and you can't get a loan to pay the police off.";
		public static string	PiratesPlunderString						= "The pirates steal from you what they can carry, but at least you get out of it alive.";
		public static string	PiratesFindNoCargoString				= "If you have nothing in your cargo holds, the pirates will blow up your ship unless you pay them some money, equal to 5% of your current worth, which will be subtracted from your cash, unless you don't have enough of that, in which case it will be added to your debt. At least it's better than dying.";
		public static string	BothDestroyedString							= "The game is over, alas.";
		public static string	OpponentDestroyedString					= "You won the fight.";
		public static string	ShipDestroyedString							= "The game is over, alas.";
		public static string	YouEscapedString								= "You continue your flight towards the target system.";
		public static string	OpponentEscapedString						= "Your opponent has flown. You can't destroy him any longer, or try to plunder him.";
		public static string	RetireString										= "If you retire, the game ends. You sell your ship and everything on it, and remain in the current system for the rest of your days. If applicable, your total worth will be entered in the high score table.";
		public static string	BountyString										= "Destroying a pirate ship awards you bounty money. The height of the sum depends on the type of ship destroyed. The reward is automatically added to your cash.";
		public static string	PlunderString										= "You are allowed to plunder your opponent's cargo to your heart's content. Just steal whatever is to your liking. This works exactly as the Buy Cargo option when you are docked, except that you don't have to pay anything. You are, of course, limited to the amount your own cargo bays can hold. If you holds are already full, you can jettison selections from your cargo into space by tapping the Dump button. Tap the Done button when you are finished.";
		public static string	NotEnoughBaysString							= "You should sell enough goods so that you have enough empty cargo bays available.";
		public static string	AntidoteString									= "You can't use these ten cargo bays until you have visited the Japori system and delivered them there. Note that you can't even get rid of them by selling your ship.";
		public static string	LightningShieldString						= "The lightning shield is a shield with a lot more power than the usual shields. This shield can be sold, but note that if you sell the shield, there is no way to get another one, since it is an experimental shield and not commonly available. If you upgrade ships, you can pay to have the shield installed in your new ship.";
		public static string	SealedCannistersString					= "On the Sell Cargo screen you can see what you bought.";
		public static string	AmountToPlunderString						= "You can steal the amount you like, as long as it fits in your cargo bays. Tap Maximum to get as much as possible. Tap Nothing to return to the Plunder screen.";
		public static string	VictimDoesntHaveAnyString				= "You can only steal what your victim actually has.";
		public static string	FindSystemString								= "Type in the name of the system you are looking for and click OK. The search is case insensitive. Selecting \"Track this System\" will cause a arrow to be shown in the Short Range chart, pointing in the direction of the system you are looking for.";
		public static string	NoFullTanksString								= "You have checked the automatic buying of full fuel tanks in the Options menu, but you don't have enough money to buy those tanks. Don't forget to buy them as soon as you have made some money.";
		public static string	NoFullRepairsString							= "You have automatic full hull repairs checked in the Options menu, but you don't have the money for that. If you still want the repairs, don't forget to make them before you leave the system.";
		public static string	NoFullTanksOrRepairsString			= "In the Options menu you have indicated that you wish to buy full tanks and full hull repairs automatically when you arrive in a new system, but you don't have the money for that. At least make sure that you buy full tanks after you have made some money.";
		public static string	HighScoreString									= "Your score, calculated from the way you ended the game, your total worth, and the number of days you played, is entered automatically in the high score table when you qualify. You do NOT qualify if you laded a savegame while playing the game.";
		public static string	HighScoreTableString						= "This screen shows the high scores. The scoring percentage is calculated as follows: if you retired through the menu, your score is your total worth / 25000, minus 5%. If you got killed, your score is calculated in the same way, except that 10% is deducted instead of 5%. If you won the game by claiming your own moon, your score is calculated by adding 100 times the difficulty level (beginner=1, impossible=5), minus the number of days played, multiplied by 1000, to your total worth. That amount is divided by 25000 to get your score. The moon is included in your total worth. One extra thing to notice is that if your total worth exceeds 1 million, every credit over 1 million counts for only 0.1 credit.";
		public static string	ClearTableString								= "If you clear the high score table, your next score is certain to get entered. It's a bit of a cowardly option, though.";
		public static string	HowToPlayString									= "Space Trader is a strategy game in which the ultimate goal is to make enough cash to buy your own moon, to which you can retire. The most straightforward way to make cash is to trade goods between solar systems, hopefully making a profit. However, you can also decide to become a pirate and rob innocent traders of their wares. You can also earn an income by bounty hunting.\r\n\r\nInformation on the game can be found in the documentation file which comes with it. The Help menu in the game offers basic information, enough to play the game. The menu choice Help Current Screen always gives information on the screen which is currently shown. The rest of the menu choices give a basic overview of the game, of which this particular text is the first. The First Steps choice is especially interesting for a first-time player, since it describes all the steps you need to perform your first days as a trader.\r\n\r\nYou have to change screens often. All main screens are accessible through the menu. Shortcut keys are provided for the major choices, and you are advised to use them. To make that easier, you don't even have to provide the shortcut-stroke: just write the character associated with the menu and it will be activated. The four choices you have to use the most (Buy Cargo, Sell Cargo, Ship Yard and Short Range Chart) have their own shortcut button at the top right corner of every screen. These shortcut functions can be changed from the Shortcuts menu option in the Game menu.\r\n\r\nAt the start of the game you have a small spaceship of the Gnat type, armed with a simple pulse laser, and 1000 credits to start your ventures. While docked, you can buy or sell trade goods; buy or sell equipment for your ship; buy fuel, repairs or even a new ship at the Ship Yard; hire mercenaries; visit the bank to get a loan; get information on your status, the galaxy or nearby solar systems; and activate the warp to another " +
																														"system.\r\n\r\nWhen you have activated the warp, you materialise nearby the target system you selected. The last distance you have to travel on your impulse engines. During that time, you may encounter pirates, police ships, or other traders.";
		public static string	TradingString										= "Trading is the safest way to make money. You trade by buying goods at one solar system, and sell them at another solar system. Of course, you should try to make a profit. There are several ways to ensure you can indeed sell your goods for a higher price than you bought them.\r\n\r\nThe prices a system pays for goods are determined by several factors. First and foremost, there is the tech level of a system. Low-tech systems have relatively cheap natural resources (water, furs, food and ore), while high-tech systems have relatively cheap non-natural goods. In general, prices for natural goods increase with the level of technological development, while the other prices decrease. Note that the tech level also influences which goods are useful to the inhabitants of a system, and which they won't buy at all.\r\n \r\nOther influences are the type of government a system has (for instance, in an anarchy there is almost always a food shortage and a military state will never buy narcotics), the size of a system (the smaller the system, the greater the demand for imported goods), and extraordinary natural resources (or the lack of them). Lastly, special events may have a tremendous influence on prices: for instance, when a system is visited by a cold spell, furs are especially in high demand.\r\n\r\nOn the Short Range Chart, you can tap a system and ask for the Average Price List for that system. This list only takes into account the size, tech level and government of a system (and the special resources if you know about them), but may be a good indication on what price you can expect to get for your goods.\r\n\r\nNote that if you are a criminal (or worse), you have to use an intermediary to sell your goods, and this intermediary will take 10% of the profits.";
		public static string	TravellingString								= "To travel to another system, go to the Short Range Chart. The system where you currently are is in the centre of the screen. The wide circle shows how far you can travel on your current fuel tanks. If the circle is absent, you probably have no fuel and you should go to the Ship Yard to buy some.\r\n\r\nWhen you tap a system that is within reach, you get shown some information on that system, and a big Warp button, with which you can activate a warp. When you tap the Warp button, you get warped to the target system. You do not materialize on the system itself, but nearby. You have to travel the last few clicks on your impulse engines (which costs no fuel - fuel is only used to warp).\r\n\r\nDuring that time, you may meet police, pirates or other traders. The chance to meet any of them is determined by the government type of the system you are flying to. If you have a weak ship, you should probably stay away from systems which have lots of pirates. \r\n\r\nPolice ships will usually let a lawful trader pass by. If they suspect you may be trafficking illegal goods (that is, firearms or narcotics), they may ask you to submit to an inspection. If you don't have any illegal goods on board, just comply. If you do, and you let them inspect you, they will impound your goods and fine you. If you don't want to submit to inspection, you can try to flee from them (in which case they will attack you), attack them, or try to bribe them.\r\n\r\nPirates will usually attack you on sight. You can also attack them, flee from them, or surrender to them. If you surrender, they will steal from your cargo bays. If you don't have anything in your cargo bays, they will blow up your ship unless you pay them off with cash. Destroying a pirate will earn you a bounty.\r\n\r\nTraders will usually ignore you. However, you can become a pirate yourself and attack them. Sometimes, a trader who finds you too strong an opponent and who can't " +
																														"manage to flee from you, will surrender to you and let you steal from his cargo bays.";
		public static string	ShipEquipmentString							= "There are sevral types of ships available to you. You start out in a Gnat, which is the cheapest ship but one (the cheapest is the Flea, which is mainly used if you need to jump over a large distance, since it can travel up to 20 parsecs on one tank). At the Ship Yard, you can buy a new ship if you like and one is available. The availability of ships depends on the tech level of the system.\r\n\r\nShip equipment falls into three groups. Each ship can equip zero or more of each group. The ship type determines exactly how many. For instance, your Gnat can equip one weapon, zero shields and one gadget. \r\n\r\nThe first group consists of weapons. Three kinds of lasers are available, and the more lasers, or the more expensive lasers you equip, the more damage you do. The second group consists of shields. Two kinds of shields are available, and the more shields, or the more expensive shields you equip, the better you are defended against attacks. The last group consists of gadgets.\r\n\r\nAs gadgets, you can buy 5 extra cargo bays, a targeting system, a navigating system, an auto-repair system, or a cloaking device. Of the extra cargo bays you can equip more than one: of the others you don't have use for more than one. The cloaking device helps you fly undetected through space; the other three systems increase one of your skills (see Skills).\r\n\r\nBesides equipment slots, a ship has also one, two or three crew quarters. If you have more than one, you might hire mercenaries to accompany you on your trips.\r\n\r\nFinally, at the Ship Yard you can get your ship equipped with an escape pod, and at the bank you can get your ship insured, so you get compensated when you have to use your pod.\r\n\r\nWhen you buy a new ship, you trade in your old one, including all its equipment. Don't worry, the price you pay for your new ship takes this into account. You may even get money for the trade. Mercenaries will stay on your " +
																														"ship, unless your new ship hasn't got enough crew quarters. In that case, you have to fire them.";
		public static string	SkillsString										= "As a trader, you have need of several skills. You can set your skills on the New Commander screen at the start of the game.\r\n\r\nThe Pilot skill determines how well you fly your ship. Good pilots have an easier time escaping from a fight and dodging laser shots.\r\n\r\nThe Fighter skill determines how well you handle your weapons. While the actual damage you do with a weapon is solely determined by the weapon's power, the fighter skill determines whether you hit or not.\r\n\r\nThe Trader skill influences the price you have to pay for goods and equipment. A good trader pays considerably less than a bad trader.\r\n\r\nFinally, the Engineer skill determines how well you keep your ship in shape. Especially, an engineer manages to repair your hull and shield while traveling and during a fight. He may even reduce the damage done by an opponent to zero. A good engineer can also upgrade your weaponry a bit, so you do more damage.\r\n\r\nIf you fly a ship with extra crew quarters, you can hire mercenaries. These travel with you, for a certain sum of credits per day. The net effect of having a mercenary on board is that if the mercenary is better in a certain skill than you are, he will take over the tasks for which that skill is needed. So, if you are lacking a certain skill, a mercenary can compensate for that.\r\n\r\nAnother way to increase certain skills is to buy gadgets. Especially, a navigating system increases your pilot skill, an auto-repair system increases your engineer skill, and a targeting system increases your fighter skill.";
		public static string	MarieCantBribeString						= "Certain governments have such an incorruptible police force that you can't bribe them. Other times, the police are corruptible, but their supervisors know what's going on, so they won't risk it.";
		public static string	AcknowledgementsString					= "This first version of \"Space Trader\" has been designed and programmed by me, Pieter Spronck, between July and September 2000. The game has been enhanced several times since then. It has been released as freeware under a GNU General Public License (GPL).\r\n\r\nI used CodeWarrior for PalmPilot, release 6. Since it was my first project with this environment, I often consulted the example code delivered with it. I also made some use of Matt Lee's code for his DopeWars program.\r\n\r\nA derivative work of DopeWars was SolarWars, a program by David J. Webb. This program is very similar to DopeWars, except that it has a space trading theme instead of a drug theme. Playing SolarWars, I was reminded of the eighties game Elite. While Elite was more like a 3D space combat program, the trading between solar systems was central to it, especially because that was the best way to make money and buy better equipment for your ship.\r\n\r\nI thought it would be fun to have a program for the PalmPilot which was a trading game like SolarWars, but which would resemble the trading, development and even the combat of Elite more. Thus Space Trader was born. I haven't tried to hide my source of inspiration, and you'll find some ideas in the game which are directly derived from Elite. Consider it a tribute.\r\n\r\nA great many thanks and a lot of admiration goes out to Alexander Lawrence (al_virtual@yahoo.com), who created the beautiful pictures which illustrate the game, including the ship designs. It's almost worth ditching your black&white Palm for to get a color one! \r\n\r\nSam Anderson (rulez2@home.com) converted Space Trader to a multi-segmented application (version 1.1.2). Sam also made a few small changes to the code, fixing bugs and correcting grammatical errors.  I wish to extend my thanks to him for that. Without Sam, players using Palm OS versions 2.x and 4.x would have had a lot more problems with this game.\r\n\r\n" +
																														"Samuel Goldstein (palm@fogbound.net) added most of the new functionalities for version 1.2.0. Among these great additions are four new quests, special encounters, the \"news\", trading with fellow traders in space, better black&white pictures, and many handy new features. Samuel brought new life to this game, and even I found it to be a lot of fun again. Many heartfelt thanks go out to Samuel, from me, and I expect from many players too.\r\n\r\nMany thanks also go out to the Space Trader beta testers, who pointed out several bugs and who suggested many ideas to better the game, a lot of which have been implemented:\r\n\r\nMichael Andersson\nJohn Austin\nBen Belatrix\nLee W. Benjamin\nRussell K Bulmer (mtg101)\nChris Casperson (Neo987)\nDanny Chan\nChristophe \"The Frenchy\" Chidoyan\nLysander Destellirer\nCharles Dill\nZion A. Dutro\nKevin and Daniel Eaton\nJen Edwards\nRoni Eskola\nSean M. Goodman\nKen Gray\nTom Heisey\nPeter Hendzlik\nAnders Hustvedt\nJonathan Jensen\nPeter Kirk\nLackyboy\nAlexander Lawrence\nEric Lundquist\nEric Munsing\nossido\nBrandon Philips\nDylan Sauce\nNeil Shapiro\nTed Timmons\nSubway of Trammel\nSascha Warnem\xfcnde\nAitor Zabala\r\n\r\nThank you all. You were a tremendous help, and I am very grateful for that.\r\n\r\nFinally, I wish to thank all people who sent their comments to me since the first release of the game. Many of your suggestions have been incorporated in the game, and made it a lot better. Suggestions I haven't used, I have at least stored to inspire me when creating a sequel game.\r\n\r\nTo report bugs or discuss Space Trader, you can contact me at space_trader@hotmail.com. An extensive FAQ for the game is available at the Space Trader home page at http://go.to/spacetrader/.";
		public static string	FirstStepsString								= "Here I will describe the steps you will undertake the first days as a trader:\r\n\r\nYou start by docking on some system. The specifics of that system are shown on the System Information screen. Take special note of any special resources the system might have. These influence the price you have to pay for certain goods. For instance, a system which has rich soil, usually sells food cheap, while a relatively lifeless system has little fauna and therefore expensive furs. \r\n\r\nAlso take note of any special events in the system. Special events usually means that certain things are expensive to buy, so you should stay clear from them in this system, but since special events last several days, it might be worth your while to return here later to sell something they especially need.\r\n\r\nIf there is a Special button on the System Information screen, tap it to see what the special offer is. You can always refuse, but it is good to know what special thing is available here.\r\n\r\nAfter you have examined the system on the System Information screen, if you have cargo, go to the Sell Cargo screen to sell it. Then, switch to the Ship Yard to buy a full tank of fuel, and repair your hull if you think it's necessary. If you want, you can let the program take care of the Ship Yard automatically when you arrive in a new system, by checking the appropriate choices in the Options menu.\r\n\r\nThen switch to the Short Range Chart to select your next target. Tap any system within the maximum range circle to get information on that system. Try to select a system which hasn't got too many pirates (unless to aspire a career as a bounty hunter), and which has a tech level which is opposite the tech level of your current system. That is, from an agricultural system you best travel to an industrial system to sell natural goods, while from an industrial system you best sell technologies to more backward systems. Use the Average " +
																														"Price List button to get an indication on the prices you might expect to sell your goods for. Goods that are displayed bold have an average selling price that is higher than the price you have to pay for those goods in the current system. Note that this isn't a guarantee, but it's better than nothing.\r\n\r\nWhen you have selected a system, you know what you want to sell there, and you can switch to the Buy Cargo screen to get some goods. Remember that Firearms and Narcotics are illegal goods, and you could get in trouble with the police if you traffick those. After having filled your cargo bays, return to the Short Range Chart, and Warp to the selected system.\r\n\r\nWhile in flight, flee from pirates, ignore traders and submit to police inspections if they ask you to (unless you are carrying illegal goods, in which case you must decide for yourself how you best handle them). Later on in the game, when you are ready for it, you might wish to become a pirate yourself and attack traders, or become a bounty hunter and attack pirates. However, with full cargo holds you best try to arrive on the target system in one piece, so you can sell your goods and make a profit.\r\n\r\nThere are many more things to Space Trader, but you can discover these by examining the screens, reading the help screens, reading the documentation, and simply by playing the game.\r\n\r\nHave fun!";
		public static string	EggString												= "Look up your ship's equipment.";
		public static string	NoWeaponsString									= "You either are flying a ship without any weapon slots, so your only option is to flee from fights, or you haven't bought any weapons yet. Sorry, no weapons, no attacking.";
		public static string	BuyEscapePodString							= "When your ship has an escape pod, when it is destroyed, you are automatically ejected from it and you will be picked up by the Space Corps after a few days and dropped on a nearby system. You will lose your ship and cargo, but not your life. If you also have taken an insurance on your ship at the bank, the bank will fully refund your ship's costs. Your crew will also be saved in their own escape pods, but they will return to their home systems.";
		public static string	EscapePodActivatedString				= "You have lost your ship and cargo, but your and your crew's lives are saved. The Space Corps transports you to the space port of the system where you are currently located. Your crew is returned to their home systems.";
		public static string	FleaBuiltString									= "Your ship has been destroyed, but luckily, you are clever enough to convert your pod into a Flea type of ship, so you can continue your journey, or trade it in for a better ship.";
		public static string	InsurancePaysString							= "The bank pays you the amount your ship was worth, including equipment but excluding the cargo. Note that this is the same amount as you would have got when you would have traded the ship in.";
		public static string	TribbleSurvivedString						= "Don't be too sad. They were incredibly annoying, weren't they?";
		public static string	AntidoteDestroyedString					= "The antidote for the Japori system was destroyed with your ship. But they probably have some new antidote in the system where you originally got it.";
		public static string	NoEscapePodString								= "Insurance pays out when you must escape from your ship with an escape pod. Since you don't have a pod, you can't get insurance.";
		public static string	StopInsuranceString							= "If you stop your insurance, your no-claim will return to 0%, even if you buy new insurance immediately.";
		public static string	CantPayInsuranceString					= "You can't leave if you haven't paid your insurance. If you have no way to pay, you should stop your insurance at the bank.";
		public static string	OutdatedSoftwareString					= "This version of the software is a beta version, and can't be used after a certain date. To get a the latest version, go to http://go.to/spacetrader.";
		public static string	PickCannisterString							= "Your scoops can pick up space debris. If you want the contents of this canister, and you have room in your cargo holds, you can pick it up. If you don't have room, you can dump cargo to make room.";
		public static string	CurrentShipString								= "This screen shows your current ship, including equipment.";
		public static string	SellItemString									= "Selling an item will return to you about 75% of what you first paid for it. If you sell a ship as a whole, all items on it will automatically be sold.";
		public static string	SureToFleeOrBribeString					= "Only when you are carrying illegal goods, the police will do something you don't like, so if you aren't carrying anything illegal, you usually should just submit, and not try to attack, flee or bribe.";
		public static string	SureToSubmitString							= "If you are carrying illegal goods and the police searches you, they will impound the goods and fine you. You normally don't want to let the police search you when you are carrying illegal goods (firearms and narcotics), unless you are afraid they might kill you if you try to do something else.";
		public static string	BuyItemString										= "Tap Yes if you want to buy the item in the title for the price mentioned.";
		public static string	QuestsString										= "This screen lists the quests you are currently on.";
		public static string	WormholeOutOfRangeString				= "The system that owns a wormhole is shown to the left of it. You must first fly to that system, and tap the wormhole from there.";
		public static string	CantPayWormholeString						= "Wormhole tax must be paid when you want to warp through a wormhole. It depends on the type of your ship.";
		public static string	SpecificationString							= "These are the specifications of the costs you have to pay if you are going to warp to the selected target system.";
		public static string	SqueekString										= "This is a cute, furry tribble.";
		public static string	TribblesAteNarcoticsString			= "Tribbles ate your narcotics, and it killed most of them. At least the furs remained.";
		public static string	MoonBoughtString								= "What are you waiting for?";
		public static string	ArtifactStolenString						= "The aliens have taken the artifact from you. Well, it's rightfully theirs, so you probably shouldn't complain. You won't receive any reward from professor Berger, though.";
		public static string	ArtifactNotSavedString					= "You couldn't take the artifact with you in the escape pod, so now it's lost in the wreckage. The aliens will probably pick it up there.";
		public static string	ShipNotWorthMuchString					= "Normally you would receive about 75% of the worth of a new ship as trade-in value, but a tribble infested ship will give you only 25%. It is a way to get rid of your tribbles, though.";
		public static string	AttackByAccidentString					= "If you attack the police, they know you are a die-hard criminal and will immediately label you as such.";
		public static string	AttackTraderString							= "While attacking a trader is not considered to be as bad as attacking the police (since no police is present, they cannot judge the exact circumstances of the attack), it will make the police suspicious of you.";
		public static string	NoSurrenderString								= "If you are too big a criminal, surrender is NOT an option anymore.";
		public static string	ArrestedString									= "At least you survived.";
		public static string	AntidoteRemovedString						= "At least those poor people at Japori are assisted. You couldn't help them, what with being in prison 'n all.";
		public static string	TribblesSoldString							= "At least you got rid of them.";
		public static string	FleaReceivedString							= "It's standard practice for the police to leave a condemned criminal with at least the means to leave the solar system.";
		public static string	ConvictionString								= "Your fine and number of days in prison are based on the kind of criminal you were found to be.";
		public static string	ShipSoldString									= "The Space Corps needs cash to make you pay for the damages you did. Your ship is the only valuable possession you have.";
		public static string	InsuranceLostString							= "Too bad. Your no-claim is reset too.";
		public static string	MercenariesLeaveString					= "You can't pay your mercenaries while you are imprisoned, and so they have sought new employment.";
		public static string	WantToSurrenderString						= "Your fine and time in prison will depend on how big a criminal you are. Your fine will be taken from your cash. If you don't have enough cash, the police will sell your ship to get it. If you have debts, the police will pay them from your credits (if you have enough) before you go to prison, because otherwise the interest would be staggering.";
		public static string	ImpoundString										= "What would you expect?";
		public static string	WantToSurrenderToAliensString		= "The aliens are only after the artifact. They will let you live, and even let you keep your cargo, but you won't be able to finish your quest.";
		public static string	RetireDestroyedUtopiaString			= "Tap anywhere on the screen to continue...";
		public static string	NoQuartersForJarekString				= "To be able to take a passenger on board, you must have at least one empty set of crew quarters. That means you can't take a passenger on a ship with only one set of quarters, and if you have spare quarters, there can't be a mercenary living in them.";
		public static string	JarekNeedsQuartersString				= "There is room for a passenger on your current ship, but not on the ship you intend to buy.";
		public static string	JarekTakenHomeString						= "You can't deliver Jarek home yourself now.";
		public static string	JarekTakenOnBoardString					= "Your passenger uses one of your crew quarters, until you have delivered him to his destination.";
		public static string	QuestListString									= "This form lists where all the quests start.";
		public static string	FuelCompactorString							= "A fuel compactor allows you to fill up your tanks so you can travel 18 parsecs. You can't buy this anywhere, though you may sell it if you like. If you upgrade ships, you can pay to have the fuel compactor installed in your new ship.";
		public static string	DebtWarningString								= "You get this warning because your debt has exceeded 75000 credits. If you don't pay back quickly, you may find yourself stuck in a system with no way to leave. You have been warned.";
		public static string	DebtTooLargeForBuyString				= "Your debt has exceeded 100000 credits. You're in big trouble! You cannot buy any cargo. You should have heeded the warnings!";
		public static string	DebtTooLargeForTravelString			= "Your ship has been chained to the station's dock. Your debt has increased to a point where you are no longer a trusted trader. You may not leave until you can reduce it to an acceptable level. You have been warned and should have listened..";
		public static string	TransferFuelCompactorString			= "For the sum of 20000 credits, you get to keep your unique fuel compactor! This may seem to be a lot of money, but you must remember that this is the exact amount the fuel compactor is currently worth, and it has already been subtracted from the price for which the new ship is offered. So actually, this is a very good deal.";
		public static string	TransferLightningShieldString		= "For the sum of 30000 credits, you get to keep your unique lightning shield! This may seem to be a lot of money, but you must remember that this is the exact amount the shield is currently worth, and it has already been subtracted from the price for which the new ship is offered. So actually, this is a very good deal.";
		public static string	FireMercenaryString							= "If you fire a mercenary, he or she returns to his or her home system.";
		public static string	ErrGraphicsSupportString				= "There are three versions of Space Trader:\r\n\r\n1) SpaceTrader_black&white.prc contains 1-bit graphics and can run on any Palm with OS version 2.0 or higher.\r\n2) SpaceTrader_gray.prc contains 4-bit grayscale graphics and needs at least Palm OS 3.5 and hardware that supports 4-bit grayscales.\r\n3) SpaceTrader_color.prc contains 8-bit color graphics and needs at least Palm OS 3.5 and hardware that supports colors.\r\n\r\nGet the right version for your Palm.";
		public static string	LootMarieCelesteString					= "The Marie Celeste is completely abandoned, and drifting through space. The ship's log is unremarkable except for a Tribble infestation a few months ago, and the note that the last system visited was Lowry.\r\n\r\nThe crew's quarters are in good shape, with no signs of struggle. There is still food sitting on the table and beer in the mugs in the mess hall. Except for the fact that it's abandoned, the ship is normal in every way.\r\n\r\nBy Intergalactic Salvage Law, you have the right to claim the cargo as your own if you decide to.";
		public static string	CreditsString										= "Space Trader\r\n\r\nCopyright © 2000-2002 by Pieter Spronck\r\n\r\nDesign and programming:\r\nPieter Spronck\r\n\r\nAdditional design and programming:\r\nSamuel Goldstein\r\nSam Anderson\r\n\r\nGraphics:\r\nAlexander Lawrence\r\n\r\nAdditional graphics:\r\nSamuel Goldstein\r\nPieter Spronck\r\n\r\nSpecial thanks to:\r\nDavid Braben and Ian Bell for \"Elite\"\r\nDavid J. Webb for \"Solar Wars\"\r\nMatt Lee for \"Dope Wars\"\r\nAll the beta testers\r\nAnd all the players that sent me their ideas\r\n\r\nSpace Trader is released under a GNU General Public License";
		public static string	NoDumpNoScoopString							= "If you wanted to pick up the floating canister, you had to dump something from your cargo holds.";
		public static string	TradeCaptainAhabString					= "Captain Ahab is in need of a spare shield for an upcoming mission. Since he's in a rush, he'd rather not stop to get one on-planet.\r\n\r\nThe deal he's offering is a trade, rather than cash, for the shield. He'll trade you some piloting lessons in exchange for your reflective shield (he only needs one, so if you have more than one, you'll keep the others).\r\n\r\nCaptain Ahab is one of the greatest pilots of all time, and still holds the speed record for cross-galaxy transport.";
		public static string	TrainingString									= "Under the watchful eye of the Captain, you demonstrate your abilities. The Captain provides some helpful pointers and tips, and teaches you a few new techniques. The few hours pass quickly, but you feel you've gained a lot from the experience.";
		public static string	TradeCaptainConradString				= "Captain Conrad is in need of a military laser to test a new shield design she's been working on. Unfortunately, she's used up her R&D budget for the year.\r\n\r\nThe deal she's offering is a trade, rather than cash, for the laser. She'll trade you some engineering lessons in exchange for your military laser (she only needs one, so if you have more than one, you'll keep the others).\r\n\r\nCaptain Conrad, in addition to writing early novels about life in the fleet,  invented practically every component of the modern warp drive.";
		public static string	TradeCaptainHuieString					= "Captain Huie is in need of a military laser for an upcoming mission, but would rather hold onto her cash to buy her cargo.\r\n\r\nThe deal she's offering is a trade, rather than cash, for the laser. She'll give you some secrets of doing business in exchange for your military laser.\r\n\r\nCaptain Huie is known far and wide for driving a hard bargain; she was Trade Commissioner of the Galactic Council for over twenty years.";
		public static string	DrinkOldTonicString							= "Floating in orbit, you come across a bottle of Captain Marmoset's Amazing Skill Tonic. This concoction has been extremely hard to find since the elusive Captain Marmoset left on a mission to the heart of a comet.\r\n\r\nIn the old days, this stuff went for thousands of credits a bottle, since people reported significant gains in their abilities after quaffing a bottle.\r\n\r\nThe \"best used by\" date stamped on the bottle has become illegible. The tonic might still be good. Then again, it's not clear what happens when the Tonic breaks down...";
		public static string	CannotSaveString								= "There was an error trying to create the savegame file. This may be due to a lack of system resources.";
		public static string	CannotLoadString								= "No savegame file was found to load. You must first create a savegame file with the menu choice \"Save game\".";
		public static string	DrankGoodSkillTonicString				= "Captain Marmoset's Amazing Skill Tonic goes down very smoothly. You feel a slight tingling in your fingertips.";
		public static string	DrankOldSkillTonicString				= "Captain Marmoset's Amazing Skill Tonic tasted very strange, like slightly salty red wine. You feel a bit dizzy, and your teeth itch for a while.";
		public static string	ReallyLoadString								= "Loading a savegame will remove your current game from memory and restore an earlier situation.";
		public static string	BuyPaperString									= "The local newspaper is a great way to find out what's going on in the area.\r\n\r\nYou may find out about shortages, wars, or other situations at nearby systems. Then again, some will tell you that \"no news is good news.\"";
		public static string	CantBuyNewspaperString					= "If you can't pay the price of a newspaper, you can't get it. If you have \"Reserve Money\" checked in the Options menu, the game will reserve at least enough money to pay for insurance and mercenaries.";
		public static string	DumpItemString									= "On the Dump Cargo screen, the leftmost button shows the number of cargo bays you have which contain these goods. If that amount is zero, you can't dump any.";
		public static string	Options2String									= "\"Always pay for newspaper\" will allow you to automatically pay when you click on the \"News\" button when viewing system information. If you leave this unchecked, you will be asked whether you want to spend the money on the paper.\r\n\r\n\"Enable use of hardware buttons\" permits the use of the hardware buttons for changing screens when docked. The order is just like the rectangular navigation buttons at the top right:\r\nThe Calendar button takes you to the Buy Cargo screen.\r\nThe Address Book button takes you to the Sell Cargo screen.\r\nThe To-Do List button takes you to the Ship Yard screen.\r\nThe Memo Pad button takes you to the Short Range chart.\r\n\r\n\"Show range to tracked system\" determines whether or not the Short Range Chart will display the distance to a tracked system. You can track a system by double-clicking it in the Galactic Chart, or by clicking the \"Track this system\" checkbox when you find a system on the Galactic Chart.\r\n\r\n\"Stop tracking systems on arrival\" allows you to automatically stop tracking a system when you arrive at that system. If you uncheck this, you will continue to track the system until you turn off system tracking or select a different system to track in the Galactic Chart.\r\n\r\n\"Textual encounters\", when checked, shows encounters as text instead of as ship pictures. This gives a bit more information but doesn't look as good.\r\n\r\nChecking \"Remind about loans\" will provide you with notification of your current loan balance every five days.\r\n\r\n\"Identify at startup\" shows the name of the current commander when Space Trader is started. This is useful when playing two switched games.\r\n\r\n\"Copy prefs from parallel game\", if checked, when you switch to this game, will copy the preferences from the parallel game. One person playing two parallel games on a Palm will usually have this turned on (an exception might be where the player is a pirate in one game " +
																														"but a lawful trader in the other). Two persons sharing a Palm playing parallel games will want this turned off. Note that you must turn copying of preferences off separately for each game. It is entirely possible for one game not to copy preferences from the other game, but have its own preferences copied to the other game.";
		public static string	DumpCargoString									= "Use this screen to jettison unwanted cargo. The leftmost column shows quantities you have stored in your cargo holds. The second column shows the name of the goods. To dump it, either tap the quantity cell, after which you can specify how much you want to dump, or tap the \"Max\" cell, which will automatically jettison all goods you own of the selected item. \r\n\r\nIt should be obvious that it's better to sell cargo than to dump it. When you dump cargo, you don't get paid! But sometimes, particularly when you need to get rid of illegal cargo on a planet with no trade in that kind of goods, it makes sense to just dump it at a loss.";
		public static string	WildArrestedString							= "Jonathan Wild is arrested, and taken off to prison.";
		public static string	DisableScoringString						= "Only a game played without loading previously saved games will be taken into account for the high score table. So you can load a game, but you won't score anymore, until you start a new game.";
		public static string	WildSwitchesShipsString					= "Jonathan Wild figures that it's probably safer to get a ride home with his old associate than stay on your ship. After all, if you surrender to pirates, what's to stop you from surrendering to the police?";
		public static string	WildStaysAboardString						= "Jonathan Wild would have preferred to get a ride home with his old associate than stay in your ship. After all, if you surrender to pirates, what's to stop you from surrendering to the police? But the Pirates have no quarters available, so he grudgingly stays aboard your ship.";
		public static string	WildWontGoString								= "Jonathan Wild is being hunted by the police. They're serious about capturing him, and he doesn't wish to be captured. He'd rather take his chances hiding out on this system than facing swarms of police without any weapons.";
		public static string	WildLeavesString								= "Since Jonathan Wild is not willing to travel under these conditions, and you're not willing to change the situation, he leaves you and goes into hiding on this system.";
		public static string	ReactorUsingFuelString					= "The Reactor was unstable to begin with. Now, it seems that it's rapidly consuming fuel. It is not clear what will happen if it runs out -- but you have no reason to suspect it will be anything good.";
		public static string	ReactorSelfDestructString				= "The Reactor has undergone unplanned energetic self-disassembly.";
		public static string	ReactorOnBoardString						= "You can't use the five cargo bays containing the reactor until you have visited the Nix system and delivered it there. The ten bays containing reactor fuel cannot be used while they contain fuel, but as the reactor consumes the fuel, the bays become available. Note that you can't even empty bays by selling your ship.";
		public static string	MorganLaserInstallString				= "Henry Morgan's Special Laser is a more powerful version of the Military laser. It uses advanced thermal coherence, which should be as effective on titanium as it is on organic material.  This laser can be sold, but there is no way to get another one if you do, since only Henry Morgan knows how to make them (and he would be as likely to kill you as he would sell you another).";
		public static string	ReactorTakenString							= "The bad news is that you've lost the Ion Reactor. The good news is that you no longer have to worry about managing its depleting fuel store.";
		public static string	ReactorNotTakenString						= "The good news is that you still have the Ion Reactor. The bad news is that you still have to worry about managing its depleting fuel store.";
		public static string	CantTransferString							= "When trading ships, you will only be able to transfer an item from your old ship to the new ship if there is capacity for that item on the new ship,";
		public static string	TransferMorgansLaserString			= "For the sum of 33333 credits, you get to keep the laser given to you by Henry Morgan! This may seem to be a lot of money, but you must remember that this is the exact amount the laser is currently worth, and it has already been subtracted from the price for which the new ship is offered. So actually, this is a very good deal.";
		public static string	CantTransferAllString						= "The ship's price takes into account the trade-in value of your current ship. You have to pay the remaining price, and the price of transferring your unique equipment, with your cash total. If you can't afford to transfer all of your unique equipment, you can choose which items to transfer. If you have \"Reserve Money\" checked in the Options menu, the game will reserve at least enough money to pay for insurance and mercenaries.";
		public static string	TribbleNoticeString							= "You might want to do something about those Tribbles...";
		public static string	CantSellShipWithReactorString		= "You can't sell your ship as long as you have an Ion Reactor on board. Deliver the Reactor to Nix, and then you'll be able to get a new ship.";
		public static string	IrradiatedTribblesString				= "Radiation poisoning seems particularly effective in killing Tribbles. Unfortunately, their fur falls out when they're irradiated, so you can't salvage anything to sell.";
		public static string	WildWontGoWithReactorString			= "The Ion Reactor is known to be unstable, and Jonathan Wild is trying to get to safety. He's not willing to get on the ship while the Reactor's on board.";
		public static string	NewspaperHelpString							= "The local newspaper gives you information about what's happening on this and nearby systems. On higher-tech systems, you'll probably get better news about neighboring systems than you would on a low-tech system.";
		public static string	TrackSystemString								= "Tracking a system will modify the Short Range Chart by adding an arrow pointing in the direction of the system being tracked. If you have selected the \"Show range to tracked system\" option (on Options Page 2), the Short Range Chart will also show you the distance to the system being tracked.";
		public static string	DumpAllString										= "You have opted to jettison all goods you own of this particular type. You don't get paid for cargo that you dump! Sometimes, particularly when you need to get rid of illegal cargo on a planet with no trade in them, it makes sense to just dump goods at a loss.";
		public static string	FleePostMarieString							= "Even if you get away, the Customs Police know that you've engaged in criminal activity, and your police record will reflect this fact.";
		public static string	CustomsPoliceConfiscatedString	= "The Customs Police took all the illegal goods from your ship, and sent you on your way.";
		public static string	HullReinforcedString						= "Technicians spent the day replacing welds and bolts, and adding materials to your ship. When they're done, they tell you your ship should be significantly sturdier.";
		public static string	TradeInOrbitString							= "If you are selling items, specify the amount to sell and tap the OK button. If you specify more than you have in your cargo bays, the maximum possible amount will be sold. The same goes if you tap the All button. If you don't want to sell anything, tap the None button.\r\n\r\nIf you are buying items, specify the amount to buy and tap the OK button. If you specify more than you can afford, or more than your available cargo bays, the maximum possible amount will be bought. The same goes if you tap the All button. If you don't want to buy anything, tap the None button.\r\n";
		public static string	AttackGreatCaptainString				= "You grew up on stories of the adventures of the Great Captains. You heard how they explored the galaxy, invented technologies ... and destroyed man, many pirates and villains in combat. Are you sure you want to attack one of these greats?";
		public static string	LoanReminderString							= "The Bank Officer will contact you every five days to remind you of your debt. You can turn off these warnings on the second page of Game Options.";
		public static string	SingularityString								= "To use the Portable Singularity in the Galactic Chart, select your destination system by tracking it, then Jump by clicking  the \"J\" button. Voila! You will travel through the Singularity and arrive instananeously at your destination.";
		public static string	GameSavedString									= "Snapshots are meant for debugging purposes. If you notice a bug and contact the game's author, he might ask you for a snapshot of the current game which allows him to recreate the bug, or notice any strange things in the memory. Snapshots have no use in playing Space Trader.";
		public static string	ShortcutPrefsString							= "On this page you can set your preferences for the rectangularshortcut buttons used when you're in the dock.\r\n\r\nUse the pulldowns to assign the function to each navigation button. Shortcut 1 is the leftmost shortcut, while Shortcut 4 is the rightmost.";
		public static string	SpaceLitteringString						= "Space litterers will at least be considered dubious. If you are already a dubious character, space littering will only add to your list of offences. However, the police must of course be able to track the litter to you, which they often are not.";
		public static string	SwitchGameString								= "You can play two parallel games of Space Trader on your Palm. You switch between them by using the \"Switch Game\" option. This allows you to try two different styles of gameplay at the same time (for instance as a pirate and as an honest trader), or two people to play their own Space Trader game on one Palm. It's best to name the Commander in the two games differently, so you can easily recognize which game is loaded.";
		public static string	CannotSwitchString							= "Switching to a parallel game failed. This is usually due to a lack of space on your Palm.";
		public static string	SwitchedString									= "A parallel game has been loaded. You can switch back to the previous game by using the option \"Switch Game\" again.";
		public static string	SwitchToNewString								= "You can play two parallel games on a Palm. You can switch between them with the \"Switch Game\" function. You best give the commander in each of the games a different name, which makes it easier to recognize them.";
		public static string	HelpOnMenuString								= "The menu consists of three main menu choices:\r\n\r\n\"Command\" allows you to issue commands while you are docked at a system. You can use this to switch between the main screens.\r\n\"Game\" gives access to game functions. These are explained in depth below.\r\n\"Help\" gives access to help information.\r\n\r\nThe functions in the \"Game\" menu probably need more in depth information:\r\n\r\n\"New Game\" starts a new game, without further ado.\r\n\"Switch Game\" switches to a parallel game. You can play two different games in parallel on a Palm, which is handy for people who are sharing a Palm.\r\n\"Retire\" ends the game by retiring the commander. Your score is calculated and you can enter the high-score table if you qualify. However, the preferred way to end a game is by claiming a moon, which is something you have to work for.\r\n\"Options\" gives access to the game preferences.\r\n\"Shortcuts\" allows you to set new preferences for the four shortcut buttons in the top right corner of many screens.\r\n\"High Scores\" shows the high-score list.\r\n\"Clear High Scores\" wipes the current high-score list.\r\n\"Snapshot\" saves an image  of your current game state. You will not ordinarily have any use for this unless you are helping us track down a bug: in this case, we'll ask you to send a copy of this image so we can figure out what's going on.";
		public static string	IdentifyStartupString						= "This information box shows the name of the commander playing the current game. This is useful if two switched games are played in parallel. You can turn this notification off in the Options.";
		public static string	RectangularButtonsOnString			= "Space Trader by default uses rectangular buttons for shortcuts and on several screens. Before the release of Palm OS 5.0 it was possible to change the frame of a button from rounded into rectangular by directly accessing the frame attribute of a button. PalmSource has warned developers that this feature might no longer work in Palm OS 5.0 and higher, and they do not offer an easy replacement feature. When this version of Space Trader was released, it was unknown whether buttons could still be made rectangular under Palm OS 5.0, since it wasn't out yet. Therefore it was turned off by default, but you can try to turn it on by choosing Yes when answering the \"Rectangular Buttons\" question. If it does NOT work, anything might happen, from crashing the game to corrupted buttons, to the Palm refusing to execute this action. If the game crashes, your setting won't be saved and the next time you start it you will have rounded buttons again. If it doesn't work right but doesn't crash, you can turn it off again from the Options. Otherwise, stick with it because rectangular buttons look better. Hopefully by the time Space Trader 1.2.1 appears it will be known how to approach this issue for OS 5.0, and a permanent fix will be made.";
		public static string	AttemptRectangularString				= "After you leave the Options, if the current game screen shown contains buttons that normally are rectangular, the change will be visible when you leave the screen and come back to it later.";
		public static string	NoJumpToCurSystemString					= "Track another system than the one where you are currently are located, then tap the Singularity button to jump.";
*/
		#endregion
	}
}
