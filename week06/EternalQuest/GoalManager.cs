public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int Score => _score;
    public List<Goal> Goals => _goals;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int index)
    {
        var goal = _goals[index];
        goal.RecordEvent();

        if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            _score += checklistGoal.Points + checklistGoal.Bonus;
        else if (goal is SimpleGoal simpleGoal && simpleGoal.IsComplete())
            _score += simpleGoal.Points;
        else if (goal is ProgressGoal progressGoal)
            _score += progressGoal.GetTotalPoints();
        else if (goal is NegativeGoal negativeGoal)
            _score -= negativeGoal.GetPenaltyPoints();
        else
            _score += goal.Points;
    }

    public string GetRank()
    {
        if (_score >= 5000) return "Master Seeker";
        else if (_score >= 3000) return "Disciplined Hero";
        else if (_score >= 1500) return "Focused Adventurer";
        else if (_score >= 500) return "Hopeful Learner";
        else return "New Explorer";
    }
} 