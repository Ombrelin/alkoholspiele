using Microsoft.Playwright;

namespace Alkohospiel.WebUi.Tests.PageObjects;

public class CreateGamePage : Page
{
    public CreateGamePage(IPage page) : base(page)
    {
    }

    public async Task GotoAsync()
    {
        await page.GotoAsync("http://localhost/game/create");
    }

    public async Task CreateGameAsync(string gameName)
    {
        await page.Locator("#game-form input").FillAsync(gameName);
        await page.Locator("#game-form button").ClickAsync();
    }
}