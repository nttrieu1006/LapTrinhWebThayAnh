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
    public class StoryTypesController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/StoryTypes
        public ActionResult Index(string searchString)
        {
           
            IQueryable<StoryType> model = db.StoryTypes;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }

            return View(model.OrderBy(x=>x.DisplayOrder).ThenBy(x=>x.Name).ToList());
        }

        // GET: Admin/StoryTypes/Details/5

        // GET: Admin/StoryTypes/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Admin/StoryTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MetaTitle,DisplayOrder,CreateDate,CreateBy,ModifyDate,ModifyBy,Status,ShowOnHome")] StoryType storyType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var sess = (UserLogin)Session[CommonConstants.USER_SESSION];
                    storyType.CreateDate = DateTime.Now;
                    storyType.CreateBy = User.Identity.GetUserName();
                    storyType.MetaTitle = ConvertToUnSign.convertToUnSign(storyType.Name);
                    storyType.Status = true;
                    storyType.ShowOnHome = true;

                    db.StoryTypes.Add(storyType);
                    db.SaveChanges();
                    SetAlert("Tạo mới thành công!", "success");
                    return RedirectToAction("Index");
                }

                return View(storyType);
            }
            catch
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi");
                return View();
            }
            
        }

        // GET: Admin/StoryTypes/Edit/5
        public ActionResult Edit(long? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoryType storyType = db.StoryTypes.Find(id);
            if (storyType == null)
            {
                return HttpNotFound();
            }
            return View(storyType);
        }

        // POST: Admin/StoryTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MetaTitle,DisplayOrder,CreateDate,CreateBy,ModifyDate,ModifyBy,Status,ShowOnHome")] StoryType storyType)
        {
            if (ModelState.IsValid)
            {
                //var sess = (UserLogin)Session[CommonConstants.USER_SESSION];
                storyType.ModifyDate = DateTime.Now;
                storyType.ModifyBy = User.Identity.GetUserName();
                storyType.MetaTitle = ConvertToUnSign.convertToUnSign(storyType.Name);

                db.Entry(storyType).State = EntityState.Modified;
                db.SaveChanges();
                SetAlert("Cập nhật thành công!", "success");
                return RedirectToAction("Index");
            }
            return View(storyType);
        }

        //GET: Admin/Stories/MultiDelete
        public ActionResult MultiDelete(string searchString)
        {
            
            IQueryable<StoryType> model = db.StoryTypes;
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
            for (int i = 0; i < chkId.Length; i++)
            {
                int temp = chkId[i];
                var article = db.StoryTypes.Find(temp);
                db.StoryTypes.Remove(article);
            }
            this.db.SaveChanges();
            SetAlert("Xóa thành công!", "success");
            return RedirectToAction("Index");
        }

        // POST: Admin/StoryTypes/Delete/5
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            StoryType story = db.StoryTypes.Find(id);
            db.StoryTypes.Remove(story);
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
