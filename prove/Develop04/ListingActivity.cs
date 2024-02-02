using System;
using System.Collections.Generic;
using System.Diagnostics;

class ListingActivity : Activity
{
    private List<string> _prompts;
    private string filePath = "MyList.txt";
    // For Creativity I save the user input to a .txt file

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }
    
    public void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($" --- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        List<string> items = GetListFromUser();

        Console.WriteLine($"You listed {items.Count} items.\n");

        DisplayEndingMessage();
    }
    private string GetRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);

        // Return the random prompt
        return _prompts[randomIndex];
    }

    private List<string> GetListFromUser()
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        List<string> items = new List<string>();

        while (stopwatch.Elapsed.TotalSeconds < _duration)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            items.Add(input);
        }

        File.AppendAllLines(filePath, items);
        return items;
    }
}
