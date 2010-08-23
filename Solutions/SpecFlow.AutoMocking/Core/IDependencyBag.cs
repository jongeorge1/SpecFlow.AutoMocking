namespace SpecFlow.AutoMocking.Core
{
    using System;

    public interface IDependencyBag
    {
        void StoreDependency(Type type, object instance);
        
        TDependency GetDependency<TDependency>();
        
        bool HasNoDependencyFor<TDependency>();
        
        void RegisterDependencyForSubject(Type dependencyType, object instance);
        
        bool HasNoDependencyFor(Type dependencyType);
        
        object GetTheProvidedDependencyAssignableFrom(Type constructorParameterType);
    }
}