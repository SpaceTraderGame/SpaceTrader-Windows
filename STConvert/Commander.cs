/*******************************************************************************
 *
 * Space Trader for Windows File Converter 2.0.0
 *
 * Copyright (C) 2004 Jay French, All Rights Reserved
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
 ******************************************************************************/
using System;

namespace Fryz.Apps.SpaceTrader
{
	[Serializable()]      
	public class Commander: CrewMember
	{
		#region Member Declarations

		private int					_cash;
		private int					_debt;
		private int					_killsPirate;
		private int					_killsPolice;
		private int					_killsTrader;
		private int					_policeRecordScore;
		private int					_reputationScore;
		private int					_days;
		private bool				_insurance;
		private int					_noclaim;
		private Ship				_ship;
		private int[]				_priceCargo;
		private string			_name;

		#endregion

		#region Properties

		public int Cash
		{
			get
			{
				return _cash;
			}
		}

		public int Debt
		{
			get
			{
				return _debt;
			}
		}

		public int KillsPirate
		{
			get
			{
				return _killsPirate;
			}
		}

		public int KillsPolice
		{
			get
			{
				return _killsPolice;
			}
		}

		public int KillsTrader
		{
			get
			{
				return _killsTrader;
			}
		}

		public int PoliceRecordScore
		{
			get
			{
				return _policeRecordScore;
			}
		}

		public int ReputationScore
		{
			get
			{
				return _reputationScore;
			}
		}

		public int Days
		{
			get
			{
				return _days;
			}
		}

		public bool Insurance
		{
			get
			{
				return _insurance;
			}
		}

		public int NoClaim
		{
			get
			{
				return _noclaim;
			}
		}

		public Ship Ship
		{
			get
			{
				return _ship;
			}
		}

		public int[] PriceCargo
		{
			get
			{
				return _priceCargo;
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}

		#endregion
	}
}
