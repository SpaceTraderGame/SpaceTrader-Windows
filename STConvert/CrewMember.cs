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
	public class CrewMember: STSerializableObject
	{
		#region Member Declarations

		private CrewMemberId	_id					= CrewMemberId.Commander;
		private int[]					_skills			= null;
		private StarSystem		_curSystem	= null;

		#endregion

		#region Methods

		public override Hashtable Serialize()
		{
			Hashtable	hash	= base.Serialize();

			hash.Add("_id",						(int)_id);
			hash.Add("_skills",				_skills);
			hash.Add("_curSystemId",	(int)(_curSystem == null ? StarSystemId.NA : _curSystem.Id));

			return hash;
		}

		#endregion

		#region Properties

		public CrewMemberId Id
		{
			get
			{
				return _id;
			}
		}

		#endregion
	}
}
