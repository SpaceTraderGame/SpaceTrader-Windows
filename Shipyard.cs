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
	/// <summary>
	/// Represents a shipyard orbiting a solar system in the universe.
	/// In a shipyard, the player can design his own ship and have it constructed, for a fee.
	/// </summary>
	public class Shipyard
	{
		#region Constants

		public static int[]	COST_FUEL							= new int[] {    1,    1,     1,     3,     5,     10 };
		public static int[]	COST_HULL							= new int[] {    1,    5,    10,    15,    20,     40 };
		public static int[]	BASE_FUEL							= new int[] {   15,   14,    13,    12,    11,     10 };
		public static int[]	BASE_HULL							= new int[] {   10,   25,    50,   100,   150,    200 };
		public static int[]	DESIGN_FEE						= new int[] { 2000, 5000, 10000, 20000, 40000, 100000 };
		public static int[]	MAX_UNITS							= new int[] {   50,  100,   150,   200,   250,    999 };
		public static int[]	PER_UNIT_FUEL					= new int[] {    3,    2,     1,     1,     1,      1 };
		public static int[]	PER_UNIT_HULL					= new int[] {   35,   30,    25,    20,    15,     10 };
		public static int[]	PRICE_PER_UNIT				= new int[] {   75,  250,   500,   750,  1000,   1200 };
		public static int[]	UNITS_CREW						= new int[] {   20,   20,    20,    20,    20,     20 };
		public static int[]	UNITS_FUEL						= new int[] {    1,    1,     1,     5,    10,     15 };
		public static int[]	UNITS_GADGET					= new int[] {    5,    5,     5,     5,     5,      5 };
		public static int[]	UNITS_HULL						= new int[] {    1,    2,     3,     4,     5,      6 };
		public static int[]	UNITS_SHIELD					= new int[] {   10,   10,    10,     8,     8,      8 };
		public static int[]	UNITS_WEAPON					= new int[] {   15,   15,    15,    10,    10,     10 };

		// Fee and Price Per Unit 10% less for the specialty size, and 10% more for sizes more than 1 away
		// from the specialty size.
		public static int		ADJUST_SIZE_DEFAULT		= 100;
		public static int		ADJUST_SIZE_SPECIALTY	=  90;
		public static int		ADJUST_SIZE_WEAKNESS	= 110;

		// One of the costs will be adjusted based on the shipyard's skill.
		public static int		ADJUST_SKILL_CREW			=   2;
		public static int		ADJUST_SKILL_FUEL			=   2;
		public static int		ADJUST_SKILL_HULL			=   5;
		public static int		ADJUST_SKILL_SHIELD		=   2;
		public static int		ADJUST_SKILL_WEAPON		=   2;

		// There is a crowding penalty for coming too close to the maximum. A modest penalty is imposed at
		// one level, and a more severe penalty at a higher level.
		public static int		PENALTY_FIRST_PCT			=  80;
		public static int		PENALTY_FIRST_FEE			=  25;
		public static int		PENALTY_SECOND_PCT		=  90;
		public static int		PENALTY_SECOND_FEE		=  75;

		#endregion

		#region Member Variables

		private ShipyardId		_id;
		private Size					_specialtySize;
		private ShipyardSkill	_skill;

		// Internal Variables
		private int						modCrew					= 0;
		private int						modFuel					= 0;
		private int						modHull					= 0;
		private int						modShield				= 0;
		private int						modWeapon				= 0;

		#endregion

		#region Methods

		public Shipyard(ShipyardId id, Size specialtySize, ShipyardSkill skill)
		{
			_id							= id;
			_specialtySize	= specialtySize;
			_skill					= skill;

			switch (Skill)
			{
				case ShipyardSkill.CrewQuarters:
					modCrew		= ADJUST_SKILL_CREW;
					break;
				case ShipyardSkill.FuelBase:
					modFuel		= ADJUST_SKILL_FUEL;
					break;
				case ShipyardSkill.HullPerUnit:
					modHull		= ADJUST_SKILL_HULL;
					break;
				case ShipyardSkill.ShieldSlotUnits:
					modShield	= ADJUST_SKILL_SHIELD;
					break;
				case ShipyardSkill.WeaponSlotUnits:
					modWeapon	= ADJUST_SKILL_WEAPON;
					break;
			}
		}

		// Calculate the ship's price (worth here, not the price paid), the fuel cost, and the repair cost.
		public void CalculateDependantVariables()
		{
			ShipSpec.Price			= BasePrice + PenaltyCost;
			ShipSpec.FuelCost		= CostFuel;
			ShipSpec.RepairCost	= CostHull;
		}

		#endregion

		#region Properties

		public int AdjustedDesignFee
		{
			get
			{
				return DESIGN_FEE[(int)ShipSpec.Size] * CostAdjustment / ADJUST_SIZE_DEFAULT;
			}
		}

		public int AdjustedPenaltyCost
		{
			get
			{
				return PenaltyCost * CostAdjustment / ADJUST_SIZE_DEFAULT;
			}
		}

		public int AdjustedPrice
		{
			get
			{
				return BasePrice * CostAdjustment / ADJUST_SIZE_DEFAULT;
			}
		}

		public ArrayList AvailableSizes
		{
			get
			{
				ArrayList	list	= new ArrayList(6);

				int				begin	= Math.Max((int)Size.Tiny, (int)SpecialtySize - 2);
				int				end		= Math.Min((int)Size.Gargantuan, (int)SpecialtySize + 2);
				for (int index = begin; index <= end; index++)
					list.Add((Size)index);

				return list;
			}
		}

		public int BaseFuel
		{
			get
			{
				return BASE_FUEL[(int)ShipSpec.Size] + modFuel;
			}
		}

		public int BaseHull
		{
			get
			{
				return BASE_HULL[(int)ShipSpec.Size];
			}
		}

		public int BasePrice
		{
			get
			{
				return UnitsUsed * PricePerUnit;
			}
		}

		public int CostAdjustment
		{
			get
			{
				int	adjustment;

				switch (Math.Abs((int)SpecialtySize - (int)ShipSpec.Size))
				{
					case 0:
						adjustment	= ADJUST_SIZE_SPECIALTY;
						break;
					case 1:
						adjustment	= ADJUST_SIZE_DEFAULT;
						break;
					default:
						adjustment	= ADJUST_SIZE_WEAKNESS;
						break;
				}

				return adjustment;
			}
		}

		public int CostFuel
		{
			get
			{
				return COST_FUEL[(int)ShipSpec.Size];
			}
		}

		public int CostHull
		{
			get
			{
				return COST_HULL[(int)ShipSpec.Size];
			}
		}

		public string Engineer
		{
			get
			{
				return Strings.ShipyardEngineers[(int)Id];
			}
		}

		public ShipyardId Id
		{
			get
			{
				return _id;
			}
		}

		public int MaxUnits
		{
			get
			{
				return MAX_UNITS[(int)ShipSpec.Size];
			}
		}

		public string Name
		{
			get
			{
				return Strings.ShipyardNames[(int)Id];
			}
		}

		public int PenaltyCost
		{
			get
			{
				int	penalty	= 0;

				if (PercentOfMaxUnits >= PENALTY_SECOND_PCT)
					penalty	= PENALTY_SECOND_FEE;
				else if (PercentOfMaxUnits >= PENALTY_FIRST_PCT)
					penalty	= PENALTY_FIRST_FEE;

				return  BasePrice * penalty / 100;
			}
		}

		public int PercentOfMaxUnits
		{
			get
			{
				return UnitsUsed * 100 / MaxUnits;
			}
		}

		public int PerUnitFuel
		{
			get
			{
				return PER_UNIT_FUEL[(int)ShipSpec.Size];
			}
		}

		public int PerUnitHull
		{
			get
			{
				return PER_UNIT_HULL[(int)ShipSpec.Size] + modHull;
			}
		}

		public int PricePerUnit
		{
			get
			{
				return PRICE_PER_UNIT[(int)ShipSpec.Size];
			}
		}

		public ShipSpec	ShipSpec
		{
			get
			{
				return Consts.ShipSpecs[(int)ShipType.Custom];
			}
		}

		public ShipyardSkill Skill
		{
			get
			{
				return _skill;
			}
		}

		public Size SpecialtySize
		{
			get
			{
				return _specialtySize;
			}
		}

		public int TotalCost
		{
			get
			{
				return AdjustedPrice + AdjustedPenaltyCost + AdjustedDesignFee - TradeIn;
			}
		}

		public int TradeIn
		{
			get
			{
				return Game.CurrentGame.Commander.Ship.Worth(false);
			}
		}

		public int UnitsCrew
		{
			get
			{
				return UNITS_CREW[(int)ShipSpec.Size] - modCrew;
			}
		}

		public int UnitsFuel
		{
			get
			{
				return UNITS_FUEL[(int)ShipSpec.Size];
			}
		}

		public int UnitsGadgets
		{
			get
			{
				return UNITS_GADGET[(int)ShipSpec.Size];
			}
		}

		public int UnitsHull
		{
			get
			{
				return UNITS_HULL[(int)ShipSpec.Size];
			}
		}

		public int UnitsShields
		{
			get
			{
				return UNITS_SHIELD[(int)ShipSpec.Size] - modShield;
			}
		}

		public int UnitsWeapons
		{
			get
			{
				return UNITS_WEAPON[(int)ShipSpec.Size] - modWeapon;
			}
		}

		public int UnitsUsed
		{
			get
			{
				return ShipSpec.CargoBays +
					ShipSpec.CrewQuarters * UnitsCrew +
					(int)Math.Ceiling((double)(ShipSpec.FuelTanks - BaseFuel) / PerUnitFuel * UnitsFuel) +
					ShipSpec.GadgetSlots * UnitsGadgets +
					(ShipSpec.HullStrength - BaseHull) / PerUnitHull * UnitsHull +
					ShipSpec.ShieldSlots * UnitsShields +
					ShipSpec.WeaponSlots * UnitsWeapons;
			}
		}

		#endregion
	}
}
