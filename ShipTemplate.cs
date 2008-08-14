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
using System.Drawing;

namespace Fryz.Apps.SpaceTrader
{
	public class ShipTemplate : STSerializableObject, IComparable
	{
		#region Member Variables

		private string	_name					= null;
		private Size		_size					= Size.Tiny;
		private int			_imageIndex		= (int)ShipType.Custom;
		private int			_cargoBays		= 0;
		private int			_weaponSlots	= 0;
		private int			_shieldSlots	= 0;
		private int			_gadgetSlots	= 0;
		private int			_crewQuarters	= 0;
		private int			_fuelTanks		= 0;
		private int			_hullStrength	= 0;
		private Image[]	_images				= null;

		#endregion

		#region Methods

		public ShipTemplate(Size size, string name)
		{
			_name		= name;
			_size		= size;
			_images	= Game.CurrentGame.ParentWindow.CustomShipImages;
		}

		public ShipTemplate(ShipSpec spec, string name)
		{
			_name					= name;
			_size					= spec.Size;
			_imageIndex		= spec.ImageIndex;
			_cargoBays		= spec.CargoBays;
			_weaponSlots	= spec.WeaponSlots;
			_shieldSlots	= spec.ShieldSlots;
			_gadgetSlots	= spec.GadgetSlots;
			_crewQuarters	= spec.CrewQuarters;
			_fuelTanks		= spec.FuelTanks;
			_hullStrength	= spec.HullStrength;

			if (ImageIndex == Consts.ShipImgUseDefault)
				_images			= Game.CurrentGame.ParentWindow.CustomShipImages;
		}

		public ShipTemplate(Hashtable hash)
		{
			_name					= (string)GetValueFromHash(hash, "_name", _name);
			_size					= (Size)GetValueFromHash(hash, "_size", _size);
			_imageIndex		= (int)GetValueFromHash(hash, "_imageIndex", _imageIndex);
			_cargoBays		= (int)GetValueFromHash(hash, "_cargoBays", _cargoBays);
			_weaponSlots	= (int)GetValueFromHash(hash, "_weaponSlots", _weaponSlots);
			_shieldSlots	= (int)GetValueFromHash(hash, "_shieldSlots", _shieldSlots);
			_gadgetSlots	= (int)GetValueFromHash(hash, "_gadgetSlots", _gadgetSlots);
			_crewQuarters	= (int)GetValueFromHash(hash, "_crewQuarters", _crewQuarters);
			_fuelTanks		= (int)GetValueFromHash(hash, "_fuelTanks", _fuelTanks);
			_hullStrength	= (int)GetValueFromHash(hash, "_hullStrength", _hullStrength);
			_images				= (Image[])GetValueFromHash(hash, "_images", _images);
		}

		public int CompareTo(object value)
		{
			int	compared	= 0;

			if (value == null)
				compared	= 1;
			else
				compared	= Name.CompareTo(((ShipTemplate)value).Name);

			return compared;
		}

		public override Hashtable Serialize()
		{
			Hashtable	hash	= base.Serialize();

			hash.Add("_name",					_name);
			hash.Add("_size",					(int)_size);
			hash.Add("_imageIndex",		_imageIndex);
			hash.Add("_cargoBays",		_cargoBays);
			hash.Add("_weaponSlots",	_weaponSlots);
			hash.Add("_shieldSlots",	_shieldSlots);
			hash.Add("_gadgetSlots",	_gadgetSlots);
			hash.Add("_crewQuarters",	_crewQuarters);
			hash.Add("_fuelTanks",		_fuelTanks);
			hash.Add("_hullStrength",	_hullStrength);

			if (_images != null)
				hash.Add("_images",			_images);

			return hash;
		}

		public override string ToString()
		{
			return Name;
		}

		#endregion

		#region Properties

		public int CargoBays
		{
			get
			{
				return _cargoBays;
			}
			set
			{
				_cargoBays = value;
			}
		}

		public int CrewQuarters
		{
			get
			{
				return _crewQuarters;
			}
			set
			{
				_crewQuarters = value;
			}
		}

		public int FuelTanks
		{
			get
			{
				return _fuelTanks;
			}
			set
			{
				_fuelTanks = value;
			}
		}

		public int GadgetSlots
		{
			get
			{
				return _gadgetSlots;
			}
			set
			{
				_gadgetSlots = value;
			}
		}

		public int HullStrength
		{
			get
			{
				return _hullStrength;
			}
			set
			{
				_hullStrength = value;
			}
		}

		public int ImageIndex
		{
			get
			{
				return _imageIndex;
			}
			set
			{
				_imageIndex = value;
			}
		}

		public Image[] Images
		{
			get
			{
				return _images;
			}
			set
			{
				_images = value;
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		public int ShieldSlots
		{
			get
			{
				return _shieldSlots;
			}
			set
			{
				_shieldSlots = value;
			}
		}

		public Size Size
		{
			get
			{
				return _size;
			}
			set
			{
				_size = value;
			}
		}

		public int WeaponSlots
		{
			get
			{
				return _weaponSlots;
			}
			set
			{
				_weaponSlots = value;
			}
		}

		#endregion
	}
}
