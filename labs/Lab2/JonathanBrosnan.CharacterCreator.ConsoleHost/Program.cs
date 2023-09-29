/*
 Name: Jonathan Brosnan
* ITSE 1430
* Fall 2023
* Lab 1 Final
*/


//add, delete, view, edit

DisplayIntro();
var done = false;

do
{
    ShowMenuDirections();
    switch (ChoosePath())
    {
        //add, delete, view, edit
        //The corresponding 90s values are for when a user enters a direction that is not possible.
        case 1: Console.WriteLine("Add Character"); break;

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

            /*case ConsoleKey.V: return (MoveFromRoom(presentRoom, 2) ? 2 : 92);

            case ConsoleKey.E: return (MoveFromRoom(presentRoom, 3) ? 3 : 93);

            case ConsoleKey.D: return (MoveFromRoom(presentRoom, 4) ? 4 : 94); */

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