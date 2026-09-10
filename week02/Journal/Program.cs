using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    string prompt = promptGenerator.GetRandomPrompt();

                    Console.WriteLine();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("> ");

                    string answer = Console.ReadLine();

                    Entry entry = new Entry();

                    entry._date = DateTime.Now.ToShortDateString();
                    entry._promptText = prompt;
                    entry._entryText = answer;

                    journal.AddEntry(entry);

                    break;

                case 2:
                    Console.WriteLine();
                    journal.DisplayAll();
                    break;

                case 3:
                    Console.Write("Enter filename: ");
                    string loadFile = Console.ReadLine();

                    try
                    {
                        journal.LoadFromFile(loadFile);
                        Console.WriteLine("Journal loaded successfully.");
                    }
                    catch
                    {
                        Console.WriteLine("Unable to load file.");
                    }

                    break;

                case 4:
                    Console.Write("Enter filename: ");
                    string saveFile = Console.ReadLine();

                    journal.SaveToFile(saveFile);

                    Console.WriteLine("Journal saved successfully.");
                    break;

                case 5:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}