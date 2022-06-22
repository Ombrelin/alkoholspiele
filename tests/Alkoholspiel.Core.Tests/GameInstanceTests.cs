using Alkoholspiel.Core.Entities;
using FluentAssertions;

namespace Alkoholspiel.Core.Tests;

public class GameInstanceTests
{
    [Fact]
    public void Constructor_Initialisation_FillsData()
    {
        // Given
        var game = new Game("Test Game","Test Author");
        
        // When
        var gameInstance = new GameInstance(game);
        
        // Then
        gameInstance.Id.Should().NotBeEmpty();
        gameInstance.Game.Should().Be(game);
        gameInstance.JokeCompletions.Should().BeEmpty();
        gameInstance.StartDateTime.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMinutes(1));
    }

    [Fact]
    public void Constructor_Reconstitution_FillsData()
    {
        // Given
        var id = Guid.NewGuid();
        var game = new Game("Test Game","Test Author");
        var date = DateTime.Now;
        var jokeCompletions = new List<JokeCompletion>();

        // When
        var gameInstance = new GameInstance(id, game, date, jokeCompletions);

        // Then
        gameInstance.Id.Should().Be(id);
        gameInstance.Game.Should().Be(game);
        gameInstance.StartDateTime.Should().Be(date);
        gameInstance.JokeCompletions.Should().BeSameAs(jokeCompletions);

    }
}