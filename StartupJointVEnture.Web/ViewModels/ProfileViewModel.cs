namespace StartupJointVenture.Web.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    using StartupJointVenture.Models;
    using StartupJointVenture.Web.Infrastructure.Mapping;
    using System.Collections.Generic;
    
    public class ProfileViewModel : IMapFrom<User>
    {
        [DisplayName("First name")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "First name field must be between {1} and {2} symbols")]
        public string FirstName { get; set; }

        [DisplayName("Last name")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Last name field must be between {1} and {2} symbols")]
        public string LastName { get; set; }

        [DisplayName("Image")]
        [DataType(DataType.Upload)]
        public string ImageUrl { get; set; }

        [StringLength(300, MinimumLength = 3, ErrorMessage = "Description field must be between {1} and {2} symbols")]
        public string Description { get; set; }

        public IEnumerable<Idea> Ideas { get; set; }
    }
}