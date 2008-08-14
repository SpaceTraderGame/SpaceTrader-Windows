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
using System.Windows.Forms;

namespace Fryz.Apps.SpaceTrader
{
	public class Game : STSerializableObject
	{
		#region Member Declarations

		private static Game		_game;

		// Game Data
		private StarSystem[]	_universe;
		private int[]					_wormholes									= new int[6];
		private CrewMember[]	_mercenaries								= new CrewMember[Strings.CrewMemberNames.Length];
		private Commander			_commander;
		private Ship					_dragonfly									= new Ship(ShipType.Dragonfly);
		private Ship					_scarab											= new Ship(ShipType.Scarab);
		private Ship					_scorpion										= new Ship(ShipType.Scorpion);
		private Ship					_spaceMonster								= new Ship(ShipType.SpaceMonster);
		private Ship					_opponent										= new Ship(ShipType.Gnat);
		private bool					_opponentDisabled						= false;

		private int						_chanceOfTradeInOrbit				= 100;
		private int						_clicks											= 0;									// Distance from target system, 0 = arrived
		private bool					_raided											= false;							// True when the commander has been raided during the trip
		private bool					_inspected									= false;							// True when the commander has been inspected during the trip
		private bool					_tribbleMessage							= false;							// Is true if the Ship Yard on the current system informed you about the tribbles
		private bool					_arrivedViaWormhole					= false;							// flag to indicate whether player arrived on current planet via wormhole
		private bool					_paidForNewspaper						= false;							// once you buy a paper on a system, you don't have to pay again.
		private bool					_litterWarning							= false;							// Warning against littering has been issued.
		private ArrayList			_newsEvents									= new ArrayList(30);

		// Current Selections
		private Difficulty		_difficulty									= Difficulty.Normal;	// Difficulty level
		private bool					_cheatEnabled								= false;
		private bool					_autoSave										= false;
		private bool					_easyEncounters							= false;
		private GameEndType		_endStatus									= GameEndType.NA;
		private EncounterType	_encounterType							= 0;									// Type of current encounter
		private StarSystemId	_selectedSystemId						= StarSystemId.NA;		// Current system on chart
		private StarSystemId	_warpSystemId								= StarSystemId.NA;		// Target system for warp
		private StarSystemId	_trackedSystemId						= StarSystemId.NA;		// The short-range chart will display an arrow towards this system if the value is not null
		private bool					_targetWormhole							= false;							// Wormhole selected?
		private int[]					_priceCargoBuy							= new int[10];
		private int[]					_priceCargoSell							= new int[10];

		// Status of Quests
		private int						_questStatusArtifact				= 0;									// 0 = not given yet, 1 = Artifact on board, 2 = Artifact no longer on board (either delivered or lost)
		private int						_questStatusDragonfly				= 0;									// 0 = not available, 1 = Go to Baratas, 2 = Go to Melina, 3 = Go to Regulas, 4 = Go to Zalkon, 5 = Dragonfly destroyed, 6 = Got Shield
		private int						_questStatusExperiment			= 0;									// 0 = not given yet, 1-11 = days from start; 12 = performed, 13 = cancelled
		private int						_questStatusGemulon					= 0;									// 0 = not given yet, 1-7 = days from start, 8 = too late, 9 = in time, 10 = done
		private int						_questStatusJapori					= 0;									// 0 = no disease, 1 = Go to Japori (always at least 10 medicine cannisters), 2 = Assignment finished or canceled
		private int						_questStatusJarek						= 0;									// 0 = not delivered, 1-11 = on board, 12 = delivered
		private int						_questStatusMoon						= 0;									// 0 = not bought, 1 = bought, 2 = claimed
		private int						_questStatusPrincess				= 0;									// 0 = not available, 1 = Go to Centauri, 2 = Go to Inthara, 3 = Go to Qonos, 4 = Princess Rescued, 5-14 = On Board, 15 = Princess Returned, 16 = Got Quantum Disruptor
		private int						_questStatusReactor					= 0;									// 0 = not encountered, 1-20 = days of mission (bays of fuel left = 10 - (ReactorStatus / 2), 21 = delivered, 22 = Done
		private int						_questStatusScarab					= 0;									// 0 = not given yet, 1 = not destroyed, 2 = destroyed - upgrade not performed, 3 = destroyed - hull upgrade performed
		private int						_questStatusSculpture				= 0;									// 0 = not given yet, 1 = on board, 2 = delivered, 3 = done
		private int						_questStatusSpaceMonster		= 0;									// 0 = not available, 1 = Space monster is in Acamar system, 2 = Space monster is destroyed, 3 = Claimed reward
		private int						_questStatusWild						= 0;									// 0 = not delivered, 1-11 = on board, 12 = delivered
		private int						_fabricRipProbability				= 0;									// if Experiment = 12, this is the probability of being warped to a random planet.
		private bool					_justLootedMarie						= false;							// flag to indicate whether player looted Marie Celeste
		private bool					_canSuperWarp								= false;							// Do you have the Portable Singularity on board?
		private int						_chanceOfVeryRareEncounter	= 5;
		private ArrayList			_veryRareEncounters					= new ArrayList(6);		// Array of Very Rare encounters not done yet.

		// Options
		private GameOptions		_options										= new GameOptions(true);

		// The rest of the member variables are not saved between games.
		private SpaceTrader		_parentWin									= null;
		private bool					_encounterContinueFleeing		= false;
		private bool					_encounterContinueAttacking	= false;
		private bool					_encounterCmdrFleeing				= false;
		private bool					_encounterCmdrHit						= false;
		private bool					_encounterOppFleeingPrev		= false;
		private bool					_encounterOppFleeing				= false;
		private bool					_encounterOppHit						= false;

		#endregion

		#region Methods

		public Game(string name, Difficulty difficulty, int pilot, int fighter, int trader, int engineer, SpaceTrader parentWin)
		{
			_game				= this;
			_parentWin	= parentWin;
			_difficulty	= difficulty;

			// Keep Generating a new universe until PlaceSpecialEvents and PlaceShipyards return true,
			// indicating all special events and shipyards were placed.
			do
				GenerateUniverse();
			while (!(PlaceSpecialEvents() && PlaceShipyards()));

			InitializeCommander(name, new CrewMember(CrewMemberId.Commander, pilot, fighter, trader, engineer, StarSystemId.NA));
			GenerateCrewMemberList();

			CreateShips();

			CalculatePrices(Commander.CurrentSystem);

			ResetVeryRareEncounters();

			if (Difficulty < Difficulty.Normal)
				Commander.CurrentSystem.SpecialEventType	= SpecialEventType.Lottery;

			// TODO: JAF - DEBUG
			/*
			Commander.Cash	= 1000000;
			CheatEnabled		= true;
			EasyEncounters	= true;
			*/
		}

		public Game(Hashtable hash, SpaceTrader parentWin): base(hash)
		{
			_game				= this;
			_parentWin	= parentWin;

			string	version	= (string)GetValueFromHash(hash, "_version");
			if (version.CompareTo(Consts.CurrentVersion) > 0)
				throw new FutureVersionException();

			_universe										= (StarSystem[])ArrayListToArray((ArrayList)GetValueFromHash(hash, "_universe"), "StarSystem");
			_wormholes									= (int[])GetValueFromHash(hash, "_wormholes", _wormholes);
			_mercenaries								= (CrewMember[])ArrayListToArray((ArrayList)GetValueFromHash(hash, "_mercenaries"), "CrewMember");
			_commander									= new Commander((Hashtable)GetValueFromHash(hash, "_commander"));
			_dragonfly									= new Ship((Hashtable)GetValueFromHash(hash, "_dragonfly", _dragonfly.Serialize()));
			_scarab											= new Ship((Hashtable)GetValueFromHash(hash, "_scarab", _scarab.Serialize()));
			_scorpion										= new Ship((Hashtable)GetValueFromHash(hash, "_scorpion", _scorpion.Serialize()));
			_spaceMonster								= new Ship((Hashtable)GetValueFromHash(hash, "_spaceMonster", _spaceMonster.Serialize()));
			_opponent										= new Ship((Hashtable)GetValueFromHash(hash, "_opponent", _opponent.Serialize()));
			_chanceOfTradeInOrbit				= (int)GetValueFromHash(hash, "_chanceOfTradeInOrbit", _chanceOfTradeInOrbit);
			_clicks											= (int)GetValueFromHash(hash, "_clicks", _clicks);
			_raided											= (bool)GetValueFromHash(hash, "_raided", _raided);
			_inspected									= (bool)GetValueFromHash(hash, "_inspected", _inspected);
			_tribbleMessage							= (bool)GetValueFromHash(hash, "_tribbleMessage", _tribbleMessage);
			_arrivedViaWormhole					= (bool)GetValueFromHash(hash, "_arrivedViaWormhole", _arrivedViaWormhole);
			_paidForNewspaper						= (bool)GetValueFromHash(hash, "_paidForNewspaper", _paidForNewspaper);
			_litterWarning							= (bool)GetValueFromHash(hash, "_litterWarning", _litterWarning);
			_newsEvents									= new ArrayList((int[])GetValueFromHash(hash, "_newsEvents", _newsEvents.ToArray(System.Type.GetType("System.Int32"))));
			_difficulty									= (Difficulty)GetValueFromHash(hash, "_difficulty", _difficulty);
			_cheatEnabled								= (bool)GetValueFromHash(hash, "_cheatEnabled", _cheatEnabled);
			_autoSave										= (bool)GetValueFromHash(hash, "_autoSave", _autoSave);
			_easyEncounters							= (bool)GetValueFromHash(hash, "_easyEncounters", _easyEncounters);
			_endStatus									= (GameEndType)GetValueFromHash(hash, "_endStatus", _endStatus);
			_encounterType							= (EncounterType)GetValueFromHash(hash, "_encounterType", _encounterType);
			_selectedSystemId						= (StarSystemId)GetValueFromHash(hash, "_selectedSystemId", _selectedSystemId);
			_warpSystemId								= (StarSystemId)GetValueFromHash(hash, "_warpSystemId", _warpSystemId);
			_trackedSystemId						= (StarSystemId)GetValueFromHash(hash, "_trackedSystemId", _trackedSystemId);
			_targetWormhole							= (bool)GetValueFromHash(hash, "_targetWormhole", _targetWormhole);
			_priceCargoBuy							= (int[])GetValueFromHash(hash, "_priceCargoBuy", _priceCargoBuy);
			_priceCargoSell							= (int[])GetValueFromHash(hash, "_priceCargoSell", _priceCargoSell);
			_questStatusArtifact				= (int)GetValueFromHash(hash, "_questStatusArtifact", _questStatusArtifact);
			_questStatusDragonfly				= (int)GetValueFromHash(hash, "_questStatusDragonfly", _questStatusDragonfly);
			_questStatusExperiment			= (int)GetValueFromHash(hash, "_questStatusExperiment", _questStatusExperiment);
			_questStatusGemulon					= (int)GetValueFromHash(hash, "_questStatusGemulon", _questStatusGemulon);
			_questStatusJapori					= (int)GetValueFromHash(hash, "_questStatusJapori", _questStatusJapori);
			_questStatusJarek						= (int)GetValueFromHash(hash, "_questStatusJarek", _questStatusJarek);
			_questStatusMoon						= (int)GetValueFromHash(hash, "_questStatusMoon", _questStatusMoon);
			_questStatusPrincess				= (int)GetValueFromHash(hash, "_questStatusPrincess", _questStatusPrincess);
			_questStatusReactor					= (int)GetValueFromHash(hash, "_questStatusReactor", _questStatusReactor);
			_questStatusScarab					= (int)GetValueFromHash(hash, "_questStatusScarab", _questStatusScarab);
			_questStatusSculpture				= (int)GetValueFromHash(hash, "_questStatusSculpture", _questStatusSculpture);
			_questStatusSpaceMonster		= (int)GetValueFromHash(hash, "_questStatusSpaceMonster", _questStatusSpaceMonster);
			_questStatusWild						= (int)GetValueFromHash(hash, "_questStatusWild", _questStatusWild);
			_fabricRipProbability				= (int)GetValueFromHash(hash, "_fabricRipProbability", _fabricRipProbability);
			_justLootedMarie						= (bool)GetValueFromHash(hash, "_justLootedMarie", _justLootedMarie);
			_canSuperWarp								= (bool)GetValueFromHash(hash, "_canSuperWarp", _canSuperWarp);
			_chanceOfVeryRareEncounter	= (int)GetValueFromHash(hash, "_chanceOfVeryRareEncounter", _chanceOfVeryRareEncounter);
			_veryRareEncounters					= new ArrayList((int[])GetValueFromHash(hash, "_veryRareEncounters", _veryRareEncounters.ToArray(System.Type.GetType("System.Int32"))));
			_options										= new GameOptions((Hashtable)GetValueFromHash(hash, "_options", _options.Serialize()));
		}

		public void Arrested()
		{
			int	term	= Math.Max(30, -Commander.PoliceRecordScore);
			int fine	= (1 + Commander.Worth * Math.Min(80, -Commander.PoliceRecordScore) / 50000) * 500;
			if (Commander.Ship.WildOnBoard)
				fine	= (int)(fine * 1.05);

			FormAlert.Alert(AlertType.EncounterArrested, ParentWindow);

			FormAlert.Alert(AlertType.JailConvicted, ParentWindow, Functions.Multiples(term, Strings.TimeUnit),
				Functions.Multiples(fine, Strings.MoneyUnit));

			if (Commander.Ship.HasGadget(GadgetType.HiddenCargoBays))
			{
				while (Commander.Ship.HasGadget(GadgetType.HiddenCargoBays))
					Commander.Ship.RemoveEquipment(EquipmentType.Gadget, GadgetType.HiddenCargoBays);

				FormAlert.Alert(AlertType.JailHiddenCargoBaysRemoved, ParentWindow);
			}

			if (Commander.Ship.ReactorOnBoard)
			{
				FormAlert.Alert(AlertType.ReactorConfiscated, ParentWindow);
				QuestStatusReactor		= SpecialEvent.StatusReactorNotStarted;
			}

			if (Commander.Ship.SculptureOnBoard)
			{
				FormAlert.Alert(AlertType.SculptureConfiscated, ParentWindow);
				QuestStatusSculpture	= SpecialEvent.StatusSculptureNotStarted;
			}

			if (Commander.Ship.WildOnBoard)
			{
				FormAlert.Alert(AlertType.WildArrested, ParentWindow);
				NewsAddEvent(NewsEvent.WildArrested);
				QuestStatusWild = SpecialEvent.StatusWildNotStarted;
			}

			if (Commander.Ship.AnyIllegalCargo)
			{
				FormAlert.Alert(AlertType.JailIllegalGoodsImpounded, ParentWindow);
				Commander.Ship.RemoveIllegalGoods();
			}

			if (Commander.Insurance)
			{
				FormAlert.Alert(AlertType.JailInsuranceLost, ParentWindow);
				Commander.Insurance	= false;
				Commander.NoClaim		= 0;
			}

			if (Commander.Ship.CrewCount - Commander.Ship.SpecialCrew.Length > 1)
			{
				FormAlert.Alert(AlertType.JailMercenariesLeave, ParentWindow);
				for (int i = 1; i < Commander.Ship.Crew.Length; i++)
					Commander.Ship.Crew[i]	= null;
			}

			if (Commander.Ship.JarekOnBoard)
			{
				FormAlert.Alert(AlertType.JarekTakenHome, ParentWindow);
				QuestStatusJarek	= SpecialEvent.StatusJarekNotStarted;
			}

			if (Commander.Ship.PrincessOnBoard)
			{
				FormAlert.Alert(AlertType.PrincessTakenHome, ParentWindow);
				QuestStatusPrincess	= SpecialEvent.StatusPrincessNotStarted;
			}

			if (QuestStatusJapori == SpecialEvent.StatusJaporiInTransit)
			{
				FormAlert.Alert(AlertType.AntidoteTaken, ParentWindow);
				QuestStatusJapori	= SpecialEvent.StatusJaporiDone;
			}

			if (Commander.Cash >= fine)
				Commander.Cash	-= fine;
			else
			{
				Commander.Cash	= Math.Max(0, Commander.Cash + Commander.Ship.Worth(true) - fine);

				FormAlert.Alert(AlertType.JailShipSold, ParentWindow);

				if (Commander.Ship.Tribbles > 0)
					FormAlert.Alert(AlertType.TribblesRemoved, ParentWindow);

				FormAlert.Alert(AlertType.FleaBuilt, ParentWindow);
				CreateFlea();
			}

			if (Commander.Debt > 0)
			{
				int	paydown			 = Math.Min(Commander.Cash, Commander.Debt);
				Commander.Debt	-= paydown;
				Commander.Cash	-= paydown;

				if (Commander.Debt > 0)
					for (int i = 0; i < term; i++)
						Commander.PayInterest();
			}

			Commander.PoliceRecordScore	= Consts.PoliceRecordScoreDubious;
			IncDays(term, ParentWindow);
		}

		private void Arrival()
		{
			Commander.CurrentSystem					= WarpSystem;
			Commander.CurrentSystem.Visited	= true;
			PaidForNewspaper								= false;

			if (TrackedSystem == Commander.CurrentSystem && Options.TrackAutoOff)
				TrackedSystemId	= StarSystemId.NA;

			ArrivalCheckReactor();
			ArrivalCheckTribbles();
			ArrivalCheckDebt();
			ArrivalPerformRepairs();
			ArrivalUpdatePressuresAndQuantities();
			ArrivalCheckEasterEgg();

			CalculatePrices(Commander.CurrentSystem);
			NewsAddEventsOnArrival();

			if (Options.NewsAutoShow)
				ShowNewspaper();
		}

		private void ArrivalCheckDebt()
		{
			// Check for Large Debt - 06/30/01 SRA
			if (Commander.Debt >= Consts.DebtWarning)
				FormAlert.Alert(AlertType.DebtWarning, ParentWindow);
				// Debt Reminder
			else if (Commander.Debt > 0 && Options.RemindLoans && Commander.Days % 5 == 0)
				FormAlert.Alert(AlertType.DebtReminder, ParentWindow, Functions.Multiples(Commander.Debt, Strings.MoneyUnit));
		}

		private void ArrivalCheckEasterEgg()
		{
			/* This Easter Egg gives the commander a Lighting Shield */
			if (Commander.CurrentSystem.Id == StarSystemId.Og)
			{
				bool egg	= true;
				for (int i = 0; i < Commander.Ship.Cargo.Length && egg; i++)
					if (Commander.Ship.Cargo[i] != 1)
						egg	= false;

				if (egg && Commander.Ship.FreeSlotsShield > 0)
				{
					FormAlert.Alert(AlertType.Egg, ParentWindow);
					Commander.Ship.AddEquipment(Consts.Shields[(int)ShieldType.Lightning]);
					for (int i = 0; i < Commander.Ship.Cargo.Length; i++)
					{
						Commander.Ship.Cargo[i]	= 0;
						Commander.PriceCargo[i]	= 0;
					}
				}
			}
		}

		private void ArrivalCheckReactor()
		{
			if (QuestStatusReactor == SpecialEvent.StatusReactorDate)
			{
				FormAlert.Alert(AlertType.ReactorMeltdown, ParentWindow);
				QuestStatusReactor	= SpecialEvent.StatusReactorNotStarted;
				if (Commander.Ship.EscapePod)
					EscapeWithPod();
				else
				{
					FormAlert.Alert(AlertType.ReactorDestroyed, ParentWindow);

					throw new GameEndException(GameEndType.Killed);
				}
			}
			else
			{
				// Reactor warnings:
				// now they know the quest has a time constraint!
				if (QuestStatusReactor == SpecialEvent.StatusReactorFuelOk + 1)
					FormAlert.Alert(AlertType.ReactorWarningFuel, ParentWindow);
					// better deliver it soon!
				else if (QuestStatusReactor == SpecialEvent.StatusReactorDate - 4)
					FormAlert.Alert(AlertType.ReactorWarningFuelGone, ParentWindow);
					// last warning!
				else if (QuestStatusReactor == SpecialEvent.StatusReactorDate - 2)
					FormAlert.Alert(AlertType.ReactorWarningTemp, ParentWindow);
			}
		}

