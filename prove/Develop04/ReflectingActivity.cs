using System;
using System.Collections.Generic;

class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _usedQuestions = new List<string>(); 
    // For Showing Creativity. I ensure it will not print duplicate 
    // unless all items in the list are used

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power of you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
        
    }

    public void Run()
    {
        DisplayStartingMessage();
        
        Console.WriteLine("\nConsider the following prompt:");
        Thread.Sleep(1000);
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n --- {prompt} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        while (Console.ReadKey().Key != ConsoleKey.Enter)
        {
            Console.WriteLine("\b\bPlease press ENTER to continue...");
        }
        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DisplayQuestions();
        Console.WriteLine();
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);

        // Return the random prompt
        return _prompts[randomIndex];
    }

    private string GetRandomQuestion()
    {
        {
        Random random = new Random();
        int index;

        // Ensure that we have not used all questions
        if (_usedQuestions.Count < _questions.Count)
        {
            do
            {
                index = random.Next(_questions.Count);
            } while (_usedQuestions.Contains(_questions[index]));

            _usedQuestions.Add(_questions[index]);
            return _questions[index];
        }
        else
        {
            // Reset used questions if all questions have been used
            // and then call again to restart the process
            _usedQuestions.Clear();
            return GetRandomQuestion(); 
        }
    }

    }

    private void DisplayQuestions()
    {
        for (int i = 0; i < (_duration/10); i++)
        {
            string randomQuestion = GetRandomQuestion();
            Console.Write($"> {randomQuestion} ");
            ShowSpinner(10);
            Console.WriteLine();
            
        }
    }
}
