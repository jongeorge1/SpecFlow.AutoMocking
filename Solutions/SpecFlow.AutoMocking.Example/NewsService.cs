namespace SpecFlow.AutoMocking.Example
{
    using System.Collections.Generic;
    using System.Linq;

    public class NewsService : INewsService
    {
        private readonly List<string> headlines;

        public NewsService(List<string> headlines)
        {
            this.headlines = headlines;
        }

        public List<string> GetAllHeadlines()
        {
            return this.headlines;
        }

        public string GetLatestHeadline()
        {
            if (this.headlines.Count == 0)
            {
                return null;
            }
            
            return this.headlines.Last();
        }
    }
}