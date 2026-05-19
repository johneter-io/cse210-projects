using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _stateOfMind;
    public string _reason;

    public void Display()
    {
        Console.WriteLine($"> Date: {_date}");
        Console.WriteLine($"Question: {_promptText}");
        Console.WriteLine($"Your answer: {_entryText}");
        Console.WriteLine("========================================");
        Console.WriteLine($"How I feel today: {_stateOfMind}");
        Console.WriteLine($"Reason: {_reason}");
        Console.WriteLine();

    }
}