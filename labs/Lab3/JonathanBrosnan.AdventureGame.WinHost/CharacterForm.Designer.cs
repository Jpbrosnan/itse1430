/*
 * ITSE 1430
 * Adventure Game
 * Name: Jonathan Brosnan
 * Lab 3 Final
 * 10/31/2023
 */

namespace JonathanBrosnan.AdventureGame.WinHost
{
    partial class CharacterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            components=new System.ComponentModel.Container();
            _charName=new TextBox();
            label1=new Label();
            label2=new Label();
            label3=new Label();
            label4=new Label();
            label5=new Label();
            label6=new Label();
            label7=new Label();
            label8=new Label();
            label9=new Label();
            _charBiography=new TextBox();
            _charProfession=new ComboBox();
            _charRace=new ComboBox();
            _charStrength=new TextBox();
            _charAgility=new TextBox();
            _charIntelligence=new TextBox();
            _charConstitution=new TextBox();
            _charCharisma=new TextBox();
            _btnSave=new Button();
            _btnCancel=new Button();
            _errors=new ErrorProvider(components);
            label10=new Label();
            label11=new Label();
            ((System.ComponentModel.ISupportInitialize)_errors).BeginInit();
            SuspendLayout();
            // 
            // _charName
            // 
            _charName.ForeColor=SystemColors.WindowText;
            _charName.Location=new Point(84, 46);
            _charName.Name="_charName";
            _charName.Size=new Size(231, 23);
            _charName.TabIndex=0;
            _charName.Validating+=OnValidateName;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(35, 46);
            label1.Name="label1";
            label1.Size=new Size(39, 15);
            label1.TabIndex=1;
            label1.Text="Name";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(13, 75);
            label2.Name="label2";
            label2.Size=new Size(61, 15);
            label2.TabIndex=2;
            label2.Text="Biography";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(12, 118);
            label3.Name="label3";
            label3.Size=new Size(62, 15);
            label3.TabIndex=3;
            label3.Text="Profession";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(39, 147);
            label4.Name="label4";
            label4.Size=new Size(32, 15);
            label4.TabIndex=4;
            label4.Text="Race";
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Location=new Point(39, 325);
            label5.Name="label5";
            label5.Size=new Size(41, 15);
            label5.TabIndex=5;
            label5.Text="Agility";
            // 
            // label6
            // 
            label6.AutoSize=true;
            label6.Location=new Point(7, 354);
            label6.Name="label6";
            label6.Size=new Size(73, 15);
            label6.TabIndex=6;
            label6.Text="Constitution";
            // 
            // label7
            // 
            label7.AutoSize=true;
            label7.Location=new Point(23, 383);
            label7.Name="label7";
            label7.Size=new Size(57, 15);
            label7.TabIndex=7;
            label7.Text="Charisma";
            // 
            // label8
            // 
            label8.AutoSize=true;
            label8.Location=new Point(12, 296);
            label8.Name="label8";
            label8.Size=new Size(68, 15);
            label8.TabIndex=8;
            label8.Text="Intelligence";
            // 
            // label9
            // 
            label9.AutoSize=true;
            label9.Location=new Point(28, 267);
            label9.Name="label9";
            label9.Size=new Size(52, 15);
            label9.TabIndex=9;
            label9.Text="Strength";
            // 
            // _charBiography
            // 
            _charBiography.Location=new Point(84, 75);
            _charBiography.Multiline=true;
            _charBiography.Name="_charBiography";
            _charBiography.PlaceholderText="Optional";
            _charBiography.Size=new Size(231, 37);
            _charBiography.TabIndex=10;
            // 
            // _charProfession
            // 
            _charProfession.DropDownStyle=ComboBoxStyle.DropDownList;
            _charProfession.FormattingEnabled=true;
            _charProfession.Items.AddRange(new object[] { "Fighter", "Hunter", "Priest", "Rogue", "Wizard" });
            _charProfession.Location=new Point(84, 118);
            _charProfession.Name="_charProfession";
            _charProfession.Size=new Size(231, 23);
            _charProfession.TabIndex=11;
            _charProfession.Validating+=OnValidateProfession;
            // 
            // _charRace
            // 
            _charRace.DropDownStyle=ComboBoxStyle.DropDownList;
            _charRace.FormattingEnabled=true;
            _charRace.Items.AddRange(new object[] { "Dwarf", "Elf", "Gnome", "Half Elf", "Human" });
            _charRace.Location=new Point(84, 147);
            _charRace.Name="_charRace";
            _charRace.Size=new Size(231, 23);
            _charRace.TabIndex=12;
            _charRace.Validating+=OnValidateRace;
            // 
            // _charStrength
            // 
            _charStrength.Location=new Point(86, 267);
            _charStrength.Name="_charStrength";
            _charStrength.PlaceholderText="1-100";
            _charStrength.Size=new Size(100, 23);
            _charStrength.TabIndex=13;
            _charStrength.Text="50";
            _charStrength.Validating+=OnValidateStrength;
            // 
            // _charAgility
            // 
            _charAgility.Location=new Point(86, 325);
            _charAgility.Name="_charAgility";
            _charAgility.PlaceholderText="1-100";
            _charAgility.Size=new Size(100, 23);
            _charAgility.TabIndex=15;
            _charAgility.Text="50";
            _charAgility.Validating+=OnValidateAgility;
            // 
            // _charIntelligence
            // 
            _charIntelligence.Location=new Point(86, 296);
            _charIntelligence.Name="_charIntelligence";
            _charIntelligence.PlaceholderText="1-100";
            _charIntelligence.Size=new Size(100, 23);
            _charIntelligence.TabIndex=14;
            _charIntelligence.Text="50";
            _charIntelligence.Validating+=OnValidateIntelligence;
            // 
            // _charConstitution
            // 
            _charConstitution.Location=new Point(86, 354);
            _charConstitution.Name="_charConstitution";
            _charConstitution.PlaceholderText="1-100";
            _charConstitution.Size=new Size(100, 23);
            _charConstitution.TabIndex=16;
            _charConstitution.Text="50";
            _charConstitution.Validating+=OnValidateConstitution;
            // 
            // _charCharisma
            // 
            _charCharisma.Location=new Point(86, 383);
            _charCharisma.Name="_charCharisma";
            _charCharisma.PlaceholderText="1-100";
            _charCharisma.Size=new Size(100, 23);
            _charCharisma.TabIndex=17;
            _charCharisma.Text="50";
            _charCharisma.Validating+=OnValidateCharisma;
            // 
            // _btnSave
            // 
            _btnSave.Anchor=AnchorStyles.Bottom|AnchorStyles.Right;
            _btnSave.DialogResult=DialogResult.OK;
            _btnSave.Location=new Point(559, 406);
            _btnSave.Name="_btnSave";
            _btnSave.Size=new Size(75, 23);
            _btnSave.TabIndex=18;
            _btnSave.Text="Save";
            _btnSave.UseCompatibleTextRendering=true;
            _btnSave.UseVisualStyleBackColor=true;
            _btnSave.Click+=OnSave;
            // 
            // _btnCancel
            // 
            _btnCancel.CausesValidation=false;
            _btnCancel.DialogResult=DialogResult.Cancel;
            _btnCancel.Location=new Point(682, 406);
            _btnCancel.Name="_btnCancel";
            _btnCancel.Size=new Size(75, 23);
            _btnCancel.TabIndex=19;
            _btnCancel.Text="Cancel";
            _btnCancel.Click+=OnCancel;
            // 
            // _errors
            // 
            _errors.BlinkStyle=ErrorBlinkStyle.NeverBlink;
            _errors.ContainerControl=this;
            // 
            // label10
            // 
            label10.AutoSize=true;
            label10.Font=new Font("Segoe UI", 14F, FontStyle.Underline, GraphicsUnit.Point);
            label10.Location=new Point(7, 221);
            label10.Name="label10";
            label10.Size=new Size(159, 25);
            label10.TabIndex=20;
            label10.Text="Attributes (1-100)";
            // 
            // label11
            // 
            label11.AutoSize=true;
            label11.Font=new Font("Segoe UI", 14F, FontStyle.Underline, GraphicsUnit.Point);
            label11.Location=new Point(12, 9);
            label11.Name="label11";
            label11.Size=new Size(156, 25);
            label11.TabIndex=21;
            label11.Text="Character Details";
            // 
            // CharacterForm
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            AutoValidate=AutoValidate.EnableAllowFocusChange;
            CancelButton=_btnCancel;
            ClientSize=new Size(800, 450);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(_btnCancel);
            Controls.Add(_btnSave);
            Controls.Add(_charName);
            Controls.Add(_charRace);
            Controls.Add(_charCharisma);
            Controls.Add(_charConstitution);
            Controls.Add(_charIntelligence);
            Controls.Add(_charAgility);
            Controls.Add(_charStrength);
            Controls.Add(_charProfession);
            Controls.Add(_charBiography);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle=FormBorderStyle.FixedToolWindow;
            MaximizeBox=false;
            MinimizeBox=false;
            Name="CharacterForm";
            ShowIcon=false;
            StartPosition=FormStartPosition.CenterParent;
            Text="Create New Character";
            ((System.ComponentModel.ISupportInitialize)_errors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox _charName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox _charBiography;
        private ComboBox _charProfession;
        private ComboBox _charRace;
        private TextBox _charStrength;
        private TextBox _charAgility;
        private TextBox _charIntelligence;
        private TextBox _charConstitution;
        private TextBox _charCharisma;
        private Button _btnSave;
        private Button _btnCancel;
        private ErrorProvider _errors;
        private Label label10;
        private Label label11;
    }
}