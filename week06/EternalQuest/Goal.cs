using System;

// Base class for all goal types (SimpleGoal, EternalGoal, ChecklistGoal)
// Holds shared fields and defines the virtual methods each subclass must override
public class Goal
{
    // The short display name shown in the goal list (e.g. "Run a marathon")
    private string _shortName;

    // A longer explanation of what the goal involves
    private string _description;

    // Stored as string to match user input directly — subclasses parse it to int when doing arithmetic
    private string _points;

    // Initializes the three fields common to every goal type
    public Goal(string name, string description, string points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public string GetShortName()
    {
        return _shortName;
    }

    public string GetDescription()
    {
        return _description;
    }

    public string GetPoints()
    {
        return _points;
    }

    // Virtual so each subclass can define what "recording" means for its goal type
    // Base implementation is intentionally empty — Goal itself has no behavior
    public virtual void RecordEvent()
    {
    }

    // Default returns false — subclasses override this to reflect their own completion logic
    // SimpleGoal returns _isComplete, ChecklistGoal compares counter vs target, EternalGoal always returns false
    public virtual bool IsComplete()
    {
        return false;
    }

    // Builds a pipe-separated string of this goal's core fields — subclasses extend this with their own fields
    public virtual string GetDetailsString()
    {
        // Format: name|description|points
        return $"{_shortName}|{_description}|{_points}";
    }

    // Returns the full save string including the class type prefix — subclasses must override this
    // Base returns empty string as a safe fallback; GoalManager calls this when writing to file
    public virtual string GetStringRepresentation()
    {
        return "";
    }
}