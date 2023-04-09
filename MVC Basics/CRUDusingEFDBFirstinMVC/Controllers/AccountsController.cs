using CRUDusingEFDBFirstinMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDusingEFDBFirstinMVC.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

    }
}