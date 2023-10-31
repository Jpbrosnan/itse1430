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

        private void OnSave ( object sender, EventArgs e )
        {
            //Validate and abort if necessary
            if (!ValidateChildren())
            {
                DialogResult = DialogResult.None;
                return;
            };
            var button = sender as Button;

            var character = new Character();

            //Populate from the UI
            character.Name = _charName.Text;
            character.Biography = _charBiography.Text;
            character.Profession = _charProfession.Text;
            character.Race = _charRace.Text;

            character.Strength = GetInt32(_charStrength, 0);
            character.Intelligence = GetInt32(_charIntelligence, 0);
            character.Agility = GetInt32(_charAgility, 0);
            character.Constitution = GetInt32(_charConstitution, 0);
            character.Charisma = GetInt32(_charCharisma, 0);

            /*
            if (!character.TryValidate(out var error))
            {
                MessageBox.Show(this, error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                DialogResult = DialogResult.None;
                return;
            };
            */
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
                _errors.SetError(_charName, "Poop Name is required");
                e.Cancel = true;
            } else
                _errors.SetError(_charName, "");
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
            if (!(attribute >= Character.MinimumAttributeValue && attribute <= Character.MaximumAttributeValue))
            {
                //Invalid
                _errors.SetError(_charStrength, $"Attribute must be between {Character.MinimumAttributeValue} - {Character.MaximumAttributeValue} inclusively.");
                e.Cancel = true;
            } else
                _errors.SetError(_charStrength, "");
        }
        private void OnValidateIntelligence ( object sender, System.ComponentModel.CancelEventArgs e )
        {

            var attribute = GetInt32(_charStrength, 0);
            if (!(attribute >= Character.MinimumAttributeValue && attribute <= Character.MaximumAttributeValue))
            {
                //Invalid
                _errors.SetError(_charStrength, $"Attribute must be between {Character.MinimumAttributeValue} - {Character.MaximumAttributeValue} inclusively.");
                e.Cancel = true;
            } else
                _errors.SetError(_charStrength, "");
        }
        private string CreateAttributeWarning ( string type )
        {
            return $"The {type} attribute must be between {Character.MinimumAttributeValue} - {Character.MaximumAttributeValue} inclusively.";
        }
        private bool CheckAttributeRange ( int attribute )
        {
            if (attribute >= Character.MinimumAttributeValue && attribute <= Character.MaximumAttributeValue)
                return true;

            return false;
        }
    }
}
