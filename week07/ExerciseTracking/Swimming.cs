// Swimming inherits from the "Activity" class, just like running and cycling
// It incorporates all the features of "Activity" and adds its own logic based on laps
public class Swimming : Activity
{
    // Stores the number of lengths swum, private variable, so accessible only by this class
    private int _laps;

    // Constructor: takes the date, minutes, and number of laps as parameters
    // to initialize the object
    // ": base(date, minutes)" passes the date and minutes to the parent Activity class
    public Swimming(string date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps; // Store the turns in our private variable
    }

    // Calculates the distance swum and converts it to miles
    // Step by step:
    //   _laps * 50.0: total number of meters swum (one lap of a standard pool = 50 meters)
    //   / 1,000: conversion from meters to kilometers
    //   * 0.62: conversion from kilometers to miles
    // for example, 20 laps → 20 × 50 = 1,000 m → 1.0 km → 0.62 miles
    public override double GetDistance()
    {
        return _laps * 50.0 / 1000 * 0.62;
    }

    // Calculates speed in miles per hour
    // GetDistance() returns miles, GetMinutes() returns minutes
    // Dividing these values gives the number of miles per minute; multiplying by 60
    // then converts the result to miles per hour
    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }

    // Calculates the pace: the number of minutes it takes to swim 1 mile
    // Dividing the total number of minutes by the total number of miles gives
    // the number of minutes per mile
    // For example: 40 min ÷ 0.62 mile ≈ 64.5 min per mile
    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}