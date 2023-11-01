using Microsoft.VisualBasic.Devices;

namespace JonathanBrosnan.AdventureGame.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();
        }
        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            RefreshCharacters();
        }

        private void OnNewCharacter ( object sender, EventArgs e )
        {
            var item = new CharacterForm();

            do
            {
                if (item.ShowDialog(this) != DialogResult.OK)
                    return;

                //Add movie to library         
                var error = _database.Add(item.Character);
                if (String.IsNullOrEmpty(error))
                    break;
                MessageBox.Show(this, error, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);

            RefreshCharacters();
        }

        private void OnEditCharacter ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            var item = new CharacterForm();
            item.Text = "Edit Character";
            item.Character = character;

            do
            {
                if (item.ShowDialog(this) != DialogResult.OK)
                    return;

                //Edit movie in library
                var error = _database.Update(character.Id, item.Character);
                if (String.IsNullOrEmpty(error))
                    break;
                MessageBox.Show(this, error, "Updated Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);

            RefreshCharacters();
        }

        private void OnDeleteCharacter ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
                return;

            if (!Confirm("Delete", $"Are you sure you want to delete '{character.Name}'?"))
                return;

            //Delete movie
            _database.Delete(character.Id);
            RefreshCharacters();
        }
        protected override void OnFormClosing ( FormClosingEventArgs e )
        {
            if (!Confirm("Do you want to exit?", "Exit"))
            {
                e.Cancel = true;
                return;
            }
            base.OnFormClosing(e);
        }

        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();
            about.ShowDialog(this);
        }
        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }
        private bool Confirm ( string title, string message )
        {
            return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private Character GetSelectedCharacter ()
        {
            return _lstCharacters.SelectedItem as Character;
        }

        private void RefreshCharacters ()
        {
            _lstCharacters.DataSource = null;

            var characters = _database.GetAll();

            _lstCharacters.DataSource = characters;

        }

        private CharacterDatabase _database = new CharacterDatabase();

        
    }
}