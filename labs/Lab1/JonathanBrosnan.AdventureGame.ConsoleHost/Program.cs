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
var room = 1;

DisplayIntro();

var done = false;

do
{

    ShowDirections();
    //var command = DisplayMenu();
    previousRoom = room;
    switch (ChoosePath())
    {
        //1=N 2=S 3=E 4=W
        case 1: 
        Story(previousRoom, 1); break;

        case 91:
        InvalidDirectionWarning(1);
        break;

        case 2:
        Story(previousRoom, 2); break;

        case 92:
        InvalidDirectionWarning(2);
        break;

        case 3:
        Story(previousRoom, 3); break;

        

        case 93:
        InvalidDirectionWarning(3);
        break;

        case 4:
        Story(previousRoom, 4); break;

        

        case 94:
        InvalidDirectionWarning(4);
        break;

        case 0:
        done = true;
        break;

        case 100:
        Console.WriteLine("Invalid input entered. Please try again.");
        break;
    };

    
} while (!done);



void DisplayIntro ()
{

    Console.WriteLine("Introduction do later");

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

}



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
        Console.WriteLine("Invalid input entered. Please try again.");
    };



}




bool ValidMove(int CurrentRoom, int direction )
{

    switch (CurrentRoom)
    {
        case 1: return Grid1(direction); 
        case 2: return Grid2(direction);
        case 3: return Grid3(direction);
        case 4: return Grid4(direction);
        case 5: return Grid5(direction);
        case 6: return Grid6(direction);
        case 7: return Grid7(direction);
        case 8: return Grid8(direction);
        case 9: return Grid9(direction);




    }
    return true;
}

bool Grid1 (int direction)
{   
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 2: room = 4; return true;
        case 3: room = 2; return true;
        default: return false;
    };
}

bool Grid2 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 4: room = 1; return true;
        case 3: room = 3; return true;
        case 2: room = 5; return true;
        default: return false;
    };
}

bool Grid3 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 4: room = 2; return true;
        case 2: room = 6; return true;
        default: return false;
    };
}

bool Grid4 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 1: room = 1;  return true;
        case 3: room = 5;  return true;
        case 2: room = 7;  return true;
        default: return false;
    };
}

bool Grid5 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 4: room = 4; return true;
        case 1: room = 2; return true;   
        case 3: room = 6; return true;
        case 2: room = 8; return true;
        default: return false;
    };
}

bool Grid6 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 2: room = 9; return true;
        case 4: room = 5; return true;
        case 1: room = 3; return true;
        default: return false;
    };
}

bool Grid7 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 1: room = 4; return true;
        case 3: room = 8; return true;
        default: return false;
    };
}

bool Grid8 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 1: room = 5;  return true;
        case 4: room = 7; return true;
        case 3: room = 9;  return true;
        default: return false;
    };
}

bool Grid9 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 1: room = 6; return true;
        case 4: room = 8; return true;
        default: return false;
    };
}

void Story (int lastRoom, int direction)
{
    switch (room)
    {
        case 1: room1Story(lastRoom, direction); break;
        case 2: room2Story(lastRoom, direction); break;
        case 3: room3Story(lastRoom, direction); break;
        case 4: room4Story(lastRoom, direction); break;
        case 5: room5Story(lastRoom, direction); break;
        case 6: room6Story(lastRoom, direction); break;
        case 7: room7Story(lastRoom, direction); break;
        case 8: room8Story(lastRoom, direction); break;
        case 9: room9Story(lastRoom, direction); break;
        default: Console.WriteLine("Invalid room number."); break;

    };
}
void InvalidDirectionWarning (int direction)
{
    switch (room) {
        case 1: room1Exits(direction, false); break;
        case 2: room2Exits(direction, false); break;
        case 3: room3Exits(direction, false); break;
        case 4: room4Exits(direction, false); break;
        case 5: room5Exits(direction, false); break;
        case 6: room6Exits(direction, false); break;
        case 7: room7Exits(direction, false); break;
        case 8: room8Exits(direction, false); break;
        case 9: room9Exits(direction, false); break;
        default: Console.WriteLine("Invalid room number."); break;
    };
}

void room1Story(int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    if(RandomEncounter())
        Console.WriteLine("Random Encounter");
    Console.WriteLine("Room Description");
    room1Exits(direction, true);

}

void room1Exits(int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");
    
    Console.WriteLine("Possible Exits");
}
void room2Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    room2Exits(direction, true);

}

void room2Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
void room3Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    room3Exits(direction, true);

}

void room3Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
void room4Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    room4Exits(direction, true);

}
void room4Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
void room5Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    room5Exits(direction, true);

}
void room5Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
void room6Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    room6Exits(direction, true);

}
void room6Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
void room7Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    room7Exits(direction, true);

}
void room7Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
void room8Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    room8Exits(direction, true);

}
void room8Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
void room9Story ( int lastRoom, int direction )
{
    Console.WriteLine($"You head {directionNumberConverter(direction)} from room#{lastRoom} towards room#{room}.");
    Console.WriteLine("Room Description");
    room9Exits(direction, true);

}
void room9Exits ( int direction, bool invalid )
{
    if (!invalid)
        Console.WriteLine($"You are unable to travel {directionNumberConverter(direction)} from this room.");

    Console.WriteLine("Possible Exits");
}
string directionNumberConverter(int direction)
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