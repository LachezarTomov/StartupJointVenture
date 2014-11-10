

namespace StartupJointVenture.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using AutoMapper.QueryableExtensions;
    using StartupJointVenture.Models;

    public class LikesController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LikeIdea(int ideaId, int likesCount)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                var like = this.Data.Likes
                    .All()
                    .Where(l => l.AuthorId == userId)
                    .Where(l => l.IdeaId == ideaId)
                    .FirstOrDefault();

                if (like == null)
                {
                    Like newLike = new Like()
                    {
                        AuthorId = userId,
                        IdeaId = ideaId
                    };

                    this.Data.Likes.Add(newLike);
                    this.Data.SaveChanges();
                    likesCount++;
                }
            }
            return Content(likesCount.ToString());
        }
    }
}