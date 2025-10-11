using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using Develop02;

public class Journal
{
    // ATTRIBUTES //


    // Create a list to store the entries //
    public List<Entry> _entries = new List<Entry>();
    //

    // Store the potential prompts //
    public List<string> _prompts =
    [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
    ];
    //

    // BEHAVIORS //

    public void Write()
    {
        // date fetch //
        DateTime nowOclock = DateTime.Now;
        string nowString = nowOclock.ToShortDateString();
        //

        // random prompt genrator //
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);
        string randomPrompt = _prompts[randomIndex];
        //

        // Generate new instance of entry, create attributes of entry //
        Entry entry = new Entry();
        entry._date = nowString;
        entry._prompt = randomPrompt;
        Console.WriteLine($"Prompt: {entry._prompt}");
        Console.Write("> ");
        entry._response = Console.ReadLine();
        // 

        // Add new entry to Journal._entries Attribute //
        _entries.Add(entry);
        //

        Console.WriteLine("Thanks for you entry.");

    }
    public void Load()
    {
        Console.WriteLine("What was the name of your file?");
        string fileQuery = Console.ReadLine();
        string file = fileQuery + ".txt";

        if (!File.Exists(file))
        {
            Console.WriteLine($"The file \"{file}\" could not be found.");
            return;
        }

        // Open file //
        string[] lines = System.IO.File.ReadAllLines(file);
        //

        // convert file back into entires class //
        foreach (string line in lines)
        {
            string[] parts = line.Split(",");
            if (parts.Length == 3)
            {
                Entry entry = new Entry
                {
                    _date = parts[0],
                    _prompt = parts[1],
                    _response = parts[2]
                };
                _entries.Add(entry);
            }
        }
        Console.WriteLine($"Loaded content from {file}.");
    }
    public void Save()
    {
        // generate filename //
        Console.WriteLine("What would you like the name of your save file to be?");
        string fileInput = Console.ReadLine();
        string file = fileInput + ".txt";
        //

        // Save entry list to filename
        using (StreamWriter outputfile = new StreamWriter(file))
        {
            foreach (Entry e in _entries)
            {
                outputfile.WriteLine($"{e._date}, {e._prompt}, {e._response}");
            }
        }
        Console.WriteLine($"Saved content to '{file}' .");
    }
    public void Display()
    {
        // Test for no entries //
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display yet.");
        }
        //

        // Iterate through entries in entries list //
        else
        {
            foreach (Entry e in _entries)
            {
                e.Display();
            }
        }
        //
    }
}