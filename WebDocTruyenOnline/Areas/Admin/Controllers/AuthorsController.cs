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
    public class AuthorsController : BaseController
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Authors
        public ActionResult Index(string searchString)
        {
            
            IQueryable<Author> model = db.Authors;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }

            return View(model.OrderBy(x=>x.DisplayOrder).ThenBy(x=>x.Name).ToList());
        }

        // GET: Admin/Authors/Details/5

        // GET: Admin/Authors/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Admin/Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MetaTitle,DisplayOrder,CreateDate,CreateBy,ModifyDate,ModifyBy,Status,ShowOnHome")] Author author)
        {
            if (ModelState.IsValid)
            {
                author.CreateDate = DateTime.Now;
                author.CreateBy = User.Identity.GetUserName();
                author.MetaTitle = ConvertToUnSign.convertToUnSign(author.Name);
                author.Status = true;
                author.ShowOnHome = true;
                db.Authors.Add(author);
                db.SaveChanges();
                SetAlert("Tạo mới tác giả thành công","success");
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Admin/Authors/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            
            return View(author);
        }

        // POST: Admin/Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MetaTitle,CreateBy,CreateDate,DisplayOrder,ModifyDate,ModifyBy,Status,ShowOnHome")] Author author)
        {
            if (ModelState.IsValid)
            {
                
                
                author.ModifyDate = DateTime.Now;
                author.ModifyBy = User.Identity.GetUserName();
                author.MetaTitle = ConvertToUnSign.convertToUnSign(author.Name);

                
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                SetAlert("Cập nhật tác giả thành công!", "success");
                return RedirectToAction("Index");
            }
            return View(author);
        }

        //GET: Admin/Stories/MultiDelete
        public ActionResult MultiDelete(string searchString)
        {
            IQueryable<Author> model = db.Authors;
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
                    var article = db.Authors.Find(temp);
                    db.Authors.Remove(article);
                }
                this.db.SaveChanges();
                SetAlert("Xóa thành công!", "success");
                return RedirectToAction("Index");
            }
            catch
            {
                SetAlert("Xóa không thành công!", "error");
                return View();
            }
            
        }

        // POST: Admin/Authors/Delete/5
        [HttpDelete]
        public ActionResult Delete(long id)
        {
            try
            {
                Author story = db.Authors.Find(id);
                db.Authors.Remove(story);
                db.SaveChanges();
                SetAlert("Xóa thành công!", "success");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                SetAlert("Xóa không thành công!", "error");
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
