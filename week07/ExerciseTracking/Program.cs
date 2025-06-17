using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 09, 11), 30, 3.0),
            new Cycling(new DateTime(2024, 09, 11), 30, 12.0),
            new Swimming(new DateTime(2024, 09, 11), 30, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}