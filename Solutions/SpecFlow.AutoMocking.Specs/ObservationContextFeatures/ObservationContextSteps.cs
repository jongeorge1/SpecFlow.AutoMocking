namespace SpecFlow.AutoMocking.Specs.ObservationContextFeatures
{
    using System.Collections;
    using System.Data;

    using global::Rhino.Mocks;

    using NUnit.Framework;

    using SpecFlow.AutoMocking.Core;
    using SpecFlow.AutoMocking.Core.Observations;

    using TechTalk.SpecFlow;

    [Binding]
    public class ObservationContextSteps
    {
        private IMockFactory mockFactory;

        private ObservationContext<DummyClassWithSingleParameterisedConstructor> subject;

        private ISubjectDependencyBuilder subjectDependencyBuilder;

        private ISubjectFactory subjectFactory;

        private ITestState<DummyClassWithSingleParameterisedConstructor> testState;

        private ArrayList theDependency;

        private IEnumerable theReturnedDependency;

        private DummyClassWithSingleParameterisedConstructor theReturnedSubject;

        private DummyClassWithSingleParameterisedConstructor theSubject;

        [Given(@"I have an observation context")]
        public void GivenIHaveAnObservationContext()
        {
            this.testState = MockRepository.GenerateMock<ITestState<DummyClassWithSingleParameterisedConstructor>>();
            this.subjectDependencyBuilder = MockRepository.GenerateMock<ISubjectDependencyBuilder>();
            this.mockFactory = MockRepository.GenerateMock<IMockFactory>();
            this.subjectFactory = MockRepository.GenerateMock<ISubjectFactory>();

            this.subject = new ObservationContext<DummyClassWithSingleParameterisedConstructor>(
                this.testState, this.subjectDependencyBuilder, this.mockFactory, this.subjectFactory);
        }

        [Then(@"the mock should be returned")]
        public void ThenTheMockShouldBeReturned()
        {
            Assert.That(this.theReturnedDependency, Is.EqualTo(this.theDependency));
        }

        [Then(@"the observation context should use the subject dependency builder to create the mock")]
        public void ThenTheObservationContextShouldUseTheSubjectDependencyBuilderToCreateTheMock()
        {
            this.subjectDependencyBuilder.AssertWasCalled(s => s.DependencyOf<IEnumerable>());
        }

        [Then(@"the observation context should use the subject factory to create the subject")]
        public void ThenTheObservationContextShouldUseTheSubjectFactoryToCreateTheSubject()
        {
            this.subjectFactory.AssertWasCalled(f => f.Create<DummyClassWithSingleParameterisedConstructor, DummyClassWithSingleParameterisedConstructor>());
        }

        [Then(@"the subject should be returned")]
        public void ThenTheSubjectShouldBeReturned()
        {
            Assert.That(this.theReturnedSubject, Is.EqualTo(this.theSubject));
        }

        [When(@"I ask the observation context to create a mock a dependency")]
        public void WhenIAskTheObservationContextToCreateAMockADependency()
        {
            this.theDependency = new ArrayList();
            this.subjectDependencyBuilder.Stub(s => s.DependencyOf<IEnumerable>()).Return(this.theDependency);

            this.theReturnedDependency = this.subject.DependencyOf<IEnumerable>();
        }

        [When(@"I ask the observation context to create the subject")]
        public void WhenIAskTheObservationContextToCreateTheSubject()
        {
            this.theSubject = new DummyClassWithSingleParameterisedConstructor(MockRepository.GenerateMock<IDbConnection>());
            this.subjectFactory.Stub(
                f =>
                f.Create<DummyClassWithSingleParameterisedConstructor, DummyClassWithSingleParameterisedConstructor>()).
                Return(this.theSubject);

            this.theReturnedSubject = this.subject.BuildSubject<DummyClassWithSingleParameterisedConstructor, DummyClassWithSingleParameterisedConstructor>();
        }
    }
}