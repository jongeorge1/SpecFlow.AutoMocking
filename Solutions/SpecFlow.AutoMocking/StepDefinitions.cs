namespace SpecFlow.AutoMocking
{
    using SpecFlow.AutoMocking.Core;
    using SpecFlow.AutoMocking.Core.Observations;

    public abstract class StepDefinitions<TContract, TSubject, TMockFactoryAdapter>
        where TSubject : TContract where TMockFactoryAdapter : IMockFactory, new()
    {
        private readonly ITestState<TContract> testState;

        protected StepDefinitions()
        {
            this.testState = new TestState<TContract>(this, this.CreateSubject);

            var args = new ObservationContextArgs<TContract>
            {
                MockFactory = new TMockFactoryAdapter(), 
                State = this.testState, Test = this
            };

            this.ObservationContext = new ObservationContextFactory().CreateFrom(args);
        }

        protected TContract Subject
        {
            get
            {
                if (this.testState.Subject == null)
                {
                    this.testState.BuildSubject();
                }

                return this.testState.Subject;
            }
        }

        private IObservationContext ObservationContext { get; set; }

        protected TInterface An<TInterface>() where TInterface : class
        {
            return this.ObservationContext.An<TInterface>();
        }

        protected virtual TContract CreateSubject()
        {
            return this.ObservationContext.BuildSubject<TContract, TSubject>();
        }

        protected TDependency DependencyOf<TDependency>() where TDependency : class
        {
            return this.ObservationContext.DependencyOf<TDependency>();
        }

        protected void ProvideBasicConstructorArgument<TArgument>(TArgument value)
        {
            this.ObservationContext.ProvideABasicSubjectConstructorArgument(value);
        }
    }
}