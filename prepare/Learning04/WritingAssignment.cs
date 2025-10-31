public class WritingAssignment : Assignment
{
    private string _title = "";

    public void SetUp(string title)
    {
        _title = title;
    }

    public void GetHomeworkList()
    {
        GetSummary();
        Console.WriteLine($"{_title} by {_studentName}");
    }
}