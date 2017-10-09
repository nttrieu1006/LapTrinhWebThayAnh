using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDocTruyenOnline.Models;

namespace WebDocTruyenOnline.Controllers
{
    public class StoryTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: StoryTypes
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public PartialViewResult TheLoaiHeader()
        {
            var model = db.StoryTypes.Where(x => x.Status == true && x.ShowOnHome == true).OrderBy(x => x.Name).Take(6).ToList();
            return PartialView(model);
        }
        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        public PartialViewResult StoryType()
        {
            var model = db.StoryTypes.Where(x => x.Status == true).OrderBy(x => x.Name).ToList();
            return PartialView(model);
        }
    }
}