		private void ArrivalCheckTribbles()
		{
			Ship	ship	= Commander.Ship;

			if (ship.Tribbles > 0)
			{
				int previousTribbles	= ship.Tribbles;
				int	narc							= (int)TradeItemType.Narcotics;
				int	food							= (int)TradeItemType.Food;

				if (ship.ReactorOnBoard)
				{
					if (ship.Tribbles < 20)
					{
						ship.Tribbles	= 0;
						FormAlert.Alert(AlertType.TribblesAllDied, ParentWindow);
					}
					else
					{
						ship.Tribbles	/= 2;
						FormAlert.Alert(AlertType.TribblesHalfDied, ParentWindow);
					}
				}
				else if (ship.Cargo[narc] > 0)
				{
					int dead														 = Math.Min(1 + Functions.GetRandom(3), ship.Cargo[narc]);
					Commander.PriceCargo[narc]					 = Commander.PriceCargo[narc] * (ship.Cargo[narc] - dead) / ship.Cargo[narc];
					ship.Cargo[narc]										-= dead;
					ship.Cargo[(int)TradeItemType.Furs]	+= dead;
					ship.Tribbles												-= Math.Min(dead * (Functions.GetRandom(5) + 98), ship.Tribbles - 1);
					FormAlert.Alert(AlertType.TribblesMostDied, ParentWindow);
				}
				else
				{
					if (ship.Cargo[food] > 0 && ship.Tribbles < Consts.MaxTribbles)
					{
						int	eaten										 = ship.Cargo[food] - Functions.GetRandom(ship.Cargo[food]);
						Commander.PriceCargo[food]	-= Commander.PriceCargo[food] * eaten / ship.Cargo[food];
						ship.Cargo[food]						-= eaten;
						ship.Tribbles								+= eaten * 100;
						FormAlert.Alert(AlertType.TribblesAteFood, ParentWindow);
					}

					if (ship.Tribbles < Consts.MaxTribbles)
						ship.Tribbles += 1 + Functions.GetRandom(ship.Cargo[food] > 0 ? ship.Tribbles : ship.Tribbles / 2);

					if (ship.Tribbles > Consts.MaxTribbles)
						ship.Tribbles = Consts.MaxTribbles;

					if ((previousTribbles < 100 && ship.Tribbles >= 100) ||
						(previousTribbles < 1000 && ship.Tribbles >= 1000) ||
						(previousTribbles < 10000 && ship.Tribbles >= 10000) ||
						(previousTribbles < 50000 && ship.Tribbles >= 50000) ||
						(previousTribbles < Consts.MaxTribbles && ship.Tribbles == Consts.MaxTribbles))
					{
						string	qty	= ship.Tribbles == Consts.MaxTribbles ? Strings.TribbleDangerousNumber :
							Functions.FormatNumber(ship.Tribbles);
						FormAlert.Alert(AlertType.TribblesInspector, ParentWindow, qty);
					}
				}

				TribbleMessage	= false;
			}
		}

		private void ArrivalPerformRepairs()
		{
			Ship	ship	= Commander.Ship;

			if (ship.Hull < ship.HullStrength)
				ship.Hull += Math.Min(ship.HullStrength - ship.Hull, Functions.GetRandom(ship.Engineer));

			for (int i = 0; i < ship.Shields.Length; ++i)
				if (ship.Shields[i] != null)
					ship.Shields[i].Charge	= ship.Shields[i].Power;

			bool	fuelOk	= true;
			int		toAdd		= ship.FuelTanks - ship.Fuel;
			if (Options.AutoFuel && toAdd > 0)
			{
				if (Commander.Cash >= toAdd * ship.FuelCost)
				{
					ship.Fuel				+= toAdd;
					Commander.Cash	-= toAdd * ship.FuelCost;
				}
				else
					fuelOk					= false;
			}

			bool	repairOk	= true;
			toAdd						= ship.HullStrength - ship.Hull;
			if (Options.AutoRepair && toAdd > 0)
			{
				if (Commander.Cash >= toAdd * ship.RepairCost)
				{
					ship.Hull				+= toAdd;
					Commander.Cash	-= toAdd * ship.RepairCost;
				}
				else
					repairOk				= false;
			}

			if (!fuelOk && !repairOk)
				FormAlert.Alert(AlertType.ArrivalIFFuelRepairs, ParentWindow);
			else if (!fuelOk)
				FormAlert.Alert(AlertType.ArrivalIFFuel, ParentWindow);
			else if (!repairOk)
				FormAlert.Alert(AlertType.ArrivalIFRepairs, ParentWindow);
		}

		private void ArrivalUpdatePressuresAndQuantities()
		{
			for (int i = 0; i < Universe.Length; i++)
			{
				if (Functions.GetRandom(100) < 15)
					Universe[i].SystemPressure	= Universe[i].SystemPressure == SystemPressure.None ?
						(SystemPressure)Functions.GetRandom((int)SystemPressure.War,
						(int)SystemPressure.Employment + 1) : SystemPressure.None;

				if (Universe[i].CountDown > 0)
				{
					Universe[i].CountDown--;

					if (Universe[i].CountDown > CountDownStart)
						Universe[i].CountDown	= CountDownStart;
					else if (Universe[i].CountDown <= 0)
						Universe[i].InitializeTradeItems();
					else
					{
						for (int j = 0; j < Consts.TradeItems.Length; j++)
						{
							if (WarpSystem.ItemTraded(Consts.TradeItems[j]))
								Universe[i].TradeItems[j]	= Math.Max(0, Universe[i].TradeItems[j] + Functions.GetRandom(-4, 5));
						}
					}
				}
			}
		}

		private void CalculatePrices(StarSystem system)
		{
			for (int i = 0; i < Consts.TradeItems.Length; i++)
			{
				int price	= Consts.TradeItems[i].StandardPrice(system);

				if (price > 0)
				{
					// In case of a special status, adapt price accordingly
					if (Consts.TradeItems[i].PressurePriceHike == system.SystemPressure)
						price	= price * 3 / 2;

					// Randomize price a bit
					int	variance	= Math.Min(Consts.TradeItems[i].PriceVariance, price - 1);
					price					= price + Functions.GetRandom(-variance, variance + 1);

					// Criminals have to pay off an intermediary
					if (Commander.PoliceRecordScore < Consts.PoliceRecordScoreDubious)
						price	= price * 90 / 100;
				}

				_priceCargoSell[i]	= price;
			}

			RecalculateBuyPrices(system);
		}

		private void CargoBuy(int tradeItem, bool max, IWin32Window owner, CargoBuyOp op)
		{
			int		freeBays		= Commander.Ship.FreeCargoBays;
			int[]	items				= null;
			int		unitPrice		= 0;
			int		cashToSpend	= Commander.Cash;

			switch (op)
			{
				case CargoBuyOp.BuySystem:
					freeBays		= Math.Max(0, Commander.Ship.FreeCargoBays - Options.LeaveEmpty);
					items				= Commander.CurrentSystem.TradeItems;
					unitPrice		= PriceCargoBuy[tradeItem];
					cashToSpend	= Commander.CashToSpend;
					break;
				case CargoBuyOp.BuyTrader:
					items							= Opponent.Cargo;
					TradeItem	item		= Consts.TradeItems[tradeItem];
					int				chance	= item.Illegal ? 45 : 10;
					double		adj			= Functions.GetRandom(100) < chance ? 1.1 : (item.Illegal ? 0.8 : 0.9);
					unitPrice					= Math.Min(item.MaxTradePrice, Math.Max(item.MinTradePrice,
						(int)Math.Round(PriceCargoBuy[tradeItem] * adj / item.RoundOff) * item.RoundOff));
					break;
				case CargoBuyOp.Plunder:
					items			= Opponent.Cargo;
					break;
			}

			if (op == CargoBuyOp.BuySystem && Commander.Debt > Consts.DebtTooLarge)
				FormAlert.Alert(AlertType.DebtTooLargeTrade, owner);
			else if (op == CargoBuyOp.BuySystem && (items[tradeItem] <= 0 || unitPrice <= 0))
				FormAlert.Alert(AlertType.CargoNoneAvailable, owner);
			else if (freeBays == 0)
				FormAlert.Alert(AlertType.CargoNoEmptyBays, owner);
			else if (op != CargoBuyOp.Plunder && cashToSpend < unitPrice)
				FormAlert.Alert(AlertType.CargoIF, owner);
			else
			{
				int	qty				= 0;
				int	maxAmount	= Math.Min(freeBays, items[tradeItem]);
				if (op == CargoBuyOp.BuySystem)
					maxAmount		= Math.Min(maxAmount, Commander.CashToSpend / unitPrice);

				if (max)
					qty	= maxAmount;
				else
				{
					FormCargoBuy	form	= new FormCargoBuy(tradeItem, maxAmount, op);
					if (form.ShowDialog(owner) == DialogResult.OK)
						qty	= form.Amount;
				}

				if (qty > 0)
				{
					int	totalPrice	= qty * unitPrice;

					Commander.Ship.Cargo[tradeItem]	+= qty;
					items[tradeItem]								-= qty;
					Commander.Cash									-= totalPrice;
					Commander.PriceCargo[tradeItem]	+= totalPrice;
				}
			}
		}

		public void CargoBuySystem(int tradeItem, bool max, IWin32Window owner)
		{
			CargoBuy(tradeItem, max, owner, CargoBuyOp.BuySystem);
		}

		public void CargoBuyTrader(int tradeItem, IWin32Window owner)
		{
			CargoBuy(tradeItem, false, owner, CargoBuyOp.BuyTrader);
		}

		public void CargoPlunder(int tradeItem, bool max, IWin32Window owner)
		{
			CargoBuy(tradeItem, max, owner, CargoBuyOp.Plunder);
		}

		public void CargoDump(int tradeItem, IWin32Window owner)
		{
			CargoSell(tradeItem, false, owner, CargoSellOp.Dump);
		}

		public void CargoJettison(int tradeItem, bool all, IWin32Window owner)
		{
			CargoSell(tradeItem, all, owner, CargoSellOp.Jettison);
		}

		public void CargoSellSystem(int tradeItem, bool all, IWin32Window owner)
		{
			CargoSell(tradeItem, all, owner, CargoSellOp.SellSystem);
		}

		private void CargoSell(int tradeItem, bool all, IWin32Window owner, CargoSellOp op)
		{
			int	qtyInHand	= Commander.Ship.Cargo[tradeItem];
			int	unitPrice;
			switch (op)
			{
				case CargoSellOp.SellSystem:
					unitPrice	= PriceCargoSell[tradeItem];
					break;
				case CargoSellOp.SellTrader:
					TradeItem	item		= Consts.TradeItems[tradeItem];
					int				chance	= item.Illegal ? 45 : 10;
					double		adj			= Functions.GetRandom(100) < chance ? (item.Illegal ? 0.8 : 0.9) : 1.1;
					unitPrice					= Math.Min(item.MaxTradePrice, Math.Max(item.MinTradePrice,
						(int)Math.Round(PriceCargoSell[tradeItem] * adj / item.RoundOff) * item.RoundOff));
					break;
				default:
					unitPrice	= 0;
					break;
			}

			if (qtyInHand == 0)
				FormAlert.Alert(AlertType.CargoNoneToSell, owner, Strings.CargoSellOps[(int)op]);
			else if (op == CargoSellOp.SellSystem && unitPrice <= 0)
				FormAlert.Alert(AlertType.CargoNotInterested, owner);
			else
			{
				if (op != CargoSellOp.Jettison || LitterWarning ||
					Commander.PoliceRecordScore <= Consts.PoliceRecordScoreDubious ||
					FormAlert.Alert(AlertType.EncounterDumpWarning, owner) == DialogResult.Yes)
				{
					int	unitCost	= 0;
					int	maxAmount	= (op == CargoSellOp.SellTrader) ? Math.Min(qtyInHand, Opponent.FreeCargoBays) : qtyInHand;
					if (op == CargoSellOp.Dump)
					{
						unitCost		= 5 * ((int)Difficulty + 1);
						maxAmount		= Math.Min(maxAmount, Commander.CashToSpend / unitCost);
					}
					int	price			= unitPrice > 0 ? unitPrice : -unitCost;

					int	qty	= 0;
					if (all)
						qty	= maxAmount;
					else
					{
						FormCargoSell	form	= new FormCargoSell(tradeItem, maxAmount, op, price);
						if (form.ShowDialog(owner) == DialogResult.OK)
							qty	= form.Amount;
					}

					if (qty > 0)
					{
						int	totalPrice	= qty * price;

						Commander.Ship.Cargo[tradeItem]	-= qty;
						Commander.PriceCargo[tradeItem]	= (Commander.PriceCargo[tradeItem] * (qtyInHand - qty)) / qtyInHand;
						Commander.Cash									+= totalPrice;

						if (op == CargoSellOp.Jettison)
						{
							if (Functions.GetRandom(10) < (int)Difficulty + 1)
							{
								if (Commander.PoliceRecordScore > Consts.PoliceRecordScoreDubious)
									Commander.PoliceRecordScore = Consts.PoliceRecordScoreDubious;
								else
									Commander.PoliceRecordScore--;

								NewsAddEvent(NewsEvent.CaughtLittering);
							}
						}
					}
				}
			}
		}

		public void CargoSellTrader(int tradeItem, IWin32Window owner)
		{
			CargoSell(tradeItem, false, owner, CargoSellOp.SellTrader);
		}

		public void CreateFlea()
		{
			Commander.Ship					= new Ship(ShipType.Flea);
			Commander.Ship.Crew[0]	= Commander;
			Commander.Insurance			= false;
			Commander.NoClaim				= 0;
		}

		private void CreateShips()
		{
			Dragonfly.Crew[0]			= Mercenaries[(int)CrewMemberId.Dragonfly];
			Dragonfly.AddEquipment(Consts.Weapons[(int)WeaponType.MilitaryLaser]);
			Dragonfly.AddEquipment(Consts.Weapons[(int)WeaponType.PulseLaser]);
			Dragonfly.AddEquipment(Consts.Shields[(int)ShieldType.Lightning]);
			Dragonfly.AddEquipment(Consts.Shields[(int)ShieldType.Lightning]);
			Dragonfly.AddEquipment(Consts.Shields[(int)ShieldType.Lightning]);
			Dragonfly.AddEquipment(Consts.Gadgets[(int)GadgetType.AutoRepairSystem]);
			Dragonfly.AddEquipment(Consts.Gadgets[(int)GadgetType.TargetingSystem]);

			Scarab.Crew[0]				= Mercenaries[(int)CrewMemberId.Scarab];
			Scarab.AddEquipment(Consts.Weapons[(int)WeaponType.MilitaryLaser]);
			Scarab.AddEquipment(Consts.Weapons[(int)WeaponType.MilitaryLaser]);

			Scorpion.Crew[0]			= Mercenaries[(int)CrewMemberId.Scorpion];
			Scorpion.AddEquipment(Consts.Weapons[(int)WeaponType.MilitaryLaser]);
			Scorpion.AddEquipment(Consts.Weapons[(int)WeaponType.MilitaryLaser]);
			Scorpion.AddEquipment(Consts.Shields[(int)ShieldType.Reflective]);
			Scorpion.AddEquipment(Consts.Shields[(int)ShieldType.Reflective]);
			Scorpion.AddEquipment(Consts.Gadgets[(int)GadgetType.AutoRepairSystem]);
			Scorpion.AddEquipment(Consts.Gadgets[(int)GadgetType.TargetingSystem]);

			SpaceMonster.Crew[0]	= Mercenaries[(int)CrewMemberId.SpaceMonster];
			SpaceMonster.AddEquipment(Consts.Weapons[(int)WeaponType.MilitaryLaser]);
			SpaceMonster.AddEquipment(Consts.Weapons[(int)WeaponType.MilitaryLaser]);
			SpaceMonster.AddEquipment(Consts.Weapons[(int)WeaponType.MilitaryLaser]);
		}

		private bool DetermineEncounter()
		{
			// If there is a specific encounter that needs to happen, it will, otherwise we'll generate a random encounter.
			return DetermineNonRandomEncounter() || DetermineRandomEncounter();
		}

		private bool DetermineNonRandomEncounter()
		{
			bool	showEncounter	= false;

			// Encounter with space monster
			if (Clicks == 1 && WarpSystem.Id == StarSystemId.Acamar &&
				QuestStatusSpaceMonster == SpecialEvent.StatusSpaceMonsterAtAcamar)
			{
				Opponent						= SpaceMonster;
				EncounterType				= Commander.Ship.Cloaked ? EncounterType.SpaceMonsterIgnore : EncounterType.SpaceMonsterAttack;
				showEncounter				= true;
			}
				// Encounter with the stolen Scarab
			else if (ArrivedViaWormhole && Clicks == 20 && WarpSystem.SpecialEventType != SpecialEventType.NA &&
				WarpSystem.SpecialEvent.Type == SpecialEventType.ScarabDestroyed &&
				QuestStatusScarab == SpecialEvent.StatusScarabHunting)
			{
				Opponent						= Scarab;
				EncounterType				= Commander.Ship.Cloaked ? EncounterType.ScarabIgnore : EncounterType.ScarabAttack;
				showEncounter				= true;
			}
				// Encounter with stolen Dragonfly
			else if (Clicks == 1 && WarpSystem.Id == StarSystemId.Zalkon &&
				QuestStatusDragonfly == SpecialEvent.StatusDragonflyFlyZalkon)
			{
				Opponent						= Dragonfly;
				EncounterType				= Commander.Ship.Cloaked ? EncounterType.DragonflyIgnore : EncounterType.DragonflyAttack;
				showEncounter				= true;
			}
				// Encounter with kidnappers in the Scorpion
			else if (Clicks == 1 && WarpSystem.Id == StarSystemId.Qonos &&
				QuestStatusPrincess == SpecialEvent.StatusPrincessFlyQonos)
			{
				Opponent						= Scorpion;
				EncounterType				= Commander.Ship.Cloaked ? EncounterType.ScorpionIgnore : EncounterType.ScorpionAttack;
				showEncounter				= true;
			}
				// ah, just when you thought you were gonna get away with it...
			else if (Clicks == 1 && JustLootedMarie)
			{
				GenerateOpponent(OpponentType.Police);
				EncounterType		= EncounterType.MarieCelestePolice;
				JustLootedMarie	= false;

				showEncounter		= true;
			}

			return showEncounter;
		}

		private bool DeterminePirateEncounter(bool mantis)
		{
			bool	showEncounter	= false;

			if (mantis)
			{
				GenerateOpponent(OpponentType.Mantis);
				EncounterType = EncounterType.PirateAttack;
			}
			else
			{
				GenerateOpponent(OpponentType.Pirate);

				// If you have a cloak, they don't see you
				if (Commander.Ship.Cloaked)
					EncounterType	= EncounterType.PirateIgnore;
					// Pirates will mostly attack, but they are cowardly: if your rep is too high, they tend to flee
					// if Pirates are in a better ship, they won't flee, even if you have a very scary
					// reputation.
				else if (Opponent.Type > Commander.Ship.Type || Opponent.Type >= ShipType.Grasshopper ||
					Functions.GetRandom(Consts.ReputationScoreElite) >
					(Commander.ReputationScore * 4) / (1 + (int)Opponent.Type))
					EncounterType = EncounterType.PirateAttack;
				else
					EncounterType = EncounterType.PirateFlee;
			}

			// If they ignore you or flee and you can't see them, the encounter doesn't take place
			// If you automatically don't want to confront someone who ignores you, the
			// encounter may not take place
			if (EncounterType == EncounterType.PirateAttack || !(Opponent.Cloaked || Options.AlwaysIgnorePirates))
				showEncounter	= true;

			return showEncounter;
		}

		private bool DeterminePoliceEncounter()
		{
			bool	showEncounter	= false;

			GenerateOpponent(OpponentType.Police);

			// If you are cloaked, they don't see you
			EncounterType	= EncounterType.PoliceIgnore;
			if (!Commander.Ship.Cloaked)
			{
				if (Commander.PoliceRecordScore < Consts.PoliceRecordScoreDubious)
				{
					// If you're a criminal, the police will tend to attack
					// JAF - fixed this; there was code that didn't do anything.
					// if you're suddenly stuck in a lousy ship, Police won't flee even if you
					// have a fearsome reputation.
					if (Opponent.WeaponStrength() > 0 && (Commander.ReputationScore < Consts.ReputationScoreAverage ||
						Functions.GetRandom(Consts.ReputationScoreElite) >
						(Commander.ReputationScore / (1 + (int)Opponent.Type))) || Opponent.Type > Commander.Ship.Type)
					{
						if (Commander.PoliceRecordScore >= Consts.PoliceRecordScoreCriminal)
							EncounterType	= EncounterType.PoliceSurrender;
						else
							EncounterType	= EncounterType.PoliceAttack;
					}
					else if (Opponent.Cloaked)
						EncounterType	= EncounterType.PoliceIgnore;
					else
						EncounterType	= EncounterType.PoliceFlee;
				}
				else if (!Inspected && (Commander.PoliceRecordScore < Consts.PoliceRecordScoreClean ||
					(Commander.PoliceRecordScore < Consts.PoliceRecordScoreLawful &&
					Functions.GetRandom(12 - (int)Difficulty) < 1) ||
					(Commander.PoliceRecordScore >= Consts.PoliceRecordScoreLawful && Functions.GetRandom(40) == 0)))
				{
					// If you're reputation is dubious, the police will inspect you
					// If your record is clean, the police will inspect you with a chance of 10% on Normal
					// If your record indicates you are a lawful trader, the chance on inspection drops to 2.5%
					EncounterType	= EncounterType.PoliceInspect;
					Inspected			= true;
				}
			}

			// If they ignore you or flee and you can't see them, the encounter doesn't take place
			// If you automatically don't want to confront someone who ignores you, the
			// encounter may not take place.  Otherwise it will - JAF
			if (EncounterType == EncounterType.PoliceAttack || EncounterType == EncounterType.PoliceInspect ||
				!(Opponent.Cloaked || Options.AlwaysIgnorePolice))
				showEncounter	= true;

			return showEncounter;
		}

