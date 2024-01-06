using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractice.Controllers
{         
    public class HomeController : Controller
    {
        public ActionResult WelCome()
        {
            return View();
        }
    }
}