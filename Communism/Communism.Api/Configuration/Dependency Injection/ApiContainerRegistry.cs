using System.Web.Http.Controllers;
using System.Web.Mvc;
using AutoMapper;
using Communism.Api.Configuration.AutoMapper;
using Communism.Application.Core.AutoMapper;
using Communism.Application.Core.DependencyInjection.Registry;
using Communism.Data.EntityFramework;
using Communism.Data.EntityFramework.DataBase;
using Communism.Domain.Contracts;
using StructureMap;
using StructureMap.Web;

namespace Communism.Api.Configuration.Dependency_Injection
{
    public class ApiContainerRegistry
    {
        public static void Configure(ConfigurationExpression configuration)
        {
            
            configuration.Scan(y =>
            {
                y.TheCallingAssembly();
                y.AddAllTypesOf<IController>();
                y.WithDefaultConventions();
            });

            configuration.Scan(y =>
            {
                y.TheCallingAssembly();
                y.AddAllTypesOf<IHttpController>();
                y.WithDefaultConventions();
            });

            configuration.For<IConfigurationProvider>()
                .Use(new MapperConfiguration(new ApiAutoMapperConfiguration().Configure))
                .Singleton();
            configuration.For<IMapper>().Use<Mapper>();

            configuration.For<IUnitOfWork>().HttpContextScoped().Use<UnitOfWork>();
            configuration.For<CommunismContext>().HttpContextScoped();

            configuration.AddRegistry<DataRegistry>();
            configuration.AddRegistry<BusinessRegistry>();
        }
    }
}