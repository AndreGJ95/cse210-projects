using System;

public class BadHabitGoal : Goal
{
    public BadHabitGoal(string name, string description, int penaltyPoints) : base(name, description, penaltyPoints)
    {
    }

    public override void RecordEvent()
    {
        
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[!] {GetShortName()} ({GetDescription()}) -- Penalty: -{GetPoints()} pts";
    }

    public override string GetStringRepresentation()
    {
        return $"BadHabitGoal:{GetShortName()},{GetDescription()},{GetPoints()}";
    }
}