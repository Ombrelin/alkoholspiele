using Alkoholspiel.Core.Entities;
using FluentAssertions;

namespace Alkoholspiel.Core.Tests;

public class JokeTests
{
    [Fact]
    public void Constructor_Initialisation_FillsData()
    {
        // Given
        const string author = "Test Author";
        const string content = "Test Content";

        // When
        var joke = new Joke(author, content);

        // Then
        joke.Id.Should().NotBeEmpty();
        joke.Author.Should().Be(author);
        joke.Content.Should().Be(content);
    }

    [Fact]
    public void Constructor_Reconstitution_FillsData()
    {
        // Given
        var id = Guid.NewGuid();
        const string author = "Test Author";
        const string content = "Test Content";

        // When
        var joke = new Joke(id, author, content);

        // Then
        joke.Id.Should().Be(id);
        joke.Author.Should().Be(author);
        joke.Content.Should().Be(content);
    }
}