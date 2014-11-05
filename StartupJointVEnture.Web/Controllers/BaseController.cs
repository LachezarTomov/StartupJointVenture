

namespace StartupJointVEnture.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using StartupJointVenture.Data;
    using StartupJointVenture.Models;

    public class BaseController : Controller
    {
        protected IJointVentureData Data { get; set; }

        public User LoggedUser { get; set; }

        public BaseController(IJointVentureData data)
        {
            this.Data = data;
            var userId = this.User.Identity.GetUserId();
            this.LoggedUser = this.Data.Users.Find(userId);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}