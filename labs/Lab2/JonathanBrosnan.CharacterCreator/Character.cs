using System;
/// <summary>
/// Represents a character. Name, profession and race are required fields for a valid character.
/// </summary>
public class Character
{
    /// <summary>
    /// Default constructor for character class.
    /// </summary>
    public Character ()
    {
       
    }

    /// <summary>
    /// Custom constructor without biography.
    /// </summary>
    /// <param name="name">Name of character.</param>
    /// <param name="profession">Profession of character. Possible professions are Fighter, Hunter, Priest, Rogue, and Wizard.</param>
    /// <param name="race">Race of character. Possible races are Dwarf, Elf, Gnome, Half Elf, and Human.</param>
    public Character ( string name, string profession, string race ) : this()
    {
        Name = name;
        Profession = profession;
        Race = race;
    }

    /// <summary>
    /// Custom constructor without biography.
    /// </summary>
    /// <param name="name">Name of character.</param>
    /// <param name="profession">Profession of character. Possible professions are Fighter, Hunter, Priest, Rogue, and Wizard.</param>
    /// <param name="race">Race of character. Possible races are Dwarf, Elf, Gnome, Half Elf, and Human.</param>
    /// <param name="biography">Small summary of character.</param>
    public Character ( string name, string profession, string race, string biography ) : this(name, profession, race)
    {
        Biography = biography;
    }


    /// <summary>
    /// Gets and sets the name of character.
    /// </summary>
    public string Name {
        get 
        {
            if (String.IsNullOrEmpty(_name))
                return "";

            return _name;
        }
        set {
            if (value != null)
                value = value.Trim();

            _name = value;
        } 
    }

    /// <summary>
    /// Gets and sets the profession of character. Possible professions are Fighter, Hunter, Priest, Rogue, and Wizard.
    /// </summary>
    public string Profession {
        get {
            if (String.IsNullOrEmpty(_profession))
                return "";

            return _profession;
        }
        set {
            if (value != null)
                value = value.Trim();

            _profession = value;
        }
    }

    /// <summary>
    /// Gets and sets the race of character. Possible races are Dwarf, Elf, Gnome, Half Elf, and Human.
    /// </summary>
    public string Race {
        get {
            if (String.IsNullOrEmpty(_race))
                return "";

            return _race;
        }
        set {
            if (value != null)
                value = value.Trim();

            _race = value;
        }
    }

    /// <summary>
    /// Gets and sets the biography of character.
    /// </summary>
    public string Biography {
        get {
            if (String.IsNullOrEmpty(_biography))
                return "";

            return _biography;
        }
        set {
            if (value != null)
            {
                value = value.Trim();
                _biography = value;
            }            
        }
    }


    //Attributes



    /// <summary>
    /// Gets and sets the strength attribute.
    /// </summary>
    public int Strength { get { return _strength; } set { _strength = value; } }

    /// <summary>
    /// Gets and sets the intelligence attribute.
    /// </summary>
    public int Intelligence { get { return _intelligence; } set { _intelligence = value; } }

    /// <summary>
    /// Gets and sets the agility attribute.
    /// </summary>
    public int Agility { get { return _agility; } set { _agility = value; } }

    /// <summary>
    /// Gets and sets the constitution attribute.
    /// </summary>
    public int Constitution { get { return _constitution; } set { _constitution = value; } }

    /// <summary>
    /// Gets and sets the charisma attribute.
    /// </summary>
    public int Charisma { get { return _charisma; } set { _charisma = value; } }

    /// <summary>
    /// Gets the minimum attribute value.
    /// </summary>
    public int MinimumAttributeValue{ get { return _minimumAttributeValue; } }

    /// <summary>
    /// Gets the maximum attribute value.
    /// </summary>
    public int MaximumAttributeValue { get { return _maximumAttributeValue; } }

    //Fields - data

    private string _name;
    private string _profession;
    private string _race;
    private string _biography;

    private int _strength;
    private int _intelligence;
    private int _agility;
    private int _constitution;
    private int _charisma;

    

    /// <summary>
    /// Current minimum attribute value allowed.
    /// </summary>
    private int _minimumAttributeValue = 1;