		private bool DetermineRandomEncounter()
		{
			bool	showEncounter	= false;
			bool	mantis				= false;
			bool	pirate				= false;
			bool	police				= false;
			bool	trader				= false;

			if (WarpSystem.Id == StarSystemId.Gemulon && QuestStatusGemulon == SpecialEvent.StatusGemulonTooLate)
			{
				if (Functions.GetRandom(10) > 4)
					mantis	= true;
			}
			else
			{
				// Check if it is time for an encounter
				int	encounter				= Functions.GetRandom(44 - (2 * (int)Difficulty));
				int	policeModifier	= Math.Max(1, 3 - (int)PoliceRecord.GetPoliceRecordFromScore(Commander.PoliceRecordScore).Type);

				// encounters are half as likely if you're in a flea.
				if (Commander.Ship.Type == ShipType.Flea)
					encounter	*= 2;

				if (encounter < (int)WarpSystem.PoliticalSystem.ActivityPirates)
					// When you are already raided, other pirates have little to gain
					pirate	= !Raided;
				else if (encounter < (int)WarpSystem.PoliticalSystem.ActivityPirates +
					(int)WarpSystem.PoliticalSystem.ActivityPolice * policeModifier)
					// policeModifier adapts itself to your criminal record: you'll
					// encounter more police if you are a hardened criminal.
					police	= true;
				else if (encounter < (int)WarpSystem.PoliticalSystem.ActivityPirates +
					(int)WarpSystem.PoliticalSystem.ActivityPolice * policeModifier +
					(int)WarpSystem.PoliticalSystem.ActivityTraders)
					trader	= true;
				else if (Commander.Ship.WildOnBoard && WarpSystem.Id == StarSystemId.Kravat)
					// if you're coming in to Kravat & you have Wild onboard, there'll be swarms o' cops.
					police	= Functions.GetRandom(100) < 100 / Math.Max(2, Math.Min(4, 5 - (int)Difficulty));
				else if (Commander.Ship.ArtifactOnBoard && Functions.GetRandom(20) <= 3)
					mantis	= true;
			}

			if (police)
				showEncounter	= DeterminePoliceEncounter();
			else if (pirate || mantis)
				showEncounter	= DeterminePirateEncounter(mantis);
			else if (trader)
				showEncounter	= DetermineTraderEncounter();
			else if (Commander.Days > 10 && Functions.GetRandom(1000) < ChanceOfVeryRareEncounter &&
				VeryRareEncounters.Count > 0)
				showEncounter	= DetermineVeryRareEncounter();

			return showEncounter;
		}

		private bool DetermineTraderEncounter()
		{
			bool	showEncounter	= false;

			GenerateOpponent(OpponentType.Trader);

			// If you are cloaked, they don't see you
			EncounterType	= EncounterType.TraderIgnore;
			if (!Commander.Ship.Cloaked)
			{
				// If you're a criminal, traders tend to flee if you've got at least some reputation
				if (!Commander.Ship.Cloaked && Commander.PoliceRecordScore <= Consts.PoliceRecordScoreCriminal &&
					Functions.GetRandom(Consts.ReputationScoreElite) <= (Commander.ReputationScore * 10) / (1 + (int)Opponent.Type))
					EncounterType = EncounterType.TraderFlee;
					// Will there be trade in orbit?
				else if (Functions.GetRandom(1000) < ChanceOfTradeInOrbit)
				{
					if (Commander.Ship.FreeCargoBays > 0 && Opponent.HasTradeableItems())
						EncounterType = EncounterType.TraderSell;
						// we fudge on whether the trader has capacity to carry the stuff he's buying.
					else if (Commander.Ship.HasTradeableItems())
						EncounterType = EncounterType.TraderBuy;
				}
			}

			// If they ignore you or flee and you can't see them, the encounter doesn't take place
			// If you automatically don't want to confront someone who ignores you, the
			// encounter may not take place; otherwise it will.
			if (!Opponent.Cloaked && !(Options.AlwaysIgnoreTraders &&
				(EncounterType == EncounterType.TraderIgnore || EncounterType == EncounterType.TraderFlee)) &&
				!((EncounterType == EncounterType.TraderBuy || EncounterType == EncounterType.TraderSell) &&
				Options.AlwaysIgnoreTradeInOrbit))
				showEncounter	= true;

			return showEncounter;
		}

		private bool DetermineVeryRareEncounter()
		{
			bool	showEncounter	= false;

			// Very Rare Random Events:
			// 1. Encounter the abandoned Marie Celeste, which you may loot.
			// 2. Captain Ahab will trade your Reflective Shield for skill points in Piloting.
			// 3. Captain Conrad will trade your Military Laser for skill points in Engineering.
			// 4. Captain Huie will trade your Military Laser for points in Trading.
			// 5. Encounter an out-of-date bottle of Captain Marmoset's Skill Tonic. This
			//    will affect skills depending on game difficulty level.
			// 6. Encounter a good bottle of Captain Marmoset's Skill Tonic, which will invoke
			//    IncreaseRandomSkill one or two times, depending on game difficulty.
			switch ((VeryRareEncounter)VeryRareEncounters[Functions.GetRandom(VeryRareEncounters.Count)])
			{
				case VeryRareEncounter.MarieCeleste:
					// Marie Celeste cannot be at Acamar, Qonos, or Zalkon as it may cause problems with the
					// Space Monster, Scorpion, or Dragonfly
					if (Clicks > 1 && Commander.CurrentSystemId != StarSystemId.Acamar &&
						Commander.CurrentSystemId != StarSystemId.Zalkon &&
						Commander.CurrentSystemId != StarSystemId.Qonos)
					{
						VeryRareEncounters.Remove(VeryRareEncounter.MarieCeleste);
						EncounterType	= EncounterType.MarieCeleste;
						GenerateOpponent(OpponentType.Trader);
						for (int i = 0; i < Opponent.Cargo.Length; i++)
							Opponent.Cargo[i]	= 0;
						Opponent.Cargo[(int)TradeItemType.Narcotics]	= Math.Min(Opponent.CargoBays, 5);

						showEncounter	= true;
					}
					break;
				case VeryRareEncounter.CaptainAhab:
					if (Commander.Ship.HasShield(ShieldType.Reflective) && Commander.Pilot < 10 &&
						Commander.PoliceRecordScore > Consts.PoliceRecordScoreCriminal)
					{
						VeryRareEncounters.Remove(VeryRareEncounter.CaptainAhab);
						EncounterType	= EncounterType.CaptainAhab;
						GenerateOpponent(OpponentType.FamousCaptain);

						showEncounter	= true;
					}
					break;
				case VeryRareEncounter.CaptainConrad:
					if (Commander.Ship.HasWeapon(WeaponType.MilitaryLaser, true) && Commander.Engineer < 10 &&
						Commander.PoliceRecordScore > Consts.PoliceRecordScoreCriminal)
					{
						VeryRareEncounters.Remove(VeryRareEncounter.CaptainConrad);
						EncounterType	= EncounterType.CaptainConrad;
						GenerateOpponent(OpponentType.FamousCaptain);

						showEncounter	= true;
					}
					break;
				case VeryRareEncounter.CaptainHuie:
					if (Commander.Ship.HasWeapon(WeaponType.MilitaryLaser, true) && Commander.Trader < 10 &&
						Commander.PoliceRecordScore > Consts.PoliceRecordScoreCriminal)
					{
						VeryRareEncounters.Remove(VeryRareEncounter.CaptainHuie);
						EncounterType	= EncounterType.CaptainHuie;
						GenerateOpponent(OpponentType.FamousCaptain);

						showEncounter	= true;
					}
					break;
				case VeryRareEncounter.BottleOld:
					VeryRareEncounters.Remove(VeryRareEncounter.BottleOld);
					EncounterType	= EncounterType.BottleOld;
					GenerateOpponent(OpponentType.Bottle);

					showEncounter	= true;
					break;
				case VeryRareEncounter.BottleGood:
					VeryRareEncounters.Remove(VeryRareEncounter.BottleGood);
					EncounterType	= EncounterType.BottleGood;
					GenerateOpponent(OpponentType.Bottle);

					showEncounter	= true;
					break;
			}

			return showEncounter;
		}

		public void EncounterBegin()
		{
			// Set up the encounter variables.
			EncounterContinueFleeing		=
				EncounterContinueAttacking	=
				OpponentDisabled						= false;
		}

		private void EncounterDefeatDragonfly()
		{
			Commander.KillsPirate++;
			Commander.PoliceRecordScore	+= Consts.ScoreKillPirate;
			QuestStatusDragonfly				= SpecialEvent.StatusDragonflyDestroyed;
		}

		private void EncounterDefeatScarab()
		{
			Commander.KillsPirate++;
			Commander.PoliceRecordScore	+= Consts.ScoreKillPirate;
			QuestStatusScarab						= SpecialEvent.StatusScarabDestroyed;
		}

		private void EncounterDefeatScorpion()
		{
			Commander.KillsPirate++;
			Commander.PoliceRecordScore	+= Consts.ScoreKillPirate;
			QuestStatusPrincess					= SpecialEvent.StatusPrincessRescued;
		}

		public void EncounterDrink(IWin32Window owner)
		{
			if (FormAlert.Alert(AlertType.EncounterDrinkContents, owner) == DialogResult.Yes)
			{
				if (EncounterType == EncounterType.BottleGood)
				{
					// two points if you're on beginner-normal, one otherwise
					Commander.IncreaseRandomSkill();
					if (Difficulty <= Difficulty.Normal)
						Commander.IncreaseRandomSkill();
					FormAlert.Alert(AlertType.EncounterTonicConsumedGood, owner);
				}
				else
				{
					Commander.TonicTweakRandomSkill();
					FormAlert.Alert(AlertType.EncounterTonicConsumedStrange, owner);
				}
			}
		}

		public EncounterResult EncounterExecuteAction(IWin32Window owner)
		{
			EncounterResult	result				= EncounterResult.Continue;
			int							prevCmdrHull	= Commander.Ship.Hull;
			int							prevOppHull		= Opponent.Hull;

			EncounterCmdrHit							= false;
			EncounterOppHit								= false;
			EncounterOppFleeingPrev				= EncounterOppFleeing;
			EncounterOppFleeing						= false;

			// Fire shots
			switch (EncounterType)
			{
				case EncounterType.DragonflyAttack:
				case EncounterType.FamousCaptainAttack:
				case EncounterType.MarieCelestePolice:
				case EncounterType.PirateAttack:
				case EncounterType.PoliceAttack:
				case EncounterType.ScarabAttack:
				case EncounterType.ScorpionAttack:
				case EncounterType.SpaceMonsterAttack:
				case EncounterType.TraderAttack:
					EncounterCmdrHit		= EncounterExecuteAttack(Opponent, Commander.Ship, EncounterCmdrFleeing);
					EncounterOppHit			= !EncounterCmdrFleeing && EncounterExecuteAttack(Commander.Ship, Opponent, false);
					break;
				case EncounterType.PirateFlee:
				case EncounterType.PirateSurrender:
				case EncounterType.PoliceFlee:
				case EncounterType.TraderFlee:
				case EncounterType.TraderSurrender:
					EncounterOppHit			= !EncounterCmdrFleeing && EncounterExecuteAttack(Commander.Ship, Opponent, true);
					EncounterOppFleeing	= true;
					break;
				default:
					EncounterOppHit			= !EncounterCmdrFleeing && EncounterExecuteAttack(Commander.Ship, Opponent, false);
					break;
			}

			// Determine whether someone gets destroyed
			if (Commander.Ship.Hull <= 0)
			{
				if (Commander.Ship.EscapePod)
					result	= EncounterResult.EscapePod;
				else
				{
					FormAlert.Alert(Opponent.Hull <= 0 ? AlertType.EncounterBothDestroyed : AlertType.EncounterYouLose, owner);

					result	= EncounterResult.Killed;
				}
			}
			else if (OpponentDisabled)
			{
				if (Opponent.Type == ShipType.Dragonfly || Opponent.Type == ShipType.Scarab || Opponent.Type == ShipType.Scorpion)
				{
					string str2	= "";

					switch (Opponent.Type)
					{
						case ShipType.Dragonfly:
							EncounterDefeatDragonfly();
							break;
						case ShipType.Scarab:
							EncounterDefeatScarab();
							break;
						case ShipType.Scorpion:
							str2		= Strings.EncounterPrincessRescued;
							EncounterDefeatScorpion();
							break;
					}

					FormAlert.Alert(AlertType.EncounterDisabledOpponent, owner, EncounterShipText, str2);

					Commander.ReputationScore	+= (int)Opponent.Type / 2 + 1;
					result										= EncounterResult.Normal;
				}
				else
				{
					EncounterUpdateEncounterType(prevCmdrHull, prevOppHull);
					EncounterOppFleeing	= false;
				}
			}
			else if (Opponent.Hull <= 0)
			{
				EncounterWon(owner);

				result	= EncounterResult.Normal;
			}
			else
			{
				bool	escaped	= false;

				// Determine whether someone gets away.
				if (EncounterCmdrFleeing && (Difficulty == Difficulty.Beginner ||
					(Functions.GetRandom(7) + Commander.Ship.Pilot / 3) * 2 >=
					Functions.GetRandom(Opponent.Pilot) * (2 + (int)Difficulty)))
				{
					FormAlert.Alert(EncounterCmdrHit ? AlertType.EncounterEscapedHit : AlertType.EncounterEscaped, owner);
					escaped	= true;
				}
				else if (EncounterOppFleeing && Functions.GetRandom(Commander.Ship.Pilot) * 4 <=
					Functions.GetRandom(7 + Opponent.Pilot / 3) * 2)
				{
					FormAlert.Alert(AlertType.EncounterOpponentEscaped, owner);
					escaped	= true;
				}

				if (escaped)
					result	= EncounterResult.Normal;
				else
				{
					// Determine whether the opponent's actions must be changed
					EncounterType	prevEncounter	= EncounterType;

					EncounterUpdateEncounterType(prevCmdrHull, prevOppHull);

					// Update the opponent fleeing flag.
					switch (EncounterType)
					{
						case EncounterType.PirateFlee:
						case EncounterType.PirateSurrender:
						case EncounterType.PoliceFlee:
						case EncounterType.TraderFlee:
						case EncounterType.TraderSurrender:
							EncounterOppFleeing	= true;
							break;
						default:
							EncounterOppFleeing	= false;
							break;
					}

					if (Options.ContinuousAttack && (EncounterCmdrFleeing || !EncounterOppFleeing ||
						Options.ContinuousAttackFleeing && (EncounterType == prevEncounter ||
						EncounterType != EncounterType.PirateSurrender && EncounterType != EncounterType.TraderSurrender)))
					{
						if (EncounterCmdrFleeing)
							EncounterContinueFleeing		= true;
						else
							EncounterContinueAttacking	= true;
					}
				}
			}

			return result;
		}

		private bool EncounterExecuteAttack(Ship attacker, Ship defender, bool fleeing)
		{
			bool	hit	= false;

			// On beginner level, if you flee, you will escape unharmed.
			// Otherwise, Fighterskill attacker is pitted against pilotskill defender; if defender
			// is fleeing the attacker has a free shot, but the chance to hit is smaller
			// JAF - if the opponent is disabled and attacker has targeting system, they WILL be hit.
			if (!(Difficulty == Difficulty.Beginner && defender.CommandersShip && fleeing) &&
				(attacker.CommandersShip && OpponentDisabled && attacker.HasGadget(GadgetType.TargetingSystem) ||
				Functions.GetRandom(attacker.Fighter + (int)defender.Size) >=
				(fleeing ? 2 : 1) * Functions.GetRandom(5 + defender.Pilot / 2)))
			{
				// If the defender is disabled, it only takes one shot to destroy it completely.
				if (attacker.CommandersShip && OpponentDisabled)
					defender.Hull						= 0;
				else
				{
					int	attackerLasers			= attacker.WeaponStrength(WeaponType.PulseLaser, WeaponType.MorgansLaser);
					int attackerDisruptors	= attacker.WeaponStrength(WeaponType.PhotonDisruptor, WeaponType.QuantumDistruptor);

					if (defender.Type == ShipType.Scarab)
					{
						attackerLasers			-= attacker.WeaponStrength(WeaponType.BeamLaser, WeaponType.MilitaryLaser);
						attackerDisruptors	-= attacker.WeaponStrength(WeaponType.PhotonDisruptor, WeaponType.PhotonDisruptor);
					}

					int attackerWeapons			= attackerLasers + attackerDisruptors;

					int disrupt							= 0;

					// Attempt to disable the opponent if they're not already disabled, their shields are down,
					// we have disabling weapons, and the option is checked.
					if (defender.Disableable && defender.ShieldCharge == 0 && !OpponentDisabled &&
						Options.DisableOpponents && attackerDisruptors > 0)
					{
						disrupt	= Functions.GetRandom(attackerDisruptors * (100 + 2 * attacker.Fighter) / 100);
					}
					else
					{
						int	damage	= attackerWeapons == 0 ? 0 :
							Functions.GetRandom(attackerWeapons * (100 + 2 * attacker.Fighter) / 100);

						if (damage > 0)
						{
							hit	= true;

							// Reactor on board -- damage is boosted!
							if (defender.ReactorOnBoard)
								damage	*= (int)(1 + ((int)Difficulty + 1) * (Difficulty < Difficulty.Normal ? 0.25 : 0.33));

							// First, shields are depleted
							for (int i = 0; i < defender.Shields.Length && defender.Shields[i] != null && damage > 0; i++)
							{
								int	applied									 = Math.Min(defender.Shields[i].Charge, damage);
								defender.Shields[i].Charge	-= applied;
								damage											-= applied;
							}

							// If there still is damage after the shields have been depleted,
							// this is subtracted from the hull, modified by the engineering skill
							// of the defender.
							// JAF - If the player only has disabling weapons, no damage will be done to the hull.
							if (damage > 0)
							{
								damage				= Math.Max(1, damage - Functions.GetRandom(defender.Engineer));

								disrupt				= damage * attackerDisruptors / attackerWeapons;

								// Only that damage coming from Lasers will deplete the hull.
								damage				-= disrupt;

								// At least 2 shots on Normal level are needed to destroy the hull
								// (3 on Easy, 4 on Beginner, 1 on Hard or Impossible). For opponents,
								// it is always 2.
								damage				= Math.Min(damage, defender.HullStrength /
									(defender.CommandersShip ? Math.Max(1, Difficulty.Impossible - Difficulty) : 2));

								// If the hull is hardened, damage is halved.
								if (QuestStatusScarab == SpecialEvent.StatusScarabDone)
									damage /= 2;

								defender.Hull	= Math.Max(0, defender.Hull - damage);
							}
						}
					}

					// Did the opponent get disabled? (Disruptors are 3 times more effective against the ship's
					// systems than they are against the shields).
					if (defender.Hull > 0 && defender.Disableable && Functions.GetRandom(100) <
						disrupt * Consts.DisruptorSystemsMultiplier * 100 / defender.Hull)
						OpponentDisabled	= true;

					// Make sure the Scorpion doesn't get destroyed.
					if (defender.Type == ShipType.Scorpion && defender.Hull == 0)
					{
						defender.Hull			= 1;
						OpponentDisabled	= true;
					}
				}
			}

			return hit;
		}

