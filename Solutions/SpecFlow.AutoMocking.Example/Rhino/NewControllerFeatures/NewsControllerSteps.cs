namespace SpecFlow.AutoMocking.Example.Rhino.NewControllerFeatures
{
    using global::Rhino.Mocks;

    using NUnit.Framework;

    using SpecFlow.AutoMocking.Rhino;

    using TechTalk.SpecFlow;

    [Binding]
    public class NewsControllerSteps : StepDefinitions<NewsController>
    {
        private INewsService newsService;

        private const string TheLatestHeadline = "The latest headline";

        private string result;

        [Given(@"I am viewing news")]
        public void GivenIAmViewingNews()
        {
            newsService = DependencyOf<INewsService>();
            newsService.Stub(x => x.GetLatestHeadline()).Return(TheLatestHeadline);
        }

        [When(@"I ask for the view")]
        public void WhenIAskForTheView()
        {
            result = Subject.Index();
        }

        [Then(@"the result should contain the latest headline")]
        public void ThenTheResultShouldContainTheLatestHeadline()
        {
            Assert.That(result, Is.EqualTo(TheLatestHeadline));
        }
    }
}