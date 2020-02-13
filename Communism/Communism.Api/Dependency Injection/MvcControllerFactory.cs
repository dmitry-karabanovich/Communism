using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Communism.Api.Dependency_Injection
{
    public class MvcControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                return base.GetControllerInstance(requestContext, controllerType);
            }

            return (IController) IocContainer.GetInstance(controllerType);
        }
    }
}
