namespace StartupJointVenture.Models
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        private ICollection<Idea> ideas;
        private ICollection<Cofounder> cofounders;
        private ICollection<Comment> comments;

        public User()
        {
            this.ideas = new HashSet<Idea>();
            this.cofounders = new HashSet<Cofounder>();
            this.comments = new HashSet<Comment>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Avatar { get; set; }

        public string Description { get; set; }

        //public string City { get; set; }

        //public string ProfSkills { get; set; }

        public virtual ICollection<Idea> Ideas
        {
            get { return this.ideas; }
            set { this.ideas = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Cofounder> Cofounders
        {
            get { return this.cofounders; }
            set { this.cofounders = value; }
        }
    }
}
