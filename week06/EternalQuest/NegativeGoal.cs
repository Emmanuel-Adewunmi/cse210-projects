public class NegativeGoal : Goal
{
    private int _penaltyPoints;

    public NegativeGoal(string name, string description, int penaltyPoints)
        : base(name, description, 0)
    {
        _penaltyPoints = penaltyPoints;
    }

    public int GetPenaltyPoints() => _penaltyPoints;

    public override void RecordEvent() { }

    public override bool IsComplete() => false;

    public override string GetDetailsString()
    {
        return $"[!] {_shortName} ({_description}) -- Lose {_penaltyPoints} pts when triggered";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal|{_shortName}|{_description}|{_penaltyPoints}";
    }
}