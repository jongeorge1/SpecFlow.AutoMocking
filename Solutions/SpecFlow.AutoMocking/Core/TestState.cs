namespace SpecFlow.AutoMocking.Core
{
    using System;
    using System.Collections.Generic;

    public class TestState<TSubject> : ITestState<TSubject>
    {
        public TestState(object test, Func<TSubject> factory)
        {
            this.Test = test;
            this.Factory = factory;

            this.Dependencies = new Dictionary<Type, object>();
        }

        public TSubject Subject { get; set; }

        private IDictionary<Type, object> Dependencies { get; set; }

        private Func<TSubject> Factory { get; set; }

        private object Test { get; set; }

        public TDependency GetDependency<TDependency>()
        {
            return (TDependency)this.Dependencies[typeof(TDependency)];
        }

        public object GetTheProvidedDependencyAssignableFrom(Type constructorParameterType)
        {
            return this.Dependencies[constructorParameterType];
        }

        public bool HasNoDependencyFor<TInterface>()
        {
            return this.HasNoDependencyFor(typeof(TInterface));
        }

        public bool HasNoDependencyFor(Type dependencyType)
        {
            return ! this.Dependencies.ContainsKey(dependencyType);
        }

        public void RegisterDependencyForSubject(Type dependencyType, object instance)
        {
            this.Dependencies[dependencyType] = instance;
        }

        public void StoreDependency(Type type, object instance)
        {
            this.Dependencies.Add(type, instance);
        }

        public void BuildSubject()
        {
            this.Subject = this.Factory();
        }
    }
}