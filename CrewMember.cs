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
using System.Collections;

namespace Fryz.Apps.SpaceTrader
{
	[Serializable()]      
	public class CrewMember
	{
		#region Member Declarations

		private CrewMemberId	_id;
		private int[]					_skills			= new int[4];
		private StarSystem		_curSystem;

		#endregion

		#region Methods

		public CrewMember(CrewMemberId id, int pilot, int fighter, int trader, int engineer, StarSystem curSystem)
		{
			_id					= id;
			Pilot				= pilot;
			Fighter			= fighter;
			Trader			= trader;
			Engineer		= engineer;
			_curSystem	= curSystem;
		}

		public CrewMember(CrewMember baseCrewMember)
		{
			_id					= baseCrewMember.Id;
			Pilot				= baseCrewMember.Pilot;
			Fighter			= baseCrewMember.Fighter;
			Trader			= baseCrewMember.Trader;
			Engineer		= baseCrewMember.Engineer;
			_curSystem	= baseCrewMember.CurrentSystem;
		}

		private void ChangeRandomSkill(int amount)
		{
			ArrayList	skillIdList	= new ArrayList(4);
			for (int i = 0; i < Skills.Length; i++)
			{
				if (Skills[i] + amount > 0 && Skills[i] + amount < Consts.MaxSkill)
					skillIdList.Add(i);
			}

			if (skillIdList.Count > 0)
			{
				int	skill	= (int)skillIdList[Functions.GetRandom(skillIdList.Count)];

				int	curTrader	= Game.CurrentGame.Commander.Ship.Trader;
				Skills[skill]	+= amount;
				if (Game.CurrentGame.Commander.Ship.Trader != curTrader)
					Game.CurrentGame.RecalculateBuyPrices(Game.CurrentGame.Commander.CurrentSystem);
			}
		}

		// *************************************************************************
		// Increase one of the skills.
		// *************************************************************************
		public void IncreaseRandomSkill()
		{
			ChangeRandomSkill(1);
		}

		// *************************************************************************
		// NthLowest Skill. Returns skill with the nth lowest score
		// (i.e., 2 is the second worst skill). If there is a tie, it will return
		// in the order of Pilot, Fighter, Trader, Engineer.
		// JAF - rewrote this to be more efficient.
		// *************************************************************************
		public int NthLowestSkill(int n)
		{
			int[]	skillIds	= new int[] { 0, 1, 2, 3 };

			for (int j = 0; j < 3; j++)
			{
				for (int i = 0; i < 3 - j; i++)
				{
					if (Skills[skillIds[i]] > Skills[skillIds[i + 1]])
					{
						int	temp				= skillIds[i];
						skillIds[i]			= skillIds[i + 1];
						skillIds[i + 1]	= temp;
					}
				}
			}

			return skillIds[n - 1];
		}

		// *************************************************************************
		// Randomly tweak the skills.
		// *************************************************************************
		public void TonicTweakRandomSkill()
		{
			int[]	oldSkills	= (int[])Skills.Clone();
	
			if (Game.CurrentGame.Difficulty < Difficulty.Hard)
			{
				// add one to a random skill, subtract one from a random skill
				while (Skills[Consts.PilotSkill] == oldSkills[Consts.PilotSkill] &&
					Skills[Consts.FighterSkill] == oldSkills[Consts.FighterSkill] &&
					Skills[Consts.TraderSkill] == oldSkills[Consts.TraderSkill] &&
					Skills[Consts.EngineerSkill] == oldSkills[Consts.EngineerSkill])
				{
					ChangeRandomSkill(1);
					ChangeRandomSkill(-1);
				}
			}
			else
			{
				// add one to two random skills, subtract three from one random skill
				ChangeRandomSkill(1);
				ChangeRandomSkill(1);
				ChangeRandomSkill(-3);
			}
		}

		#endregion

		#region Properties

		public virtual string Name
		{
			get
			{
				return Strings.CrewMemberNames[(int)_id];
			}
		}

		public CrewMemberId	Id
		{
			get
			{
				return _id;
			}
		}

		public int[] Skills
		{
			get
			{
				return _skills;
			}
		}

		public int Pilot
		{
			get
			{
				return _skills[Consts.PilotSkill];
			}
			set
			{
				_skills[Consts.PilotSkill]	= value;
			}
		}

		public int Fighter
		{
			get
			{
				return _skills[Consts.FighterSkill];
			}
			set
			{
				_skills[Consts.FighterSkill]	= value;
			}
		}

		public int Trader
		{
			get
			{
				return _skills[Consts.TraderSkill];
			}
			set
			{
				_skills[Consts.TraderSkill]	= value;
			}
		}

		public int Engineer
		{
			get
			{
				return _skills[Consts.EngineerSkill];
			}
			set
			{
				_skills[Consts.EngineerSkill]	= value;
			}
		}

		public StarSystem CurrentSystem
		{
			get
			{
				return _curSystem;
			}
			set
			{
				_curSystem	= value;
			}
		}

		public int Rate
		{
			get
			{
				return _id > CrewMemberId.Commander && _id < CrewMemberId.Zeethibal ?
					(Pilot + Fighter + Trader + Engineer) * 3 : 0;
			}
		}

		#endregion
	}
}
