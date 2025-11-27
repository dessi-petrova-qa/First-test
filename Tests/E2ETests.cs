using Microsoft.Playwright;
using UiTests.Fixtures;
using UiTests.Pages;
using Xunit;

namespace UiTests.Tests
{
    [Collection("UI Tests")]
    public class E2ETests
    {
        private readonly PlaywrightFixture _fixture;

        // 👉 TODO: тук сложи реалните данни на твой тестов акаунт
        private const string TestEmail = "dessi_kasabova@abv.bg";
        private const string TestPassword = "Qwerty1234";

        public E2ETests(PlaywrightFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "E2E: Login, add product to cart and verify cart content")]
        public async Task Login_AddProductToCart_VerifyInCart()
        {
            var context = await _fixture.Browser.NewContextAsync();
            var page = await context.NewPageAsync();

            var home = new HomePage(page);
            var loginPage = new LoginPage(page);
            var productsPage = new ProductsPage(page);
            var cartPage = new CartPage(page);

            // 1. Отваряме началната страница
            await home.OpenAsync();

            // 2. Навигираме до Signup / Login
            await home.SignupLoginLink.ClickAsync();

            // 3. Логваме се с валиден потребител
            await loginPage.LoginAsync(TestEmail, TestPassword);

            Assert.True(await loginPage.IsLoggedInAsync(),
                "Очаква се потребителят да е логнат (да се вижда 'Logged in as').");

            // 4. Отиваме на Products
            await home.ProductsLink.ClickAsync();

            // 5. Добавяме първия продукт в количката
            await productsPage.AddFirstProductToCartAsync();
            await page.WaitForTimeoutAsync(2000);

            // 6. Отваряме Cart (от header навигацията)
            var cartLink = page.GetByRole(AriaRole.Link, new() { Name = " Cart" });
            await cartLink.ClickAsync();
            await page.WaitForTimeoutAsync(2000); 


            // 7. Проверяваме, че количката съдържа поне един продукт
            Assert.True(await cartPage.HasAnyItemsAsync(),
                "Очаква се в количката да има поне един продукт след добавяне.");
            await page.WaitForTimeoutAsync(2000);

            //await context.CloseAsync();
        }
    }
}