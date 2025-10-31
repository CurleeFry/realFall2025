using System;

public class Assignment
{
    protected string _studentName = "";
    protected string _topic = "";


    public void GetSummary()
    {
        Console.WriteLine($"{_studentName} - {_topic}");
    }
    public void setName(string name)
    {
        _studentName = name;
    }
    public void setTopic(string topic)
    {
        _topic = topic;
    }
}