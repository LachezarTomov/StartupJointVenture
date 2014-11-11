namespace StartupJointVenture.Models
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    

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

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        //[DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [MaxLength(3000)]
        public string Description { get; set; }

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
