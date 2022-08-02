using Alkoholspiel.Core.Contracts;
using Alkoholspiel.Core.Entities;
using Alkoholspiel.Core.Tests.FakeRepositories;
using FluentAssertions;

namespace Alkoholspiel.Core.Tests;

public class AlkoholspielApplicationTests
{
    [Fact]
    public async Task CreateGame_InsertsInRepository()
    {
        // Given
        const string name = "Test Name";
        const string author = "Test Author";

        var fakeGameRepository = new FakeGameRepository();
        var application = new AlkoholspielApplication( /*null, null,*/ fakeGameRepository);

        // When
        IGame result = await application.CreateGame(new CreateGameRequest(name: name, author: author));

        // Then
        result.Name.Should().Be(name);
        result.Author.Should().Be(author);
        fakeGameRepository.Data.Should().HaveCount(1);
        fakeGameRepository.Data.First().Should().Be(result);
    }
}