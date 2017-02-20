namespace MyMVC
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ActionResult Index() => View();
        public ActionResult Test() => View();
    }
}