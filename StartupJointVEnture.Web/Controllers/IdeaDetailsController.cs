namespace StartupJointVenture.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using AutoMapper.QueryableExtensions;
    using StartupJointVenture.Web.ViewModels;
    using StartupJointVenture.Models;
    using StartupJointVenture.Data;
    
    public class IdeaDetailsController : BaseController
    {
        public IdeaDetailsController(IJointVentureData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index(int ideaId)
        {
            if (ideaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            string userId = User.Identity.GetUserId();
            
            ViewBag.hideLikeItButton = false;
            var result = this.Data.Likes.All()
                .Where(l => l.IdeaId == ideaId)
                .Where(l => l.AuthorId == userId)
                .FirstOrDefault();

            if (result != null)
            {
                ViewBag.hideLikeItButton = true;
            }

            ViewBag.Joined = false;
            var joined = this.Data.Cofounders.All()
                .Where(l => l.IdeaId == ideaId)
                .Where(c => c.UserId == userId)
                .FirstOrDefault();

            if (joined != null)
            {
                ViewBag.Joined = true;
            }


            var idea = this.Data.Ideas.All().Where(i => i.Id == ideaId).Project().To<IdeaDetailsViewModel>();
   
            return View(idea.FirstOrDefault());
        }
    }
}