using Alkoholspiel.WebApi.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alkoholspiel.WebApi.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<GameEntity> Games { get; set; }
    public DbSet<JokeEntity> Jokes { get; set; }
}