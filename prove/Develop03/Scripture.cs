using System;
using System.Collections.Generic;

class Scripture
{
    // Attributes
    private Reference _ref;
    private List<Word> _words = new List<Word>();
    private List<int> _visibleIndex = new List<int>();
    private Random _randy = new Random();
    private string _originalText;

    // Behaviors
    // Grab scripture and split into a word class (acknowledging punctuation)
    public Scripture(Reference reference, string sentence)
    {
        _ref = reference;
        _originalText = sentence;

        string[] splitScript = sentence.Split(
            new char[] { ' ', '\t', '\n' },
            StringSplitOptions.RemoveEmptyEntries
        );

        for (int i = 0; i < splitScript.Length; i++)
        {
            _words.Add(new Word(splitScript[i]));
            _visibleIndex.Add(i);
        }
    }
    // getters
    public Reference GetReference()
    {
        return _ref;
    }
    public string GetOriginalText()
    {
        return _originalText;
    }
    // hide word
    public void Hide(Word w)
    {
        w.SetIsHidden();
    }
    // randomized hiding 3 unhidden words 
    public void HideRandom(int count)
    {
        if (_visibleIndex.Count == 0)
            return;

        count = Math.Min(count, _visibleIndex.Count);

        for (int i = 0; i < count; i++)
        {
            int randIndex = _randy.Next(_visibleIndex.Count);
            int wordIndex = _visibleIndex[randIndex];

            _words[wordIndex].SetIsHidden();
            _visibleIndex.RemoveAt(randIndex);
        }
    }
    // Handle if all words are hidden
    public bool AllHidden()
    {
        return _visibleIndex.Count == 0;
    }
    // Display scripture and reintroduce punctuation
    public void Display()
    {
        Console.Write($"{_ref.GetDisplayText()}");

        foreach (Word w in _words)
        {
            string val = w.GetValue();

            if (val == "," || val == "." || val == ";" || val == ":" || val == "!" || val == "?")
                Console.Write(val);
            else
            {
                Console.Write(" ");
                w.Display();
            }
        }

        Console.WriteLine();
    }
}
