/*******************************************************************************
 *
 * Space Trader for Windows 2.01
 *
 * Copyright (C) 2008 Jay French, All Rights Reserved
 *
 * Additional coding by David Pierron
 * Original coding by Pieter Spronck, Sam Anderson, Samuel Goldstein, Matt Lee
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
 * You can contact the author at spacetrader@frenchfryz.com
 *
 ******************************************************************************/
using System;

namespace Fryz.Apps.SpaceTrader
{
	public class Reputation
	{
		#region Member Declarations

		private ReputationType	_type;
		private int							_minScore;

		#endregion

		#region Methods

		public Reputation(ReputationType type, int minScore)
		{
			_type			= type;
			_minScore	= minScore;
		}

		public static Reputation GetReputationFromScore(int ReputationScore)
		{
			int i;
			for (i = 0; i < Consts.Reputations.Length && Game.CurrentGame.Commander.ReputationScore >= Consts.Reputations[i].MinScore; i++);
			return Consts.Reputations[Math.Max(0, i - 1)];
		}

		#endregion

		#region Properties

		public int MinScore
		{
			get
			{
				return _minScore;
			}
		}

		public string Name
		{
			get
			{
				return Strings.ReputationNames[(int)_type];
			}
		}

		public ReputationType Type
		{
			get
			{
				return _type;
			}
		}

		#endregion
	}
}
