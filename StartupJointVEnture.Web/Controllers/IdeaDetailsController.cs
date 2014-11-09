namespace StartupJointVenture.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using StartupJointVenture.Web.ViewModels;
    using StartupJointVenture.Models;
    
    public class IdeaDetailsController : BaseController
    {
        [HttpGet]
        public ActionResult Index(int ideaId)
        {
            if (ideaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var idea = this.Data.Ideas.All().Where(i => i.Id == ideaId).Project().To<IdeaDetailsViewModel>();

            return View(idea.FirstOrDefault());
        }

        
    }
}