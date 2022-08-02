using Alkohospiel.WebUi.Tests.PageObjects;
using FluentAssertions;
using Microsoft.Playwright;
namespace Alkohospiel.WebUi.Tests;

public class GameTests : IAsyncLifetime
{
    
    private IPlaywright webDriver;
    private IBrowser browser;
    private IPage page;
    
    public async Task InitializeAsync()
    {
        webDriver = await Playwright.CreateAsync();
        browser = await webDriver.Chromium.LaunchAsync();
        page = await browser.NewPageAsync();
    }
    
    [Fact]
    public async Task CreateGame_NavigatesToGamePage()
    {
        // Given
        var testGameName = "Test game";
        var testUserName = "Test name";
        
        var homePage = new HomePage(page);
        await homePage.GotoAsync();
        await homePage.FillNameAsync(testUserName);

        // When
        var createGamePage = new CreateGamePage(page);
        await createGamePage.GotoAsync();
        await createGamePage.CreateGameAsync(testGameName);
        
        // Then
        var gamePage = new GamePage(page);
        gamePage.IsCurrentPage().Should().BeTrue();
        
        var gameName = await gamePage.GetGameNameOnPageAsync();
        var authorName = await gamePage.GetGameNameOnPageAsync();

        gameName.Should().Be(testGameName);
        authorName.Should().Be(testUserName);
    }

    public Task DisposeAsync() => Task.CompletedTask;
}