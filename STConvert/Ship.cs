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
	public class Ship : ShipSpec
	{
		#region Member Declarations

		private int						_fuel						= 0;
		private int						_hull						= 0;
		private int						_tribbles				= 0;
		private int[]					_cargo					= null;
		private Weapon[]			_weapons				= null;
		private Shield[]			_shields				= null;
		private Gadget[]			_gadgets				= null;
		private CrewMember[]	_crew						= null;
		private bool					_pod						= false;

		// The following does not need to be saved. It's more of a temp variable.
		private bool[]				_tradeableItems	= null;

		#endregion

		#region Methods

		public override Hashtable Serialize()
		{
			Hashtable	hash	= base.Serialize();

			// We don't want the actual CrewMember objects - we just want the ids.
			int[]	crewIds	= new int[_crew.Length];
			for (int i = 0; i < crewIds.Length; i++)
				crewIds[i]	= (int)(_crew[i] == null ? CrewMemberId.NA : _crew[i].Id);

			hash.Add("_fuel",						_fuel);
			hash.Add("_hull",						_hull);
			hash.Add("_tribbles",				_tribbles);
			hash.Add("_cargo",					_cargo);
			hash.Add("_weapons",				ArrayToArrayList(_weapons));
			hash.Add("_shields",				ArrayToArrayList(_shields));
			hash.Add("_gadgets",				ArrayToArrayList(_gadgets));
			hash.Add("_crewIds",				crewIds);
			hash.Add("_pod",						_pod);

			return hash;
		}

		// The following method is included only to prevent the Build Error saying
		// the member variables are not used.
		private object Dummy()
		{
			object	val;

			val	= _tradeableItems;

			return val;
		}

		#endregion
	}
}
