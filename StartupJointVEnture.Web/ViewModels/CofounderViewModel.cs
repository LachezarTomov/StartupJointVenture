namespace StartupJointVenture.Web.ViewModels
{
    using System;
    using System.Collections.Generic;

    using StartupJointVenture.Models;
    using StartupJointVenture.Web.Infrastructure.Mapping;

    public class CofounderViewModel : IMapFrom<Cofounder>
    {
        public User User { get; set; }

        public string Location { get; set; }

        public string ProfSkills { get; set; }
    }
}