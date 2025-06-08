using System;
using System.Threading;

// Main program class
public class Program
{
    public static void Main(string[] args)
    {
        // To exceed core requirements, the ReflectingActivity and ListingActivity
        // have been enhanced to ensure that no random prompts or questions
        // are selected until all available ones have been used at least once
        // within a single session. This provides a richer and more varied
        // experience for the user during each activity.

        string choice = "";
        do
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case "2":
                    ReflectingActivity reflectingActivity = new ReflectingActivity();
                    reflectingActivity.Run();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case "4":
                    Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Thread.Sleep(2000); // Pause to show error message
                    break;
            }

        } while (choice != "4");
    }
}