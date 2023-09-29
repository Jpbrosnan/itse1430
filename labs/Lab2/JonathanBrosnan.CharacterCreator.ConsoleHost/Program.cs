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
        Character player = new Character();
        var done = false;
       
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

                case 4: DeleteCharacter(player); break;

                case 0: done = true; break;

                case 100: Display("Lets continue the character creator!", 2); break;

                case 102: Display("Invalid input entered. Your input must be one of the following: A, V, E, D, Q", 3); break;
            };

        } while (!done);
    }
    /// <summary>
    /// 
    /// </summary>
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
        do
        {
            var character = new Character();
            character.Name = ReadString("Enter the character's name: ", true);
            character.Profession = ReadProfession();
            character.Race = ReadRace();
            character.Biography = ReadString("\nEnter the character's biography(Optional): ", false);


            character.Strength = ReadAttribute("strength", character.MinimumAttributeValue, character.MaximumAttributeValue);
            character.Intelligence = ReadAttribute("intelligence", character.MinimumAttributeValue, character.MaximumAttributeValue);
            character.Agility = ReadAttribute("agility", character.MinimumAttributeValue, character.MaximumAttributeValue);
            character.Constitution = ReadAttribute("constitution", character.MinimumAttributeValue, character.MaximumAttributeValue);
            character.Charisma = ReadAttribute("charisma", character.MinimumAttributeValue, character.MaximumAttributeValue);


            var error = character.Validate();
            if (String.IsNullOrEmpty(error))
                return character;

            Display($"ERROR: {error}",3);
        } while (true);
        
        
    }

    string ReadProfession()
    {
        
        DisplayProfessions();
        do
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.F: Display("Profession selected: Fighter", 2); return "Fighter";

                case ConsoleKey.H: Display("Profession selected: Hunter", 2); return "Hunter";

                case ConsoleKey.P: Display("Profession selected: Priest", 2); return "Priest";

                case ConsoleKey.R: Display("Profession selected: Rogue", 2); return "Rogue"; 

                case ConsoleKey.W: Display("Profession selected: Wizard", 2); return "Wizard";

            };
            Display("Error: Options are F) Fighter, H) Hunter, P) Priest, R) Rogue, W) Wizard", 3);
        } while (true);


    }


    void DisplayProfessions ()
    {
        Display("\nPick one of the following professions for the character: ", 1);
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
                case ConsoleKey.D: Display("Race selected: Dwarf", 2); return "Dwarf";

                case ConsoleKey.E: Display("Race selected: Elf", 2); return "Elf";

                case ConsoleKey.G: Display("Race selected: Gnome", 2); return "Gnome";

                case ConsoleKey.F: Display("Race selected: Half Elf", 2); return "Half Elf";

                case ConsoleKey.H: Display("Race selected: Human", 2); return "Human";

                //default: Console.WriteLine("Options are D) Dwarf, E) Elf, G) Gnome, F) Half Elf, H) Human"); continue;

            };
            Display("ERROR: Options are D) Dwarf, E) Elf, G) Gnome, F) Half Elf, H) Human", 3);
        } while (true);
    }

    void DisplayRaces ()
    {
        
        Display("\nPick one of the following races for the character:", 1);
        Console.WriteLine("D) Dwarf");
        Console.WriteLine("E) Elf");
        Console.WriteLine("G) Gnome");
        Console.WriteLine("F) Half Elf");
        Console.WriteLine("H) Human");
        
    }

    string ReadString ( string message, bool isRequired )
    {
        Display(message, 1);

        do
        {
            string value = Console.ReadLine().Trim();

            if (!isRequired || !String.IsNullOrEmpty(value))
                return value;

            Display("ERROR: Value is required", 3);
        } while (true);
    }

    void Display (string message, int type)
    {
        //1 = Asking, 2 = Confirmation, 3 = Error
        switch (type)
        {
            case 1: Console.ForegroundColor = ConsoleColor.Green; break;
            case 2: Console.ForegroundColor = ConsoleColor.Cyan; break;
            case 3: Console.ForegroundColor = ConsoleColor.Red; break;
            case 4: Console.ForegroundColor = ConsoleColor.Yellow; break;
        }
        Console.WriteLine(message);
        Console.ResetColor();

    }
    
    int ReadAttribute ( string message, int minimumValue, int maximumValue )
    {
        do
        {

            Display($"\nEnter the character's {message} attribute value ({minimumValue}-{maximumValue}): ", 1);
            string value = Console.ReadLine();

            if (Int32.TryParse(value, out var result))
                if (result >= minimumValue && result <= maximumValue) //&& Confirm($"Please confirm the value of {result} for attribute {message} (Y/N)"))
                    return result;

            Display($"ERROR: Value must be at least {minimumValue} and at most {maximumValue}.", 3);
        } while (true);
    }

    bool Confirm( string message )
    {
        Display(message,1);

        //Handle errors
        while (true)
        {
         
            switch (Console.ReadKey(true).Key)
            {
                
                case ConsoleKey.Y: return true;

                case ConsoleKey.N: return false;
                         
            };

            Display("\nERROR: Invalid input entered. Please enter Y or N.\n", 3);

        };
    }
    
    void ViewCharacter(Character character )
    {
        if (String.IsNullOrEmpty(character.Name))
        {
            Display("ERROR: No character available.", 3);
            return;
        }

        DisplayStats(character, true);

    }

    Character EditCharacter( Character character )
    {
        if (String.IsNullOrEmpty(character.Name))
        {
            Display("Creating new character because there is no existing character.", 2);
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

                case ConsoleKey.B: character.Biography = ReadString("Enter the character's biography(Optional): ", false); break;

                case ConsoleKey.S: character.Strength = ReadAttribute("strength", character.MinimumAttributeValue, character.MaximumAttributeValue); break;

                case ConsoleKey.I: character.Intelligence = ReadAttribute("intelligence", character.MinimumAttributeValue, character.MaximumAttributeValue); break;

                case ConsoleKey.A: character.Agility = ReadAttribute("agility", character.MinimumAttributeValue, character.MaximumAttributeValue); break;

                case ConsoleKey.C: character.Constitution = ReadAttribute("constitution", character.MinimumAttributeValue, character.MaximumAttributeValue); break;

                case ConsoleKey.H: character.Charisma = ReadAttribute("charisma", character.MinimumAttributeValue, character.MaximumAttributeValue); break;

                case ConsoleKey.Q: return character; 

            };

        } while (true);
    }
    
    void DisplayStats(Character character, bool type )
    {
        if (type)
        {
            Display("-----Character Information-----", 4);
            Console.WriteLine($"Name: {character.Name}");
            Console.WriteLine($"Profession: {character.Profession}");
            Console.WriteLine($"Race: {character.Race}");
            Console.WriteLine(!String.IsNullOrEmpty(character.Biography) ? $"Biography: {character.Biography}" : "Biography: ");

            Display("--Attributes--", 4);
            Console.WriteLine($"Strength: {character.Strength}");
            Console.WriteLine($"Intelligence: {character.Intelligence}");
            Console.WriteLine($"Agility: {character.Agility}");
            Console.WriteLine($"Constitution: {character.Constitution}");
            Console.WriteLine($"Charisma: {character.Charisma}");
        } else
        {
            Display("\n-----Character Information-----", 4);
            Console.WriteLine($"N) Name: {character.Name}");
            Console.WriteLine($"P) Profession: {character.Profession}");
            Console.WriteLine($"R) Race: {character.Race}");
            Console.WriteLine(!String.IsNullOrEmpty(character.Biography) ? $"B) Biography: {character.Biography}" : "B) Biography: ");

            Display("--Attributes--", 4);
            Console.WriteLine($"S) Strength: {character.Strength}");
            Console.WriteLine($"I) Intelligence: {character.Intelligence}");
            Console.WriteLine($"A) Agility: {character.Agility}");
            Console.WriteLine($"C) Constitution: {character.Constitution}");
            Console.WriteLine($"H) Charisma: {character.Charisma}");
            Console.WriteLine("Q) Quit the edit character menu.");
        }

    }

    void DeleteCharacter(Character character )
    {
        if (String.IsNullOrEmpty(character.Name))
        {
            Display("ERROR: No character to delete.", 3);
        }
        else if(Confirm("Are you sure you want to delete the character? (Y/N)"))
        {
           character.Name =  "";
           Display("Character deleted.", 2);

        } else
        {
            Display("Character not deleted.", 2);
        }
    }
    

    
}



/*Questions:
 * 
 * 1. Check if my attribute validation is what he wants.
 * 2. Check to see if can use custom constructer instead of current implementation
 * 3. Check to see if class structure is correct.
 * 4. Should i make the repetitive output in ViewCharacter and EditCharacter a function.
 * 5. How should I handle the minimum and maximum attribute values. Handle in character class right now
 * 6. Do I need to put input validation in the class or is it fine in the program.
 * 
*/