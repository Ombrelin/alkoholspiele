namespace Alkoholspiel.Core.Entities;

public class GameInstance : IGameInstanceWithCompletions
{
    public Guid Id { get; }
    public Game Game { get; }
    public DateTime StartDateTime { get; }
    public List<JokeCompletion> JokeCompletions { get; }
    
    public GameInstance(Game game)
    {
        Id = Guid.NewGuid();
        Game = game;
        StartDateTime = DateTime.Now;
        JokeCompletions = new List<JokeCompletion>();
    }

    public GameInstance(Guid id, Game game, DateTime startDateTime, List<JokeCompletion> jokeCompletions)
    {
        Id = id;
        Game = game;
        StartDateTime = startDateTime;
        JokeCompletions = jokeCompletions;
    }
}