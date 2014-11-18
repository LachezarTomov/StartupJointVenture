

namespace StartupJointVenture.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using StartupJointVenture.Data;
    using StartupJointVenture.Web.ViewModels;

    public class CategoriesController : BaseController
    {
        public CategoriesController(IJointVentureData data)
            : base(data)
        {
        }

        [ChildActionOnly]
        //    [OutputCache(Duration = 10 * 60)]
        public ActionResult GetAll()
        {
            var categories = this.Data.Categories.All().Project().To<CategoryViewModel>();

            return this.PartialView("_Categories", categories);
        }

        [ChildActionOnly]
        //     [OutputCache(Duration = 10 * 60)]
        public ActionResult GetCategoriesDropdown()
        {
            var categories = Data.Categories.All().Project().To<CategoryViewModel>();

            return PartialView("_CategoriesDropdown", categories);
        }
    }
}