/*******************************************************************************
 *
 * Space Trader for Windows 2.00
 *
 * Copyright (C) 2004 Jay French, All Rights Reserved
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
	public class Game: STSerializableObject
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
		private Ship					_spaceMonster								= new Ship(ShipType.SpaceMonster);
		private Ship					_opponent										= new Ship(ShipType.Gnat);

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
		private int						_questStatusReactor					= 0;									// 0 = not encountered, 1-20 = days of mission (bays of fuel left = 10 - (ReactorStatus / 2), 21 = delivered, 22 = Done
		private int						_questStatusScarab					= 0;									// 0 = not given yet, 1 = not destroyed, 2 = destroyed - upgrade not performed, 3 = destroyed - hull upgrade performed
		private int						_questStatusSpaceMonster		= 0;									// 0 = not available, 1 = Space monster is in Acamar system, 2 = Space monster is destroyed, 3 = Claimed reward
		private int						_questStatusWild						= 0;									// 0 = not delivered, 1-11 = on board, 12 = delivered
		private int						_fabricRipProbability				= 0;									// if Experiment = 12, this is the probability of being warped to a random planet.
		private bool					_justLootedMarie						= false;							// flag to indicate whether player looted Marie Celeste
		private bool					_canSuperWarp								= false;							// Do you have the Portable Singularity on board?
		private int						_chanceOfVeryRareEncounter	= 5;
		private ArrayList			_veryRareEncounters					= new ArrayList(6);		// Array of Very Rare encounters not done yet.

		// Options
		private GameOptions		_options										= new GameOptions(true);

		private SpaceTrader		_parentWin									= null;

		#endregion

		#region Methods

		public Game(string name, Difficulty difficulty, int pilot, int fighter, int trader, int engineer, SpaceTrader parentWin)
		{
			_game				= this;
			_parentWin	= parentWin;
			_difficulty	= difficulty;

			// Keep Generating a new universe until PlaceSpecialEvents returns true, indicating all special events were placed.
			do
				GenerateUniverse();
			while (!PlaceSpecialEvents());

			InitializeCommander(name, new CrewMember(CrewMemberId.Commander, pilot, fighter, trader, engineer, StarSystemId.NA));
			GenerateCrewMemberList();

			CreateShips();

			CalculatePrices(Commander.CurrentSystem);

			ResetVeryRareEncounters();

			if (Difficulty < Difficulty.Normal)
				Commander.CurrentSystem.SpecialEventType	= SpecialEventType.Lottery;

			// JAF - DEBUG
			Commander.Cash	= 1000000;
			CheatEnabled		= true;
			EasyEncounters	= true;
		}

		public Game(Hashtable hash, SpaceTrader parentWin): base(hash)
		{
			_game				= this;
			_parentWin	= parentWin;

			string	version	= (string)hash["_version"];
			if (version.CompareTo(Consts.CurrentVersion) > 0)
			{
				// TODO: abort
			}

			_universe										= (StarSystem[])ArrayListToArray((ArrayList)hash["_universe"], "StarSystem");
			_wormholes									= (int[])hash["_wormholes"];
			_mercenaries								= (CrewMember[])ArrayListToArray((ArrayList)hash["_mercenaries"], "CrewMember");
			_commander									= new Commander((Hashtable)hash["_commander"]);
			_dragonfly									= new Ship((Hashtable)hash["_dragonfly"]);
			_scarab											= new Ship((Hashtable)hash["_scarab"]);
			_spaceMonster								= new Ship((Hashtable)hash["_spaceMonster"]);
			_opponent										= new Ship((Hashtable)hash["_opponent"]);
			_chanceOfTradeInOrbit				= (int)hash["_chanceOfTradeInOrbit"];
			_clicks											= (int)hash["_clicks"];
			_raided											= (bool)hash["_raided"];
			_inspected									= (bool)hash["_inspected"];
			_tribbleMessage							= (bool)hash["_tribbleMessage"];
			_arrivedViaWormhole					= (bool)hash["_arrivedViaWormhole"];
			_paidForNewspaper						= (bool)hash["_paidForNewspaper"];
			_litterWarning							= (bool)hash["_litterWarning"];
			_newsEvents									= new ArrayList((int[])hash["_newsEvents"]);
			_difficulty									= (Difficulty)hash["_difficulty"];
			_cheatEnabled								= (bool)hash["_cheatEnabled"];
			_autoSave										= (bool)hash["_autoSave"];
			_easyEncounters							= (bool)hash["_easyEncounters"];
			_endStatus									= (GameEndType)hash["_endStatus"];
			_encounterType							= (EncounterType)hash["_encounterType"];
			_selectedSystemId						= (StarSystemId)hash["_selectedSystemId"];
			_warpSystemId								= (StarSystemId)hash["_warpSystemId"];
			_trackedSystemId						= (StarSystemId)hash["_trackedSystemId"];
			_targetWormhole							= (bool)hash["_targetWormhole"];
			_priceCargoBuy							= (int[])hash["_priceCargoBuy"];
			_priceCargoSell							= (int[])hash["_priceCargoSell"];
			_questStatusArtifact				= (int)hash["_questStatusArtifact"];
			_questStatusDragonfly				= (int)hash["_questStatusDragonfly"];
			_questStatusExperiment			= (int)hash["_questStatusExperiment"];
			_questStatusGemulon					= (int)hash["_questStatusGemulon"];
			_questStatusJapori					= (int)hash["_questStatusJapori"];
			_questStatusJarek						= (int)hash["_questStatusJarek"];
			_questStatusMoon						= (int)hash["_questStatusMoon"];
			_questStatusReactor					= (int)hash["_questStatusReactor"];
			_questStatusScarab					= (int)hash["_questStatusScarab"];
			_questStatusSpaceMonster		= (int)hash["_questStatusSpaceMonster"];
			_questStatusWild						= (int)hash["_questStatusWild"];
			_fabricRipProbability				= (int)hash["_fabricRipProbability"];
			_justLootedMarie						= (bool)hash["_justLootedMarie"];
			_canSuperWarp								= (bool)hash["_canSuperWarp"];
			_chanceOfVeryRareEncounter	= (int)hash["_chanceOfVeryRareEncounter"];
			_veryRareEncounters					= new ArrayList((int[])hash["_veryRareEncounters"]);
			_options										= new GameOptions((Hashtable)hash["_options"]);
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

			if (Commander.Ship.Cargo[(int)TradeItemType.Narcotics] > 0 ||
					Commander.Ship.Cargo[(int)TradeItemType.Firearms] > 0)
			{
				FormAlert.Alert(AlertType.JailIllegalGoodsImpounded, ParentWindow);
				Commander.Ship.Cargo[(int)TradeItemType.Narcotics]	= 0;
				Commander.Ship.Cargo[(int)TradeItemType.Firearms]		= 0;
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

			if (Commander.Ship.WildOnBoard)
			{
				FormAlert.Alert(AlertType.WildArrested, ParentWindow);
				NewsAddEvent(NewsEvent.WildArrested);
				QuestStatusWild = SpecialEvent.StatusWildNotStarted;
			}

			if (QuestStatusJapori == SpecialEvent.StatusJaporiInTransit)
			{
				FormAlert.Alert(AlertType.AntidoteTaken, ParentWindow);
				QuestStatusJapori	= SpecialEvent.StatusJaporiDone;
			}

			if (Commander.Ship.ReactorOnBoard)
			{
				FormAlert.Alert(AlertType.ReactorConfiscated, ParentWindow);
				QuestStatusReactor	= SpecialEvent.StatusReactorNotStarted;
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
			Arrival();
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

			ship.Hull += Math.Min(ship.HullStrength - ship.Hull, Functions.GetRandom(ship.Engineer));

			for (int i = 0; i < ship.Shields.Length; ++i)
				if (ship.Shields[i] != null)
					ship.Shields[i].Charge	= ship.Shields[i].Power;

			bool	fuelOk	= true;
			if (Options.AutoFuel)
			{
				int	toAdd	= ship.FuelTanks - ship.Fuel;
				if (Commander.Cash >= toAdd * ship.FuelCost)
				{
					ship.Fuel				+= toAdd;
					Commander.Cash	-= toAdd * ship.FuelCost;
				}
				else
					fuelOk					= false;
			}

			bool	repairOk	= true;
			if (Options.AutoRepair)
			{
				int	toAdd	= ship.HullStrength - ship.Hull;
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
					Universe[i].Pressure	= Universe[i].Pressure == SystemPressure.None ?
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
				_priceCargoSell[i]		= Consts.TradeItems[i].StandardPrice(system);

				// In case of a special status, adapt price accordingly
				if (Consts.TradeItems[i].PressurePriceHike == system.Pressure)
					_priceCargoSell[i]	= _priceCargoSell[i] * 3 / 2;

				// Randomize price a bit
				int	variance					= Consts.TradeItems[i].PriceVariance;
				_priceCargoSell[i]		= _priceCargoSell[i] + Functions.GetRandom(-variance + 1, variance);

				// Criminals have to pay off an intermediary
				if (Commander.PoliceRecordScore < Consts.PoliceRecordScoreDubious)
					_priceCargoSell[i]	= _priceCargoSell[i] * 90 / 100;
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
					int	maxAmount	= qtyInHand;
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
			Commander.Ship			= new Ship(ShipType.Flea);
			Commander.Insurance	= false;
			Commander.NoClaim		= 0;
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
					// StrengthPolice adapts itself to your criminal record: you'll
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
					if (Clicks > 1)
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

		public void EscapeWithPod()
		{
			FormAlert.Alert(AlertType.EncounterEscapePodActivated, ParentWindow);

			if (Commander.Ship.ReactorOnBoard)
			{
				FormAlert.Alert(AlertType.ReactorDestroyed, ParentWindow);
				QuestStatusReactor	= SpecialEvent.StatusReactorDone;
			}

			if (QuestStatusJapori == SpecialEvent.StatusJaporiInTransit)
			{
				FormAlert.Alert(AlertType.AntidoteDestroyed, ParentWindow);
				QuestStatusJapori = SpecialEvent.StatusJaporiDone;
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

			if (Commander.Ship.WildOnBoard)
			{
				FormAlert.Alert(AlertType.WildArrested, ParentWindow);
				Commander.PoliceRecordScore	+= Consts.ScoreCaughtWithWild;
				NewsAddEvent(NewsEvent.WildArrested);
				QuestStatusWild = SpecialEvent.StatusWildNotStarted;
			}

			if (Commander.Ship.Tribbles > 0)
				FormAlert.Alert(AlertType.TribblesKilled, ParentWindow);

			if (Commander.Insurance)
			{
				FormAlert.Alert(AlertType.InsurancePayoff, ParentWindow);
				Commander.Cash	+= Commander.Ship.BaseWorth(true);
			}

			FormAlert.Alert(AlertType.FleaBuilt, ParentWindow);

			if (Commander.Cash > Consts.FleaConversionCost)
				Commander.Cash	-= Consts.FleaConversionCost;
			else
			{
				Commander.Debt	+= Consts.FleaConversionCost - Commander.Cash;
				Commander.Cash	 = 0;
			}

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
			for (int i = 1; i < (int)CrewMemberId.Zeethibal; i++)
			{
				StarSystemId	id;
				bool					ok		= false;
				bool[]				used	= new bool[Universe.Length];

				// can't have another mercenary on Kravat, since Zeethibal could be there
				used[(int)StarSystemId.Kravat]	= true;

				do
				{
					id	= (StarSystemId)Functions.GetRandom(Universe.Length);
					if (!used[(int)id])
					{
						used[(int)id]	= true;
						ok						= true;
					}
				} while (!ok);

				Mercenaries[i]	= new CrewMember((CrewMemberId)i, Functions.RandomSkill(), Functions.RandomSkill(), Functions.RandomSkill(), Functions.RandomSkill(), id);
			}

			// special individuals:
			// Zeethibal, Jonathan Wild's Nephew - skills will be set later.
			// Wild, Jonathan Wild earns his keep now - JAF.
			// Jarek, Ambassador Jarek earns his keep now - JAF.
			// Dummy pilots for opponents.
			int	d	= (int)Difficulty;
			Mercenaries[(int)CrewMemberId.Zeethibal]			= new CrewMember(CrewMemberId.Zeethibal,      5,  5,  5,  5, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.Opponent]				= new CrewMember(CrewMemberId.Opponent,       5,  5,  5,  5, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.Wild]						= new CrewMember(CrewMemberId.Wild,           7, 10,  2,  5, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.Jarek]					= new CrewMember(CrewMemberId.Jarek,          3,  2, 10,  4, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.FamousCaptain]	= new CrewMember(CrewMemberId.FamousCaptain, 10, 10, 10, 10, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.Dragonfly]			= new CrewMember(CrewMemberId.Dragonfly,    4 + d, 6 + d, 1, 6 + d, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.Scarab]					= new CrewMember(CrewMemberId.Scarab,       5 + d, 6 + d, 1, 6 + d, StarSystemId.NA);
			Mercenaries[(int)CrewMemberId.SpaceMonster]		= new CrewMember(CrewMemberId.SpaceMonster, 8 + d, 8 + d, 1, 1 + d, StarSystemId.NA);
		}

		private void GenerateOpponent(OpponentType oppType)
		{
			Opponent	= new Ship(oppType);
		}

		private void GenerateUniverse()
		{
			_universe	= new StarSystem[(int)StarSystemId.Zuul + 1];

			int	i, j;

			for (i = 0; i < Universe.Length; i++)
			{
				StarSystemId		id				= (StarSystemId)i;
				Size						size			= (Size)Functions.GetRandom((int)Size.Huge + 1);
				PoliticalSystem	polSys		= Consts.PoliticalSystems[Functions.GetRandom(Consts.PoliticalSystems.Length)];
				TechLevel				tech			= (TechLevel)Functions.GetRandom((int)polSys.MinimumTechLevel, (int)polSys.MaximumTechLevel + 1);
				SystemPressure	pressure	= SystemPressure.None;
				SpecialResource	specRes		= SpecialResource.Nothing;

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
			bool				money		= false;
			bool				remove	= true;

			switch (curSys.SpecialEventType)
			{
				case SpecialEventType.Artifact:
					QuestStatusArtifact	= SpecialEvent.StatusArtifactOnBoard;
					break;
				case SpecialEventType.ArtifactDelivery:
					QuestStatusArtifact	= SpecialEvent.StatusArtifactDone;
					money								= true;
					break;
				case SpecialEventType.CargoForSale:
					FormAlert.Alert(AlertType.SpecialSealedCanisters, ParentWindow);
					int	tradeItem										 = Functions.GetRandom(Consts.TradeItems.Length);
					Commander.Ship.Cargo[tradeItem]	+= 3;
					Commander.PriceCargo[tradeItem]	+= Commander.CurrentSystem.SpecialEvent.Price;
					money								= true;
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
					money												= true;
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
					if (Commander.Ship.FreeCargoBays < 10)
					{
						FormAlert.Alert(AlertType.CargoNoEmptyBays, ParentWindow);
						remove	= false;
					}
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
						Commander.Ship.Crew[Commander.Ship.Crew[1] == null ? 1 : 2]	= jarek;
						QuestStatusJarek	= SpecialEvent.StatusJarekStarted;
					}
					break;
				case SpecialEventType.JarekGetsOut:
					QuestStatusJarek	= SpecialEvent.StatusJarekDone;
					Commander.Ship.Fire(Commander.Ship.Crew[1].Id == CrewMemberId.Jarek ? 1 : 2);
					break;
				case SpecialEventType.Lottery:
					money	= true;
					break;
				case SpecialEventType.Moon:
					FormAlert.Alert(AlertType.SpecialMoonBought, ParentWindow);
					QuestStatusMoon	= SpecialEvent.StatusMoonBought;
					money						= true;
					break;
				case SpecialEventType.MoonRetirement:
					QuestStatusMoon	= SpecialEvent.StatusMoonDone;
					throw new GameEndException(GameEndType.BoughtMoon);
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
				case SpecialEventType.Skill:
					FormAlert.Alert(AlertType.SpecialSkillIncrease, ParentWindow);
					Commander.IncreaseRandomSkill();
					money	= true;
					break;
				case SpecialEventType.SpaceMonster:
					QuestStatusSpaceMonster	= SpecialEvent.StatusSpaceMonsterAtAcamar;
					break;
				case SpecialEventType.SpaceMonsterKilled:
					QuestStatusSpaceMonster	= SpecialEvent.StatusSpaceMonsterDone;
					money	= true;
					break;
				case SpecialEventType.Tribble:
					FormAlert.Alert(AlertType.TribblesOwn, ParentWindow);						
					money										= true;
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
						Commander.Ship.Crew[Commander.Ship.Crew[1] == null ? 1 : 2]	= wild;
						QuestStatusWild	= SpecialEvent.StatusWildStarted;
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
					Commander.Ship.Fire(Commander.Ship.Crew[1].Id == CrewMemberId.Wild ? 1 : 2);
					RecalculateSellPrices(curSys);
					break;
			}

			if (money)
				Commander.Cash	-= curSys.SpecialEvent.Price;

			if (remove)
				curSys.SpecialEventType	= SpecialEventType.NA;
		}

		public void IncDays(int num, IWin32Window owner)
		{
			Commander.Days	+= num;

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
					case SpecialEventType.Scarab:
						NewsAddEvent(NewsEvent.Scarab);
						break;
					case SpecialEventType.ScarabDestroyed:
						if (QuestStatusScarab == SpecialEvent.StatusScarabHunting)
							NewsAddEvent(NewsEvent.ScarabHarass);
						else if (QuestStatusScarab >= SpecialEvent.StatusScarabDestroyed)
							NewsAddEvent(NewsEvent.ScarabDestroyed);
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
			if (Commander.Insurance)
				Commander.NoClaim++;

			if (Commander.PoliceRecordScore > Consts.PoliceRecordScoreClean)
			{
				if (Commander.Days % 3 == 0)
					Commander.PoliceRecordScore--;
			}
			else if (Commander.PoliceRecordScore < Consts.PoliceRecordScoreDubious)
			{
				if (Difficulty <= Difficulty.Normal || Commander.Days % (int)Difficulty == 0)
					Commander.PoliceRecordScore++;
			}

			SpaceMonster.Hull	= Math.Min(SpaceMonster.HullStrength, SpaceMonster.Hull * 105 / 100);
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

			// Assign the shipyards to High-Tech systems without a special event.
			// TODO: JAF - use enum for assignment.
			if (goodUniverse)
			{
				int	shipyards	= 0;
				for (system = 0; system < Universe.Length && shipyards < Consts.Shipyards.Length; system++)
				{
					if (Universe[system].TechLevel == TechLevel.HiTech)
						Universe[system].ShipyardId	= (ShipyardId)shipyards++;
				}
				goodUniverse	= (shipyards == Consts.Shipyards.Length);
			}

			// Assign the rest of the events randomly.
			if (goodUniverse)
			{
				SpecialEventType[]	random	= new SpecialEventType[]
				{
					SpecialEventType.Artifact,
					SpecialEventType.CargoForSale,
					SpecialEventType.Dragonfly,
					SpecialEventType.EraseRecord,
					SpecialEventType.Japori,
					SpecialEventType.Jarek,
					SpecialEventType.Moon,
					SpecialEventType.Scarab,
					SpecialEventType.Skill,
					SpecialEventType.SpaceMonster,
					SpecialEventType.Tribble,
					SpecialEventType.TribbleBuyer,
					SpecialEventType.Wild
				};

				for (int i = 0; i < random.Length; i++)
				{
					do
					{
						system	= Functions.GetRandom(Universe.Length);
					}
					while (Universe[system].SpecialEventType != SpecialEventType.NA);
					Universe[system].SpecialEventType	= random[i];
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
			hash.Add("_newsEvents",									(int[])_newsEvents.ToArray(typeof(NewsEvent)));
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
			hash.Add("_questStatusReactor",					_questStatusReactor);
			hash.Add("_questStatusScarab",					_questStatusScarab);
			hash.Add("_questStatusSpaceMonster",		_questStatusSpaceMonster);
			hash.Add("_questStatusWild",						_questStatusWild);
			hash.Add("_fabricRipProbability",				_fabricRipProbability);
			hash.Add("_justLootedMarie",						_justLootedMarie);
			hash.Add("_canSuperWarp",								_canSuperWarp);
			hash.Add("_chanceOfVeryRareEncounter",	_chanceOfVeryRareEncounter);
			hash.Add("_veryRareEncounters",					(int[])_veryRareEncounters.ToArray(typeof(VeryRareEncounter)));
			hash.Add("_options",										_options.Serialize());

			hash.Add("commanderName",								Strings.CrewMemberNames[(int)CrewMemberId.Commander]);

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

		public bool						CarryingIllegalCargo
		{
			get
			{
				return	Commander.Ship.Cargo[(int)TradeItemType.Firearms] > 0 ||
					Commander.Ship.Cargo[(int)TradeItemType.Narcotics] > 0 ||
					Commander.Ship.WildOnBoard || Commander.Ship.ReactorOnBoard;
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
					items.Add(Functions.StringVars(Strings.NewsEvent[(int)en.Current], Commander.Name));

				if (curSys.Pressure != SystemPressure.None)
					items.Add(Strings.NewsPressureInternal[(int)curSys.Pressure]);

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
						// Special stories that always get shown: moon, millionaire
						if (Universe[i].SpecialEventType != SpecialEventType.NA)
						{
							if (Universe[i].SpecialEventType == SpecialEventType.Moon)
								items.Add(Functions.StringVars(Strings.NewsMoonForSale, Universe[i].Name));
							else if (Universe[i].SpecialEventType == SpecialEventType.TribbleBuyer)
								items.Add(Functions.StringVars(Strings.NewsTribbleBuyer, Universe[i].Name));
						}
			
						// And not-always-shown stories
						if (Universe[i].Pressure != SystemPressure.None && Functions.GetRandom2(100) <= Consts.StoryProbability * (int)curSys.TechLevel + 10 * (5 - (int)Difficulty))
						{
							int			index			= Functions.GetRandom2(Strings.NewsPressureExternal.Length);
							string	baseStr		= Strings.NewsPressureExternal[index];
							string	pressure	= Strings.NewsPressureExternalPressures[(int)Universe[i].Pressure];
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

					for (int i = 0; i <= Functions.GetRandom2(headlines.Length); i++)
					{
						int	index	= Functions.GetRandom2(headlines.Length);
						if (!shown[index])
						{
							items.Add(headlines[index]);
							shown[index]	= true;
						}
					}
				}

				return String.Join("\r\n\r\n", Functions.ArrayListToStringArray(items));
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
