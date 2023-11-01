using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JonathanBrosnan.AdventureGame
{
    public class CharacterDatabase
    {
        


        public CharacterDatabase ()
        {
            //Object initializer - replaces need for creating an object (expression) and then assigning values to properties (statements)
            // object-initializer ::= new T() { property-assignment+ }
            // property-assignment ::= id = Et,
            //var movie = new Movie();
            //movie.Id = _id++;
            //movie.Title = "Jaws";
            //movie.ReleaseYear = 1977;
            //movie.Rating = Rating.PG;
            //movie.RunLength = 120;
            //_movies[0] = movie;
            //_movies[0] = new Movie() {
            //    Id = _id++,
            //    Title = "Jaws",
            //    ReleaseYear = 1977,
            //    Rating = Rating.PG,
            //    RunLength = 120,
            //};

            //Collection initializer syntax
            // new T[] { E, E, E }
            //Set up movies
            var characters = new[] {
                    new Character() {
                        Name = "Luke",
                        Profession = "Hunter",
                        Race = "Dwarf",
                        Biography = "Cool Guy",
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
                        Biography = "Bad Guy",
                        Strength = 50,
                        Intelligence = 50,
                        Agility = 50,
                        Constitution = 50,
                        Charisma = 50,
                    },
                    new Character() {
                        Name = "Jon",
                        Profession = "Fighter",
                        Race = "Elf",
                        Biography = "Cool Guy",
                        Strength = 2,
                        Intelligence = 2,
                        Agility = 100,
                        Constitution = 2,
                        Charisma = 2,
                    },
                };

            //Enumeration - use foreach
            // foreach-statement ::= foreach (T id in array) S;
            // 1. variant is readonly
            // 2. array must be immutable while enumerating
            //for (int index = 0; index < movies.Length; ++index)
            //   Add(movies[index]);
            foreach (var character in characters)
                Add(character);
            
        }
        public string Add ( Character character )
        {
            //Validate: null, invalid character
            if (character == null)
                return "Character is null";
           if (!character.TryValidate(out var error)) 
                return error;
           

            //Title must be unique
            var existing = FindByName(character.Name);
            if (existing != null)
                return "Character Name must be unique";

            character.Id = _id++;
            _characters.Add(Clone(character));
            return "";
            
        }
        public void Delete ( int id )
        {
            var character = FindById(id);
            if (character != null)
                _characters.Remove(character);  //Reference equality applies
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
        public string Update ( int id, Character character )
        {
            //Validate: null, invalid movie
            if (id <= 0)
                return "ID is invalid";

            if (character == null)
                return "Character is null";
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
        private Character Clone ( Character character )
        {
            var item = new Character() { Id = character.Id };
            Copy(item, character);

            return item;
        }
        private void Copy ( Character target, Character source )
        {
            //Don't copy Id
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
    }
}
