using Microsoft.Playwright;

namespace Alkohospiel.WebUi.Tests.PageObjects;

public class CreateGamePage
{
    private readonly IPage page;

    public CreateGamePage(IPage page)
    {
        this.page = page;
    }

    public async Task Goto()
    {
        await page.GotoAsync("http://localhost");
    }
}