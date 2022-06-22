namespace Alkoholspiel.Core.Entities;

public class JokeCompletion
{
    public Guid Id { get; }
    public Joke Joke { get; }
    public GameInstance GameInstance { get; }

    public JokeCompletion(Joke joke, GameInstance gameInstance)
    {
        Id = Guid.NewGuid();
        Joke = joke;
        GameInstance = gameInstance;
    }

    public JokeCompletion(Guid id, Joke joke, GameInstance gameInstance)
    {
        Id = id;
        Joke = joke;
        GameInstance = gameInstance;
    }
}