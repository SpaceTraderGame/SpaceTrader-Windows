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
	public class Commander: CrewMember
	{
		#region Member Declarations

		private int					_cash								= 0;
		private int					_debt								= 0;
		private int					_killsPirate				= 0;
		private int					_killsPolice				= 0;
		private int					_killsTrader				= 0;
		private int					_policeRecordScore	= 0;
		private int					_reputationScore		= 0;
		private int					_days								= 0;
		private bool				_insurance					= false;
		private int					_noclaim						= 0;
		private Ship				_ship								= null;
		private int[]				_priceCargo					= null;
		private string			_name								= null;

		#endregion

		#region Methods

		public override Hashtable Serialize()
		{
			Hashtable	hash	= base.Serialize();

			hash.Add("_cash",								_cash);
			hash.Add("_debt",								_debt);
			hash.Add("_killsPirate",				_killsPirate);
			hash.Add("_killsPolice",				_killsPolice);
			hash.Add("_killsTrader",				_killsTrader);
			hash.Add("_policeRecordScore",	_policeRecordScore);
			hash.Add("_reputationScore",		_reputationScore);
			hash.Add("_days",								_days);
			hash.Add("_insurance",					_insurance);
			hash.Add("_noclaim",						_noclaim);
			hash.Add("_ship",								(_ship == null ? null : _ship.Serialize()));
			hash.Add("_priceCargo",					_priceCargo);
			hash.Add("_name",								_name);

			return hash;
		}

		#endregion
	}
}
