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
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using Microsoft.Win32;

[assembly: RegistryPermissionAttribute(SecurityAction.RequestMinimum, ViewAndModify = "HKEY_CURRENT_USER")]

namespace Fryz.Apps.SpaceTrader
{
	public class Functions
	{
		#region Static Variable/Constant Declarations

		private static	Random	rand			= new Random();

		private const		long		DEFSEEDX	= 521288629;
		private const		long		DEFSEEDY	= 362436069;
		private const		int			MAX_WORD	= 65535;

		private static	long		SeedX			= DEFSEEDX;
		private static	long		SeedY			= DEFSEEDY;

		#endregion

		#region Methods

		public static int AdjustSkillForDifficulty(int skill)
		{
			switch (Game.CurrentGame.Difficulty)
			{
				case Difficulty.Beginner:
				case Difficulty.Easy:
					skill++;
					break;
				case Difficulty.Hard:
				case Difficulty.Impossible:
					skill--;
					break;
				default:
					break;
			}

			return skill;
		}

		public static string[] ArrayListToStringArray(ArrayList list)
		{
			string[]	items		= new string[list.Count];

			for (int i = 0; i < items.Length; i++)
				items[i]	= (string)list[i];

			return items;
		}

		public static int Distance(StarSystem a, StarSystem b)
		{
			return (int)Math.Floor(Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2)));
		}

		public static int Distance(StarSystem a, int x, int y)
		{
			return (int)Math.Floor(Math.Sqrt(Math.Pow(a.X - x, 2) + Math.Pow(a.Y - y, 2)));
		}

		private static void DrawPartialImage(Graphics g, Image img, int start, int stop)
		{
			g.DrawImage(img, 2 + start, 2, new Rectangle(start, 0, stop - start, img.Height), GraphicsUnit.Pixel);
		}

		public static string FormatNumber(int num)
		{
			return String.Format("{0:n0}", num);
		}

		public static string FormatList(string[] listItems)
		{
			return StringVars(Strings.ListStrings[listItems.Length], listItems);
		}

		public static string FormatMoney(int num)
		{
			return String.Format("{0:n0} cr.", num);
		}

		public static string FormatPercent(int num)
		{
			return String.Format("{0:n0}%", num);
		}

		public static int GetColumnOfFirstNonWhitePixel(Image image, int direction)
		{
			Bitmap	bitmap	= new Bitmap(image);
			int			step		= direction < 0 ? -1 : 1;
			int			col			= step > 0 ? 0 : bitmap.Width - 1;
			int			stop		= step > 0 ? bitmap.Width : -1;

			for (; col != stop; col += step)
			{
				for (int row = 0; row < bitmap.Height; row++)
				{
					if (bitmap.GetPixel(col, row).ToArgb() != 0)
						return col;
				}
			}

			return -1;
		}

		public static HighScoreRecord[] GetHighScores(System.Windows.Forms.IWin32Window owner)
		{
			HighScoreRecord[]	highScores	= new HighScoreRecord[3];

			object						obj					= LoadFile(Consts.HighScoreFile, true, owner);
			if (obj != null)
				highScores	= (HighScoreRecord[])STSerializableObject.ArrayListToArray((ArrayList)obj, "HighScoreRecord");

			return highScores;
		}

		public static int GetRandom(int max)
		{
			return GetRandom(0, max);
		}

		public static int GetRandom(int min, int max)
		{
			return rand.Next(min, max);
		}

		// *************************************************************************
		// Pieter's new random functions, tweaked a bit by SjG
		// *************************************************************************
		public static int GetRandom2(int max)
		{
			return (int)(Rand() % max);
		}

		public static RegistryKey GetRegistryKey()
		{
			return Registry.CurrentUser.OpenSubKey("Software", true).CreateSubKey("FrenchFryz").CreateSubKey("SpaceTrader");
		}

		public static bool IsInt(string toParse)
		{
			bool	isInt	= true;

			try
			{
				int.Parse(toParse);
			}
			catch (Exception)
			{
				isInt	= false;
			}

			return isInt;
		}

		public static object LoadFile(string fileName, bool ignoreMissingFile, System.Windows.Forms.IWin32Window owner)
		{
			object					obj				= null;
			FileStream			inStream	= null;

			try
			{
				inStream	= new FileStream(fileName, FileMode.Open);
				obj				= (new BinaryFormatter()).Deserialize(inStream);
				inStream.Close();
				inStream	= null;
			}
			catch (FileNotFoundException ex)
			{
				if (!ignoreMissingFile)
					FormAlert.Alert(AlertType.FileErrorOpen, owner, fileName, ex.Message);
			}
			catch (IOException ex)
			{
				FormAlert.Alert(AlertType.FileErrorOpen, owner, fileName, ex.Message);
			}
			catch (System.Runtime.Serialization.SerializationException)
			{
				FormAlert.Alert(AlertType.FileErrorOpen, owner, fileName, Strings.FileFormatBad);
			}
			finally
			{
				if (inStream != null)
					inStream.Close();
			}

			return obj;
		}

		public static string Multiples(int num, string unit)
		{
			return FormatNumber(num) + " " + unit + (num == 1 ? "" : "s");
		}

		public static void PaintShipImage(Ship ship, Graphics g, Color backgroundColor)
		{
			int		x							= Consts.ShipImageOffsets[(int)ship.Type].X;
			int		width					= Consts.ShipImageOffsets[(int)ship.Type].Width;
			int		startDamage		= x + width - ship.Hull * width / ship.HullStrength;
			int		startShield		= x + width + 2 - (ship.ShieldStrength > 0 ? ship.ShieldCharge * (width + 4) /
				ship.ShieldStrength : 0);

			g.Clear(backgroundColor);

			if (startDamage > x)
			{
				if (startShield > x)
					DrawPartialImage(g, ship.ImageDamaged, x, Math.Min(startDamage, startShield));

				if (startShield < startDamage)
					DrawPartialImage(g, ship.ImageDamagedWithShields, startShield, startDamage);
			}

			if (startShield > startDamage)
				DrawPartialImage(g, ship.Image, startDamage, startShield);

			if (startShield < x + width + 2)
				DrawPartialImage(g, ship.ImageWithShields, startShield, x + width + 2);
		}

		private static long Rand()
		{
			const int a	= 18000;
			const int b	= 30903;

			SeedX	= a*(SeedX&MAX_WORD) + (SeedX>>16);
			SeedY	= b*(SeedY&MAX_WORD) + (SeedY>>16);

			return ((SeedX<<16) + (SeedY&MAX_WORD));
		}

		public static int RandomSkill()
		{
			return 1 + GetRandom(5) + GetRandom(6);
		}

		public static void RandSeed(int seed1, int seed2)
		{
			if (seed1 > 0)
				SeedX	= seed1;   /* use default seeds if parameter is 0 */
			else
				SeedX	= DEFSEEDX;

			if (seed2 > 0)
				SeedY	= seed2;
			else
				SeedY	= DEFSEEDY;
		}

		public static bool SaveFile(string fileName, object toSerialize, System.Windows.Forms.IWin32Window owner)
		{
			FileStream	outStream	= null;
			bool				saveOk		= false;

			try
			{
				outStream	= new FileStream(fileName, FileMode.Create);
				(new BinaryFormatter()).Serialize(outStream, toSerialize);

				outStream.Close();
				outStream	= null;

				saveOk		= true;
			}
			catch (IOException ex)
			{
				FormAlert.Alert(AlertType.FileErrorSave, owner, fileName, ex.Message);
			}
			finally
			{
				if (outStream != null)
					outStream.Close();
			}

			return saveOk;
		}

		public static string StringVars(string toParse, string[] vars)
		{
			string	parsed	= toParse;

			for (int i = 0; i < vars.Length; i++)
				parsed	= parsed.Replace("^" + (i + 1).ToString(), vars[i]);

			return parsed;
		}

		public static string StringVars(string toParse, string var1)
		{
			return StringVars(toParse, new string[] { var1 });
		}

		public static string StringVars(string toParse, string var1, string var2)
		{
			return StringVars(toParse, new string[] { var1, var2 });
		}

		// *************************************************************************
		// Returns true if there exists a wormhole from a to b.
		// If b < 0, then return true if there exists a wormhole
		// at all from a.
		// *************************************************************************
		public static bool WormholeExists(int a, int b)
		{
			int[] wormholes	= Game.CurrentGame.Wormholes;
			int		i					= Array.IndexOf(wormholes, a);

			return (i >= 0 && (b < 0 || wormholes[(i + 1) % wormholes.Length] == b));
		}

		public static bool WormholeExists(StarSystem a, StarSystem b)
		{
			StarSystem[]	universe	= Game.CurrentGame.Universe;
			int[]					wormholes	= Game.CurrentGame.Wormholes;
			int						i					= Array.IndexOf(wormholes, (int)a.Id);

			return (i >= 0 && (universe[wormholes[(i + 1) % wormholes.Length]] == b));
		}

		public static StarSystem WormholeTarget(int a)
		{
			int[] wormholes	= Game.CurrentGame.Wormholes;
			int		i					= Array.IndexOf(wormholes, a);

			return (i >= 0 ? (Game.CurrentGame.Universe[wormholes[(i + 1) % wormholes.Length]]) : null);
		}

		#endregion
	}
}
