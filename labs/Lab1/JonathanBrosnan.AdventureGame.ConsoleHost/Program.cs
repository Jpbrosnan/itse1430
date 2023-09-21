/*
  Name: Jonathan Brosnan
* ITSE 1430
* Fall 2023
* Lab 1 Final
*/


//Entry Point
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

var previousRoom = 1;
//Current Room
var presentRoom = 1;
DisplayIntro();
var done = false;

do
{
    ShowMenuDirections();
    previousRoom = presentRoom;
    switch (ChoosePath())
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        //The corresponding 90s values are for when a user enters a direction that is not possible.
        case 1: DisplayRoomStory(previousRoom, 1); break;

        case 91: DisplayRoomExits(1); break;

        case 2: DisplayRoomStory(previousRoom, 2); break;

        case 92: DisplayRoomExits(2); break;

        case 3: DisplayRoomStory(previousRoom, 3); break;

        case 93: DisplayRoomExits(3); break;

        case 4: DisplayRoomStory(previousRoom, 4); break;

        case 94: DisplayRoomExits(4); break;

        case 0: done = true; break;

        case 100: Console.WriteLine("Lets continue the adventure!");  break;

        case 102: Console.WriteLine("Invalid input entered. Your input must be one of the following: N, S, E, W, Q"); break;
    };
 
} while (!done);

void DisplayIntro ()
{
    Console.WriteLine("You wake up in a dark room with no memory of how you got there. As you try to figure out what");
    Console.WriteLine("is happening to you, you hear strange noises emanating from the walls in front of you.");
    Console.WriteLine("Eventually you realize that you must pick between two doors that most likely lead to the ungodly");
    Console.WriteLine("sounds you are hearing. Which direction will you choose to go?");
}

void ShowMenuDirections ()
{
    Console.WriteLine("\n---------------\n");
    Console.WriteLine("N) Choose North");
    Console.WriteLine("S) Choose South");
    Console.WriteLine("E) Choose East");
    Console.WriteLine("W) Choose West");
    Console.WriteLine("Q) End Game");
    Console.WriteLine("\n---------------\n");
}

//User input function
int ChoosePath ()
{
    do
    {   
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.N: return (MoveFromRoom(presentRoom, 1) ? 1 : 91);

            case ConsoleKey.S: return (MoveFromRoom(presentRoom, 2) ? 2 : 92);

            case ConsoleKey.E: return (MoveFromRoom(presentRoom, 3) ? 3 : 93);

            case ConsoleKey.W: return (MoveFromRoom(presentRoom, 4) ? 4 : 94);

            case ConsoleKey.Q: return (QuitConfirm() ? 0 : 100);

            default: return 102;
        };
       
    } while (true);
}

bool QuitConfirm ()
{
    while (true)
    {
        Console.WriteLine("Are you sure you want to quit?(Y/N)");

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.Y: return true;

            case ConsoleKey.N: return false;

        };

        Console.WriteLine("\nInvalid input entered. Please enter Y or N.\n");
    };
}

bool MoveFromRoom( int currentRoom, int direction )
{
    switch (currentRoom)
    {
        case 1: return MoveFromRoom1(direction); 

        case 2: return MoveFromRoom2(direction);

        case 3: return MoveFromRoom3(direction);

        case 4: return MoveFromRoom4(direction);

        case 5: return MoveFromRoom5(direction);

        case 6: return MoveFromRoom6(direction);

        case 7: return MoveFromRoom7(direction);

        case 8: return MoveFromRoom8(direction);

        case 9: return MoveFromRoom9(direction);

        default: return false;

    };
}

bool MoveFromRoom1 ( int direction)
{   
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 2: presentRoom = 4; return true;

        case 3: presentRoom = 2; return true;

        default: return false;
    };
}

bool MoveFromRoom2 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 2: presentRoom = 5; return true;

        case 3: presentRoom = 3; return true;

        case 4: presentRoom = 1; return true;

        default: return false;
    };
}

bool MoveFromRoom3 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 2: presentRoom = 6; return true;

        case 4: presentRoom = 2; return true;

        default: return false;
    };
}

bool MoveFromRoom4 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 1: presentRoom = 1;  return true;

        case 2: presentRoom = 7; return true;

        case 3: presentRoom = 5;  return true;

        default: return false;
    };
}

bool MoveFromRoom5 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 1: presentRoom = 2; return true;

        case 2: presentRoom = 8; return true;
          
        case 3: presentRoom = 6; return true;

        case 4: presentRoom = 4; return true;

        default: return false;
    };
}

