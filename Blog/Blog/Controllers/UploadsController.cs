using Blog.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class UploadsController : Controller
    {
        public void uploadnow(HttpPostedFileWrapper upload)
        {
            if (upload != null)
            {
                string ImageName = upload.FileName;
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/uploads/post"), ImageName);
                upload.SaveAs(path);
            }
        }

        public ActionResult uploadPartial()
        {
            var appData = Server.MapPath("~/Content/uploads/post");
            var images = Directory.GetFiles(appData).Select(x => new ImagesViewModel
            {
                Url = Url.Content("/Content/uploads/post/" + Path.GetFileName(x))
            });
            return View(images);
        }
    }
}