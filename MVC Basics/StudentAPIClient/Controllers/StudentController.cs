﻿using StudentAPIClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace StudentAPIClient.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<Student> students = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:44305/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Student");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Student>>();
                    readTask.Wait();

                    students = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    students = Enumerable.Empty<Student>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(students);
        }

        public ActionResult Indexajax()
        {
            return View();
        }
    }
}