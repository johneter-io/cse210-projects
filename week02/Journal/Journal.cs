using System;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine($"Sorry, there are {_entries.Count} entries in your journal.");
            Console.WriteLine("Please, add an entry!");
        }
        else
        {
            Console.WriteLine($"You have {_entries.Count} in your journal.");
            Console.WriteLine();

            foreach (Entry entry in _entries)
                entry.Display();
        }
    }

    public void SaveToFile(string file)
    {

        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}|{entry._stateOfMind}|{entry._reason}");
            }
        }
    }

    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            string[] lines = System.IO.File.ReadAllLines(file);

            _entries.Clear();

            foreach (string line in lines)
            {
                string[] parts = line.Split("|");

                Entry entry = new Entry();

                entry._date = parts[0];
                entry._promptText = parts[1];
                entry._entryText = parts[2];
                entry._stateOfMind = parts[3];
                entry._reason = parts[4];

                _entries.Add(entry);
            }

            Console.WriteLine("Your file has been successfully loaded.");
        }
        else
        {
            Console.WriteLine("Sorry, file not found!");
            Console.WriteLine("Please enter the “3” number if you would like to save your file!");
        }
    }
}