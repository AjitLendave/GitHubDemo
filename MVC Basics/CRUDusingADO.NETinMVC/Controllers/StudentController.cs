using CRUDusingADO.NETinMVC.Models;
using CRUDusingADO.NETinMVC.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CRUDusingADO.NETinMVC.Controllers
{
    public class StudentController : Controller
    {
        SqlB1DbHelper db = new SqlB1DbHelper();

        // GET: Student
        //I want to show list of student
        public ActionResult Index()
        {
            List<Student> students = db.GetStudents();
            return View(students);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {   //create student
            return View();
        }

        [HttpPost]
        // public ActionResult Create(string Name, string Age, string Email, string DoB, string City, string TrainerId)//Simple Type as Parameter 
        //public ActionResult Create(FormCollection form)    //formcollection class
        //public ActionResult Create(Student student)   // Model as a parameter
        [ActionName("Create")]
        public ActionResult Create_Post()  //update model method
        {    //UI values which user inserts
             //this mtd needs to insert values in database

            //Student student = new Student() 
            //{

            //     Name = Name,
            //    Age = Convert.ToInt32(Age),
            //    Email = Email,
            //    DoB = Convert.ToDateTime(DoB),
            //    City = City,
            //    TrainerId = Convert.ToInt32(TrainerId)
            //};


            //Student student = new Student()
            //{
            //    Name = form["Name"],
            //    Age = Convert.ToInt32(form["Age"]),
            //    Email = form["Email"],
            //    DoB = Convert.ToDateTime(form["DoB"]),
            //    City = form["City"],
            //    TrainerId = Convert.ToInt32(form["TrainerId"])
            //};

            int RN;

            Student student = new Student();  //created object of student model
            UpdateModel<Student>(student);  //Pass object of Student model to Updatemodel method(mtd name)

            if (db.InsertStudent(student, out RN))
            {
                return RedirectToAction("Index");  //Student Inserted Successfully
            }
            else
            {
                ViewBag.Error = "Something went Wrong";
                return View();  //Student Creation Failed & Stay on create page
            }
        }
        public ActionResult Details(int? rollnumber)
        {
            //I want to details of student from database & show in UI

            Student student = db.GetStudent(rollnumber ?? 0);  //null hai to 0 lo
               
            return View(student);  //student data/ student UI
        }

        [HttpGet]
        public ActionResult Edit(int? rollnumber)
        {
            //Edit/Update Student
            //I want to details of student in editable form from database & show in UI
            Student student = db.GetStudent(rollnumber ?? 0);
           
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            if (db.UpdateStudent(student))
            {
                return RedirectToAction("Index");  //Student edited Successfully
            }
            else
            {
                ViewBag.Error = "Something went Wrong";
                return View();  //Student Edition Failed & Stay on edit page
            }
        }


        [HttpGet]
        public ActionResult Delete(int? rollnumber)
        {
            //Delete Student
            //I want to delete stdent from database & show in UI
            Student student = db.GetStudent(rollnumber ?? 0);

            return View(student);
        }

        [HttpPost]
        public ActionResult Delete(string RollNo)
        {
            if (db.DeleteStudent(Convert.ToInt32(RollNo)))
            {
                return RedirectToAction("Index");  //Student deleted Successfully
            }
            else
            {
                ViewBag.Error = "Something went Wrong";
                return View();  //Student Deletion Failed & Stay on delete page
            }
        }

    }
}