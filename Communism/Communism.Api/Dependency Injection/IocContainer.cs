using System;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Communism.Data.EntityFramework;
using Communism.Data.EntityFramework.DataBase;
using Communism.Data.EntityFramework.Repositories;
using Communism.Domain.Contracts;
using Communism.Domain.Services;
using StructureMap;
using StructureMap.Web;

namespace Communism.Api.Dependency_Injection
{
    public static class IocContainer
    {
        private static Container _container;

        public static void Configure()
        {
            var configureExpression = GetContainerConfiguration();

            if (_container == null)
            {
                _container = new Container(configureExpression);
            }
            else
            {
                _container.Configure(configureExpression);
            }
        }

        internal static T GetInstance<T>()
        {
            return _container.GetInstance<T>();
        }

        internal static object GetInstance(Type type)
        {
            return _container.GetInstance(type);
        }

        private static Action<ConfigurationExpression> GetContainerConfiguration()
        {
            return x =>
            {
                x.Scan(y =>
                {
                    y.AssemblyContainingType<UserRepository>();
                    y.WithDefaultConventions();
                    y.AssembliesFromApplicationBaseDirectory(z => z.FullName.EndsWith("Repository"));
                });

                x.Scan(y =>
                {
                    y.AssemblyContainingType<UserQueryService>();
                    y.WithDefaultConventions();
                    y.AssembliesFromApplicationBaseDirectory(z => z.FullName.EndsWith("Services"));
                });

                x.Scan(y =>
                {
                    y.TheCallingAssembly();
                    y.AddAllTypesOf<IController>();
                    y.WithDefaultConventions();
                });
                
                x.Scan(y =>
                {
                    y.TheCallingAssembly();
                    y.AddAllTypesOf<IHttpController>();
                    y.WithDefaultConventions();
                });

                x.For<IUnitOfWork>().HttpContextScoped().Use<UnitOfWork>();
                x.For<CommunismContext>().HttpContextScoped();
            };
        }
    }
}
