using System;

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

    // You can add more methods or properties here if needed
}

// Class representing the Journal application
class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void WriteNewEntry()
    {
        // Generate a random prompt from the list
        string randomPrompt = GetRandomPrompt();

        // Get user response
        Console.WriteLine(randomPrompt);
        string response = Console.ReadLine();

        // Save the entry
        entries.Add(new JournalEntry(randomPrompt, response, DateTime.Now.ToShortDateString()));
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date} - Prompt: {entry.Prompt}");
            Console.WriteLine(entry.Response);
            Console.WriteLine();
        }
    }

    public void SaveJournalToFile()
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                // Save entry to the file
                outputFile.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }

        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadJournalFromFile()
    {
        Console.Write("Enter the filename to load the journal: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            // Clear existing entries
            entries.Clear();

            // Load entries from the file
            string[] lines = File.ReadAllLines(filename);

            foreach (var line in lines)
            {
                string[] parts = line.Split(",");
                entries.Add(new JournalEntry(parts[1], parts[2], parts[0]));
            }

            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found. Please make sure the filename is correct.");
        }
    }

    private string GetRandomPrompt()
    {
        // Implement logic to get a random prompt from your list of prompts
        // You can use Random class for this
        // ...

        return "Sample Prompt"; // Placeholder, replace with actual random prompt
    }
}

// Main program
class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    journal.WriteNewEntry();
                    break;
                case 2:
                    journal.DisplayJournal();
                    break;
                case 3:
                    journal.SaveJournalToFile();
                    break;
                case 4:
                    journal.LoadJournalFromFile();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}