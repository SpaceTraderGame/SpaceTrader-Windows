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
	public class PoliticalSystem: STSerializableObject
	{
		#region Member Declarations

		private PoliticalSystemType	_type							= PoliticalSystemType.Anarchy;
		private int									_reactionIllegal	= 0;
		private Activity						_activityPolice		= Activity.Absent;
		private Activity						_activityPirates	= Activity.Absent;
		private Activity						_activityTraders	= Activity.Absent;
		private TechLevel						_minTech					= TechLevel.HiTech;
		private TechLevel						_maxTech					= TechLevel.HiTech;
		private int									_bribeLevel				= 0;
		private bool								_drugsOk					= false;
		private bool								_firearmsOk				= false;
		private TradeItemType				_wanted						= TradeItemType.NA;

		#endregion

		#region Methods

		// The following method is included only to prevent the Build Error saying
		// the member variables are not used.
		private object Dummy()
		{
			object	val;

			val	= _reactionIllegal;
			val	= _activityPolice;
			val	= _activityPirates;
			val	= _activityTraders;
			val	= _minTech;
			val	= _maxTech;
			val	= _bribeLevel;
			val	= _drugsOk;
			val	= _firearmsOk;
			val	= _wanted;

			return val;
		}

		#endregion

		#region Properties

		public PoliticalSystemType Type
		{
			get
			{
				return _type;
			}
		}

		#endregion
	}
}
