
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        DisplayMenu();
    }

    private void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine($"\nYou have {_score} points.");
            Console.WriteLine("\nMenu Opions:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Redeem Points");
            Console.WriteLine("  7. Exit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":                   
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    RedeemPoints();
                    break;
                case "7":
                    Console.WriteLine("Exiting Eternal Quest. Goodbye!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                    break;
            }
        }
    }

    private void RedeemPoints()
    {
        Console.WriteLine($"You currently have {_score} points.");

        int pointsToRedeem = 100;

        // Check if there are enough points to redeem for a 2-hour nap
        if (_score >= pointsToRedeem)
        {
            Console.Write($"You can redeem {pointsToRedeem} points for a 2-hour nap. Do you want to proceed? (yes/no): ");

            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "yes")
            {
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("---- You deserve a rest, praise yourself for your effort ----");
                Console.WriteLine("------------- Go ahead and enjoy your 2-hour nap! -----------");
                Console.WriteLine("-------------------------------------------------------------");
                // Deduct points for the nap
                _score -= pointsToRedeem;

                Console.WriteLine($"You now have {_score} points remaining.");

            }
            else
            {
                Console.WriteLine("Nap redemption canceled.");
            }
        }
        else
        {
            Console.WriteLine("Sorry, as for now your point(s) is not enough.");
        }
    }

    private void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Goal goal = _goals[i];
            Console.WriteLine($"{i + 1}. {goal._shortName} ({goal._description})");
        }
    }

    private void ListGoalDetails()
    {
        int goalindex = 1;
        Console.WriteLine("\nThe goals are:");
        foreach (Goal goal in _goals)
        {
            string checkbox = " ";
            if(goal.IsComplete() == true)
            {
               checkbox = "X";
            }
            Console.WriteLine($"{goalindex}. [{checkbox}] {goal.GetDetailsString()}");
            goalindex ++;
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string goalType = Console.ReadLine().ToLower();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = Convert.ToInt32(Console.ReadLine());

        switch (goalType)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = Convert.ToInt32(Console.ReadLine());

                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = Convert.ToInt32(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid choice. Please enter a number between 1 - 3.");
                break;
        }
    }

    private void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int selectedGoalNumber) && selectedGoalNumber >= 1 && selectedGoalNumber <= _goals.Count)
        {
            Goal selectedGoal = _goals[selectedGoalNumber - 1];
            selectedGoal.RecordEvent();
            _score += selectedGoal._points;
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid goal number.");
        }
    }

    private void SaveGoals()
    {

        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }


    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine(); // Use the provided filename
        if (File.Exists(filename))
        {
            using (StreamReader reader = new StreamReader(filename))
            {
               string firstLine = reader.ReadLine(); 
               _score = Convert.ToInt32(firstLine);    
            }
            string[] goalLines = File.ReadAllLines(filename);

            // Skip the first line as it contains the total number of goals
            for (int i = 1; i < goalLines.Length; i++)
            {
                string goalLine = goalLines[i];
                string[] parts = goalLine.Split(",");
                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = Convert.ToInt32(parts[3]);

                Goal goal;

                switch (type.ToLower())
                {
                    case "simplegoal":
                        bool isCompleted = Convert.ToBoolean(parts[4]);

                        // Create a SimpleGoal object without calling the constructor
                        goal = new SimpleGoal(name, description, points)
                        {
                            // Set the completion status using the RecordEvent method
                            _isComplete = isCompleted
                        };
                        break;
                    case "eternalgoal":
                        goal = new EternalGoal(name, description, points);
                        break;
                    case "checklistgoal":
                        int amountCompleted = Convert.ToInt32(parts[4]);
                        int target = Convert.ToInt32(parts[5]);
                        int bonus = Convert.ToInt32(parts[6]);

                        ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                        checklistGoal.SetAmountCompleted(amountCompleted);
                        goal = checklistGoal;
                        break;
                    default:
                        continue; // Skip invalid lines
                }

                _goals.Add(goal);
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine($"File '{filename}' not found.");
        }
    }
}