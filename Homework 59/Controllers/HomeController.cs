using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework_59.CL;
using Homework_59.Models;
using System.IO;

namespace Homework_59.Controllers
{
    public class HomeController : Controller
    {
        ImagesManager mgr = new ImagesManager(Properties.Settings.Default.ConStr);

        public ActionResult Index()
        {
            return View(mgr.GetAllImages());
        }

        public ActionResult UploadImages()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(string title, HttpPostedFileBase image)
        {
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName.ToString());
            image.SaveAs(Server.MapPath("~/UploadedImages/") + fileName);
            mgr.AddImage(new Images { Title = title, FileName = fileName });
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public void LikeCount(int id)
        {
            Session["Liked"] += id.ToString() + ",";
            mgr.AddLikeForId(id);
        }

        public ActionResult ViewSingle(int id)
        {
            var vm = new LikeViewModel();
            vm.Message = "Like";
            if (Session["Liked"] != null)
            {
                string ids = Session["Liked"].ToString();
                if (ids.Contains(id.ToString()))
                {
                    vm.Message = "You liked this image!";
                }
            }
            vm.HighestId = mgr.GetHighestId();
            vm.Image = mgr.GetImageForId(id);
            return View(vm);
        }

        public ActionResult GetLikes(int id)
        {
            return Json(mgr.GetLikesForId(id),JsonRequestBehavior.AllowGet);
        }
    }
}