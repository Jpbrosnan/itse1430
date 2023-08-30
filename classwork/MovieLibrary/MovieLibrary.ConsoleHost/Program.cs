//Get MOVIE
//Title,genre, decription,rating
// Length, release year, budget
//isBlackAndWhite
//Operations: Add, edit, view, delete

string title = "", genre = "", description = "", rating = "";

int length = 0, releaseYear = 1900;
    
decimal budget = 125.45M;

bool isBlackAndWhite = false;


Console.WriteLine("Enter a title: ");
title = Console.ReadLine();

Console.WriteLine("Enter a description: ");
description = Console.ReadLine();


//TODO: Fix length
Console.WriteLine("Enter the run length in minutes: ");
string lengthString = Console.ReadLine();
Console.WriteLine(title);
Console.WriteLine(description);
Console.WriteLine(lengthString);


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