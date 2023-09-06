//Get MOVIE
//Title,genre, decription,rating
// Length, release year, budget
//isBlackAndWhite
//Operations: Add, edit, view, delete

string title = "", genre = "", description = "", rating = "";

int length = 0, releaseYear = 1900;

decimal budget = 125.45M;

bool isBlackAndWhite = false;


getMovie();
DisplayMovie();


//Functions
void getMovie ()
{
    title = ReadString("Enter a title: ",true);
    description = ReadString("Enter a description: ",false);
    //TODO: Fix length
    length = ReadInt("Enter the run length in minutes: ",0);
    releaseYear = ReadInt("Enter the release year:", 1900);

    genre = ReadString("Enter the genre: ",false);
    rating = ReadString("Enter the rating: ", false);
    isBlackAndWhite = ReadBoolean("Black and White (Y/N): ");
}

bool ReadBoolean (string message)
{
    Console.WriteLine(message);

    while (true)
    {
        var value = Console.ReadLine();
        if (value == "Y" || value == "y")
            return true;
        else if (value == "N" || value == "n")
            return false;

        Console.WriteLine("Please enter Y/N");
    };
 
    
}

void DisplayMovie ()
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

        if (!isRequired || value != "")
            return value;


        Console.WriteLine("Value is required!");
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