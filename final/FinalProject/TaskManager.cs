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
