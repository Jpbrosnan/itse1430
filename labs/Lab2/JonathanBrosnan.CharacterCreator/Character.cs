using System;

public class Character
{
    public Character ()
    {
        _initialized = true;
    }

    public Character ( string name, string profession, string race ) : this()
    {
        Name = name;
        Profession = profession;
        Race = race;
    }

    public Character ( string name, string profession, string race, string biography ) : this(name, profession, race)
    {
        Biography = biography;
    }

    private string _name;
    private string _profession;
    private string _race;
    private string _biography;
    private readonly bool _initialized = false;

    public string Name { get; set; }
    public string Profession { get; set; }

    public string Race { get; set; }
    public string Biography { get; set; }


    //Attributes
    private int _strength;
    private int _intelligence;
    private int _agility;
    private int _constitution;
    private int _charisma;
    private int _minimumAttributeValue = 1;
    private int _maximumAttributeValue = 100;

    public int Strength { get; set; } = 1;
    public int Intelligence { get; set; } = 1;

    public int Agility { get; set; } = 1;

    public int Constitution { get; set; } = 1;
    public int Charisma { get; set; } = 1;

    public int MaximumAttributeValue { get; }

    public int MinimumAttributeValue { get; }


  
}

//