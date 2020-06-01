using System;
using System.Linq;
using alkoholspiele.Database;
using alkoholspiele.Models;
using alkoholspiele.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace alkoholspiele.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override Game GetById(Guid id)
        {
            return (
                from entity in this._context.Games.Include(g => g.Jokes)
                where entity.Id == id
                select entity
            ).First();
        }
    }
}