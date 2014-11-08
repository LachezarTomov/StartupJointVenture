namespace StartupJointVenture.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    using StartupJointVenture.Models;
    using StartupJointVenture.Web.Infrastructure.Mapping;
    
    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}