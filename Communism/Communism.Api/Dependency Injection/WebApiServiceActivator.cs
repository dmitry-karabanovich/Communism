using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Communism.Api.Dependency_Injection
{
    public class WebApiServiceActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return IocContainer.GetInstance(controllerType) as IHttpController;
        }
    }
}
