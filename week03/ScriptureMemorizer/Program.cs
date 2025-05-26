// To exceed requirements the program selects a random scripture from a library of scriptures on each run.
using System;
using ScriptureMemorizer;

class Program
{
    static void Main(string[] args)
    {
        var library = new ScriptureLibrary();
        var scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
                break;

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
                break;

            scripture.HideRandomWords(3);
        }

        Console.WriteLine("\nAll words are hidden. Press any key to exit.");
        Console.ReadKey();
    }
}
