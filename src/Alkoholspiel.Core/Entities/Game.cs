using Alkoholspiel.Core.Exceptions;

namespace Alkoholspiel.Core.Entities;

public class Game : IGameWithJokes
{
    public Guid Id { get; }
    public string Name { get; }
    public string Author { get; }
    public List<Joke> Jokes { get; }

    public Game(string name, string author)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new EntityStateException("Game Name can be neither null nor empty");
        }

        if (string.IsNullOrEmpty(author))
        {
            throw new EntityStateException("Game Author can be neither null nor empty");
        }
        
        Name = name;
        Author = author;
        Jokes = new List<Joke>();
        Id = Guid.NewGuid();
    }

    public Game(Guid id, string name,  string author) : this(name, author)
    {
        Id = id;
    }
}