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
	public class StarSystem
	{
		#region Member Declarations

		private StarSystemId		_id;
		private int							_x;
		private int							_y;
		private Size						_size;
		private TechLevel				_techLevel;
		private PoliticalSystem	_politicalSystem;
		private SystemPressure	_pressure;
		private SpecialResource	_specialResource;
		private SpecialEvent		_specialEvent;
		private int[]						_tradeItems;
		private int							_countDown;
		private bool						_visited;

		#endregion

		#region Properties

		public StarSystemId Id
		{
			get
			{
				return _id;
			}
		}

		public int X
		{
			get
			{
				return _x;
			}
		}

		public int Y
		{
			get
			{
				return _y;
			}
		}

		public Size Size
		{
			get
			{
				return _size;
			}
		}

		public TechLevel TechLevel
		{
			get
			{
				return _techLevel;
			}
		}

		public PoliticalSystem PoliticalSystem
		{
			get
			{
				return _politicalSystem;
			}
		}

		public SystemPressure Pressure
		{
			get
			{
				return _pressure;
			}
		}

		public SpecialResource SpecialResource
		{
			get
			{
				return _specialResource;
			}
		}

		public SpecialEvent SpecialEvent
		{
			get
			{
				return _specialEvent;
			}
		}

		public int[] TradeItems
		{
			get
			{
				return _tradeItems;
			}
		}

		public int CountDown
		{
			get
			{
				return _countDown;
			}
		}

		public bool Visited
		{
			get
			{
				return _visited;
			}
		}

		#endregion
	}
}
