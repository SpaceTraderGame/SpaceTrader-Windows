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

namespace Fryz.Apps.SpaceTrader
{
	public class Commander : CrewMember
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

		#endregion

		#region Methods

		public Commander(CrewMember baseCrewMember): base(baseCrewMember)
		{
			// Start off with a crew of only the commander and a Pulse Laser.
			Ship.Crew[0]	= this;
			Ship.AddEquipment(Consts.Weapons[(int)WeaponType.PulseLaser]);
		}

		public Commander(Hashtable hash): base(hash)
		{
			_cash																									= (int)hash["_cash"];
			_debt																									= (int)hash["_debt"];
			_killsPirate																					= (int)hash["_killsPirate"];
			_killsPolice																					= (int)hash["_killsPolice"];
			_killsTrader																					= (int)hash["_killsTrader"];
			_policeRecordScore																		= (int)hash["_policeRecordScore"];
			_reputationScore																			= (int)hash["_reputationScore"];
			_days																									= (int)hash["_days"];
			_insurance																						= (bool)hash["_insurance"];
			_noclaim																							= (int)hash["_noclaim"];
			_ship																									= new Ship((Hashtable)hash["_ship"]);
			_priceCargo																						= (int[])hash["_priceCargo"];
			Strings.CrewMemberNames[(int)CrewMemberId.Commander]	= (string)hash["_name"];
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

		public override Hashtable Serialize()
		{
			Hashtable	hash	= base.Serialize();

			hash.Add("_cash",								_cash);
			hash.Add("_debt",								_debt);
			hash.Add("_killsPirate",				_killsPirate);
			hash.Add("_killsPolice",				_killsPolice);
			hash.Add("_killsTrader",				_killsTrader);
			hash.Add("_policeRecordScore",	_policeRecordScore);
			hash.Add("_reputationScore",		_reputationScore);
			hash.Add("_days",								_days);
			hash.Add("_insurance",					_insurance);
			hash.Add("_noclaim",						_noclaim);
			hash.Add("_ship",								_ship.Serialize());
			hash.Add("_priceCargo",					_priceCargo);
			hash.Add("_name",								Name);

			return hash;
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

		public int[] PriceCargo
		{
			get
			{
				return _priceCargo;
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
