// Task class to represent individual tasks
public class Task : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }

    public Task(string name, string description, DateTime dueDate, int priority)
    : base(name) // Using the base class constructor explicitly
    {
    Title = name;
    Description = description;
    DueDate = dueDate;
    Priority = priority;
    }

    // Override the DisplayDetails method to include task-specific details
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Due Date: {DueDate}");
        Console.WriteLine($"Priority: {Priority}");
        Console.WriteLine("---------------");
    }
}