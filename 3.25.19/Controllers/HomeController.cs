using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Data;

namespace _3._25._19.Controllers
{
    public class HomeController : Controller
    {
        Manager mgr = new Manager(Properties.Settings.Default.ConStr);

        public ActionResult Index()
        {
            return View(mgr.GetPeople());
        }
        public ActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SubmitList(IEnumerable<Person> people)
        {
            mgr.AddPeople(people);
            return Redirect("/home/index");
        }
    }
}