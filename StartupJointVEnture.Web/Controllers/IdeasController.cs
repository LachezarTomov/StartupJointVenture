namespace StartupJointVenture.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

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
        public ActionResult NewIdea(IdeaViewModel model)
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
            var ideas = this.Data.Ideas.All().ToList();

            return PartialView("_IdeaNoteView", ideas);
        }
    }
}