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
	public class CrewMember
	{
		#region Member Declarations

		private CrewMemberId	_id;
		private int[]					_skills;
		private StarSystem		_curSystem;

		#endregion

		#region Properties

		public CrewMemberId	Id
		{
			get
			{
				return _id;
			}
		}

		public int[] Skills
		{
			get
			{
				return _skills;
			}
		}

		public StarSystem CurrentSystem
		{
			get
			{
				return _curSystem;
			}
		}

		#endregion
	}
}
