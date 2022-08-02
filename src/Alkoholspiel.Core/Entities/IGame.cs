namespace Alkoholspiel.Core.Entities;

public interface IGame
{
    public Guid Id { get; }
    public string Name { get; }
    public string Author { get; }
}