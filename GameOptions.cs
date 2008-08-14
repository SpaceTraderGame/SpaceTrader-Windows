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
	public class GameOptions : STSerializableObject
	{
		#region Member Declarations

		private bool	_alwaysIgnorePirates			= false;	// Automatically ignores pirates when it is safe to do so
		private bool	_alwaysIgnorePolice				= false;	// Automatically ignores police when it is safe to do so
		private bool	_alwaysIgnoreTradeInOrbit	= false;	// Automatically ignores Trade in Orbit when it is safe to do so
		private bool	_alwaysIgnoreTraders			= true;		// Automatically ignores traders when it is safe to do so
		private bool	_autoFuel									= false;	// Automatically get a full tank when arriving in a new system
		private bool	_autoRepair								= false;	// Automatically get a full hull repair when arriving in a new system
		private bool	_continuousAttack					= false;	// Continuous attack/flee mode
		private bool	_continuousAttackFleeing	= false;	// Continue attack on fleeing ship
		private bool	_disableOpponents					= false;	// Disable opponents when possible (when you have disabling weapons and the opponent is a pirate, trader, or mantis)
		private bool	_newsAutoPay							= false;	// by default, ask each time someone buys a newspaper
		private bool	_newsAutoShow							= false;	// by default, don't show newspaper
		private bool	_remindLoans							= true;		// remind you every five days about outstanding loan balances
		private bool	_reserveMoney							= false;	// Keep enough money for insurance and mercenaries
		private bool	_showTrackedRange					= true;		// display range when tracking a system on Short Range Chart
		private bool	_trackAutoOff							= true;		// Automatically stop tracking a system when you get to it?
		private int		_leaveEmpty								= 0;			// Number of cargo bays to leave empty when buying goods

		#endregion

		#region Methods

		public GameOptions(bool loadFromDefaults)
		{
			if (loadFromDefaults)
				LoadFromDefaults(false);
		}

		public GameOptions(Hashtable hash): base(hash)
		{
			_alwaysIgnorePirates			= (bool)GetValueFromHash(hash, "_alwaysIgnorePirates", _alwaysIgnorePirates);
			_alwaysIgnorePolice				= (bool)GetValueFromHash(hash, "_alwaysIgnorePolice", _alwaysIgnorePolice);
			_alwaysIgnoreTradeInOrbit	= (bool)GetValueFromHash(hash, "_alwaysIgnoreTradeInOrbit", _alwaysIgnoreTradeInOrbit);
			_alwaysIgnoreTraders			= (bool)GetValueFromHash(hash, "_alwaysIgnoreTraders", _alwaysIgnoreTraders);
			_autoFuel									= (bool)GetValueFromHash(hash, "_autoFuel", _autoFuel);
			_autoRepair								= (bool)GetValueFromHash(hash, "_autoRepair", _autoRepair);
			_continuousAttack					= (bool)GetValueFromHash(hash, "_continuousAttack", _continuousAttack);
			_continuousAttackFleeing	= (bool)GetValueFromHash(hash, "_continuousAttackFleeing", _continuousAttackFleeing);
			_disableOpponents					= (bool)GetValueFromHash(hash, "_disableOpponents", _disableOpponents);
			_newsAutoPay							= (bool)GetValueFromHash(hash, "_newsAutoPay", _newsAutoPay);
			_newsAutoShow							= (bool)GetValueFromHash(hash, "_newsAutoShow", _newsAutoShow);
			_remindLoans							= (bool)GetValueFromHash(hash, "_remindLoans", _remindLoans);
			_reserveMoney							= (bool)GetValueFromHash(hash, "_reserveMoney", _reserveMoney);
			_showTrackedRange					= (bool)GetValueFromHash(hash, "_showTrackedRange", _showTrackedRange);
			_trackAutoOff							= (bool)GetValueFromHash(hash, "_trackAutoOff", _trackAutoOff);
			_leaveEmpty								= (int)GetValueFromHash(hash, "_leaveEmpty", _leaveEmpty);
		}

		public void CopyValues(GameOptions source)
		{
			AlwaysIgnorePirates				= source.AlwaysIgnorePirates;
			AlwaysIgnorePolice				= source.AlwaysIgnorePolice;
			AlwaysIgnoreTradeInOrbit	= source.AlwaysIgnoreTradeInOrbit;
			AlwaysIgnoreTraders				= source.AlwaysIgnoreTraders;
			AutoFuel									= source.AutoFuel;
			AutoRepair								= source.AutoRepair;
			ContinuousAttack					= source.ContinuousAttack;
			ContinuousAttackFleeing		= source.ContinuousAttackFleeing;
			DisableOpponents					= source.DisableOpponents;
			NewsAutoPay								= source.NewsAutoPay;
			NewsAutoShow							= source.NewsAutoShow;
			RemindLoans								= source.RemindLoans;
			ReserveMoney							= source.ReserveMoney;
			ShowTrackedRange					= source.ShowTrackedRange;
			TrackAutoOff							= source.TrackAutoOff;
			LeaveEmpty								= source.LeaveEmpty;
		}

		public void LoadFromDefaults(bool errorIfFileNotFound)
		{
			LoadFromDefaults(errorIfFileNotFound, null);
		}

		public void LoadFromDefaults(bool errorIfFileNotFound, System.Windows.Forms.IWin32Window owner)
		{
			GameOptions	defaults	= null;

			object			obj				= Functions.LoadFile(Consts.DefaultSettingsFile, !errorIfFileNotFound, owner);
			if (obj == null)
				defaults						= new GameOptions(false);
			else
				defaults						= new GameOptions((Hashtable)obj);

			CopyValues(defaults);
		}

		public void SaveAsDefaults(System.Windows.Forms.IWin32Window owner)
		{
			Functions.SaveFile(Consts.DefaultSettingsFile, Serialize(), owner);
		}

		public override Hashtable Serialize()
		{
			Hashtable	hash	= base.Serialize();

			hash.Add("_alwaysIgnorePirates",			_alwaysIgnorePirates);
			hash.Add("_alwaysIgnorePolice",				_alwaysIgnorePolice);
			hash.Add("_alwaysIgnoreTradeInOrbit",	_alwaysIgnoreTradeInOrbit);
			hash.Add("_alwaysIgnoreTraders",			_alwaysIgnoreTraders);
			hash.Add("_autoFuel",									_autoFuel);
			hash.Add("_autoRepair",								_autoRepair);
			hash.Add("_continuousAttack",					_continuousAttack);
			hash.Add("_continuousAttackFleeing",	_continuousAttackFleeing);
			hash.Add("_disableOpponents",					_disableOpponents);
			hash.Add("_newsAutoPay",							_newsAutoPay);
			hash.Add("_newsAutoShow",							_newsAutoShow);
			hash.Add("_remindLoans",							_remindLoans);
			hash.Add("_reserveMoney",							_reserveMoney);
			hash.Add("_showTrackedRange",					_showTrackedRange);
			hash.Add("_trackAutoOff",							_trackAutoOff);
			hash.Add("_leaveEmpty",								_leaveEmpty);

			return hash;
		}

		#endregion

		#region Properties

		public bool AlwaysIgnorePirates
		{
			get
			{
				return _alwaysIgnorePirates;
			}
			set
			{
				_alwaysIgnorePirates = value;
			}
		}

		public bool AlwaysIgnorePolice
		{
			get
			{
				return _alwaysIgnorePolice;
			}
			set
			{
				_alwaysIgnorePolice = value;
			}
		}

		public bool AlwaysIgnoreTradeInOrbit
		{
			get
			{
				return _alwaysIgnoreTradeInOrbit;
			}
			set
			{
				_alwaysIgnoreTradeInOrbit = value;
			}
		}

		public bool AlwaysIgnoreTraders
		{
			get
			{
				return _alwaysIgnoreTraders;
			}
			set
			{
				_alwaysIgnoreTraders = value;
			}
		}

		public bool AutoFuel
		{
			get
			{
				return _autoFuel;
			}
			set
			{
				_autoFuel = value;
			}
		}

		public bool AutoRepair
		{
			get
			{
				return _autoRepair;
			}
			set
			{
				_autoRepair = value;
			}
		}

		public bool ContinuousAttack
		{
			get
			{
				return _continuousAttack;
			}
			set
			{
				_continuousAttack = value;
			}
		}

		public bool ContinuousAttackFleeing
		{
			get
			{
				return _continuousAttackFleeing;
			}
			set
			{
				_continuousAttackFleeing = value;
			}
		}

		public bool DisableOpponents
		{
			get
			{
				return _disableOpponents;
			}
			set
			{
				_disableOpponents	= value;
			}
		}

		public int LeaveEmpty
		{
			get
			{
				return _leaveEmpty;
			}
			set
			{
				_leaveEmpty	= value;
			}
		}

		public bool NewsAutoPay
		{
			get
			{
				return _newsAutoPay;
			}
			set
			{
				_newsAutoPay	= value;
			}
		}

		public bool NewsAutoShow
		{
			get
			{
				return _newsAutoShow;
			}
			set
			{
				_newsAutoShow = value;
			}
		}

		public bool RemindLoans
		{
			get
			{
				return _remindLoans;
			}
			set
			{
				_remindLoans = value;
			}
		}

		public bool ReserveMoney
		{
			get
			{
				return _reserveMoney;
			}
			set
			{
				_reserveMoney = value;
			}
		}

		public bool ShowTrackedRange
		{
			get
			{
				return _showTrackedRange;
			}
			set
			{
				_showTrackedRange = value;
			}
		}

		public bool TrackAutoOff
		{
			get
			{
				return _trackAutoOff;
			}
			set
			{
				_trackAutoOff = value;
			}
		}

		#endregion
	}
}
