using System.Web.Http;
using System.Web.Http.Dispatcher;
using Communism.Application.Core.DependencyInjection;

namespace Communism.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Services.Replace(typeof(IHttpControllerActivator), new WebApiServiceActivator());
        }
    }
}
