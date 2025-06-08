using System;
using System.Collections.Generic;
using System.Linq; // Needed for .ToList()
using System.Threading;

// Derived class for Listing Activity
public class ListingActivity : Activity
{
    private List<string> _allPrompts; // Stores all prompts
    private List<string> _availablePrompts; // Stores prompts not yet used in current session
    private Random _random;
    private int _count;

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _allPrompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _random = new Random();
        _count = 0;

        // Initialize available prompts by copying all prompts
        _availablePrompts = new List<string>(_allPrompts);
    }

    public void Run()
    {
        DisplayStartingMessage();

        // Ensure available prompts are fresh at the start of a new activity run
        if (_availablePrompts.Count == 0)
        {
            _availablePrompts = new List<string>(_allPrompts);
        }

        string prompt = GetRandomPrompt(); // This will now pick from available prompts
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                _count++;
            }
            // The loop's condition (DateTime.Now < endTime) will handle the duration.
            // ReadLine is blocking, so the user has the full remaining time to enter items.
        }

        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        if (_availablePrompts.Count == 0)
        {
            // If all prompts have been used, reset the list
            _availablePrompts = new List<string>(_allPrompts);
        }

        int index = _random.Next(_availablePrompts.Count);
        string prompt = _availablePrompts[index];
        _availablePrompts.RemoveAt(index); // Remove the selected prompt
        return prompt;
    }
}