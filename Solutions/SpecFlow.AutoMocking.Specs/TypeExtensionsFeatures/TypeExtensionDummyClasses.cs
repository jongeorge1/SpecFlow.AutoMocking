namespace SpecFlow.AutoMocking.Specs.TypeExtensionsFeatures
{
    using System.Data;

    internal class TypeExtensionDummyClassWithDefaultConstructor
    {
    }

    internal class TypeExtensionDummyClassWithSingleParameterisedConstructor
    {
        public TypeExtensionDummyClassWithSingleParameterisedConstructor(IDbConnection connection)
        {
            this.Connection = connection;
        }

        public IDbConnection Connection { get; set; }
    }

    internal class TypeExtensionDummyClassWithMultipleParameterisedConstructors
    {
        public TypeExtensionDummyClassWithMultipleParameterisedConstructors(IDbConnection connection)
            : this(connection, null)
        {
        }

        public TypeExtensionDummyClassWithMultipleParameterisedConstructors(
            IDbConnection connection, IDbCommand command)
        {
            this.Connection = connection;
            this.Command = command;
        }

        public IDbCommand Command { get; set; }

        public IDbConnection Connection { get; set; }
    }
}