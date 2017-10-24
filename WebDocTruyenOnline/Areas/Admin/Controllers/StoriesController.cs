using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;


using WebDocTruyenOnline.Common;
using WebDocTruyenOnline.Models;

namespace WebDocTruyenOnline.Areas.Admin.Controllers
{
    public class StoriesController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Stories
        public ActionResult Index(string searchString)
        {
            IQueryable<Story> stories = db.Stories;
            if (!string.IsNullOrEmpty(searchString))
            {
                stories = stories.Where(x => x.Name.Contains(searchString));
            }
             stories = stories.Include(s => s.Author).Include(s => s.StoryCategory).Include(s => s.StoryType);
            return View(stories.OrderBy(x=>x.Name).ThenBy(x=>x.CreateDate).ToList());
        }

        // GET: Admin/Stories/Details/5

        // GET: Admin/Stories/Create
        public ActionResult Create()
        {
          
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name");
            ViewBag.CategoryId = new SelectList(db.StoryCategories, "Id", "Name");
            ViewBag.TypeId = new SelectList(db.StoryTypes, "Id", "Name");
            return View();
        }

        // POST: Admin/Stories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Name,MetaTitle,Descirption,AuthorID,TypeID,CategoryID,Image,CreateDate,CreateBy,ModifyDate,ModifyBy,TopHot,Status,Views")] Story story)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var sess = (UserLogin)Session[CommonConstants.USER_SESSION];
                    story.CreateDate = DateTime.Now;
                    story.CreateBy = User.Identity.GetUserName();
                    story.MetaTitle = ConvertToUnSign.convertToUnSign(story.Name);
                    story.Views = 0;

                    db.Stories.Add(story);
                    db.SaveChanges();
                    SetAlert("Tạo truyện thành công! Bạn vui lòng tạo chap truyện", "success");
                }
                    ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name", story.AuthorId);
                    ViewBag.CategoryId = new SelectList(db.StoryCategories, "Id", "Name", story.CategoryId);
                    ViewBag.TypeId = new SelectList(db.StoryTypes, "Id", "Name", story.TypeId);
                    return RedirectToAction("Create", "ChapStories");
                
            }
            catch
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi");
                return View();
            }
         
        }

        // GET: Admin/Stories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = db.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
           
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name", story.AuthorId);
            ViewBag.CategoryId = new SelectList(db.StoryCategories, "Id", "Name", story.CategoryId);
            ViewBag.TypeId = new SelectList(db.StoryTypes, "Id", "Name", story.TypeId);
            return View(story);
        }

        // POST: Admin/Stories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Name,MetaTitle,Descirption,AuthorID,TypeID,CategoryID,Image,CreateDate,CreateBy,ModifyDate,ModifyBy,TopHot,Status,Views")] Story story)
        {
            try {
                if (ModelState.IsValid)
                {
                    //var sess = (UserLogin)Session[CommonConstants.USER_SESSION];
                    story.ModifyDate = DateTime.Now;
                    story.ModifyBy = User.Identity.GetUserName();
                    story.MetaTitle = ConvertToUnSign.convertToUnSign(story.Name);

                    db.Entry(story).State = EntityState.Modified;
                    db.SaveChanges();
                    SetAlert("Cập nhật truyện thành công!", "success");
                    return RedirectToAction("Index");
                }
                ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name", story.AuthorId);
                ViewBag.CategoryId = new SelectList(db.StoryCategories, "Id", "Name", story.CategoryId);
                ViewBag.TypeId = new SelectList(db.StoryTypes, "Id", "Name", story.TypeId);
                return View(story);
            }
            catch
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi");
                return View();
            }
            
        }

        //Truyen da dang

            public ActionResult StoryByUser(string searchString)
        {
            var user = User.Identity.GetUserName();
            IQueryable<Story> stories = db.Stories.Where(x=>x.CreateBy == user);
            if (!string.IsNullOrEmpty(searchString))
            {
                stories = stories.Where(x => x.Name.Contains(searchString));
            }
            stories = stories.Include(s => s.Author).Include(s => s.StoryCategory).Include(s => s.StoryType);
            return View(stories.OrderBy(x => x.Name).ThenBy(x => x.CreateDate).ToList());
        }
        //GET: Admin/Stories/MultiDelete
        public ActionResult MultiDelete(string searchString)
        {
           
            IQueryable<Story> stories = db.Stories;
            if (!string.IsNullOrEmpty(searchString))
            {
                stories = stories.Where(x => x.Name.Contains(searchString));
            }
            stories = stories.Include(s => s.Author).Include(s => s.StoryCategory).Include(s => s.StoryType);
            return View(stories.ToList());
        }
        // POST: Admin/Stories/MultiDelete
        [HttpPost]
        public ActionResult MultiDelete(int[] chkId)
        {
            try
            {
                for (int i = 0; i < chkId.Length; i++)
                {
                    int temp = chkId[i];
                    var article = db.Stories.Find(temp);
                    db.Stories.Remove(article);
                }
                this.db.SaveChanges();
                SetAlert("Xóa thành công!", "success");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi");
                return View();
            }
        }
        // GET: Admin/Stories/Delete/5
        // POST: Admin/Stories/Delete/5
        [HttpDelete]

        public ActionResult Delete(long id)
        {
            try
            {
                Story story = db.Stories.Find(id);
                db.Stories.Remove(story);
                db.SaveChanges();
                SetAlert("Xóa thành công!", "success");
            }
            catch
            {
                ModelState.AddModelError("","Đã xảy ra lỗi");
            }
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
