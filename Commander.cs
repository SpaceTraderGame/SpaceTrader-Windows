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
	public class Commander: CrewMember
	{
		#region Member Declarations

		private int					_cash								= 1000;
		private int					_debt								= 0;
		private int					_killsPirate				= 0;
		private int					_killsPolice				= 0;
		private int					_killsTrader				= 0;
		private int					_policeRecordScore	= 0;
		private int					_reputationScore		= 0;
		private int					_days								= 0;
		private bool				_insurance					= false;
		private int					_noclaim						= 0;
		private Ship				_ship								= new Ship(ShipType.Gnat);
		private int[]				_priceCargo					= new int[10];								// Total price paid for trade goods
		private string			_name								= Strings.CrewMemberNames[0];	// This is only here so that we can save it.

		#endregion

		#region Methods

		public Commander(string name, CrewMember baseCrewMember): base(baseCrewMember)
		{
			_name	= name;

			// Start off with a crew of only the commander and a Pulse Laser.
			Ship.Crew[0]	= this;
			Ship.AddEquipment(Consts.Weapons[(int)WeaponType.PulseLaser]);
		}

		public void PayInterest()
		{
			if (Debt > 0)
			{
				int	interest	= Math.Max(1, (int)(Debt * Consts.IntRate));
				if (Cash > interest)
					Cash -= interest;
				else 
				{
					Debt	+= (interest - Cash);
					Cash	= 0;
				}
			}
		}

		#endregion

		#region Properties

		public int Cash
		{
			get
			{
				return _cash;
			}
			set
			{
				_cash   = value;
			}
		}

		public int CashToSpend
		{
			get
			{
				return _cash - (Game.CurrentGame.Options.ReserveMoney ? Game.CurrentGame.CurrentCosts : 0);
			}
		}

		public int Debt
		{
			get
			{
				return _debt;
			}
			set
			{
				_debt   = value;
			}
		}

		public int KillsPirate
		{
			get
			{
				return _killsPirate;
			}
			set
			{
				_killsPirate   = value;
			}
		}

		public int KillsPolice
		{
			get
			{
				return _killsPolice;
			}
			set
			{
				_killsPolice   = value;
			}
		}

		public int KillsTrader
		{
			get
			{
				return _killsTrader;
			}
			set
			{
				_killsTrader   = value;
			}
		}

		public int PoliceRecordScore
		{
			get
			{
				return _policeRecordScore;
			}
			set
			{
				_policeRecordScore   = value;
			}
		}

		public int ReputationScore
		{
			get
			{
				return _reputationScore;
			}
			set
			{
				_reputationScore   = value;
			}
		}

		public int Days
		{
			get
			{
				return _days;
			}
			set
			{
				_days   = value;
			}
		}

		public bool Insurance
		{
			get
			{
				return _insurance;
			}
			set
			{
				_insurance   = value;
			}
		}

		public int NoClaim
		{
			get
			{
				return _noclaim;
			}
			set
			{
				_noclaim   = value;
			}
		}

		public Ship Ship
		{
			get
			{
				return _ship;
			}
			set
			{
				_ship   = value;
			}
		}

		public int[] PriceCargo
		{
			get
			{
				return _priceCargo;
			}
		}

		public override string Name
		{
			get
			{
				return _name;
			}
		}

		public int Worth
		{
			get
			{
				return Ship.Price + _cash - _debt + (Game.CurrentGame.QuestStatusMoon > 0 ? SpecialEvent.MoonCost : 0);
			}
		}

		#endregion
	}
}
