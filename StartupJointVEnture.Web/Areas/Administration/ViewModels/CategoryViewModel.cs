namespace StartupJointVenture.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Web.Mvc;
    using System.ComponentModel.DataAnnotations;

    using StartupJointVenture.Models;
    using StartupJointVenture.Web.Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        [HiddenInput(DisplayValue = false)]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}