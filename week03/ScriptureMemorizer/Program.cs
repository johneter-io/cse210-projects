// ---------------------------- W03 Project: Scripture Memorizer Program ----------------------------
// ---------------------------- Student: John Peter Joseph ----------------------------
// ---------------------------- Course: CSE 210: Programming with Classes ----------------------------

// I added a welcome message after asking the user for their name, just to show a little creativity

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine($"Welcome to this program {name}.");
        Console.WriteLine("It was designed to help you memorize a Bible verse in a fun way");
        Console.WriteLine("We hope you like it!");
        Console.WriteLine();

        Console.WriteLine("Here is the verse:");
        Reference reference = new Reference("Psalms", 16, 5);
        string text = "The Lord is the portion of mine inheritance and of my cup: thou maintainest my lot.";

        Scripture scripture = new Scripture(reference, text);

        string userInput = "";

        // The main part of the program
        while (userInput != "quit")
        {
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            userInput = Console.ReadLine();

            if (userInput != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }
    }
}