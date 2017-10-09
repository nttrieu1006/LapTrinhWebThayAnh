using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDocTruyenOnline.Models;

namespace WebDocTruyenOnline.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            ViewBag.Types = db.StoryTypes.Where(x => x.Status == true).OrderBy(x => x.Name).ToList();
            ViewBag.Finish = db.Stories.Where(x => x.Status == true).OrderByDescending(x=>x.CreateDate).Take(4).ToList();
            return View();
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
        public ActionResult DangKi()
        {
            return PartialView();
        }
        public ActionResult DangNhap()
        {
            return PartialView();
        }

    }
}