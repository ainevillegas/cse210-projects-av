using System;
using System.Collections.Generic;

// =====================================================
// EXCEEDS REQUIREMENTS
//
// 1. Multiple scriptures are stored in a collection.
// 2. A scripture is randomly selected each time
//    the program runs.
// 3. Only words that are not already hidden are
//    selected for hiding.
// 4. Progress is displayed showing the number
//    of words hidden.
// 5. A random number of words (2-4) are hidden
//    each round.
// =====================================================

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son"),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding"),

            new Scripture(
                new Reference("Mosiah", 2, 17),
                "When ye are in the service of your fellow beings ye are only in the service of your God"),

            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me")
        };

        Random random = new Random();

        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            Console.WriteLine(
                $"Progress: {scripture.GetHiddenWordCount()}/{scripture.GetTotalWordCount()} words hidden");

            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit': ");

            string input = Console.ReadLine() ?? "";

            if (input.Trim().ToLower() == "quit")
            {
                return;
            }

            int wordsToHide = random.Next(2, 5);

            scripture.HideRandomWords(wordsToHide);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        Console.WriteLine();
        Console.WriteLine("Congratulations! All words are hidden.");
    }
}