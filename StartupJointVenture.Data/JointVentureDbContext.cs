namespace StartupJointVenture.Data
{
    using System;
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    using StartupJointVenture.Models;
    using StartupJointVenture.Data.Migrations;
 
    public class JointVentureDbContext : IdentityDbContext<User>
    {
        public JointVentureDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<JointVentureDbContext, Configuration>());
        }

        public static JointVentureDbContext Create()
        {
            return new JointVentureDbContext();
        }

        public IDbSet<Idea> Ideas { get; set; }
        public IDbSet<Like> Likes { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<Category> Categories { get; set; }
    }
}
