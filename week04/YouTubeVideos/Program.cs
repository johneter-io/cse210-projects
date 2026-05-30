using System;

class Program
{
    static void Main(string[] args)
    {
        // create the videos
        Video video1 = new Video("Learn C# in an hour", "CodeAcademy", 3600);
        Video video2 = new Video("OOP Explained", "TechGuru", 1200);
        Video video3 = new Video("Python vs C#", "DevWorld", 900);

        // add comments
        video1.AddComment(new Comment("John", "Very helpful, thank you!"));
        video1.AddComment(new Comment("Michelle", "Finally, a clear tutorial."));
        video1.AddComment(new Comment("Jack", "I recommend it to everyone."));

        video2.AddComment(new Comment("Anna", "I think object-oriented programming is explained very well."));
        video2.AddComment(new Comment("Jean", "I swear, it's the best thing on the Internet."));
        video2.AddComment(new Comment("Lucy", "Thank you for the content."));

        video3.AddComment(new Comment("Sarah", "C# is faster!"));
        video3.AddComment(new Comment("Johnson", "Python is still simpler."));
        video3.AddComment(new Comment("Steve", "A good, objective comparison."));

        // add to a list
        List<Video> videos = new List<Video>() { video1, video2, video3 };


        // display video
        foreach (Video video in videos)
        {
            video.DisplayInfo();            // just one line
            Console.WriteLine();
        }
    }
}