using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;

namespace Blog.Controllers
{
    public class CategoriesController : Controller
    {
        private DB_9D8B6E_PAGINASEntities db = new DB_9D8B6E_PAGINASEntities();

        // GET: Categories
        public ActionResult Index()
        {
            return View(db.AgileInventorCategory.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgileInventorCategory agileInventorCategory = db.AgileInventorCategory.Find(id);
            if (agileInventorCategory == null)
            {
                return HttpNotFound();
            }
            return View(agileInventorCategory);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName")] AgileInventorCategory agileInventorCategory)
        {
            if (ModelState.IsValid)
            {
                db.AgileInventorCategory.Add(agileInventorCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agileInventorCategory);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgileInventorCategory agileInventorCategory = db.AgileInventorCategory.Find(id);
            if (agileInventorCategory == null)
            {
                return HttpNotFound();
            }
            return View(agileInventorCategory);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName")] AgileInventorCategory agileInventorCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agileInventorCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agileInventorCategory);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgileInventorCategory agileInventorCategory = db.AgileInventorCategory.Find(id);
            if (agileInventorCategory == null)
            {
                return HttpNotFound();
            }
            return View(agileInventorCategory);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgileInventorCategory agileInventorCategory = db.AgileInventorCategory.Find(id);
            db.AgileInventorCategory.Remove(agileInventorCategory);
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
