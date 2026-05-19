// ---------------------------- W02 Project: Journal Program ----------------------------
// ---------------------------- Student: John Peter Joseph ----------------------------


// 1. Add two more questions for each journal entry, with a focus on creativity
// 2. Implementing robust file error handling during loading operations
// 3. Displaying the total number of log entries

using System;
using System.IO;
using System.Collections.Generic;
using System.IO.Compression;
using System.Collections;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your name before continuing: ");
        string name = Console.ReadLine();
        Console.WriteLine($"Welcome {name}!");

        Console.WriteLine("This program is designed to help you get to know yourself better.");
        Console.WriteLine($"Have a good trip!");

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following options:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");

            Console.Write("Your choice?: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                string question = promptGenerator.GetRandomPrompt();

                Console.WriteLine();
                Console.WriteLine(question);
                string response = Console.ReadLine();

                Console.WriteLine("> How are you feeling today? ");
                string minsdet = Console.ReadLine();

                Console.WriteLine("> Why do you feel that way? ");
                string reason = Console.ReadLine();

                DateTime currentTime = DateTime.Now;

                string aboutDate = currentTime.ToShortDateString();

                Entry newEntry = new Entry();

                newEntry._date = aboutDate;
                newEntry._promptText = question;
                newEntry._entryText = response;
                newEntry._stateOfMind = minsdet;
                newEntry._reason = reason;


                journal.AddEntry(newEntry);

                Console.WriteLine();
                Console.WriteLine("Entry added successfully!");

            }

            else if (choice == 2)
            {
                Console.WriteLine();
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("What is the filename? ");
                string file = Console.ReadLine();
                journal.SaveToFile(file);
            }

            else if (choice == 4)
            {
                Console.Write("> What is the filename? ");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);
            }

            else if (choice == 5)
            {
                Console.WriteLine($"Goodbye {name}!");
                Console.WriteLine("I hope to see you again!");
            }

            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}