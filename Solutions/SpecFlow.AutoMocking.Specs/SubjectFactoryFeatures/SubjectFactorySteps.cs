namespace SpecFlow.AutoMocking.Specs.SubjectFactoryFeatures
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using global::Rhino.Mocks;

    using NUnit.Framework;

    using SpecFlow.AutoMocking.Core;
    using SpecFlow.AutoMocking.Rhino;

    using TechTalk.SpecFlow;

    [Binding]
    public class SubjectFactorySteps : StepDefinitions<ISubjectFactory, SubjectFactory>
    {
        private readonly ISubjectDependencyBuilder builder;

        private IDbConnection connection;

        private dynamic result;

        private Type targetType;

        public SubjectFactorySteps()
        {
            this.builder = MockRepository.GenerateStub<ISubjectDependencyBuilder>();
        }

        [Then(@"an instance of the subject should be returned")]
        public void ThenAnInstanceOfTheSubjectShouldBeReturned()
        {
            Assert.That(this.result, Is.TypeOf(this.targetType));
        }

        [Then(@"it should pass the constructor parameters retrieved from the subject dependency builder")]
        public void ThenItShouldPassTheConstructorParametersRetrievedFromTheSubjectDependencyBuilder()
        {
            Assert.That(this.result.Connection, Is.EqualTo(this.connection));
        }

        [When(@"I request a subject with dependencies be created")]
        public void WhenIRequestASubjectWithDependenciesBeCreated()
        {
            this.connection = MockRepository.GenerateStub<IDbConnection>();
            this.builder.Stub(
                x => x.AllDependencies(Arg<IEnumerable<Type>>.Matches(args => args.First() == typeof(IDbConnection)))).
                Return(new object[] { this.connection });

            this.targetType = typeof(DummyClassWithSingleParameterisedConstructor);
            this.result =
                this.Subject.Create
                    <DummyClassWithSingleParameterisedConstructor, DummyClassWithSingleParameterisedConstructor>();
        }

        [When(@"I request a subject with no dependencies be created")]
        public void WhenIRequestASubjectWithNoDependenciesBeCreated()
        {
            this.targetType = typeof(DummyClassWithDefaultConstructor);
            this.result = this.Subject.Create<DummyClassWithDefaultConstructor, DummyClassWithDefaultConstructor>();
        }

        protected override ISubjectFactory CreateSubject()
        {
            return new SubjectFactory(this.builder);
        }
    }
}