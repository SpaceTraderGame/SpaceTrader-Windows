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
	public abstract class STSerializableObject
	{
		#region Methods

		public STSerializableObject()
		{
		}

		public STSerializableObject(Hashtable hash)
		{
		}

		/*
		 * Types currently supported:
		 * CrewMember
		 * Gadget
		 * HighScoreRecord
		 * Shield
		 * StarSystem
		 * Weapon
		 *
		 * If an array of a type not listed is converted using ArrayToArrayList, the type
		 * needs to be added here.
		 */
		public static STSerializableObject[] ArrayListToArray(ArrayList list, string type)
		{
			STSerializableObject[]	array	= null;

			if (list != null)
			{
				switch (type)
				{
					case "CrewMember":
						array	= new CrewMember[list.Count];
						break;
					case "Gadget":
						array	= new Gadget[list.Count];
						break;
					case "HighScoreRecord":
						array	= new HighScoreRecord[list.Count];
						break;
					case "Shield":
						array	= new Shield[list.Count];
						break;
					case "StarSystem":
						array	= new StarSystem[list.Count];
						break;
					case "Weapon":
						array	= new Weapon[list.Count];
						break;
				}

				for (int index = 0; index < list.Count; index++)
				{
					Hashtable							hash	= (Hashtable)list[index];
					STSerializableObject	obj		= null;

					if (hash != null)
					{
						switch (type)
						{
							case "CrewMember":
								obj	= new CrewMember(hash);
								break;
							case "Gadget":
								obj	= new Gadget(hash);
								break;
							case "HighScoreRecord":
								obj	= new HighScoreRecord(hash);
								break;
							case "Shield":
								obj	= new Shield(hash);
								break;
							case "StarSystem":
								obj	= new StarSystem(hash);
								break;
							case "Weapon":
								obj	= new Weapon(hash);
								break;
						}
					}

					array[index]	= obj;
				}
			}

			return array;
		}

		public static int[] ArrayListToIntArray(ArrayList list)
		{
			int[]	array	= new int[list.Count];

			for (int index = 0; index < array.Length; index++)
				array[index]	= (int)list[index];

			return array;
		}

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

		public static object GetValueFromHash(Hashtable hash, string key)
		{
			return GetValueFromHash(hash, key, null);
		}

		public static object GetValueFromHash(Hashtable hash, string key, object defaultValue)
		{
			return hash.ContainsKey(key) ? hash[key] : defaultValue;
		}

		public virtual Hashtable Serialize()
		{
			return new Hashtable();
		}

		#endregion
	}
}
