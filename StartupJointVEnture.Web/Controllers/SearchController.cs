namespace StartupJointVenture.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using StartupJointVenture.Web.ViewModels;

    public class SearchController : BaseController
    {
        [HttpGet]
        public ActionResult Index(int categoryId)
        {
            

            //return PartialView("_IdeaNoteView", ideas);
            return View(categoryId);
        }



        public ActionResult All()
        {
            return this.View();
        }
    }
}