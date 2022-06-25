using Alkoholspiel.Core.Entities;
using Alkoholspiel.WebApi.Database.Repositories;
using Alkohospiel.WebUi.Tests.RepositoriesUnitTests;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Alkoholspiel.WebApi.Tests.RepositoriesUnitTests;

public class GameRepositoryTests : DatabaseTest
{
    [Fact]
    public async Task InsertGame_InsertRecordsInDatabase()
    {
        // Given
        var game = new Game("Test Game Name", "Test Game Author");
        var repository = new GameRepository(Context);

        // When
        await repository.Insert(game);
        
        // Then
        var gameInDatabase = await Context.Games.FirstAsync();

        gameInDatabase.Id.Should().Be(game.Id);
        gameInDatabase.Name.Should().Be(game.Name);
        gameInDatabase.Author.Should().Be(game.Author);
    } 


}