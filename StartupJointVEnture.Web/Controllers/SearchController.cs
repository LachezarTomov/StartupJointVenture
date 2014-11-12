namespace StartupJointVenture.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using StartupJointVenture.Web.ViewModels;
    using StartupJointVenture.Data;

    public class SearchController : BaseController
    {
        public SearchController(IJointVentureData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult Index(int? categoryId)
        {
            return View(categoryId);
        }



        public ActionResult All()
        {
            return this.View();
        }
    }
}