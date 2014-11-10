namespace StartupJointVenture.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using AutoMapper.QueryableExtensions;
    using StartupJointVenture.Models;
    using StartupJointVenture.Web.ViewModels;

    public class CofoundersController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetAllCofounders(int ideaId)
        {
            var result = this.Data.Cofounders.All().Where(i => i.IdeaId == ideaId).Project().To<CofounderViewModel>();

            return this.PartialView("_ListCofounders", result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCofounder(string location, string profSkills, int ideaId)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();

                var idea = this.Data.Ideas.All().FirstOrDefault(i => i.Id == ideaId);

                if (idea.AuthorId != userId)
                {
                    Cofounder newCofounder = new Cofounder()
                    {
                        Location = location,
                        DateJoined = DateTime.Now,
                        IdeaId = ideaId,
                        ProfSkills = profSkills,
                        UserId = userId
                    };

                    this.Data.Cofounders.Add(newCofounder);
                    this.Data.SaveChanges();
                }
            }

            var result = this.Data.Cofounders.All().Where(i => i.IdeaId == ideaId).Project().To<CofounderViewModel>();

            
            return this.PartialView("_ListCofounders", result);
        }
    }
}