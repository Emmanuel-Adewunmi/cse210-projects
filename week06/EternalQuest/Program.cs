// To show creativity I did the following:
// - Added streak tracking for EternalGoal to encourage daily habits.
// - Implemented goal deadlines and warnings for missed due dates.
// - Added ProgressGoal for long-term efforts with partial credit and bonus.
// - Introduced NegativeGoal to penalize bad habits (subtracts points).
// - Included a title/rank system based on total score to motivate users.

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        string fileName = "goals.txt";

        Console.WriteLine("Welcome to the Eternal Quest Program!");
        Console.WriteLine($"You have {manager.Score} points.\n");

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Progress");
            Console.WriteLine("4. Show Score & Rank");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Quit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;
                case "2":
                    ListGoals(manager);
                    break;
                case "3":
                    RecordProgress(manager);
                    break;
                case "4":
                    Console.WriteLine($"\nScore: {manager.Score} points");
                    Console.WriteLine($"Rank: {manager.GetRank()}");
                    break;
                case "5":
                    SaveGoals(manager, fileName);
                    Console.WriteLine("Goals saved.");
                    break;
                case "6":
                    LoadGoals(manager, fileName);
                    Console.WriteLine("Goals loaded.");
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        Console.WriteLine("Thanks for using Eternal Quest!");
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nChoose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Progress Goal");
        Console.WriteLine("5. Negative Goal");
        Console.Write("Choice: ");
        string type = Console.ReadLine();

        Console.Write("Enter short name: ");
        string name = Console.ReadLine();

        Console.Write("Enter description: ");
        string desc = Console.ReadLine();

        switch (type)
        {
            case "1":
                Console.Write("Enter points: ");
                int sPoints = int.Parse(Console.ReadLine());
                SimpleGoal sg = new SimpleGoal(name, desc, sPoints);
                manager.AddGoal(sg);
                break;
            case "2":
                Console.Write("Enter points per repetition: ");
                int ePoints = int.Parse(Console.ReadLine());
                EternalGoal eg = new EternalGoal(name, desc, ePoints);
                manager.AddGoal(eg);
                break;
            case "3":
                Console.Write("Points per completion: ");
                int cPoints = int.Parse(Console.ReadLine());
                Console.Write("Target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                ChecklistGoal cg = new ChecklistGoal(name, desc, cPoints, target, bonus);
                manager.AddGoal(cg);
                break;
            case "4":
                Console.Write("Target progress: ");
                int progressTarget = int.Parse(Console.ReadLine());
                Console.Write("Points per increment: ");
                int pPoints = int.Parse(Console.ReadLine());
                Console.Write("Bonus on full completion: ");
                int pBonus = int.Parse(Console.ReadLine());
                ProgressGoal pg = new ProgressGoal(name, desc, progressTarget, pPoints, pBonus);
                manager.AddGoal(pg);
                break;
            case "5":
                Console.Write("Enter penalty points: ");
                int penalty = int.Parse(Console.ReadLine());
                NegativeGoal ng = new NegativeGoal(name, desc, penalty);
                manager.AddGoal(ng);
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    static void ListGoals(GoalManager manager)
    {
        Console.WriteLine("\nYour Goals:");
        int index = 1;
        foreach (var goal in manager.Goals)
        {
            Console.WriteLine($"{index++}. {goal.GetDetailsString()}");
        }
    }

    static void RecordProgress(GoalManager manager)
    {
        ListGoals(manager);
        Console.Write("Select goal number to record progress: ");
        if (int.TryParse(Console.ReadLine(), out int choice) &&
            choice > 0 && choice <= manager.Goals.Count)
        {
            manager.RecordEvent(choice - 1);
            Console.WriteLine("Progress recorded.");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    static void SaveGoals(GoalManager manager, string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine(manager.Score);
            foreach (var goal in manager.Goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    static void LoadGoals(GoalManager manager, string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("No save file found.");
            return;
        }

        manager.Goals.Clear();

        using (StreamReader reader = new StreamReader(fileName))
        {
            int score = int.Parse(reader.ReadLine());
            typeof(GoalManager)
                .GetField("_score", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(manager, score);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                switch (parts[0])
                {
                    case "SimpleGoal":
                        SimpleGoal sg = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                        if (bool.Parse(parts[4])) sg.RecordEvent();
                        manager.AddGoal(sg);
                        break;
                    case "EternalGoal":
                        EternalGoal eg = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                        typeof(EternalGoal).GetField("_streak", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(eg, int.Parse(parts[4]));
                        typeof(EternalGoal).GetField("_lastRecorded", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(eg, DateTime.Parse(parts[5]));
                        manager.AddGoal(eg);
                        break;
                    case "ChecklistGoal":
                        ChecklistGoal cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6]));
                        typeof(ChecklistGoal).GetField("_current", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(cg, int.Parse(parts[4]));
                        manager.AddGoal(cg);
                        break;
                    case "ProgressGoal":
                        ProgressGoal pg = new ProgressGoal(parts[1], parts[2], int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
                        typeof(ProgressGoal).GetField("_currentProgress", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).SetValue(pg, int.Parse(parts[3]));
                        manager.AddGoal(pg);
                        break;
                    case "NegativeGoal":
                        NegativeGoal ng = new NegativeGoal(parts[1], parts[2], int.Parse(parts[3]));
                        manager.AddGoal(ng);
                        break;
                }
            }
        }
    }
}
