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

namespace Fryz.Apps.SpaceTrader
{
	[Serializable()]      
	public class GameOptions
	{
		#region Member Declarations

		private bool	_alwaysIgnorePirates;
		private bool	_alwaysIgnorePolice;
		private bool	_alwaysIgnoreTradeInOrbit;
		private bool	_alwaysIgnoreTraders;
		private bool	_autoFuel;
		private bool	_autoRepair;
		private bool	_continuousAttack;
		private bool	_continuousAttackFleeing;
		private bool	_newsAutoPay;
		private bool	_remindLoans;
		private bool	_reserveMoney;
		private bool	_showTrackedRange;
		private bool	_trackAutoOff;
		private int		_leaveEmpty;

		#endregion

		#region Properties

		public bool AlwaysIgnorePirates
		{
			get
			{
				return _alwaysIgnorePirates;
			}
		}

		public bool AlwaysIgnorePolice
		{
			get
			{
				return _alwaysIgnorePolice;
			}
		}

		public bool AlwaysIgnoreTradeInOrbit
		{
			get
			{
				return _alwaysIgnoreTradeInOrbit;
			}
		}

		public bool AlwaysIgnoreTraders
		{
			get
			{
				return _alwaysIgnoreTraders;
			}
		}

		public bool AutoFuel
		{
			get
			{
				return _autoFuel;
			}
		}

		public bool AutoRepair
		{
			get
			{
				return _autoRepair;
			}
		}

		public bool ContinuousAttack
		{
			get
			{
				return _continuousAttack;
			}
		}

		public bool ContinuousAttackFleeing
		{
			get
			{
				return _continuousAttackFleeing;
			}
		}

		public bool NewsAutoPay
		{
			get
			{
				return _newsAutoPay;
			}
		}

		public bool RemindLoans
		{
			get
			{
				return _remindLoans;
			}
		}

		public bool ReserveMoney
		{
			get
			{
				return _reserveMoney;
			}
		}

		public bool ShowTrackedRange
		{
			get
			{
				return _showTrackedRange;
			}
		}

		public bool TrackAutoOff
		{
			get
			{
				return _trackAutoOff;
			}
		}

		public int LeaveEmpty
		{
			get
			{
				return _leaveEmpty;
			}
		}

		#endregion
	}
}
