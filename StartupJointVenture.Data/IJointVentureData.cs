namespace StartupJointVenture.Data
{
    using EventSystem.Data.Repositories;
    using StartupJointVenture.Models;

    public interface IJointVentureData
    {
        IRepository<Idea> Ideas { get; }
        IRepository<Category> Categories { get; }
        IRepository<Like> Likes { get; }
        IRepository<Comment> Comments { get; }
        int SaveChanges();
    }
}
