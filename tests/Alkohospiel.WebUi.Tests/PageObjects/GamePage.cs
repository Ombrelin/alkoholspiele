using Microsoft.Playwright;

namespace Alkohospiel.WebUi.Tests.PageObjects;

public class GamePage : Page
{
    public GamePage(IPage page) : base(page)
    {
    }

    public Task GotoAsync(Guid gameId)
    {
        return this.page.GotoAsync("http://localhost/game/${gameId}");
    }

    public bool IsCurrentPage()
    {
        return this.page.Url.StartsWith("http://localhost/game/");
    }

    public Guid GetGameGuid()
    {
        return Guid.Parse(this.page.Url.Split("/").Last());
    }

    public Task<string> GetGameNameOnPageAsync()
    {
        return this.page.Locator("#game-name").TextContentAsync();
    }
    
    public Task<string> GetGameAuthorNameOnPageAsync()
    {
        return this.page.Locator("#game-author").TextContentAsync();
    }
}