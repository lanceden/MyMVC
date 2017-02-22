using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyMVC
{
    public class MyControllerFactory: DefaultControllerFactory
    {

        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            //MyMVC.PersonSKL
            var ctorName = "MyMVC." + controllerName + "Controller";
            var type = Type.GetType(ctorName);
            if(type == null)
            {
                controllerName = "MyMVC." + controllerName + "SKL";
                type = Type.GetType(controllerName);
            }
            var controller = Activator.CreateInstance(type) as IController;
            return controller;
        }

        public override void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
}