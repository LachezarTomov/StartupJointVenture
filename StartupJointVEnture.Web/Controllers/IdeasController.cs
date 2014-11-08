namespace StartupJointVenture.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    using StartupJointVenture.Data;
    using StartupJointVenture.Web.ViewModels;
    using System.Collections.Generic;
    
    public class IdeasController : BaseController
    {
        [HttpGet]
        public ActionResult NewIdea()
        {
            //ViewBag.Categories = this.Data.Categories.All().ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewIdea(IdeaViewModel model)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }

        [HttpGet]
        public ActionResult GetIdeasHomePage()
        {
            var ideas = this.Data.Ideas.All().ToList();

            return PartialView("_IdeaNoteView", ideas);
        }
    }
}