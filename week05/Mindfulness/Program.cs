using System;

class Program
{
    static void Main(string[] args)
    {
        /*
         * EXCEEDING REQUIREMENTS:
         *
         * 1. The program keeps track of the number of mindfulness
         *    activities completed during the current session.
         *
         * 2. The program validates the duration so the user cannot
         *    enter zero, a negative number, or non-numeric text.
         *
         * 3. The Reflecting Activity avoids repeating a question
         *    until all available questions have been used.
         */

        string choice = "";
        int completedActivities = 0;

        while (choice != "4")
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");

            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathingActivity =
                    new BreathingActivity();

                breathingActivity.Run();
                completedActivities++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflectingActivity =
                    new ReflectingActivity();

                reflectingActivity.Run();
                completedActivities++;
            }
            else if (choice == "3")
            {
                ListingActivity listingActivity =
                    new ListingActivity();

                listingActivity.Run();
                completedActivities++;
            }
            else if (choice == "4")
            {
                Console.Clear();

                Console.WriteLine(
                    $"You completed {completedActivities} mindfulness " +
                    "activities during this session.");

                Console.WriteLine();
                Console.WriteLine(
                    "Thank you for using the Mindfulness Program.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine(
                    "Invalid choice. Please select a number from 1 to 4.");
            }

            if (choice != "4")
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}