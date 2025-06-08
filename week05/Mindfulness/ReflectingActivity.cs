using System;
using System.Collections.Generic;
using System.Linq; // Needed for .ToList()
using System.Threading;

// Derived class for Reflecting Activity
public class ReflectingActivity : Activity
{
    private List<string> _allPrompts; // Stores all prompts
    private List<string> _availablePrompts; // Stores prompts not yet used in current session
    private List<string> _allQuestions; // Stores all questions
    private List<string> _availableQuestions; // Stores questions not yet used in current session
    private Random _random;

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _allPrompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _allQuestions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        _random = new Random();

        // Initialize available lists by copying all prompts/questions
        _availablePrompts = new List<string>(_allPrompts);
        _availableQuestions = new List<string>(_allQuestions);
    }

    public void Run()
    {
        DisplayStartingMessage();

        // Ensure available lists are fresh at the start of a new activity run
        if (_availablePrompts.Count == 0)
        {
            _availablePrompts = new List<string>(_allPrompts);
        }
        if (_availableQuestions.Count == 0)
        {
            _availableQuestions = new List<string>(_allQuestions);
        }

        string prompt = GetRandomPrompt(); // This will now pick from available prompts
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("When you have thought about this, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion(); // This will now pick from available questions
            Console.WriteLine($"> {question}");
            ShowSpinner(5); // Pause for 5 seconds after each question
            Console.WriteLine(); // New line after spinner
            if (DateTime.Now >= endTime) break; // Check if duration is met
        }

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

    private string GetRandomQuestion()
    {
        if (_availableQuestions.Count == 0)
        {
            // If all questions have been used, reset the list
            _availableQuestions = new List<string>(_allQuestions);
        }

        int index = _random.Next(_availableQuestions.Count);
        string question = _availableQuestions[index];
        _availableQuestions.RemoveAt(index); // Remove the selected question
        return question;
    }
}