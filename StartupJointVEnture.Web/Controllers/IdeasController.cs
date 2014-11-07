namespace StartupJointVEnture.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    using StartupJointVenture.Data;
    
    public class IdeasController : BaseController
    {
        public IdeasController(IJointVentureData data) : base(data)
        {
        }
        public ActionResult GetIdeasHomePage()
        {
            var ideas = this.Data.Ideas.All().ToList();

            return PartialView("_IdeaNoteView", ideas);
        }
    }
}