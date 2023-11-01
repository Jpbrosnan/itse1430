/*
 * ITSE 1430
 * Adventure Game
 * Name: Jonathan Brosnan
 * Lab 3 Final
 * 10/31/2023
 */

namespace JonathanBrosnan.AdventureGame
{
    /// <summary>
    /// Represents a database of characters.
    /// </summary>
    public class CharacterDatabase
    {
        //Preloading 3 characters into database to make testing and grading easier.
        public CharacterDatabase ()
        {
            var characters = new[] {
                    new Character() {
                        Name = "Luke",
                        Profession = "Hunter",
                        Race = "Dwarf",
                        Biography = "Nice Guy",
                        Strength = 40,
                        Intelligence = 40,
                        Agility = 40,
                        Constitution = 40,
                        Charisma = 40,
                    },
                    new Character() {
                        Name = "Jake",
                        Profession = "Priest",
                        Race = "Gnome",
                        Biography = "Good Guy",
                        Strength = 50,
                        Intelligence = 50,
                        Agility = 50,
                        Constitution = 50,
                        Charisma = 50,
                    },
                    new Character() {
                        Name = "Lilli",
                        Profession = "Fighter",
                        Race = "Elf",
                        Strength = 2,
                        Intelligence = 2,
                        Agility = 100,
                        Constitution = 2,
                        Charisma = 2,
                    },
                };

            foreach (var character in characters)
                Add(character);
            
        }

        #region Public Database Handlers

        /// <summary>Adds a character to the database.</summary>
        /// <param name="character">The character to add.</param>
        /// <returns>Empty string if successful or an error message otherwise.</returns>
        /// <remarks>
        /// Character cannot be null.
        /// Character must be valid.
        /// Character name must be unique.
        /// </remarks>
        public string Add ( Character character )
        {
           //Validate: null, invalid character
           if (character == null)
                return "Character is null";

            //Validates with Character validate function
            if (!character.TryValidate(out var error)) 
                return error;
           
            //Name must be unique
            var existing = FindByName(character.Name);
            if (existing != null)
                return "Character name must be unique";

            character.Id = _id++;
            _characters.Add(Clone(character));
            return "";
            
        }

        /// <summary>Deletes a character from the database.</summary>
        /// <param name="id">ID of the character to delete.</param>
        public void Delete ( int id )
        {
            if (id > 0)
            {
                var character = FindById(id);
                if (character != null)
                    _characters.Remove(character); 
            }
        }

        /// <summary>Gets all the characters in the database.</summary>
        /// <returns>The list of character.</returns>
        public List<Character> GetAll ()
        {
            var items = new List<Character>();
            foreach (var character in _characters)
                items.Add(Clone(character));
            return items;
        }

        /// <summary>Updates a character in the database.</summary>
        /// <param name="id">ID of the character to update.</param>
        /// <param name="character">The updated character information.</param>
        /// <returns>Empty string if successful or an error message otherwise.</returns>
        /// <remarks>
        /// Id must be > 0.
        /// Character cannot be null.
        /// Character must be valid.
        /// Character must exist.
        /// Character title must be unique.
        /// </remarks>
        public string Update ( int id, Character character )
        {
            //Validate: null, invalid character
            if (id <= 0)
                return "ID is invalid";

            if (character == null)
                return "Character is null";

            //Validates with Character validate function
            if (!character.TryValidate(out var error))
                return error;

            //Name must be unique (and not self)
            var existing = FindByName(character.Name);
            if (existing != null && existing.Id != id)
                return "Character name must be unique";

            //Character must exist
            existing = FindById(id);
            if (existing == null)
                return "Character not found";

            //Update
            Copy(existing, character);
            return "";
        }

        #endregion

        #region Private Members
        private Character Clone ( Character character )
        {
            var item = new Character() { Id = character.Id };
            Copy(item, character);

            return item;
        }

        private void Copy ( Character target, Character source )
        {
            
            target.Name = source.Name;
            target.Biography = source.Biography;
            target.Profession = source.Profession;
            target.Race = source.Race;

            target.Strength = source.Strength;
            target.Intelligence = source.Intelligence;
            target.Agility = source.Agility;
            target.Constitution = source.Constitution;
            target.Charisma = source.Charisma;
        }

        private Character FindById ( int id )
        {
            foreach (var character in _characters)
                if (character.Id == id)
                    return character;

            return null;
        }

        private Character FindByName ( string name )
        {
      
            foreach (var character in _characters)
                if (String.Equals(name, character.Name, StringComparison.OrdinalIgnoreCase))
                    return character;

            return null;
        }

        private readonly List<Character> _characters = new List<Character>();
        private int _id = 1;

        #endregion
    }
}
