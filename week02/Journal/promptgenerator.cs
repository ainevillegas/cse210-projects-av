using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What made me smile today?",
        "What is one thing I learned today?"
    };

    private List<string> _usedPrompts = new List<string>();

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        if (_usedPrompts.Count == _prompts.Count)
        {
            _usedPrompts.Clear();
        }

        string prompt;

        do
        {
            int index = _random.Next(_prompts.Count);
            prompt = _prompts[index];
        }
        while (_usedPrompts.Contains(prompt));

        _usedPrompts.Add(prompt);

        return prompt;
    }
}