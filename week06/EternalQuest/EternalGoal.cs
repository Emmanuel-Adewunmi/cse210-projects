public class EternalGoal : Goal
{
    private int _streak;
    private DateTime _lastRecorded;

    public int Streak => _streak;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _streak = 0;
        _lastRecorded = DateTime.MinValue;
    }

    public override void RecordEvent()
    {
        DateTime today = DateTime.Today;
        if ((today - _lastRecorded).Days == 1)
            _streak++;
        else if ((today - _lastRecorded).Days > 1)
            _streak = 1;

        _lastRecorded = today;
    }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return $"[∞] {_shortName} ({_description}) -- Streak: {_streak} days";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{_shortName}|{_description}|{_points}|{_streak}|{_lastRecorded}";
    }
}