using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

            bool playing = true;
            do // Loop entire code
            {
                Console.WriteLine(); // creates a blank line
                Console.WriteLine("I'm thinking of a magic number between 1 and 100.");

                int randNum = random.Next(1, 101);
                Console.WriteLine();

                
                int count = 0;
                bool correct = false;

                do // wrong guess
                {
                    Console.Write("What is your guess? ");
                    count++;
                    int guess = int.Parse(Console.ReadLine());
                    
                    // Stretch Challenge
                    if (guess == randNum)
                    {
                        Console.WriteLine($"You guessed it in {count} tries!!");
                        correct = true;
                    }
                    else if (guess > randNum)
                    {
                        Console.WriteLine("Lower");
                        correct = false;
                    }
                    else if (guess < randNum)
                    {
                        Console.WriteLine("Higher");
                        correct = false;
                    }
                } while (!correct); //wrong number input


                // Stretch Challenge
                bool playResponse = false;
                do
                {
                    Console.Write("Would you like to play again? (Yes or No): ");
                    string playAgain = Console.ReadLine();
                    if (playAgain.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                    {
                        playing = true;
                        playResponse = true;
                    }
                    else if (playAgain.Equals("No", StringComparison.OrdinalIgnoreCase))
                    {
                        playing = false;
                        playResponse = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Response! Please answer with a 'Yes' or 'No'");
                        playResponse = false;
                    }
                } while (!playResponse); //wrong input for Yes or No

            } while (playing); //play again
    }
}