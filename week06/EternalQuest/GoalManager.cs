using System;
using System.Collections.Generic;
using System.IO;

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
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine();
            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                choice = 0;
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;

                case 2:
                    ListGoalDetails();
                    break;

                case 3:
                    SaveGoals();
                    break;

                case 4:
                    LoadGoals();
                    break;

                case 5:
                    RecordEvent();
                    break;

                case 6:
                    Console.WriteLine();
                    Console.WriteLine(
                        "Thank you for using Eternal Quest!");
                    break;

                default:
                    Console.WriteLine(
                        "Please select a number from 1 to 6.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Current level: {GetPlayerLevel()}");
    }

    private string GetPlayerLevel()
    {
        if (_score >= 5000)
        {
            return "Level 5 - Eternal Champion";
        }
        else if (_score >= 3000)
        {
            return "Level 4 - Quest Master";
        }
        else if (_score >= 1500)
        {
            return "Level 3 - Goal Warrior";
        }
        else if (_score >= 500)
        {
            return "Level 2 - Rising Adventurer";
        }
        else
        {
            return "Level 1 - Beginner";
        }
    }

    public void ListGoalNames()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        if (!int.TryParse(Console.ReadLine(), out int goalType))
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        if (goalType < 1 || goalType > 3)
        {
            Console.WriteLine("Please select a goal type from 1 to 3.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string shortName = Console.ReadLine() ?? "";

        Console.Write(
            "What is a short description of your goal? ");
        string description = Console.ReadLine() ?? "";

        Console.Write(
            "What is the number of points associated with this goal? ");

        if (!int.TryParse(Console.ReadLine(), out int points) ||
            points < 0)
        {
            Console.WriteLine(
                "Points must be a valid non-negative number.");
            return;
        }

        if (goalType == 1)
        {
            Goal goal = new SimpleGoal(
                shortName,
                description,
                points);

            _goals.Add(goal);
            Console.WriteLine("Simple goal created successfully.");
        }
        else if (goalType == 2)
        {
            Goal goal = new EternalGoal(
                shortName,
                description,
                points);

            _goals.Add(goal);
            Console.WriteLine("Eternal goal created successfully.");
        }
        else
        {
            Console.Write(
                "How many times does this goal need to be completed? ");

            if (!int.TryParse(
                    Console.ReadLine(),
                    out int target) ||
                target <= 0)
            {
                Console.WriteLine(
                    "The target must be greater than zero.");
                return;
            }

            Console.Write(
                "What is the bonus for completing the checklist? ");

            if (!int.TryParse(
                    Console.ReadLine(),
                    out int bonus) ||
                bonus < 0)
            {
                Console.WriteLine(
                    "The bonus must be a valid non-negative number.");
                return;
            }

            Goal goal = new ChecklistGoal(
                shortName,
                description,
                points,
                target,
                bonus);

            _goals.Add(goal);
            Console.WriteLine("Checklist goal created successfully.");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine(
                "There are no goals available to record.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("The goals are:");
        ListGoalNames();

        Console.Write(
            "Which goal did you accomplish? ");

        if (!int.TryParse(
                Console.ReadLine(),
                out int goalNumber))
        {
            Console.WriteLine("Please enter a valid goal number.");
            return;
        }

        int goalIndex = goalNumber - 1;

        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("That goal does not exist.");
            return;
        }

        Goal selectedGoal = _goals[goalIndex];

        if (selectedGoal.IsComplete())
        {
            Console.WriteLine(
                "This goal is already complete.");
            return;
        }

        int earnedPoints = selectedGoal.RecordEvent();
        _score += earnedPoints;

        Console.WriteLine();
        Console.WriteLine(
            $"Congratulations! You earned {earnedPoints} points!");
        Console.WriteLine(
            $"You now have {_score} points.");

        if (selectedGoal.IsComplete())
        {
            Console.WriteLine(
                "Excellent! This goal is now complete!");
        }

        Console.WriteLine(
            $"Your current level is: {GetPlayerLevel()}");
    }

    public void SaveGoals()
    {
        Console.WriteLine();
        Console.Write(
            "What is the filename for the goal file? ");

        string filename = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("The filename cannot be empty.");
            return;
        }

        try
        {
            using (StreamWriter outputFile =
                   new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(
                        goal.GetStringRepresentation());
                }
            }

            Console.WriteLine(
                "Your goals were saved successfully.");
        }
        catch (Exception exception)
        {
            Console.WriteLine(
                $"Unable to save the goals: {exception.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.WriteLine();
        Console.Write(
            "What is the filename for the goal file? ");

        string filename = Console.ReadLine() ?? "";

        if (!File.Exists(filename))
        {
            Console.WriteLine("The specified file was not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0)
            {
                Console.WriteLine("The selected file is empty.");
                return;
            }

            if (!int.TryParse(lines[0], out int loadedScore))
            {
                Console.WriteLine(
                    "The score in the file is invalid.");
                return;
            }

            List<Goal> loadedGoals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                Goal? loadedGoal = CreateGoalFromLine(lines[i]);

                if (loadedGoal != null)
                {
                    loadedGoals.Add(loadedGoal);
                }
            }

            _score = loadedScore;
            _goals = loadedGoals;

            Console.WriteLine(
                "Your goals were loaded successfully.");
        }
        catch (Exception exception)
        {
            Console.WriteLine(
                $"Unable to load the goals: {exception.Message}");
        }
    }

    private Goal? CreateGoalFromLine(string line)
    {
        string[] parts = line.Split('|');

        if (parts.Length == 0)
        {
            return null;
        }

        string goalType = parts[0];

        if (goalType == "SimpleGoal" && parts.Length == 5)
        {
            string shortName = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            bool isComplete = bool.Parse(parts[4]);

            return new SimpleGoal(
                shortName,
                description,
                points,
                isComplete);
        }

        if (goalType == "EternalGoal" && parts.Length == 4)
        {
            string shortName = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            return new EternalGoal(
                shortName,
                description,
                points);
        }

        if (goalType == "ChecklistGoal" &&
            parts.Length == 7)
        {
            string shortName = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            int bonus = int.Parse(parts[4]);
            int target = int.Parse(parts[5]);
            int amountCompleted = int.Parse(parts[6]);

            return new ChecklistGoal(
                shortName,
                description,
                points,
                target,
                bonus,
                amountCompleted);
        }

        return null;
    }
}