using System;
using StructureMap;

namespace Communism.Application.Core.DependencyInjection
{
    public class IocContainer
    {
        private static Container _container;

        public static void Configure(Action<ConfigurationExpression> configuration)
        {
            if (_container == null)
            {
                _container = new Container(configuration);
            }
            else
            {
                _container.Configure(configuration);
            }
        }

        internal static object GetInstance(Type type)
        {
            return _container.GetInstance(type);
        }
    }
}
