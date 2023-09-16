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
var room = 1;
DisplayIntro();
var done = false;

do
{
    ShowDirections();
    previousRoom = room;
    switch (ChoosePath())
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        //The corresponding 90s values are for when a user enters a direction that is not possible.
        case 1: Story(previousRoom, 1); break;

        case 91: InvalidDirectionWarning(1); break;

        case 2: Story(previousRoom, 2); break;

        case 92: InvalidDirectionWarning(2); break;

        case 3: Story(previousRoom, 3); break;

        case 93: InvalidDirectionWarning(3); break;

        case 4: Story(previousRoom, 4); break;

        case 94: InvalidDirectionWarning(4); break;

        case 0: done = true; break;

        case 100: Console.WriteLine("Invalid input entered. Please try again."); break;
    };
 
} while (!done);

void DisplayIntro ()
{
    Console.WriteLine("You wake up in a dark room with no recollection of  ");
    Console.WriteLine("What do you want to do?");
}

void ShowDirections ()
{
    Console.WriteLine("\n---------------\n");
    Console.WriteLine("N) Travel North");
    Console.WriteLine("S) Travel South");
    Console.WriteLine("E) Travel East");
    Console.WriteLine("W) Travel West");
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
            case ConsoleKey.N: return (ValidMove(room, 1) ? 1 : 91);

            case ConsoleKey.S: return (ValidMove(room, 2) ? 2 : 92);

            case ConsoleKey.E: return (ValidMove(room, 3) ? 3 : 93);

            case ConsoleKey.W: return (ValidMove(room, 4) ? 4 : 94);

            case ConsoleKey.Q: return (QuitConfirm() ? 0 : 100);
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

        Console.WriteLine("\nInvalid input entered. Please try again.");
    };
}

bool ValidMove( int currentRoom, int direction )
{

    switch (currentRoom)
    {
        case 1: return Room1(direction); 

        case 2: return Room2(direction);

        case 3: return Room3(direction);

        case 4: return Room4(direction);

        case 5: return Room5(direction);

        case 6: return Room6(direction);

        case 7: return Room7(direction);

        case 8: return Room8(direction);

        case 9: return Room9(direction);

        default: return false;

    };
}

bool Room1 ( int direction)
{   
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 2: room = 4; return true;

        case 3: room = 2; return true;

        default: return false;
    };
}

bool Room2 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 2: room = 5; return true;

        case 3: room = 3; return true;

        case 4: room = 1; return true;

        default: return false;
    };
}

bool Room3 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 2: room = 6; return true;

        case 4: room = 2; return true;

        default: return false;
    };
}

bool Room4 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 1: room = 1;  return true;

        case 2: room = 7; return true;

        case 3: room = 5;  return true;

        default: return false;
    };
}

bool Room5 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 1: room = 2; return true;

        case 2: room = 8; return true;
          
        case 3: room = 6; return true;

        case 4: room = 4; return true;

        default: return false;
    };
}

bool Room6 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 1: room = 3; return true;

        case 2: room = 9; return true;

        case 4: room = 5; return true;

        default: return false;
    };
}

bool Room7 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 1: room = 4; return true;

        case 3: room = 8; return true;

        default: return false;
    };
}

bool Room8 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 1: room = 5; return true;

        case 3: room = 9; return true;

        case 4: room = 7; return true;
        
        default: return false;
    };
}

bool Room9 ( int direction )
{
    switch (direction)
    {
        //1 = North, 2 = South, 3 = East, 4 = West
        case 1: room = 6; return true;

        case 4: room = 8; return true;

        default: return false;
    };
}

