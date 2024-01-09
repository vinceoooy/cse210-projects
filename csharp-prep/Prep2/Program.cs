using System;

class Program
{
    static void Main(string[] args)
    {


        Console.Write("What is your grade in percentage? ");
        int grade = int.Parse(Console.ReadLine());

        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }


        // Stretch Challenge
        int lastDigit = grade % 10;
        string sign = "";
        
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }

        if (letter == "A" && sign == "+")
        {
            letter = "A";
            sign = "";
        }
        else if (letter == "F" && sign != "")
        {
            letter = "F";
            sign = "";
        }

        Console.WriteLine($"Your grade is: {letter}{sign}");


        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You've passed");
        }
        else 
        {
            Console.WriteLine("Let's do better next time");
        }

    }
}

