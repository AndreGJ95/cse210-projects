// EXCEEDING REQUIREMENTS:
// 1. Added input validation to prevent crashes when setting session duration.
// 2. Added dynamic time checking inside the ListingActivity input loop to ensure strict adherence to the requested duration.
// 3. Implemented a session counter tracking system that displays total completed mindfulness activities when exiting the program.

using System;

class Program
{
    static void Main(string[] args)
    {
        int totalActivities = 0;
        string choice = "";

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
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
                totalActivities++;
            }
            else if (choice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
                totalActivities++;
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
                totalActivities++;
            }
        }

        Console.Clear();
        Console.WriteLine($"Thank you for using the Mindfulness Program!");
        Console.WriteLine($"You completed a total of {totalActivities} session(s) today. Have a great day!");
    }
}