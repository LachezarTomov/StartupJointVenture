namespace StartupJointVenture.Data
{
    using System;

    using Microsoft.AspNet.Identity.EntityFramework;
    
    using StartupJointVenture.Models;
 
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
