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
	public abstract class STSerializableObject
	{
		public static ArrayList ArrayToArrayList(STSerializableObject[] array)
		{
			ArrayList list	= null;
			
			if (array != null)
			{
				list	= new ArrayList();

				foreach (STSerializableObject obj in array)
					list.Add(obj == null ? null : obj.Serialize());
			}

			return list;
		}

		public virtual Hashtable Serialize()
		{
			return new Hashtable();
		}
	}
}
