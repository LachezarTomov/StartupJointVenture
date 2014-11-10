namespace StartupJointVenture.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using AutoMapper.QueryableExtensions;

    using StartupJointVenture.Data;
    using StartupJointVenture.Web.ViewModels;
    using System.Collections.Generic;
    using StartupJointVenture.Models;

    public class IdeasController : BaseController
    {
        [HttpGet]
        public ActionResult NewIdea()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewIdea(CreateIdeaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newIdea = new Idea()
                {
                    Title = model.Title,
                    Content = model.Content,
                    CategoryId = int.Parse(model.Category),
                    AuthorId = User.Identity.GetUserId(),
                    DateCreated = DateTime.Now
                };

                this.Data.Ideas.Add(newIdea);
                this.Data.SaveChanges();

                //return RedirectToAction("NewIdea");
                return RedirectToAction("../");
            }

            return View();
        }

        [HttpGet]
        public ActionResult GetIdeasHomePage()
        {
            var ideas = this.Data.Ideas.All().OrderByDescending(i => i.Id).Take(3).Project().To<IdeaSampleViewModel>();

            return PartialView("_IdeaNoteView", ideas);
        }

        [HttpGet]
        public ActionResult GetIdeasByCategory(int? categoryId)
        {
            IQueryable<Idea> ideas = this.Data.Ideas.All();
            if (categoryId != null)
            {
                ideas = ideas.Where(i => i.CategoryId == categoryId);
            }

            return PartialView("_IdeaNoteView", ideas.Project().To<IdeaSampleViewModel>().ToList());
        }
    }
}