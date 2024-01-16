using System;
using System.Collections.Generic;
using System.IO;

// Main 
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            string input = Console.ReadLine();

            // Showing Creativity and Exceeding Requirements.
            // some problem that will keep people from writing 
            // Is that they typed an incorrect option, either
            // Out of bounds or not an integer

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        journal.WriteNewEntry();
                        break;
                    case 2:
                        journal.DisplayJournal();
                        break;
                    case 3:
                        journal.LoadJournalFromFile();
                        break;
                    case 4:
                        journal.SaveJournalToFile();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}


// A class models the responsibilities of an entry
class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public JournalEntry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}

// A class models the responsibilities of a journal
class Journal
{
    private List<JournalEntry> _entries;

    public Journal()
    {
        _entries = new List<JournalEntry>();
    }

    public void WriteNewEntry()
    {
        // Generate a random prompt from the list
        string randomPrompt = GetRandomPrompt();

        // Get user response
        Console.WriteLine(randomPrompt);
        string response = Console.ReadLine();

        // Save the entry
        _entries.Add(new JournalEntry(randomPrompt, response, DateTime.Now.ToShortDateString()));
    }

    public void DisplayJournal()
    {
        //Iterate through all entries in the journal and display them to the screen.
        foreach (var entry in _entries)
        {
            Console.WriteLine($"Date: {entry.Date} - Prompt: {entry.Prompt}");
            Console.WriteLine(entry.Response);
            Console.WriteLine();
        }
    }

    public void LoadJournalFromFile()
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            //While loading file, existing entries will clear
            _entries.Clear();

            // Load entries from the file
            string[] lines = File.ReadAllLines(filename);

            // reading variables that are comma separated
            foreach (var line in lines)
            {
                string[] parts = line.Split(",");
                _entries.Add(new JournalEntry(parts[1], parts[2], parts[0]));
            }

            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found. Please make sure the filename is correct.");
        }
    }

    public void SaveJournalToFile()
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();

        // Showing Creativity and Exceeding Requirements
        // If journal is saved to comma-separated values (.csv) and (.txt)
        // commas in responds is replace with semicolons ";"
        if (filename.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (var entry in _entries)
                {
                    // Saving entry to the file
                    outputFile.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response.Replace(",", ";")}");
                }
            }
        }
        else if (filename.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (var entry in _entries)
                {
                    // Saving entry to the file
                    outputFile.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response.Replace(",", ";")}");
                }
            }
        }
        else
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (var entry in _entries)
                {
                    // Save entry to the file
                    outputFile.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
                }
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    private string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            // example prompts
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",

            // own additional prompts 
            "What did you eat?",
            "Describe yourself in 3 words",
            "What am I grateful for today",
            "What emotions did you experience today, and why?",
            "What did you accomplish today?",
            "Recall a special moment from the past week and capture it in detail.",
        };

        Random listNumber = new Random();
        int randomIndex = listNumber.Next(prompts.Count);

        return prompts[randomIndex];
    }
}