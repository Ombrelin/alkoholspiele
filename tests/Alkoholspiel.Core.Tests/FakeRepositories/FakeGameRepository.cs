using Alkoholspiel.Core.Entities;

namespace Alkoholspiel.Core.Tests.FakeRepositories;

public class FakeGameRepository : IGameRepository
{
    public List<Game> Data { get; set; }

    public FakeGameRepository()
    {
        Data = new List<Game>();
    }

    public Task<Game> Insert(Game game)
    {
        Data.Add(game);
        return Task.FromResult(game);
    }
}