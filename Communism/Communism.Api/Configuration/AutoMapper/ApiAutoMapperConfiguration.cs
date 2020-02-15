using System.Reflection;
using AutoMapper;
using Communism.Application.Core.AutoMapper;

namespace Communism.Api.Configuration.AutoMapper
{
    public class ApiAutoMapperConfiguration : AutoMapperConfiguration
    {
        public override void Configure(IMapperConfigurationExpression configuration)
        {
            configuration.AddProfiles(Assembly.GetExecutingAssembly());
            base.Configure(configuration);
        }
    }
}