//Get MOVIE
//Title,genre, decription,rating
// Length, release year, budget
//isBlackAndWhite
//Operations: Add, edit, view, delete

string title = "", genre = "", description = "", rating = "";

int length = 0, releaseYear = 1900;

decimal budget = 125.45M;

bool isBlackAndWhite = false;


//Entry Point
var done = false;
do
{
    //var command = DisplayMenu();

    switch (DisplayMenu())
    {
        case 1: AddMovie();
            break;
        case 2: EditMovie();
            break;
        case 3: DeleteMovie();
            break;
        case 4: ViewMovie();
            break;
        case 0: done = true;
            break;
        default: Console.WriteLine("Unknown Option");
            break;

    };/*
    if (command == 1)
        AddMovie();
    else if (command == 2)
        EditMovie();
    else if (command == 3)
        DeleteMovie();
    else if (command == 4)
        ViewMovie();
    else if (command == 0)
        done = true;
    */
} while (!done);




//Functions
void AddMovie ()
{
    title = ReadString("Enter a title: ",true);
    description = ReadString("Enter a description: ",false);
    //TODO: Fix length
    length = ReadInt("Enter the run length in minutes: ",0);
    releaseYear = ReadInt("Enter the release year:", 1900);

    genre = ReadString("Enter the genre: ",false);
    rating = ReadRating("Enter the rating: ");
    isBlackAndWhite = ReadBoolean("Black and White (Y/N): ");
}

void EditMovie()
{
    Console.WriteLine("Not Imp.");
}
void DeleteMovie ()
{
    if (!Confirm("Are you sure you want to delete the movie?(Y/N)"))
        return;
    Console.WriteLine("Movie Deleted!");
}

bool Confirm(string message)
{
    return ReadBoolean(message);
}

bool ReadBoolean (string message)
{
    Console.WriteLine(message);

    while (true)
    {
   
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.Y: return true;
            case ConsoleKey.N: return false;
        };

        //Console.WriteLine("Please enter Y/N");
    };
 
    
}

int DisplayMenu ()
{
    Console.WriteLine("----------------");
    Console.WriteLine("A)dd Movie");
    Console.WriteLine("E)dit Movie");
    Console.WriteLine("D)elete Movie");
    Console.WriteLine("V)iew Movie");
    Console.WriteLine("Q)uit");

    do
    {   /*
        var input = Console.ReadLine();
        if (input == "A" || input == "a")
            return 1;
        else if (input == "E" || input == "e")
            return 2;
        else if (input == "D" || input == "d")
            return 3;
        else if (input == "V" || input == "v")
            return 4;
        else if (input == "Q" || input == "q")
            return 0;
        */

        switch (Console.ReadKey(true).Key)
        {
           
            case ConsoleKey.A: return 1;
            case ConsoleKey.E: return 2;
            case ConsoleKey.D: return 3;
            case ConsoleKey.V: return 4;
            case ConsoleKey.Q: return 0;
           
           


        };
    }while(true);
}

void ViewMovie ()
{

    Console.WriteLine("\n------------------------");
    Console.WriteLine("\nThe title is " + title);
    Console.WriteLine("Description: " + description);
    Console.WriteLine("The movie length is " + length + " mins");
    Console.WriteLine("The release year is " + releaseYear);
    Console.WriteLine("The genre is " + genre);
    Console.WriteLine("The MPAA rating is " + rating);

    Console.WriteLine(isBlackAndWhite ? "The movie is black and white." : "The movie is not black and white.");
    /*
    if (isBlackAndWhite)
    {
        Console.WriteLine("The movie is black and white.");
    
   } else
    {
        Console.WriteLine("The movie is not black and white.");
    }
  */
    //filepath = @"C:\windows\temp"
}

int ReadInt (string message, int minimumValue)
{
    Console.WriteLine(message);

    do {
        string value = Console.ReadLine();

        if (Int32.TryParse(value, out var result))
            if (result >= minimumValue)
                return result;

        Console.WriteLine("Value must be at least " + minimumValue);
    } while(true);
    
    
}
string ReadString (string message, bool isRequired)
{
    Console.WriteLine(message);
    do
    {
        string value = Console.ReadLine();

        if (!isRequired || !String.IsNullOrEmpty(value))
            return value;


        Console.WriteLine("Value is required!");
    } while (true);
   
}


string ReadRating ( string message )
{
    Console.WriteLine(message);
    do
    {
        string value = Console.ReadLine();

        if (value == "PG")
            return "PG";
        else if (value == "G")
            return "G";
        else if (value == "PG-13")
            return "PG-13";
        else if (value == "R")
            return "R";
        else if (String.IsNullOrEmpty(value)) //String.Empty //String.IsNullOrEmpty()
            return "";

        Console.WriteLine("Invalid Rating");
    } while (true);

}
/*
double ex1 = 3.14159;

char letterGrade = 'A';

{
    int hours = 5;
    title = "Jaws";
    Console.WriteLine(title);
    Console.WriteLine(length);


}
*/