using System.Net;
using System.Net.Http.Json;
using Alkoholspiel.Core.Contracts;
using Alkoholspiel.Core.Entities;
using Alkoholspiel.WebApi.Database;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Xunit;
using FluentAssertions;

namespace Alkoholspiel.WebApi.Tests;

public class IntegrationsTests : IClassFixture<WebApplicationFactory<Startup>>, IAsyncLifetime
{
    private readonly HttpClient client;
    private readonly ApplicationDbContext givenDbContext;
    private readonly ApplicationDbContext assertDbContext;

    public IntegrationsTests(WebApplicationFactory<Startup> webApplicationFactory)
    {
        this.client = webApplicationFactory.CreateClient();
        IConfiguration configuration = webApplicationFactory.Services.GetService<IConfiguration>() ??
                                       throw new InvalidOperationException("Can't get Configuration from DI");

        givenDbContext = new ApplicationDbContext(GetOptionsForOtherDbContext(configuration));
        assertDbContext = new ApplicationDbContext(GetOptionsForOtherDbContext(configuration));
    }

    public DbContextOptions GetOptionsForOtherDbContext(IConfiguration configuration)
    {
        var builder = new NpgsqlConnectionStringBuilder
        {
            Host = configuration["DB_HOST"],
            Port = int.Parse(configuration["DB_PORT"]),
            Username = configuration["DB_USERNAME"],
            Password = configuration["DB_PASSWORD"],
            Database = configuration["DB_NAME"]
        };
        var options = new DbContextOptionsBuilder()
            .UseNpgsql(builder.ToString())
            .Options;
        return options;
    }

    public async Task PostGames_Returns201AndInsertRecordInDatabase()
    {
        // Given
        const string author = "Test Game Author";
        const string name = "Test Game Name";
        var createGameRequest = new CreateGameRequest(author, name);

        // When
        var response = await this.client.PostAsJsonAsync("/games", createGameRequest);

        // Then
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var gameFromResponse = await response.Content.ReadFromJsonAsync<IGame>();
        gameFromResponse.Id.Should().NotBeEmpty();
        gameFromResponse.Name.Should().Be(name);
        gameFromResponse.Author.Should().Be(author);
        
        var gameFromDatabase = await this.givenDbContext.Games.FirstAsync();
        gameFromDatabase.Id.Should().Be(gameFromResponse.Id);
        gameFromDatabase.Name.Should().Be(name);
        gameFromDatabase.Author.Should().Be(author);
    }

    public Task InitializeAsync() => Task.CompletedTask;

    public async Task DisposeAsync()
    {
        this.assertDbContext.RemoveRange(this.assertDbContext.Games);
        await this.assertDbContext.SaveChangesAsync();

        Task disposeAssertContext = this.assertDbContext.DisposeAsync().AsTask();
        Task disposeGivenContext = this.givenDbContext.DisposeAsync().AsTask();
        await Task.WhenAll(disposeAssertContext, disposeGivenContext);
    }
}