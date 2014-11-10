namespace StartupJointVenture.Web.ViewModels
{
    using System;
    using System.Collections.Generic;

    using StartupJointVenture.Models;
    using StartupJointVenture.Web.Infrastructure.Mapping;

    public class CofounderViewModel : IMapFrom<User>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Avatar { get; set; }

        public string City { get; set; }

        public string ProfSkills { get; set; }
    }
}