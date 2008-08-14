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

namespace Fryz.Apps.SpaceTrader
{
	public class StarSystem : STSerializableObject
	{
		#region Member Declarations

		private StarSystemId				_id;
		private int									_x;
		private int									_y;
		private Size								_size;
		private TechLevel						_techLevel;
		private PoliticalSystemType	_politicalSystemType;
		private SystemPressure			_systemPressure;
		private SpecialResource			_specialResource;
		private SpecialEventType		_specialEventType			= SpecialEventType.NA;
		private int[]								_tradeItems						= new int[10];
		private int									_countDown						= 0;
		private bool								_visited							= false;
		private ShipyardId					_shipyardId						= ShipyardId.NA;

		#endregion

		#region Methods

		public StarSystem(StarSystemId id, int x, int y, Size size, TechLevel techLevel,
			PoliticalSystemType politicalSystemType, SystemPressure systemPressure, SpecialResource specialResource)
		{
			_id										= id;
			_x										= x;
			_y										= y;
			_size									= size;
			_techLevel						= techLevel;
			_politicalSystemType	= politicalSystemType;
			_systemPressure				= systemPressure;
			_specialResource			= specialResource;

			InitializeTradeItems();
		}

		public StarSystem(Hashtable hash): base(hash)
		{
			_id										= (StarSystemId)GetValueFromHash(hash, "_id", _id);
			_x										= (int)GetValueFromHash(hash, "_x", _x);
			_y										= (int)GetValueFromHash(hash, "_y", _y);
			_size									= (Size)GetValueFromHash(hash, "_size", _size);
			_techLevel						= (TechLevel)GetValueFromHash(hash, "_techLevel", _techLevel);
			_politicalSystemType	= (PoliticalSystemType)GetValueFromHash(hash, "_politicalSystemType", _politicalSystemType);
			_systemPressure				= (SystemPressure)GetValueFromHash(hash, "_systemPressure", _systemPressure);
			_specialResource			= (SpecialResource)GetValueFromHash(hash, "_specialResource", _specialResource);
			_specialEventType			= (SpecialEventType)GetValueFromHash(hash, "_specialEventType", _specialEventType);
			_tradeItems						= (int[])GetValueFromHash(hash, "_tradeItems", _tradeItems);
			_countDown						= (int)GetValueFromHash(hash, "_countDown", _countDown);
			_visited							= (bool)GetValueFromHash(hash, "_visited", _visited);
			_shipyardId						= (ShipyardId)GetValueFromHash(hash, "_shipyardId", _shipyardId);
		}

		public void InitializeTradeItems()
		{
			for (int i = 0; i < Consts.TradeItems.Length; i++)
			{
				if (!ItemTraded(Consts.TradeItems[i]))
				{
					_tradeItems[i]	= 0;
				}
				else
				{
					_tradeItems[i]	= ((int)this.Size + 1) * (Functions.GetRandom(9, 14) -
						Math.Abs(Consts.TradeItems[i].TechTopProduction - this.TechLevel));

					// Because of the enormous profits possible, there shouldn't be too many robots or narcotics available.
					if (i >= (int)TradeItemType.Narcotics)
						_tradeItems[i]	= ((_tradeItems[i] * (5 - (int)Game.CurrentGame.Difficulty)) / (6 - (int)Game.CurrentGame.Difficulty)) + 1;

					if (this.SpecialResource == Consts.TradeItems[i].ResourceLowPrice)
						_tradeItems[i]	= _tradeItems[i] * 4 / 3;

					if (this.SpecialResource == Consts.TradeItems[i].ResourceHighPrice)
						_tradeItems[i]	= _tradeItems[i] * 3 / 4;

					if (this.SystemPressure == Consts.TradeItems[i].PressurePriceHike)
						_tradeItems[i]	= _tradeItems[i] / 5;

					_tradeItems[i]	= _tradeItems[i] - Functions.GetRandom(10) + Functions.GetRandom(10);

					if (_tradeItems[i] < 0)
						_tradeItems[i] = 0;
				}
			}
		}

