using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Mvc;

using WebDocTruyenOnline.Models;

using Microsoft.AspNet.Identity.EntityFramework;
using WebDocTruyenOnline.Common;
using System.Net;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace WebDocTruyenOnline.Areas.Admin.Controllers

{

    //[Authorize(Users = "a@gmail.com")]

    public class ManageUserController : Controller

    {

        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: Admin/ManageUser

        public ActionResult Index()

        {
            IEnumerable<ApplicationUser> model = context.Users.AsEnumerable();

            return View(model);

        }

        public ActionResult Edit(string Id)

        {

            ApplicationUser model = context.Users.Find(Id);

            return View(model);

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult Edit(ApplicationUser model)

        {

            try

            {

                context.Entry(model).State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();

                return RedirectToAction("Index");

            }

            catch (Exception ex)

            {

                ModelState.AddModelError("", ex.Message);

                return View(model);

            }

        }

        [HttpGet]
        public ActionResult EditRole(string Id)

         {

            try
            {
                if (Id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    ApplicationUser model = context.Users.Find(Id);

                    ViewBag.RoleId = new SelectList(context.Roles.ToList(), "Name", "Name");

                    return View(model);
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", ex.Message);

                return View();
            }

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult AddToRole(string UserId, string RoleId)

        {
            try
            {


                ApplicationUser model = context.Users.Find(UserId);

                IdentityRole role = context.Roles.SingleOrDefault(m=>m.Name == RoleId);

                model.Roles.Add(new IdentityUserRole() { UserId = UserId, RoleId = role.Id });

                context.SaveChanges();

                ViewBag.RoleId = new SelectList(context.Roles.ToList().Where(item => model.Roles.FirstOrDefault(r => r.RoleId == item.Id) == null).ToList(), "Id", "Name");

                return RedirectToAction("EditRole", new { Id = UserId });
            }
            catch(Exception ex)
            {

                ModelState.AddModelError("", ex.Message);

                return View();
            }

        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        public ActionResult DeleteRoleFromUser(string UserId, string RoleId)

        {
            try
            {
                ApplicationUser model = context.Users.Find(UserId);
                model.Roles.Remove(model.Roles.SingleOrDefault(m => m.RoleId == RoleId));

                context.SaveChanges();

                ViewBag.RoleId = new SelectList(context.Roles.ToList().Where(item => model.Roles.FirstOrDefault(r => r.RoleId == item.Id) == null).ToList(), "Id", "Name");

                return RedirectToAction("EditRole", new { Id = UserId });
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

                return View();
            }
            

        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var model = context.Users.Find(id);
            context.Users.Remove(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}