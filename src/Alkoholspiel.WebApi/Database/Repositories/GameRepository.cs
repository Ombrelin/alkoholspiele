using System.Threading.Tasks;
using Alkoholspiel.Core;
using Alkoholspiel.Core.Entities;

namespace Alkoholspiel.WebApi.Database.Repositories;

public class GameRepository : IGameRepository
{
    private readonly ApplicationDbContext context;

    public GameRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public Task<Game> Insert(Game game)
    {
        throw new System.NotImplementedException();
    }
}