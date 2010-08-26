namespace SpecFlow.AutoMocking.Specs
{
    using System.Data;

    public class DummyClassWithDefaultConstructor
    {
    }

    public class DummyClassWithSingleParameterisedConstructor
    {
        public DummyClassWithSingleParameterisedConstructor(IDbConnection connection)
        {
            this.Connection = connection;
        }

        public IDbConnection Connection { get; set; }
    }

    public class DummyClassWithMultipleParameterisedConstructors
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