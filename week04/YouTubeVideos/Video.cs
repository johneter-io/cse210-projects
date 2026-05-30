class Video
{
    public string _title;
    public string _author;
    public int _length;
    public List<Comment> _comments;

    // clean Manufacturer
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    // add a comment without exposing the internal List
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // EXPLANATION | return the number of comments
    public int GetNumComments()
    {
        return _comments.Count;
    }

    // DISPLAY | a single method that displays everything in the video
    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Comments: {GetNumComments()}");

        foreach (Comment comment in _comments)
        {
            Console.WriteLine($" - {comment.GetDisplayText()}");
        }
    }
}