bool MoveFromRoom6 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 1: presentRoom = 3; return true;

        case 2: presentRoom = 9; return true;

        case 4: presentRoom = 5; return true;

        default: return false;
    };
}

bool MoveFromRoom7 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 1: presentRoom = 4; return true;

        case 3: presentRoom = 8; return true;

        default: return false;
    };
}

bool MoveFromRoom8 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 1: presentRoom = 5; return true;

        case 3: presentRoom = 9; return true;

        case 4: presentRoom = 7; return true;
        
        default: return false;
    };
}

bool MoveFromRoom9 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 1: presentRoom = 6; return true;

        case 4: presentRoom = 8; return true;

        default: return false;
    };
}

void DisplayRoomStory ( int lastRoom, int direction)
{
    switch (presentRoom)
    {
        case 1: DisplayRoom1Story(lastRoom, direction); break;

        case 2: DisplayRoom2Story(lastRoom, direction); break;

        case 3: DisplayRoom3Story(lastRoom, direction); break;

        case 4: DisplayRoom4Story(lastRoom, direction); break;

        case 5: DisplayRoom5Story(lastRoom, direction); break;

        case 6: DisplayRoom6Story(lastRoom, direction); break;

        case 7: DisplayRoom7Story(lastRoom, direction); break;

        case 8: DisplayRoom8Story(lastRoom, direction); break;

        case 9: DisplayRoom9Story(lastRoom, direction); break;

        default: Console.WriteLine("Invalid room number."); break;

    };
}
void DisplayRoomExits ( int direction )
{
    switch (presentRoom) {

        case 1: DisplayRoom1Exits(direction, false); break;

        case 2: DisplayRoom2Exits(direction, false); break;

        case 3: DisplayRoom3Exits(direction, false); break;

        case 4: DisplayRoom4Exits(direction, false); break;

        case 5: DisplayRoom5Exits(direction, false); break;

        case 6: DisplayRoom6Exits(direction, false); break;

        case 7: DisplayRoom7Exits(direction, false); break;

        case 8: DisplayRoom8Exits(direction, false); break;

        case 9: DisplayRoom9Exits(direction, false); break;

        default: Console.WriteLine("Invalid room number."); break;
    };
}

void DisplayRoom1Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {ConvertDirectionIntegerToString(direction)} from room#{lastRoom} towards room#{presentRoom}.");
    DisplayRandomEncounter();

    Console.WriteLine("You enter the room and immediately realize that you've come all the way back to the original");
    Console.WriteLine("room you woke up in. You see signs of other victims that have passed through the room since");
    Console.WriteLine("you’ve started this horrible journey. Dread overcomes you when you realize that you will");
    Console.WriteLine("probably never leave this cursed place. What direction do you choose this time?");

    DisplayRoom1Map();
    DisplayRoom1Exits(direction, true);
}

void DisplayRoom1Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to walk {ConvertDirectionIntegerToString(direction)} from this room.");

    Console.WriteLine("Your available directions to exit from this room are south and east.");
}
void DisplayRoom2Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {ConvertDirectionIntegerToString(direction)} from room#{lastRoom} towards room#{presentRoom}.");
    DisplayRandomEncounter();

    Console.WriteLine("The room consists of just 1 single bed. As you walked past the bed towards the other door,");
    Console.WriteLine("something crawled from underneath the bed. The creature was taller than a lamppost and");
    Console.WriteLine("moved crouched and close to the ground. It had 2 arms that were long and stick-like. Its back");
    Console.WriteLine("was covered in chitin like spikes. Its mouth was bursting with teeth. It had a single bulging black");
    Console.WriteLine("membrane for an eye. You launch yourself away from the beast. Which direction do you flee");
    Console.WriteLine("toward?");

    DisplayRoom2Map();
    DisplayRoom2Exits(direction, true);
}

