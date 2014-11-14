namespace StartupJointVenture.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using AutoMapper.QueryableExtensions;
    using PagedList;

    using StartupJointVenture.Data;
    using StartupJointVenture.Web.ViewModels;
    using StartupJointVenture.Models;

    public class IdeasController : BaseController
    {
        public IdeasController(IJointVentureData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult NewIdea()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
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

                return RedirectToAction("../");
            }

            return View();
        }

        [HttpGet]
        public ActionResult GetIdeasHomePage()
        {
            const int startPageNotesCount = 6;

            var ideas = this.Data.Ideas.All().OrderByDescending(i => i.Id).Take(startPageNotesCount).Project().To<IdeaSampleViewModel>();

            PagedList<IdeaSampleViewModel> newModel = new PagedList<IdeaSampleViewModel>(ideas, 1, startPageNotesCount);

            return PartialView("_IdeaNoteView", newModel);
        }

        [HttpGet]
        public ActionResult GetIdeasByCategory(int? categoryId, int page = 1, int pageSize = 6)
        {
            IQueryable<Idea> ideas = this.Data.Ideas.All();
            if (categoryId != null)
            {
                ideas = ideas.Where(i => i.CategoryId == categoryId);
            }

            IEnumerable<IdeaSampleViewModel> model = ideas.Project().To<IdeaSampleViewModel>().ToList();

            PagedList<IdeaSampleViewModel> newModel = new PagedList<IdeaSampleViewModel>(model, page, pageSize);

            return PartialView("_IdeaNoteView", newModel);
        }
    }
}