/*******************************************************************************
 *
 * Space Trader for Windows 1.3.0
 *
 * Copyright (C) 2004 Jay French, All Rights Reserved
 *
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
	[Serializable()]      
	public class Weapon : Equipment
	{
		#region Member Declarations

		private WeaponType	_type;
		private int					_power;

		#endregion

		#region Methods

		public Weapon(WeaponType type, int power, int price, TechLevel minTechLevel, int chance):
			base(EquipmentType.Weapon, price, minTechLevel, chance)
		{
			_type			= type;
			_power		= power;
		}

		public override Equipment Clone()
		{
			return new Weapon(_type, _power, _price, _minTech, _chance);
		}

		public override bool TypeEquals(object type)
		{
			bool equal	= false;

			try
			{
				if (Type == (WeaponType)type)
					equal	= true;
			}
			catch (Exception) {}

			return equal;
		}

		#endregion

		#region Properties

		public override string Name
		{
			get
			{
				return Strings.WeaponNames[(int)_type];
			}
		}

		public WeaponType Type
		{
			get
			{
				return _type;
			}
		}

		public int Power
		{
			get
			{
				return _power;
			}
		}

		#endregion
	}
}
