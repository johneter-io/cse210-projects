using System;

// Represents a one-time goal that is permanently marked complete after being recorded once
// Example use case: "Run a marathon" or "Read the entire Book of Mormon"
public class SimpleGoal : Goal
{
    // Tracks whether the goal has been completed — starts false, becomes true permanently after RecordEvent()
    private bool _isComplete;

    // Delegates name, description, and points to the base Goal class, then initializes completion state
    public SimpleGoal(string name, string description, string points) : base(name, description, points)
    {
        _isComplete = false; // Not complete until the player explicitly records the event
    }

    // Marks the goal as done — once set to true, RecordEvent() has no further effect
    public override void RecordEvent()
    {
        _isComplete = true;
    }

    // Returns the current completion state — used by GoalManager to show [X] or [ ] in the list
    public override bool IsComplete()
    {
        return _isComplete;
    }

    // Includes _isComplete in the save string so LoadGoals() can restore the completed state on reload
    public override string GetDetailsString()
    {
        // Format: name|description|points|isComplete
        // parts[4] in LoadGoals() reads _isComplete to decide whether to call RecordEvent() again
        return $"{GetShortName()}|{GetDescription()}|{GetPoints()}|{_isComplete}";
    }

    // Prepends the class type so LoadGoals() knows to reconstruct a SimpleGoal, not another subclass
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{GetDetailsString()}";
    }
}