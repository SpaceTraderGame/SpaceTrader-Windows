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

namespace Fryz.Apps.SpaceTrader
{
	public class TradeItem: IComparable
	{
		#region Member Declarations

		private TradeItemType		_type;
		private TechLevel				_techProduction;		// Tech level needed for production
		private TechLevel				_techUsage;					// Tech level needed to use
		private TechLevel				_techTopProduction;	// Tech level which produces this item the most
		private int							_piceLowTech;				// Medium price at lowest tech level
		private int							_priceInc;					// Price increase per tech level
		private int							_priceVariance;			// Max percentage above or below calculated price
		private SystemPressure	_pressurePriceHike;	// Price increases considerably when this event occurs
		private SpecialResource _resourceLowPrice;	// When this resource is available, this trade item is cheap
		private SpecialResource _resourceHighPrice;	// When this resource is available, this trade item is expensive
		private int							_minTradePrice;			// Minimum price to buy/sell in orbit
		private int							_maxTradePrice;			// Minimum price to buy/sell in orbit
		private int							_roundOff;					// Roundoff price for trade in orbit

		#endregion

		#region Methods

		public TradeItem(TradeItemType type, TechLevel techProduction, TechLevel techUsage,
			TechLevel techTopProduction, int piceLowTech, int priceInc, int priceVariance,
			SystemPressure pressurePriceHike, SpecialResource resourceLowPrice, SpecialResource resourceHighPrice,
			int minTradePrice, int maxTradePrice, int roundOff)
		{
			_type								= type;
			_techProduction			= techProduction;
			_techUsage					= techUsage;
			_techTopProduction	= techTopProduction;
			_piceLowTech				= piceLowTech;
			_priceInc						= priceInc;
			_priceVariance			= priceVariance;
			_pressurePriceHike	= pressurePriceHike;
			_resourceLowPrice		= resourceLowPrice;
			_resourceHighPrice	= resourceHighPrice;
			_minTradePrice			= minTradePrice;
			_maxTradePrice			= maxTradePrice;
			_roundOff						= roundOff;
		}

		public int CompareTo(object value)
		{
			int	compared	= 0;

			if (value == null)
				compared	= 1;
			else
			{
				compared	= PriceLowTech.CompareTo(((TradeItem)value).PriceLowTech);
				if (compared == 0)
					compared	= -PriceInc.CompareTo(((TradeItem)value).PriceInc);
			}

			return compared;
		}

		public int StandardPrice(StarSystem target)
		{
			int	price	= 0;

			if (target.ItemUsed(this))
			{
				// Determine base price on techlevel of system
				price	= PriceLowTech + (int)target.TechLevel * PriceInc;

				// If a good is highly requested, increase the price
				if (target.PoliticalSystem.Wanted == Type)
					price	= price * 4 / 3;

				// High trader activity decreases prices
				price	= price * (100 - 2 * (int)target.PoliticalSystem.ActivityTraders) / 100;

				// Large system = high production decreases prices
				price	= price * (100 - (int)target.Size) / 100;

				// Special resources price adaptation
				if (target.SpecialResource == ResourceLowPrice)
					price	= price * 3 / 4;
				else if (target.SpecialResource == ResourceHighPrice)
					price	= price * 4 / 3;
			}

			return price;
		}

		#endregion

		#region Properties

		public bool Illegal
		{
			get
			{
				return Type == TradeItemType.Firearms || Type == TradeItemType.Narcotics;
			}
		}

		public int MaxTradePrice
		{
			get
			{
				return _maxTradePrice;
			}
		}

		public int MinTradePrice
		{
			get
			{
				return _minTradePrice;
			}
		}

		public string Name
		{
			get
			{
				return Strings.TradeItemNames[(int)_type];
			}
		}

		public SystemPressure PressurePriceHike
		{
			get
			{
				return _pressurePriceHike;
			}
		}

		public int PriceInc
		{
			get
			{
				return _priceInc;
			}
		}

		public int PriceLowTech
		{
			get
			{
				return _piceLowTech;
			}
		}

		public int PriceVariance
		{
			get
			{
				return _priceVariance;
			}
		}

		public SpecialResource ResourceHighPrice
		{
			get
			{
				return _resourceHighPrice;
			}
		}

		public SpecialResource ResourceLowPrice
		{
			get
			{
				return _resourceLowPrice;
			}
		}

		public int RoundOff
		{
			get
			{
				return _roundOff;
			}
		}

		public TechLevel TechProduction
		{
			get
			{
				return _techProduction;
			}
		}

		public TechLevel TechTopProduction
		{
			get
			{
				return _techTopProduction;
			}
		}

		public TechLevel TechUsage
		{
			get
			{
				return _techUsage;
			}
		}

		public TradeItemType Type
		{
			get
			{
				return _type;
			}
		}

		#endregion
	}
}
