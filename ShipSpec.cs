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
	public class ShipSpec
	{
		#region Member Declarations

		private ShipType	_type;
		private Size			_size;
		private int				_cargoBays;
		private int				_weaponSlots;
		private int				_shieldSlots;
		private int				_gadgetSlots;
		private int				_crewQuarters;
		private int				_fuelTanks;
		private int				_fuelCost;
		private int				_hullStrength;
		private int				_repairCost;
		private int				_price;
		private int				_occurance;
		private int				_police;
		private int				_pirates;
		private int				_traders;
		private TechLevel	_minTech;
		private bool			_hullUpgraded	= false;

		#endregion

		#region Methods

		public ShipSpec()
		{
		}

		public ShipSpec(ShipType type, Size size, int cargoBays, int weaponSlots, int shieldSlots, int gadgetSlots,
			int crewQuarters, int fuelTanks, int fuelCost, int hullStrength, int repairCost, int price, int occurance,
			int police, int pirates, int traders, TechLevel minTechLevel)
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

		public ShipType Type
		{
			get
			{
				return _type;
			}
		}

		public string Name
		{
			get
			{
				return Strings.ShipNames[(int)_type];
			}
		}

		public Size Size
		{
			get
			{
				return _size;
			}
		}

		public virtual int CargoBays
		{
			get
			{
				return _cargoBays;
			}
		}

		public int WeaponSlots
		{
			get
			{
				return _weaponSlots;
			}
		}

		public int ShieldSlots
		{
			get
			{
				return _shieldSlots;
			}
		}

		public int GadgetSlots
		{
			get
			{
				return _gadgetSlots;
			}
		}

		public int CrewQuarters
		{
			get
			{
				return _crewQuarters;
			}
		}

		public virtual int FuelTanks
		{
			get
			{
				return _fuelTanks;
			}
		}

		public int FuelCost
		{
			get
			{
				return _fuelCost;
			}
		}

		public int HullStrength
		{
			get
			{
				return _hullStrength + (HullUpgraded ? Consts.HullUpgrade : 0);
			}
		}

		public int RepairCost
		{
			get
			{
				return _repairCost;
			}
		}

		public int Price
		{
			get
			{
				return _price;
			}
		}

		public int Occurance
		{
			get
			{
				return _occurance;
			}
		}

		public int Police
		{
			get
			{
				return _police;
			}
		}

		public int Pirates
		{
			get
			{
				return _pirates;
			}
		}

		public int Traders
		{
			get
			{
				return _traders;
			}
		}

		public TechLevel MinimumTechLevel
		{
			get
			{
				return _minTech;
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

		#endregion
	}
}
