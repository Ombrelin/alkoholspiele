using Alkoholspiel.Core.Entities;

namespace Alkoholspiel.Core;

public interface IGameRepository
{
    Task<Game> Insert(Game game);
}