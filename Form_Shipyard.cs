using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Fryz.Apps.SpaceTrader
{
	/// <summary>
	/// Summary description for Form_Shipyard.
	/// </summary>
	public class Form_Shipyard : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblWelcome;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox picShip;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblExplanation2;
		private System.Windows.Forms.Label lblExplanation;
		private System.Windows.Forms.Label lblHullStrength;
		private System.Windows.Forms.Label lblJumpRange;
		private System.Windows.Forms.Button btnSetPicture;
		private System.Windows.Forms.NumericUpDown numHullSpace;
		private System.Windows.Forms.Label lblShipPrice;
		private System.Windows.Forms.Label lblTotalPrice;
		private System.Windows.Forms.Label lblDesignFee;
		private System.Windows.Forms.Button btnBuild;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.NumericUpDown	numCargo;
		private System.Windows.Forms.NumericUpDown numCrew;
		private System.Windows.Forms.NumericUpDown numFuel;
		private System.Windows.Forms.NumericUpDown numShields;
		private System.Windows.Forms.NumericUpDown numGadgets;
		private System.Windows.Forms.NumericUpDown numWeapons;
		private System.Windows.Forms.NumericUpDown numArmor;
		private System.Windows.Forms.PictureBox picLogo;

		#region Member variables

		private Form			_parent				= null;
		private	Shipyard	_shipyard			= null;
		private bool			_initializing	= false;
		private int				_hullSize			= 50;
		private int				_weapons			= 0;
		private int				_gadgets			= 0;
		private int				_shields			= 0;
		private int				_fuel					= 5;
		private int				_crew					= 0;
		private int				_armor				= 0;
		
		#endregion

		#region Constructor/Destructor

		public Form_Shipyard(Shipyard shipyard, Form parentForm)
		{
			_initializing = true;

			_shipyard = shipyard;
			_parent		= parentForm;

			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			this.Text = "Ship design at " + _shipyard.Corporation;
			this.lblWelcome.Text = _shipyard.WelcomeMessage;
			if (_shipyard.Logo != null) picLogo.Image = _shipyard.Logo;
			Ship currentShip = Game.CurrentGame.Commander.Ship;
			if (currentShip != null) 
			{
				txtName.Text				= currentShip.Name;
				numHullSpace.Value	= 100;//currentShip.HullSize;
				numWeapons.Value		= currentShip.WeaponSlots;
				numShields.Value		= currentShip.ShieldSlots;
				numGadgets.Value		= currentShip.GadgetSlots;
				numCrew.Value				= currentShip.CrewQuarters;
				numFuel.Value				= currentShip.FuelTanks * currentShip.FuelCost;
			}
			checkValidity(false);
			_initializing = false;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
				components.Dispose();
			base.Dispose(disposing);
		}

		#endregion

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form_Shipyard));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblExplanation2 = new System.Windows.Forms.Label();
			this.lblExplanation = new System.Windows.Forms.Label();
			this.lblWelcome = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.lblHullStrength = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.lblJumpRange = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.btnSetPicture = new System.Windows.Forms.Button();
			this.picShip = new System.Windows.Forms.PictureBox();
			this.label3 = new System.Windows.Forms.Label();
			this.numHullSpace = new System.Windows.Forms.NumericUpDown();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.lblShipPrice = new System.Windows.Forms.Label();
			this.lblTotalPrice = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.lblDesignFee = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnBuild = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.numArmor = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numCargo = new System.Windows.Forms.NumericUpDown();
			this.numCrew = new System.Windows.Forms.NumericUpDown();
			this.numFuel = new System.Windows.Forms.NumericUpDown();
			this.numShields = new System.Windows.Forms.NumericUpDown();
			this.numGadgets = new System.Windows.Forms.NumericUpDown();
			this.numWeapons = new System.Windows.Forms.NumericUpDown();
			this.label19 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.picLogo = new System.Windows.Forms.PictureBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numHullSpace)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numArmor)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCargo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCrew)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numFuel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numShields)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numGadgets)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numWeapons)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																																						this.lblExplanation2,
																																						this.lblExplanation,
																																						this.lblWelcome});
			this.groupBox1.Location = new System.Drawing.Point(8, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(450, 96);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			// 
			// lblExplanation2
			// 
			this.lblExplanation2.Location = new System.Drawing.Point(8, 56);
			this.lblExplanation2.Name = "lblExplanation2";
			this.lblExplanation2.Size = new System.Drawing.Size(440, 32);
			this.lblExplanation2.TabIndex = 5;
			this.lblExplanation2.Text = "Bear in mind that the cost of the design is exponentially proportional to the siz" +
				"e of the ship, and that you\'ll have to pay BOTH the design fee and the ship cons" +
				"truction price.";
			// 
			// lblExplanation
			// 
			this.lblExplanation.Location = new System.Drawing.Point(8, 24);
			this.lblExplanation.Name = "lblExplanation";
			this.lblExplanation.Size = new System.Drawing.Size(440, 32);
			this.lblExplanation.TabIndex = 4;
			this.lblExplanation.Text = "Please use the form below to design your very own ship, and press the Construct b" +
				"utton when you\'re ready. Press the Cancel button to ... well ... cancel !";
			// 
			// lblWelcome
			// 
			this.lblWelcome.Location = new System.Drawing.Point(8, 8);
			this.lblWelcome.Name = "lblWelcome";
			this.lblWelcome.Size = new System.Drawing.Size(440, 16);
			this.lblWelcome.TabIndex = 3;
			this.lblWelcome.Text = "Welcome to SoroSuub shipyards ! Our best architect, Luke S., is at your service.";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.AddRange(new System.Windows.Forms.Control[] {
																																						this.lblHullStrength,
																																						this.label13,
																																						this.lblJumpRange,
																																						this.label11,
																																						this.btnSetPicture,
																																						this.picShip,
																																						this.label3,
																																						this.numHullSpace,
																																						this.txtName,
																																						this.lblName});
			this.groupBox2.Location = new System.Drawing.Point(8, 104);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(256, 128);
			this.groupBox2.TabIndex = 6;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Hull";
			// 
			// lblHullStrength
			// 
			this.lblHullStrength.Location = new System.Drawing.Point(88, 96);
			this.lblHullStrength.Name = "lblHullStrength";
			this.lblHullStrength.Size = new System.Drawing.Size(80, 16);
			this.lblHullStrength.TabIndex = 19;
			this.lblHullStrength.Text = "1500 kpt";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 96);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(80, 16);
			this.label13.TabIndex = 18;
			this.label13.Text = "Hull strength :";
			// 
			// lblJumpRange
			// 
			this.lblJumpRange.Location = new System.Drawing.Point(88, 72);
			this.lblJumpRange.Name = "lblJumpRange";
			this.lblJumpRange.Size = new System.Drawing.Size(80, 16);
			this.lblJumpRange.TabIndex = 17;
			this.lblJumpRange.Text = "17 parsecs";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 72);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(72, 16);
			this.label11.TabIndex = 16;
			this.label11.Text = "Jump range :";
			// 
			// btnSetPicture
			// 
			this.btnSetPicture.Location = new System.Drawing.Point(178, 100);
			this.btnSetPicture.Name = "btnSetPicture";
			this.btnSetPicture.Size = new System.Drawing.Size(70, 23);
			this.btnSetPicture.TabIndex = 15;
			this.btnSetPicture.Text = "Set picture";
			this.btnSetPicture.Click += new System.EventHandler(this.btnSetPicture_Click);
			// 
			// picShip
			// 
			this.picShip.BackColor = System.Drawing.Color.White;
			this.picShip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picShip.Location = new System.Drawing.Point(178, 40);
			this.picShip.Name = "picShip";
			this.picShip.Size = new System.Drawing.Size(70, 58);
			this.picShip.TabIndex = 14;
			this.picShip.TabStop = false;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 44);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 16);
			this.label3.TabIndex = 8;
			this.label3.Text = "Hull space :";
			// 
			// numHullSpace
			// 
			this.numHullSpace.Location = new System.Drawing.Point(88, 44);
			this.numHullSpace.Maximum = new System.Decimal(new int[] {
																																 100000,
																																 0,
																																 0,
																																 0});
			this.numHullSpace.Minimum = new System.Decimal(new int[] {
																																 1,
																																 0,
																																 0,
																																 0});
			this.numHullSpace.Name = "numHullSpace";
			this.numHullSpace.Size = new System.Drawing.Size(80, 20);
			this.numHullSpace.TabIndex = 7;
			this.numHullSpace.Value = new System.Decimal(new int[] {
																															 10,
																															 0,
																															 0,
																															 0});
			this.numHullSpace.ValueChanged += new System.EventHandler(this.controlChanged);
			this.numHullSpace.Leave += new System.EventHandler(this.controlChanged);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(88, 16);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(160, 20);
			this.txtName.TabIndex = 6;
			this.txtName.Text = "Conqueror";
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(8, 16);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(80, 23);
			this.lblName.TabIndex = 5;
			this.lblName.Text = "Ship name :";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.AddRange(new System.Windows.Forms.Control[] {
																																						this.lblShipPrice,
																																						this.lblTotalPrice,
																																						this.label8,
																																						this.label6,
																																						this.lblDesignFee,
																																						this.label4});
			this.groupBox3.Location = new System.Drawing.Point(8, 232);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(184, 72);
			this.groupBox3.TabIndex = 14;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Prices";
			// 
			// lblShipPrice
			// 
			this.lblShipPrice.Location = new System.Drawing.Point(96, 32);
			this.lblShipPrice.Name = "lblShipPrice";
			this.lblShipPrice.Size = new System.Drawing.Size(80, 16);
			this.lblShipPrice.TabIndex = 19;
			this.lblShipPrice.Text = "888,888,888 cr";
			// 
			// lblTotalPrice
			// 
			this.lblTotalPrice.Location = new System.Drawing.Point(96, 48);
			this.lblTotalPrice.Name = "lblTotalPrice";
			this.lblTotalPrice.Size = new System.Drawing.Size(80, 16);
			this.lblTotalPrice.TabIndex = 18;
			this.lblTotalPrice.Text = "888,888,888 cr";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 48);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(88, 16);
			this.label8.TabIndex = 17;
			this.label8.Text = "Total ship price :";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 32);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(64, 16);
			this.label6.TabIndex = 16;
			this.label6.Text = "Ship price :";
			// 
			// lblDesignFee
			// 
			this.lblDesignFee.Location = new System.Drawing.Point(96, 16);
			this.lblDesignFee.Name = "lblDesignFee";
			this.lblDesignFee.Size = new System.Drawing.Size(80, 16);
			this.lblDesignFee.TabIndex = 15;
			this.lblDesignFee.Text = "888,888,888 cr";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 14;
			this.label4.Text = "Design fee :";
			// 
			// btnBuild
			// 
			this.btnBuild.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnBuild.Location = new System.Drawing.Point(368, 280);
			this.btnBuild.Name = "btnBuild";
			this.btnBuild.Size = new System.Drawing.Size(88, 23);
			this.btnBuild.TabIndex = 21;
			this.btnBuild.Text = "Construct ship";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(272, 280);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(88, 23);
			this.btnCancel.TabIndex = 20;
			this.btnCancel.Text = "Cancel design";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.AddRange(new System.Windows.Forms.Control[] {
																																						this.numArmor,
																																						this.label1,
																																						this.numCargo,
																																						this.numCrew,
																																						this.numFuel,
																																						this.numShields,
																																						this.numGadgets,
																																						this.numWeapons,
																																						this.label19,
																																						this.label18,
																																						this.label17,
																																						this.label16,
																																						this.label15,
																																						this.label10});
			this.groupBox4.Location = new System.Drawing.Point(272, 104);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(186, 168);
			this.groupBox4.TabIndex = 15;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Space allocation :";
			// 
			// numArmor
			// 
			this.numArmor.Location = new System.Drawing.Point(112, 24);
			this.numArmor.Maximum = new System.Decimal(new int[] {
																														 10,
																														 0,
																														 0,
																														 0});
			this.numArmor.Name = "numArmor";
			this.numArmor.ReadOnly = true;
			this.numArmor.Size = new System.Drawing.Size(64, 20);
			this.numArmor.TabIndex = 14;
			this.numArmor.ValueChanged += new System.EventHandler(this.controlChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 16);
			this.label1.TabIndex = 13;
			this.label1.Text = "Armor thickness :";
			// 
			// numCargo
			// 
			this.numCargo.Enabled = false;
			this.numCargo.Location = new System.Drawing.Point(112, 144);
			this.numCargo.Maximum = new System.Decimal(new int[] {
																														 100000,
																														 0,
																														 0,
																														 0});
			this.numCargo.Name = "numCargo";
			this.numCargo.ReadOnly = true;
			this.numCargo.Size = new System.Drawing.Size(64, 20);
			this.numCargo.TabIndex = 11;
			// 
			// numCrew
			// 
			this.numCrew.Location = new System.Drawing.Point(112, 124);
			this.numCrew.Maximum = new System.Decimal(new int[] {
																														100000,
																														0,
																														0,
																														0});
			this.numCrew.Name = "numCrew";
			this.numCrew.ReadOnly = true;
			this.numCrew.Size = new System.Drawing.Size(64, 20);
			this.numCrew.TabIndex = 10;
			this.numCrew.ValueChanged += new System.EventHandler(this.controlChanged);
			// 
			// numFuel
			// 
			this.numFuel.Location = new System.Drawing.Point(112, 104);
			this.numFuel.Maximum = new System.Decimal(new int[] {
																														100000,
																														0,
																														0,
																														0});
			this.numFuel.Name = "numFuel";
			this.numFuel.ReadOnly = true;
			this.numFuel.Size = new System.Drawing.Size(64, 20);
			this.numFuel.TabIndex = 9;
			this.numFuel.ValueChanged += new System.EventHandler(this.controlChanged);
			// 
			// numShields
			// 
			this.numShields.Location = new System.Drawing.Point(112, 84);
			this.numShields.Maximum = new System.Decimal(new int[] {
																															 1000001,
																															 0,
																															 0,
																															 0});
			this.numShields.Name = "numShields";
			this.numShields.ReadOnly = true;
			this.numShields.Size = new System.Drawing.Size(64, 20);
			this.numShields.TabIndex = 8;
			this.numShields.ValueChanged += new System.EventHandler(this.controlChanged);
			// 
			// numGadgets
			// 
			this.numGadgets.Location = new System.Drawing.Point(112, 64);
			this.numGadgets.Maximum = new System.Decimal(new int[] {
																															 100000,
																															 0,
																															 0,
																															 0});
			this.numGadgets.Name = "numGadgets";
			this.numGadgets.ReadOnly = true;
			this.numGadgets.Size = new System.Drawing.Size(64, 20);
			this.numGadgets.TabIndex = 7;
			this.numGadgets.ValueChanged += new System.EventHandler(this.controlChanged);
			// 
			// numWeapons
			// 
			this.numWeapons.Location = new System.Drawing.Point(112, 44);
			this.numWeapons.Maximum = new System.Decimal(new int[] {
																															 100000,
																															 0,
																															 0,
																															 0});
			this.numWeapons.Name = "numWeapons";
			this.numWeapons.ReadOnly = true;
			this.numWeapons.Size = new System.Drawing.Size(64, 20);
			this.numWeapons.TabIndex = 6;
			this.numWeapons.ValueChanged += new System.EventHandler(this.controlChanged);
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(16, 144);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(80, 16);
			this.label19.TabIndex = 5;
			this.label19.Text = "Cargo space :";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(16, 104);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(64, 16);
			this.label18.TabIndex = 4;
			this.label18.Text = "Fuel cells :";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(16, 124);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(88, 16);
			this.label17.TabIndex = 3;
			this.label17.Text = "Crew quarters :";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(16, 84);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(48, 16);
			this.label16.TabIndex = 2;
			this.label16.Text = "Shields :";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(16, 64);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(56, 16);
			this.label15.TabIndex = 1;
			this.label15.Text = "Gadgets :";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(16, 44);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 16);
			this.label10.TabIndex = 0;
			this.label10.Text = "Weapons :";
			// 
			// picLogo
			// 
			this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picLogo.Image = ((System.Drawing.Bitmap)(resources.GetObject("picLogo.Image")));
			this.picLogo.Location = new System.Drawing.Point(196, 236);
			this.picLogo.Name = "picLogo";
			this.picLogo.Size = new System.Drawing.Size(64, 64);
			this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picLogo.TabIndex = 22;
			this.picLogo.TabStop = false;
			// 
			// Form_Shipyard
			// 
			this.AcceptButton = this.btnBuild;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(464, 310);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.groupBox4,
																																	this.groupBox3,
																																	this.groupBox2,
																																	this.groupBox1,
																																	this.btnCancel,
																																	this.btnBuild,
																																	this.picLogo});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "Form_Shipyard";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Ship design at XXXX shipyards";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numHullSpace)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numArmor)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCargo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCrew)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numFuel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numShields)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numGadgets)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numWeapons)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region Methods
		private void checkValidity(bool force) 
		{
			int hullSize= (int)numHullSpace.Value;
			int weapons = (int)numWeapons.Value;
			int gadgets = (int)numGadgets.Value;
			int shields = (int)numShields.Value;
			int fuel		= (int)numFuel.Value;
			int crew		= (int)numCrew.Value;
			int armor		= (int)numArmor.Value;
			
			int spaceFree = hullSize - _shipyard.computeSpaceUsed(weapons, gadgets, shields, fuel, crew, armor);
			if (!force && (spaceFree < 0))
			{
				numHullSpace.Value	= _hullSize;
				numWeapons.Value		= _weapons;
				numGadgets.Value		= _gadgets;
				numShields.Value		= _shields;
				numFuel.Value				= _fuel;
				numCrew.Value				= _crew;
				numArmor.Value			= _armor;
				checkValidity(true);
			} else 
			{
				numCargo.Value = spaceFree;
				lblDesignFee.Text = Functions.FormatMoney(_shipyard.computeDesignPrice(hullSize));
				lblShipPrice.Text = Functions.FormatMoney(_shipyard.computeShipPrice(hullSize));
				lblTotalPrice.Text = Functions.FormatMoney(_shipyard.computeDesignPrice(hullSize) + _shipyard.computeShipPrice(hullSize));
				lblJumpRange.Text = Functions.Multiples(_shipyard.computeRange(hullSize, (int)numFuel.Value), Strings.DistanceUnit);
				_hullSize	= (int)numHullSpace.Value;
				_weapons	= (int)numWeapons.Value;
				_gadgets	= (int)numGadgets.Value;
				_shields	= (int)numShields.Value;
				_fuel			= (int)numFuel.Value;
				_crew			= (int)numCrew.Value;
				_armor		= (int)numArmor.Value;
			}
		}

		private void controlChanged(object sender, System.EventArgs e)
		{
			if (!_initializing)
			{
				checkValidity(false);
			}
		}
				
		#endregion

		private void btnSetPicture_Click(object sender, System.EventArgs e)
		{
			FileDialog dlg = new OpenFileDialog();
			dlg.CheckFileExists = true;
			dlg.Filter = "Windows bitmap (*.bmp)|*.bmp";
			dlg.FilterIndex = 0;
			dlg.Title = "Choose a picture for your ship";
			dlg.ValidateNames = true;
			DialogResult result = dlg.ShowDialog(this);
			if (result == DialogResult.OK) 
			{
				string filename = dlg.FileName;
				picShip.Image = Image.FromFile(filename);
			}
		}

		#region Properties
		public string ShipName
		{
			get
			{
				return txtName.Text;
			}
		}

		public int Weapons
		{
			get
			{
				return (int)numWeapons.Value;
			}
		}

		public int Gadgets
		{
			get
			{
				return (int)numGadgets.Value;
			}
		}

		public int Shields
		{
			get
			{
				return (int)numShields.Value;
			}
		}

		public int Fuel
		{
			get
			{
				return (int)numFuel.Value;
			}
		}

		public int Crew
		{
			get
			{
				return (int)numCrew.Value;
			}
		}

		public int Cargo
		{
			get
			{
				return (int)numCargo.Value;
			}
		}

		public int HullSize
		{
			get
			{
				return (int)numHullSpace.Value;
			}
		}

		public int Armor
		{
			get
			{
				return (int)numArmor.Value;
			}
		}
		#endregion


	}
}
