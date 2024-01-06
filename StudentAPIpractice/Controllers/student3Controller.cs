using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StudentAPIpractice.Models;

namespace StudentAPIpractice.Controllers
{    [AllowAnonymous]
    public class student3Controller : ApiController
    {
        private StudentDBEntities db = new StudentDBEntities();

        [HttpGet]
        // GET: api/student3
        public IQueryable<student3> Getstudent3()
        {
            return db.student3;
        }

        [HttpGet]
        // GET: api/student3/5
        [ResponseType(typeof(student3))]
        public IHttpActionResult Getstudent3(int id)
        {
            student3 student3 = db.student3.Find(id);
            if (student3 == null)
            {
                return NotFound();
            }

            return Ok(student3);
        }

        [HttpPut]
        // PUT: api/student3/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putstudent3(int id, student3 student3)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student3.RollNo)
            {
                return BadRequest();
            }

            db.Entry(student3).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!student3Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        // POST: api/student3
        [ResponseType(typeof(student3))]
        public IHttpActionResult Poststudent3(student3 student3)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.student3.Add(student3);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = student3.RollNo }, student3);
        }

        [HttpDelete]
        // DELETE: api/student3/5
        [ResponseType(typeof(student3))]
        public IHttpActionResult Deletestudent3(int id)
        {
            student3 student3 = db.student3.Find(id);
            if (student3 == null)
            {
                return NotFound();
            }

            db.student3.Remove(student3);
            db.SaveChanges();

            return Ok(student3);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool student3Exists(int id)
        {
            return db.student3.Count(e => e.RollNo == id) > 0;
        }
    }
}