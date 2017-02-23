namespace MyMVC
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Linq;

    public class HomeController : Controller
    {
        List<Person> personList = null;
        public HomeController()
        {
            personList = new List<Person>();
            for (int i = 1; i <= 100; i++)
            {
                personList.Add(new Person()
                {
                    Id = i,
                    Name = "SKL" + i,
                    Addr = "Taipei" + i
                });
            }
        }
        public ActionResult Index()
        {
            Session["list"] = personList;
            return View(personList);
        }
        [HttpGet]
        public ActionResult GetList() => Json(new { data = personList }, JsonRequestBehavior.AllowGet);

        [HttpGet]
        public ActionResult Find(int id)
        {
            personList = Session["list"] as List<Person>;
            var person = personList.Where(s => s.Id == id).FirstOrDefault();
            return Json(new { status = "ok", data = person }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Post(Person p)
        {
            personList = Session["list"] as List<Person>;
            personList.Remove(personList.Where(s => s.Id == p.Id).FirstOrDefault());
            personList.Add(p);
            return Json(new { status = "ok" });
        }
        public ActionResult Test()
        {
            Session["test"] = "123";
            return Content(Session["test"].ToString());
        }
        public ActionResult Test2() => Content(Session["test"].ToString());
    }
}