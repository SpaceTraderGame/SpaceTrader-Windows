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
	public class HighScoreRecord: STSerializableObject
	{
		#region Member Declarations

		private string			_name				= null;
		private int					_score			= 0;
		private GameEndType	_type				= GameEndType.NA;
		private int					_days				= 0;
		private int					_worth			= 0;
		private Difficulty	_difficulty	= Difficulty.Beginner;

		#endregion

		#region Methods

		public override Hashtable Serialize()
		{
			Hashtable	hash	= base.Serialize();

			hash.Add("_name",				_name);
			hash.Add("_score",			_score);
			hash.Add("_type",				(int)_type);
			hash.Add("_days",				_days);
			hash.Add("_worth",			_worth);
			hash.Add("_difficulty",	(int)_difficulty);

			return hash;
		}

		#endregion
	}
}
