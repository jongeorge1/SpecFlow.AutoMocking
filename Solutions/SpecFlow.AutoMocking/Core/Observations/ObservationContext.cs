namespace SpecFlow.AutoMocking.Core.Observations
{
    public class ObservationContext<TSubject> : IObservationContext
    {
        public ObservationContext(
            ITestState<TSubject> testStateImplementation,
            ISubjectDependencyBuilder subjectDependencyBuilder,
            IMockFactory mockFactory,
            ISubjectFactory subjectFactory)
        {
            this.MockFactory = mockFactory;
            this.TestState = testStateImplementation;
            this.SubjectDependencyBuilder = subjectDependencyBuilder;
            this.SubjectFactory = subjectFactory;
        }

        private IMockFactory MockFactory { get; set; }

        private ISubjectDependencyBuilder SubjectDependencyBuilder { get; set; }

        private ISubjectFactory SubjectFactory { get; set; }

        private ITestState<TSubject> TestState { get; set; }

        public TInterface An<TInterface>() where TInterface : class
        {
            return this.MockFactory.CreateStub<TInterface>();
        }

        public TContract BuildSubject<TContract, TClass>()
        {
            return this.SubjectFactory.Create<TContract, TClass>();
        }

        public TDependency DependencyOf<TDependency>() where TDependency : class
        {
            return this.SubjectDependencyBuilder.DependencyOf<TDependency>();
        }

        public void ProvideABasicSubjectConstructorArgument<TArgument>(TArgument value)
        {
            this.SubjectDependencyBuilder.ProvideABasicSubjectConstructorArgument(value);
        }
    }
}