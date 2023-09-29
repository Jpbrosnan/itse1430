/*
 Name: Jonathan Brosnan
* ITSE 1430
* Fall 2023
* Lab 2
*/


partial class Program 
{
    static void Main ()
    {
        var app = new Program();
        app.Run();
    }

    void Run ()
    {
        //add, delete, view, edit
        Character player = new Character ();
        DisplayIntro();
        var done = false;
        int minimumAttributeValue = 1;
        int maximumAttributeValue = 100;

        do
        {
            ShowMenuDirections();
            switch (ChoosePath())
            {
                //add, delete, view, edit
                //The corresponding 90s values are for when a user enters a direction that is not possible.
                case 1: player = AddCharacter(); break;

                case 2: ViewCharacter(player); break;
                
                case 3: player = EditCharacter(player); break;

                case 0: done = true; break;

                case 100: Console.WriteLine("Lets continue the character creator!"); break;

                case 102: Console.WriteLine("Invalid input entered. Your input must be one of the following: A, V, E, D, Q"); break;
            };

        } while (!done);

        void DisplayIntro ()
        {
            Console.WriteLine("Intro");
        }

        void ShowMenuDirections ()
        {
            Console.WriteLine("\n---------------\n");
            Console.WriteLine("A) Add New Character");
            Console.WriteLine("V) View Character");
            Console.WriteLine("E) Edit Character");
            Console.WriteLine("D) Delete Character");
            Console.WriteLine("Q) End Character Creator");
            Console.WriteLine("\n---------------\n");
        }

        int ChoosePath ()
        {
            do
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A: return 1;

                    case ConsoleKey.V: return 2;

                    case ConsoleKey.E: return 3;

                    case ConsoleKey.D: return 4;

                    case ConsoleKey.Q: return (Confirm("Are you sure you want to quit?(Y/N)") ? 0 : 100);

                    default: return 102;
                };

            } while (true);
        }


      

        Character AddCharacter ()
        {
           //var character = new Character(ReadString("Enter the character's name: ", true), ReadProfession(), ReadRace(), ReadString("Enter the character's biography", false));
           
           var character = new Character();
           character.Name = ReadString("Enter the character's name: ", true);
           character.Profession = ReadProfession();
           character.Race = ReadRace();
           character.Biography = ReadString("Enter the character's biography: ", false);
           

           character.Strength = ReadAttribute("strength", minimumAttributeValue, maximumAttributeValue);
           character.Intelligence = ReadAttribute("intelligence", minimumAttributeValue, maximumAttributeValue);
           character.Agility = ReadAttribute("agility", minimumAttributeValue, maximumAttributeValue);
           character.Constitution = ReadAttribute("constitution", minimumAttributeValue, maximumAttributeValue);
           character.Charisma = ReadAttribute("charisma", minimumAttributeValue, maximumAttributeValue);

           return character;
            
        }

        string ReadProfession()
        {
            
            DisplayProfessions();
            do
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.F: Console.WriteLine("Profession selected: Fighter"); return "Fighter";

                    case ConsoleKey.H: Console.WriteLine("Profession selected: Hunter"); return "Hunter";

                    case ConsoleKey.P: Console.WriteLine("Profession selected: Priest"); return "Priest";

                    case ConsoleKey.R: Console.WriteLine("Profession selected: Rogue"); return "Rogue"; 

                    case ConsoleKey.W: Console.WriteLine("Profession selected: Wizard"); return "Wizard";

                };
                Console.WriteLine("Options are F) Fighter, H) Hunter, P) Priest, R) Rogue, W) Wizard");
            } while (true);


        }


        void DisplayProfessions ()
        {
            Console.WriteLine("\nPick one of the following professions for the character:");
            Console.WriteLine("F) Fighter");
            Console.WriteLine("H) Hunter");
            Console.WriteLine("P) Priest");
            Console.WriteLine("R) Rogue");
            Console.WriteLine("W) Wizard");
        }

        string ReadRace ()
        {
            DisplayRaces();
            do
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D: Console.WriteLine("Race selected: Dwarf"); return "Dwarf";

                    case ConsoleKey.E: Console.WriteLine("Race selected: Elf"); return "Elf";

                    case ConsoleKey.G: Console.WriteLine("Race selected: Gnome"); return "Gnome";

                    case ConsoleKey.F: Console.WriteLine("Race selected: Half Elf"); return "Half Elf";

                    case ConsoleKey.H: Console.WriteLine("Race selected: Human"); return "Human";

                    //default: Console.WriteLine("Options are D) Dwarf, E) Elf, G) Gnome, F) Half Elf, H) Human"); continue;

                };
                Console.WriteLine("Options are D) Dwarf, E) Elf, G) Gnome, F) Half Elf, H) Human");
            } while (true);
        }

        void DisplayRaces ()
        {
            Console.WriteLine("\nPick one of the following races for the character:");
            Console.WriteLine("D) Dwarf");
            Console.WriteLine("E) Elf");
            Console.WriteLine("G) Gnome");
            Console.WriteLine("F) Half Elf");
            Console.WriteLine("H) Human");
        }

        string ReadString ( string message, bool isRequired )
        {
            Console.WriteLine(message);

            do
            {
                string value = Console.ReadLine().Trim();

                if (!isRequired || !String.IsNullOrEmpty(value))
                    return value;

                Console.WriteLine("Value is required");
            } while (true);
        }


        
        int ReadAttribute ( string message, int minimumValue, int maximumValue )
        {
            

            do
            {
                Console.WriteLine($"\nEnter the character's {message} attribute value ({minimumValue}-{maximumValue}): ");
                string value = Console.ReadLine();

                if (Int32.TryParse(value, out var result))
                    if (result >= minimumValue && result <= maximumValue) //&& Confirm($"Please confirm the value of {result} for attribute {message} (Y/N)"))
                        return result;

                Console.WriteLine($"Value must be at least {minimumValue} and less than or equal to {maximumValue}");
            } while (true);
        }

        bool Confirm( string message )
        {
            Console.WriteLine(message);

            //Handle errors
            while (true)
            {
             
                switch (Console.ReadKey(true).Key)
                {
                    
                    case ConsoleKey.Y: return true;

                    case ConsoleKey.N: return false;
                             
                };

                Console.WriteLine("\nInvalid input entered. Please enter Y or N.\n");

            };
        }
    
        void ViewCharacter(Character character )
        {
            if (String.IsNullOrEmpty(character.Name))
            {
                Console.WriteLine("No character available.");
                return;
            }

            Console.WriteLine("-----Character Information-----");
            Console.WriteLine($"Name: {character.Name}");
            Console.WriteLine($"Profession: {character.Profession}");
            Console.WriteLine($"Race: {character.Race}");
            Console.WriteLine(!String.IsNullOrEmpty(character.Biography) ? $"Biography: {character.Biography}" : "Biography: "); 
            
            Console.WriteLine("--Attributes--");
            Console.WriteLine($"Strength: {character.Strength}");
            Console.WriteLine($"Intelligence: {character.Intelligence}");
            Console.WriteLine($"Agility: {character.Agility}");
            Console.WriteLine($"Constitution: {character.Constitution}");
            Console.WriteLine($"Charisma: {character.Charisma}");

        }

        Character EditCharacter( Character character )
        {
            if (String.IsNullOrEmpty(character.Name))
            {
                Console.WriteLine("Creating new character because there is no existing character.");
                return AddCharacter();
            }

            return DisplayEditMenu(character);

        }

        Character DisplayEditMenu(Character character )
        {
            //var editedCharacter = character;
            do
            {
                DisplayStats(character, false);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.N: character.Name = ReadString("Enter the character's name: ", true); break;

                    case ConsoleKey.P: character.Profession = ReadProfession(); break;

                    case ConsoleKey.R: character.Race = ReadRace(); break;

                    case ConsoleKey.B: character.Biography = ReadString("Enter the character's biography: ", false); break;

                    case ConsoleKey.S: character.Strength = ReadAttribute("strength", minimumAttributeValue, maximumAttributeValue); break;

                    case ConsoleKey.I: character.Intelligence = ReadAttribute("intelligence", minimumAttributeValue, maximumAttributeValue); break;

                    case ConsoleKey.A: character.Agility = ReadAttribute("agility", minimumAttributeValue, maximumAttributeValue); break;

                    case ConsoleKey.C: character.Constitution = ReadAttribute("constitution", minimumAttributeValue, maximumAttributeValue); break;

                    case ConsoleKey.H: character.Charisma = ReadAttribute("charisma", minimumAttributeValue, maximumAttributeValue); break;

                    case ConsoleKey.Q: return character; 

                };

            } while (true);
        }
        
        void DisplayStats(Character character, bool type )
        {
            if (type)
            {
                Console.WriteLine("-----Character Information-----");
                Console.WriteLine($"Name: {character.Name}");
                Console.WriteLine($"Profession: {character.Profession}");
                Console.WriteLine($"Race: {character.Race}");
                Console.WriteLine(!String.IsNullOrEmpty(character.Biography) ? $"Biography: {character.Biography}" : "Biography: ");

                Console.WriteLine("--Attributes--");
                Console.WriteLine($"Strength: {character.Strength}");
                Console.WriteLine($"Intelligence: {character.Intelligence}");
                Console.WriteLine($"Agility: {character.Agility}");
                Console.WriteLine($"Constitution: {character.Constitution}");
                Console.WriteLine($"Charisma: {character.Charisma}");
            } else
            {
                Console.WriteLine("-----Character Information-----");
                Console.WriteLine($"N) Name: {character.Name}");
                Console.WriteLine($"P) Profession: {character.Profession}");
                Console.WriteLine($"R) Race: {character.Race}");
                Console.WriteLine(!String.IsNullOrEmpty(character.Biography) ? $"B) Biography: {character.Biography}" : "B) Biography: ");

                Console.WriteLine("--Attributes--");
                Console.WriteLine($"S) Strength: {character.Strength}");
                Console.WriteLine($"I) Intelligence: {character.Intelligence}");
                Console.WriteLine($"A) Agility: {character.Agility}");
                Console.WriteLine($"C) Constitution: {character.Constitution}");
                Console.WriteLine($"H) Charisma: {character.Charisma}");
                Console.WriteLine("Q) Quit the edit character menu.");
            }

        }
    }

    
}



/*Questions:
 * 
 * 1. Check if my attribute validation is what he wants.
 * 2. Check to see if can use custom constructer instead of current implementation
 * 3. Check to see if class structure is correct.
 * 4. Should i make the repetitive output in ViewCharacter and EditCharacter a function.
 * 5. How should I handle the minimum and maximum attribute values.
 * 
*/