		public bool ItemTraded(TradeItem item)
		{
			return ((item.Type != TradeItemType.Narcotics || PoliticalSystem.DrugsOk) &&
				(item.Type != TradeItemType.Firearms || PoliticalSystem.FirearmsOk) &&
				TechLevel >= item.TechProduction);
		}

		public bool ItemUsed(TradeItem item)
		{
			return ((item.Type != TradeItemType.Narcotics || PoliticalSystem.DrugsOk) &&
				(item.Type != TradeItemType.Firearms || PoliticalSystem.FirearmsOk) &&
				TechLevel >= item.TechUsage);
		}

		public override Hashtable Serialize()
		{
			Hashtable	hash	= base.Serialize();

			hash.Add("_id",										(int)_id);
			hash.Add("_x",										_x);
			hash.Add("_y",										_y);
			hash.Add("_size",									(int)_size);
			hash.Add("_techLevel",						(int)_techLevel);
			hash.Add("_politicalSystemType",	(int)_politicalSystemType);
			hash.Add("_systemPressure",				(int)_systemPressure);
			hash.Add("_specialResource",			(int)_specialResource);
			hash.Add("_specialEventType",			(int)_specialEventType);
			hash.Add("_tradeItems",						_tradeItems);
			hash.Add("_countDown",						_countDown);
			hash.Add("_visited",							_visited);
			hash.Add("_shipyardId",						(int)_shipyardId);

			return hash;
		}

