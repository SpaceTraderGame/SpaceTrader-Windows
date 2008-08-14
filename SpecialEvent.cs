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
using System.Collections;

namespace Fryz.Apps.SpaceTrader
{
	public class SpecialEvent
	{
		#region Constants

		public const int MoonCost											= 500000;

		public const int StatusArtifactNotStarted			= 0;
		public const int StatusArtifactOnBoard				= 1;
		public const int StatusArtifactDone						= 2;

		public const int StatusDragonflyNotStarted		= 0;
		public const int StatusDragonflyFlyBaratas		= 1;
		public const int StatusDragonflyFlyMelina			= 2;
		public const int StatusDragonflyFlyRegulas		= 3;
		public const int StatusDragonflyFlyZalkon			= 4;
		public const int StatusDragonflyDestroyed			= 5;
		public const int StatusDragonflyDone					= 6;

		public const int StatusExperimentNotStarted		= 0;
		public const int StatusExperimentStarted			= 1;
		public const int StatusExperimentDate					= 11;
		public const int StatusExperimentPerformed		= 12;
		public const int StatusExperimentCancelled		= 13;

		public const int StatusGemulonNotStarted			= 0;
		public const int StatusGemulonStarted					= 1;
		public const int StatusGemulonDate						= 7;
		public const int StatusGemulonTooLate					= 8;
		public const int StatusGemulonFuel						= 9;
		public const int StatusGemulonDone						= 10;

		public const int StatusJaporiNotStarted				= 0;
		public const int StatusJaporiInTransit				= 1;
		public const int StatusJaporiDone							= 2;

		public const int StatusJarekNotStarted				= 0;
		public const int StatusJarekStarted						= 1;
		public const int StatusJarekImpatient					= 11;
		public const int StatusJarekDone							= 12;

		public const int StatusMoonNotStarted					= 0;
		public const int StatusMoonBought							= 1;
		public const int StatusMoonDone								= 2;

		public const int StatusPrincessNotStarted			= 0;
		public const int StatusPrincessFlyCentauri		= 1;
		public const int StatusPrincessFlyInthara			= 2;
		public const int StatusPrincessFlyQonos				= 3;
		public const int StatusPrincessRescued				= 4;
		public const int StatusPrincessImpatient			= 14;
		public const int StatusPrincessReturned				= 15;
		public const int StatusPrincessDone						= 16;

		public const int StatusReactorNotStarted			= 0;
		public const int StatusReactorFuelOk					= 1;
		public const int StatusReactorDate						= 20;
		public const int StatusReactorDelivered				= 21;
		public const int StatusReactorDone						= 22;

		public const int StatusScarabNotStarted				= 0;
		public const int StatusScarabHunting					= 1;
		public const int StatusScarabDestroyed				= 2;
		public const int StatusScarabDone							= 3;

		public const int StatusSculptureNotStarted		= 0;
		public const int StatusSculptureInTransit			= 1;
		public const int StatusSculptureDelivered			= 2;
		public const int StatusSculptureDone					= 3;

		public const int StatusSpaceMonsterNotStarted	= 0;
		public const int StatusSpaceMonsterAtAcamar		= 1;
		public const int StatusSpaceMonsterDestroyed	= 2;
		public const int StatusSpaceMonsterDone				= 3;

		public const int StatusWildNotStarted					= 0;
		public const int StatusWildStarted						= 1;
		public const int StatusWildImpatient					= 11;
		public const int StatusWildDone								= 12;

		#endregion

		#region Member Declarations

		private SpecialEventType	_type;
		private int								_price;
		private int								_occurrence;
		private bool							_messageOnly;

		#endregion

		#region Methods

		public SpecialEvent(SpecialEventType type, int price, int occurrence, bool messageOnly)
		{
			_type					= type;
			_price				= price;
			_occurrence		= occurrence;
			_messageOnly	= messageOnly;
		}

		#endregion

		#region Properties

		public StarSystem Location
		{
			get
			{
				StarSystem		location	= null;
				StarSystem[]	universe	= Game.CurrentGame.Universe;

				for (int i = 0; i < universe.Length && location == null; i++)
					if (universe[i].SpecialEventType == Type)
						location	= universe[i];

				return location;
			}
		}

		public bool MessageOnly
		{
			get
			{
				return _messageOnly;
			}
		}

		public int Occurrence
		{
			get
			{
				return _occurrence;
			}
		}

		public int Price
		{
			get
			{
				return _price;
			}
		}

		public string String
		{
			get
			{
				return Strings.SpecialEventStrings[(int)_type];
			}
		}

		public string Title
		{
			get
			{
				return Strings.SpecialEventTitles[(int)_type];
			}
		}

		public SpecialEventType Type
		{
			get
			{
				return _type;
			}
		}

		#endregion
	}
}
