// This class represents a cycling activity.
// The colon ": Activity" means that Cycling INHERITS from Activity
// (it includes all the features of Activity, while adding its own)
public class Cycling : Activity
{

    // A private variable to store the bike speed (in mph or km/h)
    // "Private" means that only THIS class can access it directly
    private double _speed;

    // This is the CONSTRUCTOR: it runs automatically when you create a new Cycling object
    // It takes three pieces of information as parameters:
    // the date, the duration of your ride, and your speed
    // ": base(date, minutes)" passes the date and minutes to
    // the parent Activity class so it can process them
    public Cycling(string date, int minutes, double speed)
        : base(date, minutes)
    {
        _speed = speed; // Store the speed in our private variable
    }

    // Calculates the distance traveled during the trip
    // "override" means that we are replacing the version of
    // this method from the parent Activity class
    // Formula: Distance = Speed × Time, but since minutes are not the
    // same as hours, we divide by 60
    public override double GetDistance()
    {
        return (_speed * GetMinutes()) / 60; // for example, 15 mph × 30 min ÷ 60 = 7.5 miles
    }

    // Simply returns the speed that was passed in when the object was created
    // Another "override", which replaces the version in the parent class
    public override double GetSpeed()
    {
        return _speed;
    }

    // Calculates pace: the number of minutes it takes to travel 1 mile/km
    // This is the INVERSE of speed: a low speed corresponds to a fast pace
    // For example, 15 mph → 60 ÷ 15 = 4 minutes per mile
    public override double GetPace()
    {
        return 60 / _speed;
    }
}