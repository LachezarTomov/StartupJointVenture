namespace StartupJointVenture.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using EventSystem.Data.Repositories;
    using StartupJointVenture.Models;
    using System.Data.Entity;

    public class JointVentureData : IJointVentureData
    {
        private DbContext context;
        private Dictionary<Type, object> repositories;

        public JointVentureData(JointVentureDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public JointVentureData()
            : this(new JointVentureDbContext())
        {
        }

        public IRepository<Idea> Ideas
        { 
            get { return this.GetRepository<Idea>(); }
        }
        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<Like> Likes
        {
            get { return this.GetRepository<Like>(); }
        }
        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<Cofounder> Cofounders
        {
            get { return this.GetRepository<Cofounder>(); }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
