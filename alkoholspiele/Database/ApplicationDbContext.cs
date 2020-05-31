using alkoholspiele.Models;
using Microsoft.EntityFrameworkCore;

namespace alkoholspiele.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Joke> Jokes { get; set; }
    }
    
}