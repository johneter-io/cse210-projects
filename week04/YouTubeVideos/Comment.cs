class Comment
{
    // PUBLIC | the outside world knows how the data is stored
    public string _name;
    public string _text;

    // the constructor is the only way to create a comment
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    // a single clean method for displaying the comment
    public string GetDisplayText()
    {
        return $"{_name}: {_text}";
    }
}