		public void EncounterMeet(IWin32Window owner)
		{
			AlertType			initialAlert	= AlertType.Alert;
			int						skill					= 0;
			EquipmentType	equipType			= EquipmentType.Gadget;
			object				equipSubType	= null;

			switch (EncounterType)
			{
				case EncounterType.CaptainAhab:
					// Trade a reflective shield for skill points in piloting?
					initialAlert	= AlertType.MeetCaptainAhab;
					equipType			= EquipmentType.Shield;
					equipSubType	= ShieldType.Reflective;
					skill					= (int)SkillType.Pilot;

					break;
				case EncounterType.CaptainConrad:
					// Trade a military laser for skill points in engineering?
					initialAlert	= AlertType.MeetCaptainConrad;
					equipType			= EquipmentType.Weapon;
					equipSubType	= WeaponType.MilitaryLaser;
					skill					= (int)SkillType.Engineer;

					break;
				case EncounterType.CaptainHuie:
					// Trade a military laser for skill points in trading?
					initialAlert	= AlertType.MeetCaptainHuie;
					equipType			= EquipmentType.Weapon;
					equipSubType	= WeaponType.MilitaryLaser;
					skill					= (int)SkillType.Trader;

					break;
			}

			if (FormAlert.Alert(initialAlert, owner) == DialogResult.Yes)
			{
				// Remove the equipment we're trading.
				Commander.Ship.RemoveEquipment(equipType, equipSubType);

				// Add points to the appropriate skill - two points if beginner-normal, one otherwise.
				Commander.Skills[skill]	= Math.Min(Consts.MaxSkill, Commander.Skills[skill] +
					(Difficulty <= Difficulty.Normal ? 2 : 1));

				FormAlert.Alert(AlertType.SpecialTrainingCompleted, owner);
			}
		}

		public void EncounterPlunder(IWin32Window owner)
		{
			(new FormPlunder()).ShowDialog(owner);

			if (EncounterType >= EncounterType.TraderAttack)
			{
				Commander.PoliceRecordScore	+= Consts.ScorePlunderTrader;

				if (OpponentDisabled)
					Commander.KillsTrader++;
			}
			else if (OpponentDisabled)
			{
				if (Commander.PoliceRecordScore >= Consts.PoliceRecordScoreDubious)
				{
					FormAlert.Alert(AlertType.EncounterPiratesBounty, owner, Strings.EncounterPiratesDisabled,
						Strings.EncounterPiratesLocation, Functions.Multiples(Opponent.Bounty(), Strings.MoneyUnit));

					Commander.Cash	+= Opponent.Bounty();
				}

				Commander.KillsPirate++;
				Commander.PoliceRecordScore	+= Consts.ScoreKillPirate;
			}
			else
				Commander.PoliceRecordScore	+= Consts.ScorePlunderPirate;

			Commander.ReputationScore	+= (int)Opponent.Type / 2 + 1;
		}

		private void EncounterScoop(IWin32Window owner)
		{
			// Chance 50% to pick something up on Normal level, 33% on Hard level, 25% on
			// Impossible level, and 100% on Easy or Beginner.
			if ((Difficulty < Difficulty.Normal || Functions.GetRandom((int)Difficulty) == 0) &&
				Opponent.FilledCargoBays > 0)
			{
				// Changed this to actually pick a good that was in the opponent's cargo hold - JAF.
				int	index			= Functions.GetRandom(Opponent.FilledCargoBays);
				int	tradeItem	= -1;
				for (int sum = 0; sum <= index; sum += Opponent.Cargo[++tradeItem]);

				if (FormAlert.Alert(AlertType.EncounterScoop, owner, Consts.TradeItems[tradeItem].Name) == DialogResult.Yes)
				{
					bool	jettisoned	= false;

					if (Commander.Ship.FreeCargoBays == 0 &&
						FormAlert.Alert(AlertType.EncounterScoopNoRoom, owner) == DialogResult.Yes)
					{
						(new FormJettison()).ShowDialog(owner);
						jettisoned	= true;
					}

					if (Commander.Ship.FreeCargoBays > 0)
						Commander.Ship.Cargo[tradeItem]++;
					else if (jettisoned)
						FormAlert.Alert(AlertType.EncounterScoopNoScoop, owner);
				}
			}
		}

		public void EncounterTrade(IWin32Window owner)
		{
			bool		buy				= (EncounterType == EncounterType.TraderBuy);
			int			item			= (buy ? Commander.Ship : Opponent).GetRandomTradeableItem();
			string	alertStr	= (buy ? Strings.CargoSelling : Strings.CargoBuying);

			int			cash			= Commander.Cash;

			if (EncounterType == EncounterType.TraderBuy)
				CargoSellTrader(item, owner);
			else // EncounterType.TraderSell
				CargoBuyTrader(item, owner);

			if (Commander.Cash != cash)
				FormAlert.Alert(AlertType.EncounterTradeCompleted, owner, alertStr, Consts.TradeItems[item].Name);
		}

		private void EncounterUpdateEncounterType(int prevCmdrHull, int prevOppHull)
		{
			int	chance	= Functions.GetRandom(100);

			if (Opponent.Hull < prevOppHull || OpponentDisabled)
			{
				switch (EncounterType)
				{
					case EncounterType.FamousCaptainAttack:
						if (OpponentDisabled)
							EncounterType	= EncounterType.FamousCaptDisabled;
						break;
					case EncounterType.PirateAttack:
					case EncounterType.PirateFlee:
					case EncounterType.PirateSurrender:
						if (OpponentDisabled)
							EncounterType	= EncounterType.PirateDisabled;
						else if (Opponent.Hull < (prevOppHull * 2) / 3)
						{
							if (Commander.Ship.Hull < (prevCmdrHull * 2) / 3)
							{
								if (chance < 60)
									EncounterType	= EncounterType.PirateFlee;
							}
							else
							{
								if (chance < 10 && Opponent.Type != ShipType.Mantis)
									EncounterType	= EncounterType.PirateSurrender;
								else
									EncounterType	= EncounterType.PirateFlee;
							}
						}
						break;
					case EncounterType.PoliceAttack:
					case EncounterType.PoliceFlee:
						if (OpponentDisabled)
							EncounterType	= EncounterType.PoliceDisabled;
						else if (Opponent.Hull < prevOppHull / 2 && (Commander.Ship.Hull >= prevCmdrHull / 2 || chance < 40))
							EncounterType	= EncounterType.PoliceFlee;
						break;
					case EncounterType.TraderAttack:
					case EncounterType.TraderFlee:
					case EncounterType.TraderSurrender:
						if (OpponentDisabled)
							EncounterType	= EncounterType.TraderDisabled;
						else if (Opponent.Hull < (prevOppHull * 2) / 3)
						{
							if (chance < 60)
								EncounterType	= EncounterType.TraderSurrender;
							else
								EncounterType	= EncounterType.TraderFlee;
						}
							// If you get damaged a lot, the trader tends to keep shooting; if
							// you get damaged a little, the trader may keep shooting; if you
							// get damaged very little or not at all, the trader will flee.
						else if (Opponent.Hull < (prevOppHull * 9) / 10 &&
							(Commander.Ship.Hull < (prevCmdrHull * 2) / 3 && chance < 20 ||
							Commander.Ship.Hull < (prevCmdrHull * 9) / 10 && chance < 60 ||
							Commander.Ship.Hull >= (prevCmdrHull * 9) / 10))
							EncounterType	= EncounterType.TraderFlee;
						break;
					default:
						break;
				}
			}
		}

		public bool EncounterVerifyAttack(IWin32Window owner)
		{
			bool	attack	= true;

			if (Commander.Ship.WeaponStrength() == 0)
			{
				FormAlert.Alert(AlertType.EncounterAttackNoWeapons, owner);
				attack	= false;
			}
			else if (!Opponent.Disableable && Commander.Ship.WeaponStrength(WeaponType.PulseLaser, WeaponType.MorgansLaser) == 0)
			{
				FormAlert.Alert(AlertType.EncounterAttackNoLasers, owner);
				attack	= false;
			}
			else if (Opponent.Type == ShipType.Scorpion && Commander.Ship.WeaponStrength(WeaponType.PhotonDisruptor, WeaponType.QuantumDistruptor) == 0)
			{
				FormAlert.Alert(AlertType.EncounterAttackNoDisruptors, owner);
				attack	= false;
			}
			else
			{
				switch (EncounterType)
				{
					case EncounterType.DragonflyIgnore:
					case EncounterType.PirateIgnore:
					case EncounterType.ScarabIgnore:
					case EncounterType.ScorpionIgnore:
					case EncounterType.SpaceMonsterIgnore:
						EncounterType	= EncounterType - 1;

						break;
					case EncounterType.PoliceInspect:
						if (!Commander.Ship.DetectableIllegalCargoOrPassengers &&
							FormAlert.Alert(AlertType.EncounterPoliceNothingIllegal, owner) != DialogResult.Yes)
							attack	= false;

						// Fall through...
						if (attack)
							goto case EncounterType.PoliceIgnore;

						break;
					case EncounterType.MarieCelestePolice:
					case EncounterType.PoliceFlee:
					case EncounterType.PoliceIgnore:
					case EncounterType.PoliceSurrender:
						if (Commander.PoliceRecordScore <= Consts.PoliceRecordScoreCriminal ||
							FormAlert.Alert(AlertType.EncounterAttackPolice, owner) == DialogResult.Yes)
						{
							if (Commander.PoliceRecordScore > Consts.PoliceRecordScoreCriminal)
								Commander.PoliceRecordScore	= Consts.PoliceRecordScoreCriminal;

							Commander.PoliceRecordScore	+= Consts.ScoreAttackPolice;

							if (EncounterType != EncounterType.PoliceFlee)
								EncounterType = EncounterType.PoliceAttack;
						}
						else
							attack	= false;

						break;
					case EncounterType.TraderBuy:
					case EncounterType.TraderIgnore:
					case EncounterType.TraderSell:
						if (Commander.PoliceRecordScore < Consts.PoliceRecordScoreClean)
							Commander.PoliceRecordScore	+= Consts.ScoreAttackTrader;
						else if (FormAlert.Alert(AlertType.EncounterAttackTrader, owner) == DialogResult.Yes)
							Commander.PoliceRecordScore	= Consts.PoliceRecordScoreDubious;
						else
							attack	= false;

						// Fall through...
						if (attack)
							goto case EncounterType.TraderAttack;

						break;
					case EncounterType.TraderAttack:
					case EncounterType.TraderSurrender:
						if (Functions.GetRandom(Consts.ReputationScoreElite) <=
							Commander.ReputationScore * 10 / ((int)Opponent.Type + 1) || Opponent.WeaponStrength() == 0)
							EncounterType = EncounterType.TraderFlee;
						else
							EncounterType = EncounterType.TraderAttack;

						break;
					case EncounterType.CaptainAhab:
					case EncounterType.CaptainConrad:
					case EncounterType.CaptainHuie:
						if (FormAlert.Alert(AlertType.EncounterAttackCaptain, owner) == DialogResult.Yes)
						{
							if (Commander.PoliceRecordScore > Consts.PoliceRecordScoreVillain)
								Commander.PoliceRecordScore	= Consts.PoliceRecordScoreVillain;

							Commander.PoliceRecordScore	+= Consts.ScoreAttackTrader;

							switch (EncounterType)
							{
								case EncounterType.CaptainAhab:
									NewsAddEvent(NewsEvent.CaptAhabAttacked);
									break;
								case EncounterType.CaptainConrad:
									NewsAddEvent(NewsEvent.CaptConradAttacked);
									break;
								case EncounterType.CaptainHuie:
									NewsAddEvent(NewsEvent.CaptHuieAttacked);
									break;
							}

							EncounterType	= EncounterType.FamousCaptainAttack;
						}
						else
							attack	= false;

						break;
				}

				// Make sure the fleeing flag isn't set if we're attacking.
				if (attack)
					EncounterCmdrFleeing	= false;
			}

			return attack;
		}

		public bool EncounterVerifyBoard(IWin32Window owner)
		{
			bool board	= false;

			if (FormAlert.Alert(AlertType.EncounterMarieCeleste, owner) == DialogResult.Yes)
			{
				board			= true;

				int	narcs	= Commander.Ship.Cargo[(int)TradeItemType.Narcotics];

				(new FormPlunder()).ShowDialog(owner);

				if (Commander.Ship.Cargo[(int)TradeItemType.Narcotics] > narcs)
					JustLootedMarie	= true;
			}

			return board;
		}

		public bool EncounterVerifyBribe(IWin32Window owner)
		{
			bool bribed	= false;

			if (EncounterType == EncounterType.MarieCelestePolice)
				FormAlert.Alert(AlertType.EncounterMarieCelesteNoBribe, owner);
			else if (WarpSystem.PoliticalSystem.BribeLevel <= 0)
				FormAlert.Alert(AlertType.EncounterPoliceBribeCant, owner);
			else if (Commander.Ship.DetectableIllegalCargoOrPassengers ||
				FormAlert.Alert(AlertType.EncounterPoliceNothingIllegal, owner) == DialogResult.Yes)
			{
				// Bribe depends on how easy it is to bribe the police and commander's current worth
				int diffMod	= 10 + 5 * (Difficulty.Impossible - Difficulty);
				int	passMod	= Commander.Ship.IllegalSpecialCargo ? (Difficulty <= Difficulty.Normal ? 2 : 3) : 1;

				int	bribe		= Math.Max(100, Math.Min(10000, (int)Math.Ceiling((double)Commander.Worth /
					WarpSystem.PoliticalSystem.BribeLevel / diffMod / 100) * 100 * passMod));

				if (FormAlert.Alert(AlertType.EncounterPoliceBribe, owner, Functions.Multiples(bribe, Strings.MoneyUnit)) ==
					DialogResult.Yes)
				{
					if (Commander.Cash >= bribe)
					{
						Commander.Cash	-= bribe;
						bribed					= true;
					}
					else
						FormAlert.Alert(AlertType.EncounterPoliceBribeLowCash, owner);
				}
			}

			return bribed;
		}

		public bool EncounterVerifyFlee(IWin32Window owner)
		{
			EncounterCmdrFleeing	= false;

			if (EncounterType != EncounterType.PoliceInspect || Commander.Ship.DetectableIllegalCargoOrPassengers ||
				FormAlert.Alert(AlertType.EncounterPoliceNothingIllegal, owner) == DialogResult.Yes)
			{
				EncounterCmdrFleeing	= true;

				if (EncounterType == EncounterType.MarieCelestePolice &&
					FormAlert.Alert(AlertType.EncounterPostMarieFlee, owner) == DialogResult.No)
				{
					EncounterCmdrFleeing = false;
				}
				else if (EncounterType == EncounterType.PoliceInspect || EncounterType == EncounterType.MarieCelestePolice)
				{
					int	scoreMod								= EncounterType == EncounterType.PoliceInspect ?
						Consts.ScoreFleePolice : Consts.ScoreAttackPolice;
					int	scoreMin								= EncounterType == EncounterType.PoliceInspect ? Consts.PoliceRecordScoreDubious -
						(Difficulty < Difficulty.Normal ? 0 : 1) : Consts.PoliceRecordScoreCriminal;

					EncounterType								= EncounterType.PoliceAttack;
					Commander.PoliceRecordScore	= Math.Min(Commander.PoliceRecordScore + scoreMod, scoreMin);
				}
			}

			return EncounterCmdrFleeing;
		}

		public bool EncounterVerifySubmit(IWin32Window owner)
		{
			bool submit	= false;

			if (Commander.Ship.DetectableIllegalCargoOrPassengers)
			{
				string	str1	= Commander.Ship.IllegalSpecialCargoDescription("", true, true);
				string	str2	= Commander.Ship.IllegalSpecialCargo ? Strings.EncounterPoliceSubmitArrested : "";

				if (FormAlert.Alert(AlertType.EncounterPoliceSubmit, owner, str1, str2) == DialogResult.Yes)
				{
					submit	= true;

					// If you carry illegal goods, they are impounded and you are fined
					if (Commander.Ship.DetectableIllegalCargo)
					{
						Commander.Ship.RemoveIllegalGoods();

						int	fine				= (int)Math.Max(100, Math.Min(10000, Math.Ceiling((double)Commander.Worth /
							((Difficulty.Impossible - Difficulty + 2) * 10) / 50) * 50));
						int	cashPayment	= Math.Min(Commander.Cash, fine);
						Commander.Debt	+= fine - cashPayment;
						Commander.Cash	-= cashPayment;

						FormAlert.Alert(AlertType.EncounterPoliceFine, owner, Functions.Multiples(fine, Strings.MoneyUnit));

						Commander.PoliceRecordScore	+= Consts.ScoreTrafficking;
					}
				}
			}
			else
			{
				submit	= true;

				// If you aren't carrying illegal cargo or passengers, the police will increase your lawfulness record
				FormAlert.Alert(AlertType.EncounterPoliceNothingFound, owner);
				Commander.PoliceRecordScore	-= Consts.ScoreTrafficking;
			}

			return submit;
		}

		public EncounterResult EncounterVerifySurrender(IWin32Window owner)
		{
			EncounterResult result	= EncounterResult.Continue;

			if (Opponent.Type == ShipType.Mantis)
			{
				if (Commander.Ship.ArtifactOnBoard)
				{
					if (FormAlert.Alert(AlertType.EncounterAliensSurrender, owner) == DialogResult.Yes)
					{
						FormAlert.Alert(AlertType.ArtifactRelinquished, owner);
						QuestStatusArtifact	= SpecialEvent.StatusArtifactNotStarted;

						result	= EncounterResult.Normal;
					}
				}
				else
					FormAlert.Alert(AlertType.EncounterSurrenderRefused, owner);
			}
			else if (EncounterType == EncounterType.PoliceAttack || EncounterType == EncounterType.PoliceSurrender)
			{
				if (Commander.PoliceRecordScore <= Consts.PoliceRecordScorePsychopath)
					FormAlert.Alert(AlertType.EncounterSurrenderRefused, owner);
				else if (FormAlert.Alert(AlertType.EncounterPoliceSurrender, owner,
					new string[] { Commander.Ship.IllegalSpecialCargoDescription(Strings.EncounterPoliceSurrenderCargo, true, false),
												 Commander.Ship.IllegalSpecialCargoActions() }) == DialogResult.Yes)
					result		= EncounterResult.Arrested;
			}
			else if (Commander.Ship.PrincessOnBoard && !Commander.Ship.HasGadget(GadgetType.HiddenCargoBays))
			{
				FormAlert.Alert(AlertType.EncounterPiratesSurrenderPrincess, owner);
			}
			else
			{
				Raided	= true;

				if (Commander.Ship.HasGadget(GadgetType.HiddenCargoBays))
				{
					ArrayList	precious	= new ArrayList();
					if (Commander.Ship.PrincessOnBoard)
						precious.Add(Strings.EncounterHidePrincess);
					if (Commander.Ship.SculptureOnBoard)
						precious.Add(Strings.EncounterHideSculpture);

					FormAlert.Alert(AlertType.PreciousHidden, owner,
						Functions.StringVars(Strings.ListStrings[precious.Count],
						(string[])precious.ToArray(System.Type.GetType("System.String"))));
				}
				else if (Commander.Ship.SculptureOnBoard)
				{
					QuestStatusSculpture	= SpecialEvent.StatusSculptureNotStarted;
					FormAlert.Alert(AlertType.EncounterPiratesTakeSculpture, owner);
				}

				ArrayList	cargoToSteal	= Commander.Ship.StealableCargo;
				if (cargoToSteal.Count == 0)
				{
					int	blackmail				 = Math.Min(25000, Math.Max(500, Commander.Worth / 20));
					int	cashPayment			 = Math.Min(Commander.Cash, blackmail);
					Commander.Debt	+= blackmail - cashPayment;
					Commander.Cash	-= cashPayment;
					FormAlert.Alert(AlertType.EncounterPiratesFindNoCargo, owner,
						Functions.Multiples(blackmail, Strings.MoneyUnit));
				}
				else
				{
					FormAlert.Alert(AlertType.EncounterLooting, owner);

					// Pirates steal as much as they have room for, which could be everything - JAF.
					// Take most high-priced items - JAF.
					while (Opponent.FreeCargoBays > 0 && cargoToSteal.Count > 0)
					{
						int item	= (int)cargoToSteal[0];

						Commander.PriceCargo[item]	-= Commander.PriceCargo[item] / Commander.Ship.Cargo[item];
						Commander.Ship.Cargo[item]--;
						Opponent.Cargo[item]++;

						cargoToSteal.RemoveAt(0);
					}
				}

				if (Commander.Ship.WildOnBoard)
				{
					if (Opponent.CrewQuarters > 1)
					{
						// Wild hops onto Pirate Ship
						QuestStatusWild	= SpecialEvent.StatusWildNotStarted;
						FormAlert.Alert(AlertType.WildGoesPirates, owner);
					}
					else
						// no room on pirate ship
						FormAlert.Alert(AlertType.WildChatsPirates, owner);
				}

				// pirates puzzled by reactor
				if (Commander.Ship.ReactorOnBoard)
					FormAlert.Alert(AlertType.EncounterPiratesExamineReactor, owner);

				result	= EncounterResult.Normal;
			}

			return result;
		}

