namespace SpecFlow.AutoMocking.Core
{
    using System;
    using System.Collections.Generic;

    public interface ISubjectDependencyBuilder
    {
        TDependency DependencyOf<TDependency>() where TDependency : class;
        
        void ProvideABasicSubjectConstructorArgument<TArgument>(TArgument value);
        
        object[] AllDependencies(IEnumerable<Type> enumerable);
        
        void RegisterOnlyIfMissing(Type dependencyType);
    }
}