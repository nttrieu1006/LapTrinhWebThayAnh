using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDocTruyenOnline.Models;
using PagedList;
using Microsoft.AspNet.Identity;
using WebDocTruyenOnline.ViewModels;

namespace WebDocTruyenOnline.Controllers
{
    public class StoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Stories
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult TopHot(long? typeId)
        {
            var model = new List<Story>();
            if(typeId == null)
            {
                model = db.Stories.ToList();
            }
            else
            {
                    model = db.Stories.Where(x => x.TypeId == typeId).ToList();   
            }
            return PartialView(model.OrderByDescending(x => x.TopHot.HasValue && x.TopHot > DateTime.Now).Take(12).ToList());
        }
        public PartialViewResult Finish()
        {
            var model= db.Stories.Where(x => x.Status == true).OrderByDescending(x => x.CreateDate).Take(4);
            return PartialView(model.ToList());
        }

        //Trang thể loại truyện

        public ActionResult Type(long? typeId, int? pageIndex)
        {
            var _pageIndex = pageIndex ?? 1;
            var ty = db.StoryTypes.Find(typeId);
            ViewBag.type = ty.Name;
            var model = db.Stories.Where(x => x.TypeId == typeId); 
            return View(model.OrderBy(x=>x.Name).ToPagedList(_pageIndex,10));
        }

        //Trang danh mục truyện

        public ActionResult Category(long Id, int? pageIndex)
        {
            var _pageIndex = pageIndex ?? 1;
            var cat = db.StoryCategories.Find(Id);
            ViewBag.cate = cat.Name;
            var model = db.Stories.Where(x=>x.CategoryId == Id);
            return View(model.OrderBy(x => x.Name).ToPagedList(_pageIndex, 10));
        }


        //Trang thông tin truyện
        public ActionResult Detail(long id, int? pageChap)
        {
            var _pageChap = pageChap ?? 1;
            ViewBag.story = db.Stories.Find(id);
            var userId = User.Identity.GetUserId();
            if(userId != null)
            {
                ViewBag.folow = db.Folowings.SingleOrDefault(x => x.StoryId == id && x.FolowerId == userId);
            }

            var model = db.ChapStories.Where(x=>x.StoryId == id);
            return View(model.OrderBy(x=>x.Chap).ToPagedList(_pageChap,10));
        }

        //Các truyện đã đăng kí

        public ActionResult Folowing(int? pageIndex)
        {
            var userId = User.Identity.GetUserId();
            var _pageIndex = pageIndex ?? 1;
            var model = db.Folowings
                        .Where(x => x.FolowerId == userId)
                        .Select(a => a.Story).ToList();

            return View(model.OrderBy(m=>m.Name).ToPagedList(_pageIndex,10));
        }

        //Search autocomplete

        public JsonResult ListName(string q)
        {
            var data = db.Stories.Where(x => x.Name.Contains(q)).Select(x => x.Name).ToList();
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search(string keyword, int? pageIndex)
        {
            var _pageIndex = pageIndex ?? 1;
            var model = db.Stories.Where(x => x.Name == keyword).ToList();
            return View(model.OrderBy(x => x.Name).ToPagedList(_pageIndex, 10));
        }
    }
}