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
	public class Ship : ShipSpec
	{
		#region Member Declarations

		private int						_fuel;
		private int						_hull;
		private int						_tribbles;
		private int[]					_cargo;
		private Weapon[]			_weapons;
		private Shield[]			_shields;
		private Gadget[]			_gadgets;
		private CrewMember[]	_crew;
		private bool					_pod;

		private bool[]				_tradeableItems;

		#endregion

		#region Properties

		public int Fuel
		{
			get
			{
				return _fuel;
			}
		}

		public int Hull
		{
			get
			{
				return _hull;
			}
		}

		public int Tribbles
		{
			get
			{
				return _tribbles;
			}
		}

		public int[] Cargo
		{
			get
			{
				return _cargo;
			}
		}

		public Weapon[] Weapons
		{
			get
			{
				return _weapons;
			}
		}

		public Shield[] Shields
		{
			get
			{
				return _shields;
			}
		}

		public Gadget[] Gadgets
		{
			get
			{
				return _gadgets;
			}
		}

		public CrewMember[] Crew
		{
			get
			{
				return _crew;
			}
		}

		public bool EscapePod
		{
			get
			{
				return _pod;
			}
		}

		public bool[] TradeableItems
		{
			get
			{
				return _tradeableItems;
			}
		}

		#endregion
	}
}
