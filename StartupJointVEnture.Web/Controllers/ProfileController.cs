using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;

using AutoMapper.QueryableExtensions;
using StartupJointVenture.Web.ViewModels;
using System.IO;
using StartupJointVenture.Data;

namespace StartupJointVenture.Web.Controllers
{
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

        public ActionResult Edit(ProfileViewModel model, HttpPostedFileBase imageUrl)
        {
            string userId = User.Identity.GetUserId();
            string basePath = "/Content/images/" + userId;
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


            return RedirectToAction("Show");
        }
    }
}