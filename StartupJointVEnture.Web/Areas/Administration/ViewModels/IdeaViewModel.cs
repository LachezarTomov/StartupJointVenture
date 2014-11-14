namespace StartupJointVenture.Web.Areas.Administration.ViewModels
{
    using System;

    using System.Web.Mvc;
    using System.ComponentModel.DataAnnotations;

    using StartupJointVenture.Models;
    using StartupJointVenture.Web.Infrastructure.Mapping;

    public class IdeaViewModel : IMapFrom<Idea>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public Category Category { get; set; }
    }
}