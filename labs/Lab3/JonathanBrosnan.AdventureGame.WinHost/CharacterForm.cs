using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.VisualBasic.Devices;

namespace JonathanBrosnan.AdventureGame.WinHost
{
    public partial class CharacterForm : Form
    {
        public CharacterForm ()
        {
            InitializeComponent();
        }

        public Character Character { get; set; }

        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            //Load movie data, if any
            if (Character != null)
            {
                Text = "Edit Movie";

                _charName.Text = Character.Name;
                _charBiography.Text = Character.Biography;
                _charProfession.Text = Character?.Profession;
                _charRace.Text = Character?.Race;

                _charStrength.Text = Character.Strength.ToString();
                _charIntelligence.Text = Character.Intelligence.ToString();
                _charAgility.Text = Character.Agility.ToString();
                _charConstitution.Text = Character.Constitution.ToString();
                _charCharisma.Text = Character.Charisma.ToString();

            };

            //ValidateChildren();
         
        }
        private void OnSave ( object sender, EventArgs e )
        {
            //Validate and abort if necessary
            if (!ValidateChildren())
            {
                DialogResult = DialogResult.None;
                return;
            };
            //var button = sender as Button;

            var character = new Character {
                //Populate from the UI
                Name = _charName.Text,
                Biography = _charBiography.Text,
                Profession = _charProfession.Text,
                Race = _charRace.Text,

                Strength = GetInt32(_charStrength, 0),
                Intelligence = GetInt32(_charIntelligence, 0),
                Agility = GetInt32(_charAgility, 0),
                Constitution = GetInt32(_charConstitution, 0),
                Charisma = GetInt32(_charCharisma, 0)
            };


            if (!character.TryValidate(out var error))
            {
                MessageBox.Show(this, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return;
            };

            Character = character;
            //DialogResult = DialogResult.OK;
            //Close();
        }

        private void OnCancel ( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private int GetInt32 ( Control control, int defaultValue )
        {
            if (Int32.TryParse(control.Text, out var value))
                return value;

            return defaultValue;
        }

        private void OnValidateName ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            if (String.IsNullOrEmpty(_charName.Text))
            {
                //Invalid
                _errors.SetError(_charName, "Name is required");
                e.Cancel = true;
            } else
                _errors.SetError(_charName, null);
        }
        private void OnValidateRace ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            if (String.IsNullOrEmpty(_charRace.Text))
            {
                //Invalid
                _errors.SetError(_charRace, "Race is required");
                e.Cancel = true;
            } else
                _errors.SetError(_charRace, "");
        }

        private void OnValidateProfession ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            if (String.IsNullOrEmpty(_charProfession.Text))
            {
                //Invalid
                _errors.SetError(_charProfession, "Profession is required");
                e.Cancel = true;
            } else
                _errors.SetError(_charProfession, "");
        }

        private void OnValidateStrength ( object sender, System.ComponentModel.CancelEventArgs e )
        {

            var attribute = GetInt32(_charStrength, 0);
            if (!CheckAttributeRange(attribute))
            {
                //Invalid
                _errors.SetError(_charStrength, CreateAttributeWarning("strength"));
                e.Cancel = true;
            } else
                _errors.SetError(_charStrength, "");
        }

        private void OnValidateIntelligence ( object sender, System.ComponentModel.CancelEventArgs e )
        {

            var attribute = GetInt32(_charIntelligence, 0);
            if (!CheckAttributeRange(attribute))
            {
                //Invalid
                _errors.SetError(_charIntelligence, CreateAttributeWarning("intelligence"));
                e.Cancel = true;
            } else
                _errors.SetError(_charIntelligence, "");
        }

        private void OnValidateAgility ( object sender, System.ComponentModel.CancelEventArgs e )
        {

            var attribute = GetInt32(_charAgility, 0);
            if (!CheckAttributeRange(attribute))
            {
                //Invalid
                _errors.SetError(_charAgility, CreateAttributeWarning("agility"));
                e.Cancel = true;
            } else
                _errors.SetError(_charAgility, "");
        }

        private void OnValidateConstitution ( object sender, System.ComponentModel.CancelEventArgs e )
        {
            
            var attribute = GetInt32(_charConstitution, 0);
            if (!CheckAttributeRange(attribute))
            {
                //Invalid
                _errors.SetError(_charConstitution, CreateAttributeWarning("constitution"));
                e.Cancel = true;
            } else
                _errors.SetError(_charConstitution, "");
        }

        private void OnValidateCharisma ( object sender, System.ComponentModel.CancelEventArgs e )
        {

            var attribute = GetInt32(_charCharisma, 0);
            if (!CheckAttributeRange(attribute))
            {
                //Invalid
                _errors.SetError(_charCharisma, CreateAttributeWarning("charisma"));
                e.Cancel = true;
            } else
                _errors.SetError(_charCharisma, "");
        }
        private string CreateAttributeWarning ( string type )
        {
            return $"The {type} attribute must be between {Character.MinimumAttributeValue} - {Character.MaximumAttributeValue} inclusively.";
        }
        private bool CheckAttributeRange ( int attribute )
        {
            return (attribute >= Character.MinimumAttributeValue && attribute <= Character.MaximumAttributeValue);

        }

    }
}
