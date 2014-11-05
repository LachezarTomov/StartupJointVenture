namespace StartupJointVenture.Data
{
    using System;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    using StartupJointVenture.Models;
    using StartupJointVenture.Data.Migrations;
 
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Idea> Ideas { get; set; }
        public IDbSet<Like> Likes { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Category> Categorys { get; set; }
    }
}
