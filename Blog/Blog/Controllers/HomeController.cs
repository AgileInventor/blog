using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        private DB_9D8B6E_PAGINASEntities db = new DB_9D8B6E_PAGINASEntities();

        public ActionResult Index()
        {
            var posts = db.AgileInventorPost.Include(p => p.AgileInventorCategory);
            return View(posts.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

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