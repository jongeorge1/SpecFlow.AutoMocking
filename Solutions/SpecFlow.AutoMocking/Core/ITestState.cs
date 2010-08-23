namespace SpecFlow.AutoMocking.Core
{
    public interface ITestState<TSubject> : IDependencyBag
    {
        TSubject Subject
        {
            get;
            set;
        }

        void BuildSubject();
    }
}