		public EncounterResult EncounterVerifyYield(IWin32Window owner)
		{
			EncounterResult result	= EncounterResult.Continue;

			if (Commander.Ship.IllegalSpecialCargo)
			{
				if (FormAlert.Alert(AlertType.EncounterPoliceSurrender, owner,
					new string[] { Commander.Ship.IllegalSpecialCargoDescription(Strings.EncounterPoliceSurrenderCargo, true, true),
												 Commander.Ship.IllegalSpecialCargoActions() }) == DialogResult.Yes)
					result	= EncounterResult.Arrested;
			}
			else
			{
				string	str1	= Commander.Ship.IllegalSpecialCargoDescription("", false, true);

				if (FormAlert.Alert(AlertType.EncounterPoliceSubmit, owner, str1, "") == DialogResult.Yes)
				{
					// Police Record becomes dubious, if it wasn't already.
					if (Commander.PoliceRecordScore > Consts.PoliceRecordScoreDubious)
						Commander.PoliceRecordScore	= Consts.PoliceRecordScoreDubious;

					Commander.Ship.RemoveIllegalGoods();

					result	= EncounterResult.Normal;
				}
			}

			return result;
		}

		private void EncounterWon(IWin32Window owner)
		{
			if (EncounterType >= EncounterType.PirateAttack && EncounterType <= EncounterType.PirateDisabled &&
				Opponent.Type != ShipType.Mantis && Commander.PoliceRecordScore >= Consts.PoliceRecordScoreDubious)
				FormAlert.Alert(AlertType.EncounterPiratesBounty, owner, Strings.EncounterPiratesDestroyed, "",
					Functions.Multiples(Opponent.Bounty(), Strings.MoneyUnit));
			else
				FormAlert.Alert(AlertType.EncounterYouWin, owner);

			switch (EncounterType)
			{
				case EncounterType.FamousCaptainAttack:
					Commander.KillsTrader++;
					if (Commander.ReputationScore < Consts.ReputationScoreDangerous)
						Commander.ReputationScore	= Consts.ReputationScoreDangerous;
					else
						Commander.ReputationScore	+= Consts.ScoreKillCaptain;

					// bump news flag from attacked to ship destroyed
					NewsReplaceEvent(NewsLatestEvent(), NewsLatestEvent() + 1);
					break;
				case EncounterType.DragonflyAttack:
					EncounterDefeatDragonfly();
					break;
				case EncounterType.PirateAttack:
				case EncounterType.PirateFlee:
				case EncounterType.PirateSurrender:
					Commander.KillsPirate++;
					if (Opponent.Type != ShipType.Mantis)
					{
						if (Commander.PoliceRecordScore >= Consts.PoliceRecordScoreDubious)
							Commander.Cash	+= Opponent.Bounty();
						Commander.PoliceRecordScore	+= Consts.ScoreKillPirate;
						EncounterScoop(owner);
					}
					break;
				case EncounterType.PoliceAttack:
				case EncounterType.PoliceFlee:
					Commander.KillsPolice++;
					Commander.PoliceRecordScore	+= Consts.ScoreKillPolice;
					break;
				case EncounterType.ScarabAttack:
					EncounterDefeatScarab();
					break;
				case EncounterType.SpaceMonsterAttack:
					Commander.KillsPirate++;
					Commander.PoliceRecordScore	+= Consts.ScoreKillPirate;
					QuestStatusSpaceMonster			= SpecialEvent.StatusSpaceMonsterDestroyed;
					break;
				case EncounterType.TraderAttack:
				case EncounterType.TraderFlee:
				case EncounterType.TraderSurrender:
					Commander.KillsTrader++;
					Commander.PoliceRecordScore	+= Consts.ScoreKillTrader;
					EncounterScoop(owner);
					break;
				default:
					break;
			}

			Commander.ReputationScore	+= (int)Opponent.Type / 2 + 1;
		}

		public void EscapeWithPod()
		{
			FormAlert.Alert(AlertType.EncounterEscapePodActivated, ParentWindow);

			if (Commander.Ship.SculptureOnBoard)
				FormAlert.Alert(AlertType.SculptureSaved, ParentWindow);

			if (Commander.Ship.ReactorOnBoard)
			{
				FormAlert.Alert(AlertType.ReactorDestroyed, ParentWindow);
				QuestStatusReactor	= SpecialEvent.StatusReactorDone;
			}

			if (Commander.Ship.Tribbles > 0)
				FormAlert.Alert(AlertType.TribblesKilled, ParentWindow);

			if (QuestStatusJapori == SpecialEvent.StatusJaporiInTransit)
			{
				int	system;
				for (system = 0; system < Universe.Length && Universe[system].SpecialEventType != SpecialEventType.Japori; system++);
				FormAlert.Alert(AlertType.AntidoteDestroyed, ParentWindow, Universe[system].Name);
				QuestStatusJapori = SpecialEvent.StatusJaporiNotStarted;
			}

			if (Commander.Ship.ArtifactOnBoard)
			{
				FormAlert.Alert(AlertType.ArtifactLost, ParentWindow);
				QuestStatusArtifact	= SpecialEvent.StatusArtifactDone;
			}

			if (Commander.Ship.JarekOnBoard)
			{
				FormAlert.Alert(AlertType.JarekTakenHome, ParentWindow);
				QuestStatusJarek = SpecialEvent.StatusJarekNotStarted;
			}

			if (Commander.Ship.PrincessOnBoard)
			{
				FormAlert.Alert(AlertType.PrincessTakenHome, ParentWindow);
				QuestStatusPrincess	= SpecialEvent.StatusPrincessNotStarted;
			}

			if (Commander.Ship.WildOnBoard)
			{
				FormAlert.Alert(AlertType.WildArrested, ParentWindow);
				Commander.PoliceRecordScore	+= Consts.ScoreCaughtWithWild;
				NewsAddEvent(NewsEvent.WildArrested);
				QuestStatusWild = SpecialEvent.StatusWildNotStarted;
			}

			if (Commander.Insurance)
			{
				FormAlert.Alert(AlertType.InsurancePayoff, ParentWindow);
				Commander.Cash	+= Commander.Ship.BaseWorth(true);
			}

			if (Commander.Cash > Consts.FleaConversionCost)
				Commander.Cash	-= Consts.FleaConversionCost;
			else
			{
				Commander.Debt	+= Consts.FleaConversionCost - Commander.Cash;
				Commander.Cash	 = 0;
			}

			FormAlert.Alert(AlertType.FleaBuilt, ParentWindow);

			IncDays(3, ParentWindow);

			CreateFlea();
		}

		private bool FindDistantSystem(StarSystemId baseSystem, SpecialEventType specEvent)
		{
			int	bestDistance	= 999;
			int	system				= -1;
			for (int i = 0; i < Universe.Length; i++)
			{
				int	distance	= Functions.Distance(Universe[(int)baseSystem], Universe[i]);
				if (distance >= 70 && distance < bestDistance && Universe[i].SpecialEventType == SpecialEventType.NA)
				{
					system				= i;
					bestDistance	= distance;
				}
			}
			if (system >= 0)
				Universe[system].SpecialEventType	= specEvent;

			return (system >= 0);
		}

		private void GenerateCrewMemberList()
		{
			int[]	used	= new int[Universe.Length];
			int		d			= (int)Difficulty;

			// Zeethibal may be on Kravat
			used[(int)StarSystemId.Kravat]	= 1;

			// special individuals:
			// Zeethibal, Jonathan Wild's Nephew - skills will be set later.
			// Wild, Jonathan Wild earns his keep now - JAF.
			// Jarek, Ambassador Jarek earns his keep now - JAF.
			// Dummy pilots for opponents.
			Mercenaries[(int)CrewMemberId.Zeethibal]			= new CrewMember(CrewMemberId.Zeethibal,      5,  5,  5,  5, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.Opponent]				= new CrewMember(CrewMemberId.Opponent,       5,  5,  5,  5, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.Wild]						= new CrewMember(CrewMemberId.Wild,           7, 10,  2,  5, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.Jarek]					= new CrewMember(CrewMemberId.Jarek,          3,  2, 10,  4, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.Princess]				= new CrewMember(CrewMemberId.Princess,       4,  3,  8,  9, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.FamousCaptain]	= new CrewMember(CrewMemberId.FamousCaptain, 10, 10, 10, 10, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.Dragonfly]			= new CrewMember(CrewMemberId.Dragonfly,    4 + d, 6 + d, 1, 6 + d, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.Scarab]					= new CrewMember(CrewMemberId.Scarab,       5 + d, 6 + d, 1, 6 + d, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.Scorpion]				= new CrewMember(CrewMemberId.Scorpion,     8 + d, 8 + d, 1, 6 + d, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.SpaceMonster]		= new CrewMember(CrewMemberId.SpaceMonster, 8 + d, 8 + d, 1, 1 + d, StarSystemId.NA);

			// JAF - Changing this to allow multiple mercenaries in each system, but no more
			// than three.
			for (int i = 1; i < Mercenaries.Length; i++)
			{
				// Only create a CrewMember object if one doesn't already exist in this slot in the array.
				if (Mercenaries[i] == null)
				{
					StarSystemId	id;
					bool					ok	= false;

					do
					{
						id	= (StarSystemId)Functions.GetRandom(Universe.Length);
						if (used[(int)id] < 3)
						{
							used[(int)id]++;
							ok	= true;
						}
					} while (!ok);

					Mercenaries[i]	= new CrewMember((CrewMemberId)i, Functions.RandomSkill(), Functions.RandomSkill(), Functions.RandomSkill(), Functions.RandomSkill(), id);
				}
			}
		}

		private void GenerateOpponent(OpponentType oppType)
		{
			Opponent	= new Ship(oppType);
		}

		private void GenerateUniverse()
		{
			_universe	= new StarSystem[Strings.SystemNames.Length];

			int	i, j;

			for (i = 0; i < Universe.Length; i++)
			{
				StarSystemId		id				= (StarSystemId)i;
				SystemPressure	pressure	= SystemPressure.None;
				SpecialResource	specRes		= SpecialResource.Nothing;
				Size						size			= (Size)Functions.GetRandom((int)Size.Huge + 1);
				PoliticalSystem	polSys		= Consts.PoliticalSystems[Functions.GetRandom(Consts.PoliticalSystems.Length)];
				TechLevel				tech			= (TechLevel)Functions.GetRandom((int)polSys.MinimumTechLevel, (int)polSys.MaximumTechLevel + 1);

				// Galvon must be a Monarchy.
				if (id == StarSystemId.Galvon)
				{
					size		= Size.Large;
					polSys	= Consts.PoliticalSystems[(int)PoliticalSystemType.Monarchy];
					tech		= TechLevel.HiTech;
				}

				if (Functions.GetRandom(100) < 15)
					pressure	= (SystemPressure)Functions.GetRandom((int)SystemPressure.War, (int)SystemPressure.Employment + 1);
				if (Functions.GetRandom(5) >= 3)
					specRes		= (SpecialResource)Functions.GetRandom((int)SpecialResource.MineralRich, (int)SpecialResource.Warlike + 1);

				int							x					= 0;
				int							y					= 0;

				if (i < Wormholes.Length)
				{
					// Place the first systems somewhere in the center.
					x	= ((Consts.GalaxyWidth * (1 + 2 * ( i % 3))) / 6) - Functions.GetRandom(-Consts.CloseDistance + 1, Consts.CloseDistance);
					y	= ((Consts.GalaxyHeight * (i < 3 ? 1 : 3)) / 4) - Functions.GetRandom(-Consts.CloseDistance + 1, Consts.CloseDistance);
					Wormholes[i]	= i;
				}
				else
				{
					bool	ok	= false;
					while (!ok)
					{
						x	= Functions.GetRandom(1, Consts.GalaxyWidth);
						y	= Functions.GetRandom(1, Consts.GalaxyHeight);

						bool	closeFound	= false;
						bool	tooClose		= false;
						for (j = 0; j < i && !tooClose; j++)
						{
							//  Minimum distance between any two systems not to be accepted.
							if (Functions.Distance(Universe[j], x, y) < Consts.MinDistance)
								tooClose	= true;

							// There should be at least one system which is close enough.
							if (Functions.Distance(Universe[j], x, y) < Consts.CloseDistance)
								closeFound	= true;
						}
						ok	= (closeFound && !tooClose);
					}
				}

				Universe[i]	= new StarSystem(id, x, y, size, tech, polSys.Type, pressure, specRes);
			}

			// Randomize the system locations a bit more, otherwise the systems with the first
			// names in the alphabet are all in the center.
			for (i = 0; i < Universe.Length; i++)
			{
				j	= Functions.GetRandom(Universe.Length);
				if (!Functions.WormholeExists(j, -1))
				{
					int	x	= Universe[i].X;
					int	y	= Universe[i].Y;
					Universe[i].X	= Universe[j].X;
					Universe[i].Y	= Universe[j].Y;
					Universe[j].X	= x;
					Universe[j].Y	= y;

					int	w	= Array.IndexOf(Wormholes, i);
					if (w >= 0)
						Wormholes[w]	= j;
				}
			}

			// Randomize wormhole order
			for (i = 0; i < Wormholes.Length; i++)
			{
				j	= Functions.GetRandom(Wormholes.Length);
				int	w	= Wormholes[i];
				Wormholes[i]	= Wormholes[j];
				Wormholes[j]	= w;
			}
		}

		public void HandleSpecialEvent()
		{
			StarSystem	curSys	= Commander.CurrentSystem;
			bool				remove	= true;

			switch (curSys.SpecialEventType)
			{
				case SpecialEventType.Artifact:
					QuestStatusArtifact	= SpecialEvent.StatusArtifactOnBoard;
					break;
				case SpecialEventType.ArtifactDelivery:
					QuestStatusArtifact	= SpecialEvent.StatusArtifactDone;
					break;
				case SpecialEventType.CargoForSale:
					FormAlert.Alert(AlertType.SpecialSealedCanisters, ParentWindow);
					int	tradeItem										 = Functions.GetRandom(Consts.TradeItems.Length);
					Commander.Ship.Cargo[tradeItem]	+= 3;
					Commander.PriceCargo[tradeItem]	+= Commander.CurrentSystem.SpecialEvent.Price;
					break;
				case SpecialEventType.Dragonfly:
				case SpecialEventType.DragonflyBaratas:
				case SpecialEventType.DragonflyMelina:
				case SpecialEventType.DragonflyRegulas:
					QuestStatusDragonfly++;
					break;
				case SpecialEventType.DragonflyDestroyed:
					curSys.SpecialEventType	= SpecialEventType.DragonflyShield;
					remove									= false;
					break;
				case SpecialEventType.DragonflyShield:
					if (Commander.Ship.FreeSlotsShield == 0)
					{
						FormAlert.Alert(AlertType.EquipmentNotEnoughSlots, ParentWindow);
						remove	= false;
					}
					else
					{
						FormAlert.Alert(AlertType.EquipmentLightningShield, ParentWindow);
						Commander.Ship.AddEquipment(Consts.Shields[(int)ShieldType.Lightning]);
						QuestStatusDragonfly	= SpecialEvent.StatusDragonflyDone;
					}
					break;
				case SpecialEventType.EraseRecord:
					FormAlert.Alert(AlertType.SpecialCleanRecord, ParentWindow);
					Commander.PoliceRecordScore	= Consts.PoliceRecordScoreClean;
					RecalculateSellPrices(curSys);
					break;
				case SpecialEventType.Experiment:
					QuestStatusExperiment	= SpecialEvent.StatusExperimentStarted;
					break;
				case SpecialEventType.ExperimentFailed:
					break;
				case SpecialEventType.ExperimentStopped:
					QuestStatusExperiment	= SpecialEvent.StatusExperimentCancelled;
					CanSuperWarp					= true;
					break;
				case SpecialEventType.Gemulon:
					QuestStatusGemulon	= SpecialEvent.StatusGemulonStarted;
					break;
				case SpecialEventType.GemulonFuel:
					if (Commander.Ship.FreeSlotsGadget == 0)
					{
						FormAlert.Alert(AlertType.EquipmentNotEnoughSlots, ParentWindow);
						remove	= false;
					}
					else
					{
						FormAlert.Alert(AlertType.EquipmentFuelCompactor, ParentWindow);
						Commander.Ship.AddEquipment(Consts.Gadgets[(int)GadgetType.FuelCompactor]);
						QuestStatusGemulon	= SpecialEvent.StatusGemulonDone;
					}
					break;
				case SpecialEventType.GemulonRescued:
					curSys.SpecialEventType	= SpecialEventType.GemulonFuel;
					QuestStatusGemulon			= SpecialEvent.StatusGemulonFuel;
					remove									= false;
					break;
				case SpecialEventType.Japori:
					// The japori quest should not be removed since you can fail and start it over again.
					remove	= false;

					if (Commander.Ship.FreeCargoBays < 10)
						FormAlert.Alert(AlertType.CargoNoEmptyBays, ParentWindow);
					else
					{
						FormAlert.Alert(AlertType.AntidoteOnBoard, ParentWindow);
						QuestStatusJapori	= SpecialEvent.StatusJaporiInTransit;
					}
					break;
				case SpecialEventType.JaporiDelivery:
					QuestStatusJapori	= SpecialEvent.StatusJaporiDone;
					Commander.IncreaseRandomSkill();
					Commander.IncreaseRandomSkill();
					break;
				case SpecialEventType.Jarek:
					if (Commander.Ship.FreeCrewQuarters == 0)
					{
						FormAlert.Alert(AlertType.SpecialNoQuarters, ParentWindow);
						remove	= false;
					}
					else
					{
						CrewMember	jarek	= Mercenaries[(int)CrewMemberId.Jarek];
						FormAlert.Alert(AlertType.SpecialPassengerOnBoard, ParentWindow, jarek.Name);
						Commander.Ship.Hire(jarek);
						QuestStatusJarek	= SpecialEvent.StatusJarekStarted;
					}
					break;
				case SpecialEventType.JarekGetsOut:
					QuestStatusJarek	= SpecialEvent.StatusJarekDone;
					Commander.Ship.Fire(CrewMemberId.Jarek);
					break;
				case SpecialEventType.Lottery:
					break;
				case SpecialEventType.Moon:
					FormAlert.Alert(AlertType.SpecialMoonBought, ParentWindow);
					QuestStatusMoon	= SpecialEvent.StatusMoonBought;
					break;
				case SpecialEventType.MoonRetirement:
					QuestStatusMoon	= SpecialEvent.StatusMoonDone;
					throw new GameEndException(GameEndType.BoughtMoon);
				case SpecialEventType.Princess:
					curSys.SpecialEventType	= SpecialEventType.PrincessReturned;
					remove									= false;
					QuestStatusPrincess++;
					break;
				case SpecialEventType.PrincessCentauri:
				case SpecialEventType.PrincessInthara:
					QuestStatusPrincess++;
					break;
				case SpecialEventType.PrincessQonos:
					if (Commander.Ship.FreeCrewQuarters == 0)
					{
						FormAlert.Alert(AlertType.SpecialNoQuarters, ParentWindow);
						remove	= false;
					}
					else
					{
						CrewMember	princess	= Mercenaries[(int)CrewMemberId.Princess];
						FormAlert.Alert(AlertType.SpecialPassengerOnBoard, ParentWindow, princess.Name);
						Commander.Ship.Hire(princess);
					}
					break;
				case SpecialEventType.PrincessQuantum:
					if (Commander.Ship.FreeSlotsWeapon == 0)
					{
						FormAlert.Alert(AlertType.EquipmentNotEnoughSlots, ParentWindow);
						remove	= false;
					}
					else
					{
						FormAlert.Alert(AlertType.EquipmentQuantumDisruptor, ParentWindow);
						Commander.Ship.AddEquipment(Consts.Weapons[(int)WeaponType.QuantumDistruptor]);
						QuestStatusPrincess	= SpecialEvent.StatusPrincessDone;
					}
					break;
				case SpecialEventType.PrincessReturned:
					Commander.Ship.Fire(CrewMemberId.Princess);
					curSys.SpecialEventType	= SpecialEventType.PrincessQuantum;
					QuestStatusPrincess			= SpecialEvent.StatusPrincessReturned;
					remove									= false;
					break;
				case SpecialEventType.Reactor:
					if (Commander.Ship.FreeCargoBays < 15)
					{
						FormAlert.Alert(AlertType.CargoNoEmptyBays, ParentWindow);
						remove	= false;
					}
					else
					{
						if (Commander.Ship.WildOnBoard)
						{
							if (FormAlert.Alert(AlertType.WildWontStayAboardReactor, ParentWindow, curSys.Name) ==
								DialogResult.OK)
							{
								FormAlert.Alert(AlertType.WildLeavesShip, ParentWindow, curSys.Name);
								QuestStatusWild	= SpecialEvent.StatusWildNotStarted;
							}
							else
								remove	= false;
						}

						if (remove)
						{
							FormAlert.Alert(AlertType.ReactorOnBoard, ParentWindow);
							QuestStatusReactor	= SpecialEvent.StatusReactorFuelOk;
						}
					}
					break;
				case SpecialEventType.ReactorDelivered:
					curSys.SpecialEventType	= SpecialEventType.ReactorLaser;
					QuestStatusReactor			= SpecialEvent.StatusReactorDelivered;
					remove									= false;
					break;
				case SpecialEventType.ReactorLaser:
					if (Commander.Ship.FreeSlotsWeapon == 0)
					{
						FormAlert.Alert(AlertType.EquipmentNotEnoughSlots, ParentWindow);
						remove	= false;
					}
					else
					{
						FormAlert.Alert(AlertType.EquipmentMorgansLaser, ParentWindow);
						Commander.Ship.AddEquipment(Consts.Weapons[(int)WeaponType.MorgansLaser]);
						QuestStatusReactor	= SpecialEvent.StatusReactorDone;
					}
					break;
				case SpecialEventType.Scarab:
					QuestStatusScarab	= SpecialEvent.StatusScarabHunting;
					break;
				case SpecialEventType.ScarabDestroyed:
					QuestStatusScarab				= SpecialEvent.StatusScarabDestroyed;
					curSys.SpecialEventType	= SpecialEventType.ScarabUpgradeHull;
					remove									= false;
					break;
				case SpecialEventType.ScarabUpgradeHull:
					FormAlert.Alert(AlertType.ShipHullUpgraded, ParentWindow);
					Commander.Ship.HullUpgraded	=  true;
					Commander.Ship.Hull					+= Consts.HullUpgrade;
					QuestStatusScarab						=  SpecialEvent.StatusScarabDone;
					remove											=  false;
					break;
				case SpecialEventType.Sculpture:
					QuestStatusSculpture	= SpecialEvent.StatusSculptureInTransit;
					break;
				case SpecialEventType.SculptureDelivered:
					QuestStatusSculpture		= SpecialEvent.StatusSculptureDelivered;
					curSys.SpecialEventType	= SpecialEventType.SculptureHiddenBays;
					remove									= false;
					break;
				case SpecialEventType.SculptureHiddenBays:
					QuestStatusSculpture	= SpecialEvent.StatusSculptureDone;
					if (Commander.Ship.FreeSlotsGadget == 0)
					{
						FormAlert.Alert(AlertType.EquipmentNotEnoughSlots, ParentWindow);
						remove	= false;
					}
					else
					{
						FormAlert.Alert(AlertType.EquipmentHiddenCompartments, ParentWindow);
						Commander.Ship.AddEquipment(Consts.Gadgets[(int)GadgetType.HiddenCargoBays]);
						QuestStatusSculpture	= SpecialEvent.StatusSculptureDone;
					}
					break;
				case SpecialEventType.Skill:
					FormAlert.Alert(AlertType.SpecialSkillIncrease, ParentWindow);
					Commander.IncreaseRandomSkill();
					break;
				case SpecialEventType.SpaceMonster:
					QuestStatusSpaceMonster	= SpecialEvent.StatusSpaceMonsterAtAcamar;
					break;
				case SpecialEventType.SpaceMonsterKilled:
					QuestStatusSpaceMonster	= SpecialEvent.StatusSpaceMonsterDone;
					break;
				case SpecialEventType.Tribble:
					FormAlert.Alert(AlertType.TribblesOwn, ParentWindow);
					Commander.Ship.Tribbles	= 1;
					break;
				case SpecialEventType.TribbleBuyer:
					FormAlert.Alert(AlertType.TribblesGone, ParentWindow);
					Commander.Cash					+= Commander.Ship.Tribbles / 2;
					Commander.Ship.Tribbles	 = 0;
					break;
				case SpecialEventType.Wild:
					if (Commander.Ship.FreeCrewQuarters == 0)
					{
						FormAlert.Alert(AlertType.SpecialNoQuarters, ParentWindow);
						remove	= false;
					}
					else if (!Commander.Ship.HasWeapon(WeaponType.BeamLaser, false))
					{
						FormAlert.Alert(AlertType.WildWontBoardLaser, ParentWindow);
						remove	= false;
					}
					else if (Commander.Ship.ReactorOnBoard)
					{
						FormAlert.Alert(AlertType.WildWontBoardReactor, ParentWindow);
						remove	= false;
					}
					else
					{
						CrewMember	wild	= Mercenaries[(int)CrewMemberId.Wild];
						FormAlert.Alert(AlertType.SpecialPassengerOnBoard, ParentWindow, wild.Name);
						Commander.Ship.Hire(wild);
						QuestStatusWild	= SpecialEvent.StatusWildStarted;

						if (Commander.Ship.SculptureOnBoard)
							FormAlert.Alert(AlertType.WildSculpture, ParentWindow);
					}
					break;
				case SpecialEventType.WildGetsOut:
					// Zeethibal has a 10 in player's lowest score, an 8
					// in the next lowest score, and 5 elsewhere.
					CrewMember	zeethibal		= Mercenaries[(int)CrewMemberId.Zeethibal];
					zeethibal.CurrentSystem	= Universe[(int)StarSystemId.Kravat];
					int					lowest1			= Commander.NthLowestSkill(1);
					int					lowest2			= Commander.NthLowestSkill(2);
					for (int i = 0; i < zeethibal.Skills.Length; i++)
						zeethibal.Skills[i]	= (i == lowest1 ? 10 : (i == lowest2 ? 8 : 5));

					QuestStatusWild							= SpecialEvent.StatusWildDone;
					Commander.PoliceRecordScore	= Consts.PoliceRecordScoreClean;
					Commander.Ship.Fire(CrewMemberId.Wild);
					RecalculateSellPrices(curSys);
					break;
			}

			if (curSys.SpecialEvent.Price != 0)
				Commander.Cash	-= curSys.SpecialEvent.Price;

			if (remove)
				curSys.SpecialEventType	= SpecialEventType.NA;
		}