void Story ( int lastRoom, int direction)
{
    switch (room)
    {
        case 1: Room1Story(lastRoom, direction); break;

        case 2: Room2Story(lastRoom, direction); break;

        case 3: Room3Story(lastRoom, direction); break;

        case 4: Room4Story(lastRoom, direction); break;

        case 5: Room5Story(lastRoom, direction); break;

        case 6: Room6Story(lastRoom, direction); break;

        case 7: Room7Story(lastRoom, direction); break;

        case 8: Room8Story(lastRoom, direction); break;

        case 9: Room9Story(lastRoom, direction); break;

        default: Console.WriteLine("Invalid room number."); break;

    };
}
void InvalidDirectionWarning ( int direction )
{
    switch (room) {
        case 1: Room1Exits(direction, false); break;

        case 2: Room2Exits(direction, false); break;

        case 3: Room3Exits(direction, false); break;

        case 4: Room4Exits(direction, false); break;

        case 5: Room5Exits(direction, false); break;

        case 6: Room6Exits(direction, false); break;

        case 7: Room7Exits(direction, false); break;

        case 8: Room8Exits(direction, false); break;

        case 9: Room9Exits(direction, false); break;

        default: Console.WriteLine("Invalid room number."); break;
    };
}

void Room1Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");

    if(RandomEncounter())
        Console.WriteLine("");

    Console.WriteLine("Room Description");
    Room1Map();
    Room1Exits(direction, true);
}

void Room1Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");
    
    Console.WriteLine("Possible Exits");
}
void Room2Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    Room2Map();
    Room2Exits(direction, true);
}

void Room2Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
void Room3Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    Room3Map();
    Room3Exits(direction, true);
}

void Room3Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
void Room4Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    Room4Map();
    Room4Exits(direction, true);
}
void Room4Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
void Room5Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    Room5Map();
    Room5Exits(direction, true);
}
void Room5Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
void Room6Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    Room6Map();
    Room6Exits(direction, true);
}
void Room6Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
void Room7Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    Room7Map();
    Room7Exits(direction, true);
}
void Room7Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
void Room8Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    Room8Map();
    Room8Exits(direction, true);
}
void Room8Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
void Room9Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    Room9Map();
    Room9Exits(direction, true);
}
void Room9Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
string directionNumberConverter (int direction)
{
    switch (direction)
    {
        case 1: return "North";

        case 2: return "South";

        case 3: return "East";

        case 4: return "West";

        default: return "Invalid direction number";
    };
}

bool RandomEncounter ()
{
    return ((GeneratePercentage() < 5) ? true : false);
}
int GeneratePercentage ()
{
    return Random.Shared.Next(1, 101);
}

void Room1Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" X 2 3");
    Console.WriteLine(" 4 5 6");
    Console.WriteLine(" 7 8 9");
    Console.WriteLine();
}
void Room2Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 X 3");
    Console.WriteLine(" 4 5 6");
    Console.WriteLine(" 7 8 9");
    Console.WriteLine();
}

void Room3Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 2 X");
    Console.WriteLine(" 4 5 6");
    Console.WriteLine(" 7 8 9");
    Console.WriteLine();
}
void Room4Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 2 3");
    Console.WriteLine(" X 5 6");
    Console.WriteLine(" 7 8 9");
    Console.WriteLine();
}
void Room5Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 2 3");
    Console.WriteLine(" 4 X 6");
    Console.WriteLine(" 7 8 9");
    Console.WriteLine();
}
void Room6Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 2 3");
    Console.WriteLine(" 4 5 X");
    Console.WriteLine(" 7 8 9");
    Console.WriteLine();
}
void Room7Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 2 3");
    Console.WriteLine(" 4 5 6");
    Console.WriteLine(" X 8 9");
    Console.WriteLine();
}
void Room8Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 2 3");
    Console.WriteLine(" 4 5 6");
    Console.WriteLine(" 7 X 9");
    Console.WriteLine();
}

void Room9Map ()
{
    Console.WriteLine();
    Console.WriteLine("X is where you are currently located.");
    Console.WriteLine();
    Console.WriteLine(" 1 2 3");
    Console.WriteLine(" 4 5 6");
    Console.WriteLine(" 7 8 X");
    Console.WriteLine();
}