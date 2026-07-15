using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Writing library
        List<Scripture> scriptureLibrary = new List<Scripture>();

        scriptureLibrary.Add(new Scripture(
            new Reference("John", 3, 16), 
            "For God so loved the world that he gave his only Son"
        ));

        scriptureLibrary.Add(new Scripture(
            new Reference("Proverbs", 3, 5, 6), 
            "Trust in the Lord with all your heart and lean not on your own understanding"
        ));

        scriptureLibrary.Add(new Scripture(
            new Reference("Joshua", 1, 9), 
            "Be strong and courageous Do not be afraid do not be discouraged"
        ));

        scriptureLibrary.Add(new Scripture(
            new Reference("Philippians", 4, 13), 
            "I can do all things through Christ who strengthens me"
        ));

       // We choose a random script
        Random random = new Random();
        int randomIndex = random.Next(scriptureLibrary.Count);
        Scripture activeScripture = scriptureLibrary[randomIndex];

        // The game cycle
        while (true)
        {
            // We cleaned the console to give the effect of words disappearing.
            Console.Clear();

            Console.WriteLine(activeScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue, or type 'quit' to finish:");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            if (activeScripture.IsCompletelyHidden())
            {
                break;
            }

            activeScripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(activeScripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Congratulations! You have hidden the entire scripture.");
    }
}