public class ProgressGoal : Goal
{
    private int _currentProgress;
    private int _targetProgress;
    private int _incrementPoints;
    private int _bonusPoints;

    public ProgressGoal(string name, string description, int target, int incrementPoints, int bonusPoints)
        : base(name, description, 0)
    {
        _currentProgress = 0;
        _targetProgress = target;
        _incrementPoints = incrementPoints;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        _currentProgress++;
    }

    public override bool IsComplete() => _currentProgress >= _targetProgress;

    public int GetTotalPoints()
    {
        return IsComplete() ? _incrementPoints + _bonusPoints : _incrementPoints;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {_shortName} ({_description}) -- Progress: {_currentProgress}/{_targetProgress}";
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressGoal|{_shortName}|{_description}|{_currentProgress}|{_targetProgress}|{_incrementPoints}|{_bonusPoints}";
    }
}