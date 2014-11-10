namespace StartupJointVenture.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using StartupJointVenture.Data;
    using StartupJointVenture.Models;

    public abstract class BaseController : Controller
    {
        protected IJointVentureData Data { get; set; }

        public User LoggedUser { get; set; }

        public BaseController()
            : this(new JointVentureData())
        {
        }

        public BaseController(IJointVentureData data)
        {
            this.Data = data;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}