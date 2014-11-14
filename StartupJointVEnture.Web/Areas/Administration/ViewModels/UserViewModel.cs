namespace StartupJointVenture.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using StartupJointVenture.Models;
    using StartupJointVenture.Web.Infrastructure.Mapping;
    
    public class UserViewModel : IMapFrom<User>
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }
    }
}