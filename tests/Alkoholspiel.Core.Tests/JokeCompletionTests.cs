using Alkoholspiel.Core.Entities;
using FluentAssertions;

namespace Alkoholspiel.Core.Tests;

public class JokeCompletionTests
{
    [Fact]
    public void Constructor_Initialisation_FillsData()
    {
        // Given
        var joke = new Joke("Test Joke Author", "Test Joke Content");
        var game = new Game("Test Game Name", "Test Game Author");
        var gameInstance = new GameInstance(game);
        
        // When
        var jokeCompletion = new JokeCompletion(joke, gameInstance);

        // Then
        jokeCompletion.Id.Should().NotBeEmpty();
        jokeCompletion.Joke.Should().Be(joke);
        jokeCompletion.GameInstance.Should().Be(gameInstance);
    }

    [Fact]
    public void Constructor_Reconstitution_FillsData()
    {
        // Given
        var id = Guid.NewGuid();
        var joke = new Joke("Test Joke Author", "Test Joke Content");
        var game = new Game("Test Game Name", "Test Game Author");
        var gameInstance = new GameInstance(game);
        
        // When
        var jokeCompletion = new JokeCompletion(id, joke, gameInstance);

        // Then
        jokeCompletion.Id.Should().Be(id);
        jokeCompletion.Joke.Should().Be(joke);
        jokeCompletion.GameInstance.Should().Be(gameInstance);
    }
}