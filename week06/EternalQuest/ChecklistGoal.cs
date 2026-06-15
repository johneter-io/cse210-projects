using System;

// Represents a goal that must be completed a set number of times to earn a bonus
public class ChecklistGoal : Goal
{
    // How many times the player has recorded this goal so far
    private int _amountCompleted;

    // The total number of times required to fully complete this goal
    private int _target;

    // Extra points awarded once when the player hits the target
    private int _bonus;

    // Calls the base Goal constructor to set name, description, and points, then initializes checklist-specific fields
    public ChecklistGoal(string name, string description, string points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0; // Always starts at zero — no progress on creation
        _target = target;
        _bonus = bonus;
    }

    // Increments the completion counter only if the target hasn't been reached yet
    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
        }
        // If already at target, do nothing — prevents over-counting beyond the goal
    }

    // Returns true when the player has completed the goal the required number of times
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }

    public int GetTarget()
    {
        return _target;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    // Builds the data string for this goal's fields — used by GetStringRepresentation() and display methods
    public override string GetDetailsString()
    {
        // Format: name|description|points|amountCompleted|target|bonus
        // Order must match exactly what LoadGoals() expects when parsing parts[]
        return $"{GetShortName()}|{GetDescription()}|{GetPoints()}|{_amountCompleted}|{_target}|{_bonus}";
    }

    // Prepends the class type so LoadGoals() knows which Goal subclass to reconstruct
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{GetDetailsString()}";
    }
}