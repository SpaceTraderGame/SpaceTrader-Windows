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

		public override Hashtable Serialize()
		{
			Hashtable	hash	= base.Serialize();

			hash.Add("_type",							(int)_type);
			hash.Add("_reactionIllegal",	_reactionIllegal);
			hash.Add("_activityPolice",		(int)_activityPolice);
			hash.Add("_activityPirates",	(int)_activityPirates);
			hash.Add("_activityTraders",	(int)_activityTraders);
			hash.Add("_minTech",					(int)_minTech);
			hash.Add("_maxTech",					(int)_maxTech);
			hash.Add("_bribeLevel",				_bribeLevel);
			hash.Add("_drugsOk",					_drugsOk);
			hash.Add("_firearmsOk",				_firearmsOk);
			hash.Add("_wanted",						(int)_wanted);

			return hash;
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
