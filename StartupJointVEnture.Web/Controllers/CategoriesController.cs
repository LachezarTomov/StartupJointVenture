

namespace StartupJointVEnture.Web.Controllers
{
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using StartupJointVenture.Data;

    public class CategoriesController : BaseController
    {
        
        public CategoriesController(IJointVentureData data) : base(data)
        {
        }

        public ActionResult GetAll()
        {
            var categories = this.Data.Categories.All().ToList();

            return PartialView("_Categories",categories);
        }
    }
}