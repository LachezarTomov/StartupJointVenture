namespace StartupJointVenture.Web.ViewModels
{
    using System;

    using StartupJointVenture.Models;
    using StartupJointVenture.Web.Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public string Content { get; set; }

        public User Author { get; set; }

        public DateTime DateCreated { get; set; }

    }
}