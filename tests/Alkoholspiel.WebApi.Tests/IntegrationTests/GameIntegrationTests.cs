using System.Net;
using System.Net.Http.Json;
using Alkoholspiel.Core.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Alkoholspiel.WebApi.Tests.IntegrationTests;

public class GameIntegrationTests : IntegrationsTests
{
    public GameIntegrationTests(WebApplicationFactory<Startup> webApplicationFactory) : base(webApplicationFactory)
    {
    }

    [Fact]
    public async Task createGame_InsertsInDatabase()
    {
        // Given
        string gameName = "Test game name";
        String gameAuthor = "Test game author";

        // When
        var response = await this.client.PostAsJsonAsync(
            "/api/games",
            new CreateGameRequest(gameAuthor, gameName)
        );

        // Then
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var responseBody = await response.Content.ReadAsAsync<JObject>();
        responseBody["id"].Value<string>().Should().NotBeNull();
        responseBody["name"].Value<string>().Should().Be(gameName);
        responseBody["author"].Value<string>().Should().Be(gameAuthor);

        var id = Guid.Parse(responseBody["id"].Value<string>());
        var recordInDatabase = await this.assertDbContext.Games.FirstAsync(game => game.Id == id);
        
        recordInDatabase.Name.Should().Be(gameName);
        recordInDatabase.Author.Should().Be(gameAuthor);
    }
}