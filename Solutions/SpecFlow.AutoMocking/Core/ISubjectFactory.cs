namespace SpecFlow.AutoMocking.Core
{
    public interface ISubjectFactory
    {
        TContract Create<TContract, TClass>();
    }
}