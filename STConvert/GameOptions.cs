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
	public class GameOptions: STSerializableObject
	{
		#region Member Declarations

		private bool	_alwaysIgnorePirates			= false;
		private bool	_alwaysIgnorePolice				= false;
		private bool	_alwaysIgnoreTradeInOrbit	= false;
		private bool	_alwaysIgnoreTraders			= false;
		private bool	_autoFuel									= false;
		private bool	_autoRepair								= false;
		private bool	_continuousAttack					= false;
		private bool	_continuousAttackFleeing	= false;
		private bool	_newsAutoPay							= false;
		private bool	_remindLoans							= false;
		private bool	_reserveMoney							= false;
		private bool	_showTrackedRange					= false;
		private bool	_trackAutoOff							= false;
		private int		_leaveEmpty								= 0;

		#endregion

		#region Methods

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
			hash.Add("_newsAutoPay",							_newsAutoPay);
			hash.Add("_remindLoans",							_remindLoans);
			hash.Add("_reserveMoney",							_reserveMoney);
			hash.Add("_showTrackedRange",					_showTrackedRange);
			hash.Add("_trackAutoOff",							_trackAutoOff);
			hash.Add("_leaveEmpty",								_leaveEmpty);

			return hash;
		}

		#endregion
	}
}
