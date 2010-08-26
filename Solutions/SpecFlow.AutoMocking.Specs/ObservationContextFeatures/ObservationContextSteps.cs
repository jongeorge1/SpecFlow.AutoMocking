namespace SpecFlow.AutoMocking.Specs.ObservationContextFeatures
{
    using System.Collections;

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

        private IEnumerable result;

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
            Assert.That(this.result, Is.EqualTo(this.theDependency));
        }

        [Then(@"the observation context should use the subject dependency builder to create the mock")]
        public void ThenTheObservationContextShouldUseTheSubjectDependencyBuilderToCreateTheMock()
        {
            this.subjectDependencyBuilder.AssertWasCalled(s => s.DependencyOf<IEnumerable>());
        }

        [When(@"I ask the observation context to create a mock a dependency")]
        public void WhenIAskTheObservationContextToCreateAMockADependency()
        {
            this.theDependency = new ArrayList();
            this.subjectDependencyBuilder.Stub(s => s.DependencyOf<IEnumerable>()).Return(this.theDependency);

            this.result = this.subject.DependencyOf<IEnumerable>();
        }
    }
}