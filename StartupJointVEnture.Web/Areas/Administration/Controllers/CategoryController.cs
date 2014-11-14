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
    
    public class CategoryController : BaseController
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

            this.Data.Categories.Delete(currentCategory);
            this.Data.SaveChanges();

            return Json(new[] { category });
        }
    }
}
