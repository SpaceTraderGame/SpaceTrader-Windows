/*******************************************************************************
 *
 * Space Trader for Windows 2.00
 *
 * Copyright (C) 2004 Jay French, All Rights Reserved
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
		private int				_occurance		= 0;
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
			int crewQuarters, int fuelTanks, int fuelCost, int hullStrength, int repairCost, int price, int occurance,
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
			_occurance		= occurance;
			_police				= police;
			_pirates			= pirates;
			_traders			=	traders;
			_minTech			=	minTechLevel;
		}

		public ShipSpec(Hashtable hash): base(hash)
		{
			_type					= (ShipType)hash["_type"];
			_size					= (Size)hash["_size"];
			_cargoBays		= (int)hash["_cargoBays"];
			_weaponSlots	= (int)hash["_weaponSlots"];
			_shieldSlots	= (int)hash["_shieldSlots"];
			_gadgetSlots	= (int)hash["_gadgetSlots"];
			_crewQuarters	= (int)hash["_crewQuarters"];
			_fuelTanks		= (int)hash["_fuelTanks"];
			_fuelCost			= (int)hash["_fuelCost"];
			_hullStrength	= (int)hash["_hullStrength"];
			_repairCost		= (int)hash["_repairCost"];
			_price				= (int)hash["_price"];
			_occurance		= (int)hash["_occurance"];
			_police				= (Activity)hash["_police"];
			_pirates			= (Activity)hash["_pirates"];
			_traders			= (Activity)hash["_traders"];
			_minTech			= (TechLevel)hash["_minTech"];
			_hullUpgraded	= (bool)hash["_hullUpgraded"];

			if (hash.ContainsKey("_imageIndex"))
				_imageIndex	= (int)hash["_imageIndex"];

			if (Type == ShipType.Custom)
				Strings.ShipNames[(int)ShipType.Custom]	= (string)hash["_name"];
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
			hash.Add("_occurance",		_occurance);
			hash.Add("_police",				(int)_police);
			hash.Add("_pirates",			(int)_pirates);
			hash.Add("_traders",			(int)_traders);
			hash.Add("_minTech",			(int)_minTech);
			hash.Add("_hullUpgraded",	_hullUpgraded);

			// Only save image index if it's not the default.
			if (_imageIndex != Consts.ShipImgUseDefault)
				hash.Add("_imageIndex",	_imageIndex);

			if (Type == ShipType.Custom)
				hash.Add("_name",				Name);

			return hash;
		}

		protected virtual void SetValues(ShipType type)
		{
			int	typeInt	= (int)type;

			_type					= type;
			_size					= Consts.ShipSpecs[typeInt].Size;
			_cargoBays		= Consts.ShipSpecs[typeInt].CargoBays;
			_weaponSlots	= Consts.ShipSpecs[typeInt].WeaponSlots;
			_shieldSlots	= Consts.ShipSpecs[typeInt].ShieldSlots;
			_gadgetSlots	= Consts.ShipSpecs[typeInt].GadgetSlots;
			_crewQuarters	= Consts.ShipSpecs[typeInt].CrewQuarters;
			_fuelTanks		= Consts.ShipSpecs[typeInt].FuelTanks;
			_fuelCost			= Consts.ShipSpecs[typeInt].FuelCost;
			_hullStrength	= Consts.ShipSpecs[typeInt].HullStrength;
			_repairCost		= Consts.ShipSpecs[typeInt].RepairCost;
			_price				= Consts.ShipSpecs[typeInt].Price;
			_occurance		= Consts.ShipSpecs[typeInt].Occurance;
			_police				= Consts.ShipSpecs[typeInt].Police;
			_pirates			= Consts.ShipSpecs[typeInt].Pirates;
			_traders			=	Consts.ShipSpecs[typeInt].Traders;
			_minTech			=	Consts.ShipSpecs[typeInt].MinimumTechLevel;
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
				_imageIndex	= value;
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

		public int Occurance
		{
			get
			{
				return _occurance;
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
