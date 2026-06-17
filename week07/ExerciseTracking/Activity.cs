// "abstract" means that this class is a MODEL: you can never
// directly create an instance of Activity
// (using "new Activity()" is not allowed).
// It exists solely to be inherited by the Running, Cycling, Swimming, etc., classes
public abstract class Activity
{
    // Private fields: only this class can access them directly
    private string _date;    // Records the date of the activity
    private int _minutes;    // Records the duration of the activity

    // Constructor: records the date and minutes when a derived class is created
    // Derived classes call it using ": base(date, minutes)"
    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }
    // Simple getter: allows other classes to READ the date without modifying it
    public string GetDate()
    {
        return _date;
    }

    // Simple getter: allows other classes to READ the duration without modifying it
    public int GetMinutes()
    {
        return _minutes;
    }

    // "Abstract" methods do NOT have a body here, they are PROMISES
    // Each derived class (Running, Cycling, Swimming) MUST provide its own version
    // Each activity calculates distance differently,
    // so it makes sense to let them handle it themselves
    public abstract double GetDistance();

    // Same principle: speed is calculated differently depending on the type of activity
    public abstract double GetSpeed();

    // Same principle: the pace is calculated differently depending on the type of activity
    public abstract double GetPace();

    // "virtual" means that this method HAS a default version here, BUT that derived classes
    // are ALLOWED to override it with their own version if they wish
    // (unlike "abstract," which REQUIRES them to override it)
    public virtual string GetSummary()
    {
        // This method generates and returns a formatted summary string using all the other methods
        // GetType().Name automatically retrieves the class name (e.g., "Running," "Cycling")
        // so you don't have to enter it manually
        // The ":0.0" after each value formats the number with one decimal place (e.g., 3.0, 12.5)
        return $"{_date} {GetType().Name} ({_minutes} min): " +
               $"Distance {GetDistance():0.0} miles, " +   // Calls the child's GetDistance()
               $"Speed {GetSpeed():0.0} mph, " +            // Calls the child's GetSpeed()
               $"Pace: {GetPace():0.0} min per mile";       // Calls the child's GetPace()
    }
}