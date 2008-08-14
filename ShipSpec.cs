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
	public class ShipSpec : STSerializableObject
	{
		#region Member Declarations

		private ShipType	_type					= ShipType.Custom;
		private Size			_size					= Size.Tiny;
		private int				_cargoBays		= 0;
		private int				_weaponSlots	= 0;
		private int				_shieldSlots	= 0;
		private int				_gadgetSlots	= 0;
		private int				_crewQuarters	= 0;
		private int				_fuelTanks		= 0;
		private int				_fuelCost			= 0;
		private int				_hullStrength	= 0;
		private int				_repairCost		= 0;
		private int				_price				= 0;
		private int				_occurrence		= 0;
		private Activity	_police				= Activity.NA;
		private Activity	_pirates			= Activity.NA;
		private Activity	_traders			= Activity.NA;
		private TechLevel	_minTech			= TechLevel.Unavailable;
		private bool			_hullUpgraded	= false;
		private int				_imageIndex		= Consts.ShipImgUseDefault;

		#endregion

		#region Methods

		public ShipSpec()
		{
		}

		public ShipSpec(ShipType type, Size size, int cargoBays, int weaponSlots, int shieldSlots, int gadgetSlots,
			int crewQuarters, int fuelTanks, int fuelCost, int hullStrength, int repairCost, int price, int occurrence,
			Activity police, Activity pirates, Activity traders, TechLevel minTechLevel)
		{
			_type					= type;
			_size					= size;
			_cargoBays		= cargoBays;
			_weaponSlots	= weaponSlots;
			_shieldSlots	= shieldSlots;
			_gadgetSlots	= gadgetSlots;
			_crewQuarters	= crewQuarters;
			_fuelTanks		= fuelTanks;
			_fuelCost			= fuelCost;
			_hullStrength	= hullStrength;
			_repairCost		= repairCost;
			_price				= price;
			_occurrence		= occurrence;
			_police				= police;
			_pirates			= pirates;
			_traders			=	traders;
			_minTech			=	minTechLevel;
		}

		public ShipSpec(Hashtable hash): base(hash)
		{
			_type					= (ShipType)GetValueFromHash(hash, "_type", _type);
			_size					= (Size)GetValueFromHash(hash, "_size", _size);
			_cargoBays		= (int)GetValueFromHash(hash, "_cargoBays", _cargoBays);
			_weaponSlots	= (int)GetValueFromHash(hash, "_weaponSlots", _weaponSlots);
			_shieldSlots	= (int)GetValueFromHash(hash, "_shieldSlots", _shieldSlots);
			_gadgetSlots	= (int)GetValueFromHash(hash, "_gadgetSlots", _gadgetSlots);
			_crewQuarters	= (int)GetValueFromHash(hash, "_crewQuarters", _crewQuarters);
			_fuelTanks		= (int)GetValueFromHash(hash, "_fuelTanks", _fuelTanks);
			_fuelCost			= (int)GetValueFromHash(hash, "_fuelCost", _fuelCost);
			_hullStrength	= (int)GetValueFromHash(hash, "_hullStrength", _hullStrength);
			_repairCost		= (int)GetValueFromHash(hash, "_repairCost", _repairCost);
			_price				= (int)GetValueFromHash(hash, "_price", _price);
			_occurrence		= (int)GetValueFromHash(hash, "_occurrence", _occurrence);
			_police				= (Activity)GetValueFromHash(hash, "_police", _police);
			_pirates			= (Activity)GetValueFromHash(hash, "_pirates", _pirates);
			_traders			= (Activity)GetValueFromHash(hash, "_traders", _traders);
			_minTech			= (TechLevel)GetValueFromHash(hash, "_minTech", _minTech);
			_hullUpgraded	= (bool)GetValueFromHash(hash, "_hullUpgraded", _hullUpgraded);
			_imageIndex		= (int)GetValueFromHash(hash, "_imageIndex", Consts.ShipImgUseDefault);

			// Get the images if the ship uses the custom images.
			if (ImageIndex == (int)ShipType.Custom)
				Game.CurrentGame.ParentWindow.CustomShipImages	= (Image[])GetValueFromHash(hash, "_images",
																													Game.CurrentGame.ParentWindow.CustomShipImages);

			// Get the name if the ship is a custom design.
			if (Type == ShipType.Custom)
			{
				Strings.ShipNames[(int)ShipType.Custom]	= (string)GetValueFromHash(hash, "_name", Strings.ShipNames[(int)ShipType.Custom]);

				Consts.ShipSpecs[(int)ShipType.Custom]	= new ShipSpec(_type, _size, _cargoBays, _weaponSlots, _shieldSlots, _gadgetSlots, _crewQuarters, _fuelTanks, _fuelCost, _hullStrength, _repairCost, _price, _occurrence, _police, _pirates, _traders, _minTech);
				UpdateCustomImageOffsetConstants();
			}
		}

		public override Hashtable Serialize()
		{
			Hashtable	hash	= base.Serialize();

			hash.Add("_type",					(int)_type);
			hash.Add("_size",					(int)_size);
			hash.Add("_cargoBays",		_cargoBays);
			hash.Add("_weaponSlots",	_weaponSlots);
			hash.Add("_shieldSlots",	_shieldSlots);
			hash.Add("_gadgetSlots",	_gadgetSlots);
			hash.Add("_crewQuarters",	_crewQuarters);
			hash.Add("_fuelTanks",		_fuelTanks);
			hash.Add("_fuelCost",			_fuelCost);
			hash.Add("_hullStrength",	_hullStrength);
			hash.Add("_repairCost",		_repairCost);
			hash.Add("_price",				_price);
			hash.Add("_occurrence",		_occurrence);
			hash.Add("_police",				(int)_police);
			hash.Add("_pirates",			(int)_pirates);
			hash.Add("_traders",			(int)_traders);
			hash.Add("_minTech",			(int)_minTech);
			hash.Add("_hullUpgraded",	_hullUpgraded);

			// Only save image index if it's not the default.
			if (_imageIndex != Consts.ShipImgUseDefault)
				hash.Add("_imageIndex",	_imageIndex);

			// Save the name if the ship is a custom design.
			if (Type == ShipType.Custom)
				hash.Add("_name",				Name);

			// Save the images if the ship uses the custom images.
			if (ImageIndex == (int)ShipType.Custom)
				hash.Add("_images",			Game.CurrentGame.ParentWindow.CustomShipImages);

			return hash;
		}

		protected virtual void SetValues(ShipType type)
		{
			int	typeInt	= (int)type;

			_type					= type;
			_size					= Consts.ShipSpecs[typeInt]._size;
			_cargoBays		= Consts.ShipSpecs[typeInt]._cargoBays;
			_weaponSlots	= Consts.ShipSpecs[typeInt]._weaponSlots;
			_shieldSlots	= Consts.ShipSpecs[typeInt]._shieldSlots;
			_gadgetSlots	= Consts.ShipSpecs[typeInt]._gadgetSlots;
			_crewQuarters	= Consts.ShipSpecs[typeInt]._crewQuarters;
			_fuelTanks		= Consts.ShipSpecs[typeInt]._fuelTanks;
			_fuelCost			= Consts.ShipSpecs[typeInt]._fuelCost;
			_hullStrength	= Consts.ShipSpecs[typeInt]._hullStrength;
			_repairCost		= Consts.ShipSpecs[typeInt]._repairCost;
			_price				= Consts.ShipSpecs[typeInt]._price;
			_occurrence		= Consts.ShipSpecs[typeInt]._occurrence;
			_police				= Consts.ShipSpecs[typeInt]._police;
			_pirates			= Consts.ShipSpecs[typeInt]._pirates;
			_traders			=	Consts.ShipSpecs[typeInt]._traders;
			_minTech			=	Consts.ShipSpecs[typeInt]._minTech;
			_hullUpgraded	= Consts.ShipSpecs[typeInt]._hullUpgraded;
			_imageIndex		= Consts.ShipSpecs[typeInt]._imageIndex;
		}

		public int Slots(EquipmentType type)
		{
			int	count	= 0;

			switch (type)
			{
				case EquipmentType.Weapon:
					count	= WeaponSlots;
					break;
				case EquipmentType.Shield:
					count	= ShieldSlots;
					break;
				case EquipmentType.Gadget:
					count	= GadgetSlots;
					break;
			}

			return count;
		}

		public void UpdateCustomImageOffsetConstants()
		{
			Image		image															= Game.CurrentGame.ParentWindow.CustomShipImages[0];
			int			custIndex													= (int)ShipType.Custom;

			// Find the first column of pixels that has a non-white pixel for the X value, and the last column for the width.
			int			x																	= Functions.GetColumnOfFirstNonWhitePixel(image, 1);
			int			width															= Functions.GetColumnOfFirstNonWhitePixel(image, -1) - x + 1;
			Consts.ShipImageOffsets[custIndex].X			= Math.Max(2, x);
			Consts.ShipImageOffsets[custIndex].Width	= Math.Min(62 - Consts.ShipImageOffsets[custIndex].X, width);
		}

		#endregion

		#region Properties

		public virtual int CargoBays
		{
			get
			{
				return _cargoBays;
			}
			set
			{
				_cargoBays	= value;
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
				_crewQuarters	= value;
			}
		}

		public int FuelCost
		{
			get
			{
				return _fuelCost;
			}
			set
			{
				_fuelCost	= value;
			}
		}

		public virtual int FuelTanks
		{
			get
			{
				return _fuelTanks;
			}
			set
			{
				_fuelTanks	= value;
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
				_gadgetSlots	= value;
			}
		}

		public int HullStrength
		{
			get
			{
				return _hullStrength + (HullUpgraded ? Consts.HullUpgrade : 0);
			}
			set
			{
				_hullStrength	= value;
			}
		}

		public bool HullUpgraded
		{
			get
			{
				return _hullUpgraded;
			}
			set
			{
				_hullUpgraded = value;
			}
		}

		public Image Image
		{
			get
			{
				return Game.CurrentGame.ParentWindow.ShipImages.Images[ImageIndex * Consts.ImagesPerShip + Consts.ShipImgOffsetNormal];
			}
		}

		public Image ImageDamaged
		{
			get
			{
				return Game.CurrentGame.ParentWindow.ShipImages.Images[ImageIndex * Consts.ImagesPerShip + Consts.ShipImgOffsetDamage];
			}
		}

		public Image ImageDamagedWithShields
		{
			get
			{
				return Game.CurrentGame.ParentWindow.ShipImages.Images[ImageIndex * Consts.ImagesPerShip + Consts.ShipImgOffsetSheildDamage];
			}
		}

		public int ImageIndex
		{
			get
			{
				return (_imageIndex == Consts.ShipImgUseDefault ? (int)Type : _imageIndex);
			}
			set
			{
				_imageIndex	= (value == (int)Type ? Consts.ShipImgUseDefault : value) ;
			}
		}

		public Image ImageWithShields
		{
			get
			{
				return Game.CurrentGame.ParentWindow.ShipImages.Images[ImageIndex * Consts.ImagesPerShip + Consts.ShipImgOffsetShield];
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
				return Strings.ShipNames[(int)Type];
			}
		}

		public int Occurrence
		{
			get
			{
				return _occurrence;
			}
		}

		public Activity Police
		{
			get
			{
				return _police;
			}
		}

		public Activity Pirates
		{
			get
			{
				return _pirates;
			}
		}

		public int Price
		{
			get
			{
				return _price;
			}
			set
			{
				_price	= value;
			}
		}

		public int RepairCost
		{
			get
			{
				return _repairCost;
			}
			set
			{
				_repairCost	= value;
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
				_shieldSlots	= value;
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
				_size	= value;
			}
		}

		public Activity Traders
		{
			get
			{
				return _traders;
			}
		}

		public ShipType Type
		{
			get
			{
				return _type;
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
				_weaponSlots	= value;
			}
		}

		#endregion
	}
}
