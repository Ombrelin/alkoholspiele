namespace Alkoholspiel.Core.Entities;

public interface IGameInstance
{
    Guid Id { get; }
    Game Game { get;  }
    DateTime StartDateTime { get;  }
}