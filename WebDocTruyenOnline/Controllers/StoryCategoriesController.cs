using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDocTruyenOnline.Models;

namespace WebDocTruyenOnline.Controllers
{
    public class StoryCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: StoryCategories
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        [OutputCache(Duration =3600)]
        public PartialViewResult DanhMucHeader()
        {
            var model = db.StoryCategories.Where(m => m.Status == true && m.ShowOnHome == true).OrderBy(x => x.Name).Take(4).ToList();
            return PartialView(model);
        }
    }
}