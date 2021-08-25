using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedUITesting.Web.Test.UI.PageObjects
{
    public class CounterPageObject
    {
        public IBrowser Browser { get; }
        public IPage Page { get; set; }

        public string PagePath => "https://localhost:44372/counter";

        public CounterPageObject(IBrowser browser)
        {
            Browser = browser;
        }

        public Task ClickIncreasesButton() => Page.ClickAsync("button.btn-primary");

        public async Task<int> CounterValue() => int.Parse(await Page.InnerTextAsync("span.counter-val"));

        public async Task NavigateAsync() 
        {
            Page = await Browser.NewPageAsync();
            await Page.GotoAsync(PagePath);
        }
    }
}
