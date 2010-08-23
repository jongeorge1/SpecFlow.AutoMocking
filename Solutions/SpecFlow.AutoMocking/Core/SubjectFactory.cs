namespace SpecFlow.AutoMocking.Core
{
    using System;
    using System.Linq;

    using SpecFlow.AutoMocking.Core.Extensions;

    public class SubjectFactory : ISubjectFactory
    {
        private readonly ISubjectDependencyBuilder dependencyBuilder;

        public SubjectFactory(ISubjectDependencyBuilder dependencyBuilder)
        {
            this.dependencyBuilder = dependencyBuilder;
        }

        public TContract Create<TContract, TClass>()
        {
            var constructor = typeof(TClass).GreediestConstructor();
            var constructorParameterTypes =
                constructor.GetParameters().Select(constructorArg => constructorArg.ParameterType);

            foreach (var current in constructorParameterTypes)
            {
                this.dependencyBuilder.RegisterOnlyIfMissing(current);
            }

            return
                (TContract)
                Activator.CreateInstance(
                    typeof(TClass), this.dependencyBuilder.AllDependencies(constructorParameterTypes));
        }
    }
}