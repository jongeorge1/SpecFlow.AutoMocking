namespace SpecFlow.AutoMocking.Core
{
    using System;

    public interface IMockFactory
    {
        TDependency CreateStub<TDependency>() where TDependency : class;
        
        object CreateStub(Type type);
    }
}