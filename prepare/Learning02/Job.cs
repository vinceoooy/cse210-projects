using System;

public class Job
{
    // Member variables
    public string _jobTitle;
    public string _company;
    public string _startDate;
    public string _endDate;

    // Constructor
    public Job(string jobTitle, string company, string startDate, string endDate)
    {
        _jobTitle = jobTitle;
        _company = company;
        _startDate = startDate;
        _endDate = endDate;
    }

    // Display 
    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startDate}-{_endDate}");
    }
}