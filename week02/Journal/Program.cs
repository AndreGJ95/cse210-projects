using System;

class Program
{
    static void Main(string[] args)
    {
        
        Journal myJournal = new Journal();
        PromptGenerator myPromptGenerator = new PromptGenerator();
        
        bool keepRunning = true;

        Console.WriteLine("Welcome to the Journal Program!");

        while (keepRunning)
        {
           
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            
            string choice = Console.ReadLine();

            if (choice == "1")
            {
               
                string prompt = myPromptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {prompt}");
                Console.Write("> ");
                string response = Console.ReadLine();

                Entry currentEntry = new Entry();
                currentEntry._date = DateTime.Now.ToShortDateString();
                currentEntry._promptText = prompt;
                currentEntry._entryText = response;

                myJournal.AddEntry(currentEntry);
            }
            else if (choice == "2")
            {
                Console.WriteLine("\n--- Journal Entries ---");
                myJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                myJournal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                
                if (myJournal._entries.Count == 0)
                {
                    Console.WriteLine("Warning: Your journal is empty. Write something before saving!");
                }
                else
                {
                    Console.Write("What is the filename? ");
                    string filename = Console.ReadLine();
                    myJournal.SaveToFile(filename);
                }
            }
            else if (choice == "5")
            {
                keepRunning = false;
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("That is not a valid option. Try again.");
            }
        }
    }
}