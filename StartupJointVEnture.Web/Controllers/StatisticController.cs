

namespace StartupJointVenture.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;
    using AutoMapper.QueryableExtensions;
    using StartupJointVenture.Data;
    using StartupJointVenture.Web.ViewModels;
    
    public class StatisticController : BaseController
    {
        public StatisticController(IJointVentureData data)
            : base(data)
        {
        }

        public ActionResult MostLikedIdeas()
        {
            var ideas = this.Data.Ideas.All().OrderByDescending(i => i.Likes.Count()).Take(5).Project().To<IdeaSampleViewModel>().ToList();

            return PartialView("_TopIdeas", ideas);
        }
    }
}