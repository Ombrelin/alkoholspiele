using Alkoholspiel.WebApi.Database;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Xunit;

namespace Alkohospiel.WebUi.Tests.RepositoriesUnitTests;

public class DatabaseTest : IAsyncLifetime
{ 
    protected ApplicationDbContext Context;
    private readonly TestcontainerDatabase database = new TestcontainersBuilder<PostgreSqlTestcontainer>()
        .WithDatabase(new PostgreSqlTestcontainerConfiguration
        {
            Database = "db",
            Username = "postgres",
            Password = "postgres",
        })
        .Build();

    public async Task InitializeAsync()
    {
        await this.database.StartAsync();
        this.Context = BuildNewDbContext();
        await Context.Database.MigrateAsync();
    }

    public async Task DisposeAsync()
    {
        await this.Context.DisposeAsync();
        await this.database.DisposeAsync();
    }
    
    private ApplicationDbContext BuildNewDbContext()
    {
        var options = new DbContextOptionsBuilder()
            .UseNpgsql(this.database.ConnectionString)
            .Options;

        return new ApplicationDbContext(options);
    }
}