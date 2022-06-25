using System.Threading.Tasks;
using Alkoholspiel.Core;
using Alkoholspiel.Core.Entities;
using Alkoholspiel.WebApi.Database.Entities;

namespace Alkoholspiel.WebApi.Database.Repositories;

public class GameRepository : IGameRepository
{
    private readonly ApplicationDbContext context;

    public GameRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<Game> Insert(Game game)
    {
        var gameEntity = new GameEntity(game);
        this.context.Games.Add(gameEntity);
        await this.context.SaveChangesAsync();
        return gameEntity.ToDomainEntity();
    }
}