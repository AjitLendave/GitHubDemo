using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDusingEFDBFirstinMVC.Common1;
using CRUDusingEFDBFirstinMVC.Models;

namespace CRUDusingEFDBFirstinMVC.Controllers
{
    //[Authorize]
    //[CustomHandelError]
    public class studentsController : Controller
    {
        private StudentDBContext db = new StudentDBContext();

        // GET: students
        //[OutputCache(Duration = 60)]
        //[OutputCache(CacheProfile = "Cache10Seconds")]
        //[AllowAnonymous]
        //[HandleError]
        //[CustomHandelError]
        public ActionResult Index()
        {
            //throw new Exception("Problem in Index Page");  //Explicitely thrown
            return View(db.students.ToList());
        }

        //[OutputCache(Duration = 60)]
        //[HttpGet]
        //public PartialViewResult GetPartialView()
        //{
        //    return PartialView("_PartialView");
        //}

        // GET: students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: students/Create
        public ActionResult Create()
        {
            ViewBag.TrainerId = db.Trainers.Select(
               t => new SelectListItem() { Text = t.Name, Value = t.Id.ToString() });

            return View();
        }

        // POST: students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RollNo,Name,Age,email,ConfirmEmail,DoB,city,TrainerId")] student student)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.TrainerId = db.Trainers.Select(
               t => new SelectListItem() { Text = t.Name, Value = t.Id.ToString() });

            return View(student);
        }

        // GET: students/Edit/5
       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            ViewBag.TrainerId = db.Trainers.Select(
             t => new SelectListItem() { Text = t.Name, Value = t.Id.ToString(),
             Selected = t.Id == student.TrainerId});

            return View(student);
        }

        // POST: students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RollNo,Name,Age,email,DoB,city,TrainerId")] student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrainerId = db.Trainers.Select(
             t => new SelectListItem(){ Text = t.Name, Value = t.Id.ToString(),
                                         Selected = t.Id == student.TrainerId
             });

            return View(student);
        }

        // GET: students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult StudentsByTrainer(int? Id)
        {
            //We want to fetch students who belong to input trainer (id) and show on view.

            var Students = db.students.Where(s => s.TrainerId == Id);
            return View(Students);
        }

        [HttpGet]
        public JsonResult IsNameExist( string Name)
        {
            bool isNameExists = db.students.Any(s => s.Name== Name);
                return Json(!isNameExists, JsonRequestBehavior.AllowGet);
        }
    }
}
