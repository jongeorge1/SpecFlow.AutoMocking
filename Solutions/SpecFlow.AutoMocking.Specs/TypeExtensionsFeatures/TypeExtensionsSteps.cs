namespace SpecFlow.AutoMocking.Specs.TypeExtensionsFeatures
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using NUnit.Framework;

    using SpecFlow.AutoMocking.Core.Extensions;

    using TechTalk.SpecFlow;

    [Binding]
    public class TypeExtensionsSteps
    {
        private string expectedResultName;

        private ConstructorInfo result;

        private string resultName;

        private Type targetType;

        [Given(@"I have a class with a multiple type parameters")]
        public void GivenIHaveAClassWithAMultipleTypeParameters()
        {
            this.expectedResultName = "Tuple`2<System.Int32><System.String>";
            this.targetType = typeof(Tuple<int, string>);
        }

        [Given(@"I have a class with a single type parameter")]
        public void GivenIHaveAClassWithASingleTypeParameter()
        {
            this.expectedResultName = "List`1<System.Int32>";
            this.targetType = typeof(List<int>);
        }

        [Given(@"I have a class with no type parameters")]
        public void GivenIHaveAClassWithNoTypeParameters()
        {
            this.expectedResultName = "Type";
            this.targetType = typeof(Type);
        }

        [Given(@"I have a type that has a single parameterised constructor")]
        public void GivenIHaveATypeThatHasASingleParameterisedConstructor()
        {
            this.targetType = typeof(DummyClassWithSingleParameterisedConstructor);
        }

        [Given(@"I have a type that multiple parameterised constructors")]
        public void GivenIHaveATypeThatMultipleParameterisedConstructors()
        {
            this.targetType = typeof(DummyClassWithMultipleParameterisedConstructors);
        }

        [Given(@"I have a type that only has the default constructor")]
        public void GivenIHaveATypeThatOnlyHasTheDefaultConstructor()
        {
            this.targetType = typeof(DummyClassWithDefaultConstructor);
        }

        [Then(@"the constructor with the most parameters should be returned")]
        public void ThenTheConstructorWithTheMostParametersShouldBeReturned()
        {
            this.AssertExpectedConstructorIsReturned(2);
        }

        [Then(@"the default constructor should be returned")]
        public void ThenTheDefaultConstructorShouldBeReturned()
        {
            this.AssertExpectedConstructorIsReturned(0);
        }

        [Then(@"the result should contain the proper name for the type")]
        public void ThenTheResultShouldContainTheProperNameForTheType()
        {
            Assert.That(this.resultName, Is.EqualTo(this.expectedResultName));
        }

        [Then(@"the single constructor should be returned")]
        public void ThenTheSingleConstructorShouldBeReturned()
        {
            this.AssertExpectedConstructorIsReturned(1);
        }

        [When(@"I ask for the greediest constructor")]
        public void WhenIAskForTheGreediestConstructor()
        {
            this.result = this.targetType.GreediestConstructor();
        }

        [When(@"I ask for the proper name")]
        public void WhenIAskForTheProperName()
        {
            this.resultName = this.targetType.ProperName();
        }

        private void AssertExpectedConstructorIsReturned(int expectedParameters)
        {
            Assert.That(this.result.GetParameters().Length, Is.EqualTo(expectedParameters));
        }
    }
}