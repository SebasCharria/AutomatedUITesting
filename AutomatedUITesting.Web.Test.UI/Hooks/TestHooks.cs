using AutomatedUITesting.Web.Test.UI.PageObjects;
using BoDi;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomatedUITesting.Web.Test.UI.Hooks
{
    [Binding]
    public class TestHooks
    {
        [BeforeScenario("Counter")]
        public async Task BeforeCounterScenario(IObjectContainer objectContainer)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync( new BrowserTypeLaunchOptions { Headless = false, SlowMo = 2000 });
            var pageObject = new CounterPageObject(browser);
            objectContainer.RegisterInstanceAs(playwright);
            objectContainer.RegisterInstanceAs(browser);
            objectContainer.RegisterInstanceAs(pageObject);
        }

        [AfterScenario]
        public async Task AfterScenario(IObjectContainer objectContainer)
        {
            var browser = objectContainer.Resolve<IBrowser>();
            await browser.CloseAsync();
            var playwright = objectContainer.Resolve<IPlaywright>();
            playwright.Dispose();
        }
    }
}