void DisplayRoom2Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to walk {ConvertDirectionIntegerToString(direction)} from this room.");

    Console.WriteLine("Your available directions to exit from this room are south, west and east.");
}
void DisplayRoom3Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {ConvertDirectionIntegerToString(direction)} from room#{lastRoom} towards room#{presentRoom}.");
    DisplayRandomEncounter();

    Console.WriteLine("What greeted you when you entered the room shocked you to your core. The creature was");
    Console.WriteLine("unnatural and broken, slithered on the ground like a worm. Its fiendish frame was broken and");
    Console.WriteLine("distorted. Its body appeared to be covered in skull and jaw like protrusions. It had 2 arms that");
    Console.WriteLine("were too long for its body and ended in razor sharp silver talons. Its back was covered in bone");
    Console.WriteLine("like protrusions. Its mouth gaped open with rows of saw-like teeth and a long black tongue. It");
    Console.WriteLine("had a single blistery white orb for an eye.");


    DisplayRoom3Map();
    DisplayRoom3Exits(direction, true);
}

void DisplayRoom3Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to walk {ConvertDirectionIntegerToString(direction)} from this room.");

    Console.WriteLine("Your available directions to exit from this room are south and west.");
}
void DisplayRoom4Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {ConvertDirectionIntegerToString(direction)} from room#{lastRoom} towards room#{presentRoom}.");
    DisplayRandomEncounter();

    Console.WriteLine("As you entered the room to find a horrible monster crawling on the ceiling. The monster was half");
    Console.WriteLine("as tall as a man and moved crouched and close to the ground. Its grotesque anatomy was");
    Console.WriteLine("obese to the point of bursting. Its body appeared to be covered in cactus like needles. It had 6");
    Console.WriteLine("arms that were long and stick-like. Two grotesque arms sprouted from its back like wings. Its");
    Console.WriteLine("face was as dark as a shadow. Its mouth had teeth like broken glass. Its eyes were 2 bug-like");
    Console.WriteLine("teal slits. What direction should you run towards?");

    DisplayRoom4Map();
    DisplayRoom4Exits(direction, true);
}
void DisplayRoom4Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to walk {ConvertDirectionIntegerToString(direction)} from this room.");

    Console.WriteLine("Your available directions to exit from this room are north, south and east.");
}
void DisplayRoom5Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {ConvertDirectionIntegerToString(direction)} from room#{lastRoom} towards room#{presentRoom}.");
    DisplayRandomEncounter();

    Console.WriteLine("You enter the room to find your late mother standing before you. Something was disturbingly off");
    Console.WriteLine("about her even though, physically, she was identical. It was like the entity was wearing your");
    Console.WriteLine("mother's existence as their own skin. She began slowly floating towards you, silently whispering");
    Console.WriteLine("your name like she did when you were still her little boy. You noticed that the closer she got to");
    Console.WriteLine("you, the louder her voice got. You decided that you didn't want to find out what would happen");
    Console.WriteLine("when she finally reached you. Which direction do you scurry too?");

    DisplayRoom5Map();
    DisplayRoom5Exits(direction, true);
}
void DisplayRoom5Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to walk {ConvertDirectionIntegerToString(direction)} from this room.");

    Console.WriteLine("You can move in any direction from this room.");
}
void DisplayRoom6Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {ConvertDirectionIntegerToString(direction)} from room#{lastRoom} towards room#{presentRoom}.");
    DisplayRandomEncounter();

    Console.WriteLine("As expected, an unholy being stalked towards you as soon as you entered the room. The");
    Console.WriteLine("creature was small enough to fit in a barrel and stood upright on two legs. Its hellish frame was");
    Console.WriteLine("thin and gangly. Its body appeared to be covered in slippery oil. It had 3 arms, one shriveled and");
    Console.WriteLine("one huge. Two grotesque arms sprouted from its back like wings. Its face was too big for its");
    Console.WriteLine("head. Its mouth was filled with glowing teeth. Its eyes were 2 ooze secreting dark green orbs. If");
    Console.WriteLine("you make it past alive, what direction do you escape toward?");

    DisplayRoom6Map();
    DisplayRoom6Exits(direction, true);
}
void DisplayRoom6Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to walk {ConvertDirectionIntegerToString(direction)} from this room.");

    Console.WriteLine("Your available directions to exit from this room are north, south and west from this room.");
}
void DisplayRoom7Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {ConvertDirectionIntegerToString(direction)} from room#{lastRoom} towards room#{presentRoom}.");
    DisplayRandomEncounter();

    Console.WriteLine("This time when entering the room instead of being across the room, the creature appeared 1");
    Console.WriteLine("inch in front of you. The creature standing in front of you was something out of a fantasy horror");
    Console.WriteLine("movie. The creature was larger than a gorilla and stood upright on two legs. Its crooked frame");
    Console.WriteLine("was thin and gangly. Its body appeared to be covered in a dense exoskeleton. It had 2 arms that");
    Console.WriteLine("was thin and gangly. Its body appeared to be covered in a dense exoskeleton. It had 2 arms that");
    Console.WriteLine("protrusions. Its body was corpse-like and clung together with loose skin. Its mouth was bursting");
    Console.WriteLine("with teeth.");

    DisplayRoom7Map();
    DisplayRoom7Exits(direction, true);
}
void DisplayRoom7Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to walk {ConvertDirectionIntegerToString(direction)} from this room.");

    Console.WriteLine("Your available directions to exit from this room are north and east from this room.");
}
void DisplayRoom8Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {ConvertDirectionIntegerToString(direction)} from room#{lastRoom} towards room#{presentRoom}.");
    DisplayRandomEncounter();

    Console.WriteLine("You hurry into the room to find an identical version of you staring at you smiling wide like a");
    Console.WriteLine("demon. As you cautiously move toward another exit, your devilish doppelganger mirrors your");
    Console.WriteLine("motion exactly. After a traumatic number of moments, you realize that the imposter’s identical");
    Console.WriteLine("movement is trapping you in this room. Immediately, you knew what had to be done. It had to be");
    Console.WriteLine("knocked out, or worse, killed.. What direction will you run towards after your violent struggle?");

    DisplayRoom8Map();
    DisplayRoom8Exits(direction, true);
}
void DisplayRoom8Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to walk {ConvertDirectionIntegerToString(direction)} from this room.");

    Console.WriteLine("Your available directions to exit from this room are west, north and east from this room.");
}
void DisplayRoom9Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {ConvertDirectionIntegerToString(direction)} from room#{lastRoom} towards room#{presentRoom}.");
    DisplayRandomEncounter();

    Console.WriteLine("You enter the room to find yourself in the most crowded DMV waiting room you’ve ever seen. It");
    Console.WriteLine("is so crowded, you can barely breathe. After hours of grueling, claustrophobic micromovements,");
    Console.WriteLine("you reach a door that will free you from this hell. What direction did you decide to go?");

    DisplayRoom9Map();
    DisplayRoom9Exits(direction, true);
}
void DisplayRoom9Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {ConvertDirectionIntegerToString(direction)} from this room.");

    Console.WriteLine("Your available directions to exit from this room are north and west from this room.");
}
string ConvertDirectionIntegerToString (int direction)
{
    switch (direction)
    {
        case 1: return "north";

        case 2: return "south";

        case 3: return "east";

        case 4: return "west";

        default: return "Invalid direction number";
    };
}

