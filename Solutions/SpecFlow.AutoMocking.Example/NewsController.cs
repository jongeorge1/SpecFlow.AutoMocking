namespace SpecFlow.AutoMocking.Example
{
    public class NewsController
    {
        private readonly INewsService newsService;

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        public string Index()
        {
            return this.newsService.GetLatestHeadline();
        }
    }
}