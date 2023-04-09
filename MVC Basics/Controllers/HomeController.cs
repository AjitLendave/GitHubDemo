using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Basics.Controllers
{   
    //[RoutePrefix("Scoopen")]
    //[Route("Scoopen/Home")]
    public class HomeController : Controller
    {   //[Route("Home")]
        //public string Welcome(int? id)
        //{
        //    return "Welcome to MVC. You Entered = " + id;

        //}
        [HttpGet]
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Welcome(int? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string employeename)
        {
            ViewBag.Name = employeename;
            return View ("~/Views/Home/Welcome.cshtml");
        }

        [HttpGet]
        public ActionResult Index()
        {    //Data from API or Database

               //ViewBag
            // ViewBag.Name = "Rahul Jawale";
            // ViewBag.employees = new string[] { "Komal", "Shital", "Mayuri" };

                //ViewData
            //ViewData["Name"] = "Rahul Jawale";
            //ViewData["employees"] = new string[] { "Komal", "Shital", "Mayuri" };

               //TempData
             TempData["Name"] = "Rahul Jawale";
             TempData["employees"] = new string[] { "Komal", "Shital", "Mayuri" };
            return View();
        }

        [HttpGet]
        public ActionResult Index1()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RazorDemo()
        {
            return View();
        }
    }
}