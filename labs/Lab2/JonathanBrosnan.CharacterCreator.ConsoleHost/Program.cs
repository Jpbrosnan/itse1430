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

    /// <summary>
    /// Runs the character creator.
    /// </summary>
    void Run ()
    {
        //add, delete, view, edit
        Character player = new Character();
        var done = false;
        do
        {
            DisplayMenu();

            switch (GetMenuInput())
            {
                //add, delete, view, edit
                //The corresponding 90s values are for when a user enters a direction that is not possible.
                case 1: player = AddCharacter(); break;

                case 2: ViewCharacter(player); break;

                case 3: player = EditCharacter(player); break;

                case 4: DeleteCharacter(player); break;

                case 0: done = true; break;

                case 100: Display("Lets continue the character creator!", 2); break;

                case 102: Display("ERROR: Invalid input entered. Your input must be one of the following: A, V, E, D, Q", 3); break;
            };

        } while (!done);
    }
    
    /// <summary>
    /// Displays main menu.
    /// </summary>
    /// <remarks>The user is shown the menu options and the corresponding input option. </remarks>
    void DisplayMenu ()
    {
        Console.WriteLine("\n---------------\n");
        Console.WriteLine("A) Add New Character");
        Console.WriteLine("V) View Character");
        Console.WriteLine("E) Edit Character");
        Console.WriteLine("D) Delete Character");
        Console.WriteLine("Q) End Character Creator");
        Console.WriteLine("\n---------------\n");
    }

    /// <summary>
    /// Handles the main menu input.
    /// </summary>
    /// <returns>The number that corresponding to the menu item selected.</returns>
    int GetMenuInput ()
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


    
    /// <summary>
    /// Creates a new character from user input.
    /// </summary>
    /// <returns>The created character.</returns>
    Character AddCharacter ()
    {
        //var character = new Character(ReadString("Enter the character's name: ", true), ReadProfession(), ReadRace(), ReadString("Enter the character's biography", false));
        do
        {
            var character = new Character();
            character.Name = ReadString("Enter the character's name: ", true);
            character.Profession = HandleProfessionInput();
            character.Race = HandleRaceInput();
            character.Biography = ReadString("\nEnter the character's biography(Optional): ", false);


            character.Strength = HandleAttributeInput("strength", character.MinimumAttributeValue, character.MaximumAttributeValue);
            character.Intelligence = HandleAttributeInput("intelligence", character.MinimumAttributeValue, character.MaximumAttributeValue);
            character.Agility = HandleAttributeInput("agility", character.MinimumAttributeValue, character.MaximumAttributeValue);
            character.Constitution = HandleAttributeInput("constitution", character.MinimumAttributeValue, character.MaximumAttributeValue);
            character.Charisma = HandleAttributeInput("charisma", character.MinimumAttributeValue, character.MaximumAttributeValue);


            var error = character.Validate();
            if (String.IsNullOrEmpty(error))
                return character;

            Display($"ERROR: {error}",3);
        } while (true);
        
        
    }
    /// <summary>
    /// Views existing character stats.
    /// </summary>
    /// <param name="character">The Character that is being viewed.</param>
    void ViewCharacter ( Character character )
    {
        if (String.IsNullOrEmpty(character.Name))
        {
            Display("ERROR: No character available.", 3);
            return;
        }

        DisplayStats(character, true);

    }
    /// <summary>
    /// Edits an existing character.
    /// </summary>
    /// <param name="character">Character that is to be edited.</param>
    /// <returns>The edited character.</returns>
    Character EditCharacter ( Character character )
    {
        if (String.IsNullOrEmpty(character.Name))
        {
            Display("Creating new character because there is no existing character.", 2);
            return AddCharacter();
        }

        return HandlesEditInputs(character);

    }

    /// <summary>
    /// Deletes a character.
    /// </summary>
    /// <param name="character">The character that is being deleted.</param>
    void DeleteCharacter ( Character character )
    {
        if (String.IsNullOrEmpty(character.Name))
        {
            Display("ERROR: No character to delete.", 3);
        } else if (Confirm("Are you sure you want to delete the character? (Y/N)"))
        {
            character.Name =  "";
            Display("Character deleted.", 2);

        } else
        {
            Display("Character not deleted.", 2);
        }
    }

    /// <summary>
    /// Reads a string.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="isRequired">false to allow empty string otherwise a value must be inputed.</param>
    /// <returns></returns>
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

    /// <summary>
    /// Handles the profession selection input.
    /// </summary>
    /// <returns>The selected profession string. </returns>
    string HandleProfessionInput()
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


    
    /// <summary>
    /// Handles the race selection input.
    /// </summary>
    /// <returns>The selected race string</returns>
    string HandleRaceInput ()
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

            };
            Display("ERROR: Options are D) Dwarf, E) Elf, G) Gnome, F) Half Elf, H) Human", 3);
        } while (true);
    }
    /// <summary>
    /// Reads the attribute value.
    /// </summary>
    /// <param name="message">The attribute that is being asked about.</param>
    /// <param name="minimumValue">The minimum value that the attribute value can be.</param>
    /// <param name="maximumValue">The maximum value that the attribute value can be.</param>
    /// <returns>The attribute value.</returns>
    int HandleAttributeInput ( string message, int minimumValue, int maximumValue )
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
    /// <summary>
    /// Displays the professions menu.
    /// </summary>
    void DisplayProfessions ()
    {
        Display("\nPick one of the following professions for the character: ", 1);
        Console.WriteLine("F) Fighter");
        Console.WriteLine("H) Hunter");
        Console.WriteLine("P) Priest");
        Console.WriteLine("R) Rogue");
        Console.WriteLine("W) Wizard");
    }
    /// <summary>
    /// Displays the races menu.
    /// </summary>
    void DisplayRaces ()
    {
        
        Display("\nPick one of the following races for the character:", 1);
        Console.WriteLine("D) Dwarf");
        Console.WriteLine("E) Elf");
        Console.WriteLine("G) Gnome");
        Console.WriteLine("F) Half Elf");
        Console.WriteLine("H) Human");
        
    }

   

    
    
    

   
    
    
    /// <summary>
    /// Handles the character edit inputs.
    /// </summary>
    /// <param name="character">The character that is to be edited.</param>
    /// <returns>The character that has been edited.</returns>
    Character HandlesEditInputs(Character character )
    {
        
        do
        {
            DisplayStats(character, false);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.N: character.Name = ReadString("Enter the character's name: ", true); break;

                case ConsoleKey.P: character.Profession = HandleProfessionInput(); break;

                case ConsoleKey.R: character.Race = HandleRaceInput(); break;

                case ConsoleKey.B: character.Biography = ReadString("Enter the character's biography(Optional): ", false); break;

                case ConsoleKey.S: character.Strength = HandleAttributeInput("strength", character.MinimumAttributeValue, character.MaximumAttributeValue); break;

                case ConsoleKey.I: character.Intelligence = HandleAttributeInput("intelligence", character.MinimumAttributeValue, character.MaximumAttributeValue); break;

                case ConsoleKey.A: character.Agility = HandleAttributeInput("agility", character.MinimumAttributeValue, character.MaximumAttributeValue); break;

                case ConsoleKey.C: character.Constitution = HandleAttributeInput("constitution", character.MinimumAttributeValue, character.MaximumAttributeValue); break;

                case ConsoleKey.H: character.Charisma = HandleAttributeInput("charisma", character.MinimumAttributeValue, character.MaximumAttributeValue); break;

                case ConsoleKey.Q: return character; 

            };

        } while (true);
    }
    /// <summary>
    /// Displays the characters stat menu.
    /// </summary>
    /// <param name="character">The character that is being displayed.</param>
    /// <param name="type">true if displaying for ViewCharacter function and false if displaying for EditCharacter function.</param>
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

    /// <summary>
    /// Displays the message in a color that is used the given type.
    /// </summary>
    /// <param name="message">The message to be colored.</param>
    /// <param name="type">The type of message. 1 = Asking, 2 = Confirmation, 3 = Error, 4 = Header.</param>
    void Display ( string message, int type )
    {
        
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

    /// <summary>
    /// Confirms if user wants to proceed.
    /// </summary>
    /// <param name="message">Confirmation message that the user must confirm.</param>
    /// <returns>true if user confirms the message and false if the user chooses to not confirm.</returns>
    bool Confirm ( string message )
    {
        Display(message, 1);

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




}



/*Questions:
 * 
 * 1. Check if my attribute validation is what he wants.
 * 2. Check to see if can use custom constructer instead of current implementation
 * 3. Check to see if class structure is correct.
 * 4. Should i make the repetitive output in ViewCharacter and EditCharacter a function.
 * 5. How should I handle the minimum and maximum attribute values. Handle in character class right now
 * 6. Do I need to put input validation in the class or is it fine in the program.
 * 7. Is the attribute range 1-100 inclusive?
 * 
*/