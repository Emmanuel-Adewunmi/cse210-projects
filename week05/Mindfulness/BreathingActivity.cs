using System;
using System.Threading;

// Derived class for Breathing Activity
public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(4); // Breathe in for 4 seconds
            Console.WriteLine();

            if (DateTime.Now >= endTime) break; // Check if duration is met after breathing in

            Console.WriteLine("Breathe out...");
            ShowCountDown(6); // Breathe out for 6 seconds
            Console.WriteLine();
            Console.Clear(); // Clear the console for the next cycle
        }

        DisplayEndingMessage();
    }
}