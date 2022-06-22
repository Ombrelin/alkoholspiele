namespace Alkoholspiel.Core.Entities;

public class Joke
{
    public Guid Id { get; }
    public string Author { get; }
    public string  Content { get; }

    public Joke(string author, string content)
    {
        Id = Guid.NewGuid();
        Author = author;
        Content = content;
    }

    public Joke(Guid id, string author, string content)
    {
        Id = id;
        Author = author;
        Content = content;
    }
}