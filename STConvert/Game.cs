/*******************************************************************************
 *
 * Space Trader for Windows File Converter 2.0.0
 *
 * Copyright (C) 2004 Jay French, All Rights Reserved
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
using System.Collections;

namespace Fryz.Apps.SpaceTrader
{
	[Serializable()]      
	public class Game
	{
		#region Member Declarations

		private static Game		_game;

		// Game Data
		private StarSystem[]	_universe;
		private int[]					_wormholes;
		private CrewMember[]	_mercenaries;
		private Commander			_commander;
		private Ship					_dragonfly;
		private Ship					_scarab;
		private Ship					_spaceMonster;
		private Ship					_opponent;

		private int						_chanceOfTradeInOrbit;
		private int						_clicks;
		private bool					_raided;
		private bool					_inspected;
		private bool					_tribbleMessage;
		private bool					_arrivedViaWormhole;
		private bool					_paidForNewspaper;
		private bool					_litterWarning;
		private ArrayList			_newsEvents;

		// Current Selections
		private Difficulty		_difficulty;
		private bool					_cheatEnabled;
		private bool					_autoSave;
		private bool					_easyEncounters;
		private GameEndType		_endStatus;
		private EncounterType	_encounterType;
		private StarSystem		_selectedSystem;
		private StarSystem		_warpSystem;
		private StarSystem		_trackedSystem;
		private bool					_targetWormhole;
		private int[]					_priceCargoBuy;
		private int[]					_priceCargoSell;

		// Status of Quests
		private int						_questStatusArtifact;
		private int						_questStatusDragonfly;
		private int						_questStatusExperiment;
		private int						_questStatusGemulon;
		private int						_questStatusJapori;
		private int						_questStatusJarek;
		private int						_questStatusMoon;
		private int						_questStatusReactor;
		private int						_questStatusScarab;
		private int						_questStatusSpaceMonster;
		private int						_questStatusWild;
		private int						_fabricRipProbability;
		private bool					_justLootedMarie;
		private bool					_canSuperWarp;
		private int						_chanceOfVeryRareEncounter;
		private ArrayList			_veryRareEncounters;

		// Options
		private GameOptions		_options;

		#endregion

		#region Properties

		public bool						ArrivedViaWormhole
		{
			get
			{
				return _arrivedViaWormhole;
			}
		}

		public bool						AutoSave
		{
			get
			{
				return _autoSave;
			}
		}

		public bool						CanSuperWarp
		{
			get
			{
				return _canSuperWarp;
			}
		}

		public int						ChanceOfTradeInOrbit
		{
			get
			{
				return _chanceOfTradeInOrbit;
			}
		}

		public int						ChanceOfVeryRareEncounter
		{
			get
			{
				return _chanceOfVeryRareEncounter;
			}
		}

		public bool						CheatEnabled
		{
			get
			{
				return _cheatEnabled;
			}
		}

		public int						Clicks
		{
			get
			{
				return _clicks;
			}
		}

		public Commander			Commander
		{
			get
			{
				return _commander;
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
		}

		public EncounterType	EncounterType
		{
			get
			{
				return _encounterType;
			}
		}

		public GameEndType		EndStatus
		{
			get
			{
				return _endStatus;
			}
		}

		public int						FabricRipProbability
		{
			get
			{
				return _fabricRipProbability;
			}
		}

		public bool						Inspected
		{
			get
			{
				return _inspected;
			}
		}

		public bool						JustLootedMarie
		{
			get
			{
				return _justLootedMarie;
			}
		}

		public bool						LitterWarning
		{
			get
			{
				return _litterWarning;
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

		public Ship						Opponent
		{
			get
			{
				return _opponent;
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
		}

		public int						QuestStatusDragonfly
		{
			get
			{
				return _questStatusDragonfly;
			}
		}

		public int						QuestStatusExperiment
		{
			get
			{
				return _questStatusExperiment;
			}
		}

		public int						QuestStatusGemulon
		{
			get
			{
				return _questStatusGemulon;
			}
		}

		public int						QuestStatusJapori
		{
			get
			{
				return _questStatusJapori;
			}
		}

		public int						QuestStatusJarek
		{
			get
			{
				return _questStatusJarek;
			}
		}

		public int						QuestStatusMoon
		{
			get
			{
				return _questStatusMoon;
			}
		}

		public int						QuestStatusReactor
		{
			get
			{
				return _questStatusReactor;
			}
		}

		public int						QuestStatusScarab
		{
			get
			{
				return _questStatusScarab;
			}
		}

		public int						QuestStatusSpaceMonster
		{
			get
			{
				return _questStatusSpaceMonster;
			}
		}

		public int						QuestStatusWild
		{
			get
			{
				return _questStatusWild;
			}
		}

		public bool						Raided
		{
			get
			{
				return _raided;
			}
		}

		public Ship						Scarab
		{
			get
			{
				return _scarab;
			}
		}

		public StarSystem			SelectedSystem
		{
			get
			{
				return _selectedSystem;
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
		}

		public StarSystem			TrackedSystem
		{
			get
			{
				return _trackedSystem;
			}
		}

		public bool						TribbleMessage
		{
			get
			{
				return _tribbleMessage;
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
				return _warpSystem;
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
