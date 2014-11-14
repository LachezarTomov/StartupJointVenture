namespace StartupJointVenture.Web.ViewModels
{
    using System;

    using StartupJointVenture.Models;
    using System.Web.Mvc;
    using System.ComponentModel.DataAnnotations;
    using StartupJointVenture.Web.Infrastructure.Mapping;

    public class IdeaProfileViewModel : IMapFrom<Idea>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public Category Category { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Idea, IdeaProfileViewModel>()
               .ForMember(m => m.Category, opt => opt.MapFrom(w => w.Category.Name));
        }
    }
}