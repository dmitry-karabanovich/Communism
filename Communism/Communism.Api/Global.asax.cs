using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Communism.Api.Configuration.Dependency_Injection;
using Communism.Application.Core.DependencyInjection;

namespace Communism.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ControllerBuilder.Current.SetControllerFactory(new MvcControllerFactory());
            IocContainer.Configure(ApiContainerRegistry.Configure);
        }
    }
}
