// To exceed core requirements I have added a mood tracking feature that stores the user's mood upon each journal entry and a writing streak tracker that tracks how many consecutive days the user has written entries //
using System;

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int streak = LoadStreak();
        DateTime lastEntryDate = LoadLastEntryDate();

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
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    Console.Write("Your mood today: ");
                    string mood = Console.ReadLine();

                    Entry newEntry = new Entry
                    {
                        _date = DateTime.Now.ToShortDateString(),
                        _prompt = prompt,
                        _response = response,
                        _mood = mood
                    };

                    myJournal.AddEntry(newEntry);

                    // Update streak
                    DateTime today = DateTime.Today;
                    if ((today - lastEntryDate).Days == 1)
                        streak++;
                    else if ((today - lastEntryDate).Days > 1)
                        streak = 1;

                    SaveStreak(streak);
                    SaveLastEntryDate(today);
                    lastEntryDate = today;

                    Console.WriteLine($"🔥 Writing Streak: {streak} day(s)!");
                    break;

                case "2":
                    myJournal.DisplayJournal();
                    break;

                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    myJournal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
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

    static int LoadStreak()
    {
        if (File.Exists("streak.txt"))
        {
            string[] data = File.ReadAllLines("streak.txt");
            return int.Parse(data[0]);
        }
        return 0;
    }

    static void SaveStreak(int streak)
    {
        File.WriteAllText("streak.txt", streak.ToString());
    }

    static DateTime LoadLastEntryDate()
    {
        if (File.Exists("lastDate.txt"))
        {
            string dateStr = File.ReadAllText("lastDate.txt");
            return DateTime.Parse(dateStr);
        }
        return DateTime.MinValue;
    }

    static void SaveLastEntryDate(DateTime date)
    {
        File.WriteAllText("lastDate.txt", date.ToShortDateString());
    }
}