		public void IncDays(int num, IWin32Window owner)
		{
			Commander.Days	+= num;

			if (Commander.Insurance)
				Commander.NoClaim	+= num;

			// Police Record will gravitate towards neutral (0).
			if (Commander.PoliceRecordScore > Consts.PoliceRecordScoreClean)
				Commander.PoliceRecordScore	= Math.Max(Consts.PoliceRecordScoreClean, Commander.PoliceRecordScore - num / 3);
			else if (Commander.PoliceRecordScore < Consts.PoliceRecordScoreDubious)
				Commander.PoliceRecordScore	= Math.Min(Consts.PoliceRecordScoreDubious, Commander.PoliceRecordScore + num / 
					(Difficulty <= Difficulty.Normal ? 1 : (int)Difficulty));

			// The Space Monster's strength increases 5% per day until it is back to full strength.
			if (SpaceMonster.Hull < SpaceMonster.HullStrength)
				SpaceMonster.Hull	= Math.Min(SpaceMonster.HullStrength, (int)(SpaceMonster.Hull * Math.Pow(1.05, num)));

			if (QuestStatusGemulon > SpecialEvent.StatusGemulonNotStarted &&
				QuestStatusGemulon < SpecialEvent.StatusGemulonTooLate)
			{
				QuestStatusGemulon	= Math.Min(QuestStatusGemulon + num, SpecialEvent.StatusGemulonTooLate);
				if (QuestStatusGemulon == SpecialEvent.StatusGemulonTooLate)
				{
					StarSystem	gemulon					= Universe[(int)StarSystemId.Gemulon];
					gemulon.SpecialEventType		= SpecialEventType.GemulonInvaded;
					gemulon.TechLevel						= TechLevel.PreAgricultural;
					gemulon.PoliticalSystemType	= PoliticalSystemType.Anarchy;
				}
			}

			if (Commander.Ship.ReactorOnBoard)
				QuestStatusReactor	= Math.Min(QuestStatusReactor + num, SpecialEvent.StatusReactorDate);

			if (QuestStatusExperiment > SpecialEvent.StatusExperimentNotStarted &&
				QuestStatusExperiment < SpecialEvent.StatusExperimentPerformed)
			{
				QuestStatusExperiment	= Math.Min(QuestStatusExperiment + num, SpecialEvent.StatusExperimentPerformed);
				if (QuestStatusExperiment == SpecialEvent.StatusExperimentPerformed)
				{
					FabricRipProbability																= Consts.FabricRipInitialProbability;
					Universe[(int)StarSystemId.Daled].SpecialEventType	= SpecialEventType.ExperimentFailed;
					FormAlert.Alert(AlertType.SpecialExperimentPerformed, owner);
					NewsAddEvent(NewsEvent.ExperimentPerformed);
				}
			}
			else if (QuestStatusExperiment == SpecialEvent.StatusExperimentPerformed && FabricRipProbability > 0)
				FabricRipProbability	-= num;

			if (Commander.Ship.JarekOnBoard)
			{
				if (QuestStatusJarek == SpecialEvent.StatusJarekImpatient / 2)
					FormAlert.Alert(AlertType.SpecialPassengerConcernedJarek, owner);
				else if (QuestStatusJarek == SpecialEvent.StatusJarekImpatient - 1)
				{
					FormAlert.Alert(AlertType.SpecialPassengerImpatientJarek, owner);
					Mercenaries[(int)CrewMemberId.Jarek].Pilot		= 0;
					Mercenaries[(int)CrewMemberId.Jarek].Fighter	= 0;
					Mercenaries[(int)CrewMemberId.Jarek].Trader		= 0;
					Mercenaries[(int)CrewMemberId.Jarek].Engineer	= 0;
				}

				if (QuestStatusJarek < SpecialEvent.StatusJarekImpatient)
					QuestStatusJarek++;
			}

			if (Commander.Ship.PrincessOnBoard)
			{
				if (QuestStatusPrincess == (SpecialEvent.StatusPrincessImpatient + SpecialEvent.StatusPrincessRescued) / 2)
					FormAlert.Alert(AlertType.SpecialPassengerConcernedPrincess, owner);
				else if (QuestStatusPrincess == SpecialEvent.StatusPrincessImpatient - 1)
				{
					FormAlert.Alert(AlertType.SpecialPassengerImpatientPrincess, owner);
					Mercenaries[(int)CrewMemberId.Princess].Pilot			= 0;
					Mercenaries[(int)CrewMemberId.Princess].Fighter		= 0;
					Mercenaries[(int)CrewMemberId.Princess].Trader		= 0;
					Mercenaries[(int)CrewMemberId.Princess].Engineer	= 0;
				}

				if (QuestStatusPrincess < SpecialEvent.StatusPrincessImpatient)
					QuestStatusPrincess++;
			}

			if (Commander.Ship.WildOnBoard)
			{
				if (QuestStatusWild == SpecialEvent.StatusWildImpatient / 2)
					FormAlert.Alert(AlertType.SpecialPassengerConcernedWild, owner);
				else if (QuestStatusWild == SpecialEvent.StatusWildImpatient - 1)
				{
					FormAlert.Alert(AlertType.SpecialPassengerImpatientWild, owner);
					Mercenaries[(int)CrewMemberId.Wild].Pilot			= 0;
					Mercenaries[(int)CrewMemberId.Wild].Fighter		= 0;
					Mercenaries[(int)CrewMemberId.Wild].Trader		= 0;
					Mercenaries[(int)CrewMemberId.Wild].Engineer	= 0;
				}

				if (QuestStatusWild < SpecialEvent.StatusWildImpatient)
					QuestStatusWild++;
			}
		}

		private void InitializeCommander(string name, CrewMember commanderCrewMember)
		{
			_commander																						= new Commander(commanderCrewMember);
			Mercenaries[(int)CrewMemberId.Commander]							= Commander;
			Strings.CrewMemberNames[(int)CrewMemberId.Commander]	= name;

			while (Commander.CurrentSystem == null)
			{
				StarSystem	system	= Universe[Functions.GetRandom(Universe.Length)];
				if (system.SpecialEventType == SpecialEventType.NA &&
					system.TechLevel > TechLevel.PreAgricultural &&
					system.TechLevel < TechLevel.HiTech)
				{
					// Make sure at least three other systems can be reached
					int	close	= 0;
					for (int i = 0; i < Universe.Length && close < 3; i++)
					{
						if (i != (int)system.Id && Functions.Distance(Universe[i], system) <= Commander.Ship.FuelTanks)
							close++;
					}

					if (close >= 3)
						Commander.CurrentSystem	= system;
				}
			}

			Commander.CurrentSystem.Visited	= true;
		}

		public void NewsAddEvent(NewsEvent newEvent)
		{
			NewsEvents.Add(newEvent);
		}

		public void NewsAddEventsOnArrival()
		{
			if (Commander.CurrentSystem.SpecialEventType != SpecialEventType.NA)
			{
				switch (Commander.CurrentSystem.SpecialEventType)
				{
					case SpecialEventType.ArtifactDelivery:
						if (Commander.Ship.ArtifactOnBoard)
							NewsAddEvent(NewsEvent.ArtifactDelivery);
						break;
					case SpecialEventType.Dragonfly:
						NewsAddEvent(NewsEvent.Dragonfly);
						break;
					case SpecialEventType.DragonflyBaratas:
						if (QuestStatusDragonfly == SpecialEvent.StatusDragonflyFlyBaratas)
							NewsAddEvent(NewsEvent.DragonflyBaratas);
						break;
					case SpecialEventType.DragonflyDestroyed:
						if (QuestStatusDragonfly == SpecialEvent.StatusDragonflyFlyZalkon)
							NewsAddEvent(NewsEvent.DragonflyZalkon);
						else if (QuestStatusDragonfly == SpecialEvent.StatusDragonflyDestroyed)
							NewsAddEvent(NewsEvent.DragonflyDestroyed);
						break;
					case SpecialEventType.DragonflyMelina:
						if (QuestStatusDragonfly == SpecialEvent.StatusDragonflyFlyMelina)
							NewsAddEvent(NewsEvent.DragonflyMelina);
						break;
					case SpecialEventType.DragonflyRegulas:
						if (QuestStatusDragonfly == SpecialEvent.StatusDragonflyFlyRegulas)
							NewsAddEvent(NewsEvent.DragonflyRegulas);
						break;
					case SpecialEventType.ExperimentFailed:
						NewsAddEvent(NewsEvent.ExperimentFailed);
						break;
					case SpecialEventType.ExperimentStopped:
						if (QuestStatusExperiment > SpecialEvent.StatusExperimentNotStarted &&
							QuestStatusExperiment < SpecialEvent.StatusExperimentPerformed)
							NewsAddEvent(NewsEvent.ExperimentStopped);
						break;
					case SpecialEventType.Gemulon:
						NewsAddEvent(NewsEvent.Gemulon);
						break;
					case SpecialEventType.GemulonRescued:
						if (QuestStatusGemulon > SpecialEvent.StatusGemulonNotStarted)
						{
							if (QuestStatusGemulon < SpecialEvent.StatusGemulonTooLate)
								NewsAddEvent(NewsEvent.GemulonRescued);
							else
								NewsAddEvent(NewsEvent.GemulonInvaded);
						}
						break;
					case SpecialEventType.Japori:
						if (QuestStatusJapori == SpecialEvent.StatusJaporiNotStarted)
							NewsAddEvent(NewsEvent.Japori);
						break;
					case SpecialEventType.JaporiDelivery:
						if (QuestStatusJapori == SpecialEvent.StatusJaporiInTransit)
							NewsAddEvent(NewsEvent.JaporiDelivery);
						break;
					case SpecialEventType.JarekGetsOut:
						if (Commander.Ship.JarekOnBoard)
							NewsAddEvent(NewsEvent.JarekGetsOut);
						break;
					case SpecialEventType.Princess:
						NewsAddEvent(NewsEvent.Princess);
						break;
					case SpecialEventType.PrincessCentauri:
						if (QuestStatusPrincess == SpecialEvent.StatusPrincessFlyCentauri)
							NewsAddEvent(NewsEvent.PrincessCentauri);
						break;
					case SpecialEventType.PrincessInthara:
						if (QuestStatusPrincess == SpecialEvent.StatusPrincessFlyInthara)
							NewsAddEvent(NewsEvent.PrincessInthara);
						break;
					case SpecialEventType.PrincessQonos:
						if (QuestStatusPrincess == SpecialEvent.StatusPrincessFlyQonos)
							NewsAddEvent(NewsEvent.PrincessQonos);
						else if (QuestStatusPrincess == SpecialEvent.StatusPrincessRescued)
							NewsAddEvent(NewsEvent.PrincessRescued);
						break;
					case SpecialEventType.PrincessReturned:
						if (QuestStatusPrincess == SpecialEvent.StatusPrincessReturned)
							NewsAddEvent(NewsEvent.PrincessReturned);
						break;
					case SpecialEventType.Scarab:
						NewsAddEvent(NewsEvent.Scarab);
						break;
					case SpecialEventType.ScarabDestroyed:
						if (QuestStatusScarab == SpecialEvent.StatusScarabHunting)
							NewsAddEvent(NewsEvent.ScarabHarass);
						else if (QuestStatusScarab >= SpecialEvent.StatusScarabDestroyed)
							NewsAddEvent(NewsEvent.ScarabDestroyed);
						break;
					case SpecialEventType.Sculpture:
						NewsAddEvent(NewsEvent.SculptureStolen);
						break;
					case SpecialEventType.SculptureDelivered:
						NewsAddEvent(NewsEvent.SculptureTracked);
						break;
					case SpecialEventType.SpaceMonsterKilled:
						if (QuestStatusSpaceMonster == SpecialEvent.StatusSpaceMonsterAtAcamar)
							NewsAddEvent(NewsEvent.SpaceMonster);
						else if (QuestStatusSpaceMonster >= SpecialEvent.StatusSpaceMonsterDestroyed)
							NewsAddEvent(NewsEvent.SpaceMonsterKilled);
						break;
					case SpecialEventType.WildGetsOut:
						if (Commander.Ship.WildOnBoard)
							NewsAddEvent(NewsEvent.WildGetsOut);
						break;
				}
			}
		}

		public NewsEvent NewsLatestEvent()
		{
			return (NewsEvent)NewsEvents[NewsEvents.Count - 1];
		}

		public void NewsReplaceEvent(NewsEvent oldEvent, NewsEvent newEvent)
		{
			if (NewsEvents.IndexOf(oldEvent) >= 0)
				NewsEvents.Remove(oldEvent);
			NewsEvents.Add(newEvent);
		}

		public void NewsResetEvents()
		{
			NewsEvents.Clear();
		}

		private void NormalDeparture(int fuel)
		{
			Commander.Cash			-= (MercenaryCosts + InsuranceCosts + WormholeCosts);
			Commander.Ship.Fuel	-= fuel;
			Commander.PayInterest();
			IncDays(1, ParentWindow);
		}

		private bool PlaceShipyards()
		{
			bool			goodUniverse	= true;

			ArrayList	systemIdList	= new ArrayList();
			for (int system = 0; system < Universe.Length; system++)
			{
				if (Universe[system].TechLevel	== TechLevel.HiTech)
					systemIdList.Add(system);
			}

			if (systemIdList.Count < Consts.Shipyards.Length)
				goodUniverse	= false;
			else
			{
				// Assign the shipyards to High-Tech systems.
				for (int shipyard = 0; shipyard < Consts.Shipyards.Length; shipyard++)
					Universe[(int)systemIdList[Functions.GetRandom(systemIdList.Count)]].ShipyardId	= (ShipyardId)shipyard;
			}

			return goodUniverse;
		}

