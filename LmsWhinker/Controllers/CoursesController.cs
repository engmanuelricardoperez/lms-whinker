using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LmsWhinker.Context;

namespace LmsWhinker.Controllers
{
    public class CoursesController : Controller
    {
        private LmsWhinkerEntities db = new LmsWhinkerEntities();

        // GET: courses
        public ActionResult Index()
        {
            var courses = db.courses.Include(c => c.typeCourse);
            return View(courses.ToList());
        }

        // GET: courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: courses/Create
        public ActionResult Create()
        {
            ViewBag.idTypeCourse = new SelectList(db.typeCourses, "idTypeCourse", "Name");
            return View();
        }

        // POST: courses/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCourse,idTypeCourse,content1,content2,creditFee,featuredImage,requirements,status,title")] course course)
        {
            if (ModelState.IsValid)
            {
                course.userCreation = User.Identity.Name.ToString();
                course.userChange = User.Identity.Name.ToString();
                course.dateCreation = DateTime.Now;
                course.dateChange = DateTime.Now;
                db.courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idTypeCourse = new SelectList(db.typeCourses, "idTypeCourse", "userCreation", course.idTypeCourse);
            return View(course);
        }

        // GET: courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.idTypeCourse = new SelectList(db.typeCourses, "idTypeCourse", "userCreation", course.idTypeCourse);
            return View(course);
        }

        // POST: courses/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCourse,idTypeCourse,content1,content2,creditFee,featuredImage,requirements,status,title,dateCreation,userCreation,dateChange,userChange")] course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idTypeCourse = new SelectList(db.typeCourses, "idTypeCourse", "userCreation", course.idTypeCourse);
            return View(course);
        }

        // GET: courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            course course = db.courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            course course = db.courses.Find(id);
            db.courses.Remove(course);
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
    }
}
