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
	public class PoliticalSystem
	{
		#region Member Declarations

		private PoliticalSystemType	_type;
		private int									_reactionIllegal;
		private Activity						_activityPolice;
		private Activity						_activityPirates;
		private Activity						_activityTraders;
		private TechLevel						_minTech;
		private TechLevel						_maxTech;
		private int									_bribeLevel;
		private bool								_drugsOk;
		private bool								_firearmsOk;
		private TradeItemType				_wanted;

		#endregion

		#region Properties

		public PoliticalSystemType Type
		{
			get
			{
				return _type;
			}
		}

		public int ReactionIllegal
		{
			get
			{
				return _reactionIllegal;
			}
		}

		public Activity ActivityPolice
		{
			get
			{
				return _activityPolice;
			}
		}

		public Activity ActivityPirates
		{
			get
			{
				return _activityPirates;
			}
		}

		public Activity ActivityTraders
		{
			get
			{
				return _activityTraders;
			}
		}

		public TechLevel MinimumTechLevel
		{
			get
			{
				return _minTech;
			}
		}

		public TechLevel MaximumTechLevel
		{
			get
			{
				return _maxTech;
			}
		}

		public int BribeLevel
		{
			get
			{
				return _bribeLevel;
			}
		}

		public bool DrugsOk
		{
			get
			{
				return _drugsOk;
			}
		}

		public bool FirearmsOk
		{
			get
			{
				return _firearmsOk;
			}
		}

		public TradeItemType Wanted
		{
			get
			{
				return _wanted;
			}
		}

		#endregion
	}
}
