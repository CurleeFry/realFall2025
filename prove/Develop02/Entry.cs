using Develop02;

public class Entry
{
    // ATTRIBUTES //
    public string _date;
    public string _prompt;
    public string _response;

    // BEHAVIORS //
    public void Display()
    {
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine($"{_date}--'{_prompt}'");
        Console.WriteLine($"{_response}");
    }
}