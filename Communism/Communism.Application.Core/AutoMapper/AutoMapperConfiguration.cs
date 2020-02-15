using System.Reflection;
using AutoMapper;

namespace Communism.Application.Core.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public virtual void Configure(IMapperConfigurationExpression configuration)
        {
            configuration.AddProfiles(Assembly.GetExecutingAssembly());
        }
    }
}
