// To exceed core requirements, this program includes a mood tracking feature and a writing streak tracker. These features are implemented cleanly within the Journal class, ensuring clear abstraction and separation of concerns.
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        myJournal.LoadStreak();
        myJournal.LoadLastEntryDate();

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    myJournal.WriteEntry(promptGenerator);
                    break;
                case "2":
                    myJournal.DisplayJournal();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(saveFile))
                    {
                        Console.WriteLine("Filename cannot be empty.");
                        break;
                    }
                    myJournal.SaveToFile(saveFile);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(loadFile))
                    {
                        Console.WriteLine("Filename cannot be empty.");
                        break;
                    }
                    myJournal.LoadFromFile(loadFile);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}