		private bool PlaceSpecialEvents()
		{
			bool	goodUniverse	= true;
			int		system;

			Universe[(int)StarSystemId.Baratas].SpecialEventType	= SpecialEventType.DragonflyBaratas;
			Universe[(int)StarSystemId.Melina].SpecialEventType		= SpecialEventType.DragonflyMelina;
			Universe[(int)StarSystemId.Regulas].SpecialEventType	= SpecialEventType.DragonflyRegulas;
			Universe[(int)StarSystemId.Zalkon].SpecialEventType		= SpecialEventType.DragonflyDestroyed;
			Universe[(int)StarSystemId.Daled].SpecialEventType		= SpecialEventType.ExperimentStopped;
			Universe[(int)StarSystemId.Gemulon].SpecialEventType	= SpecialEventType.GemulonRescued;
			Universe[(int)StarSystemId.Japori].SpecialEventType		= SpecialEventType.JaporiDelivery;
			Universe[(int)StarSystemId.Devidia].SpecialEventType	= SpecialEventType.JarekGetsOut;
			Universe[(int)StarSystemId.Utopia].SpecialEventType		= SpecialEventType.MoonRetirement;
			Universe[(int)StarSystemId.Nix].SpecialEventType			= SpecialEventType.ReactorDelivered;
			Universe[(int)StarSystemId.Acamar].SpecialEventType		= SpecialEventType.SpaceMonsterKilled;
			Universe[(int)StarSystemId.Kravat].SpecialEventType		= SpecialEventType.WildGetsOut;
			Universe[(int)StarSystemId.Endor].SpecialEventType		= SpecialEventType.SculptureDelivered;
			Universe[(int)StarSystemId.Galvon].SpecialEventType		= SpecialEventType.Princess;
			Universe[(int)StarSystemId.Centauri].SpecialEventType	= SpecialEventType.PrincessCentauri;
			Universe[(int)StarSystemId.Inthara].SpecialEventType	= SpecialEventType.PrincessInthara;
			Universe[(int)StarSystemId.Qonos].SpecialEventType		= SpecialEventType.PrincessQonos;

			// Assign a wormhole location endpoint for the Scarab.
			for (system = 0; system < Wormholes.Length &&
				Universe[Wormholes[system]].SpecialEventType != SpecialEventType.NA; system++);
			if (system < Wormholes.Length)
				Universe[Wormholes[system]].SpecialEventType	= SpecialEventType.ScarabDestroyed;
			else
				goodUniverse	= false;

			// Find a Hi-Tech system without a special event.
			if (goodUniverse)
			{
				for (system = 0; system < Universe.Length &&
					!(Universe[system].SpecialEventType == SpecialEventType.NA &&
					Universe[system].TechLevel == TechLevel.HiTech); system++);
				if (system < Universe.Length)
					Universe[system].SpecialEventType	= SpecialEventType.ArtifactDelivery;
				else
					goodUniverse	= false;
			}

			// Find the closest system at least 70 parsecs away from Nix that doesn't already have a special event.
			if (goodUniverse && !FindDistantSystem(StarSystemId.Nix, SpecialEventType.Reactor))
				goodUniverse	= false;

			// Find the closest system at least 70 parsecs away from Gemulon that doesn't already have a special event.
			if (goodUniverse && !FindDistantSystem(StarSystemId.Gemulon, SpecialEventType.Gemulon))
				goodUniverse	= false;

			// Find the closest system at least 70 parsecs away from Daled that doesn't already have a special event.
			if (goodUniverse && !FindDistantSystem(StarSystemId.Daled, SpecialEventType.Experiment))
				goodUniverse	= false;

			// Find the closest system at least 70 parsecs away from Endor that doesn't already have a special event.
			if (goodUniverse && !FindDistantSystem(StarSystemId.Endor, SpecialEventType.Sculpture))
				goodUniverse	= false;

			// Assign the rest of the events randomly.
			if (goodUniverse)
			{
				for (int i = 0; i < Consts.SpecialEvents.Length; i++)
				{
					for (int j = 0; j < Consts.SpecialEvents[i].Occurrence; j++)
					{
						do
						{
							system	= Functions.GetRandom(Universe.Length);
						}
						while (Universe[system].SpecialEventType != SpecialEventType.NA);
					
						Universe[system].SpecialEventType	= Consts.SpecialEvents[i].Type;
					}
				}
			}

			return goodUniverse;
		}

		public void RecalculateBuyPrices(StarSystem system)
		{
			for (int i = 0; i < Consts.TradeItems.Length; i++)
			{
				if (!system.ItemTraded(Consts.TradeItems[i]))
					_priceCargoBuy[i]	= 0;
				else
				{
					_priceCargoBuy[i]	= _priceCargoSell[i];

					if (Commander.PoliceRecordScore < Consts.PoliceRecordScoreDubious)
						_priceCargoBuy[i]	= _priceCargoBuy[i] * 100 / 90;

					// BuyPrice = SellPrice + 1 to 12% (depending on trader skill (minimum is 1, max 12))
					_priceCargoBuy[i]	= _priceCargoBuy[i] * (103 + Consts.MaxSkill - Commander.Ship.Trader) / 100;

					if (_priceCargoBuy[i] <= _priceCargoSell[i])
						_priceCargoBuy[i]	= _priceCargoSell[i] + 1;
				}
			}
		}

		// *************************************************************************
		// After erasure of police record, selling prices must be recalculated
		// *************************************************************************
		public void RecalculateSellPrices(StarSystem system)
		{
			for (int i = 0; i < Consts.TradeItems.Length; i++)
				_priceCargoSell[i]	= _priceCargoSell[i] * 100 / 90;
		}

		public void ResetVeryRareEncounters()
		{
			VeryRareEncounters.Clear();
			VeryRareEncounters.Add(VeryRareEncounter.MarieCeleste);
			VeryRareEncounters.Add(VeryRareEncounter.CaptainAhab);
			VeryRareEncounters.Add(VeryRareEncounter.CaptainConrad);
			VeryRareEncounters.Add(VeryRareEncounter.CaptainHuie);
			VeryRareEncounters.Add(VeryRareEncounter.BottleOld);
			VeryRareEncounters.Add(VeryRareEncounter.BottleGood);
		}

		public void SelectNextSystemWithinRange(bool forward)
		{
			int[]	dest	= Destinations;

			if (dest.Length > 0)
			{
				int	index	= Array.IndexOf(dest, (int)WarpSystemId);

				if (index < 0)
					index	= forward ? 0 : dest.Length - 1;
				else
					index	= (dest.Length + index + (forward ? 1 : -1)) % dest.Length;

				if (Functions.WormholeExists(Commander.CurrentSystem, Universe[dest[index]]))
				{
					SelectedSystemId	= Commander.CurrentSystemId;
					TargetWormhole		= true;
				}
				else
					SelectedSystemId	= (StarSystemId)dest[index];
			}
		}

		public void ShowNewspaper()
		{
			if (!PaidForNewspaper)
			{
				int	cost	= (int)Difficulty + 1;

				if (Commander.Cash < cost)
					FormAlert.Alert(AlertType.ArrivalIFNewspaper, ParentWindow, Functions.Multiples(cost, "credit"));
				else if (Options.NewsAutoPay || FormAlert.Alert(AlertType.ArrivalBuyNewspaper, ParentWindow,
					Functions.Multiples(cost, "credit")) == DialogResult.Yes)
				{
					Commander.Cash		-= cost;
					PaidForNewspaper	= true;
					ParentWindow.UpdateAll();
				}
			}

			if (PaidForNewspaper)
				FormAlert.Alert(AlertType.Alert, ParentWindow, NewspaperHead, NewspaperText);
		}

		public override Hashtable Serialize()
		{
			Hashtable	hash	= base.Serialize();

			hash.Add("_version",										"2.00");
			hash.Add("_universe",										ArrayToArrayList(_universe));
			hash.Add("_commander",									_commander.Serialize());
			hash.Add("_wormholes",									_wormholes);
			hash.Add("_mercenaries",								ArrayToArrayList(_mercenaries));
			hash.Add("_dragonfly",									_dragonfly.Serialize());
			hash.Add("_scarab",											_scarab.Serialize());
			hash.Add("_scorpion",										_scorpion.Serialize());
			hash.Add("_spaceMonster",								_spaceMonster.Serialize());
			hash.Add("_opponent",										_opponent.Serialize());
			hash.Add("_chanceOfTradeInOrbit",				_chanceOfTradeInOrbit);
			hash.Add("_clicks",											_clicks);
			hash.Add("_raided",											_raided);
			hash.Add("_inspected",									_inspected);
			hash.Add("_tribbleMessage",							_tribbleMessage);
			hash.Add("_arrivedViaWormhole",					_arrivedViaWormhole);
			hash.Add("_paidForNewspaper",						_paidForNewspaper);
			hash.Add("_litterWarning",							_litterWarning);
			hash.Add("_newsEvents",									ArrayListToIntArray(_newsEvents));
			hash.Add("_difficulty",									(int)_difficulty);
			hash.Add("_cheatEnabled",								_cheatEnabled);
			hash.Add("_autoSave",										_autoSave);
			hash.Add("_easyEncounters",							_easyEncounters);
			hash.Add("_endStatus",									(int)_endStatus);
			hash.Add("_encounterType",							(int)_encounterType);
			hash.Add("_selectedSystemId",						(int)_selectedSystemId);
			hash.Add("_warpSystemId",								(int)_warpSystemId);
			hash.Add("_trackedSystemId",						(int)_trackedSystemId);
			hash.Add("_targetWormhole",							_targetWormhole);
			hash.Add("_priceCargoBuy",							_priceCargoBuy);
			hash.Add("_priceCargoSell",							_priceCargoSell);
			hash.Add("_questStatusArtifact",				_questStatusArtifact);
			hash.Add("_questStatusDragonfly",				_questStatusDragonfly);
			hash.Add("_questStatusExperiment",			_questStatusExperiment);
			hash.Add("_questStatusGemulon",					_questStatusGemulon);
			hash.Add("_questStatusJapori",					_questStatusJapori);
			hash.Add("_questStatusJarek",						_questStatusJarek);
			hash.Add("_questStatusMoon",						_questStatusMoon);
			hash.Add("_questStatusPrincess",				_questStatusPrincess);
			hash.Add("_questStatusReactor",					_questStatusReactor);
			hash.Add("_questStatusScarab",					_questStatusScarab);
			hash.Add("_questStatusSculpture",				_questStatusSculpture);
			hash.Add("_questStatusSpaceMonster",		_questStatusSpaceMonster);
			hash.Add("_questStatusWild",						_questStatusWild);
			hash.Add("_fabricRipProbability",				_fabricRipProbability);
			hash.Add("_justLootedMarie",						_justLootedMarie);
			hash.Add("_canSuperWarp",								_canSuperWarp);
			hash.Add("_chanceOfVeryRareEncounter",	_chanceOfVeryRareEncounter);
			hash.Add("_veryRareEncounters",					ArrayListToIntArray(_veryRareEncounters));
			hash.Add("_options",										_options.Serialize());

			return hash;
		}

		// Returns true if an encounter occurred.
		public bool Travel()
		{
			// if timespace is ripped, we may switch the warp system here.
			if (QuestStatusExperiment == SpecialEvent.StatusExperimentPerformed && FabricRipProbability > 0 &&
				(FabricRipProbability == Consts.FabricRipInitialProbability || Functions.GetRandom(100) < FabricRipProbability))
			{
				FormAlert.Alert(AlertType.SpecialTimespaceFabricRip, ParentWindow);
				SelectedSystemId	= (StarSystemId)Functions.GetRandom(Universe.Length);
			}

			bool	uneventful	= true;
			Raided						= false;
			Inspected					= false;
			LitterWarning			= false;

			Clicks						= Consts.StartClicks;
			while (Clicks > 0)
			{
				Commander.Ship.PerformRepairs();

				if (DetermineEncounter())
				{
					uneventful					= false;

					FormEncounter	form	= new FormEncounter();
					form.ShowDialog(ParentWindow);
					ParentWindow.UpdateStatusBar();
					switch (form.Result)
					{
						case EncounterResult.Arrested:
							Clicks	= 0;
							Arrested();
							break;
						case EncounterResult.EscapePod:
							Clicks	= 0;
							EscapeWithPod();
							break;
						case EncounterResult.Killed:
							throw new GameEndException(GameEndType.Killed);
					}
				}

				Clicks--;
			}

			return !uneventful;
		}

		public void Warp(bool viaSingularity)
		{
			if (Commander.Debt > Consts.DebtTooLarge)
				FormAlert.Alert(AlertType.DebtTooLargeGrounded, ParentWindow);
			else if (Commander.Cash < MercenaryCosts)
				FormAlert.Alert(AlertType.LeavingIFMercenaries, ParentWindow);
			else if (Commander.Cash < MercenaryCosts + InsuranceCosts)
				FormAlert.Alert(AlertType.LeavingIFInsurance, ParentWindow);
			else if (Commander.Cash < MercenaryCosts + InsuranceCosts + WormholeCosts)
				FormAlert.Alert(AlertType.LeavingIFWormholeTax, ParentWindow);
			else
			{
				bool	wildOk	= true;

				// if Wild is aboard, make sure ship is armed!
				if (Commander.Ship.WildOnBoard && !Commander.Ship.HasWeapon(WeaponType.BeamLaser, false))
				{
					if (FormAlert.Alert(AlertType.WildWontStayAboardLaser, ParentWindow, Commander.CurrentSystem.Name) ==
						DialogResult.Cancel)
						wildOk	= false;
					else
					{
						FormAlert.Alert(AlertType.WildLeavesShip, ParentWindow, Commander.CurrentSystem.Name);
						QuestStatusWild	= SpecialEvent.StatusWildNotStarted;
					}
				}

				if (wildOk)
				{
					ArrivedViaWormhole	= Functions.WormholeExists(Commander.CurrentSystem, WarpSystem);

					if (viaSingularity)
						NewsAddEvent(NewsEvent.ExperimentArrival);
					else
						NormalDeparture(viaSingularity || ArrivedViaWormhole ? 0 :
							Functions.Distance(Commander.CurrentSystem, WarpSystem));

					Commander.CurrentSystem.CountDown	= CountDownStart;

					NewsResetEvents();

					CalculatePrices(WarpSystem);

					if (Travel())
					{
						// Clicks will be -1 if we were arrested or used the escape pod.
						/*
						if (Clicks == 0)
							FormAlert.Alert(AlertType.TravelArrival, ParentWindow);
						*/
					}
					else
						FormAlert.Alert(AlertType.TravelUneventfulTrip, ParentWindow);

					Arrival();
				}
			}
		}

		public void WarpDirect()
		{
			_warpSystemId	= SelectedSystemId;

			Commander.CurrentSystem.CountDown	= CountDownStart;
			NewsResetEvents();
			CalculatePrices(WarpSystem);
			Arrival();
		}

		#endregion

		#region Properties

		public static Game		CurrentGame
		{
			get
			{
				return _game;
			}
			set
			{
				_game	= value;
			}
		}

		public bool						ArrivedViaWormhole
		{
			get
			{
				return _arrivedViaWormhole;
			}
			set
			{
				_arrivedViaWormhole = value;
			}
		}

		public bool						AutoSave
		{
			get
			{
				return _autoSave;
			}
			set
			{
				_autoSave = value;
			}
		}

		public bool						CanSuperWarp
		{
			get
			{
				return _canSuperWarp;
			}
			set
			{
				_canSuperWarp	= value;
			}
		}

		public int						ChanceOfTradeInOrbit
		{
			get
			{
				return _chanceOfTradeInOrbit;
			}
			set
			{
				_chanceOfTradeInOrbit = value;
			}
		}

		public int						ChanceOfVeryRareEncounter
		{
			get
			{
				return _chanceOfVeryRareEncounter;
			}
			set
			{
				_chanceOfVeryRareEncounter = value;
			}
		}

		public bool						CheatEnabled
		{
			get
			{
				return _cheatEnabled;
			}
			set
			{
				_cheatEnabled = value;
			}
		}

		public int						Clicks
		{
			get
			{
				return _clicks;
			}
			set
			{
				_clicks = value;
			}
		}

		public Commander			Commander
		{
			get
			{
				return _commander;
			}
		}

		public int						CountDownStart
		{
			get
			{
				return (int)Difficulty + 3;
			}
		}

		public int						CurrentCosts
		{
			get
			{
				return InsuranceCosts + InterestCosts + MercenaryCosts + WormholeCosts;
			}
		}

		public int[]					Destinations
		{
			get
			{
				ArrayList	list	= new ArrayList();

				for (int i = 0; i < Universe.Length; i++)
					if (Universe[i].DestOk)
						list.Add(i);

				int[]			ids		= new int[list.Count];
				for (int i = 0; i < ids.Length; i++)
					ids[i]	= (int)list[i];

				return ids;
			}
		}

		public Difficulty			Difficulty
		{
			get
			{
				return _difficulty;
			}
		}

		public Ship						Dragonfly
		{
			get
			{
				return _dragonfly;
			}
		}

		public bool						EasyEncounters
		{
			get
			{
				return _easyEncounters;
			}
			set
			{
				_easyEncounters = value;
			}
		}

		public bool						EncounterContinueFleeing
		{
			get
			{
				return _encounterContinueFleeing;
			}
			set
			{
				_encounterContinueFleeing = value;
			}
		}

		public string					EncounterAction
		{
			get
			{
				string	action		= "";

				if (OpponentDisabled)
					action	= Functions.StringVars(Strings.EncounterActionOppDisabled, EncounterShipText);
				else if (EncounterOppFleeing)
				{
					if (EncounterType == EncounterType.PirateSurrender || EncounterType == EncounterType.TraderSurrender)
						action	= Functions.StringVars(Strings.EncounterActionOppSurrender, EncounterShipText);
					else
						action	= Functions.StringVars(Strings.EncounterActionOppFleeing, EncounterShipText);
				}
				else
					action		= Functions.StringVars(Strings.EncounterActionOppAttacks, EncounterShipText);

				return action;
			}
		}

		public string					EncounterActionInitial
		{
			get
			{
				string	text				= "";

				// Set up the fleeing variable initially.
				EncounterOppFleeing	= false;

				switch (EncounterType)
				{
					case EncounterType.BottleGood:
					case EncounterType.BottleOld:
						text	= Strings.EncounterTextBottle;
						break;
					case EncounterType.CaptainAhab:
					case EncounterType.CaptainConrad:
					case EncounterType.CaptainHuie:
						text	= Strings.EncounterTextFamousCaptain;
						break;
					case EncounterType.DragonflyAttack:
					case EncounterType.PirateAttack:
					case EncounterType.PoliceAttack:
					case EncounterType.ScarabAttack:
					case EncounterType.ScorpionAttack:
					case EncounterType.SpaceMonsterAttack:
						text	= Strings.EncounterTextOpponentAttack;
						break;
					case EncounterType.DragonflyIgnore:
					case EncounterType.PirateIgnore:
					case EncounterType.PoliceIgnore:
					case EncounterType.ScarabIgnore:
					case EncounterType.ScorpionIgnore:
					case EncounterType.SpaceMonsterIgnore:
					case EncounterType.TraderIgnore:
						text	= Commander.Ship.Cloaked ? Strings.EncounterTextOpponentNoNotice : Strings.EncounterTextOpponentIgnore;
						break;
					case EncounterType.MarieCeleste:
						text	= Strings.EncounterTextMarieCeleste;
						break;
					case EncounterType.MarieCelestePolice:
						text	= Strings.EncounterTextPolicePostMarie;
						break;
					case EncounterType.PirateFlee:
					case EncounterType.PoliceFlee:
					case EncounterType.TraderFlee:
						text								= Strings.EncounterTextOpponentFlee;
						EncounterOppFleeing	= true;
						break;
					case EncounterType.PoliceInspect:
						text	= Strings.EncounterTextPoliceInspection;
						break;
					case EncounterType.PoliceSurrender:
						text	= Strings.EncounterTextPoliceSurrender;
						break;
					case EncounterType.TraderBuy:
					case EncounterType.TraderSell:
						text	= Strings.EncounterTextTrader;
						break;
					case EncounterType.FamousCaptainAttack:
					case EncounterType.FamousCaptDisabled:
					case EncounterType.PoliceDisabled:
					case EncounterType.PirateDisabled:
					case EncounterType.PirateSurrender:
					case EncounterType.TraderAttack:
					case EncounterType.TraderDisabled:
					case EncounterType.TraderSurrender:
						// These should never be the initial encounter type.
						break;
				}

				return text;
			}
		}

		public bool						EncounterCmdrFleeing
		{
			get
			{
				return _encounterCmdrFleeing;
			}
			set
			{
				_encounterCmdrFleeing = value;
			}
		}