		public bool ShowSpecialButton()
		{
			Game	game	= Game.CurrentGame;
			bool	show	= false;

			switch (SpecialEventType)
			{
				case SpecialEventType.Artifact:
				case SpecialEventType.Dragonfly:
				case SpecialEventType.Experiment:
				case SpecialEventType.Jarek:
					show	= game.Commander.PoliceRecordScore >= Consts.PoliceRecordScoreDubious;
					break;
				case SpecialEventType.ArtifactDelivery:
					show	= game.Commander.Ship.ArtifactOnBoard;
					break;
				case SpecialEventType.CargoForSale:
					show	= game.Commander.Ship.FreeCargoBays >= 3;
					break;
				case SpecialEventType.DragonflyBaratas:
					show	= game.QuestStatusDragonfly > SpecialEvent.StatusDragonflyNotStarted &&
									game.QuestStatusDragonfly < SpecialEvent.StatusDragonflyDestroyed;
					break;
				case SpecialEventType.DragonflyDestroyed:
					show	= game.QuestStatusDragonfly == SpecialEvent.StatusDragonflyDestroyed;
					break;
				case SpecialEventType.DragonflyMelina:
					show	= game.QuestStatusDragonfly > SpecialEvent.StatusDragonflyFlyBaratas &&
									game.QuestStatusDragonfly < SpecialEvent.StatusDragonflyDestroyed;
					break;
				case SpecialEventType.DragonflyRegulas:
					show	= game.QuestStatusDragonfly > SpecialEvent.StatusDragonflyFlyMelina &&
									game.QuestStatusDragonfly < SpecialEvent.StatusDragonflyDestroyed;
					break;
				case SpecialEventType.DragonflyShield:
				case SpecialEventType.ExperimentFailed:
				case SpecialEventType.Gemulon:
				case SpecialEventType.GemulonFuel:
				case SpecialEventType.GemulonInvaded:
				case SpecialEventType.Lottery:
				case SpecialEventType.ReactorLaser:
				case SpecialEventType.PrincessQuantum:
				case SpecialEventType.SculptureHiddenBays:
				case SpecialEventType.Skill:
				case SpecialEventType.SpaceMonster:
				case SpecialEventType.Tribble:
					show	= true;
					break;
				case SpecialEventType.EraseRecord:
				case SpecialEventType.Wild:
					show	= game.Commander.PoliceRecordScore < Consts.PoliceRecordScoreDubious;
					break;
				case SpecialEventType.ExperimentStopped:
					show	= game.QuestStatusExperiment > SpecialEvent.StatusExperimentNotStarted &&
									game.QuestStatusExperiment < SpecialEvent.StatusExperimentPerformed;
					break;
				case SpecialEventType.GemulonRescued:
					show	= game.QuestStatusGemulon > SpecialEvent.StatusGemulonNotStarted &&
									game.QuestStatusGemulon < SpecialEvent.StatusGemulonTooLate;
					break;
				case SpecialEventType.Japori:
					show	= game.QuestStatusJapori						== SpecialEvent.StatusJaporiNotStarted &&
									game.Commander.PoliceRecordScore	>= Consts.PoliceRecordScoreDubious;
					break;
				case SpecialEventType.JaporiDelivery:
					show	= game.QuestStatusJapori == SpecialEvent.StatusJaporiInTransit;
					break;
				case SpecialEventType.JarekGetsOut:
					show	= game.Commander.Ship.JarekOnBoard;
					break;
				case SpecialEventType.Moon:
					show	= game.QuestStatusMoon == SpecialEvent.StatusMoonNotStarted &&
									game.Commander.Worth >  SpecialEvent.MoonCost * .8;
					break;
				case SpecialEventType.MoonRetirement:
					show	= game.QuestStatusMoon == SpecialEvent.StatusMoonBought;
					break;
				case SpecialEventType.Princess:
					show	= game.Commander.PoliceRecordScore	>= Consts.PoliceRecordScoreLawful &&
									game.Commander.ReputationScore		>= Consts.ReputationScoreAverage;
					break;
				case SpecialEventType.PrincessCentauri:
					show	= game.QuestStatusPrincess >= SpecialEvent.StatusPrincessFlyCentauri &&
									game.QuestStatusPrincess <= SpecialEvent.StatusPrincessFlyQonos;
					break;
				case SpecialEventType.PrincessInthara:
					show	= game.QuestStatusPrincess >= SpecialEvent.StatusPrincessFlyInthara &&
									game.QuestStatusPrincess <= SpecialEvent.StatusPrincessFlyQonos;
					break;
				case SpecialEventType.PrincessQonos:
					show	= game.QuestStatusPrincess == SpecialEvent.StatusPrincessRescued &&
						!game.Commander.Ship.PrincessOnBoard;
					break;
				case SpecialEventType.PrincessReturned:
					show	= game.Commander.Ship.PrincessOnBoard;
					break;
				case SpecialEventType.Reactor:
					show	= game.QuestStatusReactor						== SpecialEvent.StatusReactorNotStarted &&
									game.Commander.PoliceRecordScore	<  Consts.PoliceRecordScoreDubious &&
									game.Commander.ReputationScore		>= Consts.ReputationScoreAverage;
					break;
				case SpecialEventType.ReactorDelivered:
					show	= game.Commander.Ship.ReactorOnBoard;
					break;
				case SpecialEventType.Scarab:
					show	= game.QuestStatusScarab					== SpecialEvent.StatusScarabNotStarted &&
									game.Commander.ReputationScore	>= Consts.ReputationScoreAverage;
					break;
				case SpecialEventType.ScarabDestroyed:
				case SpecialEventType.ScarabUpgradeHull:
					show	= game.QuestStatusScarab == SpecialEvent.StatusScarabDestroyed;
					break;
				case SpecialEventType.Sculpture:
					show	= game.QuestStatusSculpture					== SpecialEvent.StatusSculptureNotStarted &&
									game.Commander.PoliceRecordScore	<  Consts.PoliceRecordScoreDubious &&
									game.Commander.ReputationScore		>= Consts.ReputationScoreAverage;
					break;
				case SpecialEventType.SculptureDelivered:
					show	= game.QuestStatusSculpture	== SpecialEvent.StatusSculptureInTransit;
					break;
				case SpecialEventType.SpaceMonsterKilled:
					show	= game.QuestStatusSpaceMonster == SpecialEvent.StatusSpaceMonsterDestroyed;
					break;
				case SpecialEventType.TribbleBuyer:
					show	= game.Commander.Ship.Tribbles > 0;
					break;
				case SpecialEventType.WildGetsOut:
					show	= game.Commander.Ship.WildOnBoard;
					break;
				default:
					break;
			}

			return show;
		}

