class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing. \nNOTE: each cycle lasts 8 seconds")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Write("Start\n\n");
        Thread.Sleep(1000);

        //For Creativity I added a more meaningfull animation for breathing
        for (int i = 0; i < (_duration / 8); i++)
        {
            Console.Write("Breathe in...");
            ShowGrowingBar(20); //animations for breathing in (growing bar)
            Console.WriteLine();
            Console.Write("Now breathe out...");
            ShowShrinkingBar(20); //animations for breathing out (shrinking bar)
            Console.WriteLine("\n");
        }

    DisplayEndingMessage();
    }
    private void ShowGrowingBar(int barLength)
    // This method shows a growing bar
    {
        int initialCursorLeft = Console.CursorLeft;
        int initialCursorTop = Console.CursorTop;

        for (int j = 1; j <= barLength; j++)
        {
            Console.SetCursorPosition(initialCursorLeft, initialCursorTop);
            Console.Write($"[{new string('|', j)}{new string(' ', barLength - j)}]{(j/5) + 1}");
            Thread.Sleep(200);
            Console.SetCursorPosition(initialCursorLeft, initialCursorTop); 

        }
        Console.WriteLine();
    }
    
    private void ShowShrinkingBar(int barLength)
    // This method shows a shrinking bar
    {
        int initialCursorLeft = Console.CursorLeft;
        int initialCursorTop = Console.CursorTop;

        for (int j = barLength; j > 0; j--)
        {
            Console.SetCursorPosition(initialCursorLeft, initialCursorTop);
            Console.Write($"[{new string('|', j)}{new string(' ', barLength - j)}]{(j/5) + 1}");
            Thread.Sleep(200);
            Console.SetCursorPosition(initialCursorLeft, initialCursorTop);
        }
        Console.WriteLine();
    }
}
