using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiTests.Fixtures;
using UiTests.Pages;
using Microsoft.Playwright;

namespace UiTests.Pages
{
    public class HomePage
    {
        private readonly IPage _page;
        private const string BaseUrl = "https://automationexercise.com/";

        public HomePage(IPage page)
        {
            _page = page;
        }

        public async Task OpenAsync()
        {
            await _page.GotoAsync(BaseUrl);
        }

        // Лого / линк HOME
        public ILocator HeaderLogo =>
            _page.GetByRole(AriaRole.Link, new() { Name = " Home" });

        // Линк Products
        public ILocator ProductsLink =>
            _page.GetByRole(AriaRole.Link, new() { Name = " Products" });

        // Линк Signup / Login
        public ILocator SignupLoginLink =>
            _page.GetByRole(AriaRole.Link, new() { Name = " Signup / Login" });
    }
}