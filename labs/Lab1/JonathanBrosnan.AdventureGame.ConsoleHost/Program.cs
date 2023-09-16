/*
* ITSE 1430
* Fall 2023
* Name: Jonathan Brosnan
* Lab 1 Final
*/


//Entry Point
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Reflection.Metadata.Ecma335;

DisplayIntro();
ShowDirections(true);

var done = false;
do
{
    //var command = DisplayMenu();

    switch (ChoosePath())
    {
        case 1: break;

        case 91:

        break;

        case 2:
        
        break;

        case 92:

        break;

        case 3:

        break;

        case 93:

        break;

        case 4:
       
        break;

        case 94:

        break;

        case 0:
        done = true;
        break;

        case 100:
        ShowDirections(false);
        break;
    };

    
} while (!done);



void DisplayIntro ()
{

    Console.WriteLine("Introduction do later");

    Console.WriteLine("What do you want to do?");

}

void ShowDirections (bool correct)
{

    Console.WriteLine("\n---------------\n");
    InputWarning(correct);
    Console.WriteLine("N) Travel North");
    Console.WriteLine("S) Travel South");
    Console.WriteLine("E) Travel East");
    Console.WriteLine("W) Travel West");
    Console.WriteLine("Q) End Game");

}



int ChoosePath (int room)
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
        InputWarning(false);
    };



}


void InputWarning(bool message )
{
    if (!message)
        Console.WriteLine("Invalid input entered. Please try again.");
    


}

bool ValidMove(int room, int direction )
{   
    return true;
}

int Grid1 (int direction)
{   
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 2: return 4;
        case 3: return 2;
        default: return 0;
    };
}

int Grid2 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 4: return 1;
        case 3: return 3;
        case 2: return 5;
        default: return 0;
    };
}

int Grid3 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 4: return 2;
        case 2: return 6;
        default: return 0;
    };
}

int Grid4 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 1: return 1;
        case 3: return 5;
        case 2: return 7;
        default: return 0;
    };
}

int Grid5 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 4: return 4;
        case 1: return 2;
        case 3: return 6;
        case 2: return 8;
        default: return 0;
    };
}

int Grid6 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 2: return 9;
        case 4: return 5;
        case 1: return 3;
        default: return 0;
    };
}

int Grid7 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 1: return 4;
        case 3: return 8;
        default: return 0;
    };
}

int Grid8 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 1: return 5;
        case 4: return 7;
        case 3: return 9;
        default: return 0;
    };
}

int Grid9 ( int direction )
{
    switch (direction)
    {
        //1=N 2=S 3=E 4=W
        case 1: return 6;
        case 4: return 8;
        default: return 0;
    };
}