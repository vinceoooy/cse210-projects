using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            numbers.Add(input);
        } while (input != 0);

        numbers.Remove(0); // Remove the last 0 from the list

        int sum = numbers.Sum();
        double average = numbers.Average();
        int max = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        // Stretch Challenge
        var positiveNumbers = numbers.Where(n => n > 0).ToList();
        int smallestPositive = positiveNumbers.Any() ? positiveNumbers.Min() : 0;
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}