using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
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