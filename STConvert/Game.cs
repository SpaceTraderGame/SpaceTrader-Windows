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
using System.Collections;

namespace Fryz.Apps.SpaceTrader
{
	[Serializable()]
	public class Game: STSerializableObject
	{
		#region Member Declarations

		private StarSystem[]	_universe										= null;
		private int[]					_wormholes									= null;
		private CrewMember[]	_mercenaries								= null;
		private Commander			_commander									= null;
		private Ship					_dragonfly									= null;
		private Ship					_scarab											= null;
		private Ship					_spaceMonster								= null;
		private Ship					_opponent										= null;
		private int						_chanceOfTradeInOrbit				= 0;
		private int						_clicks											= 0;
		private bool					_raided											= false;
		private bool					_inspected									= false;
		private bool					_tribbleMessage							= false;
		private bool					_arrivedViaWormhole					= false;
		private bool					_paidForNewspaper						= false;
		private bool					_litterWarning							= false;
		private ArrayList			_newsEvents									= null;
		private Difficulty		_difficulty									= Difficulty.Beginner;
		private bool					_cheatEnabled								= false;
		private bool					_autoSave										= false;
		private bool					_easyEncounters							= false;
		private GameEndType		_endStatus									= GameEndType.NA;
		private EncounterType	_encounterType							= EncounterType.BottleGood;
		private StarSystem		_selectedSystem							= null;
		private StarSystem		_warpSystem									= null;
		private StarSystem		_trackedSystem							= null;
		private bool					_targetWormhole							= false;
		private int[]					_priceCargoBuy							= null;
		private int[]					_priceCargoSell							= null;
		private int						_questStatusArtifact				= 0;
		private int						_questStatusDragonfly				= 0;
		private int						_questStatusExperiment			= 0;
		private int						_questStatusGemulon					= 0;
		private int						_questStatusJapori					= 0;
		private int						_questStatusJarek						= 0;
		private int						_questStatusMoon						= 0;
		private int						_questStatusReactor					= 0;
		private int						_questStatusScarab					= 0;
		private int						_questStatusSpaceMonster		= 0;
		private int						_questStatusWild						= 0;
		private int						_fabricRipProbability				= 0;
		private bool					_justLootedMarie						= false;
		private bool					_canSuperWarp								= false;
		private int						_chanceOfVeryRareEncounter	= 0;
		private ArrayList			_veryRareEncounters					= null;
		private GameOptions		_options										= null;

		#endregion

		#region Methods

		public override Hashtable Serialize()
		{
			Hashtable	hash	= base.Serialize();

			hash.Add("_version",										"2.00");
			hash.Add("_universe",										ArrayToArrayList(_universe));
			hash.Add("_wormholes",									_wormholes);
			hash.Add("_mercenaries",								ArrayToArrayList(_mercenaries));
			hash.Add("_commander",									_commander.Serialize());
			hash.Add("_dragonfly",									_dragonfly.Serialize());
			hash.Add("_scarab",											_scarab.Serialize());
			hash.Add("_spaceMonster",								_spaceMonster.Serialize());
			hash.Add("_opponent",										(_opponent == null ? _dragonfly : _opponent).Serialize());
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
			hash.Add("_selectedSystemId",						(int)(_selectedSystem == null ? StarSystemId.NA : _selectedSystem.Id));
			hash.Add("_warpSystemId",								(int)(_warpSystem == null ? StarSystemId.NA : _warpSystem.Id));
			hash.Add("_trackedSystemId",						(int)(_trackedSystem == null ? StarSystemId.NA : _trackedSystem.Id));
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
			hash.Add("_veryRareEncounters",					ArrayListToIntArray(_veryRareEncounters));
			hash.Add("_options",										_options.Serialize());

			return hash;
		}

		#endregion
	}
}
