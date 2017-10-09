using System.Linq;
using System.Web.Mvc;
using WebDocTruyenOnline.Common;
using WebDocTruyenOnline.Models;

namespace WebDocTruyenOnline.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Home
        public ActionResult Index()
        {
            
            return View();
        }
        public PartialViewResult Info()
        {
            var sess = (UserLogin)Session[CommonConstants.USER_SESSION];
            var user = db.Users.SingleOrDefault(m => m.Email == sess.Email);
            ViewBag.Avatar = user.Avartar;
            ViewBag.FullName = user.FullName;
            return PartialView();
        }

    }
}