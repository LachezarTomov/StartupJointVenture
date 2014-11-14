namespace StartupJointVenture.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using AutoMapper.QueryableExtensions;

    using StartupJointVenture.Data;
    using StartupJointVenture.Models;
    using StartupJointVenture.Web.Controllers;
    using StartupJointVenture.Web.Areas.Administration.ViewModels;

    public class CategoryController : AdminController
    {
        public CategoryController(IJointVentureData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CreateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                var newCategory = new Category
                {
                    Name = category.Name
                };

                this.Data.Categories.Add(newCategory);
                this.Data.SaveChanges();

                category.Id = newCategory.Id;
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public JsonResult ReadCategories([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.Data
                .Categories
                .All()
                .Project()
                .To<CategoryViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [HttpPost]
        public JsonResult UpdateCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            var currentCategory = this.Data.Categories.All().FirstOrDefault(x => x.Id == category.Id);

            if (category != null && ModelState.IsValid)
            {
                currentCategory.Name = category.Name;

                this.Data.SaveChanges();
            }

            return Json((new[] { category }.ToDataSourceResult(request, ModelState)));
        }

        [HttpPost]
        public JsonResult DeleteCategory([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {

            var currentCategory = this.Data.Categories.All().FirstOrDefault(x => x.Id == category.Id);

            var ideas = this.Data.Ideas.All().Where(i => i.CategoryId == currentCategory.Id).ToList();
            foreach (var idea in ideas)
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
            }

            this.Data.Categories.Delete(currentCategory);
            this.Data.SaveChanges();

            return Json(new[] { category });
        }
    }
}
