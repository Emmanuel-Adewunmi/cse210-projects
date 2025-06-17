using System;

class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, int durationMinutes, double distance)
        : base(date, durationMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (_distance / DurationMinutes) * 60;

    public override double GetPace() => DurationMinutes / _distance;
}
