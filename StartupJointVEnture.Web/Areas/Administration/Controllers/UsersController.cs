

namespace StartupJointVenture.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using AutoMapper.QueryableExtensions;

    using StartupJointVenture.Data;
    using StartupJointVenture.Web.Areas.Administration.ViewModels;
    using StartupJointVenture.Models;


    public class UsersController : AdminController
    {
        public UsersController(IJointVentureData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ReadUsers([DataSourceRequest]DataSourceRequest request)
        {
            var result = this.Data
                .Users
                .All()
                .Project()
                .To<UserViewModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        public JsonResult CreateUser([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            if (user != null && ModelState.IsValid)
            {
                var newUser = new User
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    ImageUrl = user.ImageUrl
                };

                this.Data.Users.Add(newUser);
                this.Data.SaveChanges();

                user.Id = newUser.Id;
            }

            return Json(new[] { user }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public JsonResult UpdateUser([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            var existingUser = this.Data.Users.All().FirstOrDefault(x => x.Id == user.Id);

            if (user != null && ModelState.IsValid)
            {
                existingUser.UserName = user.UserName;
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.ImageUrl = user.ImageUrl;

                this.Data.SaveChanges();
            }

            return Json((new[] { user }.ToDataSourceResult(request, ModelState)), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteUser([DataSourceRequest] DataSourceRequest request, UserViewModel user)
        {
            var existingUser = this.Data.Users.All().FirstOrDefault(x => x.Id == user.Id);

            this.Data.Users.Delete(existingUser);
            this.Data.SaveChanges();

            return Json(new[] { user }, JsonRequestBehavior.AllowGet);
        }

    }

}