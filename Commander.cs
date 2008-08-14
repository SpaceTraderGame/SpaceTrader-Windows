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
using System.Windows.Forms;

namespace Fryz.Apps.SpaceTrader
{
	public class Commander : CrewMember
	{
		#region Member Declarations

		private int		_cash								= 1000;
		private int		_debt								= 0;
		private int		_killsPirate				= 0;
		private int		_killsPolice				= 0;
		private int		_killsTrader				= 0;
		private int		_policeRecordScore	= 0;
		private int		_reputationScore		= 0;
		private int		_days								= 0;
		private bool	_insurance					= false;
		private int		_noclaim						= 0;
		private Ship	_ship								= new Ship(ShipType.Gnat);
		private int[]	_priceCargo					= new int[10];								// Total price paid for trade goods

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
			_cash								= (int)GetValueFromHash(hash, "_cash", _cash);
			_debt								= (int)GetValueFromHash(hash, "_debt", _debt);
			_killsPirate				= (int)GetValueFromHash(hash, "_killsPirate", _killsPirate);
			_killsPolice				= (int)GetValueFromHash(hash, "_killsPolice", _killsPolice);
			_killsTrader				= (int)GetValueFromHash(hash, "_killsTrader", _killsTrader);
			_policeRecordScore	= (int)GetValueFromHash(hash, "_policeRecordScore", _policeRecordScore);
			_reputationScore		= (int)GetValueFromHash(hash, "_reputationScore", _reputationScore);
			_days								= (int)GetValueFromHash(hash, "_days", _days);
			_insurance					= (bool)GetValueFromHash(hash, "_insurance", _insurance);
			_noclaim						= (int)GetValueFromHash(hash, "_noclaim", _noclaim);
			_ship								= new Ship((Hashtable)GetValueFromHash(hash, "_ship", _ship));
			_priceCargo					= (int[])GetValueFromHash(hash, "_priceCargo", _priceCargo);

			Game.CurrentGame.Mercenaries[(int)CrewMemberId.Commander]	= this;
			Strings.CrewMemberNames[(int)CrewMemberId.Commander]			= (string)GetValueFromHash(hash, "_name",
																																	Strings.CrewMemberNames[(int)CrewMemberId.Commander]);
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

		public bool TradeShip(ShipSpec specToBuy, int netPrice, IWin32Window owner)
		{
			return TradeShip(specToBuy, netPrice, specToBuy.Name, owner);
		}

		public bool TradeShip(ShipSpec specToBuy, int netPrice, string newShipName, IWin32Window owner)
		{
			bool	traded	= false;

			if (netPrice > 0 && Debt > 0)
				FormAlert.Alert(AlertType.DebtNoBuy, owner);
			else if (netPrice > CashToSpend)
				FormAlert.Alert(AlertType.ShipBuyIF, owner);
			else if (specToBuy.CrewQuarters < Ship.SpecialCrew.Length)
			{
				string	passengers	= Ship.SpecialCrew[1].Name;
				if (Ship.SpecialCrew.Length > 2)
					passengers	+= " and " + Ship.SpecialCrew[2].Name;

				FormAlert.Alert(AlertType.ShipBuyPassengerQuarters, owner, passengers);
			}
			else if (specToBuy.CrewQuarters < Ship.CrewCount)
				FormAlert.Alert(AlertType.ShipBuyCrewQuarters, owner);
			else if (Ship.ReactorOnBoard)
				FormAlert.Alert(AlertType.ShipBuyReactor, owner);
			else
			{
				Equipment[]	special	= new Equipment[]
				{
					Consts.Weapons[(int)WeaponType.MorgansLaser],
					Consts.Weapons[(int)WeaponType.QuantumDistruptor],
					Consts.Shields[(int)ShieldType.Lightning],
					Consts.Gadgets[(int)GadgetType.FuelCompactor],
					Consts.Gadgets[(int)GadgetType.HiddenCargoBays]
				};
				bool[]			add				= new bool[special.Length];
				bool				addPod		= false;
				int					extraCost	= 0;

				for (int i = 0; i < special.Length; i++)
				{
					if (Ship.HasEquipment(special[i]))
					{
						if (specToBuy.Slots(special[i].EquipmentType) == 0)
							FormAlert.Alert(AlertType.ShipBuyNoSlots, owner, newShipName, special[i].Name,
								Strings.EquipmentTypes[(int)special[i].EquipmentType]);
						else
						{
							extraCost	+= special[i].TransferPrice;
							add[i]		 = true;
						}
					}
				}

				if (Ship.EscapePod)
				{
					addPod		= true;
					extraCost	+= Consts.PodTransferCost;
				}

				if (netPrice + extraCost > CashToSpend)
					FormAlert.Alert(AlertType.ShipBuyIFTransfer, owner);

				extraCost = 0;

				for (int i = 0; i < special.Length; i++)
				{
					if (add[i])
					{
						if (netPrice + extraCost + special[i].TransferPrice > CashToSpend)
							FormAlert.Alert(AlertType.ShipBuyNoTransfer, owner, special[i].Name);
						else if (FormAlert.Alert(AlertType.ShipBuyTransfer, owner, special[i].Name, special[i].Name.ToLower(),
							Functions.FormatNumber(special[i].TransferPrice)) == DialogResult.Yes)
							extraCost	+= special[i].TransferPrice;
						else
							add[i]		 = false;
					}
				}

				if (addPod)
				{
					if (netPrice + extraCost + Consts.PodTransferCost > CashToSpend)
						FormAlert.Alert(AlertType.ShipBuyNoTransfer, owner, Strings.ShipInfoEscapePod);
					else if (FormAlert.Alert(AlertType.ShipBuyTransfer, owner, Strings.ShipInfoEscapePod,
						Strings.ShipInfoEscapePod.ToLower(), Functions.FormatNumber(Consts.PodTransferCost)) == DialogResult.Yes)
						extraCost	+= Consts.PodTransferCost;
					else
						addPod		= false;
				}

				if (FormAlert.Alert(AlertType.ShipBuyConfirm, owner, Ship.Name, newShipName,
					(add[0] || add[1] || add[2] || addPod ? Strings.ShipBuyTransfer : "")) == DialogResult.Yes)
				{
					CrewMember[]	oldCrew	 = Ship.Crew;

					Ship									 = new Ship(specToBuy.Type);
					Cash									-= (netPrice + extraCost);

					for (int i = 0; i < Math.Min(oldCrew.Length, Ship.Crew.Length); i++)
						Ship.Crew[i]	= oldCrew[i];

					for (int i = 0; i < special.Length; i++)
					{
						if (add[i])
							Ship.AddEquipment(special[i]);
					}

					if (addPod)
						Ship.EscapePod	= true;
					else if (Insurance)
					{
						Insurance				= false;
						NoClaim					= 0;
					}

					traded	= true;
				}
			}

			return traded;
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
				_noclaim   = Math.Max(0, Math.Min(Consts.MaxNoClaim, value));
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
