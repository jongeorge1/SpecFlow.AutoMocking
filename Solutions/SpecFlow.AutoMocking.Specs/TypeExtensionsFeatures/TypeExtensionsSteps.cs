namespace SpecFlow.AutoMocking.Specs.TypeExtensionsFeatures
{
    using System;
    using System.Reflection;

    using NUnit.Framework;

    using SpecFlow.AutoMocking.Core.Extensions;

    using TechTalk.SpecFlow;

    [Binding]
    public class TypeExtensionsSteps
    {
        private Type targetType;

        private ConstructorInfo result;

        [Given(@"I have a type that multiple parameterised constructors")]
        public void GivenIHaveATypeThatMultipleParameterisedConstructors()
        {
            this.targetType = typeof(TypeExtensionDummyClassWithMultipleParameterisedConstructors);
        }
        
        [Given(@"I have a type that has a single parameterised constructor")]
        public void GivenIHaveATypeThatHasASingleParameterisedConstructor()
        {
            this.targetType = typeof(TypeExtensionDummyClassWithSingleParameterisedConstructor);
        }

        [Given(@"I have a type that only has the default constructor")]
        public void GivenIHaveATypeThatOnlyHasTheDefaultConstructor()
        {
            this.targetType = typeof(TypeExtensionDummyClassWithDefaultConstructor);
        }

        [When(@"I ask for the greediest constructor")]
        public void WhenIAskForTheGreediestConstructor()
        {
            this.result = this.targetType.GreediestConstructor();
        }

        [Then(@"the default constructor should be returned")]
        public void ThenTheDefaultConstructorShouldBeReturned()
        {
            this.AssertExpectedConstructorIsReturned(0);
        }

        [Then(@"the constructor with the most parameters should be returned")]
        public void ThenTheConstructorWithTheMostParametersShouldBeReturned()
        {
            this.AssertExpectedConstructorIsReturned(2);
        }

        [Then(@"the single constructor should be returned")]
        public void ThenTheSingleConstructorShouldBeReturned()
        {
            this.AssertExpectedConstructorIsReturned(1);
        }

        private void AssertExpectedConstructorIsReturned(int expectedParameters)
        {
            Assert.That(this.result.GetParameters().Length, Is.EqualTo(expectedParameters));
        }

    }
}