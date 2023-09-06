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

    string value = Console.ReadLine();

    if (value == "Y" || value == "y")
        return true;
    else if(value == "N" || value == "n")
        return false;

    //TODO: Handle errors
    return false;
}

void DisplayMovie ()
{
    Console.WriteLine(title);
    Console.WriteLine(description);
    Console.WriteLine(length);
    Console.WriteLine(releaseYear);
    Console.WriteLine(genre);
    Console.WriteLine(rating);
    Console.WriteLine(isBlackAndWhite);
    
}

int ReadInt (string message, int minimumValue)
{
    Console.WriteLine(message);
    string value = Console.ReadLine();
    
    int result;
    if (Int32.TryParse(value,out result))
        if (result >= minimumValue)
            return result;
    
    return 0;
}
string ReadString (string message, bool isRequired)
{
    Console.WriteLine(message);
    string value = Console.ReadLine();

    if (!isRequired)
        return value;


    return value;
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