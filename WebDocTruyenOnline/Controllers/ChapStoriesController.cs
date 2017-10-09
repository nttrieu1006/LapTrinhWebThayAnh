using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDocTruyenOnline.Models;

namespace WebDocTruyenOnline.Controllers
{
    public class ChapStoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: ChapStories
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult MoiCN(long? typeId)
        {
            var model = new List<ChapStory>();
            if (typeId == null)
            {
                model = db.ChapStories.OrderByDescending(x => x.CreateDate).Take(20).ToList();
            }
            else
            {
                model = db.ChapStories.Where(x => x.Story.TypeId == typeId).OrderByDescending(x => x.CreateDate).Take(20).ToList();
            }
            return PartialView(model.ToList());
        }

        //Trang đọc truyện
 
        public ActionResult ReadStory(long storyID, long chap)
        {
            long? id = db.ChapStories.SingleOrDefault(x => x.StoryId == storyID && x.Chap == chap).Id;
            var chapNext = db.ChapStories.Where(x => x.StoryId == storyID && x.Chap == chap+1);
            if(chapNext.Count() == 0)
            {
                ViewBag.chapNext = db.ChapStories.SingleOrDefault(x => x.StoryId == storyID && x.Chap == chap).Id;     
            }
            ViewBag.chap = db.ChapStories.Find(id);
            var model = db.ChapStories.Where(x => x.Story.Id == storyID).ToList();
            return View(model);

        }
    }
}