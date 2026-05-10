using System;

class Program
{
    static void Main(string[] args)
    {
        // if, else if, elif statements
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");

        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed!");
            Console.WriteLine("Your efforts have paid off!");
        }
        else
        {
            Console.WriteLine("Sorry! Better luck next time!");
            Console.WriteLine("Work smarter and you'll succeed!");
        }
    }
}