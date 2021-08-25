using AutomatedUITesting.Web.Test.UI.PageObjects;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomatedUITesting.Web.Test.UI.Steps
{
    [Binding]
    public class CounterShouldBePropertyIncrementingItsValueSteps
    {
        private readonly CounterPageObject counterPageObject;

        public CounterShouldBePropertyIncrementingItsValueSteps(CounterPageObject counterPageObject)
        {
            this.counterPageObject = counterPageObject;
        }

        [Given(@"a user in then counter page")]
        public async Task GivenAUserInThenCounterPage()
        {
            await counterPageObject.NavigateAsync();
        }
        
        [When(@"the increase button is clicked (.*) times")]
        public async Task WhenTheIncreaseButtonIsClickedTimes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                await counterPageObject.ClickIncreasesButton();
            }
        }
        
        [Then(@"the counter value is (.*)")]
        public async Task ThenTheCounterValueIs(int value)
        {
            var counterValue = await counterPageObject.CounterValue();
            counterValue.Should().Be(value);
        }
    }
}
