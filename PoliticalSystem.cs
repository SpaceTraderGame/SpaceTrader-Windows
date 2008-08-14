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
	public class PoliticalSystem
	{
		#region Member Declarations

		private PoliticalSystemType	_type;
		private int									_reactionIllegal;	// Reaction level of illegal goods 0 = total acceptance (determines how police reacts if they find you carry them)
		private Activity						_activityPolice;	// Activity level of police force 0 = no police (determines occurrence rate)
		private Activity						_activityPirates;	// Activity level of pirates 0 = no pirates
		private Activity						_activityTraders;	// Activity level of traders 0 = no traders
		private TechLevel						_minTech;					// Mininum tech level needed
		private TechLevel						_maxTech;					// Maximum tech level where this is found
		private int									_bribeLevel;			// Indicates how easily someone can be bribed 0 = unbribeable/high bribe costs
		private bool								_drugsOk;					// Drugs can be traded (if not, people aren't interested or the governemnt is too strict)
		private bool								_firearmsOk;			// Firearms can be traded (if not, people aren't interested or the governemnt is too strict)
		private TradeItemType				_wanted;					// Tradeitem requested in particular in this type of government

		#endregion

		#region Methods

		public PoliticalSystem(PoliticalSystemType type, int reactionIllegal, Activity activityPolice, Activity activityPirates,
			Activity activityTraders, TechLevel minTechLevel, TechLevel maxTechLevel, int bribeLevel, bool drugsOk,
			bool firearmsOk, TradeItemType wanted)
		{
			_type							= type;
			_reactionIllegal	= reactionIllegal;
			_activityPolice		= activityPolice;
			_activityPirates	= activityPirates;
			_activityTraders	= activityTraders;
			_minTech					= minTechLevel;
			_maxTech					= maxTechLevel;
			_bribeLevel				= bribeLevel;
			_drugsOk					= drugsOk;
			_firearmsOk				= firearmsOk;
			_wanted						= wanted;
		}

		public bool ShipTypeLikely(ShipType shipType, OpponentType oppType)
		{
			bool	likely	= false;
			int		diffMod	= Math.Max(0, (int)Game.CurrentGame.Difficulty - (int)Difficulty.Normal);

			switch (oppType)
			{
				case OpponentType.Pirate:
					likely	= (int)ActivityPirates + diffMod >= (int)Consts.ShipSpecs[(int)shipType].Pirates;
					break;
				case OpponentType.Police:
					likely	= (int)ActivityPolice + diffMod >= (int)Consts.ShipSpecs[(int)shipType].Police;
					break;
				case OpponentType.Trader:
					likely	= (int)ActivityTraders + diffMod >= (int)Consts.ShipSpecs[(int)shipType].Traders;
					break;
			}

			return likely;
		}

		#endregion

		#region Properties

		public Activity ActivityPirates
		{
			get
			{
				return _activityPirates;
			}
		}

		public Activity ActivityPolice
		{
			get
			{
				return _activityPolice;
			}
		}

		public Activity ActivityTraders
		{
			get
			{
				return _activityTraders;
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

		public TechLevel MaximumTechLevel
		{
			get
			{
				return _maxTech;
			}
		}

		public TechLevel MinimumTechLevel
		{
			get
			{
				return _minTech;
			}
		}

		public string Name
		{
			get
			{
				return Strings.PoliticalSystemNames[(int)_type];
			}
		}

		public int ReactionIllegal
		{
			get
			{
				return _reactionIllegal;
			}
		}

		public PoliticalSystemType Type
		{
			get
			{
				return _type;
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
