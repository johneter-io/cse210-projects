using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    // Holds all goals the player has created during this session
    private List<Goal> _goals;

    // Tracks the player's total score accumulated across all recorded events
    private int _score;

    // The file used to persist goals between sessions
    private const string FILENAME = "goals.txt";

    public GoalManager()
    {
        // Start with an empty goal list and zero score on every new instance
        _goals = new List<Goal>();
        _score = 0;
    }

    // Entry point: loads saved data, then runs the main menu loop until the player quits
    public void Start()
    {
        LoadGoals();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\n---------- ETERNAL QUEST ----------");
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Goals");
            Console.WriteLine("2. Create New Goal");
            Console.WriteLine("3. Record Goal Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Quit");
            Console.Write("\nSelect a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ListGoalDetails();
                    break;
                case "2":
                    CreateGoal();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    SaveGoals();
                    Console.WriteLine("Goals saved successfully!");
                    break;
                case "5":
                    Console.WriteLine("Thank you for using Eternal Quest!");
                    // Setting running to false exits the loop cleanly instead of using Environment.Exit()
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Displays the player's current score at the top of every menu screen
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYour Score: {_score}");
    }

    // Shows a compact goal list — used inside RecordEvent() so the player can pick by number
    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals yet. Create one to get started!");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];

            // Show [X] if the goal is complete, [ ] if it's still in progress
            string status = goal.IsComplete() ? "[X]" : "[ ]";

            // Checklist goals get an extra progress counter (e.g. "Completed 3/5 times")
            if (goal is ChecklistGoal checklistGoal)
            {
                // Display checklist goal with name, status, and how many times it's been completed vs the target
                Console.WriteLine($"{i + 1}. {status} {goal.GetShortName()} (Completed {checklistGoal.GetAmountCompleted()}/{checklistGoal.GetTarget()} times)");
            }
            else
            {
                Console.WriteLine($"{i + 1}. {status} {goal.GetShortName()}");
            }
        }
    }

    // Shows full details for every goal — used for menu option 1
    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goal has been set yet. Create one to get started!");
            return;
        }

        Console.WriteLine("\n========== GOAL DETAILS ==========");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];

            // Show [X] if the goal is complete, [ ] if still in progress
            string status = goal.IsComplete() ? "[X]" : "[ ]";

            Console.WriteLine($"\n{i + 1}. {status} {goal.GetShortName()}");
            Console.WriteLine($"   Description: {goal.GetDescription()}");
            Console.WriteLine($"   Points: {goal.GetPoints()}");

            // Only checklist goals have a progress counter worth displaying
            if (goal is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"   Progress: {checklistGoal.GetAmountCompleted()}/{checklistGoal.GetTarget()} completed");
            }
        }
    }

    // Prompts the player to choose a goal type, collects input, and adds it to the list
    public void CreateGoal()
    {
        Console.WriteLine("\n========== CREATE NEW GOAL ==========");
        Console.WriteLine("What kind of goal would you like to set?");
        Console.WriteLine("1. Simple goal (to be completed once)");
        Console.WriteLine("2. Eternal Goal (on an endless loop)");
        Console.WriteLine("3. Goals Checklist (to be completed multiple times)");
        Console.Write("Select goal type (1-3): ");

        string type = Console.ReadLine();

        // Collect the fields shared by all goal types before branching
        Console.Write("Enter a short name for this goal: ");
        string name = Console.ReadLine();

        Console.Write("What is its description?: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points awarded for this goal: ");
        string points = Console.ReadLine();

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
            Console.WriteLine("Simple goal created!");
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
            Console.WriteLine("Eternal goal created!");
        }
        else if (type == "3")
        {
            // Checklist goals need two extra values: how many times to complete, and a one-time bonus
            Console.Write("Enter the number of achievements you want: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Enter the bonus points earned for reaching the goal: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
            Console.WriteLine("Goals checklist created!");
        }
        else
        {
            Console.WriteLine("Sorry! Invalid choice.");
        }
    }

    // Records that a goal was achieved, adds points to the score, and checks for a checklist completion bonus
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals to save. Create a goal first!");
            return;
        }

        ListGoalNames();
        Console.Write("\nWhat goal have you achieved? Enter a number: ");

        // int.TryParse prevents a crash if the player types something that isn't a number
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            // Convert 1-based player input to 0-based list index
            Goal goal = _goals[index - 1];

            // Points are stored as a string to match the constructor — parse here for arithmetic
            int points = int.Parse(goal.GetPoints());

            goal.RecordEvent();
            _score += points;

            Console.WriteLine($"Congratulations! You've earned {points} points!");

            // The bonus is only awarded once, exactly when the checklist target is fully reached
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                int bonus = checklistGoal.GetBonus();
                _score += bonus;
                Console.WriteLine($"Congratulations! You've completed the goal! You earn a bonus of {bonus} points!");
            }

            Console.WriteLine($"Your total score is: {_score}");
        }
        else
        {
            Console.WriteLine("Sorry! Invalid selection.");
        }
    }

    // Writes the score and all goals to disk so the player's progress survives between sessions
    public void SaveGoals()
    {
        try
        {
            // 'using' ensures the file is properly closed even if an error occurs mid-write
            using (StreamWriter writer = new StreamWriter(FILENAME))
            {
                // Score goes on line 1 so LoadGoals() can read it separately before the goal lines
                writer.WriteLine(_score);

                // Each goal serializes itself — the format must match what LoadGoals() expects
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Sorry! Error saving goals: {e.Message}");
        }
    }

    // Reads saved goals from disk and fully restores the player's previous session state
    public void LoadGoals()
    {
        try
        {
            // No file means this is the first run — skip loading silently
            if (!File.Exists(FILENAME))
            {
                return;
            }

            using (StreamReader reader = new StreamReader(FILENAME))
            {
                // First line is always the score saved by SaveGoals()
                string line = reader.ReadLine();
                if (line != null)
                {
                    _score = int.Parse(line);
                }

                // Every remaining line is one saved goal
                while ((line = reader.ReadLine()) != null)
                {
                    // Fields are separated by '|' — must match the format in GetStringRepresentation()
                    string[] parts = line.Split('|');
                    if (parts.Length > 0)
                    {
                        string goalType = parts[0];

                        if (goalType == "SimpleGoal")
                        {
                            // parts[4] holds the isComplete flag saved by SimpleGoal
                            bool isComplete = bool.Parse(parts[4]);
                            SimpleGoal goal = new SimpleGoal(parts[1], parts[2], parts[3]);

                            // Re-complete the goal if it was already done when the player last saved
                            if (isComplete)
                            {
                                goal.RecordEvent();
                            }
                            _goals.Add(goal);
                        }
                        else if (goalType == "EternalGoal")
                        {
                            // Eternal goals never complete, so no extra state needs restoring
                            EternalGoal goal = new EternalGoal(parts[1], parts[2], parts[3]);
                            _goals.Add(goal);
                        }
                        else if (goalType == "ChecklistGoal")
                        {
                            int amountCompleted = int.Parse(parts[4]);
                            int target = int.Parse(parts[5]);
                            int bonus = int.Parse(parts[6]);
                            ChecklistGoal goal = new ChecklistGoal(parts[1], parts[2], parts[3], target, bonus);

                            // Replay each past recording to restore the internal counter accurately
                            for (int i = 0; i < amountCompleted; i++)
                            {
                                goal.RecordEvent();
                            }

                            _goals.Add(goal);
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Sorry! Error loading goals: {e.Message}");
        }
    }
}