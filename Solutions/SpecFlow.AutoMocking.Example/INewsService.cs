namespace SpecFlow.AutoMocking.Example
{
    using System.Collections.Generic;

    public interface INewsService
    {
        List<string> GetAllHeadlines();

        string GetLatestHeadline();
    }
}