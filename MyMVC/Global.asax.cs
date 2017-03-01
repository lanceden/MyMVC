using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyMVC
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ViewEngineConfig.RegisterViewEngines(ViewEngines.Engines);
            ControllerBuilder.Current.SetControllerFactory(new MyControllerFactory());
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.Write("Session_Start <br>");
        }
        protected void Application_PostResolveRequestCache(object sender,EventArgs e)
        {
            //HttpContext.Current.Response.Write("Application_PostResolveRequestCache <br>");
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.Write("Application_BeginRequest <br>");
        }
        protected void Application_EndRequest(object sender,EventArgs e)
        {
            //HttpContext.Current.Response.Write("Application_EndRequest <br>");
        }
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.Write("Application_Error <br>");
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //HttpContext.Current.Response.Write("Session_End  <br>");
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}