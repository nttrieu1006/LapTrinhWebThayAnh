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
    public class StoryCategoriesController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/StoryCategories
        public ActionResult Index(string searchString)
        {
           
            IQueryable<StoryCategory> model = db.StoryCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }

            return View(model.OrderBy(x=>x.DisplayOrder).ThenBy(x=>x.Name).ToList());
        }

        // GET: Admin/StoryCategories/Details/5

        // GET: Admin/StoryCategories/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Admin/StoryCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MetaTitle,DisplayOrder,CreateDate,CreateBy,ModifyDate,ModifyBy,Status,ShowOnHome")] StoryCategory storyCategory)
        {
            if (ModelState.IsValid)
            {
                //var sess = (UserLogin)Session[CommonConstants.USER_SESSION];
                storyCategory.CreateDate = DateTime.Now;
                storyCategory.CreateBy = User.Identity.GetUserName();
                storyCategory.MetaTitle = ConvertToUnSign.convertToUnSign(storyCategory.Name);
                storyCategory.ShowOnHome = true;
                storyCategory.Status = true;

                db.StoryCategories.Add(storyCategory);
                db.SaveChanges();
                SetAlert("Tạo mới thành công!", "success");
                return RedirectToAction("Index");
            }

            return View(storyCategory);
        }

        // GET: Admin/StoryCategories/Edit/5
        public ActionResult Edit(long? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoryCategory storyCategory = db.StoryCategories.Find(id);
            if (storyCategory == null)
            {
                return HttpNotFound();
            }
            return View(storyCategory);
        }

        // POST: Admin/StoryCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MetaTitle,DisplayOrder,CreateDate,CreateBy,ModifyDate,ModifyBy,Status,ShowOnHome")] StoryCategory storyCategory)
        {
            if (ModelState.IsValid)
            {
                //var sess = (UserLogin)Session[CommonConstants.USER_SESSION];
                storyCategory.ModifyDate = DateTime.Now;
                storyCategory.ModifyBy = User.Identity.GetUserName();
                storyCategory.MetaTitle = ConvertToUnSign.convertToUnSign(storyCategory.Name);

                db.Entry(storyCategory).State = EntityState.Modified;
                db.SaveChanges();
                SetAlert("Cập nhật thành công!", "success");
                return RedirectToAction("Index");
            }
            return View(storyCategory);
        }
        //GET: Admin/Stories/MultiDelete
        public ActionResult MultiDelete(string searchString)
        {
           
            IQueryable<StoryCategory> model = db.StoryCategories;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }

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
                    var article = db.StoryCategories.Find(temp);
                    db.StoryCategories.Remove(article);
                }
                this.db.SaveChanges();
                SetAlert("Xóa thành công!", "success");
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi");
                return View();
            }
        }

        // POST: Admin/StoryCategories/Delete/5
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            StoryCategory story = db.StoryCategories.Find(id);
            db.StoryCategories.Remove(story);
            db.SaveChanges();
            SetAlert("Xóa thành công!", "success");
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
