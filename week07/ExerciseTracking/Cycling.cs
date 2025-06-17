using System;

class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, int durationMinutes, double speed)
        : base(date, durationMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * DurationMinutes) / 60;

    public override double GetSpeed() => _speed;

    public override double GetPace() => 60 / _speed;
}
