namespace StartupJointVenture.Web.ViewModels
{
    using StartupJointVenture.Models;
    using StartupJointVenture.Web.Infrastructure.Mapping;
   
    public class IdeaSampleViewModel : IMapFrom<Idea>
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}