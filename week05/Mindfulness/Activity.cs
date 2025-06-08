using System;
using System.Collections.Generic;
using System.Threading;

// Base class for all activities
public class Activity
{
    private string _name;
    private string _description;
    protected int _duration; // Protected to be accessible by derived classes

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        string input = Console.ReadLine();
        while (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            Console.Write("Invalid input. Please enter a positive number for the duration: ");
            input = Console.ReadLine();
        }
        Console.Clear();
        Console.WriteLine("Get ready to begin...");
        ShowSpinner(5); // Pause for 5 seconds
        Console.Clear();
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3); // Pause for 3 seconds
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(5); // Pause for 5 seconds
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = spinner[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b"); // Erase the character
            i = (i + 1) % spinner.Count;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Erase the character
            if (i > 1 && i < 10) // Only erase one more backspace if it's a two-digit number
            {
                // This condition makes sure we correctly erase single digit numbers (e.g. 9 to 8)
                // and for multi-digit numbers, it just overwrites.
                // The current implementation of \b \b already handles erasing correctly.
            }
        }
    }
}