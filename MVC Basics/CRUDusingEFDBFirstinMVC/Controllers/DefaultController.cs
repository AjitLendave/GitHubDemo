using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDusingEFDBFirstinMVC.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        //[NonAction]
        //[RequireHttps]
        [ChildActionOnly]
        [HttpGet]
        public ActionResult Post()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public string Post(string Comment)
        {
           return Comment;
        }
    }
}