    /// <summary>
    /// Current maximum attribute value allowed.
    /// </summary>
    private int _maximumAttributeValue = 100;

    /// <summary>
    /// Validates the character instance.
    /// </summary>
    /// <returns>The error message or an empty string if there are no errors. </returns>
    public string Validate ()
    {
        if (!TryValidate(out var message))
            return message;

        return "";
    }

    /// <summary>
    /// Validates the character instance.
    /// </summary>
    /// <param name="message">Error message. If the character is valid, message will be an empty string.</param>
    /// <returns>false if character instance fails validation and true if it passes validation.</returns>
    private bool TryValidate(out string message)
    {
        if (String.IsNullOrEmpty(_name))
        {
            message = "Name is required";
            return false;
        }

        if (!ValidateProfession(_profession))
        {
            message = "Profession is invalid. Profession must be one of the following: Fighter, Hunter, Priest, Rogue, Wizard";
            return false;
        }

        if (!ValidateRace(_race))
        {
            message = "Race value is invalid. Race value must be one of the following: Dwarf, Elf, Gnome, Half Elf, Human";
            return false;
        }

        if (!CheckAttributeRange(_strength))
        {
            message = DisplayAttributeWarning("strength");
            return false;
        }

        if (!CheckAttributeRange(_intelligence))
        {
            message = DisplayAttributeWarning("intelligence");
            return false;
        }

        if (!CheckAttributeRange(_agility))
        {
            message = DisplayAttributeWarning("agility");
            return false;
        }

        if (!CheckAttributeRange(_constitution))
        {
            message = DisplayAttributeWarning("constitution");
            return false;
        }

        if (!CheckAttributeRange(_charisma))
        {
            message = DisplayAttributeWarning("charisma");
            return false;
        }

        message = "";
        return true;
    }

    /// <summary>
    /// Validates race value
    /// </summary>
    /// <param name="race">String race value.</param>
    /// <returns>false if invalid race value and true if the race value passes validation.</returns>
    private bool ValidateRace (string race)
    {
        if (String.Equals(race, "Dwarf", StringComparison.CurrentCultureIgnoreCase))
            return true;
        else if (String.Equals(race, "Elf", StringComparison.CurrentCultureIgnoreCase))
            return true;
        else if (String.Equals(race, "Gnome", StringComparison.CurrentCultureIgnoreCase))
            return true;
        else if (String.Equals(race, "Half Elf", StringComparison.CurrentCultureIgnoreCase))
            return true;
        else if (String.Equals(race, "Human", StringComparison.CurrentCultureIgnoreCase))
            return true;
        else
            return false;
    }

    /// <summary>
    /// Validates profession value.
    /// </summary>
    /// <param name="profession">String profession value.</param>
    /// <returns>false if invalid profession value and true if the profession value passes validation.</returns>
    private bool ValidateProfession(string profession )
    {
        if (String.Equals(profession, "Fighter", StringComparison.CurrentCultureIgnoreCase))
            return true;
        else if (String.Equals(profession, "Hunter", StringComparison.CurrentCultureIgnoreCase))
            return true;
        else if (String.Equals(profession, "Priest", StringComparison.CurrentCultureIgnoreCase))
            return true;
        else if (String.Equals(profession, "Rogue", StringComparison.CurrentCultureIgnoreCase))
            return true;
        else if (String.Equals(profession, "Wizard", StringComparison.CurrentCultureIgnoreCase))
            return true;
        else
            return false;
    }

    /// <summary>
    /// Display attribute range warning.
    /// </summary>
    /// <param name="type">The attribute type. Can be strength, intelligence, agility, constitution, and charisma. </param>
    /// <returns>The warning string.</returns>
    private string DisplayAttributeWarning(string type)
    {
        return $"The {type} attribute must be between {_minimumAttributeValue} - {_maximumAttributeValue} inclusively.";
    }

    /// <summary>
    /// Checks if attribute is valid. 
    /// </summary>
    /// <param name="attribute">The attribute integer value.</param>
    /// <returns>true if in between valid range and false if outside valid range.</returns>
    private bool CheckAttributeRange (int attribute)
    {
        if(attribute >= _minimumAttributeValue && attribute <= _maximumAttributeValue) 
            return true;

        return false;
    }

}

