// Running is included in this activity, as are cycling and swimming
// This is actually the simplest of the three: the distance is given directly,
// so no conversion is necessary
public class Running : Activity
{
    // Stores the distance traveled in miles; this variable is private,
    // so only this class can access it
    private double _distance;

    // Constructor: takes the date, minutes, and distance as parameters to initialize the object
    // ": base(date, minutes)" passes the date and minutes to the parent Activity class
    public Running(string date, int minutes, double distance)
        : base(date, minutes)
    {
        _distance = distance; // Save the distance into our private variable
    }

    // Simply returns the distance provided—no calculations needed!
    // Unlike swimming, where you had to convert lengths to meters,
    // then to kilometers, and finally to miles,
    // running accepts the distance directly in miles
    public override double GetDistance()
    {
        return _distance;
    }

    // Calculates speed in miles per hour
    // _distance ÷ GetMinutes() gives the number of miles per minute
    // × 60 converts this value to miles per hour
    // For example: 3.0 miles ÷ 30 min × 60 = 6.0 mph
    public override double GetSpeed()
    {
        return (_distance / GetMinutes()) * 60;
    }

    // Calculates the pace, or the number of minutes it takes to run 1 mile
    // For example: 30 min ÷ 3.0 miles = 10.0 min per mile
    public override double GetPace()
    {
        return GetMinutes() / _distance;
    }
}