﻿namespace StartupJointVenture.Web.ViewModels
{
    using System;

    using StartupJointVenture.Models;
    using StartupJointVenture.Web.Infrastructure.Mapping;
using System.Web.Mvc;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Content { get; set; }

        public User Author { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime DateCreated { get; set; }

    }
}