using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebDocTruyenOnline.Models;
using WebDocTruyenOnline.DTs;

namespace WebDocTruyenOnline.Controllers
{
    public class FolowingsController : ApiController
    {
        private ApplicationDbContext context;

        public FolowingsController()
        {
            context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Flow(FolowDto folowDto)
        {
            var userId = User.Identity.GetUserId();
            if (context.Folowings.Any(a => a.FolowerId == userId && a.StoryId == folowDto.StoryId))
                return BadRequest("Đã tồn tại");

            var folow = new Folowing
            {
                StoryId = folowDto.StoryId,
                FolowerId = User.Identity.GetUserId()
            };

            context.Folowings.Add(folow);
            context.SaveChanges();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Unfollow(long id)
        {
            var userId = User.Identity.GetUserId();
            var follow = context.Folowings.SingleOrDefault(a => a.FolowerId == userId && a.StoryId == id);

            if (follow == null)
                return NotFound();

            context.Folowings.Remove(follow);
            context.SaveChanges();

            return Ok(id);
        }
    }
}
