using Alkoholspiel.Core.Entities;
using Alkoholspiel.Core.Exceptions;
using FluentAssertions;

namespace Alkoholspiel.Core.Tests;

public class GameTests
{
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Constructor_InvalidName_Throws(string invalidValue)
    {
        // When
        Action act = () => new Game(invalidValue,"Test");
        
        // Then
        act.Should().Throw<EntityStateException>();
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Constructor_InvalidAuthor_Throws(string invalidValue)
    {
        // When
        Action act = () => new Game("Test",invalidValue);
        
        // Then
        act.Should().Throw<EntityStateException>();
    }

    [Fact]
    public void Constructor_Initialisation_FillsData()
    {
        // Given
        var name = "Test Name";
        var author = "Test Author";
        
        // When
        var game = new Game(name, author);
        
        // Then
        game.Name.Should().Be(name);
        game.Author.Should().Be(author);
        game.Id.Should().NotBeEmpty();
    }
    
    [Fact]
    public void Constructor_Reconstitution_FillsData()
    {
        // Given
        var id = Guid.NewGuid();
        var name = "Test Name";
        var author = "Test Author";
        
        // When
        var game = new Game(id, name, author);
        
        // Then
        game.Name.Should().Be(name);
        game.Author.Should().Be(author);
        game.Id.Should().Be(id);
    }
}