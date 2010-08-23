namespace SpecFlow.AutoMocking.Core.Observations
{
    public class ObservationContextFactory
    {
        public ObservationContext<TContract> CreateFrom<TContract>(ObservationContextArgs<TContract> args)
        {
            var dependencyBuilder = new SubjectDependencyBuilder(args.State, args.MockFactory);

            return new ObservationContext<TContract>(
                args.State, dependencyBuilder, args.MockFactory, new SubjectFactory(dependencyBuilder));
        }
    }
}