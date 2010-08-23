namespace SpecFlow.AutoMocking.Example.Rhino.NewsServiceFeatures
{
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;

    using SpecFlow.AutoMocking.Rhino;

    using TechTalk.SpecFlow;

    [Binding]
    public class NewsServiceSteps : StepDefinitions<INewsService, NewsService>
    {
        private List<string> newsHeadlines;

        private dynamic result;

        [Given(@"There are (.*) headlines available")]
        public void GivenThereAreHeadlinesAvailable(int headlineCount)
        {
            this.newsHeadlines = new List<string>(headlineCount);

            for (var index = 0; index < headlineCount; index++)
            {
                this.newsHeadlines.Add(string.Concat("News headline ", index + 1));
            }

            // Manually add a required simple constructor argument
            this.ProvideBasicConstructorArgument(this.newsHeadlines);
        }

        [Then(@"a list of (.*) headlines should be returned")]
        public void ThenAListOfHeadlinesShouldBeReturned(int expectedHeadlines)
        {
            Assert.That(this.result.Count, Is.EqualTo(expectedHeadlines));
        }

        [Then(@"no result should be returned")]
        public void ThenNoResultShouldBeReturned()
        {
            // Abusing the constraint syntax because the dynamic variable confuses things.
            Assert.That(this.result == null, Is.True);
        }

        [Then(@"the most recent headline should be returned")]
        public void ThenTheMostRecentHeadlineShouldBeReturned()
        {
            Assert.That(this.result, Is.SameAs(this.newsHeadlines.Last()));
        }

        [When(@"I ask for all the headlines")]
        public void WhenIAskForAllTheHeadlines()
        {
            this.result = this.Subject.GetAllHeadlines();
        }

        [When(@"I ask for the latest headline")]
        public void WhenIAskForTheLatestHeadline()
        {
            this.result = this.Subject.GetLatestHeadline();
        }
    }
}