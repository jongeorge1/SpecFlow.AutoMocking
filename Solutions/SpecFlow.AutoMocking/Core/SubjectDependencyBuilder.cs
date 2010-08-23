namespace SpecFlow.AutoMocking.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SpecFlow.AutoMocking.Core.Extensions;

    public class SubjectDependencyBuilder : ISubjectDependencyBuilder
    {
        private readonly IDependencyBag dependencyBag;

        private readonly IMockFactory mockFactory;

        public SubjectDependencyBuilder(IDependencyBag dependencyBag, IMockFactory mockFactory)
        {
            this.dependencyBag = dependencyBag;
            this.mockFactory = mockFactory;
        }

        public object[] AllDependencies(IEnumerable<Type> constructorParameterTypes)
        {
            return
                constructorParameterTypes.Select(
                    parameter => this.dependencyBag.GetTheProvidedDependencyAssignableFrom(parameter)).ToArray();
        }

        public TDependency DependencyOf<TDependency>() where TDependency : class
        {
            if (this.dependencyBag.HasNoDependencyFor<TDependency>())
            {
                this.dependencyBag.StoreDependency(typeof(TDependency), this.mockFactory.CreateStub<TDependency>());
            }

            return this.dependencyBag.GetDependency<TDependency>();
        }

        public void ProvideABasicSubjectConstructorArgument<TArgument>(TArgument value)
        {
            this.StoreASubjectConstructorArgument(value);
        }

        public void RegisterOnlyIfMissing(Type dependencyType)
        {
            if (this.DependencyNeedsToBeRegisteredFor(dependencyType))
            {
                this.dependencyBag.RegisterDependencyForSubject(
                    dependencyType, this.mockFactory.CreateStub(dependencyType));
            }
        }

        private static bool IsADepedencyThatCanAutomaticallyBeCreated(Type dependencyType)
        {
            return ! dependencyType.IsValueType;
        }

        private bool DependencyNeedsToBeRegisteredFor(Type dependencyType)
        {
            return this.dependencyBag.HasNoDependencyFor(dependencyType) &&
                   IsADepedencyThatCanAutomaticallyBeCreated(dependencyType);
        }

        private void EnsureTheDependencyHasNotAlreadyBeenRegister<TArgument>()
        {
            if (! this.dependencyBag.HasNoDependencyFor<TArgument>())
            {
                throw new ArgumentException(
                    string.Format("A dependency has already been provided for :{0}", typeof(TArgument).ProperName()));
            }
        }

        private void StoreASubjectConstructorArgument<TArgument>(TArgument argument)
        {
            this.EnsureTheDependencyHasNotAlreadyBeenRegister<TArgument>();
            this.dependencyBag.StoreDependency(typeof(TArgument), argument);
        }
    }
}