public class Word
{
    // Private attributes (Encapsulation)
    private string _text;
    private bool _isHidden;

    //Methods
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            string underscores = new string('_', _text.Length);
            return underscores;
        }
        else
        {
            return _text;
        }
    }
}