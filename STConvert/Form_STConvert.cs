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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Fryz.Apps.SpaceTrader
{
	public class Form_STConvert: System.Windows.Forms.Form
	{
		#region Control Declarations

		private System.Windows.Forms.OpenFileDialog dlgFileOpen;
		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.TextBox txtOutput;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Constants

		public const string	FileFormatBad						= "-The file is not a serialized object file or has been corrupted.\r\n";
		public const string	LineBreak								= "\r\n";
		public const string	LoadFileBegin						= "****************************************\r\n+Opening File: ";
		public const string	LoadFileComplete				= "-File Opened\r\n";
		public const string	SaveFileBegin						= "+Saving File\r\n";
		public const string	SaveFileComplete				= "-File Saved\r\n";
		public const string	UnrecognizedFile				= "-The file was not recognized as a saved-game, high scores, or default settings file.\r\n";

		#endregion

		#region Methods

		public Form_STConvert()
		{
			InitializeComponent();
		}

		[STAThread]
		static void Main()
		{
			Application.Run(new Form_STConvert());
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form_STConvert));
			this.dlgFileOpen = new System.Windows.Forms.OpenFileDialog();
			this.btnConvert = new System.Windows.Forms.Button();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			//
			// dlgFileOpen
			//
			this.dlgFileOpen.Filter = "Saved-Game Files (*.sav)|*.sav|Settings/High Scores Files (*.bin)|*.bin|All files" +
				" (*.*)|*.*";
			this.dlgFileOpen.Multiselect = true;
			this.dlgFileOpen.Title = "Open File";
			//
			// btnConvert
			//
			this.btnConvert.Location = new System.Drawing.Point(4, 8);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(112, 24);
			this.btnConvert.TabIndex = 0;
			this.btnConvert.Text = "Convert File...";
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			//
			// txtOutput
			//
			this.txtOutput.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				| System.Windows.Forms.AnchorStyles.Left)
				| System.Windows.Forms.AnchorStyles.Right);
			this.txtOutput.AutoSize = false;
			this.txtOutput.BackColor = System.Drawing.Color.White;
			this.txtOutput.Location = new System.Drawing.Point(4, 40);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtOutput.Size = new System.Drawing.Size(584, 288);
			this.txtOutput.TabIndex = 2;
			this.txtOutput.Text = "";
			this.txtOutput.WordWrap = false;
			//
			// Form_STConvert
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 333);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.txtOutput,
																																	this.btnConvert});
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(400, 260);
			this.Name = "Form_STConvert";
			this.Text = "Space Trader for Windows File Converter 2.0";
			this.ResumeLayout(false);

		}
		#endregion

		private string ByteArrayToString(byte[] bytes, int index, int count)
		{
			string	str	= "";

			for (int i = index; i < index + count; i++)
				str	+= (char)bytes[i];

			return str;
		}

		private object LoadFile(string fileName)
		{
			object					obj				= null;
			FileStream			inStream	= null;
			MemoryStream		memStream	= null;
			BinaryFormatter	formatter	= new BinaryFormatter();

			try
			{
				Log(LoadFileBegin + fileName + LineBreak);

				// First read in the original file.
				inStream									= new FileStream(fileName, FileMode.Open);
				BinaryReader		reader		= new BinaryReader(inStream);
				byte[]					contents	= new byte[100000];
				int							length		= reader.Read(contents, 0, 100000);
				reader.Close();
				inStream.Close();

				// Create a memory stream from the updated byte array and deserialize it.
				memStream	= new MemoryStream(ReplaceStringInByteArray(contents, length, "ISpaceTrader", "GSTConvert"));
				obj				= formatter.Deserialize(memStream);

				Log(LoadFileComplete);
			}
			catch (IOException ex)
			{
				Log(ex.Message + LineBreak);
			}
			catch (System.Runtime.Serialization.SerializationException ex)
			{
				Log(FileFormatBad + ex.Message + LineBreak);
			}
			finally
			{
				if (inStream != null)
					inStream.Close();
				if (memStream != null)
					memStream.Close();
			}

			return obj;
		}

		private void Log(string text)
		{
			txtOutput.Text	+= text;
		}

		private byte[] ReplaceStringInByteArray(byte[] source, int length, string original, string replacement)
		{
			int			diff				= original.Length - replacement.Length;
			byte[]	dest				= new byte[length - diff];
			int			sourceIndex	= 0;
			int			destIndex		= 0;

			while (sourceIndex < length)
			{
				string	chunk	= ByteArrayToString(source, sourceIndex, original.Length);
				if (chunk == original)
				{
					for (int i = 0; i < replacement.Length; i++)
						dest[destIndex++]	= (byte)replacement[i];

					sourceIndex	+= original.Length;
				}
				else
					dest[destIndex++]	= source[sourceIndex++];
			}

			return dest;
		}

		private void SaveFile(string fileName, object toSerialize)
		{
			BinaryFormatter	formatter	= new BinaryFormatter();
			FileStream			outStream	= null;

			try
			{
				Log(SaveFileBegin);

				// Backup the old file.
				File.Move(fileName, fileName + ".bak");

				// Write out the converted file.
				outStream	= new FileStream(fileName, FileMode.Create);
				formatter.Serialize(outStream, toSerialize);
				outStream.Close();

				Log(SaveFileComplete);
			}
			catch (IOException ex)
			{
				Log(ex.Message + LineBreak);
			}
			finally
			{
				if (outStream != null)
					outStream.Close();
			}
		}

		#endregion

		#region Event Handlers

		private void btnConvert_Click(object sender, System.EventArgs e)
		{
			if (dlgFileOpen.ShowDialog(this) == DialogResult.OK)
			{
				foreach (string filename in dlgFileOpen.FileNames)
				{
					object	obj		= LoadFile(filename);

					if (obj != null)
					{
						if (typeof(STSerializableObject).IsInstanceOfType(obj) ||
							typeof(HighScoreRecord[]).IsInstanceOfType(obj))
						{
							if (typeof(STSerializableObject).IsInstanceOfType(obj))
								obj	= ((STSerializableObject)obj).Serialize();
							else
								obj	= STSerializableObject.ArrayToArrayList((HighScoreRecord[])obj);

							SaveFile(filename, obj);
						}
						else
							Log(UnrecognizedFile);
					}
				}
			}
		}

		#endregion
	}
}
