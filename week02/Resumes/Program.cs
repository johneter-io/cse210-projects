using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._jobCompany = "Facebbok";
        job1._startYear = 2013;
        job1._endYear = 2018;

        Job job2 = new Job();
        job2._jobTitle = "Graphic Design";
        job2._jobCompany = "X";
        job2._startYear = 2019;
        job2._endYear = 2022;

        Resume myResume = new Resume();
        myResume._name = "Avril Langlois";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();

    }
}



