namespace Alkoholspiel.Core.Entities;

public interface IGame
{
    public Guid Id { get; set; }
    public string Name { get; }
    public string Author { get; }
}