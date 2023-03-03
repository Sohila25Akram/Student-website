using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace secondProject
{
    public class tblTeachersController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblTeachers
        public ActionResult Index()
        {
            var tblTeachers = db.tblTeachers.Include(t => t.tblDepartment);
            return View(tblTeachers.ToList());
        }

        // GET: tblTeachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTeacher tblTeacher = db.tblTeachers.Find(id);
            if (tblTeacher == null)
            {
                return HttpNotFound();
            }
            return View(tblTeacher);
        }

        // GET: tblTeachers/Create
        public ActionResult Create()
        {
            ViewBag.depId = new SelectList(db.tblDepartments, "id", "depName");
            return View();
        }

        // POST: tblTeachers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,tcname,tcage,tcaddress,tcemail,telphone,depId")] tblTeacher tblTeacher)
        {
            if (ModelState.IsValid)
            {
                db.tblTeachers.Add(tblTeacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.depId = new SelectList(db.tblDepartments, "id", "depName", tblTeacher.depId);
            return View(tblTeacher);
        }

        // GET: tblTeachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTeacher tblTeacher = db.tblTeachers.Find(id);
            if (tblTeacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.depId = new SelectList(db.tblDepartments, "id", "depName", tblTeacher.depId);
            return View(tblTeacher);
        }

        // POST: tblTeachers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,tcname,tcage,tcaddress,tcemail,telphone,depId")] tblTeacher tblTeacher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTeacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.depId = new SelectList(db.tblDepartments, "id", "depName", tblTeacher.depId);
            return View(tblTeacher);
        }

        // GET: tblTeachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTeacher tblTeacher = db.tblTeachers.Find(id);
            if (tblTeacher == null)
            {
                return HttpNotFound();
            }
            return View(tblTeacher);
        }

        // POST: tblTeachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTeacher tblTeacher = db.tblTeachers.Find(id);
            db.tblTeachers.Remove(tblTeacher);
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
