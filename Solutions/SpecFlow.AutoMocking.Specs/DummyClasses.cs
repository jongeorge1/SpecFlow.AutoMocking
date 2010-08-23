namespace SpecFlow.AutoMocking.Specs
{
    using System.Data;

    internal class DummyClassWithDefaultConstructor
    {
    }

    internal class DummyClassWithSingleParameterisedConstructor
    {
        public DummyClassWithSingleParameterisedConstructor(IDbConnection connection)
        {
            this.Connection = connection;
        }

        public IDbConnection Connection { get; set; }
    }

    internal class DummyClassWithMultipleParameterisedConstructors
    {
        public DummyClassWithMultipleParameterisedConstructors(IDbConnection connection)
            : this(connection, null)
        {
        }

        public DummyClassWithMultipleParameterisedConstructors(
            IDbConnection connection, IDbCommand command)
        {
            this.Connection = connection;
            this.Command = command;
        }

        public IDbCommand Command { get; set; }

        public IDbConnection Connection { get; set; }
    }
}