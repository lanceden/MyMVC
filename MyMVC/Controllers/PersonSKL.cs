using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVC
{
    public class PersonSKL:Controller
    {
        public ActionResult Index()
        {
            var p = new Person();
            return View();
        }
    }
}