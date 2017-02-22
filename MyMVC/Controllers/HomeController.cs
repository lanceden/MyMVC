namespace MyMVC
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Linq;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var personList = new List<Person>();
            for (int i = 1; i <= 100; i++)
            {
                personList.Add(new Person()
                {
                    Id = i,Name = "SKL"+i,Addr = "Taipei"+i
                });
            }
            Session["list"] = personList;
            return View(personList);
        }

        public ActionResult Find(int id)
        {
            var list = Session["list"] as List<Person>;
            var person = list.Where(s => s.Id == id).FirstOrDefault();
            return View(person);
        }
        [HttpPost]
        public ActionResult Post(Person p)
        {
            var list = Session["list"] as List<Person>;
            var person = list.Where(s => s.Id == p.Id).FirstOrDefault();
            list.Remove(person);
            list.Add(p);
            list = list.OrderBy(s => s.Id).ToList();
            return View("Index", list);
        }
        public ActionResult Test()
        {
            Session["test"] = "123";
            return Content(Session["test"].ToString());
        }
        public ActionResult Test2() => Content(Session["test"].ToString());
    }
}