		#endregion

		#region Properties

		public int CountDown
		{
			get
			{
				return _countDown;
			}
			set
			{
				_countDown	= value;
			}
		}

		public bool DestOk
		{
			get
			{
				Commander	comm	= Game.CurrentGame.Commander;
				return this != comm.CurrentSystem && (Distance <= comm.Ship.Fuel ||
					Functions.WormholeExists(comm.CurrentSystem, this));
			}
		}

		public int Distance
		{
			get
			{
				return Functions.Distance(this, Game.CurrentGame.Commander.CurrentSystem);
			}
		}

		public StarSystemId Id
		{
			get
			{
				return _id;
			}
		}

		public CrewMember[] MercenariesForHire
		{
			get
			{
				Commander			cmdr		= Game.CurrentGame.Commander;
				CrewMember[]	mercs		= Game.CurrentGame.Mercenaries;
				ArrayList			forHire	= new ArrayList(3);

				for (int i = 1; i < mercs.Length; i++)
				{
					if (mercs[i].CurrentSystem == cmdr.CurrentSystem && !cmdr.Ship.HasCrew(mercs[i].Id))
						forHire.Add(mercs[i]);
				}

				return (CrewMember[])forHire.ToArray(typeof(CrewMember));
			}
		}

		public string Name
		{
			get
			{
				return Strings.SystemNames[(int)_id];
			}
		}

		public PoliticalSystem PoliticalSystem
		{
			get
			{
				return Consts.PoliticalSystems[(int)_politicalSystemType];
			}
		}

		public PoliticalSystemType PoliticalSystemType
		{
			get
			{
				return _politicalSystemType;
			}
			set
			{
				_politicalSystemType	= value;
			}
		}

		public Shipyard Shipyard
		{
			get
			{
				return (_shipyardId == ShipyardId.NA ? null : Consts.Shipyards[(int)_shipyardId]);
			}
		}

		public ShipyardId ShipyardId
		{
			get
			{
				return _shipyardId;
			}
			set
			{
				_shipyardId	= value;
			}
		}
		public Size Size
		{
			get
			{
				return _size;
			}
		}

		public SpecialEvent SpecialEvent
		{
			get
			{
				return (_specialEventType == SpecialEventType.NA ? null : Consts.SpecialEvents[(int)_specialEventType]);
			}
		}

		public SpecialEventType SpecialEventType
		{
			get
			{
				return _specialEventType;
			}
			set
			{
				_specialEventType   = value;
			}
		}

		public SpecialResource SpecialResource
		{
			get
			{
				return Visited ? _specialResource : SpecialResource.Nothing;
			}
		}

		public SystemPressure SystemPressure
		{
			get
			{
				return _systemPressure;
			}
			set
			{
				_systemPressure  = value;
			}
		}

		public TechLevel TechLevel
		{
			get
			{
				return _techLevel;
			}
			set
			{
				_techLevel	= value;
			}
		}

		public int[] TradeItems
		{
			get
			{
				return _tradeItems;
			}
		}

		public bool Visited
		{
			get
			{
				return _visited;
			}
			set
			{
				_visited	= value;
			}
		}

		public int X
		{
			get
			{
				return _x;
			}
			set
			{
				_x	= value;
			}
		}

		public int Y
		{
			get
			{
				return _y;
			}
			set
			{
				_y	= value;
			}
		}

		#endregion
	}
}
