namespace SpecFlow.AutoMocking
{
    using SpecFlow.AutoMocking.Core;
    using SpecFlow.AutoMocking.Core.Observations;

    public abstract class StepDefinitions<TContract, TSubject, TMockFactoryAdapter>
        where TSubject : TContract where TMockFactoryAdapter : IMockFactory, new()
    {
        private static ITestState<TContract> testState;

        protected StepDefinitions()
        {
            testState = new TestState<TContract>(this, this.CreateSubject);

            var args = new ObservationContextArgs<TContract>
                {
                    MockFactory = new TMockFactoryAdapter(), 
                    State = testState, Test = this
                };

            ObservationContext = new ObservationContextFactory().CreateFrom(args);
        }

        protected static TContract Subject
        {
            get
            {
                if (testState.Subject == null)
                {
                    testState.BuildSubject();
                }

                return testState.Subject;
            }
        }

        private static IObservationContext ObservationContext { get; set; }

        protected static TInterface An<TInterface>() where TInterface : class
        {
            return ObservationContext.An<TInterface>();
        }

        protected static TDependency DependencyOf<TDependency>() where TDependency : class
        {
            return ObservationContext.DependencyOf<TDependency>();
        }

        protected static void ProvideBasicConstructorArgument<TArgument>(TArgument value)
        {
            ObservationContext.ProvideABasicSubjectConstructorArgument(value);
        }

        protected virtual TContract CreateSubject()
        {
            return ObservationContext.BuildSubject<TContract, TSubject>();
        }
    }
}