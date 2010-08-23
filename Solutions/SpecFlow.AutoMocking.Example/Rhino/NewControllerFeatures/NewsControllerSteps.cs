namespace SpecFlow.AutoMocking.Example.Rhino.NewControllerFeatures
{
    using global::Rhino.Mocks;

    using NUnit.Framework;

    using SpecFlow.AutoMocking.Rhino;

    using TechTalk.SpecFlow;

    [Binding]
    public class NewsControllerSteps : StepDefinitions<NewsController>
    {
        private const string TheLatestHeadline = "The latest headline";

        private INewsService newsService;

        private string result;

        [Given(@"I am viewing news")]
        public void GivenIAmViewingNews()
        {
            this.newsService = this.DependencyOf<INewsService>();
            this.newsService.Stub(x => x.GetLatestHeadline()).Return(TheLatestHeadline);
        }

        [Then(@"the result should contain the latest headline")]
        public void ThenTheResultShouldContainTheLatestHeadline()
        {
            Assert.That(this.result, Is.EqualTo(TheLatestHeadline));
        }

        [When(@"I ask for the view")]
        public void WhenIAskForTheView()
        {
            this.result = this.Subject.Index();
        }
    }
}