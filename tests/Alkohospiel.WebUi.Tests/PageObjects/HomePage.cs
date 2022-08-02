using Microsoft.Playwright;

namespace Alkohospiel.WebUi.Tests.PageObjects;

public class HomePage : Page
{
    public HomePage(IPage page) : base(page)
    {
    }

    public async Task FillNameAsync(string name)
    {
        await page.Locator("#user-name-form input").FillAsync(name);
        await page.Locator("#user-name-form button").ClickAsync();
    }
    
    public async Task GotoAsync()
    {
        await page.GotoAsync("http://localhost");
    }
}