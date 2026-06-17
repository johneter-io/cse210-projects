// These "using" statements import the built-in C# libraries we need
using System;                   // Displays “Console.WriteLine”
using System.Collections.Generic; // Gives us a list <>

class Program
{
    // The "Main" function is the ENTRY POINT: this is where the program begins to run
    // "string[] args" allows you to pass arguments from
    // the command line (we don't use them here)
    static void Main(string[] args)
    {

        // Create a list that can contain any type of activity
        // The <Activity> list is also suitable for running, cycling, and swimming
        // because they all INHERIT from the Activity interface (they are activities)
        List<Activity> activities = new List<Activity>();

        // Add three different activity objects to the list
        // Each “new” creates a new object with its own data
        activities.Add(new Running("03 Nov 2022", 30, 3.0));   // date, minutes, distance
        activities.Add(new Cycling("04 Nov 2022", 45, 12.0));  // date, minutes, speed
        activities.Add(new Swimming("05 Nov 2022", 40, 20));   // date, minutes, laps

        // Iterate through all the activities in the list one by one
        // "Activity activity" means: each item is temporarily referred to as "activity"
        foreach (Activity activity in activities)
        {
            // Call the GetSummary() method for each activity and display the result
            // Even though they are different types, C# knows which version
            // of GetSummary() to use for each one. Tthis is called POLYMORPHISM
            Console.WriteLine(activity.GetSummary());
        }
    }
}