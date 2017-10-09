using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDocTruyenOnline.Models;

namespace WebDocTruyenOnline.Controllers
{
    public class FooterController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Footer
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        [OutputCache(Duration =3600)]
        public PartialViewResult CuoiTrang()
        {
            var model = db.Footers.Where(s => s.Status == true).ToList();
            return PartialView(model);
        }
    }
}