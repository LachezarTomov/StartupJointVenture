namespace StartupJointVenture.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using AutoMapper.QueryableExtensions;
    using StartupJointVenture.Web.ViewModels;
    using StartupJointVenture.Data;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;

    [Authorize]
    public class ProfileController : BaseController
    {
        public ProfileController(IJointVentureData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Show()
        {
            var userId = User.Identity.GetUserId();
            var userProfile = this.Data.Users
                .All()
                .Where(u => u.Id == userId)
                .Project().To<ProfileViewModel>()
                .FirstOrDefault();

            return View(userProfile);
        }

        public ActionResult ShowIdeas()
        {
            ViewData["categories"] = this.Data.Categories.All().Project().To<CategoryViewModel>().ToList();

            return View();
        }

        public ActionResult UpdateIdeaProfile([DataSourceRequest] DataSourceRequest request, IdeaProfileViewModel idea)
        {
            var existingCategory = this.Data.Ideas.All().FirstOrDefault(x => x.Id == idea.Id);

            if (idea != null && ModelState.IsValid)
            {
                existingCategory.Title = idea.Title;
                existingCategory.Content = idea.Content;
                existingCategory.CategoryId = idea.Category.Id;

                this.Data.SaveChanges();
            }

            return Json((new[] { idea }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadIdeas([DataSourceRequest]DataSourceRequest request)
        {
            var userId = User.Identity.GetUserId();
            var ideas = this.Data
                .Ideas
                .All()
                .Where(i => i.AuthorId == userId)
                .Project()
                .To<IdeaDetailsViewModel>();

            return this.Json(ideas.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProfileViewModel model, HttpPostedFileBase imageUrl)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                string basePath = "/Avatars/" + userId;
                string serverPath = Server.MapPath("~" + basePath);

                if (imageUrl != null)
                {
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }

                    string filePath = Path.Combine(serverPath, Path.GetFileName(imageUrl.FileName));
                    imageUrl.SaveAs(filePath);
                }

                var user = this.Data.Users.Find(userId);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Description = model.Description;
                if (imageUrl != null)
                {
                    user.ImageUrl = basePath + "/" + Path.GetFileName(imageUrl.FileName);
                }

                this.Data.SaveChanges();
            }

            return RedirectToAction("Show");
        }
    }
}