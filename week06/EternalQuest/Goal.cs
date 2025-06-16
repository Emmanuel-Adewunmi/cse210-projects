public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;
    protected DateTime? _deadline;

    public string ShortName => _shortName;
    public string Description => _description;
    public int Points => _points;
    public DateTime? Deadline => _deadline;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public void SetDeadline(DateTime deadline)
    {
        _deadline = deadline;
    }

    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}