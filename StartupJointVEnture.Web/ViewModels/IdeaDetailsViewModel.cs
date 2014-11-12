namespace StartupJointVenture.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using StartupJointVenture.Models;
    using StartupJointVenture.Web.Infrastructure.Mapping;
    
    public class IdeaDetailsViewModel : IMapFrom<Idea>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

   //     public User Author { get; set; }

        public DateTime DateCreated { get; set; }

        public Category Category { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public IEnumerable<Like> Likes { get; set; }

        public IEnumerable<Cofounder> Cofounders { get; set; }
    }
}