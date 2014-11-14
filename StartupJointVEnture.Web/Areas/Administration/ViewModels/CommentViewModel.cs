namespace StartupJointVenture.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using System.Web.Mvc;

    using StartupJointVenture.Models;
    using StartupJointVenture.Web.Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Content { get; set; }

        public User Author { get; set; }

        public DateTime DateCreated { get; set; }

        public Idea Idea { get; set; }
    }
}