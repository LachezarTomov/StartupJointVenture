namespace StartupJointVenture.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using AutoMapper.QueryableExtensions;
    using StartupJointVenture.Models;
    using StartupJointVenture.Web.ViewModels;
    
    public class CommentsController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetAllComments(int ideaId)
        {
            var result = this.Data.Comments.All().Where(i => i.IdeaId == ideaId).Project().To<CommentViewModel>();

            return this.PartialView("_ListComments", result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(string comment, int ideaId)
        {
            if (ModelState.IsValid)
            {
                Comment newComment = new Comment()
                {
                    Content = comment,
                    DateCreated = DateTime.Now,
                    IdeaId = ideaId,
                    AuthorId = User.Identity.GetUserId()
                };

                this.Data.Comments.Add(newComment);
                this.Data.SaveChanges();

            }

            var result = this.Data.Comments.All().Where(i => i.IdeaId == ideaId).Project().To<CommentViewModel>();

            //ModelState.Clear();

            return this.PartialView("_ListComments", result);
        }
    }
}