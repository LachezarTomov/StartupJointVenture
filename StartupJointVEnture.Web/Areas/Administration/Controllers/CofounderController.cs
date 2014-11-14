namespace StartupJointVenture.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using StartupJointVenture.Web.Areas.Administration.ViewModels;
    using StartupJointVenture.Data;

    public class CofounderController : AdminController
    {
        public CofounderController(IJointVentureData data)
            : base(data)
        {
        }

        // GET: Administration/Cofounders
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadCofounders([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.Data
                .Cofounders
                .All()
                .Project()
                .To<CofounderViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [HttpPost]
        public JsonResult DeleteCofounder([DataSourceRequest] DataSourceRequest request, CofounderViewModel cofounder)
        {
            var currentCofounder = this.Data.Cofounders.All().FirstOrDefault(x => x.Id == cofounder.Id);
            this.Data.Cofounders.Delete(currentCofounder);
            this.Data.SaveChanges();

            return Json(new[] { cofounder });
        }
    }
}