using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDocTruyenOnline.Common;
using WebDocTruyenOnline.Models;

namespace WebDocTruyenOnline.Areas.Admin.Controllers
{
    public class ManageRoleController : BaseController
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Admin/ManageRole
        public ActionResult Index()
        {
           
            var model = context.Roles.AsEnumerable();
            return View(model.ToList());
        }
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Admin/Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IdentityRole role)
        {
            if (ModelState.IsValid)
            {


                context.Roles.Add(role);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }
        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var model = context.Roles.Find(id);
            context.Roles.Remove(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}