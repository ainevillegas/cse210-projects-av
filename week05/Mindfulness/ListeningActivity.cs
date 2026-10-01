using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you reflect on the good things " +
            "in your life by having you list as many things as you can.")
    {
        _count = 0;

        _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine();
        Console.WriteLine("List as many responses as you can:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();

        Console.Write("You may begin in: ");
        ShowCountDown(5);

        List<string> responses = GetListFromUser();

        _count = responses.Count;

        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items.");

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);

        return _prompts[index];
    }

    public List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();

        Console.Write("Enter one response: ");
        string response = Console.ReadLine();

        responses.Add(response);

        return responses;
    }
}