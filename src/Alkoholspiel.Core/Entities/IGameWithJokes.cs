namespace Alkoholspiel.Core.Entities;

public interface IGameWithJokes : IGame
{
    List<Joke> Jokes { get; }
}