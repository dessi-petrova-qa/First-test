using Microsoft.Playwright;

namespace UiTests.Pages
{
    public class ProductsPage
    {
        private readonly IPage _page;

        public ProductsPage(IPage page)
        {
            _page = page;
        }

        public ILocator FirstProductAddToCartButton =>
            _page.Locator("a:has-text('Add to cart')").First;

        public ILocator ContinueShoppingButton =>
            _page.Locator("button:has-text('Continue Shopping'), .btn-success:has-text('Continue Shopping')");

        public async Task AddFirstProductToCartAsync()
        {
            await FirstProductAddToCartButton.ClickAsync();
             

            // Някои popups изискват "Continue Shopping"
            if (await ContinueShoppingButton.IsVisibleAsync())
            {
                await ContinueShoppingButton.ClickAsync();
            }
        }
    }
}