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
	public class Gadget : Equipment
	{
		#region Member Declarations

		private GadgetType	_type;
		private SkillType		_skillBonus;

		#endregion

		#region Methods

		public Gadget(GadgetType type, SkillType skillBonus, int price, TechLevel minTechLevel, int chance):
			base(EquipmentType.Gadget, price, minTechLevel, chance)
		{
			_type				= type;
			_skillBonus	= skillBonus;
		}

		public Gadget(Hashtable hash): base(hash)
		{
			_type				= (GadgetType)GetValueFromHash(hash, "_type");
			_skillBonus	= (SkillType)GetValueFromHash(hash, "_skillBonus", SkillType.NA);
		}

		public override Equipment Clone()
		{
			return new Gadget(_type, _skillBonus, _price, _minTech, _chance);
		}

		public override Hashtable Serialize()
		{
			Hashtable	hash	= base.Serialize();

			hash.Add("_type",				(int)_type);
			hash.Add("_skillBonus",	(int)_skillBonus);

			return hash;
		}

		public override bool TypeEquals(object type)
		{
			bool equal	= false;

			try
			{
				if (Type == (GadgetType)type)
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
				return Strings.GadgetNames[(int)_type];
			}
		}

		public override object SubType
		{
			get
			{
				return Type;
			}
		}

		public GadgetType Type
		{
			get
			{
				return _type;
			}
		}

		public SkillType SkillBonus
		{
			get
			{
				return _skillBonus;
			}
		}

		#endregion
	}
}
