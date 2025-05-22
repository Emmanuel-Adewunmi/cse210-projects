using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private int _streak = 0;
    private DateTime _lastEntryDate = DateTime.MinValue;

    public void WriteEntry(PromptGenerator promptGen)
    {
        string prompt = promptGen.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();
        Console.Write("Your mood today: ");
        string mood = Console.ReadLine();

        Entry entry = new Entry
        {
            Date = DateTime.Now.ToShortDateString(),
            Prompt = prompt,
            Response = response,
            Mood = mood
        };

        AddEntry(entry);

        DateTime today = DateTime.Today;
        if ((_lastEntryDate != DateTime.MinValue) && (today - _lastEntryDate).Days == 1)
            _streak++;
        else
            _streak = 1;

        _lastEntryDate = today;

        SaveStreak();
        SaveLastEntryDate();

        Console.WriteLine($"\n🔥 Writing Streak: {_streak} day(s)!");
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayJournal()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries yet.");
            return;
        }

        Console.WriteLine("\nJournal Entries:\n");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileFormat());
            }
        }
        Console.WriteLine("Journal successfully saved.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        foreach (string line in File.ReadAllLines(filename))
        {
            Entry entry = Entry.FromFileFormat(line);
            _entries.Add(entry);
        }
        Console.WriteLine("Journal successfully loaded.");
    }

    public void SaveStreak()
    {
        File.WriteAllText("streak.txt", _streak.ToString());
    }

    public void LoadStreak()
    {
        if (File.Exists("streak.txt"))
        {
            _streak = int.Parse(File.ReadAllText("streak.txt"));
        }
    }

    public void SaveLastEntryDate()
    {
        File.WriteAllText("lastDate.txt", _lastEntryDate.ToShortDateString());
    }

    public void LoadLastEntryDate()
    {
        if (File.Exists("lastDate.txt"))
        {
            _lastEntryDate = DateTime.Parse(File.ReadAllText("lastDate.txt"));
        }
    }
}
