using System;
using System.Collections.Generic;
using System.IO;
public class Goal
{
    protected internal string _shortName; 
    protected internal string _description;
    protected internal int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public virtual void RecordEvent()
    {
        Console.WriteLine($"Congratulations! You have earned {_points}.");   
    }

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual string GetDetailsString()
    {
        return $"{_shortName} ({_description})";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{_shortName},{_description},{_points}";
    }
}