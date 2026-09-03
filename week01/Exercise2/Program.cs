using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();

        int grade = int.Parse(input);

        string letter = "";
        string sign = "";

        // Determine the letter grade
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

        // Determine the sign (+ or -)
        int lastDigit = grade % 10;

        if (letter != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // No A+
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }

        // No F+ or F-
        if (letter == "F")
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is {letter}{sign}.");

        // Pass/Fail Message
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Don't give up. Keep working hard and try again next time.");
        }
    }
}