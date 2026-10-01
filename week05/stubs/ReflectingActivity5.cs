using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;

    public ReflectingActivity()
        : base(
            "Reflecting",
            "This activity will help you reflect on times in your life " +
            "when you have shown strength and resilience.")
    {
        _prompts = new List<string>()
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What did you learn about yourself?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();
        DisplayPrompt();
        DisplayQuestions();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);

        return _questions[index];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();

        Console.WriteLine(
            "When you have something in mind, press Enter to continue.");

        Console.ReadLine();
    }

    public void DisplayQuestions()
    {
        Console.WriteLine("Now reflect on the following question:");
        Console.WriteLine();

        Console.WriteLine(GetRandomQuestion());
        ShowSpinner(5);
    }
}