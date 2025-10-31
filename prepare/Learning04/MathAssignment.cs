public class MathAssignment : Assignment
{
    private string _textbookSection = "";
    private string _problems = "";

    public void Setterz(string text, string prollums)
    {
        _textbookSection = text;
        _problems = prollums;
    }
    public void GetHomeworkList()
    {
        GetSummary();
        Console.WriteLine($"Section {_textbookSection} Problems {_problems}");
    }
}