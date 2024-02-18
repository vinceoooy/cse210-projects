using System;
using System.Collections.Generic;

// Task class to represent individual tasks
public class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }

    public Task(string title, string description, DateTime dueDate, int priority)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        Priority = priority;
    }
}

// User class to represent users of the task management system
public class User
{
    public string Username { get; set; }

    public User(string username)
    {
        Username = username;
    }
}

// Category class to categorize tasks
public class Category
{
    public string Name { get; set; }

    public Category(string name)
    {
        Name = name;
    }
}

// TaskManager class to manage tasks, users, and categories
public class TaskManager
{
    private List<Task> tasks;
    private List<User> users;
    private List<Category> categories;

    public TaskManager()
    {
        tasks = new List<Task>();
        users = new List<User>();
        categories = new List<Category>();
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void AddCategory(Category category)
    {
        categories.Add(category);
    }

    // Example method to display all tasks with details
    public void DisplayAllTasks()
    {
        foreach (var task in tasks)
        {
            Console.WriteLine($"Title: {task.Title}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Due Date: {task.DueDate}");
            Console.WriteLine($"Priority: {task.Priority}");
            Console.WriteLine("---------------");
        }
    }
}

class Program
{
    static void Main()
    {
        // Creating instances for demonstration
        TaskManager taskManager = new TaskManager();
        User user1 = new User("JohnDoe");
        Category personalCategory = new Category("Personal");

        taskManager.AddUser(user1);
        taskManager.AddCategory(personalCategory);

        Task task1 = new Task("Complete Assignment", "Finish the programming assignment", DateTime.Now.AddDays(3), 1);
        Task task2 = new Task("Go to the Gym", "Work out for an hour", DateTime.Now.AddDays(5), 2);

        taskManager.AddTask(task1);
        taskManager.AddTask(task2);

        // Displaying all tasks
        taskManager.DisplayAllTasks();
    }
}
