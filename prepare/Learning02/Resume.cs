using System;
namespace Learning02;

public class Resume
{
    public string _name;

    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"name: {_name}");
        Console.WriteLine("jobs:");

        foreach (Job job in _jobs)
        {
            job.Display();
        }

    }



}