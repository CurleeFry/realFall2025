using System;

class Word
{
    // Behaviors
    private bool _isHidden;
    private string _value;

    // Attributes
    // setter
    public Word(string w)
    {
        _value = w;
        _isHidden = false;
    }

    // hide word
    public void SetIsHidden()
    {
        _isHidden = true;
    }
    // getters
    public string GetValue()
    {
        return _value;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Display word, or underscores
    public void Display()
    {
        if (_isHidden)
            Console.Write(new string('_', _value.Length));
        else
            Console.Write(_value);
    }
}
