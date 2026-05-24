using System;
using System.Collections.Generic;

public class Scripture
{
    // Private attributes (Encapsulation)
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    //Methods

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] splitText = text.Split(' ');

        foreach (string wordString in splitText)
        {
            Word newWord = new Word(wordString);
            _words.Add(newWord);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int wordsHiddenThisRound = 0;

        while (wordsHiddenThisRound < numberToHide)
        {
            if (IsCompletelyHidden())
            {
                break;
            }

            int randomIndex = random.Next(_words.Count);

            if (!_words[randomIndex].IsHidden())
            {
                _words[randomIndex].Hide();
                wordsHiddenThisRound++;
            }
        }
    }
    public string GetDisplayText()
    {
        string scriptureText = "";

        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }

        return $"{_reference.GetDisplayText()} {scriptureText.Trim()}";
    }
    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {

            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }

}