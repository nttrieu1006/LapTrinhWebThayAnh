using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebDocTruyenOnline.Common;
using WebDocTruyenOnline.Models;

namespace WebDocTruyenOnline.Areas.Admin.Controllers
{
    [Authorize(Roles ="Quản Trị")]
    
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult Info()
        {
            string email = User.Identity.GetUserName();
            var user = db.Users.SingleOrDefault(m => m.Email == email);
                ViewBag.Avatar = user.Avartar;
                ViewBag.FullName = user.FullName;
                return PartialView();

        }

    }
}