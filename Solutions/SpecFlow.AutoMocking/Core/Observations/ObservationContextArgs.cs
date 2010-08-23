namespace SpecFlow.AutoMocking.Core.Observations
{
    public class ObservationContextArgs<TContract>
    {
        public IMockFactory MockFactory { get; set; }

        public ITestState<TContract> State { get; set; }

        public object Test { get; set; }
    }
}