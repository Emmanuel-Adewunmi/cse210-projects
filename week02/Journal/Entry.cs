using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _mood;

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }

    public string ToFileFormat()
    {
        return $"{_date}|{_mood}|{_prompt}|{_response}";
    }

    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        return new Entry
        {
            _date = parts[0],
            _mood = parts[1],
            _prompt = parts[2],
            _response = parts[3]
        };
    }
}
