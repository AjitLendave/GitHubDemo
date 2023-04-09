using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AreasDemo.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialView1()
        {
            return PartialView("_PartialView1");
        }

        public PartialViewResult PartialView2()
        {
            return PartialView("_PartialView2");
        }

        public PartialViewResult PartialView3()
        {
            return PartialView("_PartialView3");
        }
    }
}