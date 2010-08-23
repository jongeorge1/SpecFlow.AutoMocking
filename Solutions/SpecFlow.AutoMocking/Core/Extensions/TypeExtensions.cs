namespace SpecFlow.AutoMocking.Core.Extensions
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public static class TypeExtensions
    {
        public const string GenericArgumentTypeFormat = "<{0}>";

        public static ConstructorInfo GreediestConstructor(this Type type)
        {
            return type.GetConstructors().OrderByDescending(x => x.GetParameters().Count()).First();
        }

        public static string ProperName(this Type type)
        {
            var message = new StringBuilder(type.Name);
            if (!type.IsGenericType)
            {
                return message.ToString();
            }

            foreach (var current in type.GetGenericArguments())
            {
                message.AppendFormat(GenericArgumentTypeFormat, current);
            }

            return message.ToString();
        }
    }
}