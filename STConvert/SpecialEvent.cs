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
	public class SpecialEvent: STSerializableObject
	{
		#region Member Declarations

		private SpecialEventType	_type					= SpecialEventType.Artifact;
		private int								_price				= 0;
		private int								_occurance		= 0;			// This was spelled wrong in the previous version
		private bool							_messageOnly	= false;
		private StarSystem				_location			= null;		// Legacy

		#endregion

		#region Methods

		// The following method is included only to prevent the Build Error saying
		// the member variables are not used.
		private object Dummy()
		{
			object	val;

			val	= _price;
			val	= _occurance;
			val	= _messageOnly;
			val	= _location;

			return val;
		}

		#endregion

		#region Properties

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
