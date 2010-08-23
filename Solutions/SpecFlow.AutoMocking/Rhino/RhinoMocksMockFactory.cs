namespace SpecFlow.AutoMocking.Rhino
{
    using System;

    using global::Rhino.Mocks;

    using SpecFlow.AutoMocking.Core;

    public class RhinoMocksMockFactory : IMockFactory
    {
        #region MockFactory Members

        public TDependency CreateStub<TDependency>() where TDependency : class
        {
            return MockRepository.GenerateStub<TDependency>();
        }

        public object CreateStub(Type type)
        {
            return MockRepository.GenerateStub(type);
        }

        #endregion
    }
}