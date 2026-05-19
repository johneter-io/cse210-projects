public class PromptGenerator
{
    public List<string> _promptsgen = new List<string>()
    {
        "> Who was the most interesting person your interacted with today?",
        "> What was the best part of your day?",
        "> How did you see the hand of the Lord in your life today?",
        "> If you had one thing you could do over today, what would it be?",
        "> What made you smile today?",
        "> What challenge did you overcome today?",
        "> What are you grateful for today?",
        "> What did you learn today?",
        "> Who did you help today, even in a small way?",
        "> What drained your energy today?",
        "> What moment do you want to remember from today?",
        "> Did you live today in line with your values?",
    };
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_promptsgen.Count);
        return _promptsgen[index];
    }
}