using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDocTruyenOnline.Common;
using WebDocTruyenOnline.Models;

namespace WebDocTruyenOnline.Areas.Admin.Controllers
{
    public class ChapStoriesController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ChapStories
        public ActionResult Index(string searchString, long? id)
        {
           
            IQueryable<ChapStory> model = db.ChapStories;
            if(id == null)
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    model = model.Where(x => x.Story.Name.Contains(searchString));
                }
            }
            else
            {
                model = model.Where(x => x.StoryId == id);
                if (!string.IsNullOrEmpty(searchString))
                {
                    model = model.Where(x => x.Story.Name.Contains(searchString) && x.StoryId == id);
                }     
            }
            model = model.Include(s => s.Story);
            return View(model.OrderBy(x=>x.StoryId).ThenBy(x=>x.Chap).ToList());
        }

        // GET: Admin/ChapStories/Details/5

        // GET: Admin/ChapStories/Create
        public ActionResult Create()
        {
               
            ViewBag.StoryId = new SelectList(db.Stories, "Id", "Name");
            return View();
        }

        // POST: Admin/ChapStories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,StoryId,Chap,ChapName, MetaTitle,Content,CreateDate,CreateBy,ModifyDate,ModifyBy,Status")] ChapStory chapStory)
        {
            int chap = db.ChapStories.Where(x => x.StoryId == chapStory.StoryId).OrderByDescending(x => x.Chap).Count();
            try
            {
                if (ModelState.IsValid)
                {
                    chapStory.CreateDate = DateTime.Now;
                    chapStory.CreateBy = User.Identity.GetUserName();
                    if (chapStory.Chap > chap)
                    {
                        db.ChapStories.Add(chapStory);
                        db.SaveChanges();
                        SetAlert("Tạo mới chap truyện thành công", "success");
                        return RedirectToAction("Index");
                    }
                    else if(chapStory.Chap < 1)
                    {
                        ModelState.AddModelError("", "Không thể tạo chap truyện dưới 1");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Truyện này đã có " + chap + " chap. Bạn có thể tạo từ chap " + (chap = chap + 1));
                    }

                }

                ViewBag.StoryID = new SelectList(db.Stories, "Id", "Name", chapStory.StoryId);
                return View(chapStory);
            }
            catch
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi");
                return View();
            }
            
        }

        // GET: Admin/ChapStories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChapStory chapStory = db.ChapStories.Find(id);
            if (chapStory == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.StoryId = new SelectList(db.Stories, "Id", "Name", chapStory.StoryId);
            return View(chapStory);
        }

        // POST: Admin/ChapStories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,StoryId,Chap,ChapName,MetaTitle,Content,CreateDate,CreateBy,ModifyDate,ModifyBy,Status")] ChapStory chapStory)
        {
            int chap = db.ChapStories.Where(x => x.StoryId == chapStory.StoryId).OrderByDescending(x => x.Chap).Count();

            try
            {
                if (ModelState.IsValid)
                {

                    //var sess = (UserLogin)Session[CommonConstants.USER_SESSION];
                    chapStory.ModifyDate = DateTime.Now;
                    chapStory.ModifyBy = User.Identity.GetUserName();
                    var st = db.Stories.Find(chapStory.StoryId);
                    chapStory.MetaTitle = st.MetaTitle;
                    if (chapStory.Chap <= chap)
                    {
                        db.Entry(chapStory).State = EntityState.Modified;
                        db.SaveChanges();
                        SetAlert("Cập nhật chap truyện thành công", "success");
                        return RedirectToAction("Index");
                    }
                    else if (chapStory.Chap < 1)
                    {
                        ModelState.AddModelError("", "Không thể tạo chap truyện dưới 1");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Truyện này đã có " + chap + " chap. Bạn có thể tạo từ chap " + (chap = chap + 1));
                    }

                    db.Entry(chapStory).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.StoryId = new SelectList(db.Stories, "Id", "Name", chapStory.StoryId);
                return View(chapStory);
            }
            catch
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi");
                return View();
            }
            
           
        }

        ////GET: Admin/Stories/MultiDelete
        public ActionResult MultiDelete(string searchString)
        {
            IQueryable<ChapStory> model = db.ChapStories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.MetaTitle.Contains(searchString));
            }
            
            model = model.Include(s => s.Story);
            return View(model.ToList());
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
                    var article = db.ChapStories.Find(temp);
                    db.ChapStories.Remove(article);
                }
                this.db.SaveChanges();
                SetAlert("Xóa thành công", "success");
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                SetAlert("Đã xảy ra lỗi", "error");
                return RedirectToAction("Index");
            }
            
        }

        // POST: Admin/ChapStories/Delete/5
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            try
            {
                ChapStory chapStory = db.ChapStories.Find(id);
                db.ChapStories.Remove(chapStory);
                db.SaveChanges();
                SetAlert("Xóa thành công", "success");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                SetAlert("Đã xảy ra lỗi", "error");
                return RedirectToAction("Index");
            }

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
