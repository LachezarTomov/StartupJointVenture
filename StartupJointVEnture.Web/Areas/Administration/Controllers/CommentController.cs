namespace StartupJointVenture.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    using StartupJointVenture.Data;
    using StartupJointVenture.Web.Areas.Administration.ViewModels;
    
    public class CommentController : AdminController
    {
        public CommentController(IJointVentureData data)
            : base(data)
        {
        }

        // GET: Administration/Comment
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadComments([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.Data
                .Comments
                .All()
                .Project()
                .To<CommentViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [HttpPost]
        public JsonResult DeleteComment([DataSourceRequest] DataSourceRequest request, CommentViewModel comment)
        {
            var currentComment = this.Data.Comments.All().FirstOrDefault(x => x.Id == comment.Id);
            this.Data.Comments.Delete(currentComment);
            this.Data.SaveChanges();

            return Json(new[] { comment });
        }
    }
}