		public bool						EncounterCmdrHit
		{
			get
			{
				return _encounterCmdrHit;
			}
			set
			{
				_encounterCmdrHit = value;
			}
		}

		public bool						EncounterContinueAttacking
		{
			get
			{
				return _encounterContinueAttacking;
			}
			set
			{
				_encounterContinueAttacking = value;
			}
		}

		public int						EncounterImageIndex
		{
			get
			{
				int	encounterImage	= -1;

				switch (EncounterType)
				{
					case EncounterType.BottleGood:
					case EncounterType.BottleOld:
					case EncounterType.CaptainAhab:
					case EncounterType.CaptainConrad:
					case EncounterType.CaptainHuie:
					case EncounterType.MarieCeleste:
						encounterImage		= Consts.EncounterImgSpecial;
						break;
					case EncounterType.DragonflyAttack:
					case EncounterType.DragonflyIgnore:
					case EncounterType.ScarabAttack:
					case EncounterType.ScarabIgnore:
					case EncounterType.ScorpionAttack:
					case EncounterType.ScorpionIgnore:
						encounterImage		= Consts.EncounterImgPirate;
						break;
					case EncounterType.MarieCelestePolice:
					case EncounterType.PoliceAttack:
					case EncounterType.PoliceFlee:
					case EncounterType.PoliceIgnore:
					case EncounterType.PoliceInspect:
					case EncounterType.PoliceSurrender:
						encounterImage		= Consts.EncounterImgPolice;
						break;
					case EncounterType.PirateAttack:
					case EncounterType.PirateFlee:
					case EncounterType.PirateIgnore:
						if (Opponent.Type == ShipType.Mantis)
							encounterImage	= Consts.EncounterImgAlien;
						else
							encounterImage	= Consts.EncounterImgPirate;
						break;
					case EncounterType.SpaceMonsterAttack:
					case EncounterType.SpaceMonsterIgnore:
						encounterImage		= Consts.EncounterImgAlien;
						break;
					case EncounterType.TraderBuy:
					case EncounterType.TraderFlee:
					case EncounterType.TraderIgnore:
					case EncounterType.TraderSell:
						encounterImage		= Consts.EncounterImgTrader;
						break;
					case EncounterType.FamousCaptainAttack:
					case EncounterType.FamousCaptDisabled:
					case EncounterType.PoliceDisabled:
					case EncounterType.PirateDisabled:
					case EncounterType.PirateSurrender:
					case EncounterType.TraderAttack:
					case EncounterType.TraderDisabled:
					case EncounterType.TraderSurrender:
						// These should never be the initial encounter type.
						break;
				}

				return encounterImage;
			}
		}

		public bool						EncounterOppFleeing
		{
			get
			{
				return _encounterOppFleeing;
			}
			set
			{
				_encounterOppFleeing = value;
			}
		}

		public bool						EncounterOppFleeingPrev
		{
			get
			{
				return _encounterOppFleeingPrev;
			}
			set
			{
				_encounterOppFleeingPrev = value;
			}
		}

		public bool						EncounterOppHit
		{
			get
			{
				return _encounterOppHit;
			}
			set
			{
				_encounterOppHit = value;
			}
		}

		public string					EncounterShipText
		{
			get
			{
				string	shipText	= Opponent.Name;

				switch (EncounterType)
				{
					case EncounterType.FamousCaptainAttack:
					case EncounterType.FamousCaptDisabled:
						shipText	= Strings.EncounterShipCaptain;
						break;
					case EncounterType.PirateAttack:
					case EncounterType.PirateDisabled:
					case EncounterType.PirateFlee:
					case EncounterType.PirateSurrender:
						shipText	= Opponent.Type == ShipType.Mantis ? Strings.EncounterShipMantis : Strings.EncounterShipPirate;
						break;
					case EncounterType.PoliceAttack:
					case EncounterType.PoliceDisabled:
					case EncounterType.PoliceFlee:
						shipText	= Strings.EncounterShipPolice;
						break;
					case EncounterType.TraderAttack:
					case EncounterType.TraderDisabled:
					case EncounterType.TraderFlee:
					case EncounterType.TraderSurrender:
						shipText	= Strings.EncounterShipTrader;
						break;
					default:
						break;
				}

				return shipText;
			}
		}

		public string					EncounterText
		{
			get
			{
				string	cmdrStatus	= "";
				string	oppStatus		= "";

				if (EncounterCmdrFleeing)
					cmdrStatus	= Functions.StringVars(Strings.EncounterActionCmdrChased, EncounterShipText);
				else if (EncounterOppHit)
					cmdrStatus	= Functions.StringVars(Strings.EncounterActionOppHit, EncounterShipText);
				else
					cmdrStatus	= Functions.StringVars(Strings.EncounterActionOppMissed, EncounterShipText);

				if (EncounterOppFleeingPrev)
					oppStatus		= Functions.StringVars(Strings.EncounterActionOppChased, EncounterShipText);
				else if (EncounterCmdrHit)
					oppStatus		= Functions.StringVars(Strings.EncounterActionCmdrHit, EncounterShipText);
				else
					oppStatus		= Functions.StringVars(Strings.EncounterActionCmdrMissed, EncounterShipText);

				return cmdrStatus + Environment.NewLine + oppStatus;
			}
		}

		public string					EncounterTextInitial
		{
			get
			{
				string	encounterPretext	= "";

				switch (EncounterType)
				{
					case EncounterType.BottleGood:
					case EncounterType.BottleOld:
						encounterPretext	= Strings.EncounterPretextBottle;
						break;
					case EncounterType.DragonflyAttack:
					case EncounterType.DragonflyIgnore:
					case EncounterType.ScarabAttack:
					case EncounterType.ScarabIgnore:
						encounterPretext	= Strings.EncounterPretextStolen;
						break;
					case EncounterType.CaptainAhab:
						encounterPretext	= Strings.EncounterPretextCaptainAhab;
						break;
					case EncounterType.CaptainConrad:
						encounterPretext	= Strings.EncounterPretextCaptainConrad;
						break;
					case EncounterType.CaptainHuie:
						encounterPretext	= Strings.EncounterPretextCaptainHuie;
						break;
					case EncounterType.MarieCeleste:
						encounterPretext	= Strings.EncounterPretextMarie;
						break;
					case EncounterType.MarieCelestePolice:
					case EncounterType.PoliceAttack:
					case EncounterType.PoliceFlee:
					case EncounterType.PoliceIgnore:
					case EncounterType.PoliceInspect:
					case EncounterType.PoliceSurrender:
						encounterPretext	= Strings.EncounterPretextPolice;
						break;
					case EncounterType.PirateAttack:
					case EncounterType.PirateFlee:
					case EncounterType.PirateIgnore:
						if (Opponent.Type == ShipType.Mantis)
							encounterPretext	= Strings.EncounterPretextAlien;
						else
							encounterPretext	= Strings.EncounterPretextPirate;
						break;
					case EncounterType.ScorpionAttack:
					case EncounterType.ScorpionIgnore:
						encounterPretext	= Strings.EncounterPretextScorpion;
						break;
					case EncounterType.SpaceMonsterAttack:
					case EncounterType.SpaceMonsterIgnore:
						encounterPretext	= Strings.EncounterPretextSpaceMonster;
						break;
					case EncounterType.TraderBuy:
					case EncounterType.TraderFlee:
					case EncounterType.TraderIgnore:
					case EncounterType.TraderSell:
						encounterPretext	= Strings.EncounterPretextTrader;
						break;
					case EncounterType.FamousCaptainAttack:
					case EncounterType.FamousCaptDisabled:
					case EncounterType.PoliceDisabled:
					case EncounterType.PirateDisabled:
					case EncounterType.PirateSurrender:
					case EncounterType.TraderAttack:
					case EncounterType.TraderDisabled:
					case EncounterType.TraderSurrender:
						// These should never be the initial encounter type.
						break;
				}

				return Functions.StringVars(Strings.EncounterText, new string[]
					{
						Functions.Multiples(Clicks, Strings.DistanceSubunit),
						WarpSystem.Name,
						encounterPretext,
						Opponent.Name.ToLower()
					});
			}
		}

		public EncounterType	EncounterType
		{
			get
			{
				return _encounterType;
			}
			set
			{
				_encounterType	= value;
			}
		}

		public GameEndType		EndStatus
		{
			get
			{
				return _endStatus;
			}
			set
			{
				_endStatus = value;
			}
		}

		public int						FabricRipProbability
		{
			get
			{
				return _fabricRipProbability;
			}
			set
			{
				_fabricRipProbability = value;
			}
		}

		public bool						Inspected
		{
			get
			{
				return _inspected;
			}
			set
			{
				_inspected = value;
			}
		}

		public int						InsuranceCosts
		{
			get
			{
				return Commander.Insurance ? (int)Math.Max(1, Commander.Ship.BaseWorth(true) * Consts.InsRate *
					(100 - Commander.NoClaim) / 100) : 0;
			}
		}

		public int						InterestCosts
		{
			get
			{
				return Commander.Debt > 0 ? (int)Math.Max(1, Commander.Debt * Consts.IntRate) : 0;
			}
		}

		public bool						JustLootedMarie
		{
			get
			{
				return _justLootedMarie;
			}
			set
			{
				_justLootedMarie = value;
			}
		}

		public bool						LitterWarning
		{
			get
			{
				return _litterWarning;
			}
			set
			{
				_litterWarning = value;
			}
		}

		public int						MercenaryCosts
		{
			get
			{
				int	total	= 0;

				for (int i = 1; i < Commander.Ship.Crew.Length && Commander.Ship.Crew[i] != null; i++)
					total	+= Commander.Ship.Crew[i].Rate;

				return total;
			}
		}

		public CrewMember[]		Mercenaries
		{
			get
			{
				return _mercenaries;
			}
		}

		public ArrayList			NewsEvents
		{
			get
			{
				return _newsEvents;
			}
		}

		public string					NewspaperHead
		{
			get
			{
				string[]		heads		= Strings.NewsMastheads[(int)Commander.CurrentSystem.PoliticalSystemType];
				string			head		= heads[(int)Commander.CurrentSystem.Id % heads.Length];

				return Functions.StringVars(head, Commander.CurrentSystem.Name);
			}
		}

		public string					NewspaperText
		{
			get
			{
				StarSystem	curSys	= Commander.CurrentSystem;
				ArrayList		items		= new ArrayList();

				// We're using the GetRandom2 function so that the same number is generated each time for the same
				// "version" of the newspaper. -JAF
				Functions.RandSeed((int)curSys.Id, Commander.Days);

				for (IEnumerator en = NewsEvents.GetEnumerator(); en.MoveNext();)
					items.Add(Functions.StringVars(Strings.NewsEvent[(int)en.Current], new string[] { Commander.Name,
																																														Commander.CurrentSystem.Name, Commander.Ship.Name }));

				if (curSys.SystemPressure != SystemPressure.None)
					items.Add(Strings.NewsPressureInternal[(int)curSys.SystemPressure]);

				if (Commander.PoliceRecordScore <= Consts.PoliceRecordScoreVillain)
				{
					string baseStr	= Strings.NewsPoliceRecordPsychopath[Functions.GetRandom2(
						Strings.NewsPoliceRecordPsychopath.Length)];
					items.Add(Functions.StringVars(baseStr, Commander.Name, curSys.Name));
				}
				else if (Commander.PoliceRecordScore >= Consts.PoliceRecordScoreHero)
				{
					string baseStr	= Strings.NewsPoliceRecordHero[Functions.GetRandom2(Strings.NewsPoliceRecordHero.Length)];
					items.Add(Functions.StringVars(baseStr, Commander.Name, curSys.Name));
				}

				// and now, finally, useful news (if any)
				// base probability of a story showing up is (50 / MAXTECHLEVEL) * Current Tech Level
				// This is then modified by adding 10% for every level of play less than Impossible
				bool	realNews				= false;
				int		minProbability	= Consts.StoryProbability * (int)curSys.TechLevel + 10 * (5 - (int)Difficulty);
				for (int i = 0; i < Universe.Length; i++)
				{
					if (Universe[i].DestOk && Universe[i] != curSys)
					{
						// Special stories that always get shown: moon, millionaire, shipyard
						if (Universe[i].SpecialEventType != SpecialEventType.NA)
						{
							if (Universe[i].SpecialEventType == SpecialEventType.Moon)
								items.Add(Functions.StringVars(Strings.NewsMoonForSale, Universe[i].Name));
							else if (Universe[i].SpecialEventType == SpecialEventType.TribbleBuyer)
								items.Add(Functions.StringVars(Strings.NewsTribbleBuyer, Universe[i].Name));
						}
						if (Universe[i].ShipyardId != ShipyardId.NA)
							items.Add(Functions.StringVars(Strings.NewsShipyard, Universe[i].Name));

						// And not-always-shown stories
						if (Universe[i].SystemPressure != SystemPressure.None &&
							Functions.GetRandom2(100) <= Consts.StoryProbability * (int)curSys.TechLevel + 10 * (5 - (int)Difficulty))
						{
							int			index			= Functions.GetRandom2(Strings.NewsPressureExternal.Length);
							string	baseStr		= Strings.NewsPressureExternal[index];
							string	pressure	= Strings.NewsPressureExternalPressures[(int)Universe[i].SystemPressure];
							items.Add(Functions.StringVars(baseStr, pressure, Universe[i].Name));
							realNews					= true;
						}
					}
				}

				// if there's no useful news, we throw up at least one
				// headline from our canned news list.
				if (!realNews)
				{
					string[]	headlines	= Strings.NewsHeadlines[(int)curSys.PoliticalSystemType];
					bool[]		shown			= new bool[headlines.Length];

					int				toShow		= Functions.GetRandom2(headlines.Length);
					for (int i = 0; i <= toShow; i++)
					{
						int	index	= Functions.GetRandom2(headlines.Length);
						if (!shown[index])
						{
							items.Add(headlines[index]);
							shown[index]	= true;
						}
					}
				}

				return String.Join(Environment.NewLine + Environment.NewLine, Functions.ArrayListToStringArray(items));
			}
		}

		public Ship						Opponent
		{
			get
			{
				return _opponent;
			}
			set
			{
				_opponent	= value;
			}
		}

		public bool						OpponentDisabled
		{
			get
			{
				return _opponentDisabled;
			}
			set
			{
				_opponentDisabled	= value;
			}
		}

		public GameOptions		Options
		{
			get
			{
				return _options;
			}
		}

		public bool						PaidForNewspaper
		{
			get
			{
				return _paidForNewspaper;
			}
			set
			{
				_paidForNewspaper	= value;
			}
		}

		public SpaceTrader		ParentWindow
		{
			get
			{
				return _parentWin;
			}
			set
			{
				_parentWin	= value;
			}
		}

		public int[]					PriceCargoBuy
		{
			get
			{
				return _priceCargoBuy;
			}
		}

		public int[]					PriceCargoSell
		{
			get
			{
				return _priceCargoSell;
			}
		}

		public int						QuestStatusArtifact
		{
			get
			{
				return _questStatusArtifact;
			}
			set
			{
				_questStatusArtifact	= value;
			}
		}

		public int						QuestStatusDragonfly
		{
			get
			{
				return _questStatusDragonfly;
			}
			set
			{
				_questStatusDragonfly	= value;
			}
		}

		public int						QuestStatusExperiment
		{
			get
			{
				return _questStatusExperiment;
			}
			set
			{
				_questStatusExperiment	= value;
			}
		}

		public int						QuestStatusGemulon
		{
			get
			{
				return _questStatusGemulon;
			}
			set
			{
				_questStatusGemulon= value;
			}
		}

		public int						QuestStatusJapori
		{
			get
			{
				return _questStatusJapori;
			}
			set
			{
				_questStatusJapori	= value;
			}
		}

		public int						QuestStatusJarek
		{
			get
			{
				return _questStatusJarek;
			}
			set
			{
				_questStatusJarek	= value;
			}
		}

		public int						QuestStatusMoon
		{
			get
			{
				return _questStatusMoon;
			}
			set
			{
				_questStatusMoon	= value;
			}
		}

		public int						QuestStatusPrincess
		{
			get
			{
				return _questStatusPrincess;
			}
			set
			{
				_questStatusPrincess = value;
			}
		}

		public int						QuestStatusReactor
		{
			get
			{
				return _questStatusReactor;
			}
			set
			{
				_questStatusReactor	= value;
			}
		}

		public int						QuestStatusScarab
		{
			get
			{
				return _questStatusScarab;
			}
			set
			{
				_questStatusScarab	= value;
			}
		}

		public int						QuestStatusSculpture
		{
			get
			{
				return _questStatusSculpture;
			}
			set
			{
				_questStatusSculpture	= value;
			}
		}

		public int						QuestStatusSpaceMonster
		{
			get
			{
				return _questStatusSpaceMonster;
			}
			set
			{
				_questStatusSpaceMonster	= value;
			}
		}

		public int						QuestStatusWild
		{
			get
			{
				return _questStatusWild;
			}
			set
			{
				_questStatusWild	= value;
			}
		}

		public bool						Raided
		{
			get
			{
				return _raided;
			}
			set
			{
				_raided = value;
			}
		}

		public Ship						Scarab
		{
			get
			{
				return _scarab;
			}
		}

		public int						Score
		{
			get
			{
				int	worth			= Commander.Worth < 1000000 ? Commander.Worth : 1000000 + ((Commander.Worth - 1000000) / 10);
				int	daysMoon	= 0;
				int	modifier	= 0;

				switch (EndStatus)
				{
					case GameEndType.Killed:
						modifier	= 90;
						break;
					case GameEndType.Retired:
						modifier	= 95;
						break;
					case GameEndType.BoughtMoon:
						daysMoon	= Math.Max(0, ((int)Difficulty + 1) * 100 - Commander.Days);
						modifier	= 100;
						break;
				}

				return ((int)Difficulty + 1) * modifier * (daysMoon * 1000 + worth) / 250000;
			}
		}

		public Ship						Scorpion
		{
			get
			{
				return _scorpion;
			}
		}

		public StarSystem			SelectedSystem
		{
			get
			{
				return (_selectedSystemId == StarSystemId.NA ? null : Universe[(int)_selectedSystemId]);
			}
		}

		public StarSystemId		SelectedSystemId
		{
			get
			{
				return _selectedSystemId;
			}
			set
			{
				_selectedSystemId		= value;
				_warpSystemId				= value;
				_targetWormhole			= false;
			}
		}

		public string					SelectedSystemName
		{
			set
			{
				string	nameToFind	= value;
				bool		found				= false;
				for (int i = 0; i < Universe.Length && !found; i++)
				{
					string	name	= Universe[i].Name;
					if (name.ToLower().IndexOf(nameToFind.ToLower()) >= 0)
					{
						SelectedSystemId	= (StarSystemId)i;
						found							= true;
					}
				}
			}
		}

		public Ship						SpaceMonster
		{
			get
			{
				return _spaceMonster;
			}
		}

		public bool						TargetWormhole
		{
			get
			{
				return _targetWormhole;
			}
			set
			{
				_targetWormhole	= value;

				if (_targetWormhole)
				{
					int wormIndex	= Array.IndexOf(Wormholes, (int)SelectedSystemId);
					_warpSystemId	= (StarSystemId)Wormholes[(wormIndex + 1) % Wormholes.Length];
				}
			}
		}

		public StarSystem			TrackedSystem
		{
			get
			{
				return (_trackedSystemId == StarSystemId.NA ? null : Universe[(int)_trackedSystemId]);
			}
		}

		public StarSystemId		TrackedSystemId
		{
			get
			{
				return _trackedSystemId;
			}
			set
			{
				_trackedSystemId	= value;
			}
		}

		public bool						TribbleMessage
		{
			get
			{
				return _tribbleMessage;
			}
			set
			{
				_tribbleMessage	= value;
			}
		}

		public StarSystem[]		Universe
		{
			get
			{
				return _universe;
			}
		}

		public ArrayList			VeryRareEncounters
		{
			get
			{
				return _veryRareEncounters;
			}
		}

		public StarSystem			WarpSystem
		{
			get
			{
				return (_warpSystemId == StarSystemId.NA ? null : Universe[(int)_warpSystemId]);
			}
		}

		public StarSystemId		WarpSystemId
		{
			get
			{
				return _warpSystemId;
			}
		}

		public int						WormholeCosts
		{
			get
			{
				return Functions.WormholeExists(Commander.CurrentSystem, WarpSystem) ?
					Consts.WormDist * Commander.Ship.FuelCost : 0;
			}
		}

		public int[]					Wormholes
		{
			get
			{
				return _wormholes;
			}
		}

		#endregion
	}
}
