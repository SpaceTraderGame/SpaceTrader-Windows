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
	public class HighScoreRecord : STSerializableObject, IComparable
	{
		#region Member Declarations

		private string			_name;
		private int					_score;
		private GameEndType	_type;
		private int					_days;
		private int					_worth;
		private Difficulty	_difficulty;

		#endregion

		#region Methods

		public HighScoreRecord(string name, int score, GameEndType type, int days, int worth, Difficulty difficulty)
		{
			_name				= name;
			_score			= score;
			_type				= type;
			_days				= days;
			_worth			= worth;
			_difficulty	= difficulty;
		}

		public HighScoreRecord(Hashtable hash): base(hash)
		{
			_name				= (string)GetValueFromHash(hash, "_name");
			_score			= (int)GetValueFromHash(hash, "_score");
			_type				= (GameEndType)GetValueFromHash(hash, "_type");
			_days				= (int)GetValueFromHash(hash, "_days");
			_worth			= (int)GetValueFromHash(hash, "_worth");
			_difficulty	= (Difficulty)GetValueFromHash(hash, "_difficulty");
		}

		public int CompareTo(object value)
		{
			int							compared;
			HighScoreRecord	highScore	= (HighScoreRecord)value;

			if (value == null)
				compared	= 1;
			else if (highScore.Score < Score)
				compared	= 1;
			else if (highScore.Score > Score)
				compared	= -1;
			else if (highScore.Worth < Worth)
				compared	= 1;
			else if (highScore.Worth > Worth)
				compared	= -1;
			else if (highScore.Days < Days)
				compared	= 1;
			else if (highScore.Days > Days)
				compared	= -1;
			else
				compared	= 0;

			return compared;
		}

		public override Hashtable Serialize()
		{
			Hashtable	hash	= base.Serialize();

			hash.Add("_name",				_name);
			hash.Add("_score",			_score);
			hash.Add("_type",				(int)_type);
			hash.Add("_days",				_days);
			hash.Add("_worth",			_worth);
			hash.Add("_difficulty",	(int)_difficulty);

			return hash;
		}

		#endregion

		#region Operators

		public static bool operator > (HighScoreRecord a, HighScoreRecord b)
		{
			return a.CompareTo(b) > 0;
		}

		public static bool operator < (HighScoreRecord a, HighScoreRecord b)
		{
			return a.CompareTo(b) < 0;
		}

		#endregion

		#region Properties

		public int Days
		{
			get
			{
				return _days;
			}
		}

		public Difficulty Difficulty
		{
			get
			{
				return _difficulty;
			}
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public int Score
		{
			get
			{
				return _score;
			}
		}

		public GameEndType Type
		{
			get
			{
				return _type;
			}
		}

		public int Worth
		{
			get
			{
				return _worth;
			}
		}

		#endregion
	}
}
