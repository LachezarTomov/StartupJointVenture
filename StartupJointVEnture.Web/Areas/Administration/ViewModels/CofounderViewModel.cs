namespace StartupJointVenture.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using StartupJointVenture.Models;
    using StartupJointVenture.Web.Infrastructure.Mapping;
    using System.Web.Mvc;

    public class CofounderViewModel : IMapFrom<Cofounder>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public User Author { get; set; }

        public DateTime DateCreated { get; set; }

        public Idea Idea { get; set; }

        public string Location { get; set; }

        public string ProfSkills { get; set; }
    }
}