using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Builder for a single verse (example: John 3:16)
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0; 
    }

    // Verse range constructor (example. Proverbs 3:5-6)
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    // Return the quote in the correct format.
    public string GetDisplayText()
    {
        if (_endVerse > 0)
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}";
        }
    }
}