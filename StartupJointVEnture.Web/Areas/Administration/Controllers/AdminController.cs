
namespace StartupJointVenture.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using StartupJointVenture.Data;
    using StartupJointVenture.Web.Controllers;

    [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(IJointVentureData data)
            : base(data)
        {
        }
    }
}