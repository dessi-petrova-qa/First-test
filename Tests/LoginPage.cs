using Microsoft.Playwright;

namespace UiTests.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        // Локатори – може да ги настроиш според real DOM, това са примерни
        private ILocator LoginEmailInput =>
            _page.Locator("input[data-qa='login-email']");

        private ILocator LoginPasswordInput =>
            _page.Locator("input[data-qa='login-password']");

        private ILocator LoginButton =>
            _page.Locator("button[data-qa='login-button']");

        private ILocator LoggedInAsLabel =>
            _page.Locator("a:has-text('Logged in as')");

        public async Task LoginAsync(string email, string password)
        {
            await LoginEmailInput.FillAsync(email);
            await LoginPasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();
        }

        public async Task<bool> IsLoggedInAsync()
        {
            return await LoggedInAsLabel.IsVisibleAsync();
        }
    }
}