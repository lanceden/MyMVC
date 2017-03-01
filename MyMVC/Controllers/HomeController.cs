namespace MyMVC
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Linq;
    using Respotiroy;

    public class HomeController : Controller
    {
        PersonRepository _personRes = new PersonRepository();
        IList<Person> personList = null;
        public HomeController()
        {
            personList = _personRes.Get();
        }

    }
}