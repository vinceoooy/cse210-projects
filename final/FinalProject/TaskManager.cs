// TaskManager class to manage _tasks, _users, and _categories
public class TaskManager
{
    private List<Task> _tasks;
    private List<User> _users;
    private List<Category> _categories;

    public TaskManager()
    {
        _tasks = new List<Task>();
        _users = new List<User>();
        _categories = new List<Category>();
    }

    public void AddTask(Task task)
    {
        _tasks.Add(task);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void AddCategory(Category category)
    {
        _categories.Add(category);
    }

    // Example method to display all _tasks with details
    public void DisplayAllTasks()
    {
        foreach (var task in _tasks)
        {
            task.DisplayDetails(); // Using polymorphism to display details based on the actual object type
        }
    }
}