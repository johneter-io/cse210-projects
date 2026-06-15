using System;

// Represents a goal that rewards points every time it's recorded but never gets "completed"
// Example use case: daily habits like exercising or reading scripture
public class EternalGoal : Goal
{
    // No extra fields needed — name, description, and points are handled entirely by the base Goal class
    public EternalGoal(string name, string description, string points) : base(name, description, points)
    {
    }

    // Recording an eternal goal does nothing to its state — points are awarded by GoalManager, not here
    public override void RecordEvent()
    {
        // Intentionally empty: eternal goals have no completion counter to increment
    }

    // Always returns false because eternal goals are designed to never be marked as done
    public override bool IsComplete()
    {
        return false;
    }

    // Builds the save string — only 3 fields needed since there's no progress state to store
    public override string GetDetailsString()
    {
        // Format: name|description|points
        // Simpler than ChecklistGoal because eternal goals have no counter or bonus
        return $"{GetShortName()}|{GetDescription()}|{GetPoints()}";
    }

    // Prepends the class type so LoadGoals() knows to reconstruct an EternalGoal, not another subclass
    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{GetDetailsString()}";
    }
}