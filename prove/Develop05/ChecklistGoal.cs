public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int target, int bonus)
        : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

        public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }

    public override void RecordEvent()
    {
        base.RecordEvent();
        _amountCompleted++;

        if (_amountCompleted == _target)
        {
            Console.WriteLine($"Bonus achieved for completing {_shortName}! +{_bonus} points!");
            _points += _bonus;
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted == _target;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently Completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal,{base.GetStringRepresentation()},{_amountCompleted},{_target},{_bonus}";
    }
}