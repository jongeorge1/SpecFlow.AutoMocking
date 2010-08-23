namespace SpecFlow.AutoMocking.Rhino
{
    using System.Diagnostics.CodeAnalysis;

    public abstract class StepDefinitions<TSubject> : StepDefinitions<TSubject, TSubject>
    {
    }

    [SuppressMessage("Microsoft.StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "It's more obvious to put different generic versions of a class in the same file.")]
    public abstract class StepDefinitions<TContract, TSubject> :
        StepDefinitions<TContract, TSubject, RhinoMocksMockFactory> where TSubject : TContract
    {
    }
}