namespace SpecFlow.AutoMocking.Core.Observations
{
    public interface IObservationContext
    {
        TInterface An<TInterface>() where TInterface : class;

        TContract BuildSubject<TContract, TClass>();

        TDependency DependencyOf<TDependency>() where TDependency : class;

        void ProvideABasicSubjectConstructorArgument<TArgument>(TArgument value);
    }
}