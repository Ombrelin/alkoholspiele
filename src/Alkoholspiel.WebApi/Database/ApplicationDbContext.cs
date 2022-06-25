using Alkoholspiel.WebApi.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Alkoholspiel.WebApi.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<GameEntity> Games { get; set; }
    public DbSet<JokeEntity> Jokes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameEntity>().HasKey(gameEntity => gameEntity.Id);
        modelBuilder.Entity<GameEntity>().Property(gameEntity => gameEntity.Id).ValueGeneratedNever();
        modelBuilder.Entity<GameEntity>().Property(gameEntity => gameEntity.Name);
        modelBuilder.Entity<GameEntity>().Property(gameEntity => gameEntity.Author);
    }
}