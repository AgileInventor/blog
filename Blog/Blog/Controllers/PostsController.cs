using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using System.IO;

namespace Blog.Controllers
{
    public class PostsController : Controller
    {
        private DB_9D8B6E_PAGINASEntities db = new DB_9D8B6E_PAGINASEntities();

        // GET: Posts
        public ActionResult Index()
        {
            var agileInventorPost = db.AgileInventorPost.Include(a => a.AgileInventorCategory);
            return View(agileInventorPost.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgileInventorPost agileInventorPost = db.AgileInventorPost.Find(id);
            if (agileInventorPost == null)
            {
                return HttpNotFound();
            }
            return View(agileInventorPost);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.AgileInventorCategory, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,PostTitle,PostContent,PostDate,PostStatus,CategoryID,URLImagen,URLGitHub")] AgileInventorPost post, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                string ImageName = upload.FileName;
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/uploads/post_caratula"), ImageName);
                upload.SaveAs(path);
                post.URLImagen = "/Content/uploads/post_caratula/" + ImageName;
            }



            if (ModelState.IsValid)
            {
                db.AgileInventorPost.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.AgileInventorCategory, "CategoryID", "CategoryName", post.CategoryID);
            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgileInventorPost agileInventorPost = db.AgileInventorPost.Find(id);
            if (agileInventorPost == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.AgileInventorCategory, "CategoryID", "CategoryName", agileInventorPost.CategoryID);
            return View(agileInventorPost);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,PostTitle,PostContent,PostDate,PostStatus,CategoryID,URLImagen,URLGitHub")] AgileInventorPost post, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                string ImageName = upload.FileName;
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/uploads/post_caratula"), ImageName);
                upload.SaveAs(path);
                post.URLImagen = "/Content/uploads/post_caratula/" + ImageName;
            }
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.AgileInventorCategory, "CategoryID", "CategoryName", post.CategoryID);
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AgileInventorPost agileInventorPost = db.AgileInventorPost.Find(id);
            if (agileInventorPost == null)
            {
                return HttpNotFound();
            }
            return View(agileInventorPost);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AgileInventorPost agileInventorPost = db.AgileInventorPost.Find(id);
            db.AgileInventorPost.Remove(agileInventorPost);
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
