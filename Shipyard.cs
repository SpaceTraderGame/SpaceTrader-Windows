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
using System.Drawing;
using System.Windows.Forms;

namespace Fryz.Apps.SpaceTrader
{
	/// <summary>
	/// Represents a shipyard orbiting a solar system in the universe.
	/// In a shipyard, the player can design his own ship and have it constructed, for a fee.
	/// </summary>
	public class Shipyard
	{
		private string	_corporationName;
		private string	_architectName;
		private string	_welcomeMessage;
		private string	_thankYouMessage;
		private Bitmap	_logo							= null;

		public Shipyard(string corporationName, string architectName, string welcomeMessage, string thankYouMessage)
		{
			_corporationName	= corporationName;
			_architectName		= architectName;
			_welcomeMessage		= welcomeMessage;
			_thankYouMessage	= thankYouMessage;
		}

		public int computeSpaceUsed(int weapons, int gadgets, int shields, int fuel, int crew, int armorType)
		{
			int spaceUsed = 
				weapons * Consts.SpaceTakenByWeapon
				+ gadgets * Consts.SpaceTakenByGadget
				+ shields * Consts.SpaceTakenByShield
				+ fuel	  * Consts.SpaceTakenByFuel
				+ crew		* Consts.SpaceTakenByCrew
			  + armorType * Consts.SpaceTakenByArmor;

			return spaceUsed;
		}

		public int computeDesignPrice(int hullSize)
		{
			float result = 0;
			for (int i=0; i< hullSize; i++) 
			{
				result += Consts.Design_BasePrice;
				result *= Consts.Design_PriceMultiplier;
			}
			return (int)Math.Floor(result);
		}

		public int computeShipPrice(int hullSize)
		{
			float result = 0;
				result = hullSize * Consts.Buy_BasePrice;
			return (int)Math.Floor(result);
		}

		public int computeRange(int hullSize, int fuelCells)
		{
			return (int)Math.Floor(fuelCells / (hullSize * Consts.FuelCostBySize));
		}

		public int computeHullStrength(int hullSize, int armor)
		{
			return hullSize * (armor+1);
		}

		public int computeRepairCost(int hullSize)
		{
			return (int)Math.Floor(hullSize * Consts.RepairCostBySize);
		}

		public int computeFuelCost(int hullSize)
		{
			return (int)Math.Floor(hullSize * Consts.FuelCostBySize);
		}

		#region Properties

		public string ThankYouMessage 
		{
			get 
			{
				return _corporationName + " thanks you for your trust !";
			}
		}

		public string WelcomeMessage 
		{
			get 
			{
				return "Welcome to " + _corporationName + " shipyards ! Our best architect, " + _architectName + " is at your service.";
			}
		}

		public string Corporation
		{
			get 
			{
				return _corporationName;
			}
		}

		public Bitmap Logo
		{
			get
			{
				return _logo;
			}
			set
			{
				_logo = value;
			}
		}

		#endregion
	}
}
