namespace StartupJointVenture.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using AutoMapper.QueryableExtensions;

    using StartupJointVenture.Data;
    using StartupJointVenture.Web.Areas.Administration.ViewModels;

    public class IdeaController : AdminController
    {
        public IdeaController(IJointVentureData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            ViewData["categories"] = this.Data.Categories.All().ToList();

            return View();
        }

        public JsonResult ReadIdeas([DataSourceRequest]DataSourceRequest request)
        {
            var ideas = this.Data
                .Ideas
                .All()
                .Project()
                .To<IdeaViewModel>()
                ;

            return this.Json(ideas.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdateIdeaProfile([DataSourceRequest] DataSourceRequest request, IdeaViewModel idea)
        {
            var existingCategory = this.Data.Ideas.All().FirstOrDefault(x => x.Id == idea.Id);

            if (idea != null && ModelState.IsValid)
            {
                existingCategory.Title = idea.Title;
                existingCategory.Content = idea.Content;
                existingCategory.CategoryId = idea.Category.Id;

                this.Data.SaveChanges();
            }

            return Json((new[] { idea }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteIdea([DataSourceRequest] DataSourceRequest request, IdeaViewModel idea)
        {
            // Delete all comment from this idea
            var comments = this.Data.Comments.All().Where(c => c.IdeaId == idea.Id).ToList();

            foreach (var comment in comments)
            {
                this.Data.Comments.Delete(comment);
            }

            // Delete all cofounders from this idea
            var cofounders = this.Data.Cofounders.All().Where(c => c.IdeaId == idea.Id).ToList();
            foreach (var cofounder in cofounders)
            {
                this.Data.Cofounders.Delete(cofounder);
            }

            // Delete all likes from this idea
            var likes = this.Data.Likes.All().Where(c => c.IdeaId == idea.Id).ToList();
            foreach (var like in likes)
            {
                this.Data.Likes.Delete(like);
            }

            var currentIdea = this.Data.Ideas.All().FirstOrDefault(x => x.Id == idea.Id);
            this.Data.Ideas.Delete(currentIdea);
            this.Data.SaveChanges();

            return Json(new[] { idea });
        }
    }
}