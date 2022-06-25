using Alkoholspiel.WebApi.Database;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Xunit;

namespace Alkohospiel.WebUi.Tests.RepositoriesUnitTests;

public class DatabaseTest : IAsyncLifetime
{ 
    protected readonly ApplicationDbContext Context;

    public DatabaseTest()
    {
        Context = BuildNewDbContext();
    }

    public Task InitializeAsync() => Context.Database.MigrateAsync();

    public async Task DisposeAsync()
    {
        this.Context.RemoveRange(this.Context.Games);
        await this.Context.SaveChangesAsync();
        await this.Context.DisposeAsync();
    }
    
    private ApplicationDbContext BuildNewDbContext()
    {
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = Environment.GetEnvironmentVariable("DB_HOST"),
            Port = int.Parse(Environment.GetEnvironmentVariable("DB_PORT")),
            Username = Environment.GetEnvironmentVariable("DB_USERNAME"),
            Password = Environment.GetEnvironmentVariable("DB_PASSWORD"),
            Database = Environment.GetEnvironmentVariable("DB_NAME")
        };
        var options = new DbContextOptionsBuilder()
            .UseNpgsql(builder.ToString())
            .Options;

        return new ApplicationDbContext(options);
    }
}