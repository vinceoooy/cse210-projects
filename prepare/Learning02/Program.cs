using System;

class Program
{
    static void Main(string[] args)
     {
        // job instances
        Job job1 = new Job("Software Engineer", "Microsoft", "2019", "2022");
        Job job2 = new Job("Manager", "Apple", "2022", "2023");

        // resume instance
        Resume myResume = new Resume("Allison Rose");

        // Add jobs to the resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display resume details 
        myResume.Display();
    }
}