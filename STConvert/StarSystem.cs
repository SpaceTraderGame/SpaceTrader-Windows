/*******************************************************************************
 *
 * Space Trader for Windows File Converter 2.00
 *
 * Copyright (C) 2005 Jay French, All Rights Reserved
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
using System.Collections;

namespace Fryz.Apps.SpaceTrader
{
	[Serializable()]
	public class StarSystem: STSerializableObject
	{
		#region Member Declarations

		private StarSystemId		_id								= StarSystemId.NA;
		private int							_x								= 0;
		private int							_y								= 0;
		private Size						_size							= Size.Tiny;
		private TechLevel				_techLevel				= TechLevel.HiTech;
		private PoliticalSystem	_politicalSystem	= null;
		private SystemPressure	_pressure					= SystemPressure.None;
		private SpecialResource	_specialResource	= SpecialResource.Nothing;
		private SpecialEvent		_specialEvent			= null;
		private int[]						_tradeItems				= null;
		private int							_countDown				= 0;
		private bool						_visited					= false;

		#endregion

		#region Methods

		public override Hashtable Serialize()
		{
			Hashtable	hash	= base.Serialize();

			hash.Add("_id",										(int)_id);
			hash.Add("_x",										_x);
			hash.Add("_y",										_y);
			hash.Add("_size",									(int)_size);
			hash.Add("_techLevel",						(int)_techLevel);
			hash.Add("_politicalSystemType",	(int)_politicalSystem.Type);
			hash.Add("_systemPressure",				(int)_pressure);
			hash.Add("_specialResource",			(int)_specialResource);
			hash.Add("_specialEventType",			(int)(_specialEvent == null ? SpecialEventType.NA : _specialEvent.Type));
			hash.Add("_tradeItems",						_tradeItems);
			hash.Add("_countDown",						_countDown);
			hash.Add("_visited",							_visited);
			hash.Add("_shipyardId",						(int)ShipyardId.NA);

			return hash;
		}

		#endregion

		#region Properties

		public StarSystemId Id
		{
			get
			{
				return _id;
			}
		}

		#endregion
	}
}
