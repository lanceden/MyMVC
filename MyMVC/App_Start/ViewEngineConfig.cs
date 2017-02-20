using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVC
{
    public static class ViewEngineConfig
    {
        public static void RegisterViewEngines(ViewEngineCollection viewEngines)
        {
            //1. 移除所有的VIewENgine
            ViewEngines.Engines.Clear();
            viewEngines.Add(new CSharpRazorViewEngine());
        }

        protected class CSharpRazorViewEngine : RazorViewEngine
        {
            public CSharpRazorViewEngine()
            {
                AreaViewLocationFormats = new[]
                {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };
                AreaMasterLocationFormats = new[]
                {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };
                AreaPartialViewLocationFormats = new[]
                {
                "~/Areas/{2}/Views/{1}/{0}.cshtml",
                "~/Areas/{2}/Views/Shared/{0}.cshtml"
            };

                ViewLocationFormats = new[]
                {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };
                MasterLocationFormats = new[]
                {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml",
            };
                PartialViewLocationFormats = new[]
                {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };

                FileExtensions = new[]
                {
                "cshtml"
            };
            }
        }
    }
}