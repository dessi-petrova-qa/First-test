using Microsoft.Playwright;

namespace UiTests.Pages
{
    public class CartPage
    {
        private readonly IPage _page;

        public CartPage(IPage page)
        {
            _page = page;
        }

        // Таблица с продуктите в количката
        private ILocator CartTable => _page.Locator("#cart_info_table, .cart_info");

        public ILocator CartRows =>
            CartTable.Locator("tbody tr");

        public async Task<bool> HasAnyItemsAsync()
        {
            return await CartRows.CountAsync() > 0;
        }
    }
}