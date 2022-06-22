namespace Alkoholspiel.Core.Entities;

public interface IGameInstanceWithCompletions : IGameInstance
{
    public List<JokeCompletion> JokeCompletions { get; }
}