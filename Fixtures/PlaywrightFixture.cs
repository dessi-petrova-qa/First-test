using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiTests.Fixtures
{
    public class PlaywrightFixture : IAsyncLifetime
    {
        public IPlaywright Playwright { get; private set; } = null!;
        public IBrowser Browser { get; private set; } = null!;

        public async Task InitializeAsync()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,   // за начало да се вижда браузъра
                SlowMo = 500        // забавяне
            });
        }

        public async Task DisposeAsync()
        {
            if (Browser != null)
            {
                await Browser.CloseAsync();
            }

            Playwright?.Dispose();
        }
    }

    // Колекция, за да споделяме фикстурата между тестовете
    [CollectionDefinition("UI Tests")]
    public class UiTestCollection : ICollectionFixture<PlaywrightFixture>
    {
    }
}

