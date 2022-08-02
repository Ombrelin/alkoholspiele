using Microsoft.Playwright;

namespace Alkohospiel.WebUi.Tests.PageObjects;

public abstract class Page
{
    protected readonly IPage page;

    public Page(IPage page)
    {
        this.page = page;
    }
}