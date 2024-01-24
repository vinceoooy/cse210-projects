using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Showing Creativity and Exceeding Requirements (Have the program to load scriptures from a files.)    
        // reading a choosing random verse from a file
        string filePath = "scripture.txt";
        List<string> scriptureMastery = new List<string>(File.ReadAllLines(filePath));
        Random random = new Random();
        int randomVerse = random.Next(0, scriptureMastery.Count);
        string[] parts = scriptureMastery[randomVerse].Split('`');

        Reference reference;   
        Scripture scripture;

        // checking if verse contains morethan 1 verse, if so, it has an endVerse
        if (parts.Length == 4)
        {
            reference = new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]));
            scripture = new Scripture(reference, parts[3]);
        }
        else if (parts.Length == 5)
        {
            reference = new Reference(parts[0], int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3]));
            scripture = new Scripture(reference, parts[4]);
        }
        else
        {
            // Handle the case where the number of parts is neither 4 nor 5
            Console.WriteLine("Invalid format in the scripture file.");
            return;
        }
        

        // Display the complete scripture
        Console.WriteLine(scripture.GetDisplayText());

        // Run the memorization loop
        while (!scripture.IsCompletelyHidden())
        {
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                // Exit the program
                break;
            }

            // Hide a few random words and display the scripture again
            scripture.HideRandomWords(3);
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}


class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    // Constructor
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    // Hide random words in the scripture
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            List<Word> wordsToHide = _words.Where(word => !word.IsHidden()).ToList();
            if (wordsToHide.Count > 0)
            {
                int randomIndex = random.Next(wordsToHide.Count);
                wordsToHide[randomIndex].Hide();
            }
        }
    }

    // Get the display text of the scripture
    public string GetDisplayText()
    {
        string displayText = $"{_reference.GetDisplayText()}\n";
        foreach (Word word in _words)
        {
            displayText += word.GetDisplayText() + " ";
        }
        return displayText.Trim();
    }

    // Check if the scripture is completely hidden
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}


class Word
{
    private string _text;
    private bool _isHidden;

    // Constructor
    public Word(string text)
    {
        _text = text;
        _isHidden = false; // Words are visible by default
    }

    // Hide the word
    public void Hide()
    {
        _isHidden = true;
    }

    // Show the word
    public void Show()
    {
        _isHidden = false;
    }

    // Check if the word is hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Get the display text of the word (underscore if hidden)
    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}


class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Constructor for a single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    // Constructor for a verse range
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    // Get the display text of the reference
    public string GetDisplayText()
    {
        if (_endVerse == 0)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}