void DisplayRandomEncounter ()
{
    if (GeneratePercentage() < 5)
    {
        Console.WriteLine("As you pass through the doorway, you feel a wall of invisible force pass through your body. You");
        Console.WriteLine("postulate that when going from one room to another you are actually passing through a gateway");
        Console.WriteLine("that connects all the rooms. What the hell is this place?");
    }
}

int GeneratePercentage ()
{
    return Random.Shared.Next(1, 101);
}

void DisplayRoom1Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" X 2 3");
    Console.WriteLine(" 4 5 6");
    Console.WriteLine(" 7 8 9");
    Console.WriteLine();
}
void DisplayRoom2Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 X 3");
    Console.WriteLine(" 4 5 6");
    Console.WriteLine(" 7 8 9");
    Console.WriteLine();
}

void DisplayRoom3Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 2 X");
    Console.WriteLine(" 4 5 6");
    Console.WriteLine(" 7 8 9");
    Console.WriteLine();
}
void DisplayRoom4Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 2 3");
    Console.WriteLine(" X 5 6");
    Console.WriteLine(" 7 8 9");
    Console.WriteLine();
}
void DisplayRoom5Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 2 3");
    Console.WriteLine(" 4 X 6");
    Console.WriteLine(" 7 8 9");
    Console.WriteLine();
}
void DisplayRoom6Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 2 3");
    Console.WriteLine(" 4 5 X");
    Console.WriteLine(" 7 8 9");
    Console.WriteLine();
}
void DisplayRoom7Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 2 3");
    Console.WriteLine(" 4 5 6");
    Console.WriteLine(" X 8 9");
    Console.WriteLine();
}
void DisplayRoom8Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 2 3");
    Console.WriteLine(" 4 5 6");
    Console.WriteLine(" 7 X 9");
    Console.WriteLine();
}

void DisplayRoom9Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 2 3");
    Console.WriteLine(" 4 5 6");
    Console.WriteLine(" 7 8 X");
    Console.WriteLine();
}