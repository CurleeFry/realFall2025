class Reference
{
    // Attributes
    private string _book;
    private int _chapter;
    private int _verse;

    // Behaviors
    // setter
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }
    // format and return scripture reference
    public string GetDisplayText()
    {
        return $"{_book} {_chapter}:{_verse}";
    }
}
