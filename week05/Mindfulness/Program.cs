// ---------------------------- W05 Project: Mindfulness Program ----------------------------
// ---------------------------- Student: John Peter Joseph ----------------------------
// ---------------------------- Course: CSE 210: Programming with Classes ----------------------------


using System;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Before we get started, what is your name? ");
        string name = Console.ReadLine();
        Console.WriteLine($"Welcome {name} to the Mindfulness Project.");
        Console.WriteLine();

        string choice = "";

        while (choice != "4")
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
            }
            else if (choice == "2")
            {
                ReflectingActivity activity = new ReflectingActivity();
                activity.Run();
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
            }
            else if (choice != "4")
            {
                Console.WriteLine("Oops! Invalid choice. Please enter 1, 2, 3, or 4.");
            }
        }

        Console.WriteLine($"\nIt was a pleasure having you here, {name}. Goodbye!");
    }
}