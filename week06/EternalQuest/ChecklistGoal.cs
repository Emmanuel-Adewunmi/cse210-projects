public class ChecklistGoal : Goal
{
    private int _target;
    private int _current;
    private int _bonus;

    public int Bonus => _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _current = 0;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        if (_current < _target) _current++;
    }

    public override bool IsComplete() => _current >= _target;

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description}) -- Completed {_current}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_current}|{_target}|{_bonus}";
    }
}
